using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using System.Text;

namespace eu4NET
{
    public partial class FormFindText : Form
    {
        public class Result
        {
            public string file;
            public string field;
            public ListViewItem item;

            public Result(string file, string field, ListViewItem item)
            {
                this.file = file;
                this.field = field;
                this.item = item;
            }
        }

        MainForm main;

        List<string> files;
        List<Result> results;

        string currentFile;
        string pathToLocalisation;

        public FormFindText()
        {
            InitializeComponent();

            Localize();

            listViewResults.ItemActivate += listViewResults_ItemActivate;
            this.FormClosing += onFormClosing;

            results = new List<Result>();

            comboBoxFind.SelectedIndex = 0;
            comboBoxEnru.SelectedIndex = 0;

            listViewResults.ColumnClick += listViewResults_ColumnClick;
        }

        void Localize()
        {
            Text = MainForm.appLocalisationStrings["formFind_caption"];
            buttonFind.Text = MainForm.appLocalisationStrings["formFind_buttonFind"];
            checkBoxCurrent.Text = MainForm.appLocalisationStrings["formFind_findInFile"];
            checkBoxCase.Text = MainForm.appLocalisationStrings["formFind_case"];

            columnHeaderFile.Text = MainForm.appLocalisationStrings["formFind_columnFile"];
            columnHeaderField.Text = MainForm.appLocalisationStrings["formFind_columnString"];
            columnHeaderText.Text = MainForm.appLocalisationStrings["formFind_columnText"];

            comboBoxFind.Items[0] = MainForm.appLocalisationStrings["formFind_comboBoxFind0"];
            comboBoxFind.Items[1] = MainForm.appLocalisationStrings["formFind_comboBoxFind1"];
            comboBoxFind.Items[2] = MainForm.appLocalisationStrings["formFind_comboBoxFind2"];

            comboBoxEnru.Items[0] = MainForm.appLocalisationStrings["formFind_comboBoxEnru0"];
            comboBoxEnru.Items[1] = MainForm.appLocalisationStrings["formFind_comboBoxEnru1"];
            comboBoxEnru.Items[2] = MainForm.appLocalisationStrings["formFind_comboBoxEnru2"];
        }
        
        public void Setup(List<string> ymlFilesEN, string currentFile, MainForm main)
        {
            files = ymlFilesEN;
            this.main = main;

            if (!currentFile.EndsWith("yml"))
            {
                pathToLocalisation = currentFile;
                currentFile = null;
            }

            if (!String.IsNullOrEmpty(currentFile))
            {
                checkBoxCurrent.Enabled = true;
                this.currentFile = currentFile;

                string filelang = Path.GetFileName(currentFile);

                if (comboBoxEnru.SelectedIndex == 0)
                {
                    filelang = filelang.Replace("_" + main.originalTranslation, "_*");
                }
                else if (comboBoxEnru.SelectedIndex == 2)
                {
                    filelang = filelang.Replace("_l_" + main.originalTranslation, "_l_" + main.editTranslation);
                }

                checkBoxCurrent.Text = MainForm.appLocalisationStrings["formFind_findInCurrentFile"] + " (" + filelang + ")";
            }
            else
            {
                checkBoxCurrent.Checked = false;
                checkBoxCurrent.Enabled = false;

                checkBoxCurrent.Text = MainForm.appLocalisationStrings["formFind_openToFindInFile"];
            }
        }

        void FindProcedure()
        {
            statusLabel.Text = MainForm.appLocalisationStrings["formFind_searching"];

            listViewResults.Items.Clear();
            results.Clear();

            listViewResults.BeginUpdate();

            progressBarFind.Maximum = files.Count;

            if (checkBoxCurrent.Checked)
            {
                FindInFile(currentFile.Replace("_l_" + main.editTranslation, "_l_" + main.originalTranslation));
                FindInFile(currentFile.Replace("_l_" + main.originalTranslation, "_l_" + main.editTranslation));
            }
            else
            {
                foreach (string file in files)
                {
                    string en = file.Replace("_l_" + main.editTranslation, "_l_" + main.originalTranslation);
                    string ru = file.Replace("_l_" + main.originalTranslation, "_l_" + main.editTranslation);

                    if (comboBoxEnru.SelectedIndex != 2) FindInFile(en);
                    if (comboBoxEnru.SelectedIndex != 1) FindInFile(ru);

                    progressBarFind.Value = files.IndexOf(file);
                }
            }

            listViewResults.EndUpdate();

            if (listViewResults.Items.Count == 0)
            {
                MessageBoxEx.Show(this, MainForm.appLocalisationStrings["formFind_noMatches"]);
                statusLabel.Text = MainForm.appLocalisationStrings["formFind_notFoundAny"];
            }
        }

        void FindInFile(string path)
        {
            int mode = comboBoxFind.SelectedIndex;//0 - везде, 1 - в тексте, 2 - в именах полей
            string raw = File.ReadAllText(path);

            char[] trim = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };
            
            int geks = 0;
            if (path.Contains("_" + main.editTranslation)) geks = main.geks;

            char[] separator = new char[] { ':' };

            using (StringReader sr = new StringReader(raw))
            {
                string line;
                bool first = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (first)
                    {
                        first = false;
                        continue;
                    }
                    
                    string[] split = line.Split(separator, 2);

                    if (split.Length < 2) continue;

                    line = TextUtils.FromChars(line, geks); // ехал костыль через костыль

                    string source;

                    switch (mode)
                    {
                        case 1:
                            source = line.Remove(0, split[0].Length);
                            break;
                        case 2:
                            source = split[0];
                            break;
                        default:
                            source = line;
                            break;
                    }

                    string q = TextUtils.FromChars(TextUtils.ToChars(textBoxFind.Text));

                    if (Regex.IsMatch(source, q, (checkBoxCase.Checked) ? RegexOptions.None : RegexOptions.IgnoreCase) ||
                        Regex.IsMatch(source, textBoxFind.Text, (checkBoxCase.Checked) ? RegexOptions.None : RegexOptions.IgnoreCase))
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = Path.GetFileName(path);
                        item.ToolTipText = path;

                        string field = split[0].TrimStart(' ');
                        
                        item.SubItems.Add(field);
                        item.SubItems.Add(TextUtils.FromChars(split[1].Trim(trim), geks));

                        results.Add(new Result(item.Text, field, item));

                        listViewResults.Items.Add(item);

                        statusLabel.Text = MainForm.appLocalisationStrings["formFind_results"] + ": " + listViewResults.Items.Count;
                    }
                }
            }
        }

        private Result FindResult(ListViewItem item)
        {
            foreach (Result r in results)
            {
                if (r.item == item) return r;
            }

            return null;
        }

        private void listViewResults_ItemActivate(Object sender, EventArgs e)
        {
            if (listViewResults.SelectedItems.Count > 0 && results.Count > 0)
            {
                Result r = FindResult(listViewResults.SelectedItems[0]);

                string path = listViewResults.SelectedItems[0].ToolTipText;
                
                main.SelectFromFind(path.Replace("_l_" + main.editTranslation, "_l_" + main.originalTranslation), r.field);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            buttonFind.Enabled = false;
            listViewResults.Enabled = false;

            FindProcedure();

            buttonFind.Enabled = true;
            listViewResults.Enabled = true;

            progressBarFind.Value = 0;
        }

        private void comboBoxEnru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(currentFile))
            {
                string filelang = Path.GetFileName(currentFile);

                if (comboBoxEnru.SelectedIndex == 0)
                {
                    filelang = filelang.Replace("_" + main.originalTranslation, "_*");
                }
                else if (comboBoxEnru.SelectedIndex == 2)
                {
                    filelang = filelang.Replace("_" + main.originalTranslation, "_" + main.editTranslation);
                }

                checkBoxCurrent.Text = MainForm.appLocalisationStrings["formFind_findInCurrentFile"] + " (" + filelang + ")";
            }
        }

        private void listViewResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listViewResults.ListViewItemSorter = new ListViewItemComparer(e.Column);
            listViewResults.Sort();
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            main.FindFormClosed();
        }
    }
}
