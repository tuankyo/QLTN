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

namespace Man.Building.Document
{
    public partial class BD_DocumentEdit : Man.PageBase
    {
        protected SortDirection ListSortDirection
        {
            get
            {
                object o = ViewState["SortDirection"];
                if (o == null)
                {
                    return SortDirection.Descending;
                }
                return (SortDirection)o;
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }

        protected string ListSortExpression
        {
            get
            {
                object o = ViewState["SortExpression"];
                if (o == null)
                {
                    return "";
                }
                return o.ToString();
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

        private string action = String.Empty;
        private string id = String.Empty;

        private string addSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string addUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string postback = "window.opener.__doPostBack('PopupBD_DocumentEdit','');";
        private string key = "openBD_DocumentEdit";

        /// <summary>
        /// Init values
        /// </summary>
        private void InitValues()
        {
        }

        /// <summary>
        /// Load data
        /// </summary>
        private void LoadData()
        {
            BD_DocumentData data = new BD_DocumentData();
            ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            Execute(tran);
            if (!HasError)
            {
                data = (BD_DocumentData)tran.Result;

                txtName.Text = data.Name;
                txtComment.Text = data.Comment;
                txtDocDate.Text = Func.FormatDMY(data.DocDate);
                txtAppeal.Text = data.Appeal;
                //if (data.InOutDoc == "0")
                //{ rdoInDoc.Checked = true; }
                //else
                //{
                //    rdoOutDoc.Checked = true;
                //}

                //if (data.DocFrom == "0")
                //{
                //    rdoCDT.Checked = true;
                //}
                //else
                //{
                //    rdoCustomer.Checked = true;
                //}

                //DbHelper.FillList      (drpDocSubject, "Select * from BD_DocSubject where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DocType = '" + data.DocType + "' and (DelFlag is null or DelFlag = '0')", "DocSubject", "id");
                DbHelper.FillListSearch(drpDocSubject, "Select * from BD_DocSubject where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DocType = '" + data.DocType + "' and (DelFlag is null or DelFlag = '0')", "DocSubject", "id");
                DbHelper.FillListSearch(drpParentId, "Select * from BD_DocSubject where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DocType = '" + data.DocType + "' and (DelFlag is null or DelFlag = '0') and ParentId is null", "DocSubject", "id");
                drpDocSubject.SelectedValue = data.DocSubject;
                drpParentId.SelectedValue = DbHelper.GetScalar("Select ParentId from BD_DocSubject where id = '" + data.DocSubject + "'");

                tran = factory.GetUpdateObject(data);
                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(addUnSuccess);
                }
            }
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
            action = Request["Action"];
            id = Request["id"];
            hidId.Value = id;
            hidDocType.Value = Request["DocType"];
            if (!IsPostBack)
            {
                //DbHelper.FillList(drpDocSubject, "Select * from Mst_DocSubject where DocType = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "DocSubject", "id");
                LoadData();
            }
        }

        protected override void DoPost()
        {

        }
        protected void drpParentIdSelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(drpParentId.SelectedValue))
            {
                DbHelper.FillListSearch(drpDocSubject, "Select * from BD_DocSubject where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DocType = '" + hidDocType.Value + "' and (DelFlag is null or DelFlag = '0')", "DocSubject", "id");
            }
            else
            {
                DbHelper.FillListSearch(drpDocSubject, "Select * from BD_DocSubject where (DelFlag is null or DelFlag = '0') and ParentId = '" + drpParentId.SelectedValue + "'", "DocSubject", "id");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtName, "Tên hồ sơ: là Danh mục bắt bắt buộc nhập");
            if (!mvMessage.IsValid) return;

            try
            {
                BD_DocumentData data = new BD_DocumentData();
                ITransaction tran = factory.GetLoadObject(data, hidId.Value);
                Execute(tran);
                if (!HasError)
                {
                    data = (BD_DocumentData)tran.Result;
                    data.Name = txtName.Text.Trim();
                    data.Comment = txtComment.Text.Trim();
                    data.ModifiedBy = Page.User.Identity.Name;
                    data.CreatedBy = Page.User.Identity.Name;
                    data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                    data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                    data.Appeal = txtAppeal.Text;
                    //data.InOutDoc = rdoInDoc.Checked == true ? "0" : "1";
                    //data.DocFrom = rdoCDT.Checked == true ? "0" : "1";
                    data.DocSubject = drpDocSubject.SelectedValue;
                    data.DocDate = Func.FormatYYYYmmdd(txtDocDate.Text.Trim());

                    if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
                    {
                        string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                        string filename = Func.ParseString(Session["__BUILDINGID__"])
                            + "_" + data.DocType + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + fn;
                        string SaveLocation = Server.MapPath("Data") + "\\" + filename;
                        File1.PostedFile.SaveAs(SaveLocation);
                        data.FileNamePath = filename;
                    }
                    tran = factory.GetUpdateObject(data);
                    Execute(tran);

                    if (!HasError)
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage(addSuccess);
                        ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                        mvMessage.AddError(addUnSuccess);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            //else
            //{
            //    Response.Write("Please select a file to upload.");
            //}
        }
    }

}

