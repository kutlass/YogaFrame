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
            this.listBoxTraceOutput.Location = new System.Drawing.Point(1, -6);
            this.listBoxTraceOutput.Name = "listBoxTraceOutput";
            this.listBoxTraceOutput.Size = new System.Drawing.Size(1297, 726);
            this.listBoxTraceOutput.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 719);
            this.Controls.Add(this.listBoxTraceOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormMain";
            this.Text = "YogaFrameTestLauncher";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTraceOutput;        
    }
}

