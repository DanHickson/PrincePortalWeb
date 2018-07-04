using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace PrincePortalWeb.Common
{
    public class UtilsString
    {
        private static Hashtable _specialChars;
        public static Hashtable SpecialChars
        {
            get
            {
                if (_specialChars == null)
                {
                    _specialChars = new Hashtable(100);
                    #region special chars
                    _specialChars.Add("<p>", Environment.NewLine);
                    _specialChars.Add("&Aacute;", "Á");
                    _specialChars.Add("&aacute;", "á");
                    _specialChars.Add("&Acirc;", "Â");
                    _specialChars.Add("&acirc;", "â");
                    _specialChars.Add("&acute;", "´");
                    _specialChars.Add("&AElig;", "Æ");
                    _specialChars.Add("&aelig;", "æ");
                    _specialChars.Add("&Agrave;", "À");
                    _specialChars.Add("&agrave;", "à");
                    _specialChars.Add("&amp;", "&");
                    _specialChars.Add("&Aring;", "Å");
                    _specialChars.Add("&aring;", "å");
                    _specialChars.Add("&Atilde;", "Ã");
                    _specialChars.Add("&atilde;", "ã");
                    _specialChars.Add("&Auml;", "Ä");
                    _specialChars.Add("&auml;", "ä");
                    _specialChars.Add("&brvbar;", "¦");
                    _specialChars.Add("&brkbar;", "¦");
                    _specialChars.Add("&Ccedil;", "Ç");
                    _specialChars.Add("&ccedil;", "ç");
                    _specialChars.Add("&cedil;", "¸");
                    _specialChars.Add("&cent;", "¢");
                    _specialChars.Add("&copy;", "©");
                    _specialChars.Add("&curren;", "¤");
                    _specialChars.Add("&deg;", "°");
                    _specialChars.Add("&divide;", "÷");
                    _specialChars.Add("&Eacute;", "É");
                    _specialChars.Add("&eacute;", "é");
                    _specialChars.Add("&Ecirc;", "Ê");
                    _specialChars.Add("&ecirc;", "ê");
                    _specialChars.Add("&Egrave;", "È");
                    _specialChars.Add("&egrave;", "è");
                    _specialChars.Add("&ETH;", "Ð");
                    _specialChars.Add("&eth;", "ð");
                    _specialChars.Add("&Euml;", "Ë");
                    _specialChars.Add("&euml;", "ë");
                    _specialChars.Add("&frac12;", "½");
                    _specialChars.Add("&frac14;", "¼");
                    _specialChars.Add("&frac34;", "¾");
                    _specialChars.Add("&gt;", ">");
                    _specialChars.Add("&Iacute;", "Í");
                    _specialChars.Add("&iacute;", "í");
                    _specialChars.Add("&Icirc;", "Î");
                    _specialChars.Add("&icirc;", "î");
                    _specialChars.Add("&iexcl;", "¡");
                    _specialChars.Add("&Igrave;", "Ì");
                    _specialChars.Add("&igrave;", "ì");
                    _specialChars.Add("&iquest;", "¿");
                    _specialChars.Add("&Iuml;", "Ï");
                    _specialChars.Add("&iuml;", "ï");
                    _specialChars.Add("&laquo;", "«");
                    _specialChars.Add("&lt;", "<");
                    _specialChars.Add("&macr;", "¯");
                    _specialChars.Add("&hibar;", "¯");
                    _specialChars.Add("&micro;", "µ");
                    _specialChars.Add("&middot;", "·");
                    _specialChars.Add("&nbsp;", " ");
                    _specialChars.Add("&not", "¬");
                    _specialChars.Add("&Ntilde;", "Ñ");
                    _specialChars.Add("&ntilde;", "ñ");
                    _specialChars.Add("&Oacute;", "Ó");
                    _specialChars.Add("&oacute;", "ó");
                    _specialChars.Add("&Ocirc;", "Ô");
                    _specialChars.Add("&ocirc;", "ô");
                    _specialChars.Add("&Ograve;", "Ò");
                    _specialChars.Add("&ograve;", "ò");
                    _specialChars.Add("&ordf;", "ª");
                    _specialChars.Add("&ordm;", "º");
                    _specialChars.Add("&Oslash;", "Ø");
                    _specialChars.Add("&oslash;", "ø");
                    _specialChars.Add("&Otilde;", "Õ");
                    _specialChars.Add("&otilde;", "õ");
                    _specialChars.Add("&Ouml;", "Ö");
                    _specialChars.Add("&ouml;", "ö");
                    _specialChars.Add("&para;", "¶");
                    _specialChars.Add("&plusmn;", "±");
                    _specialChars.Add("&pound;", "£");
                    _specialChars.Add("&quot;", "\"");
                    _specialChars.Add("&raquo;", "»");
                    _specialChars.Add("&reg;", "®");
                    _specialChars.Add("&sect;", "§");
                    _specialChars.Add("&shy;", "­");
                    _specialChars.Add("&sup1;", "¹");
                    _specialChars.Add("&sup2;", "²");
                    _specialChars.Add("&sup3;", "³");
                    _specialChars.Add("&szlig;", "ß");
                    _specialChars.Add("&THORN;", "Þ");
                    _specialChars.Add("&thorn;", "þ");
                    _specialChars.Add("&times;", "×");
                    _specialChars.Add("&Uacute;", "Ú");
                    _specialChars.Add("&uacute;", "ú");
                    _specialChars.Add("&Ucirc;", "Û");
                    _specialChars.Add("&ucirc;", "û");
                    _specialChars.Add("&Ugrave;", "Ù");
                    _specialChars.Add("&ugrave;", "ù");
                    _specialChars.Add("&uml;", "¨");
                    _specialChars.Add("&die;", "¨");
                    _specialChars.Add("&Uuml;", "Ü");
                    _specialChars.Add("&uuml;", "ü");
                    _specialChars.Add("&Yacute;", "Ý");
                    _specialChars.Add("&yacute;", "ý");
                    _specialChars.Add("&yen;", "¥");
                    _specialChars.Add("&yuml;", "ÿ");
                    #endregion
                }

                return _specialChars;
            }
        }


        string UppercaseFirst(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        public enum Tags
        {
            a,
            address,
            applet,
            area,
            basefont,
            bdo,
            bgsoundf,
            big,
            blockquote,
            blink,
            body,
            b,
            br,
            button,
            caption,
            center,
            Character,
            cite,
            code,
            col,
            colgroup,
            dd,
            dfn,
            del,
            dir,
            dl,
            div,
            doctype,
            dt,
            embed,
            em,
            fieldset,
            font,
            form,
            frame,
            frameset,
            Hx,
            head,
            hr,
            html,
            iframe,
            ilayer,
            img,
            input,
            ins,
            isindex,
            i,
            kbd,
            keygen,
            label,
            layer,
            legend,
            link,
            listing,
            li,
            map,
            marquee,
            menu,
            meta,
            multicol,
            nextid,
            nobr,
            noembed,
            noframe,
            nolayer,
            noscript,
            optgroup,
            option,
            ol,
            p,
            param,
            plaintext,
            pre,
            q,
            s,
            samp,
            script,
            select,
            small,
            sound,
            spacer,
            span,
            strike,
            strong,
            style,
            sub,
            sup,
            table,
            td,
            th,
            tr,
            tbody,
            textarea,
            tfoot,
            thead,
            title,
            tt,
            u,
            ul,
            var,
            wbr,
            xmp
        }


        public static string GetTagSearchRegExString(Tags tag)
        {
            return @"<[\s/]{0,2}" + tag + "([^>]*)>";
        }

        public static void TagStrip(ref string html, Tags tag, string replaceString)
        {
            Regex regex;

            try
            {
                //match between 0 and 2 space or "/" charecters, then img to end of tag
                String tags = GetTagSearchRegExString(tag);
                regex = new Regex(tags, RegexOptions.IgnoreCase);
                html = regex.Replace(html, replaceString);
            }
            catch (Exception)
            {
                //suck it up
            }
        }

        public static string TagStrip(string html, Tags tag, string replaceString)
        {
            TagStrip(ref html, tag, replaceString);
            return html;
        }

        //------------------------------------------------------------------------------------------
        public static void RemoveHTML(ref string text)
        {
            //do some PrincePortalWeb.Common replacements
            ReplaceSpecialChars(ref text);

            //remove all tags
            string cleanText = "";
            int myIndex = 0;
            int startTag = text.IndexOf("<", myIndex);
            while (startTag != -1)
            {
                string subText = text.Substring(myIndex + 1 - 1, startTag - myIndex);
                cleanText += subText;
                myIndex = startTag + 1;

                //skip over tag
                int endTag = text.IndexOf(">", myIndex);
                if (endTag == -1)
                {
                    return;
                }

                myIndex = endTag + 1;
                startTag = text.IndexOf("<", myIndex);
            }

            //gather remaining text
            if (myIndex < text.Length)
            {
                cleanText += text.Substring(text.Length - (text.Length - myIndex));
            }
            text = cleanText;
        }


        public static string RemoveHTML(string text)
        {
            RemoveHTML(ref text);
            return text;
        }

        public static string FormatAsText(string strHtml, bool removeHTMLTags)
        {
            string strText = strHtml;

            if (!string.IsNullOrEmpty(strText))
            {
                strText = strText.Replace("<br />", "\n");
                strText = strText.Replace("<BR />", "\n");
                strText = strText.Replace("<br>", "\n");
                strText = strText.Replace("<BR>", "\n");

                if (removeHTMLTags)
                {
                    strText = RemoveHTML(strText);
                }
            }

            return strText;
        }

        public static string FormatAsHtml(string strText)
        {
            string strHtml = strText;

            if (!string.IsNullOrEmpty(strHtml))
            {
                strHtml = strHtml.Replace("\r", "");
                strHtml = strHtml.Replace("\n", "<BR />");
            }

            return strHtml;
        }

        //------------------------------------------------------------------------------------------
        public static void ReplaceSpecialChars(ref string text)
        {
            foreach (DictionaryEntry myDE in SpecialChars)
            {
                if (text.IndexOf((string)myDE.Key) != -1)
                {
                    text = text.Replace((string)myDE.Key, (string)myDE.Value);
                }
            }
        }

        public static string ReplaceSpecialCharsByVal(string text)
        {
            ReplaceSpecialChars(ref text);
            return text;
        }

        //------------------------------------------------------------------------------------------
        protected static void RemoveLineBreaks(ref string text)
        {
            text = text.Trim();
            text = text.Replace(Environment.NewLine, " ");
            text = text.Replace("\n", " ");
            text = text.Replace("\r", " ");
        }

        //------------------------------------------------------------------------------------------
        public static void RemoveWhiteSpace(ref string text)
        {
            Regex regex = new Regex("\\s+");
            text = regex.Replace(text, " ");
        }

        /// <summary>
        /// Removes unneeded whites space (spaces and breaks)
        /// </summary>
        public string RemoveExtraWhiteSpace(string input)
        {
            // white space cleaning
            input = input.Replace("\n", " ");
            input = input.Replace("\r", " ");
            input = input.Replace("\t", " ");
            while (input.IndexOf("  ") != -1)
            {
                input = input.Replace("  ", " ");
            }
            return input;
        }

        public static string RemoveQuotationMarks(string text)
        {
            Regex regex = new Regex("[\"'']+");
            text = regex.Replace(text, "");

            return text;
        }

        private static string AltImageLink = "[IMAGE:<a href=\"{0}\">{1}</a>]";
        private static string AltImageString = "[IMAGE:{0}]";
        private static string LongDescLink = "[<a href=\"{0}\">D</a>]";
        public static string CreateImageReplaceHtml(string alt, string src, string longDesc)
        {
            string s = string.Empty;

            try
            {
                //if we have alt and src, display alt with link to src
                if (!Null.IsNull(src) && !Null.IsNull(alt))
                {
                    s += String.Format(AltImageLink, src, alt);
                }
                else if (!Null.IsNull(alt))
                {
                    //if only alt just display alt name
                    s += String.Format(AltImageString, alt);
                }

                //if longDesc provide dLink
                if (!Null.IsNull(longDesc))
                {
                    s += String.Format(LongDescLink, longDesc);
                }
            }
            catch (Exception)
            {
                //suck it up
            }

            return s;
        }

        /// <summary>
        /// Removes the local servername from A and IMG tags
        /// </summary>
        public static string RemoveServerNameAndApplicationPathFromUrl(string input)
        {
            RemoveServerNameFromUrl(ref input, HttpContext.Current.Request.ServerVariables["HTTP_HOST"]);

            //make sure that input is not just a slash (ie root)
            if (input.Length > 0 && !input.Equals("\\") && !!input.Equals("/"))
            {
                input = Regex.Replace(input, HttpContext.Current.Request.ApplicationPath, "", RegexOptions.IgnoreCase);
            }

            return input;
        }

        /// <summary>
        /// Removes the local servername from A and IMG tags
        /// </summary>
        public static string RemoveServerNameFromUrl(string input)
        {
            RemoveServerNameFromUrl(ref input, HttpContext.Current.Request.ServerVariables["HTTP_HOST"]);
            return input;
        }

        /// <summary>
        /// Removes the local servername from A and IMG tags
        /// </summary>
        public static void RemoveServerNameFromUrl(ref string input)
        {
            RemoveServerNameFromUrl(ref input, HttpContext.Current.Request.ServerVariables["HTTP_HOST"]);
        }


        /// <summary>
        /// Removes the local servername from A and IMG tags
        /// </summary>
        public static string RemoveServerNameFromUrl(string input, string servername)
        {
            RemoveServerNameFromUrl(ref input, servername);
            return input;
        }


        /// <summary>
        /// Removes the local servername from A and IMG tags
        /// </summary>
        public static void RemoveServerNameFromUrl(ref string input, string servername)
        {
            //System.Web.HttpContext.Current.Trace.Write("ServerName",servername);
            input = Regex.Replace(input, "http://" + servername, "", RegexOptions.IgnoreCase);
        }

        public static string ChopDirectoriesOffPath(string path, int numberToChop)
        {
            char[] dirSeperator1 = new char[2] { '\\', '/' };
            string newPath = path;

            for (int i = 0; i < numberToChop; i++)
            {
                int index = newPath.LastIndexOfAny(dirSeperator1);

                if (index <= -1)
                {
                    break;
                }
                newPath = newPath.Substring(0, index);
            }

            return newPath;
        }


        public static string ToLowercaseWithUnderscore(string s)
        {
            return s.ToLower().Replace(" ", "_");
        }

        public static void shortenStringInMiddle(string s)
        {
            int default_max_string_length = 25;

            shortenStringInMiddle(s, default_max_string_length);
        }

        public static string shortenStringInMiddle(string s, int maxLength)
        {
            if (s.Length > maxLength)
            {
                string newS = s.Substring(0, ((int)Math.Ceiling((double)maxLength / 2)));
                newS += " ... ";
                newS += s.Substring((s.Length - (((int)Math.Ceiling((double)maxLength / 2) - 2))));

                s = newS;
            }

            return s;
        }

        public static string ShortenStringAtEnd(object o, int max_string_length)
        {
            string s;

            if (o is string)
            {
                s = ShortenStringAtEnd((string)o, max_string_length);
            }
            else
            {
                s = string.Empty;
            }

            return s;
        }

        public static string ShortenStringAtEnd(string s)
        {
            int default_max_string_length = 25;

            return ShortenStringAtEnd(s, default_max_string_length);
        }

        public static string ShortenStringAtEnd(string s, int maxLength)
        {
            if (s.Length > maxLength)
            {
                string newS = s.Substring(0, ((int)Math.Ceiling((double)maxLength)));
                newS += "...";
                s = newS;
            }

            return s;
        }

        public static string FirstLetterDelimitedShorten(string s, char delimiter)
        {
            string[] sArray;
            string shortenedDelimitedString = string.Empty;

            if (s.Length > 0)
            {
                sArray = s.Split(delimiter);

                for (int i = 0; i < sArray.Length; i++)
                {
                    if (sArray[i].Length > 0)
                    {
                        if (i > 0)
                        {
                            shortenedDelimitedString += delimiter;
                        }

                        //if(sArray[i].LastIndexOf(delimiter) > -1)
                        //{
                        //	//add first letter
                        //	SelectedItem += sArray[i].Split(delimiter)[1][0];
                        //}
                        //else
                        //{
                        //add first letter
                        shortenedDelimitedString += sArray[i][0];
                        //}
                    }
                }
            }

            return shortenedDelimitedString;
        }

        public const char DEFAULT_DELIMITER = ',';
        public static string GetDelimitedString(string[] sArray)
        {
            return GetDelimitedString(sArray, DEFAULT_DELIMITER);
        }

        public static string GetDelimitedString(string[] sArray, char delimiter)
        {
            return GetDelimitedString(sArray, delimiter.ToString());
        }

        public static string GetDelimitedString(string[] sArray, string delimiter)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < sArray.Length; i++)
            {
                if (sb.Length > 0)
                {
                    sb.Append(delimiter);
                }
                sb.Append(sArray[i]);
            }

            return sb.ToString();
        }

        public static bool IsEmpty(string stringToValidate)
        {
            bool isBlank = false;

            if (string.IsNullOrEmpty(stringToValidate) || stringToValidate == "" || stringToValidate.Length <= 0)
            {
                isBlank = true;
            }

            return isBlank;
        }

        public static string ConvertToPacalCasing(string strToConvert)
        {
            //REVISE
            strToConvert = strToConvert.ToLowerInvariant();
            string firstLetter = strToConvert[0].ToString().ToUpper();
            strToConvert = strToConvert.Remove(0, 1);
            strToConvert = strToConvert.Insert(0, firstLetter);
            return strToConvert;
        }

        private static Regex FindWordsViaCasingRegex
        {
            get
            {
                if (_FindWordsViaCasingRegex == null)
                {
                    _FindWordsViaCasingRegex = new Regex(@"[A-Z][a-z0-9]*", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
                }
                return _FindWordsViaCasingRegex;
            }
        }
        private static Regex _FindWordsViaCasingRegex;

        public static string AutoSpaceOnCamelCase(string enumItemName)
        {
            string spacedName = string.Empty;
            MatchCollection objMatches = FindWordsViaCasingRegex.Matches(enumItemName);
            // 
            // build up the display string 
            // 
            foreach (Match objMatch in objMatches)
            {
                if (spacedName.Length > 0) spacedName += " ";
                spacedName += objMatch.Value;
            }

            return spacedName.Trim();
        }

        public static string RemoveUnderscores(string searchString)
        {
            return searchString.Replace("_", " ");
        }

        public static string AddUnderscores(string searchString)
        {
            return searchString.Replace(" ", "_");
        }

        public static string AddAddressLine(params string[] addressLine)
        {
            string addressSoFar = (addressLine.Length > 0) ? addressLine[0] : string.Empty;

            for (int i = 1; i < addressLine.Length; i++)
            {
                addressSoFar = AddAddressLine(addressSoFar, addressLine[i]);
            }

            return addressSoFar;
        }

        public static string AddAddressLine(string addressSoFar, string newAddressLine)
        {
            string s = addressSoFar ?? string.Empty;

            if (!string.IsNullOrEmpty(newAddressLine))
            {
                if (!string.IsNullOrEmpty(addressSoFar)
                    && !addressSoFar.TrimEnd().EndsWith(","))
                {
                    s += ADDRESS_LINE_SEPERATOR_DEFAULT;
                }
            }

            s += newAddressLine;

            return s;
        }
        public static string ADDRESS_LINE_SEPERATOR_DEFAULT = ", ";

        public static string FormatAddressAsHtml(string strText)
        {
            string strHtml = strText;

            if (!string.IsNullOrEmpty(strHtml))
            {
                strHtml = strHtml.Trim();
                strHtml = strHtml.Replace(",", "<BR />");
            }

            return strHtml;
        }

        public static bool DoesContainWhiteSpace(string slug)
        {
            //check for any whitespace
            return Regex.IsMatch(slug, @"^\s+$");
        }

        public static string RemoveSpaces(string str)
        {
            return str.Replace(" ", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("-", "");
        }

        public static string BuildDivTag(string cssClass, string innerHTML)
        {
            return BuildTag("div", cssClass, innerHTML);
        }

        private static string BuildTag(string tag, string cssClass, string innerHTML)
        {
            return "<" + tag + " class=\"" + cssClass + "\">" + innerHTML + "</" + tag + ">";
        }

        public static string EncodeJsString(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\'':
                        sb.Append("");
                        break;
                    case '.':
                        sb.Append("");
                        break;
                    case ':':
                        sb.Append("");
                        break;
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            sb.Append("\"");

            return sb.ToString();
        }
    }
}
