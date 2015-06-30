using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Player
    {
        private string m_PlayerName = null;
        private int m_PlayerScore = 0;
        private bool m_IsPlayerTurn = false;

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }

        public int PlayerScore
        {
            get { return m_PlayerScore; }
            set { m_PlayerScore = value >= 0 ? value : 0; }
        }

        public bool IsPlayerTurn
        {
            get { return m_IsPlayerTurn; }
            set { m_IsPlayerTurn = value; }
        }
    }
}
