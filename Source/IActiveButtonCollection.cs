using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveButtons
{
    /// <summary>
    ///     A list of buttons to be rendered in the ActiveButton's menu.
    /// </summary>
    public interface IActiveButtonCollection : IList<IActiveButton>
    {
        IActiveButton CreateItem();
        IActiveButton CreateItem(string text, EventHandler click);

        IActiveButton Add(string text, EventHandler click);
    }
}
