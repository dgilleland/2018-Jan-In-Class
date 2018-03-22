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
            MessageLabel.Text = string.Empty;
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
                    if (UserNameIsAvailable())
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

                        // Call another method to do the form-clearing
                        ClearForm_Click(sender, e); // Hijacking - a bit of a code smell....
                    }
                    else
                    {
                        MessageLabel.Text = "That username is already taken.";
                    }
                }
                else
                {
                    // Display a message through the MessageLabel control
                    MessageLabel.Text = "You must agree to the terms before you can be registered.";
                }
            }
        }

        private bool UserNameIsAvailable()
        {
            bool isAvailable = true;
            // Now, see if it has been taken!
            foreach (var person in TheUsers)
                if (person.UserName == UserName.Text)
                    isAvailable = false;
            return isAvailable;
        }

        protected void ClearForm_Click(object sender, EventArgs e)
        {
            // Manually clear out the data entry form.
            FirstName.Text = string.Empty;
            LastName.Text = string.Empty;
            UserName.Text = string.Empty;
            Email.Text = string.Empty;
            ConfirmEmail.Text = string.Empty;
            Password.Text = string.Empty;
            ConfirmPassword.Text = string.Empty;
            AgreeToTerms.Checked = false;
        }

        protected void DeleteAllUsers_Click(object sender, EventArgs e)
        {
            TheUsers.Clear(); // Empties out the List<RegisteredUser> object
            PopulateGridView();
        }
    }
}