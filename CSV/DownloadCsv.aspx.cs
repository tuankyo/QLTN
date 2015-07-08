using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace Man.CSV
{
    public partial class DownloadCsv1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string csv = (string)Session["DownloadCsvContent"];

            string kind = (string)Session["Kind"];
            if (!string.IsNullOrEmpty(csv))
            {
                Session["DownloadCsvContent"] = null;
                Session["Kind"] = null;
                Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");

                //Gnt.Utils.CSV.CSVFileWriter writer = new Gnt.Utils.CSV.CSVFileWriter();
                //writer.Response = Response;
                //writer.SetContents(csv);
                //writer.Download(kind + DateTime.Now.ToString("yyMMdd") + ".csv");

                MemoryStream strmXls = new MemoryStream(encoding.GetBytes(csv));
                this.Response.ContentType = "text/csv";
                this.Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(kind + DateTime.Now.ToString("yyMMddHHmmss") + ".csv"));
                this.Response.BinaryWrite(strmXls.ToArray());

                strmXls.Close();
                Response.Flush();
                Response.Close();
                Response.End();
            }
        }
    }
}
