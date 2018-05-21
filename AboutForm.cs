using System;
using System.Windows.Forms;

namespace eu4NET
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            Localize();

            textBoxAbout.Text += " " + Updater.version;
        }

        void Localize()
        {
            label1.Text = MainForm.appLocalisationStrings["about_support"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void patreon_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.patreon.com/levelgd");
        }
    }
}
