/*=============================================================================
*
*   (C) Copyright 2011, Michael Carlisle (mike.carlisle@thecodeking.co.uk)
*
*   http://www.TheCodeKing.co.uk
*  
*   All rights reserved.
*   The code and information is provided "as-is" without waranty of any kind,
*   either expresed or implied.
*
*-----------------------------------------------------------------------------
*   History:
*       01/09/2007  Michael Carlisle                Version 1.0
*=============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActiveButtons.Utils;

namespace ActiveButtons
{
    /// <summary>
    ///     The implementation of ActiveItems used to store a list of buttons in
    ///     the ActiveMenu.
    /// </summary>
    internal class ActiveButtonCollection : ListCollection<IActiveButton>, IActiveButtonCollection
    {
        private ActiveMenuForm Owner { get; }

        public ActiveButtonCollection(ActiveMenuForm owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));
            Owner = owner;
        }


        public IActiveButton CreateItem()
        {
            return new ActiveButton();
        }
        public IActiveButton CreateItem(string text, EventHandler click)
        {
            var button = new ActiveButton();
            button.Text = text;
            button.Click += click;

            return button;
        }
        public IActiveButton Add(string text, EventHandler click)
        {
            var button = CreateItem(text, click);
            Add(button);
            return button;
        }

        protected override void OnListChanged()
        {
            Owner.OnItemsCollectionChanged();
        }
    }
}
