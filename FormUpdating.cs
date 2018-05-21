using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eu4NET
{
    public partial class FormUpdating : Form
    {
        List<string> changelog;

        public FormUpdating()
        {
            InitializeComponent();

            Localize();
        }

        void Localize()
        {
            Text = MainForm.appLocalisationStrings["formUpd_caption"];
            label1.Text = MainForm.appLocalisationStrings["formUpd_changes"];
            button1.Text = MainForm.appLocalisationStrings["formUpd_restart"];
        }

        public void SetProgress(int value)
        {
            progressBar.Value = value;
        }

        public void SetChangelog(string text)
        {
            changelog = new List<string>();

            string currentVersion = "";
            string note = "";

            List<string> lines = text.Split('\n').ToList();

            foreach (string l in lines)
            {
                if (l.StartsWith("●"))
                {
                    if (!string.IsNullOrEmpty(note))
                    {
                        changelog.Add(note);
                        note = "";

                        listBoxVersions.Items.Add(currentVersion);
                    }

                    currentVersion = l.Substring(2);
                }
                else
                {
                    note += (l + "\r\n");
                }
            }

            changelog.Add(note);
            listBoxVersions.Items.Add(currentVersion);

            listBoxVersions.SelectedIndex = 0;
        }

        public void SetFinished(bool success)
        {
            if (success && File.Exists("update.zip"))
            {
                this.Text = MainForm.appLocalisationStrings["formUpd_updated"];
                button1.Enabled = true;

                button1.Click += (object s, EventArgs e) =>
                {
                    ZipFile.ExtractToDirectory("update.zip", "update");

                    File.WriteAllText("upd.bat", "timeout 1 > nul\nxcopy \"" + Application.StartupPath + "\\update\" \"" + Application.StartupPath + "\" /e /h /r /x /y /i /k\nrmdir /q /s update\ndel update.zip\nstart eu4loc.exe\ndel upd.bat");

                    Application.Exit();
                    Process.Start("upd.bat");
                };
            }
            else
            {
                MessageBoxEx.Show(MainForm.appLocalisationStrings["formUpd_error"]);
            }
        }

        public void CenterAtParent(Form parent)
        {
            Location = new Point(parent.Location.X + (parent.Width - Width) / 2, parent.Location.Y + (parent.Height - Height) / 2);
        }

        private void listBoxVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxNote.Text = changelog[listBoxVersions.SelectedIndex];
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }
    }
}
