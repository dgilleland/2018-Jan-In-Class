using NorthwindSystem.BLL; // for the InventoryPurchasingController class
using NorthwindEntities; // for the Product, Category, and Supplier classes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Purchasing
{
    public partial class AddEditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) // on the initial GET of the page
            {
                PopulateProductDropDown();
            }
        }

        private void PopulateProductDropDown()
        {
            // Get the data from the BLL
            var controller = new InventoryPurchasingController();
            var data = controller.ListAllProducts();

            // Use the data in the DropDownList control
            CurrentProducts.DataSource = data;  // supplies all the data to the control
            CurrentProducts.DataTextField = nameof(Product.ProductName); // identify which property will be used to display text
            CurrentProducts.DataValueField = nameof(Product.ProductID);// identify which property will be associated with the value of the <option> element
            CurrentProducts.DataBind();
        }
    }
}