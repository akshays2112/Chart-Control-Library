using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace ChartControlLibrary
{
    public class DrillDownTable2 : Button
    {
        public object Tag;
        public string colnamesjsarray { get; set; }
        public string datajsarray { get; set; }
        public string numfixedcols { get; set; }

        public DrillDownTable2()
        {
        }

        public DrillDownTable2(string datajsarray, string numfixedcols)
        {
            this.datajsarray = datajsarray;
            this.numfixedcols = numfixedcols;
        }

        public DrillDownTable2(object tag, string datajsarray, string numfixedcols)
        {
            Tag = tag;
            this.datajsarray = datajsarray;
            this.numfixedcols = numfixedcols;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<table id=\"" + ID + "\" style=\"color:White;vertical-align:top;text-align:center;\"></table>" +
                        "<script language=\"javascript\" type=\"text/javascript\">" +
                        "insertColumnHeaders('" + ID + "', " + colnamesjsarray + ");" +
                        "tblcurrColTypes = tblcurrColTypes.concat(" + datajsarray + ");" +
                        "tblnumfixedcols.push([" + numfixedcols + ", '" + ID + "']);" +
                        "drawdrilldowntable2('" + ID + "');" +
                        "</script>");
        }
    }

}
