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
    public partial class OtherFeeImport : Man.PageBase
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
            DbHelper.FillList(drpTenement, "Select TenementID + ' : ' + Name as Name, TenementID from MST_Tenement where TenementID = '" + Func.getMACC(Page.User.Identity.Name) + "'", "Name", "TenementID");

            for (int i = 2000; i < 2050; i++)
            {
                drpYear.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i), Func.ParseString(i)));
            }
            drpYear.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("yyyy")).Selected = true;

            for (int i = 1; i < 13; i++)
            {
                drpMonth.Items.Add(new System.Web.UI.WebControls.ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
            }
            drpMonth.Items.FindByValue(DateTime.Now.AddMonths(-1).ToString("MM")).Selected = true;
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
            if (!(drpYear.SelectedValue + drpMonth.SelectedValue).Equals(DateTime.Now.AddMonths(-1).ToString("yyyyMM")))
            {
                mvImportMaster.AddError("Chỉ lưu Phí khác cho " + DateTime.Now.AddMonths(-1).ToString("MM/yyyy"));
                return;
            }

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
                string sql = "DELETE FROM PaymentMonthOtherFeeTmp WHERE SessionId='" + Session.SessionID + "'";
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
                    for (int i = 0; i < Constants.ImportOtheFeeDataHeader.Length; i++)
                    {
                        if (!Constants.ImportOtheFeeDataHeader[i].Equals(header[i]))
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
                        copy.DestinationTableName = "PaymentMonthOtherFeeTmp";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        for (int i = 0; i < Constants.ImportOtheFeeDataHeader.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportOtheFeeDataDbRef[i]);
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
                Response.Redirect("ListOtherFeeImport.aspx", false);
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
            bool valid = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string message = "";
                string yearMonth = !(dt.Rows[i][0] is System.DBNull) ? (string)dt.Rows[i][0] : "";
                string tenementID = !(dt.Rows[i][1] is System.DBNull) ? (string)dt.Rows[i][1] : "";
                string flatID = !(dt.Rows[i][2] is System.DBNull) ? (string)dt.Rows[i][2] : "";
                string name = !(dt.Rows[i][3] is System.DBNull) ? (string)dt.Rows[i][3] : "";

                int mount = !(dt.Rows[i][4] is System.DBNull) ? Func.ParseInt(dt.Rows[i][4]) : 0;
                int price = !(dt.Rows[i][5] is System.DBNull) ? Func.ParseInt(dt.Rows[i][5]) : 0;

                string strYearMonth = drpYear.SelectedValue + drpMonth.SelectedValue;
                if ( !strYearMonth.Equals(yearMonth))
                {
                    message += " _ có giá trị Năm, Tháng không đúng như đã chọn <- " + yearMonth;
                }

                if (!drpTenement.SelectedValue.Equals(tenementID))
                {
                    message += " _ có Mã Chung Cư không đúng như đã chọn <- " + tenementID ;
                }

                if ("".Equals(flatID))
                {
                    message += " _ Mã Căn Hộ chưa nhập";
                }

                if (mount < 0)
                {
                    message += " _ Số lượng phải lớn hơn 0" + mount;
                }

                if (price < 0)
                {
                    message += " _ Số lượng phải lớn hơn 0" + price;
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
