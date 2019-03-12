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

namespace ActiveButtons.Themes
{
    internal interface ITheme
    {
        Color BackColor { get; }

        Point ButtonOffset { get; }

        Size ControlBoxSize { get; }

        bool ForceFlat { get; }

        Size FrameBorder { get; }

        bool IsDisplayed { get; }

        bool Maximized { get; set; }

        Size SystemButtonSize { get; }
    }
}
