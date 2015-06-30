using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    /// <summary>
    /// Interface for classes of final item which runs a method
    /// </summary>
    public interface IStartActionHandler
    {
        void DoAction(LeafItem i_LeafItem);
    }
}
