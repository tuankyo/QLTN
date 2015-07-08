using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections;
using System.Threading;
using Microsoft.VisualBasic;
using System.Xml;
using System.Collections.Generic;


namespace Man.Utils
{
    public class RSSFeedGenerator : Gnt.Utils.FuncBase
    {

        XmlTextWriter writer;
        public RSSFeedGenerator(System.IO.Stream stream, System.Text.Encoding encoding)
        {
            writer = new XmlTextWriter(stream, encoding);
            writer.Formatting = Formatting.Indented;
        }
        public RSSFeedGenerator(System.IO.TextWriter w)
        {
            writer = new XmlTextWriter(w);
            writer.Formatting = Formatting.Indented;
        }
        /// <summary>
        /// Writes the beginning of the RSS document
        /// </summary>
        public void WriteStartDocument()
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("rss");
            writer.WriteAttributeString("version", "2.0");
        }
        /// <summary>
        /// Writes the end of the RSS document
        /// </summary>
        public void WriteEndDocument()
        {
            writer.WriteEndElement(); //rss
            writer.WriteEndDocument();
        }
        /// <summary>
        /// Closes this stream and the underlying stream
        /// </summary>
        public void Close()
        {
            writer.Flush();
            writer.Close();
        }
        /// <summary>
        /// Begins a new channel in the RSS document
        /// </summary>
        /// <param name="text_label"></param>
        /// <param name="link"></param>
        /// <param name="description"></param>
        public void WriteStartChannel(string title, string link, string description, string copyright, string webMaster)
        {
            writer.WriteStartElement("channel");
            writer.WriteElementString("text_label", title);
            writer.WriteElementString("link", link);
            writer.WriteElementString("description", description);
            writer.WriteElementString("language", "en-gb");
            writer.WriteElementString("copyright", copyright);
            writer.WriteElementString("generator", "Developer Fusion RSS Feed Generator v1.0");
            writer.WriteElementString("webMaster", webMaster);
            writer.WriteElementString("lastBuildDate", DateTime.Now.ToString("r"));
            writer.WriteElementString("ttl", "20");

        }
        /// <summary>
        /// Writes the end of a channel in the RSS document
        /// </summary>
        public void WriteEndChannel()
        {
            writer.WriteEndElement(); //channel
        }
        /// <summary>
        /// Writes an item to a channel in the RSS document
        /// </summary>
        /// <param name="text_label"></param>
        /// <param name="link"></param>
        /// <param name="description"></param>
        /// <param name="author"></param>
        /// <param name="publishedDate"></param>
        /// <param name="category"></param>
        public void WriteItem(string title, string link, DateTime publishedDate)
        {
            writer.WriteStartElement("item");
            writer.WriteElementString("text_label", title);
            writer.WriteElementString("link", link);
            writer.WriteElementString("pubDate", publishedDate.ToString("r"));
            writer.WriteEndElement();
        }
    }
}