using System;
using System.Diagnostics;

namespace PrincePortalWeb.Common
{
    public class DebugUtils
    {
        public static string GetStackTrace()
        {
            string s = Null.NullString;
            StackFrame sf;

            StackTrace st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                sf = st.GetFrame(i);
                s += "<br>";
                s += " File: " + sf.GetFileName();
                s += "<br>";
                s += " Line: " + sf.GetFileLineNumber();
                s += "<br>";
                s += " Method: " + sf.GetMethod();
                s += "<br>";
            }

            return s;
        }

        public static string GetInnerExceptionMessages(Exception ex)
        {
            string messages = string.Empty;

            //iterate through inner exception to find the root cause of the exception
            while (ex.InnerException != null)
            {
                //append exception
                messages += "--------------------------------";
                messages += "The following InnerException reported: " + ex.InnerException;

                //set to inner exception
                ex = ex.InnerException;
            }

            return messages;
        }
    }
}
