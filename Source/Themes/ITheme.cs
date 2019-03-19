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

        Point ImageOffset { get; }

        Size ControlBoxSize { get; }

        bool ForceFlat { get; }

        Size FrameBorder { get; }

        bool IsDisplayed { get; }

        bool Maximized { get; set; }

        Size SystemButtonSize { get; }

    }
}
