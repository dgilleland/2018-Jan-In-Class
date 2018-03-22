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

        }

        protected void SubmitRegistration_Click(object sender, EventArgs e)
        {
            if(IsValid) // server-side rechecking of Validation controls
            {
                if(AgreeToTerms.Checked)
                {

                }
                else
                {
                    // Display a message through the MessageLabel control
                }
            }
        }
    }
}