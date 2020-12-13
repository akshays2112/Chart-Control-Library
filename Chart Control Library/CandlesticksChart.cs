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
using System.Data;

namespace ChartControlLibrary
{
    [AspNetHostingPermission(SecurityAction.Demand,
       Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class CandlesticksGraph : DataBoundControl
    {
        private string dataJSString;
        private string dataJSString2;
        public string Title { get; set; }
        public int XMarksWidth { get; set; }
        public int YMaxValue { get; set; }
        public int NumMarksY { get; set; }
        public int CandleBodyWidth { get; set; }
        public string CandelBodyColorStr { get; set; }
        public string CandelLineColorStr { get; set; }

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
            if (retrievedData != null)
            {
                if (retrievedData is DataView)
                {
                    DataSet ds = ((DataView)retrievedData).DataViewManager.DataSet;
                    dataJSString = "[";
                    for (int y = 0; y < ds.Tables[0].Rows.Count; y++)
                    {
                        DataRow dr = ds.Tables[0].Rows[y];
                        dataJSString += "[";
                        for (int x = 0; x < ds.Tables[0].Columns.Count; x++)
                        {
                            if (IsNumber(dr[x].ToString()))
                            {
                                dataJSString += dr[x].ToString() + ",";
                            }
                            else
                            {
                                dataJSString += "'" + dr[x].ToString() + "',";
                            }
                        }
                        dataJSString = dataJSString.Substring(0, dataJSString.Length - 1) + "],";
                    }
                    dataJSString = dataJSString.Substring(0, dataJSString.Length - 1) + "]";
                    dataJSString2 = "[";
                    for (int y = 0; y < ds.Tables[1].Rows.Count; y++)
                    {
                        DataRow dr = ds.Tables[1].Rows[y];
                        dataJSString2 += "[";
                        for (int x = 0; x < ds.Tables[1].Columns.Count; x++)
                        {
                            if (IsNumber(dr[x].ToString()))
                            {
                                dataJSString2 += dr[x].ToString() + ",";
                            }
                            else
                            {
                                dataJSString2 += "'" + dr[x].ToString() + "',";
                            }
                        }
                        dataJSString2 = dataJSString2.Substring(0, dataJSString2.Length - 1) + "],";
                    }
                    dataJSString2 = dataJSString2.Substring(0, dataJSString2.Length - 1) + "]";
                }
            }
        }


        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<canvas id=\"" + this.ID.ToString() + "\" width=\"" + this.Width.ToString() + "\" height=\"" + this.Height.ToString() +
                "\"><script language=\"javascript\" type=\"text/javascript\">drawCandlesticksGraph('" + this.ID.ToString() + "', " + dataJSString + "," +
                dataJSString2 + "," + XMarksWidth.ToString() + "," + YMaxValue.ToString() + "," + NumMarksY.ToString() + ",'" +
                this.Title.ToString() + "'," + CandleBodyWidth.ToString() + ",'" + CandelBodyColorStr + "','" + CandelLineColorStr + "');</script></canvas>");
        }

        private bool IsNumber(string str)
        {
            double Num;
            return double.TryParse(str, out Num);
        }
    }
}
