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
            if (!IsPostBack) // on the initial GET of the page
            {
                PopulateProductDropDown();
                PopulateCategoryDropDown();
                PopulateSupplierDropDown();
            }
        }

        private void PopulateSupplierDropDown()
        {
            InventoryPurchasingController controller = new InventoryPurchasingController();
            List<Supplier> suppliers = controller.ListAllSuppliers();
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
                    try
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
                        // Other values that are displayed in text boxes
                        QtyPerUnit.Text = item.QuantityPerUnit;
                        UnitPrice.Text = item.UnitPrice.ToString();
                        InStock.Text = item.UnitsInStock.ToString();
                        OnOrder.Text = item.UnitsOnOrder.ToString();
                        ReorderLevel.Text = item.ReorderLevel.ToString();
                        // Set the checkbox for the found product's Discontinued flag
                        Discontinued.Checked = item.Discontinued;

                        // Update the message
                        MessageLabel.Text = "Product details found.";

                    }
                    catch (Exception ex)
                    {
                        MessageLabel.Text = ex.Message;
                    }
                }
            }
        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            if (IsValid) // Do a server-side check on the Validation Controls
            {
                try
                {
                    // Create a Product object and fill it with the data from the form
                    Product item = BuildProductFromUserInput();

                    // Send the Product object to the BLL
                    var controller = new InventoryPurchasingController();
                    int newItemId = controller.AddProduct(item);

                    // Give the user some feedback
                    PopulateProductDropDown(); // because we have a new product for the list
                    CurrentProducts.SelectedValue = newItemId.ToString();
                    ProductID.Text = newItemId.ToString();

                    MessageLabel.Text = "Product Added";
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }


        private Product BuildProductFromUserInput()
        {
            Product item = new Product();

            // Populate with data from the form controls
            item.ProductName = ProductName.Text.Trim();

            int temp;
            if (int.TryParse(SupplierDropDown.SelectedValue, out temp)) // If I can convert the Selected value to an int...
                item.SupplierID = temp;
            if (int.TryParse(CategoryDropDown.SelectedValue, out temp))
                item.CategoryID = temp;

            // Nullable quantity per unit from a TextBox
            // - a couple of things to note: It's not quite sufficient to just see if the text is null or empty.
            //   It's possible that the user entered in only spaces, and we want to strip out leading and trailing
            //   spaces from their input.
            if (!string.IsNullOrWhiteSpace(QtyPerUnit.Text))
                item.QuantityPerUnit = QtyPerUnit.Text.Trim(); // remove leading/trailing white space

            // Get the unit price
            decimal money;
            if (decimal.TryParse(UnitPrice.Text, out money))
                item.UnitPrice = money;

            // Get the instock/onorder/reorder values
            short smallNumber;
            if (short.TryParse(InStock.Text, out smallNumber))
                item.UnitsInStock = smallNumber;
            if (short.TryParse(OnOrder.Text, out smallNumber))
                item.UnitsOnOrder = smallNumber;
            if (short.TryParse(ReorderLevel.Text, out smallNumber))
                item.ReorderLevel = smallNumber;

            // Discontinued is a simple true/false (not nullable)
            item.Discontinued = Discontinued.Checked;

            return item;
        }



        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            // TODO: do any validation
            int id;
            if (IsValid && int.TryParse(ProductID.Text, out id)) // If there is a Product ID....
            {
                try
                {
                    // Create a Product object and fill it in with data from the form
                    Product item = BuildProductFromUserInput(); // Everything but the ProductID
                    item.ProductID = id;

                    // Send the Product to the BLL
                    var controller = new InventoryPurchasingController();
                    controller.UpdateProduct(item);

                    // Give the user some feedback
                    PopulateProductDropDown(); // in case the product name changed
                    CurrentProducts.SelectedValue = id.ToString();
                    MessageLabel.Text = item.ProductName + " was sucessfully updated.";
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
            else
            {
                MessageLabel.Text = "Please lookup a product before clicking the Update button.";
            }
        }

        protected void DeleteProduct_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(ProductID.Text, out id)) // If there is a Product ID
            {
                try
                {
                    // Send the Product ID to the BLL
                    var controller = new InventoryPurchasingController();
                    controller.DeleteProduct(id);

                    // Give the user some feedback
                    PopulateProductDropDown(); // Because the product has now been removed
                    CurrentProducts.SelectedIndex = 0;
                    ShowMessage("Product was successfully removed.", AlertStyle.success);
                    ClearForm_Click(sender, e); // Pass off the work to an existing click handler
                }
                catch (Exception ex)
                {
                    ShowFullExceptionMessage(ex);
                }
            }
            else
            {
                ShowMessage("Please lookup a product before clicking the Delete button.", AlertStyle.info);
            }
        }

        protected void ClearForm_Click(object sender, EventArgs e)
        {
            // Reset all the controls on the form
            CurrentProducts.SelectedIndex = 0;
            SupplierDropDown.SelectedIndex = 0;
            CategoryDropDown.SelectedIndex = 0;
            ProductID.Text = "";
            ProductName.Text = "";
            QtyPerUnit.Text = "";
            UnitPrice.Text = "";
            InStock.Text = "";
            OnOrder.Text = "";
            ReorderLevel.Text = "";
            Discontinued.Checked = false;
        }

        // Enumeration values based off of Bootstrap styles for alerts.
        public enum AlertStyle { success, info, warning, danger }

        private void ShowMessage(string message, AlertStyle alertStyle)
        {
            MessageLabel.Text = message;
            MessagePanel.CssClass = $"alert alert-{alertStyle} alert-dismissible";
            MessagePanel.Visible = true;
        }

        private void ShowFullExceptionMessage(Exception ex)
        {
            string message = $"ERROR: {ex.Message}";
            // get the inner exception....
            Exception inner = ex;
            // this next statement drills down on the details of the exception
            while (inner.InnerException != null)
                inner = inner.InnerException;
            if (inner != ex)
                message += $"<blockquote>{inner.Message}</blockquote>";
            ShowMessage(message, AlertStyle.danger);
        }
    }
}