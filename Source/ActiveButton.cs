﻿/*=============================================================================
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
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveButtons.Themes;
using ActiveButtons.Utils;

namespace ActiveButtons
{
    /// <summary>
    ///     An instance of a button which can be added to the
    ///     ActiveButtons menu.
    /// </summary>
    /// <example>
    ///     The ActiveButton class can be used to create new
    ///     button instances, which can be added to the current IActiveMenu. The
    ///     Height and Width properties of the button class are auto-configured
    ///     based on the current platform and theme.
    ///     <code>
    ///         // get an instance of the menu for the current form
    ///         IActiveMenu menu = ActiveMenu.GetInstance(this);
    /// 
    ///         // create a new instance of ActiveButton
    ///         ActiveButton button = new ActiveButton();
    /// 
    ///         // set the button properties
    ///         button.Text = "One";
    ///         button.BackColor = Color.Red;
    /// 
    ///         // attach button event handlers
    ///         button.Click += new EventHandler(button_Click);
    /// 
    ///         // add the button to the title bar menu
    ///         menu.Items.Add(button);
    ///     </code>
    /// </example>
    internal class ActiveButton : Button, IActiveButton
    {
        private Size buttonSize;
        private int buttonX;
        private int buttonY;
        private Size textSize;
        private ITheme theme;
        private string _toolTipText;
        private string _text;

        /// <summary>
        ///     Gets or sets the text property of the button control.
        /// </summary>
        /// <value>The text.</value>
        public new string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    CalcButtonSize();
                }
            }
        }

        public string ToolTipText
        {
            get => _toolTipText;
            set
            {
                if (_toolTipText != value)
                {
                    _toolTipText = value;
                    (Parent as ActiveMenuForm)?.OnButtonToolTipChanged(this);
                }
            }
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                if (value.IsEmpty)
                    value = Color.WhiteSmoke;

                base.BackColor = value;
            }
        }

        /// <summary>
        ///     Gets or sets the theme.
        /// </summary>
        /// <value>The theme.</value>
        internal ITheme Theme
        {
            get => theme;
            set
            {
                if (theme != value)
                {
                    theme = value;
                    CalcButtonSize();
                }
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActiveButton" /> class.
        /// </summary>
        public ActiveButton()
        {
            Initialize();
        }


        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        protected void Initialize()
        {
            if (Win32.DwmIsCompositionEnabled || Application.RenderWithVisualStyles)
                base.BackColor = Color.Transparent;
            else
                base.BackColor = Color.FromKnownColor(KnownColor.Control);

            SystemColorsChanged += ActiveButton_SystemColorsChanged;

            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TextAlign = ContentAlignment.MiddleCenter;
            Visible = false;

            CalcButtonSize();
        }

        /// <summary>
        ///     Calculates the size of the button.
        /// </summary>
        public void CalcButtonSize(bool maximized = false)
        {
            if (theme != null)
            {
                theme.Maximized = maximized;

                buttonSize = theme.SystemButtonSize;

                if (BackColor == Color.Empty)
                    BackColor = theme.BackColor;

                if (ForeColor == Color.Empty)
                    ForeColor = Color.Black;

                if (theme.ForceFlat)
                {
                    FlatStyle = FlatStyle.Flat;
                    FlatAppearance.BorderSize = 0;

                    buttonSize.Height -= 6;
                }
            }
            else
            {
                buttonSize = SystemInformation.CaptionButtonSize;
            }

            var width = buttonSize.Width;
            var height = buttonSize.Height;

            using (var e = Graphics.FromHwnd(Handle))
            {
                var text = Text;
                if (text?.Length > 23)
                    text = text.Substring(0, 20) + "...";

                textSize = e.MeasureString(text, Font, new SizeF(300, 40), StringFormat.GenericTypographic).ToSize();
            }

            if (width < textSize.Width + 20)
                width = textSize.Width + 20;

            buttonX = (width - textSize.Width) / 2 - 1;
            buttonY = (height - textSize.Height) / 2 - 1;

            Size = new Size(width, height);
        }

        /// <summary>
        ///     Handles the SystemColorsChanged event of the ActiveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void ActiveButton_SystemColorsChanged(object sender, EventArgs e)
        {
            CalcButtonSize();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var color = Enabled ? ForeColor : ForeColor.Lerp(Color.White, 0.40f);

            using (var sf = StringFormat.GenericTypographic)
            using (var brush = new SolidBrush(color))
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                var text = Text;
                if (text?.Length > 23)
                    text = text.Substring(0, 20) + "...";

                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                e.Graphics.DrawString(text, Font, brush, ClientRectangle, sf);
            }
        }
    }
}
