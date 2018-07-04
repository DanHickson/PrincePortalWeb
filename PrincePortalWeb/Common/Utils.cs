using System;
using System.Web.UI.WebControls;

namespace PrincePortalWeb.Common
{
    public class Utils
    {
        /// <summary>
        ///	 Checks to see if a string is an integer
        /// </summary>
        /// <return>Returns a the byte array </return>
        public static bool isInt(string s)
        {

            bool isIntBool = false;

            try
            {
                int.Parse(s);

                isIntBool = true;
            }
            catch (Exception)
            {
                //catch and continue
            }

            return isIntBool;

        }

        /// <summary>
        ///	 Checks to see if a string is an integer
        /// </summary>
        /// <return>Returns a the byte array </return>
        public static int SafeParseInt(string s)
        {
            int returnInt = Null.NullInteger;

            try
            {
                returnInt = int.Parse(s);
            }
            catch
            {
            }

            return returnInt;
        }

        public static int SafeParseInt(double d)
        {
            int returnInt = Null.NullInteger;

            try
            {
                returnInt = int.Parse(d.ToString());
            }
            catch
            {
            }

            return returnInt;
        }

        /// <summary>
        ///	 Checks to see if an object is a bool true or a string true
        /// </summary>
        /// <return>bool</return>
        public static bool SafeIsTrue(object o)
        {
            bool returnBool = false;

            try
            {
                if (o is bool)
                {
                    returnBool = ((bool)o);
                }
                else if (o is string)
                {
                    returnBool = (((string)o).ToLower().Equals("true"));
                }
            }
            catch (Exception)
            {
                //catch and continue
            }

            return returnBool;
        }

        /// <summary>
        ///	 Checks to see if an object is a bool true or a string true
        /// </summary>
        /// <return>bool</return>
        public static bool SafeParseBool(object o)
        {
            bool returnBool = false;

            try
            {
                if (o is bool)
                {
                    returnBool = ((bool)o);
                }
                else if (o is string)
                {
                    returnBool = bool.Parse((string)o);
                }
            }
            catch (Exception)
            {
                //catch and continue
            }

            return returnBool;
        }


        /// <summary>
        ///	 Checks to see if an object is a bool true or a string true
        /// </summary>
        /// <return>bool</return>
        public static bool SafeParseBool(int iVal)
        {
            bool returnBool = false;

            try
            {
                if (iVal == 1)
                {
                    returnBool = true;
                }
            }
            catch (Exception)
            {
                //catch and continue
            }

            return returnBool;
        }

        public static DateTime SafeParseDate(string date)
        {
            DateTime returnDate = Null.NullDate;

            try
            {
                returnDate = DateTime.Parse(date);
            }
            catch { }

            return returnDate;
        }

        public static float SafeParseFloat(string s)
        {
            float returnFloat = 0;

            try
            {
                returnFloat = float.Parse(s);
            }
            catch
            {
            }

            return returnFloat;
        }

        public static float PositiveToNegative(float value)
        {
            return value - (value*2);
        }

        public static float MakeValueNegativeIfChecked(float value, bool isChecked)
        {
            if (!isChecked)
            {
                value = PositiveToNegative(value);
            }

            return value;
        }

        public static string ConvertBoolToYesNo(bool bValue)
        {
            return bValue ? "Yes" : "No";
        }

        public static bool ConvertYesNoToBool(string sValue)
        {
            return sValue != "N";
        }

        public static bool ConvertNewRepeatToBool(string sValue)
        {
            return sValue != "New";
        }

        public static void AddSessionTimeout(Literal litSession)
        {
            //bool showSessionTimeout = SafeParseBool(UtilsApp.GetAppSetting("ShowSessionTimeout", "false"));
            //if (showSessionTimeout)
            //{
            //    litSession.Text = "SESSION timeout = " + System.Web.HttpContext.Current.Session.Timeout + " minutes";
            //}
        }
    }
}
