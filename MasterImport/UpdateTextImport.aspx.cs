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
using System.Data.SqlTypes;
using Microsoft.VisualBasic;

namespace Man.MasterImport
{
    public partial class UpdateTextImport : Man.PageBase
    {
        public string GetPath
        {
            get
            {
                return "../Update/Tmp/" + Page.User.Identity + "/";
            }
        }

        protected DataTable FileListTable
        {
            get
            {
                object obj = ViewState["FileListTable"];
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return (DataTable)obj;
                }
            }
            set
            {
                ViewState["FileListTable"] = value;
            }
        }

        /// <summary>
        /// Init file list table
        /// </summary>
        private void InitFileListTable()
        {
            DbHelper.FillList(drpSite, "Select * from Site where TypeId = 1", "Name", "Id");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitFileListTable();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string importType = "";

            if (!fileUpload.HasFile)
            {
                mvImportMaster.AddError("ファイルを見つかりません・・・");
                return;
            }
            CsvReader csvRead = null;

            try
            {
                // Binh add start
                 // add all of GenreId into Hashtable
                Hashtable map = new Hashtable();
                // Binh add end
                string[] array = fileUpload.FileName.Split('.');
                string ext = string.Empty;
                if (array.Length > 0)
                {
                    ext = array[array.Length - 1];
                }
                if (ext.Length == 0) return;

                ext = ext.ToUpper();

                if (!"csv".Equals(ext.ToLower()))
                {
                    mvImportMaster.AddError("CSVファイルを選択してください・・・");
                    return;
                }
                if (File.Exists(Server.MapPath("./") + fileUpload.FileName))
                {
                    File.Delete(Server.MapPath("./") + fileUpload.FileName);
                }
                fileUpload.SaveAs(Server.MapPath("./") + fileUpload.FileName);

                csvRead = new CsvReader(Server.MapPath("./") + fileUpload.FileName, true, ',');
                csvRead.IsCheckQuote = true;

                string[] dataHeader = null;
                string[] dbRef = null;
                if (rdoSong.Checked)
                {
                    importType = "1";
                    dataHeader = Constants.ImportUpdateSongPRTextHeader;
                    dbRef = Constants.ImportUpdateSongPRTextDbRef;
                }
                else if (rdoAlbum.Checked)
                {
                    importType = "2";
                    dataHeader = Constants.ImportUpdateAlbumCommentHeader;
                    dbRef = Constants.ImportUpdateAlbumCommentDbRef;
                }
                else if (rdoArtist.Checked)
                {
                    importType = "3";
                    // Binh update start
                    //dataHeader = Constants.ImportUpdateArtistProfileHeader;
                    ArrayList arrayListHeader = new ArrayList();
                    arrayListHeader.AddRange(Constants.ImportUpdateArtistProfileHeader);

                    DataTable dtGenre = new DataTable();
                    string genreName;
                    string genreId;
                    string sql1 = "SELECT GenreId, Name FROM Genre";
                    dtGenre = DbHelper.GetDataTable(sql1);
                    foreach (DataRow row in dtGenre.Rows)
                    {
                        genreId = Func.ParseString(row["GenreId"]);
                        genreName = Func.ParseString(row["Name"]);
                        arrayListHeader.Add(genreName);
                        map.Add(genreName, genreId);
                    }
                    
                    dataHeader = (string[])arrayListHeader.ToArray(typeof(string));
                    // Binh update end
                    dbRef = Constants.ImportUpdateArtistProfileDbRef;
                }

                string sql = "DELETE FROM SongAlbumArtistTmp WHERE SessionId='" + Session.SessionID + "' and ImportType = '" + importType + "'";
                DbHelper.ExecuteNonQuery(sql);


                DataTable dt = new DataTable();
                DataTable dtTmp = new DataTable();
                dt.Load(csvRead);

                

                string[] header = csvRead.GetFieldHeaders();

                if (!validFormat(dt))
                {
                    return;
                }

                if (dt.Rows.Count > 0)
                {

                    //フォーマットﾁｪｯｸ
                    for (int i = 0; i < dataHeader.Length; i++)
                    {
                        if (!dataHeader[i].ToUpper().Equals(header[i].ToUpper()))
                        {
                            mvImportMaster.AddError("CSVファイルのヘッダー部分が間違っています・・・");
                            return;
                        }
                    }

                    dt.Columns.Add("SessionId", Type.GetType("System.String"));
                    dt.Columns.Add("ImportType", Type.GetType("System.String"));

                    dt.Columns.Add("DelFlag", Type.GetType("System.String"));
                    dt.Columns.Add("Updated", Type.GetType("System.String"));
                    dt.Columns.Add("Updator", Type.GetType("System.String"));
                    dt.Columns.Add("Created", Type.GetType("System.String"));
                    dt.Columns.Add("Creator", Type.GetType("System.String"));
                    // Binh add start
                    dt.Columns.Add("GenreId01", Type.GetType("System.String"));
                    dt.Columns.Add("GenreId02", Type.GetType("System.String"));
                    // Binh add end                        
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SessionId"] = Session.SessionID;
                        dt.Rows[i]["ImportType"] = importType;
                        dt.Rows[i]["DelFlag"] = "0";
                        dt.Rows[i]["Updated"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Updator"] = Page.User.Identity.Name;
                        dt.Rows[i]["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Creator"] = Page.User.Identity.Name;
                    }
                    // Binh add start
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strTemp01 = "";
                        string strTemp02 = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (map.ContainsKey(dt.Columns[j].ToString()))
                            {
                                if (dt.Rows[i][dt.Columns[j]].Equals("1"))
                                {
                                    if ((map[dt.Columns[j].ToString()].Equals("G-001")) || (map[dt.Columns[j].ToString()].Equals("G-002")))
                                        if ("".Equals(strTemp01))
                                            strTemp01 = map[dt.Columns[j].ToString()].ToString();
                                        else
                                            strTemp01 += "," + map[dt.Columns[j].ToString()].ToString();
                                    else
                                        if ("".Equals(strTemp02))
                                            strTemp02 = map[dt.Columns[j].ToString()].ToString();
                                        else
                                            strTemp02 += "," + map[dt.Columns[j].ToString()].ToString();
                                }
                            }
                        }
                        dt.Rows[i]["GenreId01"] = strTemp01;
                        dt.Rows[i]["GenreId02"] = strTemp02;
                    }
                    // Binh add end
                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "SongAlbumArtistTmp";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        // Binh update start
                        //for (int i = 0; i < dataHeader.Length; i++)
                        for (int i = 0; i < (dataHeader.Length - map.Count); i++)
                        {
                            copy.ColumnMappings.Add(i, dbRef[i]);
                        }
                        

                        copy.ColumnMappings.Add(dt.Columns.Count - 9, "SessionId");
                        copy.ColumnMappings.Add(dt.Columns.Count - 8, "ImportType");
                        copy.ColumnMappings.Add(dt.Columns.Count - 7, "DelFlag");
                        copy.ColumnMappings.Add(dt.Columns.Count - 6, "Updated");
                        copy.ColumnMappings.Add(dt.Columns.Count - 5, "Updator");
                        copy.ColumnMappings.Add(dt.Columns.Count - 4, "Created");
                        copy.ColumnMappings.Add(dt.Columns.Count - 3, "Creator");
                        // Binh add start
                        copy.ColumnMappings.Add(dt.Columns.Count - 2, "GenreId01");
                        copy.ColumnMappings.Add(dt.Columns.Count - 1, "GenreId02");
                        // Binh add end
                        copy.WriteToServer(dt);
                    }
                }
                                
                Session["FolderPath"] = fileUpload.FileName;
                Session["ImportType"] = importType;
                Response.Redirect("ListUpdateTextImport.aspx", false);
            }
            catch (Exception ex)
            {
                mvImportMaster.AddError("エラーが発生しました: " + ex.Message);
            }
            finally
            {
                if (csvRead != null)
                {
                    csvRead.Dispose();
                }
            }
        }

        private bool validFormat(DataTable dt)
        {
            Hashtable tmpKey = new Hashtable();

            bool valid = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strID = !(dt.Rows[i][0] is System.DBNull) ? (string)dt.Rows[i][0] : "";
                if (tmpKey.Contains(strID))
                {
                    mvImportMaster.AddError(strID + "が重複です。");
                    valid = false;
                    continue;
                }
                else
                {
                    tmpKey.Add(strID, strID);
                }
            }
            return valid;
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string csv = "";
            DataSet dsSite = new DataSet();
            DataSet ds = new DataSet();
            string kind = "";
            kind = "Song";
            
            string ss = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmm");
            string tmpFolder = Server.MapPath("./") + "DownloadCSV" + "/" + Page.User.Identity.Name + "/" + ss;// +DateTime.Now.ToString("yyyyMMddHHmmss");
            if (Directory.Exists(tmpFolder))
            {
                string[] files = Directory.GetFiles(tmpFolder);
                foreach (string file in files) { }
                    //File.Delete(file);
            }
            else
            {
                Directory.CreateDirectory(tmpFolder);
            }

            try
            {
                string sqlHaishinDate = "";
                
                if (!"".Equals(txtHaishinDate.Text.Trim()))
                {
                    sqlHaishinDate += " AND SM.HaishinDate >= Convert(datetime,'" + txtHaishinDate.Text.Trim() + "')";
                }
                if (!"".Equals(txtHaishinEndDate.Text.Trim()))
                {
                    sqlHaishinDate += " AND SM.HaishinDate <= Convert(datetime,'" + txtHaishinEndDate.Text.Trim() + "')";
                }

                if ("".Equals(sqlHaishinDate))
                {
                    mvImportMaster.AddError("条件【配信日】を記入してください。");
                    return;
                }

                kind = "VSongArtistAlbum";
                string outFile = tmpFolder + "\\" + "Song_" + ss + ".csv";
                StreamWriter tmpFileSW = new StreamWriter(outFile, false, System.Text.Encoding.GetEncoding("Shift_JIS"));
                ds = DbHelper.GetMstrData(  " Select V.SongMediaId, V.Title,V.AID,V.ArtistName,V.AlbumId,V.Album,V.契約者ID,V.契約者名, SongSite.PRText " +
                                            " From (SELECT  Distinct SongMediaId, Title,AID,ArtistName,AlbumId,Album,契約者ID,契約者名 " +
                                            " FROM VSongArtistAlbum SM Where 1=1 " + sqlHaishinDate + ") V Left outer join SongSite on " +
                                            " SongSite.SongId = V.SongMediaId and SongSite.SiteId = '1' ");

                csv = Func.CreateCSV(ds, true);
                tmpFileSW.WriteLine(csv);
                tmpFileSW.Close();

                outFile = tmpFolder + "\\" + "Artist_" + ss + ".csv";
                tmpFileSW = new StreamWriter(outFile, false, System.Text.Encoding.GetEncoding("Shift_JIS"));
                // Binh update start
                //ds = DbHelper.GetMstrData(  "  SELECT tmp.ArtistId AS AID, Artist.Name AS ArtistName, Contractor.Name AS 契約者名, Artist.Profile"
                //                            +" FROM   (SELECT DISTINCT S.ArtistId, S.ContractorId"
                //                            +"        FROM Song S INNER JOIN SongMedia SM ON S.SongId = SM.SongId "+ sqlHaishinDate +") AS tmp "
                //                            +"        LEFT OUTER JOIN Artist ON Artist.ArtistId = tmp.ArtistId "
                //                            +"        LEFT OUTER JOIN Contractor ON Contractor.ContractorId = tmp.ContractorId");
                ds = DbHelper.GetMstrData(getInputString(txtHaishinDate.Text.ToString(), txtHaishinEndDate.Text.ToString()));
                // Binh Update end
                csv = Func.CreateCSV(ds, true);
                tmpFileSW.WriteLine(csv);
                tmpFileSW.Close();

                outFile = tmpFolder + "\\" + "Album_" + ss + ".csv";
                tmpFileSW = new StreamWriter(outFile, false, System.Text.Encoding.GetEncoding("Shift_JIS"));
                ds = DbHelper.GetMstrData("  SELECT tmp.AlbumId, Album.Title AS Album, Album.CdId AS CDID, tmp.ArtistId AS AID, Artist.Name AS ArtistName, Contractor.Name AS 契約者名, Album.SaleDate as 発売日, Album.Comment , case when Album.JacketFlag = 'true' then '1' else '0' end 写FL"
                                            +" FROM   ( SELECT DISTINCT S.ArtistId, S.AlbumId, S.ContractorId"
                                            +"          FROM   Song S INNER JOIN SongMedia SM ON S.SongId = SM.SongId "+ sqlHaishinDate +") AS tmp "
                                            +" LEFT OUTER JOIN Album ON Album.AlbumId = tmp.AlbumId LEFT OUTER JOIN Artist ON Artist.ArtistId = tmp.ArtistId "
                                            +" LEFT OUTER JOIN Contractor ON Contractor.ContractorId = tmp.ContractorId ");
                csv = Func.CreateCSV(ds, true);
                tmpFileSW.WriteLine(csv);
                tmpFileSW.Close();

                string fileName = "UpdateText" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip";
                Func.ZipFiles(tmpFolder, tmpFolder + "\\" + fileName, "");
                Session["ZipFilePath"] = tmpFolder + "\\" + fileName;
            }
            catch (Exception ex)
            {
                ICJSystem.Instance.Log.Error(ex.Message);
            }
            Session["DownloadCsvContent"] = csv;
            Session["Kind"] = kind;

            mvImportMaster.SetCompleteMessage("CSV出力完了しました。");
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../CSV/DownloadZipFile.aspx'," + 10 + "," + 10 + ",'EditAlbum', true);", true);
        }
        /// <summary>
        /// Binh create getInputString function
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        private string getInputString(string dateFrom, string dateTo)
        {
            SqlConnection mySqlConnection = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString);
            string returnValue = "";
            try
            {
                // open the database connection using the
                // Open() method of the SqlConnection object
                mySqlConnection.Open();
                // formulate a string containing the name of the
                // stored procedure
                string procedureString = "CROSSTAB";
                
                // create a SqlCommand object to hold the SQL statement
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                
                // set the CommandText property of the SqlCommand object to
                // procedureString
                mySqlCommand.CommandText = procedureString;

                // set the CommandType property of the SqlCommand object
                // to CommandType.StoredProcedure
                mySqlCommand.CommandType = CommandType.StoredProcedure;

                mySqlCommand.Parameters.Add(new SqlParameter("@dateFrom", SqlDbType.VarChar, 10)).Value = dateFrom;
                mySqlCommand.Parameters.Add(new SqlParameter("@dateTo", SqlDbType.VarChar, 10)).Value = dateTo;
                mySqlCommand.Parameters.Add("@outString", SqlDbType.VarChar, 8000).Direction = ParameterDirection.Output;

                //mySqlCommand.Parameters[0].Value =  Page.User.Identity.Name;

                // run the stored procedure
                mySqlCommand.ExecuteNonQuery();
                returnValue=  mySqlCommand.Parameters["@outString"].Value.ToString();
            }
            catch (Exception ex)
            {
                ICJSystem.Instance.Log.Error(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return returnValue;
        }

    }
}
