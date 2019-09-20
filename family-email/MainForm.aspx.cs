using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.IO;

namespace family_email
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbPort.Text = "";
            tbPort.Enabled = false;

            tbSMTP.Text = "localhost";
            tbSMTP.Enabled = false;

            tbUsername.Text = "";
            tbUsername.Enabled = false;

            tbPassword.Text = "";
            tbPassword.Enabled = false;
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

        protected void bSend_Click(object sender, EventArgs e)
        {
            SmtpClient client;
            MailMessage message;
            ArrayList attachmentList = new ArrayList();

            try
            {
                message = new MailMessage(tbFrom.Text, tbTo.Text);
                message.Subject = tbSubject.Text;
                message.Body = tbText.Text;

                if (rblLocal.SelectedIndex == 1)
                {
                    client = new SmtpClient(tbSMTP.Text, int.Parse(tbPort.Text));
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(tbUsername.Text, tbPassword.Text);
                }
                else
                {
                    client = new SmtpClient(tbSMTP.Text);
                    client.Credentials = CredentialCache.DefaultNetworkCredentials;
                }

                for (int i = 0; i < lbAttachments.Items.Count; i++)
                {
                    Attachment attachment = new Attachment(Server.MapPath("~/") + lbAttachments.Items[i].ToString());
                    message.Attachments.Add(attachment);
                    attachmentList.Add(attachment);
                }

                client.Send(message);

                lInfo1.Text = "Message Sent";

                for (int i = 0; i < attachmentList.Count; i++)
                {
                    ((Attachment)attachmentList[i]).Dispose();
                }

                for (int i = 0; i < lbAttachments.Items.Count; i++)
                {
                    File.Delete(Server.MapPath("~/") + lbAttachments.Items[i].ToString());
                }

                lbAttachments.Items.Clear();
            }
            catch(Exception ex)
            {
                lInfo1.Text = "Could not send message (" + ex.Message + ")";
            }
        }

        protected void rblLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLocal.SelectedIndex == 0)
            {
                tbPort.Text = "";
                tbPort.Enabled = false;

                tbSMTP.Text = "localhost";
                tbSMTP.Enabled = false;

                tbUsername.Text = "";
                tbUsername.Enabled = false;

                tbPassword.Text = "";
                tbPassword.Enabled = false;
            }
            else
            {
                tbPort.Text = "";
                tbPort.Enabled = true;

                tbSMTP.Text = "";
                tbSMTP.Enabled = true;

                tbUsername.Text = "";
                tbUsername.Enabled = true;

                tbPassword.Text = "";
                tbPassword.Enabled = true;
            }
        }
    }
}