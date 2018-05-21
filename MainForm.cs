using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace eu4NET
{
    public partial class MainForm : Form
    {
        public static class FormatType
        {
            public static bool addVersion = true;
            public static string Original { get { return "\n"; } }
            public static string Simple { get { return "\r\n"; } }
        }

        public class Cfg
        {
            //public string key;
            public List<string> last;
            public List<string> marks;
            public string merged;
            public string chartable;
            public List<string> langs;
            public Dictionary<string, string> notes;
            public Dictionary<string, Color> highlightRules;

            public Cfg()
            {
                langs = new List<string>();
                marks = new List<string>();
                last = new List<string>();
                notes = new Dictionary<string, string>();
                highlightRules = new Dictionary<string, Color>();
            }

            public void Save()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("# Recent folders");
                sb.AppendLine("last:");

                foreach (string l in last)
                {
                    if (Directory.Exists(l))
                    {
                        sb.AppendLine(l);
                    }
                }

                sb.AppendLine("");

                sb.AppendLine("# Marks");
                sb.AppendLine("marks:");

                foreach (string m in marks)
                {
                    sb.AppendLine(m);
                }

                sb.AppendLine("");

                sb.AppendLine("# Convert char tables");
                sb.AppendLine("chartable:");

                sb.AppendLine(chartable);

                sb.AppendLine("");

                sb.AppendLine("# Highlight rules");
                sb.AppendLine("highlight:");

                foreach (var hlr in highlightRules)
                {
                    sb.AppendLine(hlr.Key + "→" + ColorTranslator.ToHtml(hlr.Value));
                }

                sb.AppendLine("");

                sb.AppendLine("# App language");
                sb.AppendLine("language:");

                sb.AppendLine(appLocalisation);

                sb.AppendLine("");

                sb.AppendLine("# Translation languages");
                sb.AppendLine("translations:");

                foreach (string s in langs) sb.AppendLine(s);

                sb.AppendLine("");

                sb.AppendLine("# Folders path to merge/export");
                sb.AppendLine("merged:");

                sb.AppendLine(merged);

                /*sb.AppendLine("");

                sb.AppendLine("# Ключ для Яндекс.Переводчика");
                sb.AppendLine("key:");
                sb.AppendLine(key);*/

                sb.AppendLine("");

                sb.AppendLine("# Notes");
                sb.AppendLine("notes:");

                foreach (KeyValuePair<string, string> n in notes)
                {
                    if (!String.IsNullOrWhiteSpace(n.Value)) sb.AppendLine(n.Key + "|" + n.Value.Replace("\r\n", "§"));
                }

                File.WriteAllText("cfg.txt", sb.ToString());
            }
        }

        public class YamlLine
        {
            public static char[] separator = new char[] { ':' };

            public ListViewItem item;

            public string field;
            public Dictionary<string, string> text;

            public string version;

            public YamlLine(string fieldName)
            {
                text = new Dictionary<string, string>();

                field = fieldName;
            }

            public YamlLine(string line, string lang)
            {
                text = new Dictionary<string, string>();

                string[] split = line.Split(separator, 2);
                field = split[0].Trim(' ');
                if (split.Length > 1)
                {
                    version = (split[1][0] != ' ') ? split[1][0].ToString() : "";
                    text.Add(lang, Regex.Match(split[1], "\".*\"").Value.Trim('"'));
                }
            }

            public string Build(string lang)
            {
                if (text.ContainsKey(lang) && field.Length > 0)
                {
                    if (field[0] == '#') return " " + field;
                    else return " " + field + ":" + (FormatType.addVersion ? version : "") + " \"" + text[lang] + "\"" + stdFormat;
                }
                else
                {
                    return null;
                }
            }

            public static string GetVariableName(string fullLine)
            {
                string[] split = fullLine.Split(':');
                return split[0].Trim(' ');
            }

            public static string GetVariableText(string fullLine)
            {
                string[] split = fullLine.Split(separator, 2);
                if (split.Length > 1) return Regex.Match(split[1], "\".*\"").Value.Trim('"');

                return "NULL";
            }
        }

        public static string appLocalisation = "russian";
        public static Dictionary<string, string> appLocalisationStrings = new Dictionary<string, string>();

        public Cfg cfg;
        string pathToLocalisation = "";

        Color rus = Color.FromArgb(224, 255, 224);

        FormFindText formFind;
        //AutoTranslateForm translate;

        Dictionary<string, YamlLine> strings = new Dictionary<string, YamlLine>();

        List<string> ymlFilesEN;

        ListViewItem[] fullYmlsCollection;
        ListViewItem[] fullStringsCollection;

        YamlLine currentLine;
        string currentFile;

        string undo = "";
        string redo = "";

        public bool saved = true;
        public int geks = 0;
        public static string stdFormat = FormatType.Original;

        public bool columnStringsSorted = true;
        public bool columnNotesSorted = false;

        public string originalTranslation = "english";
        public string editTranslation = "russian";

        ListViewItemComparer comparer;

        //Font keyword;

        ParsingStringForm parsingStringForm;

        public MainForm()
        {
            InitializeComponent();

            listViewStrings.DoubleBuffered(true);
            listViewYmls.DoubleBuffered(true);

            groupBox1.DoubleBuffered(true);
            groupBox2.DoubleBuffered(true);
            groupBox1.Visible = false;
            groupBox2.Visible = false;

            buttonBookmark.Enabled = false;

            MenuItemRedo.Enabled = MenuItemUndo.Enabled = false;

            toolStripButtonBookmarkList.Enabled = false;
            toolStripButtonBookmarkL.Enabled = toolStripButtonBookmarkR.Enabled = false;

            /*buttonAutoTranslate.Enabled = false;
            buttonAutoTranslate.Visible = false;*/

            menuItemClose.Enabled = false;
            toolStripButtonFind.Enabled = MenuItemFindText.Enabled = false;
            toolStripButtonSave.Enabled = MenuItemSave.Enabled = false;

            listViewYmls.ItemActivate += listViewYmls_ItemActivate;
            listViewStrings.SelectedIndexChanged += listViewStrings_SelectedIndexChanged;

            richTextBoxRU.AddContextMenu();
            richTextBoxEN.AddContextMenu();

            richTextBoxRU.KeyPress += richTextBox_KeyPress;
            richTextBoxRU.TextChanged += richTextBox_Highlight;
            richTextBoxEN.TextChanged += richTextBox_Highlight;

            richTextBoxRU.ContextMenuStrip.Opening += richTextBox_ContextMenuOpening;

            comparer = new ListViewItemComparer(1);

            listViewStrings.ListViewItemSorter = comparer;
            listViewYmls.ListViewItemSorter = comparer;

            listViewStrings.ColumnClick += listViewStrings_ColumnClick;

            parsingStringForm = new ParsingStringForm();

            ReadCfg();

            if (cfg.langs.Count > 0)
            {
                originalTranslation = toolStripComboBoxOrig.Items[0].ToString();
                editTranslation = toolStripComboBoxEdit.Items[0].ToString();
            }

            toolStripComboBoxOrig.SelectedIndex = toolStripComboBoxOrig.Items.IndexOf(originalTranslation);
            toolStripComboBoxEdit.SelectedIndex = toolStripComboBoxEdit.Items.IndexOf(editTranslation);

            if (!string.IsNullOrEmpty(cfg.chartable))
            {
                toolStripButtonGEKS.Text = Path.GetFileName(cfg.chartable);
                TextUtils.SetChars(cfg.chartable);

                toolStripButtonGEKS.Checked = true;
                geks = 2;
            }

            /*byte[] from = Encoding.UTF8.GetBytes("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя");
            byte[] to = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(1251), from);
            File.WriteAllText("cp1252.txt", Encoding.GetEncoding(1252).GetString(to));*/

            LoadAppLocalisation(true);
            Localize();

            Text += " " + Updater.version;

            tabControl1.TabPages.Remove(tabPageStrings);

            Updater updater = new Updater(this);
            updater.Update();
        }
        //
        void LoadAppLocalisation(bool init = false)
        {
            if (Directory.Exists("localisation") && File.Exists("localisation/strings_l_" + appLocalisation + ".yml"))
            {
                if (init)
                {
                    string[] langs = Directory.EnumerateFiles("localisation/", "strings_l_*.yml", SearchOption.TopDirectoryOnly).ToArray<string>();

                    foreach (string lang in langs)
                    {
                        toolStripComboBoxLang.Items.Add(lang.Split('_')[2].Replace(".yml", ""));
                    }

                    toolStripComboBoxLang.SelectedItem = appLocalisation;
                    toolStripComboBoxLang.SelectedIndexChanged += toolStripComboBoxLang_SelectedIndexChanged;
                }

                string[] lines = File.ReadAllLines("localisation/strings_l_" + appLocalisation + ".yml");

                foreach (string s in lines)
                {
                    if (string.IsNullOrWhiteSpace(s) || s.IndexOf('#') > 0 || s.IndexOf(':') < 1 || s.IndexOf('"') < 1) continue;

                    string name = YamlLine.GetVariableName(s);
                    string value = YamlLine.GetVariableText(s);

                    if (!appLocalisationStrings.ContainsKey(name)) appLocalisationStrings.Add(name, value);
                    else appLocalisationStrings[name] = value;
                }
            }
        }

        void Localize()
        {
            bool needRemove = false;

            if (tabControl1.TabPages.Count < 2)
            {
                needRemove = true;
                tabControl1.TabPages.Add(tabPageStrings);
            }

            /*foreach (KeyValuePair<string, string> str in appLocalisationStrings)
            {
                Control cs = this.Controls.Find(str.Key, true).FirstOrDefault();

                if(cs != null)
                {
                    cs.Text = str.Value;
                }
                else
                {
                    try
                    {
                        ToolStripMenuItem item = menuStrip1.Items.Find(str.Key, true).OfType<ToolStripMenuItem>().Single();

                        if (item != null) item.Text = str.Value;
                    }
                    catch (Exception)
                    {

                    }
                }
            }*/

            MenuItemFile.Text = appLocalisationStrings["MenuItemFile"];
            MenuItemSave.Text = appLocalisationStrings["MenuItemSave"];
            MenuItemOpen.Text = appLocalisationStrings["MenuItemOpen"];
            menuItemClose.Text = appLocalisationStrings["MenuItemClose"];
            MenuItemQuit.Text = appLocalisationStrings["MenuItemQuit"];
            MenuItemEdit.Text = appLocalisationStrings["MenuItemEdit"];
            MenuItemUndo.Text = appLocalisationStrings["MenuItemUndo"];
            MenuItemRedo.Text = appLocalisationStrings["MenuItemUndo"];
            MenuItemTools.Text = appLocalisationStrings["MenuItemTools"];
            MenuItemFindText.Text = appLocalisationStrings["MenuItemFindText"];
            MenuItemMerge.Text = appLocalisationStrings["MenuItemMerge"];
            MenuItemHelp.Text = appLocalisationStrings["MenuItemHelp"];
            MenuItemAbout.Text = appLocalisationStrings["MenuItemAbout"];
            tabPageYmls.Text = appLocalisationStrings["tabPageYmls"];
            tabPageStrings.Text = appLocalisationStrings["tabPageStrings"];

            ymlFilesColumn.Text = appLocalisationStrings["ymlFilesColumn"];
            ymlStringsColumn.Text = appLocalisationStrings["ymlStringsColumn"];
            NumStrings.Text = appLocalisationStrings["NumStrings"];

            labelNote.Text = appLocalisationStrings["labelNote"];
            groupBox1.Text = appLocalisationStrings["groupBox1"];
            groupBox2.Text = appLocalisationStrings["groupBox2"];
            toolTipButton.SetToolTip(groupBox2, appLocalisationStrings["groupBox2_tooltip"]);
            buttonAddStringEn.Text = appLocalisationStrings["buttonAddStringEn"];
            buttonAddStringRu.Text = appLocalisationStrings["buttonAddStringRu"];

            statusLabelEditing.Text = appLocalisationStrings["statusLabelEditing"];

            toolStripButtonGEKS.ToolTipText = appLocalisationStrings["chartable_tooltip"];
            toolStripComboBoxLang.ToolTipText = appLocalisationStrings["appLang_tooltip"];

            toolStripButtonBookmarkR.Text = appLocalisationStrings["bookmark_next"];
            toolStripButtonBookmarkL.Text = appLocalisationStrings["bookmark_prev"];
            toolStripButtonBookmarkList.Text = appLocalisationStrings["bookmark_list"];
            toolStripButtonSymbols.Text = appLocalisationStrings["symbols_replace"];
            toolStripButtonHighlight.Text = appLocalisationStrings["var_highlight"];

            toolStripButtonFind.Text = appLocalisationStrings["MenuItemFindText"];
            toolStripButtonSave.Text = appLocalisationStrings["MenuItemSave"];
            toolStripButtonOpen.Text = appLocalisationStrings["MenuItemOpen"];

            toolTipButton.SetToolTip(buttonAddString, appLocalisationStrings["buttonStringAdd_tooltip"]);
            toolTipButton.SetToolTip(buttonStringDelete, appLocalisationStrings["buttonStringDelete_tooltip"]);
            
            if (tabControl1.TabPages.Count == 2 && needRemove) tabControl1.TabPages.Remove(tabPageStrings);
        }
        //
        void ReadCfg()
        {
            cfg = new Cfg();

            if (File.Exists("cfg.txt"))
            {
                char[] trim = new char[] { '\r', '\n' };
                string currentkey = "";

                List<string> lines = File.ReadAllLines("cfg.txt").ToList<string>();

                foreach (string l in lines)
                {
                    string line = l.TrimEnd(trim);

                    if (line.StartsWith("#") || line.Length < 3) continue;

                    if (line.EndsWith(":"))
                    {
                        currentkey = line;
                    }
                    else
                    {
                        switch (currentkey)
                        {
                            case "last:":
                                AddRecent(line);
                                break;
                            case "marks:":
                                string[] s = line.Split('>');
                                if (File.Exists(s[0])) AddBookmark(s[0], s[1]);
                                break;
                            case "merged:":
                                cfg.merged = line;
                                currentkey = "";
                                break;
                            case "chartable:":
                                cfg.chartable = line;
                                currentkey = "";
                                break;
                            case "highlight:":
                                string[] splitted = line.Split('→');
                                if (splitted.Length == 2 && !cfg.highlightRules.ContainsKey(splitted[0]))
                                {
                                    cfg.highlightRules.Add(splitted[0], ColorTranslator.FromHtml(splitted[1]));
                                }
                                break;
                            case "language:":
                                appLocalisation = line;
                                currentkey = "";
                                break;
                            case "translations:":
                                cfg.langs.Add(line);
                                toolStripComboBoxEdit.Items.Add(line);
                                toolStripComboBoxOrig.Items.Add(line);
                                break;
                            case "notes:":
                                string[] n = line.Split('|');
                                cfg.notes.Add(n[0], n[1].Replace("§", "\r\n"));
                                break;

                        }
                    }
                }
            }
            /*else
            {
                Console.WriteLine(Path.GetFullPath("cfg.txt") + " не найден");
            }*/

            if (cfg.marks.Count > 0)
            {
                toolStripButtonBookmarkList.Enabled = true;
                toolStripButtonBookmarkL.Enabled = toolStripButtonBookmarkR.Enabled = true;
            }

            /*if (string.IsNullOrEmpty(cfg.chartable))
            {
                cfg.chartable = Application.StartupPath + "\\chartables\\geks_rus.txt";
            }*/
        }

        void AddRecent(string line)
        {
            if (cfg != null) cfg.last.Add(line);
            MenuItemOpen.DropDownItems.Add(line);
            MenuItemOpen.DropDownItems[MenuItemOpen.DropDownItems.Count - 1].Click += MenuItemRecent_Click;
            if (!MenuItemOpen.Enabled) MenuItemOpen.Enabled = true;
        }

        void AddBookmark(string file, string field)
        {
            string name = file + ">" + field;
            if (!cfg.marks.Contains(name)) cfg.marks.Add(name);

            if (!String.IsNullOrEmpty(pathToLocalisation)) name = name.Replace(pathToLocalisation + "\\", "");

            ToolStripMenuItem menuitem = new ToolStripMenuItem(name.Replace(">", " > "));

            contextMenuStripBookmarks.Items.Add(menuitem);
        }

        void RemoveBookmark(string mark)
        {
            string name = mark;

            if (!mark.Contains("\\"))
            {
                mark = pathToLocalisation + mark;
            }

            if (cfg.marks.Contains(mark))
            {
                contextMenuStripBookmarks.Items.RemoveAt(cfg.marks.IndexOf(mark));

                cfg.marks.Remove(mark);

                if (cfg.marks.Count == 0)
                {
                    toolStripButtonBookmarkList.Enabled = false;
                    toolStripButtonBookmarkL.Enabled = toolStripButtonBookmarkR.Enabled = false;
                }
            }
        }

        void SelectBookmark(string mark)
        {
            string[] s = mark.Split('>');

            s[0] = s[0].TrimEnd(' ');
            s[1] = s[1].TrimStart(' ');

            if (!s[0].Contains("\\")) s[0] = pathToLocalisation + "\\" + s[0];

            SelectFromFind(s[0], s[1]);
        }

        //
        // Формирование списка строк
        //
        void ParseYml(string path)
        {
            currentFile = path;

            listViewStrings.Items.Clear();

            strings.Clear();

            //fullYmlsCollection = null;
            fullStringsCollection = null;

            List<string> lines = File.ReadAllLines(currentFile).ToList<string>();

            parsingStringForm.Text = appLocalisationStrings["parsingStringForm_loading"];
            parsingStringForm.Show();
            parsingStringForm.CenterAtParent(this);
            parsingStringForm.Activate();
            parsingStringForm.InitProgressBar(lines.Count);

            listViewStrings.BeginUpdate();

            int i = 0;
            bool firstLine = true;

            foreach (string l in lines)
            {
                i++;
                if (firstLine) { firstLine = false; continue; }

                if (string.IsNullOrWhiteSpace(l) || l.IndexOf('#') > 0 || l.IndexOf(':') < 1) continue;

                //if (yl.field[0] == '#') continue;//comment

                YamlLine yl = new YamlLine(l, originalTranslation);

                if (!strings.ContainsKey(yl.field))
                {
                    strings.Add(yl.field, yl);

                    ListViewItem item = new ListViewItem();
                    item.Text = "";
                    yl.item = item;

                    item.SubItems.Add(yl.field);

                    listViewStrings.Items.Add(item);

                    parsingStringForm.SetProgress(i);
                }
            }

            fullStringsCollection = new ListViewItem[listViewStrings.Items.Count];
            listViewStrings.Items.CopyTo(fullStringsCollection, 0);

            lines = File.ReadAllLines(currentFile.Replace("_l_" + originalTranslation, "_l_" + editTranslation)).ToList<string>();

            firstLine = true;

            foreach (string l in lines)
            {
                if (firstLine) { firstLine = false; continue; }

                if (string.IsNullOrWhiteSpace(l) || l.IndexOf('#') > 0 || l.IndexOf(':') < 1) continue;

                string ln = YamlLine.GetVariableName(l);

                if (strings.ContainsKey(ln))
                {
                    if (strings[ln].text.ContainsKey(editTranslation))
                    {
                        strings[ln].text[editTranslation] = YamlLine.GetVariableText(l);
                    }
                    else
                    {
                        strings[ln].text.Add(editTranslation, YamlLine.GetVariableText(l));
                    }
                }
                else
                {
                    YamlLine yl = new YamlLine(l, editTranslation);
                    string f = yl.field;
                    strings.Add(f, yl);

                    ListViewItem item = new ListViewItem();
                    item.Text = "";
                    yl.item = item;

                    item.SubItems.Add(yl.field);

                    listViewStrings.Items.Add(item);
                }

                strings[ln].item.BackColor = SystemColors.Window;

                if (cfg.highlightRules.Count > 0)
                {
                    foreach (var hl in cfg.highlightRules)
                    {
                        if (TextUtils.ContainRu(TextUtils.FromChars(strings[ln].text[editTranslation], geks), hl.Key))
                        {
                            strings[ln].item.BackColor = hl.Value;
                        }
                    }
                }
            }

            comparer.SetColumn(1);
            listViewStrings.ListViewItemSorter = comparer;
            listViewStrings.Sort();

            listViewStrings.EndUpdate();

            FindUniqueStrings();

            parsingStringForm.Hide();

            toolStripButtonSave.Enabled = MenuItemSave.Enabled = true;

            foreach (ToolStripMenuItem item in contextMenuStripBookmarks.Items)
            {
                item.Text = item.Text.Replace(pathToLocalisation + "\\", "");
            }
        }

        //
        // Открыть папку localisation
        //
        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult r = DialogExitWOSaving();
                if (r == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (MenuItemOpen.DropDown.Items.Contains(sender as ToolStripMenuItem))
            {
                pathToLocalisation = sender.ToString();
                OpenLocalisation();
                return;
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = appLocalisationStrings["chooseLocFolder"];
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                if (!fbd.SelectedPath.Contains("localisation"))
                {
                    string[] searchLocalisation = Directory.GetDirectories(fbd.SelectedPath, "localisation", SearchOption.AllDirectories);
                    if (searchLocalisation.Length == 0)
                    {
                        MessageBoxEx.Show(this, appLocalisationStrings["mb_locNotFound"]);
                        return;
                    }
                    else
                    {
                        MessageBoxEx.Show(this, appLocalisationStrings["mb_locFound"] + ":\n" + searchLocalisation[0]);
                        pathToLocalisation = searchLocalisation[0];
                    }
                }
                else
                {
                    pathToLocalisation = fbd.SelectedPath;
                }

                OpenLocalisation();
            }
        }

        void OpenLocalisation()
        {
            if (formFind != null)
            {
                formFind.Close();
            }

            if (!Directory.Exists(pathToLocalisation))
            {
                MessageBoxEx.Show(this, appLocalisationStrings["mb_chooseNotFound"]);

                foreach (ToolStripItem i in MenuItemOpen.DropDownItems)
                {
                    if (i.Text == pathToLocalisation)
                    {
                        MenuItemOpen.DropDownItems.Remove(i);
                        break;
                    }
                }

                MenuItemOpen_Click(MenuItemOpen, null);
                return;
            }

            menuItemClose.Enabled = true;

            toolStripComboBoxOrig.Enabled = false;
            toolStripComboBoxEdit.Enabled = false;

            ymlFilesEN = Directory.EnumerateFiles(pathToLocalisation, "*_" + originalTranslation + "*.yml", SearchOption.AllDirectories).ToList<string>();

            if (ymlFilesEN.Count > 0)
            {
                parsingStringForm.Text = appLocalisationStrings["parsingStringForm_loadingFiles"];
                parsingStringForm.Show();
                parsingStringForm.CenterAtParent(this);
                parsingStringForm.Activate();
                parsingStringForm.InitProgressBar(ymlFilesEN.Count);

                //string zipPath = Directory.GetParent(pathToLocalisation).FullName + "\\localisation_backup.zip";

                //if (File.Exists(zipPath)) File.Delete(zipPath);
                //backup
                //ZipFile.CreateFromDirectory(pathToLocalisation, Directory.GetParent(pathToLocalisation).FullName + "\\localisation_backup.zip");// + DateTime.Now.ToString("dd.MM.yy HH-mm-ss") + ").zip"

                if (cfg != null && !cfg.last.Contains(pathToLocalisation))
                {
                    AddRecent(pathToLocalisation);
                }

                groupBox1.Visible = false;
                groupBox2.Visible = false;

                //buttonAutoTranslate.Enabled = false;

                tabControl1.SelectTab(0);

                if (tabControl1.TabPages.Count == 2) tabControl1.TabPages.Remove(tabPageStrings);

                currentFile = null;
                currentLine = null;

                fullYmlsCollection = null;
                fullStringsCollection = null;

                toolStripButtonFind.Enabled = MenuItemFindText.Enabled = true;

                listViewYmls.Items.Clear();
                listViewYmls.BeginUpdate();

                int i = 0;

                foreach (string file in ymlFilesEN)
                {
                    string copy = file.Replace("_l_" + originalTranslation, "_l_" + editTranslation);

                    if (!File.Exists(copy))
                    {
                        string changeHeader = File.ReadAllText(file);
                        File.WriteAllText(copy, changeHeader.Replace("l_" + originalTranslation + ":", "l_" + editTranslation + ":"), Encoding.UTF8);
                    }

                    ListViewItem item = new ListViewItem();
                    item.Text = Path.GetFileName(file);

                    item.ToolTipText = file;

                    item.SubItems.Add((File.ReadAllLines(file).Length - 1).ToString());

                    listViewYmls.Items.Add(item);

                    if (cfg.notes.ContainsKey(file))
                    {
                        item.BackColor = Color.Yellow;
                    }

                    parsingStringForm.SetProgress(i++);
                }

                comparer.SetColumn(0);
                listViewYmls.ListViewItemSorter = comparer;
                listViewYmls.Sort();

                listViewYmls.EndUpdate();

                fullYmlsCollection = new ListViewItem[listViewYmls.Items.Count];
                listViewYmls.Items.CopyTo(fullYmlsCollection, 0);

                parsingStringForm.Hide();

                statusLabelEditing.Image = Properties.Resources.exclamation;
                statusLabelEditing.Text = appLocalisationStrings["status_edit"];
            }
            else
            {
                MessageBoxEx.Show(this, appLocalisationStrings["mb_notFoundInFolder"] + "\n" + pathToLocalisation, appLocalisationStrings["mb_locFilesNotFound"]);
                menuItemClose_Click(null, null);
            }
        }

        public void FindFormClosed()
        {
            toolStripButtonFind.Checked = false;
        }

        //
        // Выбрать из результатов окна поиска
        //
        public void SelectFromFind(string file, string field)
        {
            if (String.IsNullOrEmpty(pathToLocalisation))
            {
                pathToLocalisation = file.Replace("\\" + Path.GetFileName(file), "");
                OpenLocalisation();
            }

            if (currentFile != file)
            {
                saved = true;
                ParseYml(file);
            }

            if (tabControl1.TabCount == 1)
            {
                tabControl1.TabPages.Add(tabPageStrings);
            }

            tabControl1.SelectTab(1);

            if (listViewStrings.SelectedItems.Count == 0 || listViewStrings.SelectedItems[0].Text != field)
            {
                ListViewItem i = listViewStrings.FindItemWithText(field);
                i.Selected = true;
                i.EnsureVisible();
            }

        }

        //
        // Выбор yml файла для редактирования
        //
        private void listViewYmls_ItemActivate(Object sender, EventArgs e)
        {
            if (listViewYmls.SelectedItems.Count > 0)
            {
                if (!saved)
                {
                    DialogResult r = DialogExitWOSaving();
                    if (r == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                currentLine = null;
                richTextBoxEN.Clear();
                richTextBoxRU.Clear();

                if (tabControl1.TabCount == 1)
                {
                    tabControl1.TabPages.Add(tabPageStrings);
                }

                ParseYml(listViewYmls.SelectedItems[0].ToolTipText);

                tabControl1.SelectTab(1);

                LabelEditText(true);
            }

            if (formFind != null)
            {
                formFind.Setup(ymlFilesEN, currentFile, this);
            }
        }

        //
        // Выбор Строки для редактирования
        //
        private void listViewStrings_SelectedIndexChanged(Object sender, EventArgs e)
        {
            SaveField();

            if (listViewStrings.SelectedItems.Count > 0)
            {
                string s = listViewStrings.SelectedItems[0].SubItems[1].Text;

                OpenField(s);
            }
        }
        //
        void OpenField(string s, Object sender = null, EventArgs e = null)
        {
            if (!groupBox1.Visible) groupBox1.Visible = true;
            if (!groupBox2.Visible) groupBox2.Visible = true;
            //if (!buttonAutoTranslate.Enabled) buttonAutoTranslate.Enabled = true;

            if (currentLine != null)
            {
                if (cfg.marks.Contains(currentFile + ">" + currentLine.field))
                {
                    currentLine.item.BackColor = Color.Orange;
                }

                currentLine.item.Text = "";
            }

            if (strings.ContainsKey(s))
            {
                currentLine = strings[s];

                if (strings[s].text.ContainsKey(originalTranslation))
                {
                    buttonAddStringEn.Visible = false;
                    SetEN(strings[s].text[originalTranslation]);
                }
                else //строчка есть только на русском
                {
                    //SetEN("");
                    buttonAddStringEn.Visible = true;
                }

                if (strings[s].text.ContainsKey(editTranslation))
                {
                    buttonAddStringRu.Visible = false;

                    richTextBoxRU.TextChanged -= richTextBoxRU_TextChanged;

                    SetRU(TextUtils.FromChars(strings[s].text[editTranslation], geks));
                    undo = GetRU();

                    richTextBoxRU.TextChanged += richTextBoxRU_TextChanged;
                }
                else // строчка есть только на английском
                {
                    //SetRU("");
                    buttonAddStringRu.Visible = true;
                }

                textBoxFieldName.ForeColor = SystemColors.WindowText;
                textBoxFieldName.Text = currentLine.field;
            }

            currentLine.item.Text = "●";

            statusLabelEditing.Text = ((!String.IsNullOrEmpty(currentFile)) ? appLocalisationStrings["status_editing"] + Path.GetFileName(currentFile.Replace("_l_" + originalTranslation, "_l_" + editTranslation)) : "") +
                ((currentLine != null) ? " > " + currentLine.field : "");

            if (statusLabelEditing.Image != Properties.Resources.page_white_edit)
                statusLabelEditing.Image = Properties.Resources.page_white_edit;

            buttonBookmark.Enabled = true;

            if (cfg == null) return;

            if (cfg.marks.Contains(currentFile + ">" + currentLine.field))
            {
                buttonBookmark.Image = Properties.Resources.bookmark;
            }
            else
            {
                buttonBookmark.Image = Properties.Resources.bookmark_gray;
            }


            string n = currentFile.Replace(pathToLocalisation + "\\", "") + " > " + currentLine.field;

            foreach (ToolStripMenuItem item in contextMenuStripBookmarks.Items)
            {
                item.Checked = item.Text.Contains(n);
            }
        }

        void LabelEditText(bool saved)
        {
            if (this.saved == saved) return;

            this.saved = saved;

            if (saved)
            {
                stripStatusSaved.Text = "";
                stripStatusSaved.Image = Properties.Resources.accept;
            }
            else
            {
                stripStatusSaved.Text = "(" + appLocalisationStrings["stripStatusSaved_notSaved"] + ")";
                stripStatusSaved.Image = Properties.Resources.cross;
            }

            stripStatusSaved.Text = (!saved) ? " (" + appLocalisationStrings["stripStatusSaved_notSaved"] + ")" : "";
        }

        void SaveField(bool changeItemColor = true)
        {
            if (currentLine != null)
            {
                if (currentLine.text.ContainsKey(editTranslation))
                {
                    string newtextRu = TextUtils.ToChars(GetRU(), geks);

                    if (newtextRu != currentLine.text[editTranslation])
                    {
                        currentLine.text[editTranslation] = newtextRu;
                        LabelEditText(false);
                    }

                    /*if (changeItemColor && TextUtils.ContainRu(GetRU(), cfg.checkMatch)) currentLine.item.BackColor = rus;
                    else currentLine.item.BackColor = SystemColors.Window;*/

                    if (changeItemColor)
                    {
                        currentLine.item.BackColor = SystemColors.Window;

                        if (cfg.highlightRules.Count > 0)
                        {
                            foreach (var hl in cfg.highlightRules)
                            {
                                if (TextUtils.ContainRu(GetRU(), hl.Key))
                                {
                                    currentLine.item.BackColor = hl.Value;
                                }
                            }
                        }
                    }
                }
            }
        }

        //
        // сохранить файл
        //
        void SaveYml()
        {
            if (currentLine != null)
            {
                SaveField();
            }

            string tosave = currentFile.Replace("_l_" + originalTranslation, "_l_" + editTranslation);

            if (!String.IsNullOrEmpty(tosave))
            {
                if (File.Exists(tosave))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("l_" + editTranslation + ":" + stdFormat);

                    foreach (KeyValuePair<string, YamlLine> line in strings)
                    {
                        string l = line.Value.Build(editTranslation);
                        if (l != null) sb.Append(l);
                    }

                    File.WriteAllText(tosave, sb.ToString(), Encoding.UTF8);

                    LabelEditText(true);

                    MessageBoxEx.Show(this, appLocalisationStrings["loc_file"] + " " + Path.GetFileName(tosave) + " " + appLocalisationStrings["saved"]);
                }
                else
                {
                    MessageBoxEx.Show(this, appLocalisationStrings["file0"] + " " + tosave + " " + appLocalisationStrings["err_pathNotExist"]);
                }
            }
            else
            {
                MessageBoxEx.Show(this, appLocalisationStrings["mb_locNotChoosed"]);
            }
        }

        private void richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            int start = rtb.SelectionStart;

            switch (e.KeyChar)
            {
                /*case (char)13:
                    rtb.Suspend();
                    rtb.Text = rtb.Text.Insert(rtb.SelectionStart, "\\n");
                    rtb.Text = rtb.Text.Replace("\n", "");

                    rtb.SelectionStart = start + 1;
                    e.Handled = true;
                    rtb.Resume();
                    break;*/

                case '"':
                    rtb.Suspend();
                    rtb.Text = rtb.Text.Insert(rtb.SelectionStart, "\\\"");

                    rtb.SelectionStart = start + 2;
                    e.Handled = true;
                    rtb.Resume();
                    break;
            }
        }

        private void richTextBox_Highlight(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            rtb.Suspend();

            int st = rtb.SelectionStart;

            rtb.Select(0, rtb.TextLength);
            rtb.SelectionColor = SystemColors.WindowText;

            Highlight(rtb, "\\$.*?\\$", Color.Blue);
            Highlight(rtb, "\\[.*?\\]", Color.Green);

            rtb.Select(st, 0);
            rtb.Resume();
        }

        void Highlight(RichTextBox rtb, string reg, Color color)
        {
            MatchCollection mc = Regex.Matches(rtb.Text, reg);

            if (mc.Count > 0)
            {
                foreach (Match m in mc)
                {
                    rtb.Select(m.Index, m.Length);
                    rtb.SelectionColor = color;
                }
            }
        }

        void SetRU(string text)
        {
            richTextBoxRU.Text = text.Replace("\\n", "\n");
        }

        string GetRU()
        {
            return richTextBoxRU.Text.Replace("\n", "\\n");
        }

        void SetEN(string text)
        {
            richTextBoxEN.Text = text.Replace("\\n", "\n");
        }

        string GetEN()
        {
            return richTextBoxEN.Text.Replace("\n", "\\n");
        }

        /*protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                if (richTextBoxRU.Focused)
                {
                    redo = richTextBoxRU.Text;
                    richTextBoxRU.Text = undo;
                }

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }*/

        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            SaveYml();
        }

        private void MenuItemFindText_Click(object sender, EventArgs e)
        {
            formFind = new FormFindText();

            if (String.IsNullOrEmpty(currentFile)) formFind.Setup(ymlFilesEN, pathToLocalisation, this);
            else formFind.Setup(ymlFilesEN, currentFile, this);
            formFind.Show(this);

            toolStripButtonFind.Checked = true;
        }

        private void statusLabelEditing_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(currentFile))
            {
                string folderPath = currentFile.Substring(0, currentFile.Length - Path.GetFileName(currentFile).Length);

                if (Directory.Exists(folderPath))
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + currentFile.Replace("_l_" + originalTranslation, "_l_" + editTranslation) + "\"");
                }
            }
        }

        private void textBoxFilterYmls_TextChanged(object sender, EventArgs e)
        {
            if (fullYmlsCollection == null || listViewYmls.Items.Count == 0) return;

            listViewYmls.BeginUpdate();

            listViewYmls.Items.Clear();
            listViewYmls.Items.AddRange(fullYmlsCollection);

            string t = textBoxFilterYmls.Text;

            if (t.Length > 0)
            {
                foreach (ListViewItem item in listViewYmls.Items)
                {
                    if (!item.Text.StartsWith(t))
                    {
                        listViewYmls.Items.Remove(item);
                    }
                }
            }

            listViewYmls.EndUpdate();
        }

        private void textBoxFilterStrings_TextChanged(object sender, EventArgs e)
        {
            if (fullStringsCollection == null || listViewStrings.Items.Count == 0) return;

            listViewStrings.BeginUpdate();

            listViewStrings.Items.Clear();
            listViewStrings.Items.AddRange(fullStringsCollection);

            string t = textBoxFilterStrings.Text;

            if (t.Length > 0)
            {
                foreach (ListViewItem item in listViewStrings.Items)
                {
                    if (!item.SubItems[1].Text.StartsWith(t))
                    {
                        listViewStrings.Items.Remove(item);
                    }
                }
            }

            listViewStrings.EndUpdate();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            MenuItemOpen_Click(sender, e);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            MenuItemSave_Click(sender, e);
        }

        private void toolStripButtonFind_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonFind.Checked)
            {
                if (formFind != null)
                {
                    formFind.Close();
                }
            }
            else
            {
                MenuItemFindText_Click(sender, e);
            }
        }

        private void toolStripButtonHighlight_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripButton).Checked)
            {
                richTextBoxEN.TextChanged += richTextBox_Highlight;
                richTextBoxRU.TextChanged += richTextBox_Highlight;
            }
            else
            {
                richTextBoxEN.TextChanged -= richTextBox_Highlight;
                richTextBoxRU.TextChanged -= richTextBox_Highlight;
            }
        }

        private void richTextBox_ContextMenuOpening(object sender, EventArgs e)
        {
            ContextMenuStrip cms = sender as ContextMenuStrip;
            RichTextBox rtb = cms.SourceControl as RichTextBox;

            foreach (ToolStripMenuItem item in rtb.ContextMenuStrip.Items)
            {
                switch (item.ShortcutKeyDisplayString.Last())
                {
                    case 'X':
                        item.Enabled = !string.IsNullOrEmpty(rtb.SelectedText);
                        break;
                    case 'C':
                        item.Enabled = !string.IsNullOrEmpty(rtb.SelectedText);
                        break;
                    case 'V':
                        item.Enabled = Clipboard.ContainsText();
                        break;
                }
            }
        }

        private void toolStripButtonSymbols_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripButton).Checked)
            {
                richTextBoxRU.KeyPress += richTextBox_KeyPress;
            }
            else
            {
                richTextBoxRU.KeyPress -= richTextBox_KeyPress;
            }
        }

        /*private void buttonAutoTranslate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(GetEN())) return;
            
            if (translate == null) translate = new AutoTranslateForm(this);
            
            translate.SetString(GetEN());
            translate.Show();

            translate.Translate();
        }

        public void Translating(bool finish)
        {
            buttonAutoTranslate.Enabled = finish;
        }

        public void SetTranslate(string result)
        {
            SetRU(result);
        }*/

        private void MenuItemRecent_Click(object sender, EventArgs e)
        {
            pathToLocalisation = sender.ToString();
            OpenLocalisation();
        }

        DialogResult DialogExitWOSaving()
        {
            return MessageBoxEx.Show(this,
                appLocalisationStrings["file1"] + " " + currentFile.Replace("_l_" + originalTranslation, "_l_" + editTranslation) + " "
                + appLocalisationStrings["not_saved"] + ".\n" + appLocalisationStrings["mb_quitWOSave"], appLocalisationStrings["warning"], MessageBoxButtons.OKCancel);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult r = DialogExitWOSaving();
                if (r == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (cfg != null)
            {
                cfg.Save();
            }
        }

        private void buttonBookmark_Click(object sender, EventArgs e)
        {
            if (cfg == null) return;

            if (!cfg.marks.Contains(currentFile + ">" + currentLine.field))
            {
                buttonBookmark.Image = Properties.Resources.bookmark;

                AddBookmark(currentFile, currentLine.field);

                toolStripButtonBookmarkList.Enabled = true;
                toolStripButtonBookmarkL.Enabled = toolStripButtonBookmarkR.Enabled = true;
            }
            else
            {
                buttonBookmark.Image = Properties.Resources.bookmark_gray;

                RemoveBookmark(currentFile + ">" + currentLine.field);

                if (currentLine != null) currentLine.item.BackColor = SystemColors.Window;
            }
        }

        private void contextMenuStripBookmarks_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SelectBookmark(e.ClickedItem.Text);
        }

        private void contextMenuStripBookmarks_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked) e.Cancel = true;
        }

        private void toolStripButtonBookmarkList_Click(object sender, EventArgs e)
        {
            contextMenuStripBookmarks.Show(Cursor.Position);
        }

        private void toolStripButtonBookmarkL_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in contextMenuStripBookmarks.Items)
            {
                if (item.Checked)
                {
                    int index = contextMenuStripBookmarks.Items.IndexOf(item);
                    if ((index + 1) < contextMenuStripBookmarks.Items.Count)
                    {
                        SelectBookmark(contextMenuStripBookmarks.Items[index + 1].Text);
                    }
                    else
                    {
                        SelectBookmark(contextMenuStripBookmarks.Items[0].Text);
                    }

                    return;
                }
            }

            SelectBookmark(contextMenuStripBookmarks.Items[0].Text);
        }

        private void toolStripButtonBookmarkR_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in contextMenuStripBookmarks.Items)
            {
                if (item.Checked)
                {
                    int index = contextMenuStripBookmarks.Items.IndexOf(item);
                    if ((index - 1) > -1)
                    {
                        SelectBookmark(contextMenuStripBookmarks.Items[index - 1].Text);
                    }
                    else
                    {
                        SelectBookmark(contextMenuStripBookmarks.Items[contextMenuStripBookmarks.Items.Count - 1].Text);
                    }

                    return;
                }
            }

            SelectBookmark(contextMenuStripBookmarks.Items[contextMenuStripBookmarks.Items.Count - 1].Text);
        }

        private void listViewYmls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewYmls.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewYmls.SelectedItems[0];

                labelNote.Text = "Памятка (" + (item.Text) + ")";

                if (cfg.notes.ContainsKey(item.ToolTipText))
                {
                    textBoxNote.Text = cfg.notes[item.ToolTipText];
                }
                else
                {
                    textBoxNote.Clear();
                }
            }
        }

        private void textBoxNote_TextChanged(object sender, EventArgs e)
        {
            if (listViewYmls.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewYmls.SelectedItems[0];

                cfg.notes[item.ToolTipText] = textBoxNote.Text;

                if (textBoxNote.Text.Length > 0)
                {
                    if (item.BackColor != Color.Yellow) item.BackColor = Color.Yellow;
                }
                else
                {
                    if (cfg.notes.ContainsKey(item.ToolTipText))
                    {
                        cfg.notes.Remove(item.ToolTipText);
                        if (item.BackColor != SystemColors.Window) item.BackColor = SystemColors.Window;
                    }

                }
            }
            else
            {
                textBoxNote.Clear();
            }
        }

        private void toolStripButtonGEKS_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonGEKS.Checked)
            {
                geks = 0;
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = appLocalisationStrings["chooseChartable"];
                ofd.InitialDirectory = Application.StartupPath + "\\chartables";
                ofd.Filter = "*(*.txt)|*.txt";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    cfg.chartable = ofd.FileName;
                    toolStripButtonGEKS.Text = ofd.SafeFileName;
                    TextUtils.SetChars(ofd.FileName);

                    geks = 2;
                }
            }

            if (currentLine != null)
            {
                SetRU(TextUtils.FromChars(currentLine.text[editTranslation], geks));
            }
        }

        private void MenuItemMerge_Click(object sender, EventArgs e)
        {
            MergeForm mf = new MergeForm(this);

            mf.ShowDialog(this);
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            (new AboutForm()).ShowDialog(this);
        }

        private void MenuItemUndo_Click(object sender, EventArgs e)
        {
            if (richTextBoxRU.Focused)
            {
                redo = GetRU();
                SetRU(undo);

                MenuItemRedo.Enabled = true;
                MenuItemUndo.Enabled = false;
            }
        }

        private void MenuItemRedo_Click(object sender, EventArgs e)
        {
            if (richTextBoxRU.Focused)
            {
                SetRU(redo);

                MenuItemRedo.Enabled = false;
                MenuItemUndo.Enabled = true;
            }
        }

        private void richTextBoxRU_TextChanged(object sender, EventArgs e)
        {
            if (richTextBoxRU.Focused)
            {
                LabelEditText(false);
                if (!MenuItemUndo.Enabled) MenuItemUndo.Enabled = true;
                if (MenuItemRedo.Enabled) MenuItemRedo.Enabled = false;
            }
        }

        private void richTextBoxRU_Leave(object sender, EventArgs e)
        {
            MenuItemRedo.Enabled = MenuItemUndo.Enabled = false;
        }

        private void toolStripButtonStdFormat_Click(object sender, EventArgs e)
        {
            bool std = (stdFormat == FormatType.Original);

            if (std)
            {
                stdFormat = FormatType.Simple;
                FormatType.addVersion = false;
                toolStripButtonStdFormat.Image = Properties.Resources.std1;
            }
            else
            {
                stdFormat = FormatType.Original;
                FormatType.addVersion = true;
                toolStripButtonStdFormat.Image = Properties.Resources.std0;
            }
        }

        private void listViewStrings_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (fullStringsCollection == null || listViewStrings.Items.Count == 0) return;

            switch (e.Column)
            {
                case 1:
                    columnStringsSorted = !columnStringsSorted;

                    if (columnStringsSorted)
                    {
                        if (fullStringsCollection != null)
                        {
                            listViewStrings.Items.Clear();
                            listViewStrings.BeginUpdate();
                            listViewStrings.Items.AddRange(fullStringsCollection);

                            comparer.SetColumn(1);
                            listViewStrings.ListViewItemSorter = comparer;
                            listViewStrings.Sort();

                            listViewStrings.EndUpdate();
                        }
                    }
                    else
                    {
                        listViewStrings.Items.Clear();
                        listViewStrings.BeginUpdate();

                        listViewStrings.ListViewItemSorter = null;

                        foreach (KeyValuePair<string, YamlLine> s in strings)
                        {
                            listViewStrings.Items.Add(s.Value.item);
                        }

                        listViewStrings.EndUpdate();
                    }

                    break;
                case 2:

                    if (fullStringsCollection != null)
                    {
                        listViewStrings.BeginUpdate();

                        comparer.SetColumn(2);
                        listViewStrings.ListViewItemSorter = comparer;
                        listViewStrings.Sort();

                        listViewStrings.EndUpdate();
                    }

                    break;
            }
        }

        private void buttonAddStringEn_Click(object sender, EventArgs e)
        {
            currentLine.text.Add(originalTranslation, currentLine.text[editTranslation]);
            SetEN(currentLine.text[editTranslation]);
            currentLine.item.SubItems[2].Text = "";
            buttonAddStringEn.Visible = false;

            LabelEditText(false);
        }

        private void buttonAddStringRu_Click(object sender, EventArgs e)
        {
            currentLine.text.Add(editTranslation, currentLine.text[originalTranslation]);
            SetRU(currentLine.text[originalTranslation]);
            currentLine.item.SubItems[2].Text = "";
            buttonAddStringRu.Visible = false;

            LabelEditText(false);
        }

        private void toolStripComboBoxOrig_SelectedIndexChanged(object sender, EventArgs e)
        {
            originalTranslation = toolStripComboBoxOrig.SelectedItem.ToString();
        }

        private void toolStripComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            editTranslation = toolStripComboBoxEdit.SelectedItem.ToString();
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult r = DialogExitWOSaving();
                if (r == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (formFind != null) formFind.Close();

            listViewStrings.Items.Clear();
            listViewYmls.Items.Clear();
            strings.Clear();

            groupBox1.Visible = false;
            groupBox2.Visible = false;

            buttonBookmark.Enabled = false;

            MenuItemRedo.Enabled = MenuItemUndo.Enabled = false;
            menuItemClose.Enabled = false;

            toolStripButtonBookmarkList.Enabled = false;
            toolStripButtonBookmarkL.Enabled = toolStripButtonBookmarkR.Enabled = false;

            toolStripButtonFind.Enabled = MenuItemFindText.Enabled = false;
            toolStripButtonSave.Enabled = MenuItemSave.Enabled = false;
            tabControl1.TabPages.Remove(tabPageStrings);

            toolStripComboBoxOrig.Enabled = true;
            toolStripComboBoxEdit.Enabled = true;

            LabelEditText(true);

            statusLabelEditing.Image = Properties.Resources.exclamation;
            statusLabelEditing.Text = appLocalisationStrings["statusLabelEditing"];

            labelInfo.Text = "";
        }

        private void toolStripComboBoxLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            appLocalisation = toolStripComboBoxLang.SelectedItem as string;

            LoadAppLocalisation();
            Localize();
        }

        void FindUniqueStrings()
        {
            int onlyRU = 0;
            int onlyEN = 0;

            foreach (KeyValuePair<string, YamlLine> exist in strings)
            {
                Dictionary<string, string> d = exist.Value.text;

                exist.Value.item.SubItems.Add("");

                if (!d.ContainsKey(originalTranslation))
                {
                    onlyRU++;
                    exist.Value.item.SubItems[2].Text = editTranslation.Substring(0, 1).ToUpper();
                }
                if (!d.ContainsKey(editTranslation))
                {
                    onlyEN++;
                    exist.Value.item.SubItems[2].Text = originalTranslation.Substring(0, 1).ToUpper();
                }

                if (!strings.ContainsKey(exist.Key))
                {
                    exist.Value.item.BackColor = Color.LightGray;
                }

                if (cfg.marks.Contains(currentFile + ">" + exist.Key))
                {
                    exist.Value.item.BackColor = Color.Orange;
                }
            }

            labelInfo.Text = appLocalisationStrings["labelInfo_strings"] + ": " + strings.Count + ", " + appLocalisationStrings["labelInfo_unique"] + ": " + onlyEN + " (" + originalTranslation + "), " + onlyRU + " (" + editTranslation + ")";
        }

        private void buttonAddString_Click(object sender, EventArgs e)
        {
            int addIndex = 0;

            do
            {
                addIndex++;
            } while (strings.ContainsKey("new_line" + addIndex));

            YamlLine yl = new YamlLine("new_line" + addIndex);
            yl.text.Add(editTranslation, "@new string");

            strings.Add("new_line" + addIndex, yl);

            ListViewItem item = new ListViewItem();
            item.Text = "";
            yl.item = item;

            item.SubItems.Add(yl.field);

            listViewStrings.Items.Add(item);

            fullStringsCollection = new ListViewItem[listViewStrings.Items.Count];
            listViewStrings.Items.CopyTo(fullStringsCollection, 0);

            //ListViewItem i = listViewStrings.FindItemWithText("new line");
            item.Selected = true;
            item.EnsureVisible();

            FindUniqueStrings();

            LabelEditText(false);
        }

        private void buttonStringDelete_Click(object sender, EventArgs e)
        {
            if(currentLine != null)
            {
                int index = listViewStrings.Items.IndexOf(currentLine.item);

                listViewStrings.Items.Remove(currentLine.item);
                strings.Remove(currentLine.field);

                fullStringsCollection = new ListViewItem[listViewStrings.Items.Count];
                listViewStrings.Items.CopyTo(fullStringsCollection, 0);

                if (index >= listViewStrings.Items.Count)
                {
                    index = listViewStrings.Items.Count - 1;
                }

                listViewStrings.Items[index].Selected = true;
                listViewStrings.Items[index].EnsureVisible();

                FindUniqueStrings();

                LabelEditText(false);
            }
        }

        private void textBoxFieldName_TextChanged(object sender, EventArgs e)
        {
            textBoxFieldName.ForeColor = SystemColors.WindowText;

            if (currentLine != null)
            {
                if(currentLine.field != textBoxFieldName.Text)
                {
                    if (strings.ContainsKey(textBoxFieldName.Text))
                    {
                        textBoxFieldName.ForeColor = Color.Red;
                    }
                    else
                    {
                        strings.Remove(currentLine.field);
                        strings.Add(textBoxFieldName.Text, currentLine);
                        currentLine.item.SubItems[1].Text = currentLine.field = textBoxFieldName.Text;
                    }
                }
            }
        }
    }
}
