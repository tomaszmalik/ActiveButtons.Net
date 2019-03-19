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

        public XPStyle(Form form) : base(form) { }
    }
}
