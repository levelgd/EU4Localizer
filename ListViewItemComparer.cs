using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eu4NET
{
    class ListViewItemComparer : IComparer
    {
        private int listViewColumn;

        public ListViewItemComparer()
        {
            listViewColumn = 0;
        }

        public ListViewItemComparer(int column)
        {
            listViewColumn = column;
        }

        public void SetColumn(int column)
        {
            listViewColumn = column;
        }

        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[listViewColumn].Text, ((ListViewItem)y).SubItems[listViewColumn].Text);
            return returnVal;
        }
    }
}
