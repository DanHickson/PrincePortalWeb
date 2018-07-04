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
using System.Data;

namespace PrincePortalWeb.Classes
{
    public class BusinessLogic
    {
        private DataAccessObject databasefunc;


        public BusinessLogic()
        {
            //construct here
            databasefunc = new DataAccessObject();

        }


        public void GetUserCredentials(string usernamestring, string passwordstring, out string url)
        {
            url = "";
            string isAdmin = "N";
            string userName = "";
            string firstTimeLogin = "Y";
            string userEmail = "";


            DataTable data = databasefunc.ValidateUser(usernamestring, passwordstring);

            int usercount = data.Rows.Count;


            if (usercount > 0)
            {

                //get user info
                foreach (DataRow row in data.Rows)
                {
                    userName = row["username"].ToString().Trim().ToUpper();
                    isAdmin = row["isadmin"].ToString().Trim().ToUpper();

                    if (row["lastlogindate"] != System.DBNull.Value)
                    {

                        firstTimeLogin = "N";

                    }
                    else
                    {
                        firstTimeLogin = "Y";

                    }
                    userEmail = row["email"].ToString().Trim();

                }


                //if admin then admin dashboard, if non admin then check for first login, if first login prompt for password change otherwise take to user dashboard
                if (isAdmin.Trim().ToUpper() == "Y")
                {

                    url = "~/pages/admin/admindashboard.aspx";

                }
                else
                {
                    if (firstTimeLogin == "N")
                    {
                        url = "~/pages/userdashboard.aspx";

                    }
                    else
                    {

                        url = "~/pages/changepassword.aspx";

                    }

                }

            }


        }

        public DataTable GetSupplierListFilterOrNoFilter(string supplierName)
        {

            DataTable dt = new DataTable();

            if (!string.IsNullOrEmpty(supplierName))
            {                //use filter
                dt = databasefunc.GetSuppliersWithFilter(supplierName.Trim().ToUpper());





            }
            else
            {
                //no filter
                dt = databasefunc.GetSuppliers();

            }



            return dt;



        }

        public DataTable GetSupplierListFilterByWebStatus(string webstatus)
        {

            DataTable dt = new DataTable();

            dt = databasefunc.GetSuppliersWithFilterByWebStatus(webstatus.Trim());

            return dt;
        }



        //<method>
        //Update the users webstatus field, pass userid and numeric
        // 1 - Live
        // 2 - Logged In
        // 3 - Invitation Sent
        //<method>
        //public IdentityResult SetUserWebstatus(string userID,int Status)
        //{
        //    var man = new ApplicationUserManager(ApplicationUserManagerd);


        //    string statusname = "";

        //    var user = applicationUserManager.FindById(userID);

        //    switch (Status)
        //    {
        //        case 1:
        //            statusname = "Live";

        //            break;
        //        case 2:
        //            statusname = "Logged In";
        //            break;

        //        case 3:

        //            statusname = "Invitation Sent";

        //            break;

        //        default:
        //            statusname = "";
        //            break;
        //    }

        //    user.webStatus = statusname;

        //    var result=applicationUserManager.Update(user);
        //    return result;
        //}




        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessageItem"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="userID">The current user id.</param>
        /// <param name="Status">1 is Live, 2 Is Logged in, 3 is invite sent</param>


        public void SetUserWebstatus(string userID, int Status)
        {



            string statusname = "";



            switch (Status)
            {
                case 1:
                    statusname = "Live";

                    break;
                case 2:
                    statusname = "Logged In";
                    break;

                case 3:

                    statusname = "Invitation Sent";

                    break;

                default:
                    statusname = "";
                    break;
            }


            databasefunc.UpdateUserWebSatus(userID, statusname);


        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessageItem"/> class.
        /// </summary>  
        /// <param name="supplierID">The current supplier id.</param>
        /// <param name="Status">1 is Live, 2 Is Logged in, 3 is invite sent</param>
        public void SetSupplierWebstatus(int supplierID, int Status)
        {



            string statusname = "";



            switch (Status)
            {
                case 1:
                    statusname = "Live";

                    break;
                case 2:
                    statusname = "Logged In";
                    break;

                case 3:

                    statusname = "Invitation Sent";

                    break;

                default:
                    statusname = "";
                    break;
            }

            databasefunc.UpdateSupplierrWebSatus(supplierID, statusname);


        }

        public DataTable getallUsers()
        {

            DataTable dt = new DataTable();


            dt = databasefunc.GetAllUsers();


            return dt;
        }

        public DataTable getallUsersByWebstatus(string webstatus)
        {

            DataTable dt = new DataTable();


            dt = databasefunc.GetAllUsersByWebStatus(webstatus.Trim());


            return dt;
        }

        public DataTable getallUsersByWebstatusandSupplierID(string webstatus, int supplierid)
        {

            DataTable dt = new DataTable();


            dt = databasefunc.GetAllUsersByWebStatusandSupplierID(webstatus.Trim(),supplierid);


            return dt;
        }

        public void updateUserlastseen(string userid)
        {
            databasefunc.UpdateUserLastSeen(userid);


        }

    }
}