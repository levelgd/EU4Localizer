namespace eu4NET
{
    partial class FormFindText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFindText));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxCase = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.columnHeaderFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBarFind = new System.Windows.Forms.ProgressBar();
            this.buttonFind = new System.Windows.Forms.Button();
            this.comboBoxFind = new System.Windows.Forms.ComboBox();
            this.checkBoxCurrent = new System.Windows.Forms.CheckBox();
            this.comboBoxEnru = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxCase, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFind, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewResults, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.progressBarFind, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonFind, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFind, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxCurrent, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxEnru, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 361);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxCase
            // 
            this.checkBoxCase.AutoSize = true;
            this.checkBoxCase.Location = new System.Drawing.Point(343, 161);
            this.checkBoxCase.Name = "checkBoxCase";
            this.checkBoxCase.Size = new System.Drawing.Size(124, 17);
            this.checkBoxCase.TabIndex = 0;
            this.checkBoxCase.Text = "Учитывать регистр";
            this.checkBoxCase.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 4);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // textBoxFind
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxFind, 4);
            this.textBoxFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFind.Location = new System.Drawing.Point(3, 3);
            this.textBoxFind.Multiline = true;
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(678, 123);
            this.textBoxFind.TabIndex = 1;
            // 
            // listViewResults
            // 
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFile,
            this.columnHeaderField,
            this.columnHeaderText});
            this.tableLayoutPanel1.SetColumnSpan(this.listViewResults, 4);
            this.listViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.GridLines = true;
            this.listViewResults.HideSelection = false;
            this.listViewResults.Location = new System.Drawing.Point(3, 213);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(678, 123);
            this.listViewResults.TabIndex = 3;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFile
            // 
            this.columnHeaderFile.Text = "Файл";
            this.columnHeaderFile.Width = 100;
            // 
            // columnHeaderField
            // 
            this.columnHeaderField.Text = "Строка";
            this.columnHeaderField.Width = 100;
            // 
            // columnHeaderText
            // 
            this.columnHeaderText.Text = "Текст";
            this.columnHeaderText.Width = 300;
            // 
            // progressBarFind
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBarFind, 4);
            this.progressBarFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBarFind.Location = new System.Drawing.Point(3, 184);
            this.progressBarFind.Name = "progressBarFind";
            this.progressBarFind.Size = new System.Drawing.Size(678, 23);
            this.progressBarFind.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarFind.TabIndex = 4;
            // 
            // buttonFind
            // 
            this.buttonFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFind.Image = global::eu4NET.Properties.Resources.find;
            this.buttonFind.Location = new System.Drawing.Point(3, 132);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(94, 23);
            this.buttonFind.TabIndex = 5;
            this.buttonFind.Text = "Найти";
            this.buttonFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // comboBoxFind
            // 
            this.comboBoxFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFind.FormattingEnabled = true;
            this.comboBoxFind.Items.AddRange(new object[] {
            "Везде",
            "В тексте",
            "В именах строк"});
            this.comboBoxFind.Location = new System.Drawing.Point(103, 132);
            this.comboBoxFind.Name = "comboBoxFind";
            this.comboBoxFind.Size = new System.Drawing.Size(114, 21);
            this.comboBoxFind.TabIndex = 6;
            // 
            // checkBoxCurrent
            // 
            this.checkBoxCurrent.AutoSize = true;
            this.checkBoxCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCurrent.Location = new System.Drawing.Point(343, 132);
            this.checkBoxCurrent.Name = "checkBoxCurrent";
            this.checkBoxCurrent.Size = new System.Drawing.Size(338, 23);
            this.checkBoxCurrent.TabIndex = 7;
            this.checkBoxCurrent.Text = "Искать только в файле";
            this.checkBoxCurrent.UseVisualStyleBackColor = true;
            // 
            // comboBoxEnru
            // 
            this.comboBoxEnru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEnru.FormattingEnabled = true;
            this.comboBoxEnru.Items.AddRange(new object[] {
            "Во всех файлах",
            "В оригинальных",
            "В редактируемых"});
            this.comboBoxEnru.Location = new System.Drawing.Point(223, 132);
            this.comboBoxEnru.Name = "comboBoxEnru";
            this.comboBoxEnru.Size = new System.Drawing.Size(114, 21);
            this.comboBoxEnru.TabIndex = 8;
            this.comboBoxEnru.SelectedIndexChanged += new System.EventHandler(this.comboBoxEnru_SelectedIndexChanged);
            // 
            // FormFindText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFindText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Найти текст (во всех файлах)";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ColumnHeader columnHeaderFile;
        private System.Windows.Forms.ColumnHeader columnHeaderField;
        private System.Windows.Forms.ColumnHeader columnHeaderText;
        private System.Windows.Forms.ProgressBar progressBarFind;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.ComboBox comboBoxFind;
        private System.Windows.Forms.CheckBox checkBoxCurrent;
        private System.Windows.Forms.ComboBox comboBoxEnru;
        private System.Windows.Forms.CheckBox checkBoxCase;
    }
}