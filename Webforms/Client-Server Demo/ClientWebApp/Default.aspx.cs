using System;
using System.Collections.Generic;
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
                var controller = new ServerSide.BLL.CodeDemoController();
                CodeDemoGridView.DataSource = controller.ListAllDemos();
                CodeDemoGridView.DataBind();
            }
        }
    }
}