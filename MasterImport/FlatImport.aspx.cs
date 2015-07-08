using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
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
    public partial class FlatImport : Man.PageBase
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
            DbHelper.FillList(drpTenement, "Select TenementID + ' : ' + Name as Name, TenementID from MST_Tenement  where TenementID = '" + Func.getMACC(Page.User.Identity.Name) + "'", "Name", "TenementID");
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
                mvImportMaster.AddError("Không tìm thất File cần thực hiện");
                return;
            }
            CsvReader csvRead = null;
            
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
                    mvImportMaster.AddError("Hãy chọn file CSV.");
                    return;
                }
                if (File.Exists(Server.MapPath("./") + fileUpload.FileName))
                {
                    File.Delete(Server.MapPath("./") + fileUpload.FileName);
                }
                fileUpload.SaveAs(Server.MapPath("./") + fileUpload.FileName);

                csvRead = new CsvReader(Server.MapPath("./") + fileUpload.FileName, true, ',');
                csvRead.IsCheckQuote = true;
                string sql = "DELETE FROM MST_FlatTmp WHERE SessionId='" + Session.SessionID + "';";
                //sql += "DELETE FROM PaymentMonthWaterFeeDetailTmp WHERE SessionId='" + Session.SessionID + "';";
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
                    for (int i = 0; i < Constants.ImportFlatDataHeader.Length; i++)
                    {
                        if (!Constants.ImportFlatDataHeader[i].Equals(header[i]))
                        {
                            mvImportMaster.AddError("Header của File CSV không đúng. Chú ý, Cột cuối cùng của CSV phải là End và giá trị là *.");
                            return;
                        }
                    }

                    dt.Columns.Add("SessionId", Type.GetType("System.String"));

                    dt.Columns.Add("DelFlag", Type.GetType("System.String"));
                    dt.Columns.Add("Modified", Type.GetType("System.String"));
                    dt.Columns.Add("Updator", Type.GetType("System.String"));
                    dt.Columns.Add("Created", Type.GetType("System.String"));
                    dt.Columns.Add("Creator", Type.GetType("System.String"));

                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SessionId"] = Session.SessionID;
                        dt.Rows[i]["DelFlag"] = "0";
                        dt.Rows[i]["Modified"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Updator"] = Page.User.Identity.Name;
                        dt.Rows[i]["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Creator"] = Page.User.Identity.Name;
                    }

                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "MST_FlatTmp";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        for (int i = 0; i < Constants.ImportFlatDataDbRef.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportFlatDataDbRef[i]);
                        }

                        copy.ColumnMappings.Add(dt.Columns.Count - 6, "SessionId");

                        copy.ColumnMappings.Add(dt.Columns.Count - 5, "DelFlag");
                        copy.ColumnMappings.Add(dt.Columns.Count - 4, "Modified");
                        copy.ColumnMappings.Add(dt.Columns.Count - 3, "Updator");
                        copy.ColumnMappings.Add(dt.Columns.Count - 2, "Created");
                        copy.ColumnMappings.Add(dt.Columns.Count - 1, "Creator");

                        copy.WriteToServer(dt);
                    }
                }
                Response.Redirect("ListFlatImport.aspx", false);
            }
            catch (Exception ex)
            {
                mvImportMaster.AddError("Lỗi phát sinh: " + ex.Message);
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
            DataSet ds = new DataSet();
            string sql = string.Empty;

            sql = " SELECT * ";
            sql += " FROM MST_FlatType ";
            sql += " WHERE TenementID = '"+ drpTenement.SelectedValue +"' ";

            string strArea = "";
            ArrayList Areas = new ArrayList();
            using (SqlDatabase db = new SqlDatabase())
            {
                using (SqlCommand cm = db.CreateCommand(sql))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(ds);
                    db.Close();

                    if (ds != null)
                    {
                        DataTable dta = ds.Tables[0];
                        foreach (DataRow rowType in dta.Rows)
                        {
                            string Area = rowType["Area"].ToString();
                            Areas.Add(Area);
                            strArea += "," + Area;
                        }
                    }
                }
            }

            string strYearMonth = "";
            ArrayList yearMonthList = new ArrayList();
            for (int k = 0; k < 12; k++)
            {
                yearMonthList.Add(DateTime.Now.AddMonths(k).ToString("yyyyMM"));
                strYearMonth += "  " + DateTime.Now.AddMonths(k).ToString("yyyyMM");
            }

            bool valid = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string message = "";
                string tenementID = !(dt.Rows[i][0] is System.DBNull) ? (string)dt.Rows[i][0] : "";
                string flatID = !(dt.Rows[i][1] is System.DBNull) ? (string)dt.Rows[i][1] : "";
                string Name = !(dt.Rows[i][2] is System.DBNull) ? (string)dt.Rows[i][2] : "";
                string Address = !(dt.Rows[i][3] is System.DBNull) ? (string)dt.Rows[i][3] : "";

                string Phone = !(dt.Rows[i][4] is System.DBNull) ? (string)dt.Rows[i][4] : "";
                string Area = !(dt.Rows[i][5] is System.DBNull) ? (string)dt.Rows[i][5] : "";
                string Persons = !(dt.Rows[i][6] is System.DBNull) ? (string)dt.Rows[i][6] : "";


                string Comment = !(dt.Rows[i][7] is System.DBNull) ? (string)dt.Rows[i][7] : "";
                string WaterFeeType = !(dt.Rows[i][8] is System.DBNull) ? (string)dt.Rows[i][8] : "";
                string ReceiveDate  = !(dt.Rows[i][9] is System.DBNull) ? (string)dt.Rows[i][9] : "";


                string YearMonth = !(dt.Rows[i][8] is System.DBNull) ? (string)dt.Rows[i][8] : "";

                if (!drpTenement.SelectedValue.Equals(tenementID))
                {
                    message += " _ có Mã Chung Cư không đúng như đã chọn <- " + tenementID ;
                }

                if ("".Equals(flatID))
                {
                    message += ": Mã Căn Hộ chưa nhập";
                }

                if ("".Equals(Name))
                {
                    message += ": Tên Chủ Hộ chưa nhập";
                }

                if ("".Equals(Address))
                {
                    message += ": Căn Hộ chưa nhập";
                }

                if ("".Equals(Area) || (!"".Equals(Area) && Func.ParseInt(Area) <= 0))
                {
                    message += ": Diện tích chưa nhập hoặc phải lớn hơn 0";
                }

                if ("".Equals(WaterFeeType) || (!"".Equals(WaterFeeType) && !Areas.Contains(Area)))
                {
                    message += " _ Chưa nhập Định Mức Nước hoặc không thuộc (" + strArea.Substring(1) + ").";
                }
                if (!String.IsNullOrEmpty(ReceiveDate) && !Func.IsDate(ReceiveDate))
                {
                    message += " _ Định dạng Ngày không đúng (" + ReceiveDate + ") phải là yyyyMMdd.";
                }

                if (!"".Equals(message))
                {
                    valid = false;
                    mvImportMaster.AddError("Dòng " + (i+2) + message);
                }
            }
            return valid;
        }        
    }
}
