namespace eu4NET
{
    partial class ParsingStringForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParsingStringForm));
            this.progressBarParsing = new System.Windows.Forms.ProgressBar();
            this.labelParsed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarParsing
            // 
            this.progressBarParsing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarParsing.Location = new System.Drawing.Point(12, 20);
            this.progressBarParsing.Name = "progressBarParsing";
            this.progressBarParsing.Size = new System.Drawing.Size(360, 32);
            this.progressBarParsing.Step = 20;
            this.progressBarParsing.TabIndex = 0;
            // 
            // labelParsed
            // 
            this.labelParsed.AutoSize = true;
            this.labelParsed.Location = new System.Drawing.Point(12, 4);
            this.labelParsed.Name = "labelParsed";
            this.labelParsed.Size = new System.Drawing.Size(24, 13);
            this.labelParsed.TabIndex = 1;
            this.labelParsed.Text = "0/0";
            // 
            // ParsingStringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 61);
            this.ControlBox = false;
            this.Controls.Add(this.labelParsed);
            this.Controls.Add(this.progressBarParsing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParsingStringForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Загрузка строк...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarParsing;
        private System.Windows.Forms.Label labelParsed;
    }
}