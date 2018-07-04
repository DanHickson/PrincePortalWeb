using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PrincePortalWeb.Classes;

namespace PrincePortalWeb
{
    public partial class SiteMaster : MasterPage

    {
        private BusinessLogic BL;


        public SiteMaster()
        {
            //construct here
            BL = new BusinessLogic();

        }

        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {


            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            //get id
            var finduserid = Context.User.Identity.GetUserId();

            BL.updateUserlastseen(finduserid);
            //now set last log in datetime

            // DateTime ukDateTimeFormatToUSA = DateTime.Parse(DateTime.Now.ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-us"));

            if (!IsPostBack)
            {
                var userrole = Context.GetOwinContext().Authentication.User.IsInRole("Admin");

                //get user
                var applicationUser = manager.FindById(finduserid);

                //check if first login i.e Y
                string isFirstLogin = "N";

                try
                {
                    isFirstLogin = applicationUser.firstLogin.Trim().ToUpper();
                }
                catch (NullReferenceException)
                {
                    isFirstLogin = "N";
                }

                if (userrole)
                {
                    AdminNavpanel.Visible = true;
                    UserNavpanel.Visible = false;
                    LoopThroughUserSetStatus();

                }
                else
                {
                    UserNavpanel.Visible = true;
                    AdminNavpanel.Visible = false;
                }
            }

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);


            var id = Context.User.Identity.GetUserId();
            BL.SetUserWebstatus(id, 1);

        }


        public void LoopThroughUserSetStatus()
        {
            // get a list of users


            DataTable userList = BL.getallUsersByWebstatus("Logged In");


            foreach (DataRow row in userList.Rows)
            {

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                //get last seen time
                DateTime lastOnline = Convert.ToDateTime(row["lastlogdatetime"]);
                string email = row["email"].ToString().Trim();



                var rowuserID = manager.FindByEmail(email).Id;

                //get token timeout
                DateTime currentDatetime = DateTime.Now;

                int time = (currentDatetime - lastOnline).Minutes;

                //if inactive for 20 mins or more change status
                if (time > 20)
                {
                    BL.SetUserWebstatus(rowuserID, 1);


                }

            }


            //now update the suppliers status
            DataTable supplierList = BL.GetSupplierListFilterByWebStatus("Logged In");

            foreach (DataRow row in supplierList.Rows)
            {

                int supp_id = Convert.ToInt32(row["supplierid"]);

                DataTable dt = BL.getallUsersByWebstatusandSupplierID("Logged In", supp_id);

                int count = dt.Rows.Count;

                if (count == 0)
                {
                    BL.SetSupplierWebstatus(supp_id, 1);
                }

            }

        }

    }

}