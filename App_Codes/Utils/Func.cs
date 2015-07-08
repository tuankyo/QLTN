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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Man.Utils
{
    public class Func : Gnt.Utils.FuncBase
    {
        public static string[] mangso = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        public static string[] Ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        /// <summary>
        /// Set selected item in a CheckBoxList by value
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value">Value need select (String)</param>
        public static void SetSelectedByValue(System.Web.UI.WebControls.CheckBoxList list, string value)
        {
            ListItemCollection lic = new ListItemCollection();
            list.SelectedIndex = lic.IndexOf(list.Items.FindByValue(value));
        }

        /// <summary>
        /// Set selected item in a RadioButtonList by value
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value">Value need select (String)</param>
        public static void SetSelectedByValue(System.Web.UI.WebControls.RadioButtonList list, string value)
        {
            ListItemCollection lic = new ListItemCollection();
            list.SelectedIndex = lic.IndexOf(list.Items.FindByValue(value));
        }

        /// <summary>
        /// Set selected item in a RadioButtonList by value
        /// This Added by Hieu
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value">Value need select (String)</param>
        public static void SetSelectedByValue2(System.Web.UI.WebControls.RadioButtonList list, string value)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Value == value)
                {
                    list.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// Set selected item in a dropdownlist by value
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value">Value need select (String)</param>
        public static void SetSelectedByValue(System.Web.UI.WebControls.DropDownList list, string value)
        {
            ListItemCollection lic = new ListItemCollection();
            list.SelectedIndex = lic.IndexOf(list.Items.FindByValue(value));
        }

        public static void FindByText(System.Web.UI.WebControls.DropDownList list, string text)
        {
            if (list.Items.FindByText(text) != null)
            {
                list.SelectedIndex = -1;
                list.Items.FindByText(text).Selected = true;
            }
        }

        public static void FindByValue(System.Web.UI.WebControls.ListControl list, string value)
        {
            list.SelectedIndex = -1;
            if (list.Items.FindByValue(value) != null)
            {
                list.SelectedIndex = -1;
                list.Items.FindByValue(value).Selected = true;
            }
        }

        public static void FindByValue(System.Web.UI.WebControls.CheckBoxList list, string value)
        {
            list.SelectedIndex = -1;
            string[] values = value.Split('/');
            foreach (ListItem item in list.Items)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (item.Value == values[i])
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        public static string ParseBinary(string value)
        {
            if (value == null || value == string.Empty)
            {
                return string.Empty;
            }
            //return Convert.ToString(value, 2);
            return "";
        }

        public static double ParseDouble(Object value)
        {
            if (value == null || value == System.DBNull.Value || "".Equals(value)) return 0;
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Get parameter in string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="from"></param>
        /// <returns></returns>

        public static string GetString(string source, string from)
        {
            int fromlen = from.Length;
            int vend;
            int kstart = source.IndexOf(from, 0);
            string value = "";
            while (kstart != -1)
            {
                vend = source.IndexOf("&%", kstart + fromlen);
                if (vend == -1)
                {
                    return "-1";
                }
                else
                {
                    value = source.Substring(kstart + fromlen, vend - kstart - fromlen);
                    return value;
                }
            }
            return "-1";
        }

        public static string DbFormatDate(string value)
        {
            if (value == string.Empty)
            {
                return string.Empty;
            }
            DateTime date = ParseDate(value.Replace("_", ""));
            if (date == DateTime.MinValue)
            {
                return string.Empty;
            }
            return date.ToString("yyyyMMdd");
        }

        public static string DbFormatDate(object data)
        {
            if (data == null)
            {
                return string.Empty;
            }
            DateTime date = ParseDate(data.ToString());
            if (date == DateTime.MinValue)
            {
                return string.Empty;
            }
            return date.ToString("yyyyMMdd");
        }

        public static string DbFormatLongDate(object data)
        {
            if (data == null)
            {
                return string.Empty;
            }
            DateTime date = ParseDate(data.ToString());
            if (date == DateTime.MinValue)
            {
                return string.Empty;
            }
            return date.ToString("yyyyMMddHHmmss");
        }

        public static string IntValue(string value)
        {
            return value.Replace(",", "").Replace(".", "");
        }

        /// <summary>
        /// Get parameter in string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="from"></param>
        /// <returns></returns>

        public static string GetString(string source, string from, string to)
        {
            int fromlen = from.Length;
            int vend;
            int kstart = source.IndexOf(from, 0);
            string value = "";
            if (kstart != -1)
            {
                vend = source.IndexOf(to, kstart + fromlen);
                if (vend == -1)
                {
                    return "-1";
                }
                else
                {
                    value = source.Substring(kstart + fromlen, vend - kstart - fromlen);
                    return value;
                }
            }
            return "-1";
        }

        public static String StringReplace(String source, String from, String strTo)
        {

            String strDest = "";
            int intFromLen = from.Length;
            int intPos;
            while ((intPos = source.IndexOf(from)) != -1)
            {
                strDest = strDest + source.Substring(0, intPos);
                strDest = strDest + strTo;
                source = source.Substring(intPos + intFromLen);
            }
            strDest = strDest + source;


            return strDest;
        }

        public static string RemoveString(string content, string start, string end)
        {
            int pos = content.IndexOf(start);
            while (pos != -1)
            {
                string src = content.Substring(0, pos);
                string item = GetString(content, start, end);
                content = src + "" + content.Substring(pos + (start + item + end).Length);
                pos = content.IndexOf(start);
            }
            return content;
        }

        /// <summary>
        /// Generates password specific a length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateNumber(int length)
        {
            Random rd = new Random();
            string ret = "";
            for (int i = 0; i < length; i++)
            {
                ret += Convert.ToString(rd.Next(10));
            }
            return ret;
        }
        public static string FormatNumber_New(object value)
        {
            double abc = ParseDouble(value);
            String.Format("{0:0,0.00}", abc);
            return String.Format("{0:0,0.00}", abc);
        }
        /// <summary>
        /// Generate a char random
        /// </summary>
        /// <returns></returns>
        public static string GenerateChar()
        {
            Random rd = new Random();
            return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rd.NextDouble() + 65))).ToString().ToLower();
        }

        public static bool IsValid(string value)
        {
            return (value != string.Empty && value != null);
        }

        /// <summary>
        /// Gets career by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string GetCareer(string email)
        {
            if (email == null || email == string.Empty)
            {
                return string.Empty;
            }
            if (email.ToLower().IndexOf("docomo.ne.jp") != -1) //If found
            {
                return "i";
            }
            else if (email.ToLower().IndexOf("ezweb.ne.jp") != -1)
            {
                return "e";
            }
            else if (email.ToLower().IndexOf("softbank.ne.jp") != -1 || email.ToLower().IndexOf("vodafone.ne.jp") != -1)
            {
                return "s";
            }
            else
            {
                return "p";
            }

        }

        public static string ToolTipByteLen(string input, int lenLimit)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            int num = sjisEnc.GetByteCount(input);
            if (num <= lenLimit)
            {
                return input;
            }
            //input.Substring(0, 26)
            input = input.Replace("\r\n", "");
            input = input.Replace("\n", "");
            input = input.Replace("\"", "");
            input = input.Replace("'", "");
            if (num <= lenLimit)
            {
                return input;
            }
            string tmp = input.Substring(0, input.Length - 1);
            while (sjisEnc.GetByteCount(tmp) > lenLimit)
            {
                tmp = tmp.Substring(0, tmp.Length - 1);
            }

            return "<span href='#'  onmouseover=\"return showtip(event,'" + input + "');\" onmouseout=\"HideTip();\" >" + tmp + "..." + "</span>";
        }

        public static string StringLimitLen(string input, int lenLimit)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            int num = sjisEnc.GetByteCount(input);
            if (num <= lenLimit)
            {
                return input;
            }
            //input.Substring(0, 26)
            input = input.Replace("\r\n", "");
            input = input.Replace("\n", "");
            input = input.Replace("\"", "");
            input = input.Replace("'", "");
            if (num <= lenLimit)
            {
                return input;
            }
            string tmp = input.Substring(0, input.Length - 1);
            while (sjisEnc.GetByteCount(tmp) > lenLimit)
            {
                tmp = tmp.Substring(0, tmp.Length - 1);
            }

            return tmp + "...";
        }

        public static string GetStringByteLen(string input, int lenLimit)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            int num = sjisEnc.GetByteCount(input);
            if (num <= lenLimit)
            {
                return input;
            }
            //input.Substring(0, 26)
            input = input.Replace("\r\n", "");
            input = input.Replace("\n", "");
            input = input.Replace("\"", "");
            input = input.Replace("'", "");
            if (num <= lenLimit)
            {
                return input;
            }
            string tmp = input.Substring(0, input.Length - 1);
            while (sjisEnc.GetByteCount(tmp) > lenLimit)
            {
                tmp = tmp.Substring(0, tmp.Length - 1);
            }

            return tmp + "...";
        }

        public static string ToolTipText(string input)
        {
            return "  onmouseover=\"return ShowTip('" + input + "');\" onmouseout=\"HideTip();\" ";
        }


        public static string ToolTip(string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            //input.Substring(0, 26)
            input = input.Replace("\r\n", "");
            input = input.Replace("\n", "");
            input = input.Replace("\"", "");
            input = input.Replace("'", "");
            return "<span href='#'  onmouseover=\"return ShowTip('" + input + "');\" onmouseout=\"HideTip();\" >" + input.Substring(0, length) + "..." + "</span>";
        }

        public static string ToolTip(string summary, string content)
        {
            content = content.Replace("\r\n", "");
            content = content.Replace("\n", "");
            content = content.Replace("\"", "");
            content = content.Replace("\\", "");
            content = content.Replace("'", "");
            return "<span href='#' style=\"cursor:pointer;\" onmouseover=\"return ShowTip('" + content + "');\" onmouseout=\"HideTip();\" >" + summary + "</span>";
        }

        public static string ToolTip(string summary, string content, string width)
        {
            return "<span href='#' style=\"cursor:pointer;\" onmouseover=\"return ShowTip('" + content + "'," + width + ");\" onmouseout=\"HideTip();\" >" + summary + "</span>";
        }

        public static string GetCheckBoxListValue(CheckBoxList chks)
        {
            string ret = string.Empty;
            foreach (ListItem item in chks.Items)
            {
                if (item.Selected)
                {
                    ret += "/" + item.Value;
                }
            }
            if (ret != string.Empty)
            {
                ret = ret.Substring(1, ret.Length - 1);
            }
            return ret;
        }

        public static string GetListValue(ListControl list)
        {
            string ret = string.Empty;
            foreach (ListItem item in list.Items)
            {
                if (item.Selected)
                {
                    ret += item.Value + ",";
                }
            }
            if (ret != string.Empty)
            {
                ret = ret.Substring(0, ret.Length - 1);
            }
            return ret;
        }

        public static Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)

                return Root;
            foreach (Control Ctl in Root.Controls)
            {

                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)

                    return FoundCtl;
            }
            return null;
        }

        public static void SaveObject(string name, object obj)
        {
            //try
            //{
            //    FileStream file = new
            //       FileStream(Path.Combine(Constants.DataPath, name), FileMode.Create);
            //    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //    bf.Serialize(file, obj);
            //    file.Close();
            //}
            //catch (Exception ex)
            //{
            //    ApplicationLog.WriteError(ex);
            //}
        }


        public static object LoadObject(string name)
        {
            //Object obj = null;
            //try
            //{

            //    FileStream file = new FileStream(Path.Combine(Constants.DataPath, name), FileMode.Open);
            //    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf2 = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //    obj = bf2.Deserialize(file);
            //    file.Close();

            //}
            //catch (Exception ex)
            //{
            //    ApplicationLog.WriteError(ex);
            //}
            //return obj;
            return null;
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Get full name from input username
        /// </summary>
        /// <param name="userName">String type, user's name</param>
        /// <returns>String type, user's full name.</returns>
        public static string GetFullNameByUserName(string userName)
        {
            if (userName == null) return "Error: Invalid username inputed.";
            userName = userName.Trim();

            if (userName == String.Empty) return "";

            string sql = string.Format("SELECT [FullName] FROM [aspnet_Membership] WHERE [UserId] = '{0}'; ", Membership.GetUser(userName).ProviderUserKey.ToString());
            return DbHelper.GetScalar(sql);
        }

        public static void SetPageSize(System.Web.UI.WebControls.DropDownList list)
        {
            list.Items.Clear();
            ListItem item = new ListItem("10", "10");
            item.Attributes.Add("height", "50");
            list.Items.Add(item);
            item = new ListItem("20", "20");
            list.Items.Add(item);
            item = new ListItem("30", "30");
            list.Items.Add(item);
            item = new ListItem("40", "40");
            list.Items.Add(item);
            item = new ListItem("50", "50");
            list.Items.Add(item);
            item = new ListItem("100", "100");
            list.Items.Add(item);
            item = new ListItem("500", "500");
            list.Items.Add(item);
            item = new ListItem("1000", "1000");
            list.Items.Add(item);
        }

        /// <summary>
        /// Concat collection of element of SQL string
        /// </summary>
        /// <param name="sqlString">Return sql string</param>
        public static void AddSqlString(StringBuilder sql, string addSql)
        {
            addSql = addSql.Replace("\t", "");
            sql.Append(" " + addSql + " ");
        }

        /// <summary>
        /// Clear sql string
        /// </summary>
        /// <param name="sql"></param>
        public static void ClearSqlString(StringBuilder sql)
        {
            sql.Length = 0;
        }

        /// <summary>
        /// Set value for an item of a row of gridview
        /// </summary>
        /// <param name="linkItem">row needed to set value</param>
        /// <param name="linkName">colum name</param>
        /// <param name="linkValue">record value set for item</param>
        public static void SetGridTextValue(RepeaterItem item, string name, string textValue)
        {
            Literal control = (Literal)item.FindControl(name);
            if (control != null)
            {
                control.Text = textValue;
            }
        }

        /// <summary>
        /// Set value for an item of a row of gridview
        /// </summary>
        /// <param name="textItem">row needed to set value</param>
        /// <param name="linkName">column name</param>
        /// <param name="textValue">record value set for item</param>
        public static void SetGridLinkValue(RepeaterItem item, string name, string linkValue)
        {
            LinkButton control = (LinkButton)item.FindControl(name);
            if (control != null)
            {
                control.Text = linkValue;
            }
        }

        /// <summary>
        /// Set value for an item of a row of gridview
        /// </summary>
        /// <param name="textItem">row needed to set value</param>
        /// <param name="linkName">column name</param>
        /// <param name="textValue">record value set for item</param>
        public static void SetGridTextboxValue(RepeaterItem item, string name, string linkValue)
        {
            TextBox control = (TextBox)item.FindControl(name);
            if (control != null)
            {
                control.Text = linkValue;
            }
        }

        /// <summary>
        /// Set value for an item of a row of gridview
        /// </summary>
        /// <param name="checkItem">row needed to set value</param>
        /// <param name="checkName">column name</param>
        /// <param name="value">record value set for item</param>
        public static void SetGridCheckValue(RepeaterItem item, string name, bool value)
        {
            CheckBox control = (CheckBox)item.FindControl(name);
            if (control != null)
            {
                control.Checked = value;
            }
        }

        /// <summary>
        /// Set status for checkbox
        /// </summary>
        /// <param name="chk"></param>
        /// <param name="value"></param>
        public static void SetCheckValue(CheckBox chk, string value)
        {
            if (String.Compare(value.Trim().ToUpper(), "TRUE") == 0)
            {
                chk.Checked = true;
            }
            else
            {
                chk.Checked = false;
            }
        }
        /// <summary>
        /// Get checkbox value
        /// </summary>
        /// <param name="chk"></param>
        /// <returns></returns>
        public static string GetCheckValue(CheckBox chk)
        {
            return chk.Checked ? "1" : "0";
        }

        public static string CurrentDateTime
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }
        public static string CreateCSV(DataSet ds, bool header)
        {
            DataTable dt = ds.Tables[0];

            StringBuilder csv = new StringBuilder();
            //string csvPath = Request.PhysicalApplicationPath + "Sync\\csv\\" + Session.SessionID + ".csv";
            //string csvPath =  System.IO.Path.GetTempFileName();
            //System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            //System.IO.StreamWriter csv = new System.IO.StreamWriter(csvPath, false, enc);
            int colCount = dt.Columns.Count;
            int i = 0;
            string field = "";
            if (header)
            {
                //header
                for (i = 0; i < colCount; i++)
                {
                    //get header
                    field = dt.Columns[i].Caption;
                    // escape if necessary
                    if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    //write field
                    csv.Append(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        csv.Append(',');
                    }
                }
                //line feed
                csv.Append("\r\n");
            }

            //record
            foreach (DataRow row in dt.Rows)
            {
                for (i = 0; i < colCount; i++)
                {
                    field = row[i].ToString().Replace("\r\n", " ").Replace("\n", " ");
                    // escape if necessary
                    if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.IndexOf('\'') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    //write field
                    csv.Append(field);
                    //csv.Write(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        csv.Append(',');
                        //csv.Write(',');
                    }
                }
                //line feed
                csv.Append("\r\n");
                //csv.Write("\n");
            }
            //csv.Close();
            return csv.ToString();
            //return csvPath;
        }
        public static string CreateCSV(DataSet ds, bool header, ArrayList arrField)
        {
            DataTable dt = ds.Tables[0];

            StringBuilder csv = new StringBuilder();
            //string csvPath = Request.PhysicalApplicationPath + "Sync\\csv\\" + Session.SessionID + ".csv";
            //string csvPath =  System.IO.Path.GetTempFileName();
            //System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            //System.IO.StreamWriter csv = new System.IO.StreamWriter(csvPath, false, enc);
            int colCount = dt.Columns.Count;
            int i = 0;
            string field = "";
            if (header)
            {
                //header
                for (i = 0; i < colCount; i++)
                {
                    //get header
                    field = dt.Columns[i].Caption;
                    // escape if necessary
                    if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    //write field
                    csv.Append(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        csv.Append(',');
                    }
                }
                //line feed
                csv.Append("\r\n");
            }

            //record
            foreach (DataRow row in dt.Rows)
            {
                for (i = 0; i < colCount; i++)
                {
                    field = row[i].ToString().Replace("\r\n", " ").Replace("\n", " ");
                    // escape if necessary
                    /*if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.IndexOf('\'') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    */
                    if (arrField.Contains(dt.Columns[i].Caption))
                    {
                        field = "\"" + field + "\"";
                    }

                    //write field
                    csv.Append(field);
                    //csv.Write(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        csv.Append(',');
                        //csv.Write(',');
                    }
                }
                //line feed
                csv.Append("\r\n");
                //csv.Write("\n");
            }
            //csv.Close();
            return csv.ToString();
            //return csvPath;
        }
        public static string CreateCSVWithTab(DataSet ds, bool header)
        {
            DataTable dt = ds.Tables[0];

            StringBuilder csv = new StringBuilder();
            //string csvPath = Request.PhysicalApplicationPath + "Sync\\csv\\" + Session.SessionID + ".csv";
            //string csvPath =  System.IO.Path.GetTempFileName();
            //System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            //System.IO.StreamWriter csv = new System.IO.StreamWriter(csvPath, false, enc);
            int colCount = dt.Columns.Count;
            int i = 0;
            string field = "";
            if (header)
            {
                //header
                for (i = 0; i < colCount; i++)
                {
                    //get header
                    field = dt.Columns[i].Caption;
                    // escape if necessary
                    if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    //write field
                    csv.Append(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        csv.Append('\t');
                    }
                }
                //line feed
                csv.Append("\r\n");
            }

            //record
            foreach (DataRow row in dt.Rows)
            {
                for (i = 0; i < colCount; i++)
                {
                    field = row[i].ToString();
                    // escape if necessary
                    if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    //write field
                    csv.Append(field);
                    //csv.Write(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        csv.Append('\t');
                        //csv.Write(',');
                    }
                }
                //line feed
                csv.Append("\r\n");
                //csv.Write("\n");
            }
            //csv.Close();
            return csv.ToString();
            //return csvPath;
        }

        public static string CreateCSVWithTab(DataSet ds, bool header, ArrayList KanaHankakuField)
        {
            DataTable dt = ds.Tables[0];

            StringBuilder csv = new StringBuilder();
            //string csvPath = Request.PhysicalApplicationPath + "Sync\\csv\\" + Session.SessionID + ".csv";
            //string csvPath =  System.IO.Path.GetTempFileName();
            //System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            //System.IO.StreamWriter csv = new System.IO.StreamWriter(csvPath, false, enc);
            int colCount = dt.Columns.Count;
            int i = 0;
            string field = "";
            if (header)
            {
                //header
                for (i = 0; i < colCount; i++)
                {
                    //get header
                    field = dt.Columns[i].Caption;
                    // escape if necessary
                    if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    //write field
                    csv.Append(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        csv.Append('\t');
                    }
                }
                //line feed
                csv.Append("\r\n");
            }

            //record
            foreach (DataRow row in dt.Rows)
            {
                bool invalid = false;
                string tmp = "";

                for (i = 0; i < colCount; i++)
                {

                    field = row[i].ToString().Replace("\r", "").Replace("\r\n", "").Replace("\n", "").Trim();

                    if (KanaHankakuField.Contains(dt.Columns[i].Caption))
                    {
                        field = OmmitKana(field);
                        if ("".Equals(field))
                        {
                            invalid = true;
                        }
                    }

                    if (!invalid)
                    {
                        // escape if necessary
                        if (field.IndexOf('"') > -1 ||
                            field.IndexOf(',') > -1 ||
                            field.IndexOf('\r') > -1 ||
                            field.IndexOf('\n') > -1 ||
                            field.StartsWith(" ") || field.StartsWith("\t") ||
                            field.EndsWith(" ") || field.EndsWith("\t"))
                        {
                            if (field.IndexOf('"') > -1)
                            {
                                //" --> ""
                                field = field.Replace("\"", "\"\"");
                            }
                            field = "\"" + field + "\"";
                        }
                        //write field
                        tmp += field;
                        //csv.Write(field);
                        //write comma
                        if (colCount > i + 1)
                        {
                            tmp += "\t";
                            //csv.Write(',');
                        }
                    }
                }
                if (!invalid && !String.IsNullOrEmpty(tmp))
                {
                    //line feed
                    csv.Append(tmp);
                    csv.Append("\r\n");
                    //csv.Write("\n");
                }
            }
            //csv.Close();
            return csv.ToString();
            //return csvPath;
        }
        public static string CreateCSVWithTab(DataSet ds, bool header, ArrayList KanaHankakuField, bool Han2Zen)
        {
            DataTable dt = ds.Tables[0];

            StringBuilder csv = new StringBuilder();
            //string csvPath = Request.PhysicalApplicationPath + "Sync\\csv\\" + Session.SessionID + ".csv";
            //string csvPath =  System.IO.Path.GetTempFileName();
            //System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            //System.IO.StreamWriter csv = new System.IO.StreamWriter(csvPath, false, enc);
            int colCount = dt.Columns.Count;
            int i = 0;
            string field = "";
            if (header)
            {
                //header
                for (i = 0; i < colCount; i++)
                {
                    //get header
                    field = dt.Columns[i].Caption;
                    // escape if necessary
                    if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    //write field
                    csv.Append(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        csv.Append('\t');
                    }
                }
                //line feed
                csv.Append("\r\n");
            }

            //record
            foreach (DataRow row in dt.Rows)
            {
                bool invalid = false;
                string tmp = "";

                for (i = 0; i < colCount; i++)
                {

                    field = row[i].ToString();

                    if (KanaHankakuField.Contains(dt.Columns[i].Caption))
                    {
                        field = OmmitKana(field);
                        if ("".Equals(field))
                        {
                            invalid = true;
                        }
                        field = Han2Zen ? Strings.StrConv(field, VbStrConv.Wide, 0x0411) : field;
                        field = field.Replace("゛", "").Replace("゜", "");
                    }

                    if (!invalid)
                    {
                        // escape if necessary
                        if (field.IndexOf('"') > -1 ||
                            field.IndexOf(',') > -1 ||
                            field.IndexOf('\r') > -1 ||
                            field.IndexOf('\n') > -1 ||
                            field.StartsWith(" ") || field.StartsWith("\t") ||
                            field.EndsWith(" ") || field.EndsWith("\t"))
                        {
                            if (field.IndexOf('"') > -1)
                            {
                                //" --> ""
                                field = field.Replace("\"", "\"\"");
                            }
                            field = "\"" + field + "\"";
                        }
                        //write field
                        tmp += field;
                        //csv.Write(field);
                        //write comma
                        if (colCount > i + 1)
                        {
                            tmp += "\t";
                            //csv.Write(',');
                        }
                    }
                }
                if (!invalid)
                {
                    //line feed
                    csv.Append(tmp);
                    csv.Append("\r\n");
                    //csv.Write("\n");
                }
            }
            //csv.Close();
            return csv.ToString();
            //return csvPath;
        }
        public static string CreateCSVWithTabFieldByteLimit(DataSet ds, bool header, ArrayList KanaHankakuField, bool Han2Zen, string fieldByteLimit)
        {
            DataTable dt = ds.Tables[0];

            StringBuilder csv = new StringBuilder();

            int colCount = dt.Columns.Count;
            int i = 0;
            string field = "";
            if (header)
            {
                //header
                for (i = 0; i < colCount; i++)
                {
                    //get header
                    field = dt.Columns[i].Caption;
                    // escape if necessary
                    if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    //write field
                    csv.Append(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        csv.Append('\t');
                    }
                }
                //line feed
                csv.Append("\r\n");
            }

            //record
            foreach (DataRow row in dt.Rows)
            {
                bool invalid = false;
                string tmp = "";

                for (i = 0; i < colCount; i++)
                {

                    field = row[i].ToString().Replace("\r", " ").Replace("\r\n", " ").Replace("\n", "");

                    if (KanaHankakuField.Contains(dt.Columns[i].Caption))
                    {
                        field = OmmitKana(field);
                        if ("".Equals(field))
                        {
                            invalid = true;
                        }
                        field = Han2Zen ? Strings.StrConv(field, VbStrConv.Wide, 0x0411) : field;
                        field = field.Replace("゛", "").Replace("゜", "");
                    }
                    if (fieldByteLimit.Equals(dt.Columns[i].Caption))
                    {
                        field = GetStringByteLen(field, 55);
                        field = Strings.StrConv(field, VbStrConv.Narrow, 0);
                    }

                    if (!invalid)
                    {
                        // escape if necessary
                        if (field.IndexOf('"') > -1 ||
                            field.IndexOf(',') > -1 ||
                            field.IndexOf('\r') > -1 ||
                            field.IndexOf('\n') > -1 ||
                            field.StartsWith(" ") || field.StartsWith("\t") ||
                            field.EndsWith(" ") || field.EndsWith("\t"))
                        {
                            if (field.IndexOf('"') > -1)
                            {
                                //" --> ""
                                field = field.Replace("\"", "\"\"");
                            }
                            field = "\"" + field + "\"";
                        }
                        //write field
                        tmp += field;
                        //csv.Write(field);
                        //write comma
                        if (colCount > i + 1)
                        {
                            tmp += "\t";
                            //csv.Write(',');
                        }
                    }
                }
                if (!invalid)
                {
                    //line feed
                    csv.Append(tmp);
                    csv.Append("\r\n");
                    //csv.Write("\n");
                }
            }
            //csv.Close();
            return csv.ToString();
            //return csvPath;
        }
        public static string OmmitKana(string str)
        {
            string ret = "";
            int len = str.Length;

            for (int i = 0; i < len; i++)
            {
                string one = str.Substring(i, 1);
                if (System.Text.RegularExpressions.Regex.IsMatch(one, "[ｦ-ﾟ]"))
                {
                    ret += one;
                }
            }
            return ret;
        }

        public static ArrayList CreateCSVList(DataSet ds, bool headerFlg)
        {
            int getRecords = 300;
            ArrayList csvList = new ArrayList();
            DataTable dt = ds.Tables[0];

            int count = dt.Rows.Count;
            int devide = count / getRecords;
            int odd = count % getRecords;
            int number = devide;
            if (odd > 0)
            {
                number++;
            }


            StringBuilder csv = new StringBuilder();
            //string csvPath = Request.PhysicalApplicationPath + "Sync\\csv\\" + Session.SessionID + ".csv";
            //string csvPath =  System.IO.Path.GetTempFileName();
            //System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            //System.IO.StreamWriter csv = new System.IO.StreamWriter(csvPath, false, enc);
            int colCount = dt.Columns.Count;
            int i = 0;

            StringBuilder header = new StringBuilder();
            string field = "";
            if (headerFlg)
            {
                //header
                for (i = 0; i < colCount; i++)
                {
                    //get header
                    field = dt.Columns[i].Caption;
                    // escape if necessary
                    if (field.IndexOf('"') > -1 ||
                        field.IndexOf(',') > -1 ||
                        field.IndexOf('\r') > -1 ||
                        field.IndexOf('\n') > -1 ||
                        field.StartsWith(" ") || field.StartsWith("\t") ||
                        field.EndsWith(" ") || field.EndsWith("\t"))
                    {
                        if (field.IndexOf('"') > -1)
                        {
                            //" --> ""
                            field = field.Replace("\"", "\"\"");
                        }
                        field = "\"" + field + "\"";
                    }
                    //write field
                    header.Append(field);
                    //write comma
                    if (colCount > i + 1)
                    {
                        header.Append(',');
                    }
                }
                //line feed
                header.Append("\r\n");
            }
            string strHeader = header.ToString();

            for (int j = 0; j < number; j++)
            {
                csv = new StringBuilder();
                csv.Append(strHeader);
                for (int k = j * getRecords; k < ((j + 1) * getRecords) && k < dt.Rows.Count; k++)
                {
                    for (i = 0; i < colCount; i++)
                    {
                        field = dt.Rows[k][i].ToString();
                        // escape if necessary
                        if (field.IndexOf('"') > -1 ||
                            field.IndexOf(',') > -1 ||
                            field.IndexOf('\r') > -1 ||
                            field.IndexOf('\n') > -1 ||
                            field.StartsWith(" ") || field.StartsWith("\t") ||
                            field.EndsWith(" ") || field.EndsWith("\t"))
                        {
                            if (field.IndexOf('"') > -1)
                            {
                                //" --> ""
                                field = field.Replace("\"", "\"\"");
                            }
                            field = "\"" + field + "\"";
                        }
                        //write field
                        csv.Append(field);
                        //csv.Write(field);
                        //write comma
                        if (colCount > i + 1)
                        {
                            csv.Append(',');
                            //csv.Write(',');
                        }
                    }
                    //line feed
                    csv.Append("\r\n");
                    //csv.Write("\n");
                }
                csvList.Add(csv.ToString());
            }
            /*
                //record
                foreach (DataRow row in dt.Rows)
                {
                    for (i = 0; i < colCount; i++)
                    {
                        field = row[i].ToString();
                        // escape if necessary
                        if (field.IndexOf('"') > -1 ||
                            field.IndexOf(',') > -1 ||
                            field.IndexOf('\r') > -1 ||
                            field.IndexOf('\n') > -1 ||
                            field.StartsWith(" ") || field.StartsWith("\t") ||
                            field.EndsWith(" ") || field.EndsWith("\t"))
                        {
                            if (field.IndexOf('"') > -1)
                            {
                                //" --> ""
                                field = field.Replace("\"", "\"\"");
                            }
                            field = "\"" + field + "\"";
                        }
                        //write field
                        csv.Append(field);
                        //csv.Write(field);
                        //write comma
                        if (colCount > i + 1)
                        {
                            csv.Append(',');
                            //csv.Write(',');
                        }
                    }
                    //line feed
                    csv.Append("\r\n");
                    //csv.Write("\n");
                }
            */
            //csvList.Add(csv.ToString());
            //csv.Close();
            return csvList;
            //return csvPath;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public static string getChangedFormat(string strSabi)
        {
            int intSabiStartMinute = int.Parse(strSabi.Substring(0, 2));
            int intSabiStartSecond = int.Parse(strSabi.Substring(2, 2));
            int intSabiStartMiliSecond = strSabi.Length > 4 ? int.Parse(strSabi.Substring(4, 3)) : 0;
            string changed = String.Format("{00}", intSabiStartMinute) + String.Format(":" + "{00}", intSabiStartSecond) + String.Format("." + "{000}", intSabiStartMiliSecond);

            return changed;
        }


        //public static void SynData(string action, DataSet dsSite, string mstTable, string selectFields, string where, string key, bool logFlg, string userName)
        //{
        //    string[,] resultSync = new string[20, 3];
        //    string delFlag = "0";
        //    try
        //    {
        //        if (mstTable.ToLower().IndexOf("song") >= 0)
        //        {
        //            delFlag = "";
        //        }
        //        PostToFile post = new PostToFile(mstTable, key, selectFields, where, delFlag, dsSite, action, logFlg, userName);
        //        Thread threadObj = new Thread(new ThreadStart(post.Post));
        //        threadObj.Priority = ThreadPriority.Highest;
        //        threadObj.Start();
        //        Thread.Sleep(1000);
        //        threadObj.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        ICJSystem.Instance.Log.Error(ex.Message);
        //    }
        //}
        public static void LinkPopup(LinkButton lnkBtn, string url, int width, int height, string popupName)
        {
            lnkBtn.OnClientClick = "PopUp('" + url + "'," + width + "," + height + ",'" + popupName + "', true); return false;";
        }
        public static void ButtonPopup(Button btn, string url, int width, int height, string popupName)
        {
            btn.OnClientClick = "PopUp('" + url + "'," + width + "," + height + ",'" + popupName + "', true); return false;";
        }
        public static void ZipFiles(string inputFolderPath, string outputPathAndFile, string password)
        {
            ArrayList ar = GenerateFileList(inputFolderPath); // generate file list
            int TrimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
            // find number of chars to remove     // from orginal file path
            TrimLength += 1; //remove '\'
            FileStream ostream;
            byte[] obuffer;
            string outPath = outputPathAndFile;
            ZipOutputStream oZipStream = new ZipOutputStream(File.Create(outPath)); // create zip stream
            if (password != null && password != String.Empty)
                oZipStream.Password = password;
            oZipStream.SetLevel(9); // maximum compression
            ZipEntry oZipEntry;
            foreach (string Fil in ar) // for each file, generate a zipentry
            {
                oZipEntry = new ZipEntry(Fil.Remove(0, TrimLength));
                oZipStream.PutNextEntry(oZipEntry);

                if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                {
                    ostream = File.OpenRead(Fil);
                    obuffer = new byte[ostream.Length];
                    ostream.Read(obuffer, 0, obuffer.Length);
                    oZipStream.Write(obuffer, 0, obuffer.Length);
                    ostream.Close();
                }
            }
            oZipStream.Finish();
            oZipStream.Close();
        }

        private static ArrayList GenerateFileList(string Dir)
        {
            ArrayList fils = new ArrayList();
            bool Empty = true;
            foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
            {
                fils.Add(file);
                Empty = false;
            }

            if (Empty)
            {
                if (Directory.GetDirectories(Dir).Length == 0)
                // if directory is completely empty, add it
                {
                    fils.Add(Dir + @"/");
                }
            }

            foreach (string dirs in Directory.GetDirectories(Dir)) // recursive
            {
                foreach (object obj in GenerateFileList(dirs))
                {
                    fils.Add(obj);
                }
            }
            return fils; // return file list
        }

        private static double RoundOff(double roundValue, int digits)
        {
            double shift = Math.Pow(10, (double)digits);
            return Math.Floor(roundValue * shift + 0.5) / shift;
        }

        public static string GetPriceNoTax(string price)
        {
            string priceNoTax = "";
            if ("368".Equals(price) || "367".Equals(price))
            {
                priceNoTax = "350";
            }
            else if ("388".Equals(price))
            {
                priceNoTax = "370";
            }
            else if ("262".Equals(price))
            {
                priceNoTax = "250";
            }
            else if ("157".Equals(price))
            {
                priceNoTax = "150";
            }
            else
            {
                priceNoTax = ParseString(Math.Round(RoundOff(ParseDouble(price) / 1.05, 2)));
            }
            return priceNoTax;
        }
        public static string GetBuyUnique(string priceNoTax, string rate)
        {
            double dPriceNoTax = ParseDouble(priceNoTax);
            string buyUnique = ParseString(RoundOff(dPriceNoTax * ParseDouble(rate), 2));
            return buyUnique;
        }
        public static string GetCopyrightFeeUnique(string CopyrightContractId, string priceNoTax, string type)
        {
            DataTable dt = DbHelper.GetDataTable("SELECT * FROM CopyrightContract WHERE CopyrightContractId  = '" + CopyrightContractId + "'");

            if (String.IsNullOrEmpty(priceNoTax))
            {
                return "0";
            }
            string ritsu = "";
            string fixVal = "";
            foreach (DataRow row in dt.Rows)
            {
                string ritsuFull = Func.FormatDecimal(row["HbunRitsuFull"]);
                string ritsuUta = Func.FormatDecimal(row["HbunRitsuUta"]);
                string ritsuVideo = Func.FormatDecimal(row["HbunRitsuVideo"]);
                string ritsuRbt = Func.FormatDecimal(row["HbunRitsuRbt"]);
                string ritsuKaraoke = Func.FormatDecimal(row["HbunRitsuKaraoke"]);
                string ritsuMelo = Func.FormatDecimal(row["HbunRitsuMelo"]);

                string FixValFull = Func.FormatDecimal(row["FixFeeUniqueFull"]);
                string FixValUta = Func.FormatDecimal(row["FixFeeUniqueUta"]);
                string FixValVideo = Func.FormatDecimal(row["FixFeeUniqueVideo"]);
                string FixValRbt = Func.FormatDecimal(row["FixFeeUniqueRbt"]);
                string FixValKaraoke = Func.FormatDecimal(row["FixFeeUniqueKaraoke"]);
                string FixValMelo = Func.FormatDecimal(row["FixFeeUniqueMelo"]);

                if ("1".Equals(type))
                {
                    ritsu = ritsuFull;
                    fixVal = FixValFull;
                }
                else if ("2".Equals(type))
                {
                    ritsu = ritsuUta;
                    fixVal = FixValUta;
                }
                else if ("3".Equals(type))
                {
                    ritsu = ritsuVideo;
                    fixVal = FixValVideo;
                }
                else if ("4".Equals(type))
                {
                    ritsu = ritsuRbt;
                    fixVal = FixValRbt;
                }
                else if ("5".Equals(type))
                {
                    ritsu = ritsuKaraoke;
                    fixVal = FixValKaraoke;
                }
                else if ("6".Equals(type))
                {
                    ritsu = ritsuMelo;
                    fixVal = FixValMelo;
                }
            }
            if (String.IsNullOrEmpty(ritsu))
            {
                ritsu = "0";
            }

            double copyrightFeeUnique = 0;
            double dPriceNoTax = ParseDouble(priceNoTax);
            if (ParseDouble(ritsu) > 0)
            {
                copyrightFeeUnique = RoundOff(dPriceNoTax * ParseDouble(ritsu), 2);
                if (!String.IsNullOrEmpty(fixVal) && copyrightFeeUnique < ParseDouble(fixVal))
                {
                    copyrightFeeUnique = ParseDouble(fixVal);
                }
            }
            if (ParseDouble(ritsu) <= 0 && !String.IsNullOrEmpty(fixVal) && !"0".Equals(fixVal))
            {
                copyrightFeeUnique = ParseDouble(fixVal);
            }
            return "".Equals(ParseString(copyrightFeeUnique)) ? "0" : ParseString(copyrightFeeUnique);

            //if (!String.IsNullOrEmpty(fixVal) && !"0".Equals(fixVal))
            //{
            //    return fixVal;
            //}

            //string copyrightFeeUnique = "";
            //double dPriceNoTax = ParseDouble(priceNoTax);
            //copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * ParseDouble(ritsu), 2));
            //return "".Equals(copyrightFeeUnique) ? "0" : copyrightFeeUnique;


            //if ("JASRAC".Equals(copyrightOrg) || "JASRAC（歌詞付）".Equals(copyrightOrg))
            //{
            //    if ("1".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.077, 2));
            //    }
            //    else if ("2".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.072, 2));

            //    }
            //    else if ("3".Equals(type) || "5".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.077, 2));
            //    }
            //    else if ("4".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.045, 2));
            //    }
            //}
            ///*
            //else if ("JASRAC（歌詞付）".Equals(copyrightOrg))
            //{
            //    copyrightFeeUnique = ParseString(RoundOff((dPriceNoTax / 2) * 0.077 + (dPriceNoTax / 2) * 0.1, 2));
            //}
            //     * */
            //else if ("その他4%".Equals(copyrightOrg))
            //{
            //    copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.04, 2));
            //}
            //    /*
            //else if ("e-license（歌詞付）".Equals(copyrightOrg))
            //{
            //    copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.065 + ((dPriceNoTax) * 0.09), 2));
            //}
            //     */
            //else if ("e-license".Equals(copyrightOrg) || "e-license（歌詞付）".Equals(copyrightOrg))
            //{
            //    if ("1".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.065, 2));
            //    }
            //    else if ("2".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.065, 2));

            //    }
            //    else if ("3".Equals(type) || "5".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.059, 2));
            //    }
            //    else if ("4".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.045, 2));
            //    }
            //}
            //else if ("その他7.7%".Equals(copyrightOrg))
            //{
            //    if ("1".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.077, 2));
            //    }
            //    else if ("2".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.072, 2));

            //    }
            //    else if ("3".Equals(type) || "5".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.077, 2));
            //    }
            //    else if ("4".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.045, 2));
            //    }
            //}
            //else if ("JRC".Equals(copyrightOrg))
            //{
            //    if ("1".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.075, 2));
            //    }
            //    else if ("2".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.06, 2));

            //    }
            //    else if ("3".Equals(type) || "5".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.075, 2));
            //    }
            //    else if ("4".Equals(type))
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.06, 2));
            //    }
            //}
            //else if ("e-licene".Equals(copyrightOrg))
            //{
            //    if (dPriceNoTax <= 100)
            //    {
            //        copyrightFeeUnique = "6.5";
            //    }
            //    else
            //    {
            //        copyrightFeeUnique = ParseString(RoundOff(dPriceNoTax * 0.063, 2));
            //    }
            //}
            //else if ("その他(歌詞付)8.85%".Equals(copyrightOrg) || "その他8.85%".Equals(copyrightOrg))
            //{
            //    copyrightFeeUnique = ParseString(RoundOff(((dPriceNoTax / 2) * 0.077) + ((dPriceNoTax / 2) * 0.1), 2));

            //}
            //else
            //{
            //    copyrightFeeUnique = "0";
            //}
            //return "".Equals(copyrightFeeUnique) ? "0" : copyrightFeeUnique;
        }

        public static string GetProfitUnique(string priceNoTax, string buyUnique, string copyrightFeeUnique, string KDDICommissionUnique)
        {
            double dPriceNoTax = ParseDouble(priceNoTax);
            return ParseString(dPriceNoTax -
                ParseDouble(buyUnique) -
                ParseDouble(copyrightFeeUnique) -
                ParseDouble(KDDICommissionUnique));
        }

        //public static string SaveLocalFile(string filePath, string fileType, string toFolder)
        //{
        //    if (File.Exists(filePath))
        //    {
        //        MoneWs.Service ws = new Man.MoneWs.Service();
        //        //Mone Server --> SV860(ICJ Local) File Copy with Web Service Attachments
        //        ws.RequestSoapContext.Attachments.Add(
        //            new Microsoft.Web.Services.Dime.DimeAttachment(
        //                fileType, Microsoft.Web.Services.Dime.TypeFormatEnum.MediaType, filePath)
        //        );
        //        string tmp = Encryption64.Encrypt(toFolder, "!#$a54?3");
        //        string retFileName = ws.PutDataToFolder(Path.GetFileName(filePath), tmp);
        //        return retFileName;
        //    }
        //    return null;
        //}

        //public static bool FolderExists(MoneWs.Service ws, string path)
        //{
        //    string tmp = Encryption64.Encrypt(path, "!#$a54?3");
        //    return ws.FolderExists(tmp);
        //}

        //public static bool FileExists(MoneWs.Service ws, string filePath)
        //{
        //    string tmp = Encryption64.Encrypt(filePath, "!#$a54?3");
        //    return ws.FileExists(tmp);
        //}

        //public static string FileLicense(MoneWs.Service ws, string path)
        //{
        //    string tmp = Encryption64.Encrypt(path, "!#$a54?3");
        //    return ws.FileLicense(tmp);
        //}

        //public static void ChangeFileName(MoneWs.Service ws, string fileNameList)
        //{
        //    string tmp = Encryption64.Encrypt(fileNameList, "!#$a54?3");
        //    ws.ChangeFileName(tmp);
        //}
        //// Binh Add Start
        //public static void CutAuditionFile(MoneWs.Service ws, string fileNameList)
        //{
        //    string tmp = Encryption64.Encrypt(fileNameList, "!#$a54?3");
        //    ws.CutAuditionFile(tmp);
        //}
        //// Binh Add End
        //public static string FileSizeGetter(MoneWs.Service ws, string path, string[] fileType)
        //{
        //    string tmp = Encryption64.Encrypt(path, "!#$a54?3");
        //    return ws.FileSizeGetter(tmp, fileType);
        //}

        //public static string GetBasicPath(MoneWs.Service ws)
        //{
        //    return Encryption64.Decrypt(ws.GetBasicPath(), "!#$a54?3");
        //}

        //region sorting methods

        public static void SortByValue(ListControl combo)
        {
            SortCombo(combo, new ComboValueComparer());
        }
        public static void SortByText(ListControl combo)
        {
            SortCombo(combo, new ComboTextComparer());
        }
        private static void SortCombo(ListControl combo, IComparer comparer)
        {
            int i;
            if (combo.Items.Count <= 1)
                return;
            ArrayList arrItems = new ArrayList();
            for (i = 0; i < combo.Items.Count; i++)
            {
                ListItem item = combo.Items[i];
                arrItems.Add(item);
            }
            arrItems.Sort(comparer);
            combo.Items.Clear();
            for (i = 0; i < arrItems.Count; i++)
            {
                combo.Items.Add((ListItem)arrItems[i]);
            }
        }
        //region Combo Comparers
        /// <summary>
        /// compare list items by their value
        /// </summary>
        private class ComboValueComparer : IComparer
        {
            public enum SortOrder
            {
                Ascending = 1,
                Descending = -1
            }
            private int _modifier;
            public ComboValueComparer()
            {
                _modifier = (int)SortOrder.Ascending;
            }
            public ComboValueComparer(SortOrder order)
            {
                _modifier = (int)order;
            }
            //sort by value
            public int Compare(Object o1, Object o2)
            {
                ListItem cb1 = (ListItem)o1;
                ListItem cb2 = (ListItem)o2;
                return cb1.Value.CompareTo(cb2.Value) * _modifier;
            }
        } //end class ComboValueComparer
        /// <summary>
        /// compare list items by their text.
        /// </summary>
        private class ComboTextComparer : IComparer
        {
            public enum SortOrder
            {
                Ascending = 1,
                Descending = -1
            }
            private int _modifier;
            public ComboTextComparer()
            {
                _modifier = (int)SortOrder.Ascending;
            }
            public ComboTextComparer(SortOrder order)
            {
                _modifier = (int)order;
            }
            //sort by value
            public int Compare(Object o1, Object o2)
            {
                ListItem cb1 = (ListItem)o1;
                ListItem cb2 = (ListItem)o2;
                return cb1.Text.CompareTo(cb2.Text) * _modifier;
            }
        }
        public static string invalidLenght(int i)
        {
            return "長さが" + i + "バイトより大きい。";
        }
        public static string invalidEqual(int i)
        {
            return "長さが" + i + "バイトはず。";
        }

        public static string invalidNull()
        {
            return "ヌル又はブランク";
        }
        public static string invalidDate()
        {
            return "不正な日付フォーマット";
        }
        public static string invalidNumber()
        {
            return "数値";
        }

        // Binh add start
        public static bool IsZipFile(string fileName)
        {
            string pattern = "(.*?)\\.(zip|rar)$";
            return Regex.IsMatch(fileName, pattern, RegexOptions.IgnoreCase);
        }
        // Binh add end

        public static string dochangchuc(decimal so, bool daydu)
        {
            string chuoi = "";
            int chuc = (int) so / 10;
            int donvi = (int)so % 10;
            if (chuc > 1)
            {
                chuoi = " " + mangso[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {
                chuoi = " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (daydu && donvi > 0)
            {
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc > 1)
            {
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mangso[donvi];
            }
            return chuoi;
        }
        public static string docblock(decimal so, bool daydu)
        {
            string chuoi = "";
            int tram = (int)so / 100;
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mangso[tram] + " trăm";
                chuoi += dochangchuc(so, true);
            }
            else
            {
                chuoi = dochangchuc(so, false);
            }
            return chuoi;
        }
        public static string dochangtrieu(decimal so, bool daydu)
        {
            string chuoi = "";
            decimal trieu = so / 1000000;
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = docblock(trieu, daydu) + " triệu";
                daydu = true;
            }
            int nghin = (int) so / 1000;
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += docblock(nghin, daydu) + " ngàn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += docblock(so, daydu);
            }
            return chuoi;
        }

        public static string getMACC(string strName)
        {
            string result = strName.Substring(strName.Length - 4, 4);
            return result;
        }
        public static string parseYYYYMM(Object value)
        {
            if (value == null || value == System.DBNull.Value || "".Equals(value)) return "";
            return Convert.ToString(value).Substring(4, 2) + "/" + Convert.ToString(value).Substring(0, 4);
        }
        public static string docso(decimal so)
        {
            decimal tmp = so;
            if (so < 0)
                so = -1 * so;

            if (so == 0) { return mangso[0]; }
            string chuoi = "";
            string hauto = "";
            decimal ty = 0;
            int i = 0;

            int ti = 0;
           
            ty = so % 1000000000;
            so = so / 1000000000;

            ti = (int)so;

            if ( Math.Truncate(so) > 0)
            {
                chuoi = dochangtrieu(ty, true) + hauto + chuoi + " đồng";
            }
            else
            {
                chuoi = dochangtrieu(ty, false) + hauto + chuoi + " đồng";
            }
            hauto = " tỉ";

            if (ti > 0)
                chuoi = mangso[ti] + hauto + chuoi;

            if (tmp < 0)
            {
                chuoi = "Trừ "+chuoi;
            }
            return chuoi;
        }

        public static string Encrypt(string toEncrypt, bool useHashing, string strKey)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue(strKey, typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        private static string[] _ones =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };

        private static string[] _teens =
        {
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        private static string[] _tens =
        {
            "",
            "ten",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };

        // US Nnumbering:
        private static string[] _thousands =
        {
            "",
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion"
        };

        /// <summary>
        /// Converts a numeric value to words suitable for the portion of
        /// a check that writes out the amount.
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <returns></returns>
        public static string DocSo_En(decimal value)
        {
            decimal tmp = value;
            if (value < 0)
                value = -1 * value;

            string digits, temp;
            bool showThousands = false;
            bool allZeros = true;

            // Use StringBuilder to build result
            StringBuilder builder = new StringBuilder();
            // Convert integer portion of value to string
            digits = ((long)value).ToString();
            // Traverse characters in reverse order
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int ndigit = (int)(digits[i] - '0');
                int column = (digits.Length - (i + 1));

                // Determine if ones, tens, or hundreds column
                switch (column % 3)
                {
                    case 0:        // Ones position
                        showThousands = true;
                        if (i == 0)
                        {
                            // First digit in number (last in loop)
                            temp = String.Format("{0} ", _ones[ndigit]);
                        }
                        else if (digits[i - 1] == '1')
                        {
                            // This digit is part of "teen" value
                            temp = String.Format("{0} ", _teens[ndigit]);
                            // Skip tens position
                            i--;
                        }
                        else if (ndigit != 0)
                        {
                            // Any non-zero digit
                            temp = String.Format("{0} ", _ones[ndigit]);
                        }
                        else
                        {
                            // This digit is zero. If digit in tens and hundreds
                            // column are also zero, don't show "thousands"
                            temp = String.Empty;
                            // Test for non-zero digit in this grouping
                            if (digits[i - 1] != '0' || (i > 1 && digits[i - 2] != '0'))
                                showThousands = true;
                            else
                                showThousands = false;
                        }

                        // Show "thousands" if non-zero in grouping
                        if (showThousands)
                        {
                            if (column > 0)
                            {
                                temp = String.Format("{0}{1}{2}",
                                    temp,
                                    _thousands[column / 3],
                                    allZeros ? " " : ", ");
                            }
                            // Indicate non-zero digit encountered
                            allZeros = false;
                        }
                        builder.Insert(0, temp);
                        break;

                    case 1:        // Tens column
                        if (ndigit > 0)
                        {
                            temp = String.Format("{0}{1}",
                                _tens[ndigit],
                                (digits[i + 1] != '0') ? "-" : " ");
                            builder.Insert(0, temp);
                        }
                        break;

                    case 2:        // Hundreds column
                        if (ndigit > 0)
                        {
                            temp = String.Format("{0} hundred ", _ones[ndigit]);
                            builder.Insert(0, temp);
                        }
                        break;
                }
            }

            string strMinus = "";
            if (tmp < 0)
            {
                strMinus = "Minus ";
            }
            // Append fractional portion/cents
            //builder.AppendFormat("and {0:00}/100", (value - (long)value) * 100);

            // Capitalize first letter
            return strMinus + String.Format("{0}{1}",
                Char.ToUpper(builder[0]),
                builder.ToString(1, builder.Length - 1));
        }

        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing, string strKey)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue(strKey, typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }


    }
}
