using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FormInterface
{
    public class ButtonMemoryGameCard : Button
    {
        private int m_RowIndex;
        private int m_ColIndex;

        public int RowIndex
        {
            get { return m_RowIndex; }
            set { m_RowIndex = value; }
        }

        public int ColIndex
        {
            get { return m_ColIndex; }
            set { m_ColIndex = value; }
        }
    }
}
