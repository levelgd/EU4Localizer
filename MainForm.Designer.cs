namespace eu4NET
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelEditing = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripStatusSaved = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageYmls = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewYmls = new System.Windows.Forms.ListView();
            this.ymlFilesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumStrings = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxFilterYmls = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.tabPageStrings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFilterStrings = new System.Windows.Forms.TextBox();
            this.listViewStrings = new System.Windows.Forms.ListView();
            this.columnHeaderEditing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ymlStringsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddStringEn = new System.Windows.Forms.Button();
            this.richTextBoxEN = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAddStringRu = new System.Windows.Forms.Button();
            this.richTextBoxRU = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonBookmark = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddString = new System.Windows.Forms.Button();
            this.buttonStringDelete = new System.Windows.Forms.Button();
            this.textBoxFieldName = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHr1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFindText = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHighlight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSymbols = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonBookmarkL = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBookmarkList = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBookmarkR = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonGEKS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonStdFormat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxEdit = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxLang = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxOrig = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.toolTipButton = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripBookmarks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageYmls.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPageStrings.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelInfo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 510);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelEditing,
            this.stripStatusSaved});
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelEditing
            // 
            this.statusLabelEditing.Image = global::eu4NET.Properties.Resources.exclamation;
            this.statusLabelEditing.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusLabelEditing.Name = "statusLabelEditing";
            this.statusLabelEditing.Padding = new System.Windows.Forms.Padding(1);
            this.statusLabelEditing.Size = new System.Drawing.Size(419, 18);
            this.statusLabelEditing.Text = "Для начала работы нужно выбрать папку localisation (Файл > Открыть)";
            this.statusLabelEditing.Click += new System.EventHandler(this.statusLabelEditing_Click);
            // 
            // stripStatusSaved
            // 
            this.stripStatusSaved.Image = global::eu4NET.Properties.Resources.accept;
            this.stripStatusSaved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stripStatusSaved.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stripStatusSaved.Name = "stripStatusSaved";
            this.stripStatusSaved.Size = new System.Drawing.Size(350, 18);
            this.stripStatusSaved.Spring = true;
            this.stripStatusSaved.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stripStatusSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageYmls);
            this.tabControl1.Controls.Add(this.tabPageStrings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 462);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageYmls
            // 
            this.tabPageYmls.Controls.Add(this.tableLayoutPanel2);
            this.tabPageYmls.Location = new System.Drawing.Point(4, 22);
            this.tabPageYmls.Name = "tabPageYmls";
            this.tabPageYmls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageYmls.Size = new System.Drawing.Size(770, 436);
            this.tabPageYmls.TabIndex = 0;
            this.tabPageYmls.Text = "Локализации";
            this.tabPageYmls.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.listViewYmls, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxFilterYmls, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(764, 430);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // listViewYmls
            // 
            this.listViewYmls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ymlFilesColumn,
            this.NumStrings});
            this.listViewYmls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewYmls.FullRowSelect = true;
            this.listViewYmls.GridLines = true;
            this.listViewYmls.HideSelection = false;
            this.listViewYmls.Location = new System.Drawing.Point(3, 3);
            this.listViewYmls.MultiSelect = false;
            this.listViewYmls.Name = "listViewYmls";
            this.listViewYmls.ShowItemToolTips = true;
            this.listViewYmls.Size = new System.Drawing.Size(334, 398);
            this.listViewYmls.TabIndex = 0;
            this.listViewYmls.UseCompatibleStateImageBehavior = false;
            this.listViewYmls.View = System.Windows.Forms.View.Details;
            this.listViewYmls.SelectedIndexChanged += new System.EventHandler(this.listViewYmls_SelectedIndexChanged);
            // 
            // ymlFilesColumn
            // 
            this.ymlFilesColumn.Text = "Файлы локализации";
            this.ymlFilesColumn.Width = 220;
            // 
            // NumStrings
            // 
            this.NumStrings.Text = "Строк (≈)";
            this.NumStrings.Width = 70;
            // 
            // textBoxFilterYmls
            // 
            this.textBoxFilterYmls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFilterYmls.Location = new System.Drawing.Point(3, 407);
            this.textBoxFilterYmls.Name = "textBoxFilterYmls";
            this.textBoxFilterYmls.Size = new System.Drawing.Size(334, 20);
            this.textBoxFilterYmls.TabIndex = 1;
            this.textBoxFilterYmls.TextChanged += new System.EventHandler(this.textBoxFilterYmls_TextChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.textBoxNote, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelNote, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(343, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(418, 398);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNote.Location = new System.Drawing.Point(3, 202);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(412, 193);
            this.textBoxNote.TabIndex = 0;
            this.textBoxNote.TextChanged += new System.EventHandler(this.textBoxNote_TextChanged);
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelNote.Location = new System.Drawing.Point(3, 186);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(412, 13);
            this.labelNote.TabIndex = 1;
            this.labelNote.Text = "Памятка (сохраняется автоматически)";
            this.labelNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageStrings
            // 
            this.tabPageStrings.Controls.Add(this.tableLayoutPanel3);
            this.tabPageStrings.Location = new System.Drawing.Point(4, 22);
            this.tabPageStrings.Name = "tabPageStrings";
            this.tabPageStrings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStrings.Size = new System.Drawing.Size(770, 436);
            this.tabPageStrings.TabIndex = 1;
            this.tabPageStrings.Text = "Строки";
            this.tabPageStrings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.textBoxFilterStrings, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.listViewStrings, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxFieldName, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(764, 430);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // textBoxFilterStrings
            // 
            this.textBoxFilterStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFilterStrings.Location = new System.Drawing.Point(3, 407);
            this.textBoxFilterStrings.MaxLength = 32;
            this.textBoxFilterStrings.Name = "textBoxFilterStrings";
            this.textBoxFilterStrings.Size = new System.Drawing.Size(334, 20);
            this.textBoxFilterStrings.TabIndex = 3;
            this.textBoxFilterStrings.TextChanged += new System.EventHandler(this.textBoxFilterStrings_TextChanged);
            // 
            // listViewStrings
            // 
            this.listViewStrings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderEditing,
            this.ymlStringsColumn,
            this.columnNotes});
            this.listViewStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewStrings.FullRowSelect = true;
            this.listViewStrings.GridLines = true;
            this.listViewStrings.HideSelection = false;
            this.listViewStrings.Location = new System.Drawing.Point(3, 27);
            this.listViewStrings.MultiSelect = false;
            this.listViewStrings.Name = "listViewStrings";
            this.tableLayoutPanel3.SetRowSpan(this.listViewStrings, 2);
            this.listViewStrings.Size = new System.Drawing.Size(334, 374);
            this.listViewStrings.TabIndex = 0;
            this.listViewStrings.UseCompatibleStateImageBehavior = false;
            this.listViewStrings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderEditing
            // 
            this.columnHeaderEditing.Text = "";
            this.columnHeaderEditing.Width = 16;
            // 
            // ymlStringsColumn
            // 
            this.ymlStringsColumn.Text = "Строки";
            this.ymlStringsColumn.Width = 260;
            // 
            // columnNotes
            // 
            this.columnNotes.Text = "";
            this.columnNotes.Width = 30;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.buttonAddStringEn);
            this.groupBox1.Controls.Add(this.richTextBoxEN);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(343, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оригинальный текст";
            // 
            // buttonAddStringEn
            // 
            this.buttonAddStringEn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddStringEn.Enabled = false;
            this.buttonAddStringEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddStringEn.Location = new System.Drawing.Point(3, 16);
            this.buttonAddStringEn.Name = "buttonAddStringEn";
            this.buttonAddStringEn.Size = new System.Drawing.Size(412, 166);
            this.buttonAddStringEn.TabIndex = 1;
            this.buttonAddStringEn.Text = "Такой строки нет в оригинальной локализации.";
            this.buttonAddStringEn.UseVisualStyleBackColor = true;
            this.buttonAddStringEn.Click += new System.EventHandler(this.buttonAddStringEn_Click);
            // 
            // richTextBoxEN
            // 
            this.richTextBoxEN.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBoxEN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxEN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBoxEN.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxEN.Name = "richTextBoxEN";
            this.richTextBoxEN.ReadOnly = true;
            this.richTextBoxEN.Size = new System.Drawing.Size(412, 166);
            this.richTextBoxEN.TabIndex = 0;
            this.richTextBoxEN.Text = "";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.buttonAddStringRu);
            this.groupBox2.Controls.Add(this.richTextBoxRU);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Help;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(343, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 183);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Перевод";
            this.toolTipButton.SetToolTip(this.groupBox2, "Изменения сохраняются автоматически при выборе другой строки");
            // 
            // buttonAddStringRu
            // 
            this.buttonAddStringRu.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonAddStringRu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddStringRu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddStringRu.Location = new System.Drawing.Point(3, 16);
            this.buttonAddStringRu.Name = "buttonAddStringRu";
            this.buttonAddStringRu.Size = new System.Drawing.Size(412, 164);
            this.buttonAddStringRu.TabIndex = 1;
            this.buttonAddStringRu.Text = "Такой строки нет в редактируемой локализации.\r\nНажмите чтоб добавить";
            this.buttonAddStringRu.UseVisualStyleBackColor = true;
            this.buttonAddStringRu.Click += new System.EventHandler(this.buttonAddStringRu_Click);
            // 
            // richTextBoxRU
            // 
            this.richTextBoxRU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxRU.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxRU.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxRU.Name = "richTextBoxRU";
            this.richTextBoxRU.Size = new System.Drawing.Size(412, 164);
            this.richTextBoxRU.TabIndex = 0;
            this.richTextBoxRU.Text = "";
            this.richTextBoxRU.Leave += new System.EventHandler(this.richTextBoxRU_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonBookmark);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(340, 404);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(26, 26);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // buttonBookmark
            // 
            this.buttonBookmark.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBookmark.Image = global::eu4NET.Properties.Resources.bookmark_gray;
            this.buttonBookmark.Location = new System.Drawing.Point(0, 0);
            this.buttonBookmark.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBookmark.Name = "buttonBookmark";
            this.buttonBookmark.Size = new System.Drawing.Size(26, 26);
            this.buttonBookmark.TabIndex = 1;
            this.buttonBookmark.UseVisualStyleBackColor = true;
            this.buttonBookmark.Click += new System.EventHandler(this.buttonBookmark_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.buttonAddString);
            this.flowLayoutPanel2.Controls.Add(this.buttonStringDelete);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(340, 24);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // buttonAddString
            // 
            this.buttonAddString.Image = global::eu4NET.Properties.Resources.add;
            this.buttonAddString.Location = new System.Drawing.Point(2, 0);
            this.buttonAddString.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.buttonAddString.Name = "buttonAddString";
            this.buttonAddString.Size = new System.Drawing.Size(24, 24);
            this.buttonAddString.TabIndex = 0;
            this.toolTipButton.SetToolTip(this.buttonAddString, "Добавить строку");
            this.buttonAddString.UseVisualStyleBackColor = true;
            this.buttonAddString.Click += new System.EventHandler(this.buttonAddString_Click);
            // 
            // buttonStringDelete
            // 
            this.buttonStringDelete.Image = global::eu4NET.Properties.Resources.delete;
            this.buttonStringDelete.Location = new System.Drawing.Point(28, 0);
            this.buttonStringDelete.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.buttonStringDelete.Name = "buttonStringDelete";
            this.buttonStringDelete.Size = new System.Drawing.Size(24, 24);
            this.buttonStringDelete.TabIndex = 1;
            this.toolTipButton.SetToolTip(this.buttonStringDelete, "Удалить строку");
            this.buttonStringDelete.UseVisualStyleBackColor = true;
            this.buttonStringDelete.Click += new System.EventHandler(this.buttonStringDelete_Click);
            // 
            // textBoxFieldName
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.textBoxFieldName, 2);
            this.textBoxFieldName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFieldName.Location = new System.Drawing.Point(342, 2);
            this.textBoxFieldName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFieldName.Name = "textBoxFieldName";
            this.textBoxFieldName.Size = new System.Drawing.Size(420, 20);
            this.textBoxFieldName.TabIndex = 6;
            this.textBoxFieldName.TextChanged += new System.EventHandler(this.textBoxFieldName_TextChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo.Location = new System.Drawing.Point(3, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Padding = new System.Windows.Forms.Padding(3);
            this.labelInfo.Size = new System.Drawing.Size(778, 19);
            this.labelInfo.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemEdit,
            this.MenuItemTools,
            this.MenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSave,
            this.MenuItemOpen,
            this.menuItemClose,
            this.MenuHr1,
            this.MenuItemQuit});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(48, 20);
            this.MenuItemFile.Text = "Файл";
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Image = global::eu4NET.Properties.Resources.disk;
            this.MenuItemSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemSave.Size = new System.Drawing.Size(172, 22);
            this.MenuItemSave.Text = "Сохранить";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Image = global::eu4NET.Properties.Resources.folder;
            this.MenuItemOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.ShortcutKeyDisplayString = "";
            this.MenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemOpen.Size = new System.Drawing.Size(172, 22);
            this.MenuItemOpen.Text = "Открыть";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // menuItemClose
            // 
            this.menuItemClose.Image = global::eu4NET.Properties.Resources.door_out;
            this.menuItemClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.menuItemClose.Size = new System.Drawing.Size(172, 22);
            this.menuItemClose.Text = "Закрыть";
            this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // MenuHr1
            // 
            this.MenuHr1.Name = "MenuHr1";
            this.MenuHr1.Size = new System.Drawing.Size(169, 6);
            // 
            // MenuItemQuit
            // 
            this.MenuItemQuit.Name = "MenuItemQuit";
            this.MenuItemQuit.Size = new System.Drawing.Size(172, 22);
            this.MenuItemQuit.Text = "Выход";
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemUndo,
            this.MenuItemRedo});
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.Size = new System.Drawing.Size(59, 20);
            this.MenuItemEdit.Text = "Правка";
            // 
            // MenuItemUndo
            // 
            this.MenuItemUndo.Name = "MenuItemUndo";
            this.MenuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.MenuItemUndo.Size = new System.Drawing.Size(169, 22);
            this.MenuItemUndo.Text = "Отменить";
            this.MenuItemUndo.Click += new System.EventHandler(this.MenuItemUndo_Click);
            // 
            // MenuItemRedo
            // 
            this.MenuItemRedo.Name = "MenuItemRedo";
            this.MenuItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.MenuItemRedo.Size = new System.Drawing.Size(169, 22);
            this.MenuItemRedo.Text = "Вернуть";
            this.MenuItemRedo.Click += new System.EventHandler(this.MenuItemRedo_Click);
            // 
            // MenuItemTools
            // 
            this.MenuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFindText,
            this.MenuItemMerge});
            this.MenuItemTools.Name = "MenuItemTools";
            this.MenuItemTools.Size = new System.Drawing.Size(95, 20);
            this.MenuItemTools.Text = "Инструменты";
            // 
            // MenuItemFindText
            // 
            this.MenuItemFindText.Image = global::eu4NET.Properties.Resources.find;
            this.MenuItemFindText.Name = "MenuItemFindText";
            this.MenuItemFindText.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.MenuItemFindText.Size = new System.Drawing.Size(179, 22);
            this.MenuItemFindText.Text = "Найти текст";
            this.MenuItemFindText.Click += new System.EventHandler(this.MenuItemFindText_Click);
            // 
            // MenuItemMerge
            // 
            this.MenuItemMerge.Image = global::eu4NET.Properties.Resources.arrow_merge;
            this.MenuItemMerge.Name = "MenuItemMerge";
            this.MenuItemMerge.Size = new System.Drawing.Size(179, 22);
            this.MenuItemMerge.Text = "Слияние и экспорт";
            this.MenuItemMerge.Click += new System.EventHandler(this.MenuItemMerge_Click);
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAbout});
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.Size = new System.Drawing.Size(68, 20);
            this.MenuItemHelp.Text = "Помощь";
            // 
            // MenuItemAbout
            // 
            this.MenuItemAbout.Image = global::eu4NET.Properties.Resources.exclamation;
            this.MenuItemAbout.Name = "MenuItemAbout";
            this.MenuItemAbout.Size = new System.Drawing.Size(149, 22);
            this.MenuItemAbout.Text = "О программе";
            this.MenuItemAbout.Click += new System.EventHandler(this.MenuItemAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripSeparator1,
            this.toolStripButtonFind,
            this.toolStripSeparator2,
            this.toolStripButtonHighlight,
            this.toolStripButtonSymbols,
            this.toolStripSeparator3,
            this.toolStripButtonBookmarkL,
            this.toolStripButtonBookmarkList,
            this.toolStripButtonBookmarkR,
            this.toolStripSeparator4,
            this.toolStripButtonGEKS,
            this.toolStripSeparator5,
            this.toolStripButtonStdFormat,
            this.toolStripSeparator6,
            this.toolStripComboBoxEdit,
            this.toolStripComboBoxLang,
            this.toolStripSeparator7,
            this.toolStripLabel1,
            this.toolStripComboBoxOrig,
            this.toolStripSeparator8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::eu4NET.Properties.Resources.folder;
            this.toolStripButtonOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Открыть локализацию";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::eu4NET.Properties.Resources.disk;
            this.toolStripButtonSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Сохранить локализацию";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonFind
            // 
            this.toolStripButtonFind.CheckOnClick = true;
            this.toolStripButtonFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFind.Image = global::eu4NET.Properties.Resources.find;
            this.toolStripButtonFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFind.Name = "toolStripButtonFind";
            this.toolStripButtonFind.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFind.Text = "Найти текст";
            this.toolStripButtonFind.Click += new System.EventHandler(this.toolStripButtonFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonHighlight
            // 
            this.toolStripButtonHighlight.Checked = true;
            this.toolStripButtonHighlight.CheckOnClick = true;
            this.toolStripButtonHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHighlight.Image = global::eu4NET.Properties.Resources.highlighter;
            this.toolStripButtonHighlight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonHighlight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHighlight.Name = "toolStripButtonHighlight";
            this.toolStripButtonHighlight.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHighlight.Text = "Подсветка переменных";
            this.toolStripButtonHighlight.Click += new System.EventHandler(this.toolStripButtonHighlight_Click);
            // 
            // toolStripButtonSymbols
            // 
            this.toolStripButtonSymbols.Checked = true;
            this.toolStripButtonSymbols.CheckOnClick = true;
            this.toolStripButtonSymbols.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonSymbols.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSymbols.Image = global::eu4NET.Properties.Resources.pilcrow;
            this.toolStripButtonSymbols.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSymbols.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSymbols.Name = "toolStripButtonSymbols";
            this.toolStripButtonSymbols.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSymbols.Text = "Автозамена спецсимволов";
            this.toolStripButtonSymbols.Click += new System.EventHandler(this.toolStripButtonSymbols_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonBookmarkL
            // 
            this.toolStripButtonBookmarkL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBookmarkL.Image = global::eu4NET.Properties.Resources.arrow_left;
            this.toolStripButtonBookmarkL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBookmarkL.Name = "toolStripButtonBookmarkL";
            this.toolStripButtonBookmarkL.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBookmarkL.Text = "Предыдущая закладка";
            this.toolStripButtonBookmarkL.Click += new System.EventHandler(this.toolStripButtonBookmarkL_Click);
            // 
            // toolStripButtonBookmarkList
            // 
            this.toolStripButtonBookmarkList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBookmarkList.Image = global::eu4NET.Properties.Resources.bookmark_book;
            this.toolStripButtonBookmarkList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBookmarkList.Name = "toolStripButtonBookmarkList";
            this.toolStripButtonBookmarkList.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBookmarkList.Text = "Список закладок";
            this.toolStripButtonBookmarkList.Click += new System.EventHandler(this.toolStripButtonBookmarkList_Click);
            // 
            // toolStripButtonBookmarkR
            // 
            this.toolStripButtonBookmarkR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBookmarkR.Image = global::eu4NET.Properties.Resources.arrow_right;
            this.toolStripButtonBookmarkR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBookmarkR.Name = "toolStripButtonBookmarkR";
            this.toolStripButtonBookmarkR.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBookmarkR.Text = "Следующая закладка";
            this.toolStripButtonBookmarkR.Click += new System.EventHandler(this.toolStripButtonBookmarkR_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonGEKS
            // 
            this.toolStripButtonGEKS.CheckOnClick = true;
            this.toolStripButtonGEKS.Image = global::eu4NET.Properties.Resources.text_replace;
            this.toolStripButtonGEKS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGEKS.Name = "toolStripButtonGEKS";
            this.toolStripButtonGEKS.Size = new System.Drawing.Size(65, 22);
            this.toolStripButtonGEKS.Text = "charset";
            this.toolStripButtonGEKS.ToolTipText = "Выбор таблицы для конвертации символов";
            this.toolStripButtonGEKS.Click += new System.EventHandler(this.toolStripButtonGEKS_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator5.Visible = false;
            // 
            // toolStripButtonStdFormat
            // 
            this.toolStripButtonStdFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStdFormat.Image = global::eu4NET.Properties.Resources.std0;
            this.toolStripButtonStdFormat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonStdFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStdFormat.Name = "toolStripButtonStdFormat";
            this.toolStripButtonStdFormat.Size = new System.Drawing.Size(68, 22);
            this.toolStripButtonStdFormat.Text = "Формат локализации";
            this.toolStripButtonStdFormat.ToolTipText = resources.GetString("toolStripButtonStdFormat.ToolTipText");
            this.toolStripButtonStdFormat.Visible = false;
            this.toolStripButtonStdFormat.Click += new System.EventHandler(this.toolStripButtonStdFormat_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBoxEdit
            // 
            this.toolStripComboBoxEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBoxEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripComboBoxEdit.Name = "toolStripComboBoxEdit";
            this.toolStripComboBoxEdit.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxEdit_SelectedIndexChanged);
            // 
            // toolStripComboBoxLang
            // 
            this.toolStripComboBoxLang.AutoSize = false;
            this.toolStripComboBoxLang.Name = "toolStripComboBoxLang";
            this.toolStripComboBoxLang.Size = new System.Drawing.Size(80, 23);
            this.toolStripComboBoxLang.ToolTipText = "Язык программы";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripLabel1.Size = new System.Drawing.Size(17, 22);
            this.toolStripLabel1.Text = "→";
            // 
            // toolStripComboBoxOrig
            // 
            this.toolStripComboBoxOrig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBoxOrig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripComboBoxOrig.Name = "toolStripComboBoxOrig";
            this.toolStripComboBoxOrig.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxOrig.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxOrig_SelectedIndexChanged);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 50);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(784, 1);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(0, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(784, 1);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // contextMenuStripBookmarks
            // 
            this.contextMenuStripBookmarks.Name = "contextMenuStripBookmarks";
            this.contextMenuStripBookmarks.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripBookmarks.ShowCheckMargin = true;
            this.contextMenuStripBookmarks.ShowImageMargin = false;
            this.contextMenuStripBookmarks.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStripBookmarks.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStripBookmarks_Closing);
            this.contextMenuStripBookmarks.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripBookmarks_ItemClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EU4 Localizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageYmls.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabPageStrings.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemQuit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageYmls;
        private System.Windows.Forms.TabPage tabPageStrings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView listViewYmls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListView listViewStrings;
        private System.Windows.Forms.ColumnHeader ymlFilesColumn;
        private System.Windows.Forms.ColumnHeader ymlStringsColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBoxEN;
        private System.Windows.Forms.RichTextBox richTextBoxRU;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
        private System.Windows.Forms.ToolStripSeparator MenuHr1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.TextBox textBoxFilterYmls;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTools;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFindText;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelEditing;
        private System.Windows.Forms.ToolStripStatusLabel stripStatusSaved;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TextBox textBoxFilterStrings;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonHighlight;
        private System.Windows.Forms.ToolStripButton toolStripButtonSymbols;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTipButton;
        private System.Windows.Forms.Button buttonBookmark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBookmarks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonBookmarkL;
        private System.Windows.Forms.ToolStripButton toolStripButtonBookmarkR;
        private System.Windows.Forms.ToolStripButton toolStripButtonBookmarkList;
        private System.Windows.Forms.ColumnHeader NumStrings;
        private System.Windows.Forms.ColumnHeader columnHeaderEditing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonGEKS;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMerge;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRedo;
        private System.Windows.Forms.ToolStripButton toolStripButtonStdFormat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ColumnHeader columnNotes;
        private System.Windows.Forms.Button buttonAddStringEn;
        private System.Windows.Forms.Button buttonAddStringRu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxOrig;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLang;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button buttonAddString;
        private System.Windows.Forms.Button buttonStringDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.TextBox textBoxFieldName;
    }
}

