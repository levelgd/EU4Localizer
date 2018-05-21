using System;
using System.Xml;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace eu4NET
{
    public partial class AutoTranslateForm : Form
    {
        public string key = "trnsl.1.1.20160915T094040Z.dece27af39ac5634.a48fe6bed465eeee03bdaa2bfbdceee4638d2bd2";

        MainForm mainForm;

        public AutoTranslateForm(MainForm main)
        {
            InitializeComponent();

            mainForm = main;

            if(main.cfg != null && !String.IsNullOrEmpty(main.cfg.key))
            {
                key = main.cfg.key;
            }
        }

        public void SetString(string en)
        {
            textBoxEn.Text = en;
        }

        public async void Translate()
        {
            textBoxRu.Text = "";
            mainForm.Translating(false);

            buttonOk.Enabled = false;
            progressBarTranslating.Style = ProgressBarStyle.Marquee;
            progressBarTranslating.MarqueeAnimationSpeed = 20;

            Task<string> task = Task.Run(() => TranslateTask(textBoxEn.Text));
            textBoxRu.Text = await task;

            mainForm.Translating(true);

            buttonOk.Enabled = true;
            progressBarTranslating.Style = ProgressBarStyle.Continuous;
            progressBarTranslating.MarqueeAnimationSpeed = 0;
        }

        string TranslateTask(string text)
        {
            using (var client = new WebClient())
            {
                NameValueCollection values = new NameValueCollection();
                values["key"] = key;
                values["text"] = text;
                values["lang"] = "en-ru";
                values["format"] = "plain";

                byte[] response;

                try
                {
                    response = client.UploadValues("https://translate.yandex.net/api/v1.5/tr/translate", values);
                }
                catch(WebException e)
                {
                    return "Неверный ключ, либо ошибка подключения к сервису";
                }

                string responseString = Encoding.UTF8.GetString(response);
                string result = "";

                try
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(responseString);

                    result = xml.DocumentElement.ChildNodes[0].InnerText;
                }
                catch (XmlException e)
                {
                    result = e.StackTrace;
                }

                return result;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(mainForm != null)
            {
                mainForm.SetTranslate(textBoxRu.Text);
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(toolStripStatusLabel2.Text);
        }
    }
}
