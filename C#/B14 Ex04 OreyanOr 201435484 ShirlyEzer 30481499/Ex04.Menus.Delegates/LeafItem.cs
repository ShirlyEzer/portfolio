using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void DoActionHandler();

    /// <summary>
    /// Class represent a final item which run a method.
    /// </summary>
    /// <remarks>
    /// This class inherits from MenuItem
    /// <see cref="MenuItem"/>
    /// </remarks>
    public class LeafItem : MenuItem
    {
        public event DoActionHandler DoAction;

        public LeafItem(string i_ItemName) 
            : base(i_ItemName)
        {
        }

        public void RunMethod()
        {
            if (DoAction != null)
            {
                DoAction.Invoke();
            }
        }
    }
}
