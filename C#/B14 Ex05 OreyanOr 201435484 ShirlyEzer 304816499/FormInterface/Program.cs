using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormInterface
{
    public class Program
    {
        public static void Main()
        {
            FormMemoryGame formMemoryGame = new FormMemoryGame();
            if (formMemoryGame.DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Goodbye");
            }
            else
            {
                formMemoryGame.ShowDialog();
            }
        }
    }
}
