using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PrincePortalWeb.Classes;
using PrincePortalWeb.Models;

namespace PrincePortalWeb.Pages.Admin
{
    public partial class EditUsers : System.Web.UI.Page
    {

        private int supplierid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {


            supplierid = Convert.ToInt32(Request.QueryString["supplierid"]);



        }



        public IQueryable<ApplicationUser> GridView1_GetData()
        {

            ApplicationDbContext context = new ApplicationDbContext();
            return (from s in context.Users
                    orderby s.UserName
                    where s.supplierId == supplierid
                    select s).AsQueryable();

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridView1_UpdateItem(string id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())

            {
                PrincePortalWeb.Models.ApplicationUser item = null;
                item = context.Users.Find(id);
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("User was not found!"));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    context.SaveChanges();

                }

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridView1_DeleteItem(string id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())

            {
                PrincePortalWeb.Models.ApplicationUser item = null;
                item = context.Users.Find(id);
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("User was not found!"));
                    return;
                }

                TryUpdateModel(item);
                if (ModelState.IsValid)

                {
                    context.Users.Remove(item);
                    context.SaveChanges();

                }


            }
        }

        protected void newuserbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/admin/register.aspx?supplierid=" + supplierid.ToString());


        }





        protected void passwordreset(string id)
        {

            id = id.Trim();

            string password = Membership.GeneratePassword(10, 2) + "6" + "Dh";
            IdentityResult bob;
            bob = null;
            //IdentityResult.Failed();
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            var item = userManager.FindById(id);

            string email = item.Email.Trim();
           

            item.PasswordHash = userManager.PasswordHasher.HashPassword(password);
           
            bob = userManager.Update(item);
            if (bob.Succeeded)
            {

            }
            else
            {
                dvMessageError.Visible = true;
                dvMessageError.InnerText = "Failed to add new password to user." + bob.Errors.First();

            }







            if (bob.Succeeded)
            {

                if (string.IsNullOrEmpty(email))
                {
                    dvMessageError.Visible = true;
                    dvMessageError.InnerText = "No email address entered for this user, the password for this user is:" + password.Trim();

                }

                else
                {

                    var sendok = Utils.Email_Without_Attachment(email.
                   Trim(), Global.GlobalVariables.FROMEMAILADDRESS, "Portal Password Reset",
                   "Hello, your password has been reset successfully.<br><br>" +
                   " Please visit the link below to login using the new credentials provided." +
                   ".<br><br><b>Username:</b>" + item.UserName.Trim() + "<br><b>Password:</b>" + password.Trim() +
                   "<br><br>Web Portal Link:<a href='" + Global.GlobalVariables.princeportaladdress.Trim() + "'></a>");

                    if (sendok)
                    {
                        dvMessageSuccess.Visible = true;
                        dvMessageSuccess.InnerText = "User has been emailed a new password.";
                    }
                    else
                    {
                        dvMessageError.Visible = true;
                        dvMessageError.InnerHtml = "Email failed to send - error at SMTP. However the users password has been reset to:" +
                            "<br><b>Password:</b>" + password.Trim();
                    }



                }


            }


        }

        protected void passwordresetbtn_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "passwordreset")
            {
                string id = e.CommandArgument.ToString();
                passwordreset(id);
            }

        }
    }
}