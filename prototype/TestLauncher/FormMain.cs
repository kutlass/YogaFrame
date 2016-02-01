using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

using UnitTests;
using YogaFrameDeploy;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.TemplateEmailsJsonTypes;

namespace TestLauncher
{
    public partial class FormMain : Form
    {
        private ListBoxTraceListener m_listBoxTraceListener;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //
            // Setup the UI trace listener
            //
            m_listBoxTraceListener = new ListBoxTraceListener(this.listBoxTraceOutput);
            Trace.Listeners.Add(m_listBoxTraceListener);

            DisplayDeploymentSettings();
        }

        private void DisplayDeploymentSettings()
        {
            //
            // Populate the textBox values
            // with appropriate DeploymentSettings 
            //
            DeploymentSettings deploymentSettings = new DeploymentSettings();
            textBoxConnectionString.Text = deploymentSettings.ConnectionString;
            textBoxFtpUri.Text           = deploymentSettings.FtpUri;
            textBoxFtpUserName.Text      = deploymentSettings.FtpUserName;
            textBoxFtpPassword.Text      = deploymentSettings.FtpPassword;
            textBoxTemplateEmail_VerifyYourAccount_Headers.Text = deploymentSettings.TemplateEmail_VerifyYourAccount_Headers;
            textBoxTemplateEmail_VerifyYourAccount_Subject.Text = deploymentSettings.TemplateEmail_VerifyYourAccount_Subject;
            textBoxTemplateEmail_VerifyYourAccount_Message.Text = deploymentSettings.TemplateEmail_VerifyYourAccount_Message;
        }

        private void buttonDeployFullService_Click(object sender, EventArgs e)
        {
            Deployment.DeployFullService();
        }

        private void buttonTestAPI_Click(object sender, EventArgs e)
        {
            PreUnitTests.TestAPIs();
        }

        private void buttonUnitTestsDatabaseRestore_Click(object sender, EventArgs e)
        {
            PreUnitTests.UnitTests_DatabaseRestore();
        }

        private void buttonRegExValidate_Click(object sender, EventArgs e)
        {
            string strRegExData    = this.textBoxRegExData.Text;    // user data under test
            string strRegExPattern = this.textBoxRegExPattern.Text; // RegEx pattern rule
                  
            string strResult = string.Empty;
            try
            {
                Regex regex = new Regex(strRegExPattern);
                bool fResult = regex.IsMatch(strRegExData);
                strResult = fResult.ToString();
            }
            catch (Exception ex)
            {
                strResult = "Exception in Regex object: " + ex.Message;
            }
            finally
            {
                MessageBox.Show(strResult);
            }
        }

        private void buttonWebPostTemplateEmail_Click(object sender, EventArgs e)
        {
            //
            // Post the "Verify your account" template email
            // to the web service. This is an administrative task.
            //
            DeploymentSettings deploymentSettings = new DeploymentSettings();
            TblTemplateEmail[] rgTblTemplateEmail = new TblTemplateEmail[1];
            rgTblTemplateEmail[0].ColHeaders = deploymentSettings.TemplateEmail_VerifyYourAccount_Headers;
            rgTblTemplateEmail[0].ColSubject = deploymentSettings.TemplateEmail_VerifyYourAccount_Subject;
            rgTblTemplateEmail[0].ColMessage = deploymentSettings.TemplateEmail_VerifyYourAccount_Message;
            TemplateEmails templateEmails = new TemplateEmails();
            templateEmails.TblTemplateEmails = rgTblTemplateEmail;
            JSession jSessionWebResponse = null;
            jSessionWebResponse = WebAdapter.WebPostTemplateEmail(ref templateEmails);
            MessageBox.Show(jSessionWebResponse.Dispatch.Message);
        }
    }
}
