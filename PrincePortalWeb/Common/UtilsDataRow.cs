using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PrincePortalWeb.Common
{
    public class UtilsDataRow
    {
        public static DateTime GetDataRowAttrAsDateTime(DataRow dr, string attribute)
        {
            DateTime retVal = DateTime.MinValue;

            if (!String.IsNullOrEmpty(dr[attribute].ToString()))
            {
                if(!DateTime.TryParse(dr[attribute].ToString(), out retVal))
                {
                    //not a recognised date!
                }
            }

            return retVal;
        }

        public static string GetDataRowAttrAsString(DataRow dr, string attribute)
        {
            string retVal = String.Empty;

            if (!String.IsNullOrEmpty(dr[attribute].ToString()))
            {
                retVal = dr[attribute].ToString();
            }

            return retVal;
        }

        public static int GetDataRowAttrAsInt(DataRow dr, string attribute)
        {
            int retVal = 0;

            if (!String.IsNullOrEmpty(dr[attribute].ToString()))
            {
                retVal = Utils.SafeParseInt(dr[attribute].ToString());
            }

            return retVal;
        }

        public static float GetDataRowAttrAsFloat(DataRow dr, string attribute)
        {
            float retVal = 0;

            if (!String.IsNullOrEmpty(dr[attribute].ToString()))
            {
                retVal = Utils.SafeParseFloat(dr[attribute].ToString());
            }

            return retVal;
        }
    }
}
