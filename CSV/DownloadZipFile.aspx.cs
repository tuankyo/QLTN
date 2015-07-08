using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Man.CSV
{
    public partial class DownloadZipFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = (string)Session["ZipFilePath"];
            HttpResponse response = HttpContext.Current.Response;
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    FileInfo file = new FileInfo(fileName);

                    response.ClearContent();
                    response.ClearHeaders();
                    response.AppendHeader("Content-Disposition:", "attachment; filename =" + file.Name);
                    response.AppendHeader("Content-Length:", file.Length.ToString());
                    string a = fileName.Substring(fileName.Length - 3, 3);
                    if (a.Equals("xls"))
                    {
                        response.ContentType = "application/vnd.ms-excel";
                    }
                    else if (a.Equals("zip"))
                    {
                        response.ContentType = "application/zip";
                    }
                    else if (a.Equals("pdf"))
                    {
                        response.ContentType = "application/pdf";
                    }

                    response.TransmitFile(fileName);
                    response.Flush();
                    response.End();

                    Session["ZipFilePath"] = null;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                response.End();
                Session["ZipFilePath"] = null;
            }
        }
    }
}
