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
using System.Windows.Forms;

namespace ActiveButtons.Themes
{
    internal class XPStyle : Styled
    {
        public override Color BackColor
        {
            get
            {
                if (backColor == Color.Empty)
                    backColor = Color.FromKnownColor(KnownColor.ActiveBorder);
                return backColor;
            }
        }

        public override Size FrameBorder
        {
            get
            {
                if (frameBorder == Size.Empty)
                    frameBorder = new Size(base.FrameBorder.Width + 2, base.FrameBorder.Height);
                return frameBorder;
            }
        }

        public XPStyle(Form form)
            : base(form)
        { }
    }
}
