using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web;

namespace PrincePortalWeb.Common
{
    public class QueryString : NameValueCollection
    {
        private string document;
        public string Document
        {
            get
            {
                return document;
            }
        }

        public QueryString()
        {
        }

        public QueryString(NameValueCollection clone)
            : base(clone)
        {
        }

        public static QueryString FromCurrent()
        {
            return FromUrl(HttpContext.Current.Request.Url.AbsoluteUri);
        }

        public static QueryString FromUrl(string url)
        {
            string[] parts = url.Split("?".ToCharArray());
            QueryString qs = new QueryString {document = parts[0]};

            if (parts.Length == 1)
                return qs;

            string[] keys = parts[1].Split("&".ToCharArray());
            foreach (string key in keys)
            {
                string[] part = key.Split("=".ToCharArray());
                if (part.Length == 1)
                    qs.Add(part[0], "");
                qs.Add(part[0], part[1]);
            }

            return qs;
        }

        public void ClearAllExcept(string except)
        {
            ClearAllExcept(new[] { except });
        }

        public void ClearAllExcept(string[] except)
        {
            ArrayList toRemove = new ArrayList();
            foreach (string s in AllKeys)
            {
                foreach (string e in except)
                {
                    if (s.ToLower() == e.ToLower())
                        if (!toRemove.Contains(s))
                            toRemove.Add(s);
                }
            }

            foreach (string s in toRemove)
                Remove(s);
        }

        public override void Add(string name, string value)
        {
            if (this[name] != null)
                this[name] = value;
            else
                base.Add(name, value);
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool includeUrl)
        {
            string[] parts = new string[Count];
            string[] keys = AllKeys;
            for (int i = 0; i < keys.Length; i++)
                parts[i] = keys[i] + "=" + HttpUtility.UrlEncode(this[keys[i]]);
            string url = String.Join("&", parts);
            if ((url != null || url != String.Empty) && !url.StartsWith("?"))
                url = "?" + url;
            if (includeUrl)
                url = document + url;
            return url;
        }
    }
}
