using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public delegate void GetTwoCardsDelegate(out int o_FirstCardRow, out int o_FirstCardCol, out int o_SecondCardRow, out int o_SecondCardCol);

    public delegate void GameOverDelegate();

    public delegate void ComputerMoveDelegate(int i_FirstCardRow, int i_FirstCardCol, int i_SecondCardRow, int i_SecondCardCol);

    public delegate void UpdateScoreDelegate();

    public delegate void TwoCardsMatchedDelegate();

    public delegate void ExchangeTurnsDelegate();

    public class GameLogic
    {
        public event GameOverDelegate GameOverHandler;

        public event ComputerMoveDelegate ComputerMoveHandler;

        public event UpdateScoreDelegate UpdateScoreHandler;

        public event GetTwoCardsDelegate GetTwoCardsHandler;

        public event TwoCardsMatchedDelegate TwoCardsMatchedHandler;

        public event ExchangeTurnsDelegate ExchangeTurnsHandler;

        private Player m_PlayerNumber1 = new Player();
        private Player m_PlayerNumber2 = new Player();
        private ComputerPlayer m_ComputerPlay = new ComputerPlayer();
        private MemoryBoard m_BoardGame;
        private bool m_GameComputerVSPlayer = false;
        private bool m_GamePlayerVSPlayer = false;
        private Player m_Winner;
        private Random m_RandValue = new Random();

        public GameLogic()
        {
            m_PlayerNumber1.IsPlayerTurn = true;
            m_PlayerNumber1.PlayerScore = 0;
            m_PlayerNumber2.IsPlayerTurn = false;
            m_PlayerNumber2.PlayerScore = 0;
            m_ComputerPlay.IsComputerTurn = false;
            m_ComputerPlay.ComputerScore = 0;
        }

        public MemoryBoard BoardGame
        {
            get { return m_BoardGame; }
        }

        public ComputerPlayer ComputerPlay
        {
            get { return m_ComputerPlay; }
            set { m_ComputerPlay = value; }
        }

        public Player PlayerNumber1
        {
            get { return m_PlayerNumber1; }
            set { m_PlayerNumber1 = value; }
        }

        public Player PlayerNumber2
        {
            get { return m_PlayerNumber2; }
            set { m_PlayerNumber2 = value; }
        }

        public bool GameComputerVSPlayer
        {
            get { return m_GameComputerVSPlayer; }
            set { m_GameComputerVSPlayer = value; }
        }

        public bool GamePlayerVSPlayer
        {
            get { return m_GamePlayerVSPlayer; }
            set { m_GamePlayerVSPlayer = value; }
        }

        public Player Winner
        {
            get { return m_Winner; }
        }

        private bool isMatchingCard(int i_FirstCardRowNumber, int i_FirstCardColNumber, int i_SecondCardRowNumber, int i_SecondCardColNumber)
        {
            char firstCardCharacter;
            bool flag = true;

            firstCardCharacter = revealCard(i_FirstCardRowNumber, i_FirstCardColNumber);
            if (firstCardCharacter != revealCard(i_SecondCardRowNumber, i_SecondCardColNumber))
            {
                flag = false;
            }
            else
            {
                m_BoardGame.CountOfMatchingCard[firstCardCharacter - 'L'] = 1;
                m_BoardGame.AvailableCardsToChoose.Remove(((i_FirstCardRowNumber + 1) * 10) + i_FirstCardColNumber + 1);
                m_BoardGame.AvailableCardsToChoose.Remove(((i_SecondCardRowNumber + 1) * 10) + i_SecondCardColNumber + 1);
            }

            return flag;
        }

        public bool CreateBoardMatrix(int i_RowOfBoard, int i_ColOfBoard)
        {
            bool flag = true;
            const int k_MinRowOrCol = 4;
            const int k_MaxRowOrCol = 6;

            if (i_RowOfBoard < k_MinRowOrCol || i_RowOfBoard > k_MaxRowOrCol)
            {
                flag = false;
            }
            else
            {
                if (i_ColOfBoard < k_MinRowOrCol || i_ColOfBoard > k_MaxRowOrCol)
                {
                    flag = false;
                }
                else
                {
                    if (i_RowOfBoard % 2 != 0 && i_ColOfBoard % 2 != 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        m_BoardGame = new MemoryBoard();
                        m_BoardGame.ColOfBoard = i_ColOfBoard;
                        m_BoardGame.RowOfBoard = i_RowOfBoard;
                        m_BoardGame.CreateBoard();
                    }
                }
            }

            return flag;
        }

        private bool isGameOver()
        {
            bool flag = true;
            
            for (int i = 0; i < m_BoardGame.CountOfMatchingCard.Length; i++)
            {
                if (m_BoardGame.CountOfMatchingCard[i] == 0)
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        private char revealCard(int i_RowIndexOfCard, int i_ColIndexOfCard)
        {
            return m_BoardGame.Board[i_RowIndexOfCard, i_ColIndexOfCard];
        }

        private void updateScore()
        {
            if (m_PlayerNumber1.IsPlayerTurn == true)
            {
                m_PlayerNumber1.PlayerScore++;
            }
            else
            {
                if (m_GamePlayerVSPlayer == true)
                {
                    m_PlayerNumber2.PlayerScore++;
                }
                else
                {
                    m_ComputerPlay.ComputerScore++;
                }
            }

            if (UpdateScoreHandler != null)
            {
                UpdateScoreHandler.Invoke();
            }
        }

        private void exchangeTurns()
        {
            if (m_PlayerNumber1.IsPlayerTurn == true)
            {
                m_PlayerNumber1.IsPlayerTurn = false;
                if (m_GameComputerVSPlayer == true)
                {
                    m_ComputerPlay.IsComputerTurn = true;
                }
                else
                {
                    m_PlayerNumber2.IsPlayerTurn = true;
                }
            }
            else
            {
                m_PlayerNumber1.IsPlayerTurn = true;
                if (m_GameComputerVSPlayer == true)
                {
                    m_ComputerPlay.IsComputerTurn = false;
                }
                else
                {
                    m_PlayerNumber2.IsPlayerTurn = false;
                }
            }

            if (ExchangeTurnsHandler != null)
            {
                ExchangeTurnsHandler.Invoke();
            }
        }

        private void determiningTheWinner()
        {
            m_Winner = new Player();

            if (m_GamePlayerVSPlayer == true)
            {
                if (m_PlayerNumber1.PlayerScore > m_PlayerNumber2.PlayerScore)
                {
                    m_Winner.PlayerName = m_PlayerNumber1.PlayerName;
                    m_Winner.PlayerScore = m_PlayerNumber1.PlayerScore;
                }
                else
                {
                    m_Winner.PlayerName = m_PlayerNumber2.PlayerName;
                    m_Winner.PlayerScore = m_PlayerNumber2.PlayerScore;
                }
            }
            else
            {
                if (m_PlayerNumber1.PlayerScore > m_ComputerPlay.ComputerScore)
                {
                    m_Winner.PlayerName = m_PlayerNumber1.PlayerName;
                    m_Winner.PlayerScore = m_PlayerNumber1.PlayerScore;
                }
                else
                {
                    m_Winner.PlayerName = "The Computer";
                    m_Winner.PlayerScore = m_ComputerPlay.ComputerScore;
                }
            }
        }

        public void ComputerChooseTwoCards()
        {
            int firstCardChosenByComputer = 0;
            int secondCardChosenByComputer = 0;
            int randomIndex = m_RandValue.Next(0, m_BoardGame.AvailableCardsToChoose.Count);

            if (m_BoardGame.AvailableCardsToChoose.Count != 0)
            {
                firstCardChosenByComputer = m_BoardGame.AvailableCardsToChoose[randomIndex];
                m_BoardGame.AvailableCardsToChoose.Remove(m_BoardGame.AvailableCardsToChoose[randomIndex]);
                randomIndex = m_RandValue.Next(0, m_BoardGame.AvailableCardsToChoose.Count);
                secondCardChosenByComputer = m_BoardGame.AvailableCardsToChoose[randomIndex];
                m_BoardGame.AvailableCardsToChoose.Add(firstCardChosenByComputer);
                if (ComputerMoveHandler != null)
                {
                    ComputerMoveHandler.Invoke((firstCardChosenByComputer / 10) - 1, (firstCardChosenByComputer % 10) - 1, (secondCardChosenByComputer / 10) - 1, (secondCardChosenByComputer % 10) - 1);
                    isMatchingCard((firstCardChosenByComputer / 10) - 1, (firstCardChosenByComputer % 10) - 1, (secondCardChosenByComputer / 10) - 1, (secondCardChosenByComputer % 10) - 1);
                }
            }
        }

        public void PlayerMakeMove()
        {
            int firstCardRow = 0;
            int firstCardCol = 0; 
            int secondCardRow = 0; 
            int secondCardCol = 0;
            if (GetTwoCardsHandler != null)
            {
                GetTwoCardsHandler.Invoke(out firstCardRow, out firstCardCol, out secondCardRow, out secondCardCol);
            }

            if (isMatchingCard(firstCardRow, firstCardCol, secondCardRow, secondCardCol))
            {
                updateScore();

                if (TwoCardsMatchedHandler != null)
                {
                    TwoCardsMatchedHandler.Invoke();
                }

                if (isGameOver() == true)
                {
                    if (GameOverHandler != null)
                    {
                        determiningTheWinner();
                        GameOverHandler.Invoke();
                    }
                }
            }
            else
            {
                exchangeTurns();
            }
        }
    }
}
