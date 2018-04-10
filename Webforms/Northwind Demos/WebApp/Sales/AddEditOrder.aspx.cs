using NorthwindEntities;
using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Sales
{
    public partial class AddEditOrder : System.Web.UI.Page
    {
        #region Page Setup
        protected void Page_Load(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
            if (!IsPostBack)
            {
                PopulateCustomerDropDowns();
                PopulateEmployeeDropDown();
                PopulateShipperDropDown();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            OrderSelectionDiv.Visible = CurrentCustomersDropDown.SelectedIndex > 0;
        }

        private void PopulateCustomerDropDowns()
        {
            var controller = new SalesController();
            List<Customer> customers = controller.ListAllCustomers();
            // Populates two drop-down lists....

            // This drop-down is for narrowing the selection of orders
            CurrentCustomersDropDown.DataSource = customers;
            CurrentCustomersDropDown.DataTextField = nameof(Customer.CompanyName);
            CurrentCustomersDropDown.DataValueField = nameof(Customer.CustomerID);
            CurrentCustomersDropDown.DataBind();
            CurrentCustomersDropDown.Items.Insert(0, "[Select a customer]");

            // This drop-down is "informational" - about the customer for the selected Order.
            CustomerDropDown.DataSource = customers;
            CustomerDropDown.DataTextField = nameof(Customer.CompanyName);
            CustomerDropDown.DataValueField = nameof(Customer.CustomerID);
            CustomerDropDown.DataBind();
            CustomerDropDown.Items.Insert(0, "[Select a customer]");
        }

        private void PopulateEmployeeDropDown()
        {
            var controller = new SalesController();
            List<Employee> employees = controller.ListAllEmployees();

            EmployeeDropDown.DataSource = employees;
            EmployeeDropDown.DataTextField = nameof(Employee.FullName);
            EmployeeDropDown.DataValueField = nameof(Employee.EmployeeID);
            EmployeeDropDown.DataBind();
            EmployeeDropDown.Items.Insert(0, "[Select an employee]");
            EmployeeDropDown.Items.Insert(1, new ListItem("[No employee]", ""));
        }

        private void PopulateShipperDropDown()
        {
            var controller = new SalesController();
            List<Shipper> shippers = controller.ListAllShippers();

            ShipperDropDown.DataSource = shippers;
            ShipperDropDown.DataTextField = nameof(Shipper.CompanyName);
            ShipperDropDown.DataValueField = nameof(Shipper.ShipperID);
            ShipperDropDown.DataBind();
            ShipperDropDown.Items.Insert(0, "[Select a shipper]");
            EmployeeDropDown.Items.Insert(1, new ListItem("[No shipper]", ""));
        }
        #endregion

        #region Button Click Events
        protected void SelectOrdersForCustomer_Click(object sender, EventArgs e)
        {
            if (CurrentCustomersDropDown.SelectedIndex == 0)
            {
                ShowMessage("Select a customer first.", AlertStyle.info);
            }
            else
            {
                string customerId = CurrentCustomersDropDown.SelectedValue;
                var controller = new SalesController();
                List<Order> orders = controller.GetCustomerOrders(customerId);

                CustomerOrdersDropDown.DataSource = orders;
                CustomerOrdersDropDown.DataTextField = nameof(Order.OrderInfo);
                CustomerOrdersDropDown.DataValueField = nameof(Order.OrderID);
                CustomerOrdersDropDown.DataBind();
                CustomerOrdersDropDown.Items.Insert(0, "[Select an order]");
            }
        }

        protected void ShowOrderDetails_Click(object sender, EventArgs e)
        {
            ShowMessage("Not implemented", AlertStyle.warning);
        }

        protected void AddOrder_Click(object sender, EventArgs e)
        {
            ShowMessage("Not implemented", AlertStyle.warning);
        }

        protected void UpdateOrder_Click(object sender, EventArgs e)
        {
            ShowMessage("Not implemented", AlertStyle.warning);
        }

        protected void DeleteOrder_Click(object sender, EventArgs e)
        {
            ShowMessage("Not implemented", AlertStyle.warning);
        }

        protected void ClearForm_Click(object sender, EventArgs e)
        {
            ShowMessage("Not implemented", AlertStyle.warning);
        }
        #endregion

        #region Error Message Reporting
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
        #endregion
    }
}