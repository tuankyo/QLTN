using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Man.Utils;
namespace Man
{
    public class RepeaterRowSpan
    {
        private int _total = 0;
        private int _rowCount = 1;
        private int _index;
        private string _value;
        private int _pageSize = 0;

        public int Total
        {
            get { return this._total; }
            set { this._total = value; }
        }

        public int RowCount
        {
            get { return this._rowCount; }
            set { this._rowCount = value; }
        }

        public int Index
        {
            get { return this._index; }
            set { this._index = value; }
        }

        public string Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        public RepeaterRowSpan(int total)
        {
            this._total = total;
        }

        public RepeaterRowSpan(int total, int pageSize)
        {
            this._total = total;
            this._pageSize = pageSize;
        }

        public void Init(int index, string value)
        {
            this._index = index;
            this._value = value;
            this._rowCount = 1;
        }

        public void SetRowValue(bool otherBreak, int index, string value, Repeater rpt, RepeaterItem item, string controlId, string width)
        {
            if (this._value == null)
            {
                Init(index, value);
                if (_total == 1)
                {
                    Literal ltr = (Literal)item.FindControl(controlId);
                    ltr.Text = " <td align=\"center\" style=\"width:" + width + "\">" + _value + "</td>";
                }
            }
            else
            {
                if (index == _total - 1 || index == _pageSize - 1)
                {
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" style=\"width:" + width + "\"" + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        ltr = (Literal)item.FindControl(controlId);
                        ltr.Text = " <td align=\"center\" style=\"width:" + width + "\">" + value + "</td>";
                    }
                    else
                    {
                        _rowCount++;
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" style=\"width:" + width + "\"" + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                    }
                }
                else
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" style=\"width:" + width + "\"" + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        Init(index, value);
                    }
                    else
                    {
                        _rowCount++;
                    }
            }
        }

        public void SetRowValueLeft(bool otherBreak, int index, string value, Repeater rpt, RepeaterItem item, string controlId, string width)
        {
            if (this._value == null)
            {
                Init(index, value);
                if (_total == 1)
                {
                    Literal ltr = (Literal)item.FindControl(controlId);
                    ltr.Text = " <td align=\"left\" style=\"width:" + width + "\">" + _value + "</td>";
                }
            }
            else
            {
                if (index == _total - 1 || index == _pageSize - 1)
                {
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"left\" style=\"width:" + width + "\"" + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        ltr = (Literal)item.FindControl(controlId);
                        ltr.Text = " <td align=\"left\" style=\"width:" + width + "\">" + value + "</td>";
                    }
                    else
                    {
                        _rowCount++;
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"left\" style=\"width:" + width + "\"" + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                    }
                }
                else
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"left\" style=\"width:" + width + "\"" + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        Init(index, value);
                    }
                    else
                    {
                        _rowCount++;
                    }
            }
        }

        public void SetRowValue(bool otherBreak, int index, string value, Repeater rpt, RepeaterItem item, string controlId)
        {
            if (this._value == null)
            {
                Init(index, value);
                if (_total == 1)
                {
                    Literal ltr = (Literal)item.FindControl(controlId);
                    ltr.Text = " <td align=\"center\">" + _value + "</td>";
                }
            }
            else
            {
                if (index == _total - 1 || index == _pageSize - 1)
                {
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        ltr = (Literal)item.FindControl(controlId);
                        ltr.Text = " <td align=\"center\">" + value + "</td>";
                    }
                    else
                    {
                        _rowCount++;
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                    }
                }
                else
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        Init(index, value);
                    }
                    else
                    {
                        _rowCount++;
                    }
            }
        }

        public void SetRowValue2Row(bool otherBreak, int index, string value, Repeater rpt, RepeaterItem item, string controlId)
        {
            if (this._value == null)
            {
                Init(index, value);
                if (_total == 1)
                {
                    Literal ltr = (Literal)item.FindControl(controlId);
                    ltr.Text = " <td align=\"center\" rowspan=\"2\">" + _value + "</td>";
                }
            }
            else
            {
                if (index == _total - 1 || index == _pageSize - 1)
                {
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount * 2 : " rowspan=\"2\" ") + ">" + _value + "</td>";
                        ltr = (Literal)item.FindControl(controlId);
                        ltr.Text = " <td align=\"center\" rowspan=\"2\">" + value + "</td>";
                    }
                    else
                    {
                        _rowCount++;
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount * 2 : " rowspan=\"2\" ") + ">" + _value + "</td>";
                    }
                }
                else
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount * 2 : " rowspan=\"2\" ") + ">" + _value + "</td>";
                        Init(index, value);
                    }
                    else
                    {
                        _rowCount++;
                    }
            }
        }

        public void SetRowValueLeft(bool otherBreak, int index, string value, Repeater rpt, RepeaterItem item, string controlId)
        {
            if (this._value == null)
            {
                Init(index, value);
                if (_total == 1)
                {
                    Literal ltr = (Literal)item.FindControl(controlId);
                    ltr.Text = " <td align=\"left\">" + _value + "</td>";
                }
            }
            else
            {
                if (index == _total - 1 || index == _pageSize - 1)
                {
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"left\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        ltr = (Literal)item.FindControl(controlId);
                        ltr.Text = " <td align=\"left\">" + value + "</td>";
                    }
                    else
                    {
                        _rowCount++;
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"left\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                    }
                }
                else
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"left\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        Init(index, value);
                    }
                    else
                    {
                        _rowCount++;
                    }
            }
        }

        public void SetBannerRowValue(int index, string value, Repeater rpt, RepeaterItem item, string controlId, string sumRowId)
        {
            if (this._value == null)
            {
                Init(index, value);
                if (_total == 1)
                {
                    Literal ltr = (Literal)item.FindControl(controlId);
                    ltr.Text = " <td align=\"center\">" + _value + "</td>";
                }
            }
            else
            {
                if (index == _total - 1)
                {
                    if (value != this._value)
                    {
                        if (_rowCount > 1 && index > 0)
                        {
                            _rowCount++;
                            Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                            ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                            ltr = (Literal)item.FindControl(controlId);
                            ltr.Text = " <td align=\"center\" rowspan=\"1\">" + value + "</td>";
                            ltr = (Literal)rpt.Items[index - 1].FindControl(sumRowId);
                            ltr.Text = GetBannerData(rpt, _rowCount, index);
                        }
                        else
                        {
                            Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                            ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                            ltr = (Literal)item.FindControl(controlId);
                            ltr.Text = " <td align=\"center\">" + value + "</td>";
                        }
                    }
                    else
                    {
                        _rowCount++;
                        if (_rowCount > 1 && index > 0)
                        {
                            _rowCount++;
                            Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                            ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                            ltr = (Literal)item.FindControl(sumRowId); //last record
                            ltr.Text = GetBannerData(rpt, _rowCount, index, item);
                        }
                        else
                        {
                            Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                            ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        }
                    }
                }
                else
                    if (value != this._value)
                    {

                        if (_rowCount > 1 && index > 0)
                        {
                            _rowCount++;
                            Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                            ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                            ltr = (Literal)rpt.Items[index - 1].FindControl(sumRowId);
                            ltr.Text = GetBannerData(rpt, _rowCount, index);
                        }
                        else
                        {
                            Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                            ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + _value + "</td>";
                        }
                        Init(index, value);
                    }
                    else
                    {
                        _rowCount++;
                    }
            }
        }

        /// <summary>
        /// If a banner has more than one banner no, then each day need sum value up
        /// </summary>
        /// <param name="rpt"></param>
        /// <param name="_rowCount"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetBannerData(Repeater rpt, int _rowCount, int index, RepeaterItem item)
        {
            int pvCountI = 0;
            int pvCountE = 0;
            int pvCountS = 0;
            int pvCountAll = 0;
            int clickCountI = 0;
            int clickCountE = 0;
            int clickCountS = 0;
            int clickCountAll = 0;
            int uniqueCountI = 0;
            int uniqueCountE = 0;
            int uniqueCountS = 0;
            int uniqueCountAll = 0;
            for (int i = 0; i < _rowCount - 1; i++)
            {
                RepeaterItem itemDetail = null;
                if (item != null && i == _rowCount - 2)
                {
                    itemDetail = item;
                }
                else
                {
                    itemDetail = (RepeaterItem)rpt.Items[index - 1 - i];
                }
                TextBox txt = (TextBox)itemDetail.FindControl("txtPvCountI");
                pvCountI += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtPvCountE");
                pvCountE += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtPvCountS");
                pvCountS += Func.ParseInt(txt.Text);

                txt = (TextBox)itemDetail.FindControl("txtClickCountI");
                clickCountI += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtClickCountE");
                clickCountE += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtClickCountS");
                clickCountS += Func.ParseInt(txt.Text);

                txt = (TextBox)itemDetail.FindControl("txtUniqueCountI");
                uniqueCountI += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtUniqueCountE");
                uniqueCountE += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtUniqueCountS");
                uniqueCountS += Func.ParseInt(txt.Text);

                Label lblAll = (Label)itemDetail.FindControl("lblPvCountAll");
                pvCountAll += Func.ParseInt(lblAll.Text);
                lblAll = (Label)itemDetail.FindControl("lblClickCountAll");
                clickCountAll += Func.ParseInt(lblAll.Text);
                lblAll = (Label)itemDetail.FindControl("lblUniqueCountAll");
                uniqueCountAll += Func.ParseInt(lblAll.Text);

            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder("<tr class=\"TitleNoBold\">");
            sb.AppendFormat("<td>合計</td><td align=\"right\">{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td>", Func.FormatNumber(pvCountI), Func.FormatNumber(clickCountI), Func.FormatNumber(uniqueCountI));
            sb.AppendFormat("<td align=\"right\">{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td>", Func.FormatNumber(pvCountE), Func.FormatNumber(clickCountE), Func.FormatNumber(uniqueCountE));
            sb.AppendFormat("<td align=\"right\">{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td>", Func.FormatNumber(pvCountS), Func.FormatNumber(clickCountS), Func.FormatNumber(uniqueCountS));
            sb.AppendFormat("<td align=\"right\">{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td><td></td>", Func.FormatNumber(pvCountAll), Func.FormatNumber(clickCountAll), Func.FormatNumber(uniqueCountAll));
            sb.Append("</tr>");
            return sb.ToString();
        }

        /// <summary>
        /// If a banner has more than one banner no, then each day need sum value up
        /// </summary>
        /// <param name="rpt"></param>
        /// <param name="_rowCount"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetBannerData(Repeater rpt, int _rowCount, int index)
        {
            int pvCountI = 0;
            int pvCountE = 0;
            int pvCountS = 0;
            int pvCountAll = 0;
            int clickCountI = 0;
            int clickCountE = 0;
            int clickCountS = 0;
            int clickCountAll = 0;
            int uniqueCountI = 0;
            int uniqueCountE = 0;
            int uniqueCountS = 0;
            int uniqueCountAll = 0;
            for (int i = 0; i < _rowCount - 1; i++)
            {
                RepeaterItem itemDetail = (RepeaterItem)rpt.Items[index - 1 - i];
                TextBox txt = (TextBox)itemDetail.FindControl("txtPvCountI");
                pvCountI += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtPvCountE");
                pvCountE += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtPvCountS");
                pvCountS += Func.ParseInt(txt.Text);

                txt = (TextBox)itemDetail.FindControl("txtClickCountI");
                clickCountI += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtClickCountE");
                clickCountE += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtClickCountS");
                clickCountS += Func.ParseInt(txt.Text);

                txt = (TextBox)itemDetail.FindControl("txtUniqueCountI");
                uniqueCountI += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtUniqueCountE");
                uniqueCountE += Func.ParseInt(txt.Text);
                txt = (TextBox)itemDetail.FindControl("txtUniqueCountS");
                uniqueCountS += Func.ParseInt(txt.Text);

                Label lblAll = (Label)itemDetail.FindControl("lblPvCountAll");
                pvCountAll += Func.ParseInt(lblAll.Text);
                lblAll = (Label)itemDetail.FindControl("lblClickCountAll");
                clickCountAll += Func.ParseInt(lblAll.Text);
                lblAll = (Label)itemDetail.FindControl("lblUniqueCountAll");
                uniqueCountAll += Func.ParseInt(lblAll.Text);

            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder("<tr class=\"TitleNoBold\">");
            sb.AppendFormat("<td>合計</td><td align=\"right\">{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td>", Func.FormatNumber(pvCountI), Func.FormatNumber(clickCountI), Func.FormatNumber(uniqueCountI));
            sb.AppendFormat("<td align=\"right\">{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td>", Func.FormatNumber(pvCountE), Func.FormatNumber(clickCountE), Func.FormatNumber(uniqueCountE));
            sb.AppendFormat("<td align=\"right\">{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td>", Func.FormatNumber(pvCountS), Func.FormatNumber(clickCountS), Func.FormatNumber(uniqueCountS));
            sb.AppendFormat("<td align=\"right\">{0}</td><td align=\"right\">{1}</td><td align=\"right\">{2}</td><td></td>", Func.FormatNumber(pvCountAll), Func.FormatNumber(clickCountAll), Func.FormatNumber(uniqueCountAll));
            sb.Append("</tr>");
            return sb.ToString();
        }

        public void SetRowCheckBox(int index, string value, Repeater rpt, RepeaterItem item, string controlId, string checkBoxId)
        {
            if (this._value == null)
            {
                Init(index, value);
                if (_total == 1)
                {
                    Literal ltr = (Literal)item.FindControl(controlId);
                    ltr.Text = " <td align=\"center\">" + "";

                    CheckBox chk = (CheckBox)item.FindControl(checkBoxId);
                    chk.Visible = chk.Enabled;
                }
            }
            else
            {
                if (index == _total - 1)
                {
                    if (value != this._value)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + "";
                        CheckBox chk = (CheckBox)rpt.Items[_index].FindControl(checkBoxId);
                        chk.Visible = chk.Enabled;

                        ltr = (Literal)item.FindControl(controlId);
                        ltr.Text = " <td align=\"center\">" + "";
                        chk = (CheckBox)item.FindControl(checkBoxId);
                        chk.Visible = chk.Enabled;
                    }
                    else
                    {
                        _rowCount++;
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + "";

                        CheckBox chk = (CheckBox)rpt.Items[_index].FindControl(checkBoxId);
                        chk.Visible = chk.Enabled;
                    }
                }
                else
                    if (value != this._value)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + "";
                        CheckBox chk = (CheckBox)rpt.Items[_index].FindControl(checkBoxId);
                        chk.Visible = chk.Enabled;
                        Init(index, value);
                    }
                    else
                    {
                        _rowCount++;
                    }
            }
        }

        public void SetRowControl(bool otherBreak, int index, string value, Repeater rpt, RepeaterItem item, string controlId, string id)
        {
            if (this._value == null)
            {
                Init(index, value);
                if (_total == 1)
                {
                    Literal ltr = (Literal)item.FindControl(controlId);
                    ltr.Text = " <td align=\"center\">" + "";
                    ((Control)item.FindControl(id)).Visible = true;

                }
            }
            else
            {
                if (index == _total - 1)
                {
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + "";
                        ((Control)rpt.Items[_index].FindControl(id)).Visible = true;

                        ltr = (Literal)item.FindControl(controlId);
                        ltr.Text = " <td align=\"center\">" + "";
                        ((Control)item.FindControl(id)).Visible = true;
                    }
                    else
                    {
                        _rowCount++;
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + "";

                        ((Control)rpt.Items[_index].FindControl(id)).Visible = true;

                    }
                }
                else
                    if (value != this._value || otherBreak)
                    {
                        Literal ltr = (Literal)rpt.Items[_index].FindControl(controlId);
                        ltr.Text = " <td align=\"center\" " + (_rowCount > 1 ? " rowspan=" + _rowCount : "") + ">" + "";
                        ((Control)rpt.Items[_index].FindControl(id)).Visible = true;

                        Init(index, value);
                    }
                    else
                    {
                        _rowCount++;
                    }
            }
        }

    }
}
