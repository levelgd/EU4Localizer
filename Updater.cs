using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace eu4NET
{
    class Updater
    {
        public static string version = "0.2.0";
        public string updateFrom = "http://euloc-levelgd.rhcloud.com/";

        MainForm mainForm;
        string mainFormCaption;

        public Updater(MainForm form)
        {
            mainForm = form;
            mainFormCaption = mainForm.Text;
        }

        public void Update()
        {
            Check();
        }

        public async void Check()
        {
            mainForm.Text = mainFormCaption + " [" + MainForm.appLocalisationStrings["upd_checking"] + "...]";

            Task<string> task = Task.Run(() => RequestStringTask("check"));
            string actual = await task;

            FormUpdating fu = null;

            if (actual != "connection error")
            {
                if(actual != version)
                {
                    mainForm.Text = mainFormCaption + " [" + MainForm.appLocalisationStrings["upd_new"] + " " + actual + "!]";

                    DialogResult r = MessageBoxEx.Show(mainForm, MainForm.appLocalisationStrings["upd_update"] + " " + actual + "?", MainForm.appLocalisationStrings["upd_updateAvailable"],
                        MessageBoxButtons.OKCancel);

                    if(r == DialogResult.OK)
                    {
                        mainForm.Text = mainFormCaption + " [" + MainForm.appLocalisationStrings["upd_updTo"] + " " + actual + "...]";

                        fu = new FormUpdating();
                        fu.Show(mainForm);
                        fu.CenterAtParent(mainForm);
                        mainForm.Enabled = false;

                        task = Task.Run(() => RequestStringTask("changelog"));
                        string changelog = await task;

                        Console.WriteLine(changelog);

                        fu.SetChangelog(changelog);

                        Task<bool> dl = Task.Run(() => UpdateTask(fu));
                        bool success = await dl;

                        fu.SetFinished(success);
                        return;
                    }
                }
                else
                {
                    mainForm.Text = mainFormCaption;
                }
            }
            else
            {
                mainForm.Text = mainFormCaption;
            }

            mainForm.Enabled = true;
            if (fu != null) fu.Close();
        }

        bool UpdateTask(FormUpdating fu) //один сплошной говнокод
        {
            bool finished = false;

            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += (s, e) =>
                {
                    fu.BeginInvoke((MethodInvoker)delegate {
                        fu.SetProgress(e.ProgressPercentage);
                    });
                };

                client.DownloadFileCompleted += (s, e) =>
                {
                    finished = true;
                };

                try
                {
                    client.DownloadFileAsync(new Uri(updateFrom + "dl"), "update.zip");

                    while(!finished)
                    {
                        Thread.Sleep(1000);
                    }
                    return true;
                }
                catch (WebException)
                {
                    return false;
                }
            }
        }

        string RequestStringTask(string addpath)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                string response = "";

                try
                {
                    response = client.DownloadString(updateFrom + addpath);
                }
                catch (WebException)
                {
                    return "connection error";
                }

                return response;
            }
        }
    }
}
