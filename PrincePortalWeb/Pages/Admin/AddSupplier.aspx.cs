using PrincePortalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrincePortalWeb.Pages.Admin
{
    public partial class AddSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //use object of type customer to get value from formview 
        // the value will be bound to customer automaticlly
        // or you can use the method TryUpdateMedel to populate your model
        public void FormView1_InsertItem(supplier supplier)
        {
            using (SupplierDBModel context = new SupplierDBModel())

            {
                //Customer customer=new Customer()
                //TryUpdateModel(customer)
                if (ModelState.IsValid)
                {
                    supplier.webstatus = "Invited To Portal";
                    context.suppliers.Add(supplier);

                    context.SaveChanges();
                   
                }
            }
        }

        protected void addSupplierForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/pages/admin/supplieredit.aspx");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/admin/supplieredit.aspx");
        }
    }
}