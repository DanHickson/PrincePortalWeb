
using System;

namespace PrincePortalWeb.Common
{
    public class UtilsParams
    {
        public static int GetValue(string paramName)
        {
            int valueToReturn = Null.NullInteger;

            if (System.Web.HttpContext.Current.Request.Params[paramName] != null)
            {
                valueToReturn = Utils.SafeParseInt(System.Web.HttpContext.Current.Request.Params[paramName]);
            }

            return valueToReturn;
        }

        public static Guid GetValueAsGuid(string paramName)
        {
            Guid valueToReturn = Guid.Empty;

            if (System.Web.HttpContext.Current.Request.Params[paramName] != null)
            {
                valueToReturn  = new Guid(System.Web.HttpContext.Current.Request.Params[paramName]);
            }

            return valueToReturn;
        }
    }
}
