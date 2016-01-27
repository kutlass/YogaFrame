using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

using UnitTests;
using YogaFrameDeploy;
using YogaFrameWebAdapter;

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

        private void listBoxTraceOutput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonRegExValidate_Click(object sender, EventArgs e)
        {
            string strRegExData    = this.textBoxRegExData.Text;    // user data under test
            string strRegExPattern = this.textBoxRegExPattern.Text; // RegEx pattern rule
            Regex regex = new Regex(strRegExPattern);
            MessageBox.Show(regex.IsMatch(strRegExData).ToString());
        }
    }
}
