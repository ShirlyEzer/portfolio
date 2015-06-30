using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    /// <summary>
    /// Class represent a final item which run a method.
    /// </summary>
    /// <remarks>
    /// This class inherits from MenuItem
    /// <see cref="MenuItem"/>
    /// </remarks>
    public class LeafItem : MenuItem
    {
        private IStartActionHandler m_StartAction;

        public IStartActionHandler StartAction
        {
            get { return this.m_StartAction; }
            set { this.m_StartAction = value; }
        }

        public LeafItem(string i_ItemName, IStartActionHandler i_IStartAction) : base(i_ItemName)
        {
            this.m_StartAction = i_IStartAction;
        }
    }
}
