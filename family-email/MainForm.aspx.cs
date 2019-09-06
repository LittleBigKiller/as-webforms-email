using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace family_email
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bHello_Click(object sender, EventArgs e)
        {
            lHello.Text = "Hello, " + tbHello.Text;
        }
    }
}