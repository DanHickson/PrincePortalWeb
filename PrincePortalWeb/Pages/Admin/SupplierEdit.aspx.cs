using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrincePortalWeb.Classes;
using PrincePortalWeb.Models;
using static PrincePortalWeb.Models.SupplierDBModel;

namespace PrincePortalWeb.Pages.Admin
{
    public partial class SupplierEdit : System.Web.UI.Page
    {   


        protected void Page_Load(object sender, EventArgs e)
        {
    
         

        }
         



        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<supplier> GridView1_GetData()
        {

            SupplierDBModel context = new SupplierDBModel();
            return (from s in context.suppliers
                    select s).AsQueryable();

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridView1_DeleteItem(int supplierid)
        {
            using (SupplierDBModel context = new SupplierDBModel())

            {
                PrincePortalWeb.Models.supplier item = null;
                item = context.suppliers.Find(supplierid);
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", supplierid));
                    return;
                }

                TryUpdateModel(item);
                if (ModelState.IsValid)

                {
                    context.suppliers.Remove(item);
                    context.SaveChanges();

                }


            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridView1_UpdateItem(int supplierid)
        {
            using (SupplierDBModel context = new SupplierDBModel())

            {
                PrincePortalWeb.Models.supplier item = null;
                item = context.suppliers.Find(supplierid);
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", supplierid));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    context.SaveChanges();

                }

            }
        }

        protected void newsupplierbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/admin/addsupplier.aspx");
        }   

        
    }
}
    
