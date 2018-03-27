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
                PopulateCategoryDropDown();
                PopulateSupplierDropDown();
            }
        }

        private void PopulateSupplierDropDown()
        {
            InventoryPurchasingController controller = new InventoryPurchasingController();
            List<Supplier> suppliers = controller.ListAllSupplier();
            SupplierDropDown.DataSource = suppliers;
            SupplierDropDown.DataTextField = nameof(Supplier.CompanyName);
            SupplierDropDown.DataValueField = nameof(Supplier.SupplierID);
            SupplierDropDown.DataBind();
            // Let's insert a couple of options at the top of the drop-down
            SupplierDropDown.Items.Insert(0, new ListItem("[select a supplier]"));
            SupplierDropDown.Items.Insert(1, new ListItem("[no supplier]", "")); // because Product.SupplierID is nullable
        }

        private void PopulateCategoryDropDown()
        {
            var controller = new InventoryPurchasingController();
            var data = controller.ListAllCategories();
            CategoryDropDown.DataSource = data;
            CategoryDropDown.DataTextField = nameof(Category.CategoryName);
            CategoryDropDown.DataValueField = nameof(Category.CategoryID);
            CategoryDropDown.DataBind();
            // Let's insert a couple of options at the top of the drop-down
            CategoryDropDown.Items.Insert(0, new ListItem("[select a category]"));
            CategoryDropDown.Items.Insert(1, new ListItem("[no category]", ""));
            // The second inserted item is to accommodate a NULL value for the Product.CategoryID
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

            // Insert an item at the top to be our "placeholder" for the <select> tag
            CurrentProducts.Items.Insert(0, "[select a product]");
        }

        protected void ShowProductDetails_Click(object sender, EventArgs e)
        {
            if (CurrentProducts.SelectedIndex == 0) // first item in the drop-down
            {
                MessageLabel.Text = "Please select product before clicking Show Product Details.";
            }
            else
            {
                int productId;
                if (int.TryParse(CurrentProducts.SelectedValue, out productId))
                {
                    // Instantiate my BLL class and call a method to get the specific product
                    var controller = new InventoryPurchasingController();
                    Product item = controller.LookupProduct(productId);

                    // "Unpack" the data into the form's controls
                    ProductID.Text = item.ProductID.ToString(); // ProductID is an int
                    ProductName.Text = item.ProductName;
                    // Select the supplier/category for the found product
                    SupplierDropDown.SelectedValue = item.SupplierID.ToString();
                    CategoryDropDown.SelectedValue = item.CategoryID.ToString();
                }
            }
        }
    }
}