using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    /// <summary>
    /// Class represent an item.
    /// </summary>
    public class MenuItem
    {
        private string m_ItemName = string.Empty;

        public string ItemName
        {
            get { return m_ItemName; }
            set { m_ItemName = value; }
        }

        public MenuItem(string i_ItemName)
        {
            ItemName = i_ItemName;
        }
    }
}
