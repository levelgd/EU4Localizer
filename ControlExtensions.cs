using System;
using System.Windows.Forms;
using System.Reflection;

namespace eu4NET
{
    public static class ControlExtensions
    {
        public static void DoubleBuffering(this Control control, bool enable)
        {
            var method = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(control, new object[] { ControlStyles.OptimizedDoubleBuffer, enable });
        }

        public static void DoubleBuffered(this Control control, bool enable) //better
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        public static void Suspend(this Control control)
        {
            LockWindowUpdate(control.Handle);
        }

        public static void Resume(this Control control)
        {
            LockWindowUpdate(IntPtr.Zero);
        }

        public static void AddContextMenu(this RichTextBox rtb)
        {
            if (rtb.ContextMenuStrip == null)
            {
                ContextMenuStrip cms = new ContextMenuStrip { ShowImageMargin = true };

                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Вырезать");
                tsmiCut.ShortcutKeyDisplayString = "Ctrl+X";
                tsmiCut.Image = Properties.Resources.cut;
                tsmiCut.Click += (sender, e) => rtb.Cut();
                cms.Items.Add(tsmiCut);

                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Копировать");
                tsmiCopy.ShortcutKeyDisplayString = "Ctrl+C";
                tsmiCopy.Image = Properties.Resources.page_copy;
                tsmiCopy.Click += (sender, e) => rtb.Copy();
                cms.Items.Add(tsmiCopy);

                ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Вставить");
                tsmiPaste.ShortcutKeyDisplayString = "Ctrl+V";
                tsmiPaste.Image = Properties.Resources.page_white_paste;
                tsmiPaste.Click += (sender, e) => rtb.Paste(DataFormats.GetFormat(DataFormats.Text));
                cms.Items.Add(tsmiPaste);
                rtb.ContextMenuStrip = cms;
            }
        }
    }
}
