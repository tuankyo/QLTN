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
using System.Text;
using Gnt.Utils.FastCsv;
using System.Data.SqlTypes;
using Microsoft.VisualBasic;

namespace Man.MasterImport
{
    public partial class NewMasterImport : Man.PageBase
    {
        private string importType = "1";

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
            if (!fileUpload.HasFile)
            {
                mvImportMaster.AddError("ファイルを見つかりません・・・");
                return;
            }
            CsvReader csvRead = null;
            Hashtable artistKeyMap = new Hashtable();
            Hashtable labelKeyMap = new Hashtable();
            Hashtable albumKeyMap = new Hashtable();
            StringBuilder updSql = new StringBuilder();

            string[] excAlbumName = { "ﾊﾟｯｹｰｼﾞﾅｼ",
                                        "ﾊﾟｯｹｰｼﾞなし",
                                        "ﾊﾟｯｹｰｼﾞ未発売",
                                        "ﾊﾟｯｹｰｼﾞ未発売のためなし",
                                        "先行配信",
                                        "配信ｼﾝｸﾞﾙ",
                                        "配信限定",
                                        "配信限定ﾊﾟｯｹｰｼﾞのためなし",
                                        "配信限定楽曲",
                                        "未定",
                                        "ﾀｲﾄﾙ未定",
                                        "配信限定商品" };

            string[] excAlbumNameYomi = { "ﾊﾟｯｹｰｼﾞﾅｼ",
                                        "ﾊｯｹｰｼﾞﾐﾊﾂﾊﾞｲ",
                                        "ﾊｯｹｰｼﾞﾐﾊﾂﾊﾞｲﾉﾀﾒﾅｼ",
                                        "ｾﾝｺｳﾊｲｼﾝ",
                                        "ﾊｲｼﾝｹﾞﾝﾃｲｼﾝｸﾞﾙ",
                                        "ﾊｲｼﾝｹﾞﾝﾃｲ",
                                        "ﾊｲｼﾝｹﾞﾝﾃｲﾊﾟｯｹｰｼﾞﾉﾀﾒﾅｼ",
                                        "ﾊｲｼﾝｹﾞﾝﾃｲｶﾞｯｷｮｸ",
                                        "ﾐﾃｲ",
                                        "ﾀｲﾄﾙﾐﾃｲ",
                                        "ﾊｲｼﾝｹﾞﾝﾃｲｼｮｳﾋﾝ"};
            try
            {
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
                string sql = "DELETE FROM SongImport WHERE SessionId='" + Session.SessionID + "' and ImportType = '"+ importType +"'";
                DbHelper.ExecuteNonQuery(sql);
                sql = "DELETE FROM SongMediaTemp WHERE SessionId='" + Session.SessionID + "' and ImportType = '" + importType + "'";
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
                    for (int i = 0; i < Constants.ImportDataHeader.Length; i++)
                    {
                        if (!Constants.ImportDataHeader[i].Equals(header[i]))
                        {
                            mvImportMaster.AddError("CSVファイルのヘッダー部分が間違っています・・・");
                            return;
                        }
                    }

                    dt.Columns.Add("SessionId", Type.GetType("System.String"));
                    dt.Columns.Add("ImportType", Type.GetType("System.String"));
                    dt.Columns.Add("Status");

                    dt.Columns.Add("DelFlag", Type.GetType("System.String"));
                    dt.Columns.Add("Updated", Type.GetType("System.String"));
                    dt.Columns.Add("Updator", Type.GetType("System.String"));
                    dt.Columns.Add("Created", Type.GetType("System.String"));
                    dt.Columns.Add("Creator", Type.GetType("System.String"));

                    
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

                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "SongImport";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        for (int i = 0; i < Constants.ImportDataHeader.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportDataDbRef[i]);
                        }

                        copy.ColumnMappings.Add(dt.Columns.Count - 8, "SessionId");
                        copy.ColumnMappings.Add(dt.Columns.Count - 7, "ImportType");
                        copy.ColumnMappings.Add(dt.Columns.Count - 6, "Status");

                        copy.ColumnMappings.Add(dt.Columns.Count - 5, "DelFlag");
                        copy.ColumnMappings.Add(dt.Columns.Count - 4, "Updated");
                        copy.ColumnMappings.Add(dt.Columns.Count - 3, "Updator");
                        copy.ColumnMappings.Add(dt.Columns.Count - 2, "Created");
                        copy.ColumnMappings.Add(dt.Columns.Count - 1, "Creator");

                        copy.WriteToServer(dt);
                    }
                }

                DbHelper.ExecuteNonQuery("Update SongImport set Status = 1 where SessionId = '" + Session.SessionID + "' and ImportType = '"+ importType +"' and SongId in (Select SongMediaId from SongMedia where TypeId = '1')");

                sql = "Select * from SongImport where SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
                SqlDatabase db = new SqlDatabase();
                DataSet ds = new DataSet();
                DataSet dsTmp = new DataSet();

                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                dt = ds.Tables[0];

                string autoKeyArtist = "";
                string autoKeyLabel = "";
                string autoKeyAlbum = "";

                //record
                foreach (DataRow row in dt.Rows)
                {
                    //曲ID
                    string songId = row["SongId"].ToString().ToUpper();

                    //ｱｰﾃｨｽﾄ名(半角)	ArtistName
                    string artistName = row["ArtistName"].ToString().Replace("'", "''").ToUpper();
                    //ｱｰﾃｨｽﾄ名ﾖﾐ(半角)	ArtistNameReadingFull
                    string artistNameReadingFull = row["ArtistNameReadingFull"].ToString().Replace("'", "''").ToUpper();

                    string artistId = row["ArtistId"].ToString().ToUpper();

                    if ("".Equals(artistId) || artistId == null)
                    {
                        if (!artistKeyMap.Contains(artistName) &&
                            !artistKeyMap.Contains(artistNameReadingFull) &&
                            !artistKeyMap.Contains(artistName + "_" + artistNameReadingFull))
                        {
                            ArtistData artistData = new ArtistData();
                            string sqlArtist01 = "UPPER(" + artistData.ObjectKeyTableName + artistData.ColName + ") = '" + artistName + "' and UPPER(" + artistData.ObjectKeyTableName + artistData.ColNameReadingFull + ") = '" + artistNameReadingFull + "'";
                            string sqlArtist02 = "UPPER(" + artistData.ObjectKeyTableName + artistData.ColName + ") = '" + artistName + "' ";
                            string sqlArtist03 = "UPPER(" + artistData.ObjectKeyTableName + artistData.ColNameReadingFull + ") = '" + artistNameReadingFull + "'";
                            string[] sqlWhereArtist = { sqlArtist01 };

                            artistId = GetKey(artistData, sqlWhereArtist);
                            if ("".Equals(artistId) || artistId == null)
                            {
                                string sqlTemp = "SELECT count(*) " + artistData.ObjectKeyColumnName + " FROM " + artistData.ObjectKeyTableName + " WHERE " + sqlArtist02;
                                int count1 = Func.ParseInt(DbHelper.GetScalar(sqlTemp));
                                sqlTemp = "SELECT count(*) FROM " + artistData.ObjectKeyTableName + " WHERE " + sqlArtist03;
                                int count2 = Func.ParseInt(DbHelper.GetScalar(sqlTemp));

                                if (count1 + count2 >= 1)
                                {
                                    artistId = "ERROR";
                                }
                                else
                                {
                                    if ("".Equals(autoKeyArtist) || autoKeyArtist == null)
                                    {
                                        artistId = CreateKey(artistData, artistData.ObjectType.Prefix);
                                    }
                                    else
                                    {
                                        string prefix = artistData.ObjectType.Prefix;
                                        int length = artistData.KeyAttributeData.MaxLength;
                                        string tmp = autoKeyArtist.Replace(prefix, "");
                                        int i = Func.ParseInt(tmp) + 1;
                                        artistId = prefix + Func.ParseString(i).PadLeft(length - prefix.Length, '0');
                                    }
                                    autoKeyArtist = artistId;
                                }
                            }

                            if (!artistKeyMap.Contains(artistName))
                            {
                                artistKeyMap.Add(artistName, artistId);
                            }
                            if (!artistKeyMap.Contains(artistNameReadingFull))
                            {
                                artistKeyMap.Add(artistNameReadingFull, artistId);
                            }
                            if (!artistKeyMap.Contains(artistName + "_" + artistNameReadingFull))
                            {
                                artistKeyMap.Add(artistName + "_" + artistNameReadingFull, artistId);
                            }
                        }
                        else
                        {
                            if (!"".Equals((string)artistKeyMap[artistName]))
                            {
                                artistId = (string)artistKeyMap[artistName];
                            }

                            if ("".Equals(artistId) || artistId == null)
                            {
                                if (!"".Equals((string)artistKeyMap[artistNameReadingFull]))
                                {
                                    artistId = (string)artistKeyMap[artistNameReadingFull];
                                }
                            }

                            if ("".Equals(artistId) || artistId == null)
                            {
                                if (!"".Equals((string)artistKeyMap[artistName + "_" + artistNameReadingFull]))
                                {
                                    artistId = (string)artistKeyMap[artistName + "_" + artistNameReadingFull];
                                }
                            }
                        }
                    }
                    
                    //ﾚｰﾍﾞﾙ名(半角)	    LabelName
                    string labelName = row["LabelName"].ToString().Replace("'", "''").ToUpper();
                    string labelId = row["LabelId"].ToString().ToUpper();
                    if ("".Equals(labelId) || labelId == null)
                    {
                        if (!labelKeyMap.Contains(labelName))
                        {
                            LabelData labelData = new LabelData();
                            string labelSql01 = "UPPER(" + labelData.ObjectKeyTableName + labelData.ColName + ") = '" + labelName + "' ";
                            string[] sqlWhereLabel = { labelSql01 };
                            labelId = GetKey(labelData, sqlWhereLabel);
                            if ("".Equals(labelId) || labelId == null)
                            {
                                if ("".Equals(autoKeyLabel) || autoKeyLabel == null)
                                {
                                    labelId = CreateKey(labelData, labelData.ObjectType.Prefix);
                                }
                                else
                                {
                                    string prefix = labelData.ObjectType.Prefix;
                                    int length = labelData.KeyAttributeData.MaxLength;
                                    string tmp = autoKeyLabel.Replace(prefix, "");
                                    int i = Func.ParseInt(tmp) + 1;
                                    labelId = prefix + Func.ParseString(i).PadLeft(length - prefix.Length, '0');
                                }
                                autoKeyLabel = labelId;
                            }


                            labelKeyMap.Add(labelName, labelId);
                        }
                        else
                        {
                            labelId = (string)labelKeyMap[labelName];
                        }
                    }
                    string songTitleReading = row["SongTitleReading"].ToString();
                    string yomi = "";
                    if (!String.IsNullOrEmpty(songTitleReading))
                    {
                        yomi = songTitleReading.Substring(0, 1);
                        yomi = Strings.StrConv(Strings.StrConv(yomi, VbStrConv.Wide, 0x0411), VbStrConv.Hiragana, 0x0411);
                    }
                    updSql.AppendLine("Update SongImport set ArtistId = '" + artistId + "' , LabelId = '" + labelId + "', SongYomi = '" + yomi + "' where SongId = '" + songId + "' and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'");
                }

                
                DbHelper.ExecuteNonQuery(updSql.ToString());
                

                db = new SqlDatabase();
                ds = new DataSet();
                dsTmp = new DataSet();
                cm = db.CreateCommand(sql);
                da = new SqlDataAdapter(cm);

                updSql = new StringBuilder();
                sql = "Select * from SongImport where SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
                cm = db.CreateCommand(sql);
                da = new SqlDataAdapter(cm);
                da.Fill(ds);

                dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    string contractorId = row["ContractorId"].ToString();
                    string hbunRitsu = "";
                    string uta_rate = "";
                    string video_rate = "";
                    if (!"".Equals(contractorId))
                    {
                        ContractorData data = new ContractorData();
                        ITransaction tran = factory.GetLoadObject(data, contractorId);
                        Execute(tran);
                        if (!HasError)
                        {

                            //編集の場合、DBに既存データを取得して設定する。
                            data = (ContractorData)tran.Result;
                            hbunRitsu = data.HbunRitsu;
                            uta_rate = data.uta_rate;
                            video_rate = data.video_rate;
                        }
                    }

                    //ｱｰﾃｨｽﾄID
                    string artistId = row["ArtistId"].ToString().ToUpper();

                    ///////////
                    //ｱﾙﾊﾞﾑ名(半角)	",	"	AlbumTitle	",
                    string albumTitle = row["AlbumTitle"].ToString().Replace("'", "''").ToUpper();
                    //ｱﾙﾊﾞﾑ名ﾖﾐ(半角)	",	"	AlbumTitleReadingFull	",
                    string albumTitleReadingFull = row["AlbumTitleReadingFull"].ToString().Replace("'", "''").ToUpper();
                    //CD品番	",	"	AlbumCdId	",
                    string albumCdId = row["AlbumCdId"].ToString().Replace("'", "''").ToUpper();

                    string albumId = row["AlbumId"].ToString().Replace("'", "''").ToUpper();

                    if ("".Equals(albumId) || albumId == null)
                    {
                        if (!albumKeyMap.Contains(albumTitle + "_" + albumTitleReadingFull + "_" + albumCdId))
                        {
                            if (excAlbumName.Contains(albumTitle) || excAlbumNameYomi.Contains(albumTitleReadingFull))
                            {
                                albumId = "ERROR";
                            }
                            else
                            {
                                AlbumData albumData = new AlbumData();

                                db = new SqlDatabase();
                                ds = new DataSet();
                                dsTmp = new DataSet();

                                string albumSql = "UPPER(" + albumData.ObjectKeyTableName + albumData.ColTitle + ") = '" + albumTitle + "' AND " +
                                                 "UPPER(" + albumData.ObjectKeyTableName + albumData.ColTitleReadingFull + ") = '" + albumTitleReadingFull + "' AND " +
                                                 "UPPER(" + albumData.ObjectKeyTableName + albumData.ColCdId + ") = '" + albumCdId + "' ";

                                string[] sqlWhereAlbum = { albumSql };
                                albumId = GetKey(albumData, sqlWhereAlbum);

                                albumSql = "Select count(*) from " + albumData.ObjectKeyTableName + " where " + albumSql;
                                int count = Func.ParseInt(DbHelper.GetScalar(albumSql));
                                if (count > 1)
                                {
                                    albumId = "ERROR";
                                }
                                else if (count == 1)
                                {
                                }
                                else
                                {
                                    db = new SqlDatabase();
                                    ds = new DataSet();
                                    dsTmp = new DataSet();

                                    string sqlGetArtist = "SELECT distinct Song.ArtistId, Album.AlbumId, Album.Title FROM Album INNER JOIN Song ON Album.AlbumId = Song.AlbumId WHERE (Album.Title = '" + albumTitle + "') OR (Album.TitleReadingFull = '" + albumTitleReadingFull + "')";
                                    cm = db.CreateCommand(sqlGetArtist);
                                    da = new SqlDataAdapter(cm);
                                    da.Fill(dsTmp);
                                    dtTmp = dsTmp.Tables[0];


                                    foreach (DataRow rowTmp in dtTmp.Rows)
                                    {
                                        string artistIdTmp = rowTmp["ArtistId"].ToString().ToUpper();
                                        string albumIdTmp = rowTmp["AlbumId"].ToString().ToUpper();

                                        if (artistId.Equals(artistIdTmp))
                                        {
                                            albumId = albumIdTmp;
                                        }
                                    }

                                    if ("".Equals(albumId) || albumId == null)
                                    {
                                        if ("".Equals(autoKeyAlbum) || autoKeyAlbum == null)
                                        {
                                            albumId = CreateKey(albumData, albumData.ObjectType.Prefix + "0");
                                        }
                                        else
                                        {
                                            string prefix = albumData.ObjectType.Prefix;
                                            int length = albumData.KeyAttributeData.MaxLength;
                                            string tmp = autoKeyAlbum.Replace(prefix, "");
                                            int i = Func.ParseInt(tmp) + 1;
                                            albumId = prefix + Func.ParseString(i).PadLeft(length - prefix.Length, '0');
                                        }
                                        autoKeyAlbum = albumId;
                                    }
                                }
                            }
                            albumKeyMap.Add(albumTitle + "_" + albumTitleReadingFull + "_" + albumCdId, albumId);
                        }
                        else
                        {
                            albumId = (string)albumKeyMap[albumTitle + "_" + albumTitleReadingFull + "_" + albumCdId];
                        }
                    }

                    string price = row["Price"].ToString();

                    string rate = hbunRitsu;
                    string priceNoTax = "";
                    string buyUnique = "";
                    string copyrightFeeUnique = "";
                    string KDDICommissionUnique = "";
                    string profitUnique = "";

                    if (!"".Equals(price) && !"".Equals(rate))
                    {
                        priceNoTax = Func.GetPriceNoTax(price);
                        buyUnique = Func.GetBuyUnique(priceNoTax, rate);
                        copyrightFeeUnique = Func.GetCopyrightFeeUnique(row["CopyrightContractId"].ToString(), priceNoTax, "1");
                        KDDICommissionUnique = Func.GetKDDICommissionUnique(priceNoTax);
                        profitUnique = Func.GetProfitUnique(priceNoTax, buyUnique, copyrightFeeUnique, KDDICommissionUnique);
                    }

                    string songId = row["SongId"].ToString();
                    updSql.AppendLine("Update SongImport set AlbumId = '" + albumId + "', hbunRitsu = '" + hbunRitsu + "', uta_rate = '" + uta_rate + "', video_rate = '" + video_rate + "' , PriceNoTax = '" + priceNoTax + "', BuyUnique = '" + buyUnique + "', CopyrightFeeUnique = '" + copyrightFeeUnique + "', KDDICommissionUnique = '" + KDDICommissionUnique + "', ProfitUnique = '" + profitUnique + "'where SongId = '" + songId + "' and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'");

                    ArrayList sqlAddSongMedia = GetSqlAddSongMediaKey(row,uta_rate,video_rate);
                    for (int i = 0; i < sqlAddSongMedia.Count; i++)
                    {
                        updSql.AppendLine(sqlAddSongMedia[i].ToString());
                    }
                }

                DbHelper.ExecuteNonQuery(updSql.ToString());
                

                //うた既存　=>　status=1
                DbHelper.ExecuteNonQuery("Update SongMediaTemp set Status = 1 where SessionId = '" + Session.SessionID + "' and SongMediaId in (Select SongMediaId from SongMedia where TypeId = '2') and ImportType = '" + importType + "'");

                //ビデオ既存　=>　status=1
                DbHelper.ExecuteNonQuery("Update SongMediaTemp set Status = 1 where SessionId = '" + Session.SessionID + "' and SongMediaId in (Select SongMediaId from SongMedia where TypeId = '3') and ImportType = '" + importType + "'");

                db.Close();
                ///////////
                Session["FolderPath"] = fileUpload.FileName;
                Response.Redirect("NewListMasterImport.aspx", false);
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

        /// <summary>
        /// Creates primary key in case dataobject is set autoincrement = false
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private ArrayList GetSqlAddSongMediaKey(DataRow row, string uta_rate, string video_rate)
        {
            try
            {
                ArrayList returnList = new ArrayList();

                string Updated = DateTime.Now.ToString("yyyyMMddHHmmss");
                string Updator = Page.User.Identity.Name;
                string Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                string Creator = Page.User.Identity.Name;

                string songId = row["SongId"].ToString();
                string PRText = row["PRText"].ToString();
                string Flag = row["Flag"].ToString();

                string haishinDate = "";
                string haishinEndDate = "";
                string copyrightContractId = row["CopyrightContractId"].ToString();
                string priceNoTax = "";
                string buyUnique = "";
                string copyrightFeeUnique = "";
                string KDDICommissionUnique = "";
                string profitUnique = "";
                string title = "";
                string isrcNo = "";
                string fileName = "";
                string songMediaId = "";
                string price = "";

                haishinDate = row["RemoveDateUta"].ToString();
                haishinEndDate = row["HaishinEndDateUta"].ToString();

                price = row["PriceUta"].ToString();

                string rate = "".Equals(uta_rate) ? "0" : uta_rate;

                for (int i = 0; i < Constants.SongMediaExt.Length; i++)
                {
                    songMediaId = row["SongId"].ToString() + Constants.SongMediaExt[i];
                    title = row["UtaTitle" + Constants.SongMediaExt[i]].ToString().Replace("'", "''");
                    isrcNo = row["UtaIsrcNo" + Constants.SongMediaExt[i]].ToString();
                    fileName = row["UtaFileName" + Constants.SongMediaExt[i]].ToString();

                    if (!"".Equals(price) && !"".Equals(rate))
                    {
                        priceNoTax = Func.GetPriceNoTax(price);
                        buyUnique = Func.GetBuyUnique(priceNoTax, rate);
                        copyrightFeeUnique = Func.GetCopyrightFeeUnique(copyrightContractId, priceNoTax, "2");
                        KDDICommissionUnique = Func.GetKDDICommissionUnique(priceNoTax);
                        profitUnique = Func.GetProfitUnique(priceNoTax, buyUnique, copyrightFeeUnique, KDDICommissionUnique);
                    }

                    if (!"".Equals(title) || !"".Equals(isrcNo) || !"".Equals(fileName))
                    {
                        returnList.Add("Insert into SongMediaTemp (SessionId, ImportType, SongMediaId, SongId, Title, FileName, TypeId, ISRCNo, rate , Price,PRText,Flag, HaishinDate, HaishinEndDate, PriceNoTax, BuyUnique, CopyrightFeeUnique, KDDICommissionUnique, ProfitUnique,DelFlag,Updated , Updator, Created, Creator) " +
                            "values('" + Session.SessionID + "', '" + importType + "', '" + songMediaId + "', '" + songId + "','" + title.Replace("'", "''") + "', '" + fileName.Replace("'", "''") + "','2', '" + isrcNo + "','" + rate + "','" + price + "','" + PRText.Replace("'", "''") + "','" + Flag + "'," + ("".Equals(haishinDate) ? "null" : "'" + haishinDate + "'") + "," + ("".Equals(haishinEndDate) ? "null" : "'" + haishinEndDate + "'") + ", '" + priceNoTax + "','" + buyUnique + "','" + copyrightFeeUnique + "','" + KDDICommissionUnique + "','" + profitUnique + "', '0','" + Updated + "', '" + Updator + "', '" + Created + "', '" + Creator + "')");
                    }
                }


                rate = "".Equals(video_rate) ? "0" : video_rate;
                haishinDate = row["RemoveDateVideo"].ToString();
                songMediaId = row["SongId"].ToString() + "V";
                title = row["VideoBranchName"].ToString().Replace("'", "\'");
                isrcNo = row["VideoIsrcNo"].ToString();
                price = row["priceVideo"].ToString();
                fileName = row["VideoFileName"].ToString();
                haishinEndDate = row["HaishinEndDateVideo"].ToString();

                if (!"".Equals(price) && !"".Equals(rate))// && !"".Equals(rate))
                {
                    priceNoTax = Func.GetPriceNoTax(price);
                    buyUnique = Func.GetBuyUnique(priceNoTax, rate);
                    copyrightFeeUnique = Func.GetCopyrightFeeUnique(copyrightContractId, priceNoTax, "3");
                    KDDICommissionUnique = Func.GetKDDICommissionUnique(priceNoTax);
                    profitUnique = Func.GetProfitUnique(priceNoTax, buyUnique, copyrightFeeUnique, KDDICommissionUnique);
                }

                if (!"".Equals(title) || !"".Equals(isrcNo) || !"".Equals(fileName) || !"".Equals(price))
                {
                    returnList.Add("Insert into SongMediaTemp (SessionId, ImportType, SongMediaId, SongId, Title, FileName, TypeId, ISRCNo, rate , Price,PRText,Flag, HaishinDate,HaishinEndDate, PriceNoTax, BuyUnique, CopyrightFeeUnique, KDDICommissionUnique, ProfitUnique,DelFlag,Updated , Updator, Created, Creator) " +
                            "values('" + Session.SessionID + "', '" + importType + "', '" + songMediaId + "', '" + songId + "','" + title.Replace("'", "''") + "', '" + fileName.Replace("'", "''") + "','3', '" + isrcNo + "','" + rate + "','" + price + "','" + PRText.Replace("'", "''") + "','" + Flag + "'," + ("".Equals(haishinDate) ? "null" : "'" + haishinDate + "'") + "," + ("".Equals(haishinEndDate) ? "null" : "'" + haishinEndDate + "'") + ", '" + priceNoTax + "','" + buyUnique + "','" + copyrightFeeUnique + "','" + KDDICommissionUnique + "','" + profitUnique + "', '0','" + Updated + "', '" + Updator + "', '" + Created + "', '" + Creator + "')");
                }

                return returnList;
            }
            catch (Exception exc)
            {
                return null;
            }
        }


        /// <summary>
        /// Creates primary key in case dataobject is set autoincrement = false
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetKey(DataObject data, string[] condition)
        {
            string key = "";
            for (int i = 0; i < condition.Length; i++)
            {
                string sql = "SELECT " + data.ObjectKeyColumnName + " FROM " + data.ObjectKeyTableName + " WHERE " + condition[i];
                key = DbHelper.GetScalar(sql);
                if (!"".Equals(key))
                {
                    break;
                }
            }
            return key;
        }

        /// <summary>
        /// Creates primary key in case dataobject is set autoincrement = false
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string CreateKey(DataObject data,string prefix)
        {
            int length = data.KeyAttributeData.MaxLength;
            string tmp = String.Format("", length);

            string maxId = "".PadRight(length - prefix.Length, '9');

            string sql = "SELECT max(maxid) from (SELECT SUBSTRING(" + data.ObjectKeyColumnName + ", " + (prefix.Length + 1) + ", " + length + ") as maxid FROM " + data.ObjectKeyTableName + ") as tmp WHERE maxid < '" + maxId + "'";

            if ("ARTIST".Equals(data.ObjectKeyTableName.ToUpper()))
            {
                length--;
                maxId = "".PadRight(length - prefix.Length, '9');
                sql = "SELECT max(maxid) from (SELECT SUBSTRING(" + data.ObjectKeyColumnName + ", " + (prefix.Length + 2) + ", " + length + ") as maxid FROM " + data.ObjectKeyTableName + ") as tmp WHERE maxid < '" + maxId + "'";
            }          
            
            int key = 0;
            try
            {
                key = Convert.ToInt32(DbHelper.GetScalar(sql));
                key++;
            }
            catch
            {
                key = 1;
            }

            bool keyFlg = true;
            while (keyFlg)
            {
                string tmpKey = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
                sql = "SELECT count(*) from " + data.ObjectKeyTableName + " WHERE " + data.ObjectKeyColumnName + " = '" + tmpKey + "'";
                if (Convert.ToInt32(DbHelper.GetScalar(sql)) != 1)
                {
                    keyFlg = false;
                }
                else
                {
                    key--;
                }
            }
            
            
            if ("ARTIST".Equals(data.ObjectKeyTableName.ToUpper()))
            {
                return prefix + key.ToString().PadLeft(length + 1 - prefix.Length, '0');
            }
            return prefix + key.ToString().PadLeft(length - prefix.Length, '0');
        }

        private bool validFormat(DataTable dt)
        {
            Hashtable tmpKey = new Hashtable();
            SongData data = new SongData();


            int k = 1;
            bool valid = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string message = "";
                string strWID = !(dt.Rows[i][0] is System.DBNull) ? (string)dt.Rows[i][0] : "";

                if (strWID.IndexOf(data.ObjectType.Prefix) != 0)
                {
                    mvImportMaster.AddError("WIDのフォーマットが間違っている：" + strWID);
                    valid = false;
                    continue;
                }

                if (tmpKey.Contains(strWID))
                {
                    mvImportMaster.AddError(strWID + "が重複です。");
                    valid = false;
                    continue;
                }
                else
                {
                    tmpKey.Add(strWID,strWID);
                }

                string strTitle = !(dt.Rows[i][7] is System.DBNull) ? (string)dt.Rows[i][7] : "";
                string strTitleYomFull = !(dt.Rows[i][9] is System.DBNull) ? (string)dt.Rows[i][9] : "";
                string strAlphabetTitle = !(dt.Rows[i][10] is System.DBNull) ? (string)dt.Rows[i][10] : "";

                string strDcSearchTitle = !(dt.Rows[i][11] is System.DBNull) ? (string)dt.Rows[i][11] : "";

                string strHaishinFull = !(dt.Rows[i][11 + k] is System.DBNull) ? (string)dt.Rows[i][11 + k] : "";
                string strHaishinUta = !(dt.Rows[i][12 + k] is System.DBNull) ? (string)dt.Rows[i][12+k] : "";
                string strHaishinVideo = !(dt.Rows[i][13 + k] is System.DBNull) ? (string)dt.Rows[i][13+k] : "";

                string strHaishinTeishiFull = !(dt.Rows[i][14 + k] is System.DBNull) ? (string)dt.Rows[i][14 + k] : "";
                string strHaishinTeishiUta = !(dt.Rows[i][15 + k] is System.DBNull) ? (string)dt.Rows[i][15 + k] : "";
                string strHaishinTeishiVideo = !(dt.Rows[i][16 + k] is System.DBNull) ? (string)dt.Rows[i][16 + k] : "";

                string strArtistAID = !(dt.Rows[i][17 + k] is System.DBNull) ? (string)dt.Rows[i][17 + k] : "";
                string strAlphabetName = !(dt.Rows[i][21 + k] is System.DBNull) ? (string)dt.Rows[i][21 + k] : "";

                string strAlbumID = !(dt.Rows[i][22 + k] is System.DBNull) ? (string)dt.Rows[i][22 + k] : "";
                string strSaleDate = !(dt.Rows[i][29 + k] is System.DBNull) ? (string)dt.Rows[i][29 + k] : "";

                string strPriceFull = !(dt.Rows[i][30 + k] is System.DBNull) ? (string)dt.Rows[i][30 + k] : "";
                string strPriceUta = !(dt.Rows[i][31 + k] is System.DBNull) ? (string)dt.Rows[i][31 + k] : "";
                string strPriceVideo = !(dt.Rows[i][32 + k] is System.DBNull) ? (string)dt.Rows[i][32 + k] : "";
                string strLabelID = !(dt.Rows[i][33 + k] is System.DBNull) ? (string)dt.Rows[i][33 + k] : "";
                string str契約者ID = !(dt.Rows[i][35 + k] is System.DBNull) ? (string)dt.Rows[i][35 + k] : "";
                string strIVT = !(dt.Rows[i][36 + k] is System.DBNull) ? (string)dt.Rows[i][36 + k] : "";
                string strIVT区分 = !(dt.Rows[i][37 + k] is System.DBNull) ? (string)dt.Rows[i][37 + k] : "";
                string str著作権管理団体 = !(dt.Rows[i][38 + k] is System.DBNull) ? (string)dt.Rows[i][38 + k] : "";
                string strJASRAC作品コード = !(dt.Rows[i][39 + k] is System.DBNull) ? (string)dt.Rows[i][39 + k] : "";
                string strISRC番号 = !(dt.Rows[i][40 + k] is System.DBNull) ? (string)dt.Rows[i][40 + k] : "";
                string str作詞者名 = !(dt.Rows[i][41 + k] is System.DBNull) ? (string)dt.Rows[i][41 + k] : "";
                string str作曲者名 = !(dt.Rows[i][42 + k] is System.DBNull) ? (string)dt.Rows[i][42 + k] : "";
                string strPOINT1 = !(dt.Rows[i][44 + k] is System.DBNull) ? (string)dt.Rows[i][44 + k] : "";
                string strSabi1 = !(dt.Rows[i][45 + k] is System.DBNull) ? (string)dt.Rows[i][45 + k] : "";
                string strSabi1end = !(dt.Rows[i][46 + k] is System.DBNull) ? (string)dt.Rows[i][46 + k] : "";
                string strPOINT2 = !(dt.Rows[i][47 + k] is System.DBNull) ? (string)dt.Rows[i][47 + k] : "";
                string strSabi2 = !(dt.Rows[i][48 + k] is System.DBNull) ? (string)dt.Rows[i][48 + k] : "";
                string strSabi2end = !(dt.Rows[i][49 + k] is System.DBNull) ? (string)dt.Rows[i][49 + k] : "";
                string strPOINT3 = !(dt.Rows[i][50 + k] is System.DBNull) ? (string)dt.Rows[i][50 + k] : "";
                string strSabi3 = !(dt.Rows[i][51 + k] is System.DBNull) ? (string)dt.Rows[i][51 + k] : "";
                string strSabi3end = !(dt.Rows[i][52 + k] is System.DBNull) ? (string)dt.Rows[i][52 + k] : "";
                string strPRText = !(dt.Rows[i][53 + k] is System.DBNull) ? (string)dt.Rows[i][53 + k] : "";
                string strFlag = !(dt.Rows[i][54 + k] is System.DBNull) ? (string)dt.Rows[i][54 + k] : "";

                if ("".Equals(strWID))
                {
                    message += "【WID】" + Func.invalidNull();
                }
                else if (strWID.Length > 8)
                {
                    message += "【WID】" + Func.invalidLenght(8);
                }
                if ("".Equals(strTitle))
                {
                    message += "【曲名(半角)】" + Func.invalidNull();
                }
                else if (strTitle.Length > 255)
                {
                    message += "【曲名(半角)】" + Func.invalidLenght(255);
                }

                if (!"".Equals(strTitleYomFull) && strTitleYomFull.Length > 255)
                {
                    message += "【曲名ﾖﾐ(半角)】" + Func.invalidLenght(255);
                }

                if (!"".Equals(strAlphabetTitle) && strAlphabetTitle.Length > 200)
                {
                    message += "【曲名英表記】" + Func.invalidLenght(200);
                }

                if (!"".Equals(strHaishinFull) && !Func.IsDate(strHaishinFull))
                {
                    message += "【解禁日（フル）】" + Func.invalidDate();
                }
                if (!"".Equals(strHaishinUta) && !Func.IsDate(strHaishinUta))
                {
                    message += "【解禁日（うた）】" + Func.invalidDate();
                }
                if (!"".Equals(strHaishinVideo) && !Func.IsDate(strHaishinVideo))
                {
                    message += "【解禁日（ﾋﾞﾃﾞｵｸﾘｯﾌﾟ）】" + Func.invalidDate();
                }


                if (!"".Equals(strHaishinTeishiFull) && !Func.IsDate(strHaishinTeishiFull))
                {
                    message += "【配信停止日】" + Func.invalidDate();
                }
                if (!"".Equals(strHaishinTeishiUta) && !Func.IsDate(strHaishinTeishiUta))
                {
                    message += "【配信停止日（うた）】" + Func.invalidDate();
                }
                if (!"".Equals(strHaishinTeishiVideo) && !Func.IsDate(strHaishinTeishiVideo))
                {
                    message += "【配信停止日（ビデオ）】" + Func.invalidDate();
                }


                if (!"".Equals(strArtistAID) && strArtistAID.Length > 8)
                {
                    message += "【ｱｰﾃｨｽﾄID】" + Func.invalidLenght(8);
                }

                if (!"".Equals(strAlphabetName) && strArtistAID.Length > 200)
                {
                    message += "ｱｰﾃｨｽﾄ名英表記" + Func.invalidLenght(200);
                }

                //if (!"".Equals(strGEID) && strGEID.Length > 5)
                //{
                //    message += "【ｼﾞｬﾝﾙ】" + Func.invalidLenght(5);
                //}

                if (!"".Equals(strAlbumID) && strAlbumID.Length > 8)
                {
                    message += "【ｱﾙﾊﾞﾑID】" + Func.invalidLenght(8);
                }
                if (!"".Equals(strSaleDate) && !Func.IsDate(strSaleDate))
                {
                    message += "【発売日】" + Func.invalidDate();
                }

                if (!"".Equals(strPriceFull) && !Func.IsInterger(strPriceFull))
                {
                    message += "【価格】" + Func.invalidNumber();
                }
                if (!"".Equals(strPriceUta) && !Func.IsInterger(strPriceUta))
                {
                    message += "【価格(うた)】" + Func.invalidNumber();
                }
                if (!"".Equals(strPriceVideo) && !Func.IsInterger(strPriceVideo))
                {
                    message += "【価格（ﾋﾞﾃﾞｵｸﾘｯﾌﾟ）】" + Func.invalidNumber();
                }
                if (!"".Equals(strLabelID) && strLabelID.Length > 8)
                {
                    message += "【ﾚｰﾍﾞﾙID】" + Func.invalidLenght(8);
                }

                if (!"".Equals(str契約者ID) && str契約者ID.Length > 6)
                {
                    message += "【契約者】" + Func.invalidLenght(6);
                }

                if (!"".Equals(strIVT) && strIVT.Length > 1)
                {
                    message += "【歌詞区分】" + Func.invalidLenght(1);
                }

                if (!"".Equals(strIVT区分) && strIVT区分.Length > 1)
                {
                    message += "【IVT区分】" + Func.invalidLenght(1);
                }

                if (!"".Equals(str著作権管理団体) && str著作権管理団体.Length > 50)
                {
                    message += "【著作権団体】" + Func.invalidLenght(50);
                }

                if (!"".Equals(strJASRAC作品コード) && strJASRAC作品コード.Length > 250)
                {
                    message += "【著作権管理番号】" + Func.invalidLenght(250);
                }

                if (!"".Equals(strISRC番号) && strISRC番号.Length > 50)
                {
                    message += "【ISRC番号】" + Func.invalidLenght(50);
                }

                if (!"".Equals(str作詞者名) && str作詞者名.Length > 250)
                {
                    message += "【作詞者】" + Func.invalidLenght(250);
                }

                if (!"".Equals(str作曲者名) && str作曲者名.Length > 250)
                {
                    message += "【作曲者】" + Func.invalidLenght(250);
                }

                if (!"".Equals(strPOINT1) && strPOINT1.Length > 50)
                {
                    message += "【切り出し表記1】" + Func.invalidLenght(50);
                }
                /*
                if (!"".Equals(strSabi1) && strSabi1.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[43] + "】" + invalidEqual(7);
                }
                if (!"".Equals(strSabi1end) && strSabi1end.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[44] + "】" + invalidEqual(7);
                }
                */
                if (!"".Equals(strSabi1) && strSabi1.Length > 7)
                {
                    message += "【cut開始1】" + Func.invalidLenght(7);
                }
                if (!"".Equals(strSabi1end) && strSabi1end.Length > 7)
                {
                    message += "【cut終了1】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strPOINT2) && strPOINT2.Length > 50)
                {
                    message += "【切り出し表記2】" + Func.invalidLenght(50);
                }
                /*
                if (!"".Equals(strSabi2) && strSabi2.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[46] + "】" + invalidEqual(7);
                }
                if (!"".Equals(strSabi2end) && strSabi2end.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[47] + "】" + invalidEqual(7);
                }
                */
                if (!"".Equals(strSabi2) && strSabi2.Length > 7)
                {
                    message += "【cut開始2】" + Func.invalidLenght(7);
                }
                if (!"".Equals(strSabi2end) && strSabi2end.Length > 7)
                {
                    message += "【cut終了2】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strPOINT3) && strPOINT3.Length > 50)
                {
                    message += "【切り出し表記3】" + Func.invalidLenght(50);
                }
                /*
                if (!"".Equals(strSabi3) && strSabi3.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[49] + "】" + invalidEqual(7);
                }
                if (!"".Equals(strSabi3end) && strSabi3end.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[50] + "】" + invalidEqual(7);
                }
                */
                if (!"".Equals(strSabi3) && strSabi3.Length > 7)
                {
                    message += "【cut開始3】" + Func.invalidLenght(7);
                }
                if (!"".Equals(strSabi3end) && strSabi3end.Length > 7)
                {
                    message += "【cut終了3】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strPRText) && strPRText.Length > 255)
                {
                    message += "【備考】" + Func.invalidLenght(255);
                }
                if (!"".Equals(strFlag) && strFlag.Length != 1)
                {
                    message += "【fineflag】" + Func.invalidEqual(1);
                }

                if (!"".Equals(strFlag) && !"1".Equals(strFlag) && !"0".Equals(strFlag))
                {
                    message += "【fineflag】がTrue:1 False:0又はブランク";
                }

                for (int j = 56; j <= 73; j++)
                {
                    string strTitleUta = !(dt.Rows[i][j] is System.DBNull) ? (string)dt.Rows[i][j] : "";
                    string tmp = Constants.SongMediaExt[j - 56];

                    if (!"".Equals(strTitleUta) && strTitleUta.Length > 255)
                    {
                        message += "【うたﾀｲﾄﾙ名" + tmp + "】" + Func.invalidLenght(255);
                    }
                }

                for (int j = 74; j <= 91; j++)
                {
                    string strIsrcUta = !(dt.Rows[i][j] is System.DBNull) ? (string)dt.Rows[i][j] : "";
                    string tmp = Constants.SongMediaExt[j - 74];
                    if (!"".Equals(strIsrcUta) && strIsrcUta.Length > 50)
                    {
                        message += "【うたISRC" + tmp + "】" + Func.invalidLenght(50);
                    }
                }

                string strTitleVideo = !(dt.Rows[i][92] is System.DBNull) ? (string)dt.Rows[i][92] : "";
                if (!"".Equals(strTitleVideo) && strTitleVideo.Length > 255)
                {
                    message += "【ﾋﾞﾃﾞｵ枝番名V】" + Func.invalidLenght(255);
                }


                string strIsrcVideo = !(dt.Rows[i][93] is System.DBNull) ? (string)dt.Rows[i][93] : "";
                if (!"".Equals(strIsrcVideo) && strIsrcVideo.Length > 50)
                {
                    message += "【ﾋﾞﾃﾞｵISRCV】" + Func.invalidLenght(50);
                }

                string strFullFileName = !(dt.Rows[i][94] is System.DBNull) ? (string)dt.Rows[i][94] : "";
                if (!"".Equals(strFullFileName) && strFullFileName.Length > 200)
                {
                    message += "【フルファイル名】" + Func.invalidLenght(200);
                }

                for (int j = 95; j <= 112; j++)
                {
                    string strFileName = !(dt.Rows[i][j] is System.DBNull) ? (string)dt.Rows[i][j] : "";
                    string tmp = Constants.SongMediaExt[j - 95];
                    if (!"".Equals(strFileName) && strFileName.Length > 200)
                    {
                        message += "【うたファイル名" + tmp + "】" + Func.invalidLenght(255);
                    }
                }

                string strVideoFileName = !(dt.Rows[i][113] is System.DBNull) ? (string)dt.Rows[i][113] : "";
                if (!"".Equals(strVideoFileName) && strVideoFileName.Length > 200)
                {
                    message += "【ビデオファイル名V】" + Func.invalidLenght(200);
                }

                if (!"".Equals(message))
                {
                    valid = false;
                    mvImportMaster.AddError("Error (Line)" + (i+2) + ": " + message);
                }
            }
            return valid;
        }        
    }
}
