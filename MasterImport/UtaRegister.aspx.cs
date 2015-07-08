using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Gnt.Data.DBCommand;
using Gnt.Data;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using Man.Utils;
using System.IO;
using Gnt.Utils.FastCsv;

namespace Man.MasterImport
{
    public partial class UtaRegister : Man.PageBase
    {
        private Hashtable songHash = new Hashtable();
        private string action = String.Empty;
        private string id=String.Empty;

        /// <summary>
        /// Init values
        /// </summary>
        private void InitValues()
        {
            DbHelper.FillList(drpType, "SELECT TypeId, Type FROM Type where DelFlag=0 and TypeId in ('2','3')", "Type", "TypeId");

            drpOngen.DataSource = Constants.OngenType;
            drpOngen.DataBind();
            drpOngen.SelectedIndex = 0;

            btnFileGet.OnClientClick = "return confirm('読み込み開始です。よろしいですか？');";

            txtPath.Text = DbHelper.GetScalar("Select " + Constants.UtaRigisterPath + " from Path where Id = 1");
        }
        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            InitValues();
        }                
        protected override void DoGet()
        {
        }

        protected override void DoPost()
        {
        }
        protected void btnFileGet_Click(object sender, EventArgs e)
        {
            mvFileGetter.CheckRequired(txtPath, "フォルダバスを入力してください");

            try
            {
                if (!mvFileGetter.IsValid) return;

                int funcId = 0;
                MoneWs.Service ws = new MoneWs.Service();
                string fileListCSV = "";
                string basicPath = Func.GetBasicPath(ws);
                string folderName = txtPath.Text.Trim();

                if (!Func.FolderExists(ws, folderName))
                {
                    mvFileGetter.AddError(folderName + "フォルダが見つかりませんでした・・・");
                    return;
                }

                string[] a = {drpOngen.SelectedItem.Text};
                funcId = Constants.UtaRegister;
                fileListCSV = Func.FileSizeGetter(ws, folderName, a);

                CsvReader csvRead = new CsvReader(new StringReader(fileListCSV), true, ',');
                
                while (csvRead.ReadNextRecord())
                {
                    string col1 = csvRead[0];
                    string col2 = csvRead[1];
                    string col3 = csvRead[2];
                    string col4 = csvRead[3];
                    
                    string filebs = col1;
                    if (filebs.Length > 8)
                    {
                        string getwid = filebs.Substring(0, 8);
                        string abc = filebs.Substring(8, 1);
                        if (insertFlg(getwid, abc, drpType.SelectedItem.Value))
                        {
                            FileGetterData data = new FileGetterData();
                            data.SessionId = Session.SessionID;
                            data.FuncId = Func.ParseString(funcId);
                            data.SongId = col1;
                            data.Extension = getwid;
                            songHash.Add(col1, data);
                        }
                    }
                }


                string sql = "DELETE FROM FileGetter WHERE SessionId='" + Session.SessionID + "' and FuncId = '" + funcId + "'";
                DbHelper.ExecuteNonQuery(sql);

                if (!(songHash != null && songHash.Count > 0))
                {
                    mvFileGetter.AddError("指定したフォルダバスには適当なファイルがありません。");
                    return;
                }
                
                foreach (FileGetterData data in songHash.Values)
                {
                    ITransaction tran = factory.GetInsertObject(data);
                    Execute(tran);
                }

                Session["FuncId"] = funcId;
                Session["TypeId"] = drpType.SelectedItem.Value;
                Session["FolderPath"] = folderName;
                Session["TypeName"] = drpType.SelectedItem.Text;
                Response.Redirect("ListUtaRegister.aspx", false);
                
            }
            catch (Exception ex)
            {
                mvFileGetter.AddError("エラーが発生しました: " + ex.Message);
            }
            finally
            {
            }
        }
        
        protected bool insertFlg(string WID, string EDA, string typeId)
        {

            if ("".Equals(WID) || WID == null)
            {
                return false;
            }
            if ("".Equals(EDA) || EDA == null)
            {
                return false;
            }

            SongMediaData songMediaData = new SongMediaData();
            ISearchTransaction tran = factory.GetSearchObject(songMediaData);
            tran.Where = songMediaData.ColSongMediaId + "='" + WID + EDA + "' and " + songMediaData.ColDelFlag + "='0'";
            Execute(tran);
            if (!HasError)
            {
                if (tran.Count != 1)
                {
                    SongData songData = new SongData();
                    ISearchTransaction tranExist = factory.GetSearchObject(songData);
                    tranExist.Where = songData.ColSongId + "='" + WID + "' and " + songData.ColDelFlag + "='0'";
                    Execute(tranExist);
                    if (!HasError)
                    {
                        if (tranExist.Count == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected void btnSavePath_Click(object sender, EventArgs e)
        {
            mvFileGetter.CheckRequired(txtPath, "フォルダバスを入力してください");
            if (!mvFileGetter.IsValid)
            {
                return;
            }

            MoneWs.Service ws = new Man.MoneWs.Service();
            if (!Func.FolderExists(ws, txtPath.Text.Trim()))
            {
                mvFileGetter.AddError("【" + txtPath.Text + "】を見つかれません...");
                return;
            }
            DbHelper.ExecuteNonQuery("Update Path set " + Constants.UtaRigisterPath + " = '" + txtPath.Text.Trim() + "' where Id = 1");
        }
    }
}