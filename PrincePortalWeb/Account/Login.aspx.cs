using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PrincePortalWeb.Models;
using PrincePortalWeb.Common;
using System.Threading.Tasks;
using PrincePortalWeb.Classes;

namespace PrincePortalWeb.Account
{
    public partial class Login : Page
    {

        private BusinessLogic BL;

        public Login()
        {
            //construct here
            BL = new BusinessLogic();

        }




        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                var result = signinManager.PasswordSignIn(textUsername.Value, textPassword.Value, false, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:

                        var finduserid = manager.FindByName(textUsername.Value).Id;

                        var isadmin = manager.IsInRole(finduserid, "Admin");

                        var currentUser = manager.FindById(finduserid);

                        int currentSupplierID = currentUser.supplierId;


                        currentUser.WebStatus = "Logged In";

                        manager.Update(currentUser);

                        //set the supplier as live
                        BL.SetSupplierWebstatus(currentSupplierID,2);

                        if (isadmin)
                        {
                            Response.Redirect("~/pages/admin/adminland.aspx");
                        }
                        else
                        {
                            // check for first login
                            var empty = UtilsString.IsEmpty(currentUser.firstLogin.Trim().ToUpper());

                            if (!empty)
                            {
                                if (currentUser.firstLogin.Trim().ToUpper() == "Y")
                                {



                                    Response.Redirect("~/account/managepassword.aspx");
                                }
                                else
                                {
                                    Response.Redirect("~/pages/userland.aspx");

                                }
                            }

                        }


                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.Failure:
                    default:
                        dvMessage.InnerText = "Invalid Username and/or Password";
                        dvMessage.Visible = true;
                        break;
                }
            }
        }


    }
}