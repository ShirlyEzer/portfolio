using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ComputerPlayer
    {
        private int m_ComputerScore = 0;
        private bool m_IsComputerTurn = false;
        public int ComputerScore
        {
            set { m_ComputerScore = value >= 0 ? value : 0; }
            get { return m_ComputerScore; }
        }
        public bool IsComputerTurn
        {
            set { m_IsComputerTurn = value; }
            get { return m_IsComputerTurn; }
        }
    }
}
