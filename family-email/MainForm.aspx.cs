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

        protected void bClear_Click(object sender, EventArgs e)
        {
            tbFrom.Text = "";
            tbTo.Text = "";
            tbSubject.Text = "";
            tbText.Text = "";
            tbSMTP.Text = "";
            lInfo1.Text = "";
            lbAttachments.Items.Clear();
        }

        protected void bSave_Click(object sender, EventArgs e)
        {
            if (fuAttachments.HasFile)
            {
                string fileName = fuAttachments.FileName;
                string serverPath = Server.MapPath("~/") + fileName;
                fuAttachments.SaveAs(serverPath);
                lbAttachments.Items.Add(fileName);
                lInfo2.Text = "Attachment Downloaded";
            }
        }
    }
}