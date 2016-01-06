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
            this.SuspendLayout();
            // 
            // listBoxTraceOutput
            // 
            this.listBoxTraceOutput.BackColor = System.Drawing.Color.Black;
            this.listBoxTraceOutput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTraceOutput.ForeColor = System.Drawing.Color.LimeGreen;
            this.listBoxTraceOutput.FormattingEnabled = true;
            this.listBoxTraceOutput.HorizontalScrollbar = true;
            this.listBoxTraceOutput.ItemHeight = 19;
            this.listBoxTraceOutput.Location = new System.Drawing.Point(1, 32);
            this.listBoxTraceOutput.Name = "listBoxTraceOutput";
            this.listBoxTraceOutput.Size = new System.Drawing.Size(1297, 688);
            this.listBoxTraceOutput.TabIndex = 0;
            // 
            // buttonDeployFullService
            // 
            this.buttonDeployFullService.Location = new System.Drawing.Point(1, 1);
            this.buttonDeployFullService.Name = "buttonDeployFullService";
            this.buttonDeployFullService.Size = new System.Drawing.Size(226, 30);
            this.buttonDeployFullService.TabIndex = 1;
            this.buttonDeployFullService.Text = "Deploy Full YogaFrame Service";
            this.buttonDeployFullService.UseVisualStyleBackColor = true;
            this.buttonDeployFullService.Click += new System.EventHandler(this.buttonDeployFullService_Click);
            // 
            // buttonTestAPI
            // 
            this.buttonTestAPI.Location = new System.Drawing.Point(409, 1);
            this.buttonTestAPI.Name = "buttonTestAPI";
            this.buttonTestAPI.Size = new System.Drawing.Size(85, 30);
            this.buttonTestAPI.TabIndex = 2;
            this.buttonTestAPI.Text = "Test API(s)";
            this.buttonTestAPI.UseVisualStyleBackColor = true;
            this.buttonTestAPI.Click += new System.EventHandler(this.buttonTestAPI_Click);
            // 
            // buttonUnitTestsDatabaseRestore
            // 
            this.buttonUnitTestsDatabaseRestore.Location = new System.Drawing.Point(233, 1);
            this.buttonUnitTestsDatabaseRestore.Name = "buttonUnitTestsDatabaseRestore";
            this.buttonUnitTestsDatabaseRestore.Size = new System.Drawing.Size(170, 30);
            this.buttonUnitTestsDatabaseRestore.TabIndex = 3;
            this.buttonUnitTestsDatabaseRestore.Text = "UnitTests::DatabaseRestore()";
            this.buttonUnitTestsDatabaseRestore.UseVisualStyleBackColor = true;
            this.buttonUnitTestsDatabaseRestore.Click += new System.EventHandler(this.buttonUnitTestsDatabaseRestore_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 719);
            this.Controls.Add(this.buttonUnitTestsDatabaseRestore);
            this.Controls.Add(this.buttonTestAPI);
            this.Controls.Add(this.buttonDeployFullService);
            this.Controls.Add(this.listBoxTraceOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormMain";
            this.Text = "YogaFrameTestLauncher";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTraceOutput;
        private System.Windows.Forms.Button buttonDeployFullService;
        private System.Windows.Forms.Button buttonTestAPI;
        private System.Windows.Forms.Button buttonUnitTestsDatabaseRestore;        
    }
}

