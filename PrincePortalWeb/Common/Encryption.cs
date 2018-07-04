using System;
using System.Globalization;
using System.Text;

namespace PrincePortalWeb.Common
{
    public class Encryption
    {

        private Encryption()
        {
        }

        public static QueryString EncryptQueryString(QueryString queryString)
        {
            QueryString newQueryString = new QueryString();
            foreach (string name in queryString)
            {
                string nm = name;
                string val = queryString[name];
                newQueryString.Add(Hex(nm), Hex(val));
            }
            return newQueryString;
        }

        public static QueryString DecryptQueryString(QueryString queryString)
        {
            QueryString newQueryString = new QueryString();
            foreach (string name in queryString)
            {
                string nm = DeHex(name);
                string val = DeHex(queryString[name]);
                newQueryString.Add(nm, val);
            }
            return newQueryString;
        }

        public static string DeHex(string hexstring)
        {
            StringBuilder sb = new StringBuilder(hexstring.Length / 2);
            for (int i = 0; i <= hexstring.Length - 1; i = i + 2)
            {
                sb.Append((char)int.Parse(hexstring.Substring(i, 2), NumberStyles.HexNumber));
            }
            return sb.ToString();
        }

        public static string Hex(string sData)
        {
            StringBuilder sb = new StringBuilder(sData.Length * 2);
            for (int i = 0; i < sData.Length; i++)
            {
                if ((sData.Length - (i + 1)) > 0)
                {
                    string temp = sData.Substring(i, 2);
                    if (temp == @"\n") ;
                    else if (temp == @"\b") ;
                    else if (temp == @"\r") ;
                    else if (temp == @"\c") ;
                    else if (temp == @"\\") ;
                    else if (temp == @"\0") ;
                    else if (temp == @"\t") ;
                    else
                    {
                        sb.Append(String.Format("{0:X2}", (int)(sData.ToCharArray())[i]));
                        i--;
                    }
                }
                else
                {
                    sb.Append(String.Format("{0:X2}", (int)(sData.ToCharArray())[i]));
                }
                i++;
            }
            return sb.ToString();
        }
    }
}
