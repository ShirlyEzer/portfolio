using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FormInterface
{
    public class FormMemoryGameSettings : Form
    {
        private Label m_LabelFirstPlayerName = new Label();
        private Label m_LabelSecondPlayerName = new Label();
        private Label m_LabelBoardSize = new Label();
        private TextBox m_TextBoxFirstPlayerName = new TextBox();
        private TextBox m_TextBoxSecondPlayerName = new TextBox();
        private Button m_ButtonAgainstFriendOrComputer = new Button();
        private Button m_ButtonBoardSize = new Button();
        private Button m_ButtonStartGame = new Button();
        private int m_BoardCols = 4;
        private int m_BoardRows = 4;
        private bool m_AgainstComputer = true;

        public FormMemoryGameSettings()
        {
            this.Text = "Memory Game - Settings";
            this.Size = new Size(410, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public string TextBoxFirstPlayerName
        {
            get { return m_TextBoxFirstPlayerName.Text; }
        }

        public string TextBoxSecondPlayerName
        {
            get { return m_TextBoxSecondPlayerName.Text; }
        }

        public int BoardCols
        {
            get { return m_BoardCols; }
        }

        public int BoardRows
        {
            get { return m_BoardRows; }
        }

        public bool AgainstComputer
        {
            get { return m_AgainstComputer; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initControls();
        }

        private void initControls()
        {
            FontFamily fontFamily = new FontFamily("Times New Roman");

            m_LabelFirstPlayerName.Text = "First Player Name :";
            m_LabelFirstPlayerName.Location = new Point(10, 30);
            m_LabelFirstPlayerName.Width = 140;

            m_LabelSecondPlayerName.Text = "Second Player Name :";
            m_LabelSecondPlayerName.Location = new Point(10, 65);
            m_LabelSecondPlayerName.Width = 140;

            m_LabelBoardSize.Text = "Choose The Board Size :";
            m_LabelBoardSize.Location = new Point(10, 100);
            m_LabelBoardSize.Width = 180;

            int textBoxTop = m_LabelFirstPlayerName.Top + (m_LabelFirstPlayerName.Height / 2);
            textBoxTop -= m_LabelSecondPlayerName.Height / 2;
            m_TextBoxFirstPlayerName.Location = new Point(m_LabelSecondPlayerName.Right + 7, textBoxTop);

            textBoxTop = m_LabelSecondPlayerName.Top + (m_LabelSecondPlayerName.Height / 2);
            textBoxTop -= m_LabelSecondPlayerName.Height / 2;
            m_TextBoxSecondPlayerName.Location = new Point(m_LabelSecondPlayerName.Right + 7, textBoxTop);
            m_TextBoxSecondPlayerName.Text = "    - Computer -  ";
            m_TextBoxSecondPlayerName.Enabled = false;

            m_ButtonAgainstFriendOrComputer.Text = "Against Friend";
            int buttonTop = m_TextBoxSecondPlayerName.Top + (m_TextBoxSecondPlayerName.Height / 2);
            buttonTop -= m_TextBoxSecondPlayerName.Height / 2;
            m_ButtonAgainstFriendOrComputer.Location = new Point(m_TextBoxSecondPlayerName.Right + 7, buttonTop);
            m_ButtonAgainstFriendOrComputer.Size = new Size(120, 25);
            m_ButtonAgainstFriendOrComputer.Click += new EventHandler(buttonAgainstFriend_Click);

            m_ButtonBoardSize.Text = "4X4";
            m_ButtonBoardSize.Font = new Font(fontFamily, 30f);
            m_ButtonBoardSize.Size = new Size(m_LabelBoardSize.Width, 60);
            m_ButtonBoardSize.Location = new Point(m_LabelBoardSize.Left, m_LabelBoardSize.Top + m_LabelBoardSize.Height + 10);
            m_ButtonBoardSize.BackColor = Color.LightSteelBlue;
            m_ButtonBoardSize.Click += new EventHandler(buttonBoardSize_Click);

            m_ButtonStartGame.Text = "Start!";
            m_ButtonStartGame.Font = new Font(fontFamily, 20f);
            m_ButtonStartGame.Size = new Size(108, 50);
            m_ButtonStartGame.BackColor = Color.LightGreen;
            m_ButtonStartGame.Location = new Point(this.ClientSize.Width - m_ButtonStartGame.Width - 8, this.ClientSize.Height - m_ButtonStartGame.Height - 8);
            m_ButtonStartGame.Click += new EventHandler(buttonStartGame_Click);
            this.Controls.AddRange(new Control[] { m_LabelFirstPlayerName, m_LabelSecondPlayerName, m_LabelBoardSize, m_TextBoxFirstPlayerName, m_TextBoxSecondPlayerName, m_ButtonAgainstFriendOrComputer, m_ButtonBoardSize, m_ButtonStartGame });
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAgainstFriend_Click(object sender, EventArgs e)
        {
            if (m_AgainstComputer == true)
            {
                m_TextBoxSecondPlayerName.Enabled = true;
                m_ButtonAgainstFriendOrComputer.Text = "Against Computer";
                m_TextBoxSecondPlayerName.Text = string.Empty;
                m_AgainstComputer = false;
            }
            else
            {
                m_TextBoxSecondPlayerName.Enabled = false;
                m_ButtonAgainstFriendOrComputer.Text = "Against Friend";
                m_TextBoxSecondPlayerName.Text = "    - Computer -  ";
                m_AgainstComputer = true;
            }
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            Button buttonBoardSize = sender as Button;

            boardSizeValues();
            buttonBoardSize.Text = m_BoardRows.ToString() + "X" + m_BoardCols.ToString();
        }

        private void boardSizeValues()
        {
            const int k_MaxBoardColsOrRows = 7;

            m_BoardCols++;

            if (m_BoardCols >= k_MaxBoardColsOrRows)
            {
                m_BoardCols = 4;
                m_BoardRows++;

                if (m_BoardRows >= k_MaxBoardColsOrRows)
                {
                    m_BoardRows = 4;
                }
            }

            if ((m_BoardCols * m_BoardRows) % 2 != 0)
            {
                m_BoardCols++;
            }
        }
    }
}
