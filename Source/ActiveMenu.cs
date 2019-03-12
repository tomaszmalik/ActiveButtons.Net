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
using System.Windows.Forms;

namespace ActiveButtons
{
    /// <summary>
    ///     The ActiveMenu class used to create concrete instances of the
    ///     <see cref="T:IActiveMenu"></see> instance.
    /// </summary>
    /// <example>
    ///     This sample shows how to get an instance of the IActiveMenu and
    ///     render an instance of a button in the title bar.
    ///     <code>
    ///         // get an instance of the menu for the current form
    ///         IActiveMenu menu = ActiveMenu.GetInstance(this);
    /// 
    ///         // create a new instance of ActiveButton
    ///         var button = menu.Items.CreateItem();
    ///         button.Text = "One";
    ///         button.BackColor = Color.Blue;
    ///         button.Click += new EventHandler(button_Click);
    /// 
    ///         // add the button to the title bar menu
    ///         menu.Items.Add(button);
    ///     </code>
    /// </example>
    public static class ActiveMenu
    {
        /// <summary>
        ///     Creates or returns the menu instance for a given form.
        /// </summary>
        public static IActiveMenu GetInstance(Form form, int leftAdjust = 0, int topAdjust = 0)
        {
            return ActiveMenuForm.GetInstance(form, leftAdjust, topAdjust);
        }
    }
}
