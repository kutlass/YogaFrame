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
            this.panelRegEx.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTraceOutput
            // 
            this.listBoxTraceOutput.BackColor = System.Drawing.Color.Black;
            this.listBoxTraceOutput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTraceOutput.ForeColor = System.Drawing.Color.LimeGreen;
            this.listBoxTraceOutput.FormattingEnabled = true;
            this.listBoxTraceOutput.HorizontalScrollbar = true;
            this.listBoxTraceOutput.ItemHeight = 37;
            this.listBoxTraceOutput.Location = new System.Drawing.Point(2, 277);
            this.listBoxTraceOutput.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxTraceOutput.Name = "listBoxTraceOutput";
            this.listBoxTraceOutput.Size = new System.Drawing.Size(2590, 1188);
            this.listBoxTraceOutput.TabIndex = 0;
            // 
            // buttonDeployFullService
            // 
            this.buttonDeployFullService.Location = new System.Drawing.Point(2, 2);
            this.buttonDeployFullService.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDeployFullService.Name = "buttonDeployFullService";
            this.buttonDeployFullService.Size = new System.Drawing.Size(452, 58);
            this.buttonDeployFullService.TabIndex = 1;
            this.buttonDeployFullService.Text = "Deploy Full YogaFrame Service";
            this.buttonDeployFullService.UseVisualStyleBackColor = true;
            this.buttonDeployFullService.Click += new System.EventHandler(this.buttonDeployFullService_Click);
            // 
            // buttonTestAPI
            // 
            this.buttonTestAPI.Location = new System.Drawing.Point(818, 2);
            this.buttonTestAPI.Margin = new System.Windows.Forms.Padding(6);
            this.buttonTestAPI.Name = "buttonTestAPI";
            this.buttonTestAPI.Size = new System.Drawing.Size(170, 58);
            this.buttonTestAPI.TabIndex = 2;
            this.buttonTestAPI.Text = "Test API(s)";
            this.buttonTestAPI.UseVisualStyleBackColor = true;
            this.buttonTestAPI.Click += new System.EventHandler(this.buttonTestAPI_Click);
            // 
            // buttonUnitTestsDatabaseRestore
            // 
            this.buttonUnitTestsDatabaseRestore.Location = new System.Drawing.Point(466, 2);
            this.buttonUnitTestsDatabaseRestore.Margin = new System.Windows.Forms.Padding(6);
            this.buttonUnitTestsDatabaseRestore.Name = "buttonUnitTestsDatabaseRestore";
            this.buttonUnitTestsDatabaseRestore.Size = new System.Drawing.Size(340, 58);
            this.buttonUnitTestsDatabaseRestore.TabIndex = 3;
            this.buttonUnitTestsDatabaseRestore.Text = "UnitTests::DatabaseRestore()";
            this.buttonUnitTestsDatabaseRestore.UseVisualStyleBackColor = true;
            this.buttonUnitTestsDatabaseRestore.Click += new System.EventHandler(this.buttonUnitTestsDatabaseRestore_Click);
            // 
            // textBoxRegExData
            // 
            this.textBoxRegExData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegExData.Location = new System.Drawing.Point(117, 53);
            this.textBoxRegExData.Name = "textBoxRegExData";
            this.textBoxRegExData.Size = new System.Drawing.Size(789, 44);
            this.textBoxRegExData.TabIndex = 4;
            // 
            // textBoxRegExPattern
            // 
            this.textBoxRegExPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegExPattern.Location = new System.Drawing.Point(117, 105);
            this.textBoxRegExPattern.Name = "textBoxRegExPattern";
            this.textBoxRegExPattern.Size = new System.Drawing.Size(789, 44);
            this.textBoxRegExPattern.TabIndex = 5;
            // 
            // labelRegExData
            // 
            this.labelRegExData.AutoSize = true;
            this.labelRegExData.Location = new System.Drawing.Point(25, 59);
            this.labelRegExData.Name = "labelRegExData";
            this.labelRegExData.Size = new System.Drawing.Size(57, 25);
            this.labelRegExData.TabIndex = 6;
            this.labelRegExData.Text = "Data";
            // 
            // labelRegExPattern
            // 
            this.labelRegExPattern.AutoSize = true;
            this.labelRegExPattern.Location = new System.Drawing.Point(25, 111);
            this.labelRegExPattern.Name = "labelRegExPattern";
            this.labelRegExPattern.Size = new System.Drawing.Size(81, 25);
            this.labelRegExPattern.TabIndex = 7;
            this.labelRegExPattern.Text = "Pattern";
            // 
            // buttonRegExValidate
            // 
            this.buttonRegExValidate.Location = new System.Drawing.Point(30, 171);
            this.buttonRegExValidate.Name = "buttonRegExValidate";
            this.buttonRegExValidate.Size = new System.Drawing.Size(876, 43);
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
            this.panelRegEx.Location = new System.Drawing.Point(1006, 12);
            this.panelRegEx.Name = "panelRegEx";
            this.panelRegEx.Size = new System.Drawing.Size(926, 232);
            this.panelRegEx.TabIndex = 9;
            // 
            // labelRegExHeader
            // 
            this.labelRegExHeader.AutoSize = true;
            this.labelRegExHeader.Location = new System.Drawing.Point(25, 7);
            this.labelRegExHeader.Name = "labelRegExHeader";
            this.labelRegExHeader.Size = new System.Drawing.Size(267, 25);
            this.labelRegExHeader.TabIndex = 10;
            this.labelRegExHeader.Text = "Regular Expression Tester";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2596, 1383);
            this.Controls.Add(this.panelRegEx);
            this.Controls.Add(this.buttonUnitTestsDatabaseRestore);
            this.Controls.Add(this.buttonTestAPI);
            this.Controls.Add(this.buttonDeployFullService);
            this.Controls.Add(this.listBoxTraceOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "YogaFrameTestLauncher";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelRegEx.ResumeLayout(false);
            this.panelRegEx.PerformLayout();
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
    }
}

