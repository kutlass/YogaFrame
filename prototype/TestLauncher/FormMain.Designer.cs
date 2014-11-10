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
            this.buttonTestTrace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxTraceOutput
            // 
            this.listBoxTraceOutput.FormattingEnabled = true;
            this.listBoxTraceOutput.Location = new System.Drawing.Point(12, 90);
            this.listBoxTraceOutput.Name = "listBoxTraceOutput";
            this.listBoxTraceOutput.Size = new System.Drawing.Size(543, 290);
            this.listBoxTraceOutput.TabIndex = 0;
            // 
            // buttonTestTrace
            // 
            this.buttonTestTrace.Location = new System.Drawing.Point(231, 30);
            this.buttonTestTrace.Name = "buttonTestTrace";
            this.buttonTestTrace.Size = new System.Drawing.Size(75, 23);
            this.buttonTestTrace.TabIndex = 1;
            this.buttonTestTrace.Text = "Test Trace";
            this.buttonTestTrace.UseVisualStyleBackColor = true;
            this.buttonTestTrace.Click += new System.EventHandler(this.buttonTestTrace_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 391);
            this.Controls.Add(this.buttonTestTrace);
            this.Controls.Add(this.listBoxTraceOutput);
            this.Name = "FormMain";
            this.Text = "YogaFrameTestLauncher";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTraceOutput;
        private System.Windows.Forms.Button buttonTestTrace;        
    }
}

