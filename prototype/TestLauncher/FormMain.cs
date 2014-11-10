using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using YogaFrameDeploy;

namespace TestLauncher
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Deployment deployment = new Deployment();
            
            deployment.DatabaseConnect();
            Deployment.DatabaseRestore();
            Deployment.DatabaseRestore1();
            Deployment.DatabaseRestore2();
            deployment.DatabaseCommand();
        }
    }
}
