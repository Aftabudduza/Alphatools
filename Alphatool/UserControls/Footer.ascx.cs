using System;
using System.Collections.Generic;
using AlphatoolServices.BO;
using AlphatoolServices.DA;

namespace UserControls
{    
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblYear.Text = DateTime.Now.Year.ToString();
        }
    }
}
