using System.Drawing;
using System.Windows.Forms;

namespace eu4NET
{
    public partial class ParsingStringForm : Form
    {
        public ParsingStringForm()
        {
            InitializeComponent();

            labelParsed.DoubleBuffered(true);
        }

        public void InitProgressBar(int count)
        {
            progressBarParsing.Maximum = count;
        }

        public void SetProgress(int current)
        {
            progressBarParsing.Value = current;

            labelParsed.Text = current + "/" + progressBarParsing.Maximum;
            labelParsed.Refresh();
        }

        public void CenterAtParent(Form parent)
        {
            Location = new Point(parent.Location.X + (parent.Width - Width) / 2, parent.Location.Y + (parent.Height - Height) / 2);
        }
    }
}
