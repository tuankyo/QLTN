using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using Man.Utils;
using System.Data;

namespace Man.CSV
{
    public partial class GetFile : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            string siteid = Request["siteid"];
            string filename = Request["filename"];

            DataSet dsSite = DbHelper.GetSiteData(siteid, "");
            string tmpFolder = Server.MapPath("./") + "TempOutput" + "/" + Page.User.Identity.Name + "/";

            if (Directory.Exists(tmpFolder))
            {
                string[] files = Directory.GetFiles(tmpFolder);
                foreach (string file in files)
                    File.Delete(file);
            }
            else
            {
                Directory.CreateDirectory(tmpFolder);
            }

            foreach (DataRow drSite in dsSite.Tables[0].Rows)
            {
                string siteUrl = drSite["ZipApiUrl"].ToString() + "getfile.php?filename=" + filename;
                System.Net.WebClient client = new System.Net.WebClient();
                client.DownloadFile(siteUrl, tmpFolder + filename);

                Func.SaveLocalFile(tmpFolder + filename, "zip", "Mone\\CSV出力");
            }
        }
    }
}
