using System;
using System.Windows.Forms;
using System.Diagnostics;

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
    }
}
