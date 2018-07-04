using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PrincePortalWeb.Models;
using PrincePortalWeb.Classes;
using System.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;

namespace PrincePortalWeb.Pages.Admin
{
    public partial class Register : Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //populate suppliers dropdown
                DataAccessObject da = new DataAccessObject();

                DataTable dt = da.GetSuppliers();

                SupplierListDropdown.DataSource = dt;
                SupplierListDropdown.DataTextField = "suppliername";
                SupplierListDropdown.DataValueField = "supplierid";
                SupplierListDropdown.DataBind();



            }


        }




        protected void CreateUser_Click(object sender, EventArgs e)


        {

            dvMessageError.Visible = false;
            dvMessageSuccess.Visible = false;
            string selectedSupplier = SupplierListDropdown.SelectedItem.Text.Trim();
            int selectedSupplierID = Convert.ToInt32(SupplierListDropdown.SelectedValue);


            if (string.IsNullOrEmpty(selectedSupplier))
            {

                dvMessageError.InnerText = "You must select a supplier";
            }
            else
            {

                //create user then send email invitiation
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = Name.Text, Email = Email.Text, supplierId = selectedSupplierID, supplierName = selectedSupplier, firstLogin = "Y",WebStatus="Invited To Portal",LastLogDateTime=DateTime.MinValue};


                string password = Membership.GeneratePassword(10, 2) + "6"+"Dh";

                IdentityResult result = manager.Create(user, password);

                if (result.Succeeded)
                {


                    var userid = user.Id;
                    ApplicationDbContext context = new ApplicationDbContext();
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


                    //add to user role as all contact added will be user only i.e for supplier
                    UserManager.AddToRole(userid, "User");
                    context.SaveChanges();

                    var sendok = Utils.Email_Without_Attachment(Email.Text.
                   Trim(), Global.GlobalVariables.FROMEMAILADDRESS, "Portal Login Created",
                   "Hello, a login has been created for you on the Prince Minerals Web Portal.<br><br>" +
                   " Please visit the link below to login using the credentials provided. Once logged" +
                   " in you will be required to change your password.<br><br><b>Username:</b>" + Name.Text.Trim() + "<br><b>Password:</b>" + password.Trim() +
                   "<br><br>Web Portal Link:<a href='" + Global.GlobalVariables.princeportaladdress.Trim() + "'></a>");

                    if (sendok)
                    {
                        dvMessageSuccess.Visible = true;
                        dvMessageSuccess.InnerText = "Invitation sent successfully and the user has been created on the system.";
                        dvMessageSuccess.InnerText = "Successfully sent invitation and created the user.";
                        Name.Text = "";
                        Email.Text = ""; ;
                    }
                    else
                    {
                        dvMessageError.Visible = true;
                        dvMessageError.InnerHtml = "Email failed to send - error at SMTP. However the user has been successfully created, please pass the following details to the user<br><br><b>User Name:</b>" + Name.Text.Trim() +
                            "<br><b>Password:</b>" + password.Trim();
                    }




                }
                else
                {
                    dvMessageError.Visible = true;
                    dvMessageError.InnerText = result.Errors.FirstOrDefault();
                }



            }
        }



    }
}