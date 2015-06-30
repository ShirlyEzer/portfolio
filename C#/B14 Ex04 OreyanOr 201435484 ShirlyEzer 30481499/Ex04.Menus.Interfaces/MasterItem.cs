using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    /// <summary>
    /// Class represent an item which have a sub menu.
    /// </summary>
    /// <remarks>
    /// This class inherits from MenuItem
    /// <see cref="MenuItem"/>
    /// </remarks>
    public class MasterItem : MenuItem
    {
        private readonly List<MenuItem> r_MenuItemsList = null;

        public List<MenuItem> MenuItemsList
        {
            get { return r_MenuItemsList; }
        }

        public MasterItem(string i_ItemName)
            : base(i_ItemName)
        {
            r_MenuItemsList = new List<MenuItem>(0);
        }

        public void AddItem(MenuItem i_MenuItemToAdd)
        {
            r_MenuItemsList.Add(i_MenuItemToAdd);
        }
    }
}
