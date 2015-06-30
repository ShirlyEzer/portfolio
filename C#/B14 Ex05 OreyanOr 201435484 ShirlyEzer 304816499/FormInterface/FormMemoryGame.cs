using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Logic;

namespace FormInterface
{
    public class FormMemoryGame : Form
    {
        private FormMemoryGameSettings m_FormMemoryGameSettings = new FormMemoryGameSettings();
        private Label m_LabelCurrentPlayer = new Label();
        private Label m_LabelFirstPlayerScore = new Label();
        private Label m_LabelSecondPlayerScore = new Label();
        private GameLogic m_GameLogic = new GameLogic();
        private bool m_IsLoggedIn = false;
        private ButtonMemoryGameCard[,] m_ButtonsMatrix = null;
        private bool m_FirstClick = false;
        private bool m_SecondClick = false;
        private bool m_IsMatching = false;
        private ButtonMemoryGameCard m_ButtonFirstCard = null;
        private ButtonMemoryGameCard m_ButtonSecondCard = null;

        public FormMemoryGame()
        {
            this.Text = "Memory Game";
            this.StartPosition = FormStartPosition.CenterScreen;
            m_GameLogic.GameOverHandler += this.showGameOverMessage;
            m_GameLogic.ComputerMoveHandler += this.compuetrMove;
            m_GameLogic.UpdateScoreHandler += this.updateScore;
            m_GameLogic.GetTwoCardsHandler += this.getTwoCard;
            m_GameLogic.TwoCardsMatchedHandler += this.twoCardsRevealed;
            m_GameLogic.ExchangeTurnsHandler += this.exchangeTurns;
            ensureLoggedIn();
            m_GameLogic.PlayerNumber1.PlayerName = m_FormMemoryGameSettings.TextBoxFirstPlayerName;
            m_GameLogic.PlayerNumber2.PlayerName = m_FormMemoryGameSettings.TextBoxSecondPlayerName;
            m_GameLogic.GameComputerVSPlayer = m_FormMemoryGameSettings.AgainstComputer;
            m_GameLogic.GamePlayerVSPlayer = !m_FormMemoryGameSettings.AgainstComputer;
        }

        private void initControls()
        {
            this.Size = new Size((m_FormMemoryGameSettings.BoardCols * 75) + ((m_FormMemoryGameSettings.BoardCols - 1) * 3) + 10, (m_FormMemoryGameSettings.BoardRows * 75) + ((m_FormMemoryGameSettings.BoardRows - 1) * 3) + (23 * 3) + 75);

            m_LabelCurrentPlayer.Text = "Current Player: " + m_FormMemoryGameSettings.TextBoxFirstPlayerName;
            m_LabelCurrentPlayer.AutoSize = true;
            m_LabelCurrentPlayer.Location = new Point(15, this.ClientSize.Height - m_LabelFirstPlayerScore.Height - m_LabelSecondPlayerScore.Height - m_LabelFirstPlayerScore.Height - 35);
            m_LabelCurrentPlayer.BackColor = Color.LightGreen;

            m_LabelFirstPlayerScore.Text = m_FormMemoryGameSettings.TextBoxFirstPlayerName + ":";
            m_LabelFirstPlayerScore.AutoSize = true;
            m_LabelFirstPlayerScore.Location = new Point(15, this.ClientSize.Height - m_LabelFirstPlayerScore.Height - m_LabelSecondPlayerScore.Height - 25);
            m_LabelFirstPlayerScore.BackColor = Color.LightGreen;

            m_LabelSecondPlayerScore.Text = (m_FormMemoryGameSettings.AgainstComputer == true) ? "Computer:" : (m_FormMemoryGameSettings.TextBoxSecondPlayerName + ":");
            m_LabelSecondPlayerScore.AutoSize = true;
            m_LabelSecondPlayerScore.Location = new Point(15, this.ClientSize.Height - m_LabelSecondPlayerScore.Height - 15);
            m_LabelSecondPlayerScore.BackColor = Color.LightPink;

            this.Controls.AddRange(new Control[] { m_LabelFirstPlayerScore, m_LabelSecondPlayerScore, m_LabelCurrentPlayer });

            addCardButtons();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initControls();
        }

        private bool ensureLoggedIn()
        {
            if (!m_IsLoggedIn)
            {
                if (m_FormMemoryGameSettings.ShowDialog() == DialogResult.OK)
                {
                    m_IsLoggedIn = true;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }

            return m_IsLoggedIn;
        }

        private void addCardButtons()
        {
            m_GameLogic.CreateBoardMatrix(m_FormMemoryGameSettings.BoardRows, m_FormMemoryGameSettings.BoardCols);
            m_ButtonsMatrix = new ButtonMemoryGameCard[m_FormMemoryGameSettings.BoardRows, m_FormMemoryGameSettings.BoardCols];
            for (int i = 0; i < m_FormMemoryGameSettings.BoardRows; i++)
            {
                for (int j = 0; j < m_FormMemoryGameSettings.BoardCols; j++)
                {
                    m_ButtonsMatrix[i, j] = new ButtonMemoryGameCard();
                    m_ButtonsMatrix[i, j].Location = new Point(3 + (j * m_ButtonsMatrix[i, j].Width), 3 + (i * 4 * 19));
                    m_ButtonsMatrix[i, j].Size = new Size(70, 70);
                    m_ButtonsMatrix[i, j].RowIndex = i;
                    m_ButtonsMatrix[i, j].ColIndex = j;
                    m_ButtonsMatrix[i, j].Click += new EventHandler(buttonMemoryGameCard_Click);
                    this.Controls.Add(m_ButtonsMatrix[i, j]);
                }
            }
        }

        private void buttonMemoryGameCard_Click(object sender, EventArgs e)
        {
            ButtonMemoryGameCard button = sender as ButtonMemoryGameCard;

            if (!m_IsMatching)
            {
                upsideDownCard();
            }

            if (button.Enabled == true)
            {
                if (!m_FirstClick)
                {
                    m_ButtonFirstCard = button;
                    revealFirstCard(button.RowIndex, button.ColIndex);
                }
                else
                {
                    if (!m_SecondClick)
                    {
                        if (m_ButtonFirstCard != button)
                        {
                            m_ButtonSecondCard = button;
                            revealSecondCard(button.RowIndex, button.ColIndex);
                        }
                    }
                }
            }
        }

        private void twoCardsRevealed()
        {
            m_ButtonFirstCard.Enabled = false;
            m_ButtonsMatrix[m_ButtonFirstCard.RowIndex, m_ButtonFirstCard.ColIndex].Enabled = false;
            m_ButtonSecondCard.Enabled = false;
            m_ButtonsMatrix[m_ButtonSecondCard.RowIndex, m_ButtonSecondCard.ColIndex].Enabled = false;
            m_IsMatching = true;
        }

        private void revealFirstCard(int i_RowIndex, int i_ColIndex)
        {
            m_FirstClick = true;
            m_SecondClick = false;
            
            m_ButtonFirstCard.Text = m_GameLogic.BoardGame.Board[i_RowIndex, i_ColIndex].ToString();
            m_ButtonFirstCard.BackColor = m_LabelCurrentPlayer.BackColor;
            m_ButtonSecondCard = null;
        }

        private void revealSecondCard(int i_RowIndex, int i_ColIndex)
        {
            m_SecondClick = true; 
            m_FirstClick = false;
            m_ButtonSecondCard.Text = m_GameLogic.BoardGame.Board[i_RowIndex, i_ColIndex].ToString();
            m_ButtonSecondCard.BackColor = m_LabelCurrentPlayer.BackColor;
            m_ButtonSecondCard.Refresh();
            m_GameLogic.PlayerMakeMove();
            
            if (m_GameLogic.ComputerPlay.IsComputerTurn == true)
            {
                m_GameLogic.ComputerChooseTwoCards();
            }
        }

        private void showGameOverMessage()
        {
            StringBuilder stringEndGameMessage = new StringBuilder();
            stringEndGameMessage.AppendLine("Game Over!!");
            stringEndGameMessage.AppendLine("The winner is: " + m_GameLogic.Winner.PlayerName);
            MessageBox.Show(stringEndGameMessage.ToString());
        }

        private void compuetrMove(int i_FirstCardRow, int i_FirstCardCol, int i_SecondCardRow, int i_SecondCardCol)
        {
            System.Threading.Thread.Sleep(450);

            if (m_GameLogic.ComputerPlay.IsComputerTurn != true)
            {
                exchangeTurns();
            }

            if (m_IsMatching == false)
            {
                upsideDownCard();
            }

            m_ButtonFirstCard = m_ButtonsMatrix[i_FirstCardRow, i_FirstCardCol];
            m_ButtonSecondCard = null;
            revealFirstCard(i_FirstCardRow, i_FirstCardCol);
            m_ButtonSecondCard = m_ButtonsMatrix[i_SecondCardRow, i_SecondCardCol];
            revealSecondCard(i_SecondCardRow, i_SecondCardCol);
            this.Refresh();
        }

        private void updateScore()
        {
            m_LabelFirstPlayerScore.Text = m_FormMemoryGameSettings.TextBoxFirstPlayerName + ":" + m_GameLogic.PlayerNumber1.PlayerScore;
            if (m_FormMemoryGameSettings.AgainstComputer == true)
            {
                m_LabelSecondPlayerScore.Text = "Computer :" + m_GameLogic.ComputerPlay.ComputerScore;
            }
            else
            {
                m_LabelSecondPlayerScore.Text = m_FormMemoryGameSettings.TextBoxSecondPlayerName + ":" + m_GameLogic.PlayerNumber2.PlayerScore;
            }
        }

        private void getTwoCard(out int o_firstCardRow, out int o_firstCardCol, out int o_secondCardRow, out int o_secondCardCol)
        {
            o_firstCardRow = m_ButtonFirstCard.RowIndex;
            o_firstCardCol = m_ButtonFirstCard.ColIndex;
            o_secondCardRow = m_ButtonSecondCard.RowIndex;
            o_secondCardCol = m_ButtonSecondCard.ColIndex;
        }

        private void exchangeTurns()
        {
            if (m_GameLogic.PlayerNumber1.IsPlayerTurn == true)
            {
                m_LabelCurrentPlayer.BackColor = m_LabelFirstPlayerScore.BackColor;
                m_LabelCurrentPlayer.Text = "Current Player: " + m_FormMemoryGameSettings.TextBoxFirstPlayerName;
            }
            else
            {
                m_LabelCurrentPlayer.BackColor = m_LabelSecondPlayerScore.BackColor;
                m_LabelCurrentPlayer.Text = "Current Player: " + m_FormMemoryGameSettings.TextBoxSecondPlayerName;
            }

            m_IsMatching = false;
        }

        private void upsideDownCard()
        {
            if (m_ButtonFirstCard != null && m_ButtonSecondCard != null)
            {
                m_ButtonFirstCard.Text = string.Empty;
                m_ButtonFirstCard.BackColor = Color.Empty;
                m_ButtonSecondCard.Text = string.Empty;
                m_ButtonSecondCard.BackColor = Color.Empty;
            }
        }
    }
}
