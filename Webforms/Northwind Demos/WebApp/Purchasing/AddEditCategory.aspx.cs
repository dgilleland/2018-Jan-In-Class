using NorthwindEntities;
using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Utilities;

namespace WebApp.Purchasing
{
    public partial class AddEditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
            MessageLabel.Text = "";  //Clears old previous message
                                     //load the drop down list
                                     // for first time only initialization of page controls
            if (!Page.IsPostBack)
            {
                try
                {
                    PopulateCategoryDropdown();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                    MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                    MessagePanel.Visible = true;
                }
            }
        }
        private void PopulateCategoryDropdown()
        {
            // Populate Category drop-down
            InventoryPurchasingController controller = new InventoryPurchasingController();
            List<Category> categories = controller.ListAllCategories();
            CurrentCategories.DataSource = categories;
            CurrentCategories.DataTextField = "CategoryName";
            CurrentCategories.DataValueField = "CategoryID";
            CurrentCategories.DataBind();
            CurrentCategories.Items.Insert(0, "[select a category]");
        }


        protected void LookupCategory_Click(object sender, EventArgs e)
        {
            // if the user is required to make a selection or 
            // enter a value for the look, ensure that it has
            // been done
            if (CurrentCategories.SelectedIndex != 0)
            {
                // you should properly handle errors in a friendly manner
                try
                {
                    //connect to the BLL
                    InventoryPurchasingController systemmgr = new InventoryPurchasingController();
                    //set up the data catching variable
                    Category aCategory; //currently null
                                        // issue query request (lookup)
                    aCategory = systemmgr.LookupCategory(int.Parse(CurrentCategories.SelectedValue));

                    // testing for not found
                    if (aCategory == null)
                    {
                        MessageLabel.Text = "No data from for selected category";
                        // empty display controls
                        CategoryID.Text = "";
                        CategoryName.Text = "";
                        Description.Text = "";
                    }
                    else
                    {
                        // load the appropriate controls with corresponding data
                        CategoryID.Text = aCategory.CategoryID.ToString();
                        CategoryName.Text = aCategory.CategoryName;
                        Description.Text = aCategory.Description;

                        if (aCategory.Picture != null)
                        {
                            string base64String = Convert.ToBase64String(aCategory.Picture);
                            Picture.ImageUrl = string.Format("data:{0};base64,{1}", aCategory.PictureMimeType, base64String);
                        }
                        else
                            Picture.ImageUrl = "~/Images/NoImage_172x120.gif";
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                    MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                    MessagePanel.Visible = true;
                }
            }
            else
            {
                MessageLabel.Text = "Select a category for searching.";
                MessagePanel.CssClass = "alert alert-info alert-dismissible";
                MessagePanel.Visible = true;
            }

        }

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                Category item = new Category();
                item.CategoryName = CategoryName.Text;
                if (!string.IsNullOrEmpty(Description.Text))
                    item.Description = Description.Text;
                item.Picture = ImageUploadHelpers.GetUploadedPicture(CategoryImageUpload);
                item.PictureMimeType = ImageUploadHelpers.GetMimeType(CategoryImageUpload);

                InventoryPurchasingController controller = new InventoryPurchasingController();
                int addedCategoryID = controller.AddCategory(item);
                // Update the form and give feedback to the user
                PopulateCategoryDropdown();
                CurrentCategories.SelectedValue = addedCategoryID.ToString();
                CategoryID.Text = addedCategoryID.ToString();
                if (item.Picture != null)
                {
                    string base64String = Convert.ToBase64String(item.Picture);
                    Picture.ImageUrl = string.Format("data:{0};base64,{1}", item.PictureMimeType, base64String);
                }
                else
                    Picture.ImageUrl = "~/Images/NoImage_172x120.gif";
                MessageLabel.Text = "New category added";
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }


        protected void UpdateCategory_Click(object sender, EventArgs e)
        {
            int theCategoryId;
            if (IsValid)
                if (int.TryParse(CategoryID.Text, out theCategoryId))
                {
                    try
                    {
                        byte[] uploadedPicture = ImageUploadHelpers.GetUploadedPicture(CategoryImageUpload);
                        string mimeType = ImageUploadHelpers.GetMimeType(CategoryImageUpload);
                        if (uploadedPicture != null && DeletePicture.Checked)
                        {
                            MessageLabel.Text = "Unclear input.<br />"
                                + "You selected 'Check to delete picture' and uploaded an image.";
                        }
                        else
                        {
                            // 1) Get the picture to be used in the update
                            InventoryPurchasingController controller = new InventoryPurchasingController();
                            if (DeletePicture.Checked)
                            {
                                uploadedPicture = null;
                                mimeType = null;
                            }
                            else if (uploadedPicture == null)
                            {
                                // default to the existing picture
                                Category existing = controller.LookupCategory(theCategoryId);
                                uploadedPicture = existing.Picture;
                                mimeType = existing.PictureMimeType;
                            }

                            // 2) Create the Category object
                            Category item = new Category();
                            item.CategoryID = theCategoryId;
                            item.CategoryName = CategoryName.Text;
                            if (!string.IsNullOrEmpty(Description.Text))
                                item.Description = Description.Text;
                            item.Picture = uploadedPicture;
                            item.PictureMimeType = mimeType;

                            // 3) Update the database
                            controller.UpdateCategory(item);


                            PopulateCategoryDropdown();
                            CurrentCategories.SelectedValue = item.CategoryID.ToString();
                            if (item.Picture != null)
                            {
                                string base64String = Convert.ToBase64String(item.Picture);
                                Picture.ImageUrl = string.Format("data:{0};base64,{1}", item.PictureMimeType, base64String);
                            }
                            else
                                Picture.ImageUrl = "~/Images/NoImage_172x120.gif";
                            MessageLabel.Text = "Category was updated.";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageLabel.Text = ex.Message;
                        MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                        MessagePanel.Visible = true;
                    }
                }
                else
                {
                    MessageLabel.Text = "Lookup and existing category before attempting an update.";
                }
        }

        protected void DeleteCategory_Click(object sender, EventArgs e)
        {
            int theCategoryId;
            if (int.TryParse(CategoryID.Text, out theCategoryId))
            {
                try
                {
                    InventoryPurchasingController controller = new InventoryPurchasingController();
                    controller.DeleteCategory(theCategoryId);

                    MessageLabel.Text = "Category " + CategoryName.Text + " deleted";
                    PopulateCategoryDropdown();
                    CategoryID.Text = string.Empty;
                    CategoryName.Text = string.Empty;
                    Description.Text = string.Empty;
                    Picture.ImageUrl = "~/Images/NoImage_172x120.gif";
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                    MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                    MessagePanel.Visible = true;
                }
            }
            else
            {
                MessageLabel.Text = "Lookup and existing category before attempting to delete.";
            }
        }

        protected void ClearForm_Click(object sender, EventArgs e)
        {
            CategoryID.Text = "";
            CategoryName.Text = "";
            Description.Text = "";
            DeletePicture.Checked = false;
            Picture.ImageUrl = "~/Images/NoImage_172x120.gif";
            CurrentCategories.SelectedIndex = 0;
        }
    }
}