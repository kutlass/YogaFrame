using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using YogaFrameDeploy;

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

            //
            // Test out the various deployment methods
            //
            Deployment deployment = new Deployment();
            deployment.DatabaseConnect();
            Deployment.DatabaseRestore();
            Deployment.DatabaseRestore1();
            Deployment.DatabaseRestore2();
            //deployment.DatabaseCommand();

            Deployment.procedure_GetCharacters_drop();
            Deployment.procedure_GetCharacters_create();
            Deployment.procedure_GetCharacters_call();

            Deployment.YogaWebRequest();
            Deployment.FtpUploadFile();
        }

        private void buttonTestTrace_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("[Test Trace] button was clicked!");
        }
    }
}
