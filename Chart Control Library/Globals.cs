﻿/*
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChartControlLibrary
{
    public class Globals
    {
        static Random r = new Random(DateTime.Now.Millisecond);

        public static bool CheckIfContainsIEnumerableData(IEnumerable retrievedData)
        {
            IEnumerator re = retrievedData.GetEnumerator();
            re.MoveNext();
            IEnumerable x = re.Current as IEnumerable;
            if (x != null)
                return true;
            return false;
        }

        public static string ConvertTo2Decimals(string s)
        {
            return String.Format("{0:0.00}", Convert.ToDouble(s));
        }

        public static string RandomHexColorString()
        {
            string hexColor = "#";
            int redcomp = r.Next(0, 255);
            if (redcomp < 16)
                hexColor += "0" + String.Format("{0:X}", redcomp);
            else
                hexColor += String.Format("{0:X}", redcomp);
            int greencomp = r.Next(0, 255);
            if (greencomp < 16)
                hexColor += "0" + String.Format("{0:X}", greencomp);
            else
                hexColor += String.Format("{0:X}", greencomp);
            int bluecomp = r.Next(0, 255);
            if (bluecomp < 16)
                hexColor += "0" + String.Format("{0:X}", bluecomp);
            else
                hexColor += String.Format("{0:X}", bluecomp);
            return hexColor;
        }
    }
}
