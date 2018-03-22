using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.FormSamples.Classes;

namespace WebApp.Practice
{
    public partial class UserRegistrationForm : System.Web.UI.Page
    {
        // Field
        private static List<RegisteredUser> TheUsers
            = new List<RegisteredUser>();
        // vs Property
        //private static List<RegisteredUser> TheUsers { get; set; }
        //    = new List<RegisteredUser>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateGridView();
        }

        private void PopulateGridView()
        {
            RegisteredUsersGridView.DataSource = TheUsers;
            RegisteredUsersGridView.DataBind();
        }

        protected void SubmitRegistration_Click(object sender, EventArgs e)
        {
            if(IsValid) // server-side rechecking of Validation controls
            {
                if(AgreeToTerms.Checked)
                {
                    // Make a new RegisteredUser object based off of info in
                    // the form
                    var newPerson = new RegisteredUser()
                    {   // This is an "Initialization List"
                        FirstName = FirstName.Text,
                        LastName = LastName.Text,
                        Email = Email.Text,
                        Password = Password.Text,
                        UserName = UserName.Text,
                        AgreedToTerms = DateTime.Now
                    };

                    // Add them to the list (or DB in a real app)
                    TheUsers.Add(newPerson);
                    // Refresh the data in the GridView
                    PopulateGridView();
                }
                else
                {
                    // Display a message through the MessageLabel control
                    MessageLabel.Text = "You must agree to the terms before you can be registered.";
                }
            }
        }
    }
}