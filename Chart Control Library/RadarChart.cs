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
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChartControlLibrary
{
    [AspNetHostingPermission(SecurityAction.Demand,
       Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class RadarChart : DataBoundControl
    {
        private string dataJSString;
        public string Title { get; set; }
        public int MaxValue { get; set; }
        public string ColorString { get; set; }
        public int NumMarks { get; set; }
        
        protected override void PerformSelect()
        {
            if (!IsBoundUsingDataSourceID)
            {
                this.OnDataBinding(EventArgs.Empty);
            }
            GetData().Select(CreateDataSourceSelectArguments(),
                this.OnDataSourceViewSelectCallback);
            RequiresDataBinding = false;
            MarkAsDataBound();
            OnDataBound(EventArgs.Empty);
        }

        private void OnDataSourceViewSelectCallback(IEnumerable retrievedData)
        {
            if (IsBoundUsingDataSourceID)
            {
                OnDataBinding(EventArgs.Empty);
            }
            PerformDataBinding(retrievedData);
        }

        protected override void PerformDataBinding(IEnumerable retrievedData)
        {
            base.PerformDataBinding(retrievedData);
            dataJSString = "[";
            if (retrievedData != null)
            {
                foreach (object dataItem in retrievedData)
                {
                    PropertyDescriptorCollection props =
                            TypeDescriptor.GetProperties(dataItem);
                    for (int x=0;x<props.Count;x++)
                    {
                        if (null != props[x].GetValue(dataItem))
                        {
                            if (IsNumber(props[x].GetValue(dataItem).ToString()))
                            {
                                dataJSString += props[x].GetValue(dataItem).ToString() + ",";
                            }
                            else
                            {
                                dataJSString += "'" + props[x].GetValue(dataItem).ToString() + "',";
                            }
                        }
                    }
                }
            }
            dataJSString = dataJSString.Substring(0, dataJSString.Length - 1) + "]";
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<canvas id=\"" + this.ID.ToString() + "\" width=\"" + this.Width.ToString() + "\" height=\"" + this.Height.ToString() +
                "\"><script language=\"javascript\" type=\"text/javascript\">drawRadarGraph('" + this.ID.ToString() + "', " + dataJSString +
                "," + MaxValue.ToString() + ",'" + ColorString + "'," + NumMarks.ToString() + ",'" + this.Title.ToString() +
                "');</script></canvas>");
        }

        private bool IsNumber(string str)
        {
            double Num;
            return double.TryParse(str, out Num);
        }
    }
}
