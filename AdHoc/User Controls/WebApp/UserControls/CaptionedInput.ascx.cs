using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.UserControls
{
    public partial class CaptionedInput : System.Web.UI.UserControl
    {
        [TemplateContainer(typeof(MessageContainer))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate MessageTemplate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init()
        {
            if (MessageTemplate != null)
            {
                String[] fruits = { "apple", "orange", "banana", "pineapple" };
                for (int i = 0; i < 4; i++)
                {
                    MessageContainer container = new MessageContainer(i, fruits[i]);
                    MessageTemplate.InstantiateIn(container);
                    MessagePlaceHolder.Controls.Add(container);
                }
            }
        }
    }

    public class MessageContainer : Control, INamingContainer
    {
        private int m_index;
        private String m_message;
        internal MessageContainer(int index, String message)
        {
            m_index = index;
            m_message = message;
        }
        public int Index
        {
            get
            {
                return m_index;
            }
        }
        public String Message
        {
            get
            {
                return m_message;
            }
        }
    }
}