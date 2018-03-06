
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

partial class FormSamples_CreateBankAccount
    : System.Web.UI.Page
{
    protected void Page_Load(Object sender, EventArgs e)
    {
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (IsValid) // IsValid is a property on the page that checks with the validation controls to ensure that the data in the controls passes all the validation.
        {
            MessageLabel.Text = "Your new bank account will be processed soon.";
        }
        // else....
        //      The ValidationSummary will automatically display its contents should the IsValid check return False.
    }
    protected void ClearForm_Click(object sender, EventArgs e)
    {
        // Empty out all the values of the textboxes, etc.
        AccountHolder.Text = "";
        AccountNumber.Text = "";
        OverdraftLimit.Text = "";
        OpeningBalance.Text = "";
        // To "clear" a DropDownList, RadioButtonList, or CheckBoxList, you would change the .SelectedValue
        AccountType.SelectedValue = "";
        // (Alternatively, I could have changed the .SelectedIndex instead)
        AccountType.SelectedIndex = -1; // -1, just in case there are no items in the control

    }
}
