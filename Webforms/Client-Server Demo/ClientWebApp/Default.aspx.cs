using DataEntities;
using ServerSide.BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateGridView();
            }

            MessageLabel.Text = string.Empty; // Clear out the message each time
        }

        private void PopulateGridView()
        {
            var controller = new ServerSide.BLL.CodeDemoController();
            CodeDemoGridView.DataSource = controller.ListAllDemos();
            CodeDemoGridView.DataBind();
        }

        protected void AddDemo_Click(object sender, EventArgs e)
        {
            try
            {
                var data = new CodeDemo();
                data.Name = DemoName.Text; // Grab the name from the form & put in object
                if (!string.IsNullOrWhiteSpace(Description.Text))
                    data.Description = Description.Text;

                var controller = new CodeDemoController();
                controller.AddDemo(data);
                PopulateGridView();
            }
            catch(Exception ex)
            {
                Exception inner = ex;
                // this next statement drills down on the details of the exception
                while (inner.InnerException != null)
                    inner = inner.InnerException;
                string message;
                if (inner is DbEntityValidationException)
                {
                    message = ExtractValidationErrorDetails(inner as DbEntityValidationException);
                }
                else
                    message = inner.Message;
                MessageLabel.Text = message;
            }
        }

        private string ExtractValidationErrorDetails(DbEntityValidationException ex)
        {
            string details = "";

            foreach(var entityObj in ex.EntityValidationErrors)
            {
                details += $"<p>Entity of type {entityObj.Entry.Entity.GetType().Name} in state {entityObj.Entry.State} has the following errors: <ul>";
                foreach(var err in entityObj.ValidationErrors)
                {
                    details += $"<li>Property: {err.PropertyName} - Error: {err.ErrorMessage}</li>";
                }
                details += "</ul></p>";
            }

            return details;
        }
    }
}