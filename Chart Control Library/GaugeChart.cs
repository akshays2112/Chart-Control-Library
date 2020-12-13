/*
    Chart Control Library Copyright 2012
    Created by Akshay Srinivasan [akshay.srin@gmail.com] (Consultant with Tata Consultancy Services)
    This javascript code is provided as is with no warranty implied.
    Akshay Srinivasan and Tata Consultancy Services Ltd. are not liable or
    responsible for any consequence of using this code in your applications.
    You are free to use it and/or change it for both commercial and non-commercial
    applications as long as you give credit to Akshay Srinivasan the creator 
    of this code.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace ChartControlLibrary
{
    public class GaugeChart : Button
    {
        public string MinVal { get; set; }
        public string MaxVal { get; set; }
        public string LowMinRange { get; set; }
        public string LowMaxRange { get; set; }
        public string LowColorForRange { get; set; }
        public string MidMinRange { get; set; }
        public string MidMaxRange { get; set; }
        public string MidColorForRange { get; set; }
        public string HighMinRange { get; set; }
        public string HighMaxRange { get; set; }
        public string HighColorForRange { get; set; }
        public string MajorMarksEveryValIncrement { get; set; }
        public string NumMinorMarksWithinAMajorMark { get; set; }
        public string ActualValueToPointAt { get; set; }
        public new int Width { get; set; }
        public new int Height { get; set; }
        public string GraphTitle { get; set; }

        public GaugeChart()
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<canvas id=\"" + this.ID + "\" width=\"" + Width.ToString() + "\" height=\"" + Height.ToString() +
                "\"><script language=\"javascript\" type=\"text/javascript\">drawGauge('" + this.ID + "', [" + MinVal + ", " +
                MaxVal + ", [" + LowMinRange + ", " + LowMaxRange + ", '" + LowColorForRange + "'], [" + MidMinRange + ", " +
                MidMaxRange + ", '" + MidColorForRange + "'], [" + HighMinRange + ", " + HighMaxRange + ", '" + HighColorForRange + "'], " +
                MajorMarksEveryValIncrement + ", " + NumMinorMarksWithinAMajorMark + ", " + ActualValueToPointAt + "], '" +
                GraphTitle + "');</script></canvas>");
        }
    }
}
