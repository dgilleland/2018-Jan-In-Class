using NorthwindEntities;
using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Purchasing
{
    public partial class AddEditSupplier : System.Web.UI.Page
    {
        #region Event Handlers"
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BindSupplierDropDown();
                    BindCountryDropDown();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                    MessagePanel.CssClass = "alert alert-warning alert-dismissible";
                    MessagePanel.Visible = true;
                }
            }
        }

        protected void LookupSupplier_Click(object sender, System.EventArgs e)
        {
            try
            {
                int supplierId;
                if (int.TryParse(SupplierDropDownList.SelectedValue, out supplierId) && supplierId >= 0)
                {
                    Supplier item;
                    InventoryPurchasingController Controller = new InventoryPurchasingController();
                    item = Controller.LookupSupplier(supplierId);

                    CurrentSupplier.Text = item.SupplierID.ToString();
                    CompanyName.Text = item.CompanyName;
                    ContactName.Text = item.ContactName;
                    ContactTitle.Text = item.ContactTitle;
                    Address.Text = item.Address;
                    City.Text = item.City;
                    Region.Text = item.Region;
                    PostalCode.Text = item.PostalCode;
                    CountryDropDown.SelectedValue = item.Country;
                    Phone.Text = item.Phone;
                    Fax.Text = item.Fax;
                    HomePageTitle.Text = item.HomePageTitle;
                    WebAddress.Text = item.HomePageUrl;
                }
                else
                {
                    MessageLabel.Text = "Please Select a supplier before clicking Lookup";
                    MessagePanel.CssClass = "alert alert-info alert-dismissible";
                    MessagePanel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }

        protected void AddSupplier_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    // 1) Add the product as a new item
                    // Get the Country name
                    string country = null;
                    if (CountryDropDown.SelectedIndex > 0)
                    {
                        country = CountryDropDown.SelectedValue;
                    }

                    Supplier item = new Supplier();
                    item.CompanyName = CompanyName.Text;
                    item.ContactName = ContactName.Text;
                    item.ContactTitle = ContactTitle.Text;
                    item.Address = Address.Text;
                    item.City = City.Text;
                    item.Region = Region.Text;
                    item.PostalCode = PostalCode.Text;
                    item.Country = country;
                    item.Phone = Phone.Text;
                    item.Fax = Fax.Text;
                    item.HomePageTitle = HomePageTitle.Text;
                    item.HomePageUrl = WebAddress.Text;


                    InventoryPurchasingController Controller = new InventoryPurchasingController();
                    int NewSupplierId = Controller.AddSupplier(item);

                    // 2) Update the form and give feedback to the user
                    BindSupplierDropDown();
                    SupplierDropDownList.SelectedValue = NewSupplierId.ToString();
                    CurrentSupplier.Text = NewSupplierId.ToString();
                    MessageLabel.Text = "Supplier added";
                    MessagePanel.CssClass = "alert alert-success alert-dismissible";
                    MessagePanel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }

        protected void UpdateSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                int supplierId;
                if (int.TryParse(CurrentSupplier.Text, out supplierId))
                {
                    if (IsValid)
                    {
                        // 1) Add the product as a new item
                        // Get the Country name
                        string country = null;
                        if (CountryDropDown.SelectedIndex > 0)
                        {
                            country = CountryDropDown.SelectedValue;
                        }

                        Supplier item = new Supplier();
                        item.SupplierID = supplierId;
                        item.CompanyName = CompanyName.Text;
                        item.ContactName = ContactName.Text;
                        item.ContactTitle = ContactTitle.Text;
                        item.Address = Address.Text;
                        item.City = City.Text;
                        item.Region = Region.Text;
                        item.PostalCode = PostalCode.Text;
                        item.Country = country;
                        item.Phone = Phone.Text;
                        item.Fax = Fax.Text;
                        item.HomePageTitle = HomePageTitle.Text;
                        item.HomePageUrl = WebAddress.Text;


                        InventoryPurchasingController Controller = new InventoryPurchasingController();
                        Controller.UpdateSupplier(item);

                        // 2) Update the form and give feedback to the user
                        BindSupplierDropDown();
                        ClearForm_Click(sender, e);
                        MessageLabel.Text = "Supplier updated";
                        MessagePanel.CssClass = "alert alert-success alert-dismissible";
                        MessagePanel.Visible = true;
                    }
                }
                else
                {
                    MessageLabel.Text = "Please lookup a supplier before attempting to update";
                    MessagePanel.CssClass = "alert alert-warning alert-dismissible";
                    MessagePanel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }

        protected void DeleteSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                int supplierId;
                if (int.TryParse(CurrentSupplier.Text, out supplierId))
                {
                    if (IsValid)
                    {

                        InventoryPurchasingController Controller = new InventoryPurchasingController();
                        Controller.DeleteSupplier(supplierId);

                        // 2) Update the form and give feedback to the user
                        BindSupplierDropDown();
                        SupplierDropDownList.SelectedIndex = -1;
                        MessageLabel.Text = "Supplier removed";
                        MessagePanel.CssClass = "alert alert-success alert-dismissible";
                        MessagePanel.Visible = true;
                    }
                }
                else
                {
                    MessageLabel.Text = "Please lookup a supplier before attempting to update";
                    MessagePanel.CssClass = "alert alert-warning alert-dismissible";
                    MessagePanel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }

        protected void ClearForm_Click(object sender, EventArgs e)
        {
            SupplierDropDownList.SelectedIndex = -1;
            CountryDropDown.SelectedIndex = -1;
            CurrentSupplier.Text = "";
            CompanyName.Text = "";
            ContactName.Text = "";
            ContactTitle.Text = "";
            Address.Text = "";
            City.Text = "";
            Region.Text = "";
            PostalCode.Text = "";
            Phone.Text = "";
            Fax.Text = "";
            HomePageTitle.Text = "";
            WebAddress.Text = "";

        }
        #endregion

        #region Private Methods"
        private void BindSupplierDropDown()
        {
            InventoryPurchasingController controller = new InventoryPurchasingController();
            SupplierDropDownList.DataSource = controller.ListAllSuppliers();
            SupplierDropDownList.DataTextField = "CompanyName";
            SupplierDropDownList.DataValueField = "SupplierID";
            SupplierDropDownList.DataBind();
            SupplierDropDownList.Items.Insert(0, new ListItem("[Select a supplier]", "-1"));
        }

        private void BindCountryDropDown()
        {
            InventoryPurchasingController controller = new InventoryPurchasingController();
            CountryDropDown.DataSource = controller.ListAllCountries();
            CountryDropDown.DataTextField = "Country";
            CountryDropDown.DataValueField = "Country";
            CountryDropDown.DataBind();
            CountryDropDown.Items.Insert(0, new ListItem("[Select a Country]", "-1"));
            CountryDropDown.Items.Insert(1, new ListItem("[no Country]", ""));
        }

        private void ValidateCurrentSupplierID()
        {
            int temp;
            if (!int.TryParse(CurrentSupplier.Text, out temp))
                MessageLabel.Text = "You can only update/delete an existing Supplier";
            else
                if (!CurrentSupplier.Text.Equals(SupplierDropDownList.SelectedValue))
                MessageLabel.Text = "The supplier selected in the drop-down is not the same as the supplier details in the form; it is not clear which one you want to modify.<br />Please Select the supplier you want to modify before clicking Update or Delete.";
        }
        #endregion
    }
}