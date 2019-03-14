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
using System.Drawing;
using System.Linq;
using System.Text;

namespace ActiveButtons
{
    /// <summary>
    ///     Defines an ActiveMenu item.
    /// </summary>
    public interface IActiveButton
    {
        event EventHandler Click;

        bool Enabled { get; set; }
        object Tag { get; set; }
        string Name { get; set; }

        /// <summary>
        /// Gets or sets button text.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets text color.
        /// </summary>
        Color ForeColor { get; set; }

        /// <summary>
        /// Gets or sets background color.
        /// </summary>
        Color BackColor { get; set; }

        /// <summary>
        /// Button tool tip.
        /// </summary>
        string ToolTipText { get; set; }
    }
}
