using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrincePortalWeb.Classes;

namespace PrincePortalWeb.Pages.Admin
{
    public partial class SupplierEdit : System.Web.UI.Page
    {
        private BusinessLogic BL;

        public SupplierEdit()
        {
            //construct here
            BL = new BusinessLogic();

        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // asign data to grid 

                DataTable suppliersDT = new BusinessLogic().GetSupplierListFilterOrNoFilter("");
                griddataBind(suppliersDT);

            }


        }

        protected void Search_Click(object sender, EventArgs e)
        {

            string suppliername = searchText.Text.Trim().ToUpper();

            DataTable dt = BL.GetSupplierListFilterOrNoFilter(suppliername);
            griddataBind(dt);


        }


        private void griddataBind(DataTable dataTableForGrid)
        {
                GridView1.DataSource = dataTableForGrid;
                GridView1.DataBind();
            
        }
    }
}