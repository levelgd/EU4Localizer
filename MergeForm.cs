using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eu4NET
{
    public partial class MergeForm : Form
    {
        public string source;
        public string destination;

        MainForm main;

        public MergeForm(MainForm main)
        {
            InitializeComponent();

            Localize();

            this.main = main;

            if (!string.IsNullOrEmpty(main.cfg.merged))
            {
                string[] sp = main.cfg.merged.Split('|');
                textBoxSource.Text = source = sp[0];
                textBoxDest.Text = destination = sp[1];

                buttonStart.Enabled = true;
            }
            else
            {
                buttonStart.Enabled = false;
            }
            
            progressBarMerging.Visible = false;

            comboBoxMode.SelectedIndex = 0;
        }

        void Localize()
        {
            Text = MainForm.appLocalisationStrings["formMerge_caption"];
            label1.Text = MainForm.appLocalisationStrings["formMerge_sourceFolder"];
            label2.Text = MainForm.appLocalisationStrings["formMerge_destFolder"];
            buttonStart.Text = MainForm.appLocalisationStrings["formMerge_buttonMerge"];
            buttonExport.Text = MainForm.appLocalisationStrings["formMerge_buttonExport"];
            
            label3.Text = MainForm.appLocalisationStrings["formMerge_convert"];

            comboBoxMode.Items[0] = MainForm.appLocalisationStrings["formMerge_mode0"];
            comboBoxMode.Items[1] = MainForm.appLocalisationStrings["formMerge_mode1"];
            comboBoxMode.Items[2] = MainForm.appLocalisationStrings["formMerge_mode2"];
        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (!string.IsNullOrEmpty(source)) fbd.SelectedPath = source;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                if (!fbd.SelectedPath.Contains("localisation"))
                {
                    string[] searchLocalisation = Directory.GetDirectories(fbd.SelectedPath, "localisation", SearchOption.AllDirectories);
                    if (searchLocalisation.Length == 0)
                    {
                        MessageBoxEx.Show(this, MainForm.appLocalisationStrings["mb_locNotFound"]);
                        return;
                    }
                    else
                    {
                        source = searchLocalisation[0];
                    }
                }
                else
                {
                    source = fbd.SelectedPath;
                }

                textBoxSource.Text = source;
                CheckCanStart();
            }
        }

        private void buttonDest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (!string.IsNullOrEmpty(destination)) fbd.SelectedPath = destination;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                if (!fbd.SelectedPath.Contains("localisation"))
                {
                    string[] searchLocalisation = Directory.GetDirectories(fbd.SelectedPath, "localisation", SearchOption.AllDirectories);
                    if (searchLocalisation.Length == 0)
                    {
                        MessageBoxEx.Show(this, MainForm.appLocalisationStrings["mb_locNotFound"]);
                        return;
                    }
                    else
                    {
                        destination = searchLocalisation[0];
                    }
                }
                else
                {
                    destination = fbd.SelectedPath;
                }

                textBoxDest.Text = destination;
                CheckCanStart();
            }
        }

        void CheckCanStart()
        {
            if (source.Length > 0 && source == destination)
            {
                labelInfo.Text = MainForm.appLocalisationStrings["formMerge_samePath"];
                return;
            }

            buttonStart.Enabled = (Directory.Exists(source) && Directory.Exists(destination));
        }
        
        void Merge(bool export = false)
        {
            main.cfg.merged = source + "|" + destination;

            int mode = comboBoxMode.SelectedIndex;

            Dictionary<string, string> sources = new Dictionary<string, string>();
            Dictionary<string, string> dests = new Dictionary<string, string>();

            List<string> filesSource = Directory.EnumerateFiles(source, "*_l_" + main.editTranslation + "*.yml", SearchOption.AllDirectories).ToList<string>();

            if (export)
            {
                foreach (string file in filesSource)
                {
                    File.Copy(file, file.Replace("_l_" + main.originalTranslation, "_l_" + main.editTranslation).Replace(source, destination), true);
                }
            }

            List<string> filesDest = Directory.EnumerateFiles(destination, "*_l_" + main.editTranslation + "*.yml", SearchOption.AllDirectories).ToList<string>();

            progressBarMerging.Visible = true;
            progressBarMerging.Maximum = filesSource.Count;

            foreach (string file in filesSource)
            {
                string fn = Path.GetFileName(file);
                if(!sources.ContainsKey(fn)) sources.Add(fn, file);
            }

            foreach (string file in filesDest)
            {
                string fn = Path.GetFileName(file);
                if(!dests.ContainsKey(fn)) dests.Add(fn, file);
            }
            
            int filesProcessed = 0;

            string proc = MainForm.appLocalisationStrings["formMerge_processing"];

            foreach (KeyValuePair<string, string> s in sources)
            {
                labelInfo.Text = proc + " " + s.Key + "...";
                labelInfo.Refresh();

                if (dests.ContainsKey(s.Key))
                {
                    Dictionary<string, string> destFields = new Dictionary<string, string>();

                    string[] sourceText = File.ReadAllLines(s.Value);
                    string[] destText = File.ReadAllLines(dests[s.Key]);

                    int i = 0;

                    string c = "l_" + main.editTranslation + ":";

                    char[] separator = new char[] { ':' };

                    foreach (string dt in destText)
                    {
                        if (dt.Contains(c) || !(dt.Contains("#") || dt.Contains(":"))) continue;
                        i++;

                        string[] split = dt.Split(separator, 2);

                        if (split.Length > 1)
                        {
                            string key = split[0].TrimStart(' ');
                            if (!destFields.ContainsKey(key))
                            {
                                destFields.Add(key, split[1]);
                            }
                        }
                        else
                        {
                            string sp = split[0].TrimStart(' ');
                            if (!destFields.ContainsKey(sp)) destFields.Add(sp, "");
                        }
                    }

                    i = 0;
                    foreach (string st in sourceText)
                    {
                        if (st.Contains(c) || !(st.Contains("#") || st.Contains(":"))) continue;
                        i++;

                        string[] split = st.Split(separator, 2);

                        if(split.Length > 1)
                        {
                            string field = split[0].TrimStart(' ');
                            string text = split[1];

                            string finaltext = text;
                            
                            switch (mode)
                            {
                                case 1:
                                    finaltext = TextUtils.FromChars(text, 2);
                                    break;

                                case 2:
                                    finaltext = TextUtils.ToChars(text, 2);
                                    break;
                            }

                            if (destFields.ContainsKey(field))
                            {
                                destFields[field] = finaltext;
                            }
                            else
                            {
                                destFields.Add(field, finaltext);
                            }
                        }
                        else
                        {
                            string sp = split[0].TrimStart(' ');
                            if (!destFields.ContainsKey(sp)) destFields.Add(sp, "");
                        }
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(c);

                    foreach(KeyValuePair<string, string> merged in destFields)
                    {
                        if (merged.Key.StartsWith("#"))
                        {
                            sb.AppendLine(merged.Key);
                        }
                        else
                        {
                            sb.AppendLine(" " + merged.Key + ":" + merged.Value);
                        }
                    }

                    File.WriteAllText(dests[s.Key], sb.ToString(), Encoding.UTF8);
                }

                progressBarMerging.Value = ++filesProcessed;
                progressBarMerging.Refresh();
            }

            labelInfo.Text = MainForm.appLocalisationStrings["formMerge_finish"] + " " + filesProcessed;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Merge();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Merge(true);
        }
    }
}
