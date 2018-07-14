using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PrincePortalWeb.Models;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(PrincePortalWeb.Startup))]
namespace PrincePortalWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);


        }



        public class IdentityRoleHelper
        {


            internal static void DefaultAdminUserandRole(ApplicationDbContext context)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                //if admin doesnt exist and admin role doesnt exist then add to db

                if (!roleManager.RoleExists("Admin"))
                {
                    var roleresult = roleManager.Create(new IdentityRole("Admin"));


                }


                if (userManager.FindByName("Admin") == null)
                {
                    var user = new ApplicationUser() { UserName = "Admin", supplierId = 0, supplierName = "Admin" };



                    IdentityResult result = userManager.Create(user, "superPRINCE");
                    if (result.Succeeded)
                    {
                        var userid = user.Id;

                        //add to user role as all contact added will be user only i.e for supplier
                        userManager.AddToRole(userid, "Admin");
                        context.SaveChanges();

                    }

                }
            }
        }
    }
}
