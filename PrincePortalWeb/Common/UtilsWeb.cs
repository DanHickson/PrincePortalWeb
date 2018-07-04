using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Common;

namespace PrincePortalWeb.Common
{
    public class UtilsWeb
    {
        protected const string STR_DEFAULT_POPUP_OPTIONS = "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=800,height=560";
        protected const string STR_SMALL_POPUP_OPTIONS = "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=604,height=500";
        protected const string SCRIPT_QUE_IDENTIFIER = "scriptQue";

        /// <summary>
        /// Gets the current instance of the HeadScriptManager.
        /// </summary>
        public static Page Page
        {
            get
            {

                Page _page = HttpContext.Current.CurrentHandler as Page;

                if (_page == null)
                {
                    throw new NullReferenceException("The page is null.");
                }

                return _page;
            }
        }

        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>The base URL.</value>
        public static string BaseURL
        {
            get
            {
                if (_baseURL == null)
                {
                    _baseURL = HttpContext.Current.Request.ApplicationPath;

                    //if baseURL is not at at root ("/dir") - add a "/" to keep slash pattern consistent (eg /DWF => /DWF/) 
                    if (!_baseURL.EndsWith("/"))
                    {
                        _baseURL += "/";
                    }
                }
                return _baseURL;
            }
            set { _baseURL = value; }
        }
        private static string _baseURL;

        /// <summary>
        /// Gets or sets the absolute base URL.
        /// </summary>
        /// <value>The absolute base URL.</value>
        public static string AbsoluteBaseUrl
        {
            get
            {
                if (_absoluteBaseUrl == null)
                {
                    try
                    {
                        string Port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                        if (Port == null || Port == "80" || Port == "443")
                            Port = "";
                        else
                            Port = ":" + Port;

                        string Protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                        if (Protocol == null || Protocol == "0")
                            Protocol = "http://";
                        else
                            Protocol = "https://";

                        // *** Figure out the base Url which points at the application's 
                        _absoluteBaseUrl = Protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] +
                                           Port + HttpContext.Current.Request.ApplicationPath + "/";
                    }
                    catch (Exception)
                    {
                    }

                    return _absoluteBaseUrl;
                }
                return _absoluteBaseUrl;
            }
            set { _absoluteBaseUrl = value; }
        }
        private static string _absoluteBaseUrl;


        /// <summary>
        /// Gets or sets the script que.
        /// </summary>
        /// <value>The script que.</value>
        private static Queue ScriptQue
        {
            get
            {
                if (HttpContext.Current.Items[SCRIPT_QUE_IDENTIFIER] == null)
                {
                    HttpContext.Current.Items[SCRIPT_QUE_IDENTIFIER] = new Queue();
                }
                return (Queue)HttpContext.Current.Items[SCRIPT_QUE_IDENTIFIER];
            }
        }

        /// <summary>
        /// Registers and inserts a style sheet in the head of a template based page
        /// </summary>
        /// <param name="name">a unique name for the style sheet</param>
        /// <param name="src">href of the style sheet</param>
        public static void RegisterCss(string name, string src)
        {
            //register with page
            RegisterClientScript(name, GetAtImportLinkString(src), false);
        }

        public static void RegisterClientScriptReference(string name, string scriptSource)
        {
            string scriptString = string.Format(@"<script src=""{0}""></script>", scriptSource);

            RegisterClientScript(name, scriptString, false);
        }

        public static void RegisterClientScript(string name, string script, bool addScriptTags)
        {
            string scriptString = (addScriptTags) ? string.Format(@"<script>{0}</script>", script) : script;

            if (Page == null)
            {
                AddClientScriptToRenderQue(name, script, false);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), name, scriptString);
            }
        }

        public static void AddClientScriptToRenderQue(string name, string script, bool addScriptTags)
        {
            string scriptString = (addScriptTags) ? string.Format(@"<script>{0}</script>", script) : script;

            ScriptQue.Enqueue(scriptString);
        }

        public static void RenderQuedScript()
        {
            if (Page != null)
            {
                for (int i = 0; i < ScriptQue.Count; i++)
                {
                    //dupes already got filteres when put in, so name can be anything unique
                    Page.ClientScript.RegisterClientScriptBlock(typeof(string), i.ToString(), (string)ScriptQue.Dequeue());
                }
            }
        }

        public static void PopupAlert(string message)
        {
            string jsPopupString = string.Format(@"alert(unescape('{0}').replace(/\+/g,' '));", HttpUtility.UrlEncode(message).Replace("'", ""));

            RegisterClientScript("PopupAlert", jsPopupString, true);
        }

        public static void SetFocus(Control control)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\r\n<script language='JavaScript'>\r\n");
            sb.Append("<!--\r\n");
            sb.Append("function SetFocus()\r\n");
            sb.Append("{\r\n");
            sb.Append("\tdocument.");

            Control p = control.Parent;
            while (!(p is HtmlForm)) p = p.Parent;

            sb.Append(p.ClientID);
            sb.Append("['");
            sb.Append(control.UniqueID);
            sb.Append("'].focus();\r\n");
            sb.Append("}\r\n");
            sb.Append("window.onload = SetFocus;\r\n");
            sb.Append("// -->\r\n");
            sb.Append("</script>");

            control.Page.RegisterClientScriptBlock("SetFocus", sb.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrl"></param>
        public static void AddCheckDeleteJS(WebControl ctrl)
        {
            AddCheckMessageJS(ctrl.Attributes, Const.UserMessages.CONFIRM_DELETE);
        }

        /// <summary>
        /// Adds the check message JS.
        /// </summary>
        /// <param name="attributeCollection">The attribute collection.</param>
        /// <param name="chekMessage">The chek message.</param>
        public static void AddCheckMessageJS(AttributeCollection attributeCollection, string chekMessage)
        {
            if (attributeCollection != null)
            {
                attributeCollection.Add("onclick", "return confirm('" + chekMessage + "');");
            }
        }

        /// <summary>
        /// Adds the confirm message JS.
        /// </summary>
        /// <param name="jsEvent">The js event.</param>
        /// <param name="attributeCollection">The attribute collection.</param>
        /// <param name="chekMessage">The chek message.</param>
        public static void AddConfirmMessageJS(string jsEvent, AttributeCollection attributeCollection, string chekMessage)
        {
            if (attributeCollection != null)
            {
                attributeCollection.Add(jsEvent, "return confirm('" + chekMessage + "');");
            }
        }

        /// <summary>
        /// Closes the client window.
        /// </summary>
        /// <param name="page">The page.</param>
        public static void CloseClientWindow(Page page)
        {
            RegisterClientScript("CloseClientWindow", "window.close();", true);
        }

        public static void RefreshOpener(Page page)
        {
            RegisterClientScript("RefreshOpener", "opener.history.go(0);", true);
        }

        public static string AddStdQueryString(string url)
        {
            return url;
        }

        public static string AddCurrentQueryString(string url)
        {
            if (HttpContext.Current.Request.QueryString.Count > 0)
            {
                for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
                {
                    url += GetNextUrlParameterAppendCharacter(url) + HttpContext.Current.Request.QueryString.GetKey(i) + "=" + HttpContext.Current.Request.QueryString.Get(i);
                }

                return url;
            }
            return url;
        }

        public static void AddItemToSession(string itemName, string itemValue)
        {
            HttpContext.Current.Session[itemName] = itemValue;
        }

        public static string GetItemFromSession(string itemName)
        {
            return HttpContext.Current.Session[itemName].ToString();
        }

        public static string AddItemToQueryString(string url, string itemName, string itemValue)
        {
            if (url == null)
            {
                url = string.Empty;
            }

            url += GetNextUrlParameterAppendCharacter(url);
            url += itemName + "=" + itemValue;

            return url;
        }

        /// <summary>
        /// Establishes if any parameters are already appended to url
        /// and returns ? or & accordingly
        /// </summary>
        /// <param name="url">The current url</param>
        public static char GetNextUrlParameterAppendCharacter(string url)
        {
            char appendChar = url.IndexOf('?') <= -1 ? '?' : '&';

            return appendChar;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="url"></param>
        public static void CreateClientPopup(WebControl ctrl, string url)
        {
            if (ctrl != null)
            {
                ctrl.Attributes.Add("onclick", CreatePopupWindowString(url) + "; return false;");
            }
        }

        public static void CreateSmallClientPopup(WebControl ctrl, string url, string options)
        {
            if (ctrl != null)
            {
                ctrl.Attributes.Add("onclick", CreatePopupWindowString(url, options) + "; return false;");
            }
        }


        /// <summary>
        /// Overloaded Method to popup an html window
        /// </summary>
        /// <param name="url">The url to navigate to</param>
        public static string CreatePopupWindowString(string url)
        {
            return CreatePopupWindowString(url, STR_DEFAULT_POPUP_OPTIONS);
        }

        /// <summary>
        /// Overloaded Method to popup an html window
        /// </summary>
        /// <param name="url">The url to navigate to</param>
        public static string CreateSmallPopupWindowString(string url)
        {
            return CreatePopupWindowString(url, STR_SMALL_POPUP_OPTIONS);
        }

        /// <summary>
        /// Overloaded Method to popup an html window
        /// </summary>
        /// <param name="url">The url to navigate to</param>
        /// <param name="options"></param>
        public static string CreatePopupWindowString(string url, string options)
        {
            string scriptString = null;

            //add standard query parameters
            url = AddStdQueryString(url);

            //generate popup javascript
            //extra {} to stop navigation if script in href & allow return false: http://west-wind.com/WebLog/posts/9899.aspx
            scriptString += "{window.open('";
            scriptString += url;
            scriptString += "'";

            //add blank window name
            scriptString += ", ''";

            //add options'
            scriptString += ", '";
            scriptString += options;

            scriptString += "'); }";
            //return false;}";


            return scriptString;
        }

        /// <summary>
        /// Overloaded Method to popup an html window
        /// </summary>
        /// <param name="url">The url to navigate to</param>
        /// <param name="preventHistoryWityhPostback"></param>
        public static void PopupWindowWithGetParameters(string url, bool preventHistoryWityhPostback)
        {
            PopupWindowWithGetParameters(url, STR_DEFAULT_POPUP_OPTIONS, preventHistoryWityhPostback);
        }

        /// <summary>
        /// Overloaded Method to popup an html window
        /// </summary>
        /// <param name="url">The url to navigate to</param>
        /// <param name="preventHistoryWithPostback"></param>
        public static void PopupSmallWindowWithGetParameters(string url, bool preventHistoryWithPostback)
        {
            PopupWindowWithGetParameters(url, STR_SMALL_POPUP_OPTIONS, preventHistoryWithPostback);
        }

        /// <summary>
        /// Overloaded Method to popup an html window
        /// </summary>
        /// <param name="url">The url to navigate to</param>
        /// <param name="options"></param>
        /// <param name="preventRepopWithHistoryBack"></param>
        public static void PopupWindowWithGetParameters(string url, string options, bool preventRepopWithHistoryBack)
        {
            RegisterClientScript("popupWindowWithGetParama", (CreatePopupWindowString(url, options)), true);
            if (preventRepopWithHistoryBack)
            {
                RegisterClientScript("preventRepopWithHistoryBack", "history.go(-1);", true);
            }
        }

        public static HtmlGenericControl GetLinkControl(string src)
        {
            HtmlGenericControl objLink;

            try
            {
                objLink = new HtmlGenericControl("LINK");
                objLink.Attributes["rel"] = "stylesheet";
                objLink.Attributes["type"] = "text/css";
                objLink.Attributes["href"] = src;
            }
            catch (Exception)
            {
                objLink = new HtmlGenericControl();
            }

            return objLink;
        }

        public static string GetAtImportLinkString(string src)
        {
            string s = string.Empty;

            try
            {
                s = "<style type='text/css'>@import '" + src + "';</style>";
            }
            catch (Exception)
            {
            }

            return s;
        }

        public static HtmlGenericControl GetJavascriptIncludeControl(string src)
        {
            HtmlGenericControl objLink;

            try
            {
                objLink = new HtmlGenericControl("SCRIPT");
                objLink.Attributes["type"] = "text/javascript";
                objLink.Attributes["src"] = src;
            }
            catch (Exception)
            {
                objLink = new HtmlGenericControl();
            }

            return objLink;
        }


        public static string TildaParse(string url)
        {
            string returnUrl = HttpContext.Current != null ? url.Replace("~", HttpContext.Current.Request.ApplicationPath) : url;

            //return returnUrl;
            return returnUrl.Replace("//", "/");
        }

        public static String MakeURLFromRoot(string relativeUrl)
        {
            string return_string;

            if (relativeUrl[0] == '~')
            {
                return_string = TildaParse(relativeUrl);
            }
            else
            {
                return_string = BaseURL + relativeUrl;
            }

            return return_string.Replace("//", "/");
        }

        public static String MakeURLFromAdminRoot(string relativeUrl)
        {
            string return_string = BaseURL + "Admin/" + relativeUrl;

            return return_string.Replace("//", "/");
        }

        public static string GetURLRelativeToApplicationPath()
        {
            string s = HttpContext.Current.Request.CurrentExecutionFilePath.ToLower().Replace(HttpContext.Current.Request.ApplicationPath.ToLower(), "");

            return s;
        }

        public static string MakeLinkExternal(string link)
        {
            if (link.IndexOf("http://") == -1)
            {
                link = "http://" + link;
            }

            return link;
        }

        public static string MakeAbsoluteUrl(string relativeUrl)
        {   
            string return_string = AbsoluteBaseUrl + TildaParse(relativeUrl);

            return return_string;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Line1"></param>
        /// <param name="Line2"></param>
        /// <remarks>
        /// - If one word, output first line
        /// - If two words output one word on each line
        /// - If more than two words, output words on a line until less than or equal to 12 characters on line 1, with the rest on line 2
        /// </remarks>
        public static void SplitStringForTab(string Source, ref string Line1, ref string Line2)
        {
            string[] words = Source.Split(' ');
            if (words.Length == 1)
            {
                Line1 = Source;
                Line2 = "";
            }
            else if (words.Length == 2)
            {
                Line1 = words[0];
                Line2 = words[1];
            }
            else
            {
                Line1 = words[0];
                for (int i = 1; i < words.Length; i += 1)
                {
                    if (Line1.Length + 1 + words[i].Length > 12)
                    {
                        Line2 += words[i] + " ";
                    }
                    else
                    {
                        Line1 += " " + words[i];
                    }
                }
            }
        }

        public static string GetTextFromTextControls(Control parentControl)
        {
            //create new sb
            StringBuilder sb = new StringBuilder();

            GetTextFromTextControls(parentControl, ref sb);

            return sb.ToString();
        }

        private static void GetTextFromTextControls(Control parentControl, ref StringBuilder sb)
        {
            //add text
            for (int i = 0; i < parentControl.Controls.Count; i++)
            {
                if (parentControl.Controls[i] is LiteralControl)
                {
                    sb.Append(((LiteralControl)parentControl.Controls[i]).Text);
                }
                if (parentControl.Controls[i] is Literal)
                {
                    sb.Append(((Literal)parentControl.Controls[i]).Text);
                }
                if (parentControl.Controls[i] is PlaceHolder)
                {
                    GetTextFromTextControls(parentControl.Controls[i], ref sb);
                }
            }
        }

        public static string GetAbsoluteImagePath(string relativePath, string imageFileNameAndExtension)
        {
            return AbsoluteBaseUrl + relativePath + imageFileNameAndExtension;
        }

        public static String GetBaseURL()
        {
            string return_string = HttpContext.Current.Request.ApplicationPath;

            //if baseURL is not at at root ("/dir") - add a "/" to keep slash pattern consistent (eg /EmPowerDemo => /DWF/) 
            if (!return_string.EndsWith("/"))
                return_string += "/";

            return return_string;
        }
    }
}
