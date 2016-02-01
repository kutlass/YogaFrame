namespace TestLauncher
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxTraceOutput = new System.Windows.Forms.ListBox();
            this.buttonDeployFullService = new System.Windows.Forms.Button();
            this.buttonTestAPI = new System.Windows.Forms.Button();
            this.buttonUnitTestsDatabaseRestore = new System.Windows.Forms.Button();
            this.textBoxRegExData = new System.Windows.Forms.TextBox();
            this.textBoxRegExPattern = new System.Windows.Forms.TextBox();
            this.labelRegExData = new System.Windows.Forms.Label();
            this.labelRegExPattern = new System.Windows.Forms.Label();
            this.buttonRegExValidate = new System.Windows.Forms.Button();
            this.panelRegEx = new System.Windows.Forms.Panel();
            this.labelRegExHeader = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxTemplateEmail_VerifyYourAccount_Message = new System.Windows.Forms.TextBox();
            this.labelTemplateEmail_VerifyYourAccount_Message = new System.Windows.Forms.Label();
            this.textBoxTemplateEmail_VerifyYourAccount_Subject = new System.Windows.Forms.TextBox();
            this.labelTemplateEmail_VerifyYourAccount_Subject = new System.Windows.Forms.Label();
            this.textBoxTemplateEmail_VerifyYourAccount_Headers = new System.Windows.Forms.TextBox();
            this.labelTemplateEmail_VerifyYourAccount_Headers = new System.Windows.Forms.Label();
            this.FtpPassword = new System.Windows.Forms.Label();
            this.labelFtpUserName = new System.Windows.Forms.Label();
            this.labelFtpUri = new System.Windows.Forms.Label();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.textBoxFtpPassword = new System.Windows.Forms.TextBox();
            this.textBoxFtpUserName = new System.Windows.Forms.TextBox();
            this.textBoxFtpUri = new System.Windows.Forms.TextBox();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.buttonWebPostTemplateEmail = new System.Windows.Forms.Button();
            this.panelRegEx.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTraceOutput
            // 
            this.listBoxTraceOutput.BackColor = System.Drawing.Color.Black;
            this.listBoxTraceOutput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTraceOutput.ForeColor = System.Drawing.Color.LimeGreen;
            this.listBoxTraceOutput.FormattingEnabled = true;
            this.listBoxTraceOutput.HorizontalScrollbar = true;
            this.listBoxTraceOutput.ItemHeight = 23;
            this.listBoxTraceOutput.Location = new System.Drawing.Point(3, 160);
            this.listBoxTraceOutput.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxTraceOutput.Name = "listBoxTraceOutput";
            this.listBoxTraceOutput.Size = new System.Drawing.Size(1342, 487);
            this.listBoxTraceOutput.TabIndex = 0;
            // 
            // buttonDeployFullService
            // 
            this.buttonDeployFullService.Location = new System.Drawing.Point(3, 5);
            this.buttonDeployFullService.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeployFullService.Name = "buttonDeployFullService";
            this.buttonDeployFullService.Size = new System.Drawing.Size(301, 37);
            this.buttonDeployFullService.TabIndex = 1;
            this.buttonDeployFullService.Text = "Deploy Full YogaFrame Service";
            this.buttonDeployFullService.UseVisualStyleBackColor = true;
            this.buttonDeployFullService.Click += new System.EventHandler(this.buttonDeployFullService_Click);
            // 
            // buttonTestAPI
            // 
            this.buttonTestAPI.Location = new System.Drawing.Point(547, 5);
            this.buttonTestAPI.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTestAPI.Name = "buttonTestAPI";
            this.buttonTestAPI.Size = new System.Drawing.Size(113, 37);
            this.buttonTestAPI.TabIndex = 2;
            this.buttonTestAPI.Text = "Test API(s)";
            this.buttonTestAPI.UseVisualStyleBackColor = true;
            this.buttonTestAPI.Click += new System.EventHandler(this.buttonTestAPI_Click);
            // 
            // buttonUnitTestsDatabaseRestore
            // 
            this.buttonUnitTestsDatabaseRestore.Location = new System.Drawing.Point(313, 5);
            this.buttonUnitTestsDatabaseRestore.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUnitTestsDatabaseRestore.Name = "buttonUnitTestsDatabaseRestore";
            this.buttonUnitTestsDatabaseRestore.Size = new System.Drawing.Size(227, 37);
            this.buttonUnitTestsDatabaseRestore.TabIndex = 3;
            this.buttonUnitTestsDatabaseRestore.Text = "UnitTests::DatabaseRestore()";
            this.buttonUnitTestsDatabaseRestore.UseVisualStyleBackColor = true;
            this.buttonUnitTestsDatabaseRestore.Click += new System.EventHandler(this.buttonUnitTestsDatabaseRestore_Click);
            // 
            // textBoxRegExData
            // 
            this.textBoxRegExData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegExData.Location = new System.Drawing.Point(78, 34);
            this.textBoxRegExData.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRegExData.Name = "textBoxRegExData";
            this.textBoxRegExData.Size = new System.Drawing.Size(527, 30);
            this.textBoxRegExData.TabIndex = 4;
            // 
            // textBoxRegExPattern
            // 
            this.textBoxRegExPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegExPattern.Location = new System.Drawing.Point(78, 67);
            this.textBoxRegExPattern.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRegExPattern.Name = "textBoxRegExPattern";
            this.textBoxRegExPattern.Size = new System.Drawing.Size(527, 30);
            this.textBoxRegExPattern.TabIndex = 5;
            // 
            // labelRegExData
            // 
            this.labelRegExData.AutoSize = true;
            this.labelRegExData.Location = new System.Drawing.Point(17, 38);
            this.labelRegExData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRegExData.Name = "labelRegExData";
            this.labelRegExData.Size = new System.Drawing.Size(38, 17);
            this.labelRegExData.TabIndex = 6;
            this.labelRegExData.Text = "Data";
            // 
            // labelRegExPattern
            // 
            this.labelRegExPattern.AutoSize = true;
            this.labelRegExPattern.Location = new System.Drawing.Point(17, 71);
            this.labelRegExPattern.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRegExPattern.Name = "labelRegExPattern";
            this.labelRegExPattern.Size = new System.Drawing.Size(54, 17);
            this.labelRegExPattern.TabIndex = 7;
            this.labelRegExPattern.Text = "Pattern";
            // 
            // buttonRegExValidate
            // 
            this.buttonRegExValidate.Location = new System.Drawing.Point(20, 109);
            this.buttonRegExValidate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRegExValidate.Name = "buttonRegExValidate";
            this.buttonRegExValidate.Size = new System.Drawing.Size(584, 28);
            this.buttonRegExValidate.TabIndex = 8;
            this.buttonRegExValidate.Text = "Validate";
            this.buttonRegExValidate.UseVisualStyleBackColor = true;
            this.buttonRegExValidate.Click += new System.EventHandler(this.buttonRegExValidate_Click);
            // 
            // panelRegEx
            // 
            this.panelRegEx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRegEx.Controls.Add(this.labelRegExHeader);
            this.panelRegEx.Controls.Add(this.buttonRegExValidate);
            this.panelRegEx.Controls.Add(this.textBoxRegExData);
            this.panelRegEx.Controls.Add(this.labelRegExPattern);
            this.panelRegEx.Controls.Add(this.textBoxRegExPattern);
            this.panelRegEx.Controls.Add(this.labelRegExData);
            this.panelRegEx.Location = new System.Drawing.Point(666, 5);
            this.panelRegEx.Margin = new System.Windows.Forms.Padding(2);
            this.panelRegEx.Name = "panelRegEx";
            this.panelRegEx.Size = new System.Drawing.Size(618, 149);
            this.panelRegEx.TabIndex = 9;
            // 
            // labelRegExHeader
            // 
            this.labelRegExHeader.AutoSize = true;
            this.labelRegExHeader.Location = new System.Drawing.Point(17, 4);
            this.labelRegExHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRegExHeader.Name = "labelRegExHeader";
            this.labelRegExHeader.Size = new System.Drawing.Size(176, 17);
            this.labelRegExHeader.TabIndex = 10;
            this.labelRegExHeader.Text = "Regular Expression Tester";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1357, 688);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDeployFullService);
            this.tabPage1.Controls.Add(this.listBoxTraceOutput);
            this.tabPage1.Controls.Add(this.panelRegEx);
            this.tabPage1.Controls.Add(this.buttonTestAPI);
            this.tabPage1.Controls.Add(this.buttonUnitTestsDatabaseRestore);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1349, 659);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonWebPostTemplateEmail);
            this.tabPage2.Controls.Add(this.textBoxTemplateEmail_VerifyYourAccount_Message);
            this.tabPage2.Controls.Add(this.labelTemplateEmail_VerifyYourAccount_Message);
            this.tabPage2.Controls.Add(this.textBoxTemplateEmail_VerifyYourAccount_Subject);
            this.tabPage2.Controls.Add(this.labelTemplateEmail_VerifyYourAccount_Subject);
            this.tabPage2.Controls.Add(this.textBoxTemplateEmail_VerifyYourAccount_Headers);
            this.tabPage2.Controls.Add(this.labelTemplateEmail_VerifyYourAccount_Headers);
            this.tabPage2.Controls.Add(this.FtpPassword);
            this.tabPage2.Controls.Add(this.labelFtpUserName);
            this.tabPage2.Controls.Add(this.labelFtpUri);
            this.tabPage2.Controls.Add(this.labelConnectionString);
            this.tabPage2.Controls.Add(this.textBoxFtpPassword);
            this.tabPage2.Controls.Add(this.textBoxFtpUserName);
            this.tabPage2.Controls.Add(this.textBoxFtpUri);
            this.tabPage2.Controls.Add(this.textBoxConnectionString);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1349, 659);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxTemplateEmail_VerifyYourAccount_Message
            // 
            this.textBoxTemplateEmail_VerifyYourAccount_Message.Location = new System.Drawing.Point(325, 210);
            this.textBoxTemplateEmail_VerifyYourAccount_Message.Name = "textBoxTemplateEmail_VerifyYourAccount_Message";
            this.textBoxTemplateEmail_VerifyYourAccount_Message.Size = new System.Drawing.Size(393, 22);
            this.textBoxTemplateEmail_VerifyYourAccount_Message.TabIndex = 13;
            // 
            // labelTemplateEmail_VerifyYourAccount_Message
            // 
            this.labelTemplateEmail_VerifyYourAccount_Message.AutoSize = true;
            this.labelTemplateEmail_VerifyYourAccount_Message.Location = new System.Drawing.Point(17, 213);
            this.labelTemplateEmail_VerifyYourAccount_Message.Name = "labelTemplateEmail_VerifyYourAccount_Message";
            this.labelTemplateEmail_VerifyYourAccount_Message.Size = new System.Drawing.Size(291, 17);
            this.labelTemplateEmail_VerifyYourAccount_Message.TabIndex = 12;
            this.labelTemplateEmail_VerifyYourAccount_Message.Text = "TemplateEmail_VerifyYourAccount_Message";
            // 
            // textBoxTemplateEmail_VerifyYourAccount_Subject
            // 
            this.textBoxTemplateEmail_VerifyYourAccount_Subject.Location = new System.Drawing.Point(325, 182);
            this.textBoxTemplateEmail_VerifyYourAccount_Subject.Name = "textBoxTemplateEmail_VerifyYourAccount_Subject";
            this.textBoxTemplateEmail_VerifyYourAccount_Subject.Size = new System.Drawing.Size(393, 22);
            this.textBoxTemplateEmail_VerifyYourAccount_Subject.TabIndex = 11;
            // 
            // labelTemplateEmail_VerifyYourAccount_Subject
            // 
            this.labelTemplateEmail_VerifyYourAccount_Subject.AutoSize = true;
            this.labelTemplateEmail_VerifyYourAccount_Subject.Location = new System.Drawing.Point(27, 185);
            this.labelTemplateEmail_VerifyYourAccount_Subject.Name = "labelTemplateEmail_VerifyYourAccount_Subject";
            this.labelTemplateEmail_VerifyYourAccount_Subject.Size = new System.Drawing.Size(281, 17);
            this.labelTemplateEmail_VerifyYourAccount_Subject.TabIndex = 10;
            this.labelTemplateEmail_VerifyYourAccount_Subject.Text = "TemplateEmail_VerifyYourAccount_Subject";
            // 
            // textBoxTemplateEmail_VerifyYourAccount_Headers
            // 
            this.textBoxTemplateEmail_VerifyYourAccount_Headers.Location = new System.Drawing.Point(325, 154);
            this.textBoxTemplateEmail_VerifyYourAccount_Headers.Name = "textBoxTemplateEmail_VerifyYourAccount_Headers";
            this.textBoxTemplateEmail_VerifyYourAccount_Headers.Size = new System.Drawing.Size(393, 22);
            this.textBoxTemplateEmail_VerifyYourAccount_Headers.TabIndex = 9;
            // 
            // labelTemplateEmail_VerifyYourAccount_Headers
            // 
            this.labelTemplateEmail_VerifyYourAccount_Headers.AutoSize = true;
            this.labelTemplateEmail_VerifyYourAccount_Headers.Location = new System.Drawing.Point(20, 157);
            this.labelTemplateEmail_VerifyYourAccount_Headers.Name = "labelTemplateEmail_VerifyYourAccount_Headers";
            this.labelTemplateEmail_VerifyYourAccount_Headers.Size = new System.Drawing.Size(288, 17);
            this.labelTemplateEmail_VerifyYourAccount_Headers.TabIndex = 8;
            this.labelTemplateEmail_VerifyYourAccount_Headers.Text = "TemplateEmail_VerifyYourAccount_Headers";
            // 
            // FtpPassword
            // 
            this.FtpPassword.AutoSize = true;
            this.FtpPassword.Location = new System.Drawing.Point(219, 129);
            this.FtpPassword.Name = "FtpPassword";
            this.FtpPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FtpPassword.Size = new System.Drawing.Size(89, 17);
            this.FtpPassword.TabIndex = 7;
            this.FtpPassword.Text = "FtpPassword";
            // 
            // labelFtpUserName
            // 
            this.labelFtpUserName.AutoSize = true;
            this.labelFtpUserName.Location = new System.Drawing.Point(213, 101);
            this.labelFtpUserName.Name = "labelFtpUserName";
            this.labelFtpUserName.Size = new System.Drawing.Size(95, 17);
            this.labelFtpUserName.TabIndex = 6;
            this.labelFtpUserName.Text = "FtpUserName";
            // 
            // labelFtpUri
            // 
            this.labelFtpUri.AutoSize = true;
            this.labelFtpUri.Location = new System.Drawing.Point(262, 73);
            this.labelFtpUri.Name = "labelFtpUri";
            this.labelFtpUri.Size = new System.Drawing.Size(46, 17);
            this.labelFtpUri.TabIndex = 5;
            this.labelFtpUri.Text = "FtpUri";
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(192, 45);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(116, 17);
            this.labelConnectionString.TabIndex = 4;
            this.labelConnectionString.Text = "ConnectionString";
            // 
            // textBoxFtpPassword
            // 
            this.textBoxFtpPassword.Location = new System.Drawing.Point(325, 126);
            this.textBoxFtpPassword.Name = "textBoxFtpPassword";
            this.textBoxFtpPassword.Size = new System.Drawing.Size(393, 22);
            this.textBoxFtpPassword.TabIndex = 3;
            // 
            // textBoxFtpUserName
            // 
            this.textBoxFtpUserName.Location = new System.Drawing.Point(325, 98);
            this.textBoxFtpUserName.Name = "textBoxFtpUserName";
            this.textBoxFtpUserName.Size = new System.Drawing.Size(393, 22);
            this.textBoxFtpUserName.TabIndex = 2;
            // 
            // textBoxFtpUri
            // 
            this.textBoxFtpUri.Location = new System.Drawing.Point(325, 70);
            this.textBoxFtpUri.Name = "textBoxFtpUri";
            this.textBoxFtpUri.Size = new System.Drawing.Size(393, 22);
            this.textBoxFtpUri.TabIndex = 1;
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(325, 42);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(393, 22);
            this.textBoxConnectionString.TabIndex = 0;
            // 
            // buttonWebPostTemplateEmail
            // 
            this.buttonWebPostTemplateEmail.Location = new System.Drawing.Point(724, 157);
            this.buttonWebPostTemplateEmail.Name = "buttonWebPostTemplateEmail";
            this.buttonWebPostTemplateEmail.Size = new System.Drawing.Size(178, 75);
            this.buttonWebPostTemplateEmail.TabIndex = 14;
            this.buttonWebPostTemplateEmail.Text = "WebPostTemplateEmail()";
            this.buttonWebPostTemplateEmail.UseVisualStyleBackColor = true;
            this.buttonWebPostTemplateEmail.Click += new System.EventHandler(this.buttonWebPostTemplateEmail_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1351, 666);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "YogaFrameTestLauncher";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelRegEx.ResumeLayout(false);
            this.panelRegEx.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTraceOutput;
        private System.Windows.Forms.Button buttonDeployFullService;
        private System.Windows.Forms.Button buttonTestAPI;
        private System.Windows.Forms.Button buttonUnitTestsDatabaseRestore;
        private System.Windows.Forms.TextBox textBoxRegExData;
        private System.Windows.Forms.TextBox textBoxRegExPattern;
        private System.Windows.Forms.Label labelRegExData;
        private System.Windows.Forms.Label labelRegExPattern;
        private System.Windows.Forms.Button buttonRegExValidate;
        private System.Windows.Forms.Panel panelRegEx;
        private System.Windows.Forms.Label labelRegExHeader;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label FtpPassword;
        private System.Windows.Forms.Label labelFtpUserName;
        private System.Windows.Forms.Label labelFtpUri;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TextBox textBoxFtpPassword;
        private System.Windows.Forms.TextBox textBoxFtpUserName;
        private System.Windows.Forms.TextBox textBoxFtpUri;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.TextBox textBoxTemplateEmail_VerifyYourAccount_Message;
        private System.Windows.Forms.Label labelTemplateEmail_VerifyYourAccount_Message;
        private System.Windows.Forms.TextBox textBoxTemplateEmail_VerifyYourAccount_Subject;
        private System.Windows.Forms.Label labelTemplateEmail_VerifyYourAccount_Subject;
        private System.Windows.Forms.TextBox textBoxTemplateEmail_VerifyYourAccount_Headers;
        private System.Windows.Forms.Label labelTemplateEmail_VerifyYourAccount_Headers;
        private System.Windows.Forms.Button buttonWebPostTemplateEmail;
    }
}

