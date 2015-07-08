using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Gnt.Configuration;
using System.Collections;
using Gnt.Transaction;
using System.IO;
using Gnt.Data;
using Gnt.Data.DBCommand;
using BusinessObjects;
using Man.Utils;

namespace Man.Utils
{
    public class PostToFile
    {
        private string mstTable = string.Empty;
        private string selectFields = string.Empty;
        private string where = string.Empty;
        private string delFlag = string.Empty;
        private DataSet dsSite = null;
        private string action = string.Empty;
        private bool logFlg = false;
        private string key = "";
        private string userName = "";

        public PostToFile(string mstTable, string key, string selectFields, string where, string delFlag, DataSet dsSite, string action, bool logFlg,string userName)
        {
            this.mstTable = mstTable;
            this.selectFields = selectFields;
            this.where = where;
            this.delFlag = delFlag;
            this.dsSite = dsSite.Copy();
            this.action = action;
            this.logFlg = logFlg;
            this.key = key;
            this.userName = userName;
        }

        public void Post()
        {
            DataSet ds = new DataSet();
            string kind = mstTable.ToLower();
            if (mstTable.ToLower().IndexOf("song") >= 0)
            {
                kind = "song";
            }
            // For Each Site
            foreach (DataRow drSite in dsSite.Tables[0].Rows)
            {
                try
                {
                    string siteId = drSite["Id"].ToString();
                    string siteUrl = drSite["Url"].ToString();
                    string siteType = drSite["TypeId"].ToString();

                    ApplicationLog.WriteError(string.Format("SiteId: {0} SiteURL {1} ", siteId, siteUrl));

                    ds = DbHelper.GetMstrData(mstTable, selectFields, where, delFlag, siteId);
                    if ("".Equals(siteUrl))
                    {
                        continue;
                    }
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string path = System.Configuration.ConfigurationManager.AppSettings["SynchornizeFile"] + "/" + DateTime.Now.ToString("yyyyMMdd") + "/" + kind + "/" + "Site_" + siteId;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        StreamWriter csvCreator = new StreamWriter(path + "/" + fileName + "_" + userName + ".txt", false, System.Text.Encoding.GetEncoding("Shift_JIS"));
                        csvCreator.Close();

                        ArrayList csvList = Func.CreateCSVList(ds, true);
                        for (int i = 0; i < csvList.Count; i++)
                        {
                            string csvSend = (string)csvList[i];
                            StreamWriter csvFile = new StreamWriter(path + "/" + fileName + "_" + i.ToString().PadLeft(2, '0') + ".csv", false, System.Text.Encoding.GetEncoding("Shift_JIS"));

                            csvFile.WriteLine(csvSend);
                            csvFile.Close();


                            Gnt.Utils.CustomWebRequest wr = new Gnt.Utils.CustomWebRequest(siteUrl);
                            wr.ParamsCollection.Add(new Gnt.Utils.ParamsStruct("file", csvSend, Gnt.Utils.ParamsStruct.ParamType.File, fileName));
                            wr.ParamsCollection.Add(new Gnt.Utils.ParamsStruct("kind", kind));
                            wr.ParamsCollection.Add(new Gnt.Utils.ParamsStruct("action", action.ToLower()));
                            if (this.logFlg)
                            {
                                wr.PostData();
                                string[,] resultSync;
                                resultSync = new string[100, 3];
                                string ret = wr.ResponseString;
                                resultSync[int.Parse(siteId), 0] = ret;
                                //writeLog(resultSync);
                            }
                            else
                            {
                                //wr.PostDataNoResponse();
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    ApplicationLog.WriteError(exc);
                }
            }
        }

        private void writeLog(string[,] resultSync)
        {
            SqlDatabase db = new SqlDatabase();
            SqlCommand cm = db.CreateCommand("SELECT Id, Name FROM Site where DelFlag=0");
            SqlDataReader reader = cm.ExecuteReader();
            int countRec = 0;
            bool skip = false;
            Hashtable siteList = new Hashtable();
            while (reader.Read())
            {
                siteList.Add(reader[0], reader[1]);
            }
            string lastSynchronizer = userName;
            string lastSynchDated = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string[] lines = new string[100];
            string[] results = new string[3];

            if (resultSync is System.Array)
            {
                for (int i = 0; i < resultSync.GetLength(0); ++i)
                {
                    skip = false;
                    string siteName = "";

                    for (int j = 0; j < resultSync.GetLength(1); ++j)
                    {
                        if (!string.IsNullOrEmpty(resultSync[i, j]))
                        {
                            foreach (DictionaryEntry de in siteList)
                            {
                                if (de.Key.ToString().Equals("" + i))
                                {
                                    siteName = de.Value.ToString();
                                    break;
                                }
                            }

                            lines = resultSync[i, j].Split('\n');
                            foreach (string line in lines)
                            {
                                if (!skip)
                                {
                                    skip = true;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(line))
                                    {
                                        countRec++;
                                        if ("update".Equals(action.ToLower()) || "updatemass".Equals(action.ToLower()) || "updateonly".Equals(action.ToLower()) || "updateonlymass".Equals(action.ToLower()))
                                        {
                                            results = line.Split(',');
                                            string sql = "";
                                            string id = (string)results[0];

                                            int count = 0;

                                            string updatedStatus = "";
                                            if ("203".Equals((string)results[1]) || "204".Equals((string)results[1]))
                                            {
                                                updatedStatus = "1";
                                            }

                                            if (!(mstTable.ToLower().IndexOf("song") >= 0))
                                            {
                                                string sqlCount = " Select count(*) from " + mstTable + "Site WHERE " + key + "='" + id + "' and SiteId = '" + i + "'";
                                                count = DbHelper.GetCount(sqlCount);

                                                sql = "UPDATE " + mstTable + "Site set sendResult = '" + (string)results[2] + "'";
                                                sql += " , PrevSynchronizer = LastSynchronizer, PrevSynchDated = LastSynchDated, LastSynchronizer = '" + lastSynchronizer + "' ";
                                                sql += " , LastSynchDated = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', DelFlag = '0' WHERE " + key + "='" + id + "' and SiteId = '" + i + "'";
                                                if (count == 0)
                                                {
                                                    sql = "Insert into " + mstTable + "Site (" + key + ", SiteId, LastSynchronizer, LastSynchDated, SendResult, DelFlag) values('" + id + "', '" + i + "', '" + lastSynchronizer + "', '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', '" + (string)results[2] + "', '0')";
                                                }
                                            }
                                            else
                                            {
                                                string sqlCount = " Select count(*) from SongSite WHERE SongId ='" + id + "' and SiteId = '" + i + "'";
                                                count = DbHelper.GetCount(sqlCount);

                                                sql = "UPDATE SongSite set sendResult = '" + (string)results[2] + "'";
                                                sql += " , PrevSynchronizer = LastSynchronizer, PrevSynchDated = LastSynchDated, LastSynchronizer = '" + lastSynchronizer + "' ";
                                                sql += " , Updator = '" + lastSynchronizer + "', Updated = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "'";
                                                sql += " , LastSynchDated = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', DelFlag = '0' , UpdatedStatus = '" + updatedStatus + "' WHERE " + key + "='" + id + "' and SiteId = '" + i + "'";

                                                if (count == 0)
                                                {
                                                    sql = "Insert into SongSite (" + key + ", SiteId, LastSynchronizer, LastSynchDated, SendResult, DelFlag,Creator, Created) values('" + id + "', '" + i + "', '" + lastSynchronizer + "', '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "', '" + (string)results[2] + "', '0','" + lastSynchronizer + "','" + DateTime.Now.ToString("yyyyMMddHHmmss") + "')";
                                                }
                                            }
                                            DbHelper.ExecuteNonQuery(sql);

                                            //編集した値をDBに既存データを取得して設定する。
                                            DbHelper.ExecuteNonQuery("INSERT INTO SynLog VALUES ('" + mstTable + "' ,'" + id + "', '" + siteName + "' ,'" + this.action + "','" + lastSynchDated + "' ,'" + userName + "' ,'" + (string)(results[1] + "(" + results[2] + ")") + "')");

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
