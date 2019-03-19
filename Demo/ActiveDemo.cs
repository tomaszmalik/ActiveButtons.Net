using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveButtons;

namespace ActiveDemo
{
    /// <summary>
    ///     Demo Windows Form which demonstrates adding buttons to the title bar using
    ///     the ActiveButtons .Net code library.
    /// </summary>
    public partial class ActiveDemo : Form
    {
        /// <summary>
        ///     Used to increment default button labels
        /// </summary>
        private int buttonInt = 1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActiveDemo" /> class.
        /// </summary>
        public ActiveDemo()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            buttonText.Text = buttonInt++.ToString();

            // Add an about button
            AddButton("Transparent", Color.Empty, ButtonClick);
            AddButton("Color", Color.FromArgb(202, 251, 160), ButtonClick);
            AddButton("Dark", Color.FromArgb(33, 33, 33), ButtonClick).ForeColor = Color.White;
        }

        /// <summary>
        ///     Handles click events on the menu buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void AddButtonClick(object sender, EventArgs e)
        {
            if (buttonText.Text.Length == 0)
                errorLabel.Text = "Enter a button label";
            else
                AddButton(buttonText.Text, colorSwitch.BackColor, ButtonClick);
        }

        /// <summary>
        ///     Helper method for adding items to the menu bar.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="handler"></param>
        private IActiveButton AddButton(string text, Color backColor, EventHandler handler)
        {
            // get an instance of IActiveMenu used to attach
            // buttons to the form
            var menu = ActiveMenu.GetInstance(this);

            // define a new button
            var button = menu.Items.CreateItem(text, handler);
            button.ToolTipText = "Tooltip " + button.Text;
            button.BackColor = backColor;

            // add the button to the menu
            menu.Items.Add(button);

            errorLabel.Text = "";
            buttonText.Text = buttonInt++.ToString();

            return button;
        }

        /// <summary>
        ///     Handles the Click event of the title bar buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            var button = (IActiveButton)sender;
            label1.Text = string.Format("Button {0}", button.Text);
            if (button.BackColor == BackColor)
                label1.ForeColor = Color.Black;
            else
                label1.ForeColor = button.BackColor;

            button.Enabled = false;
        }

        /// <summary>
        ///     Handles the Click event of the colorPickerBtn control, to enable
        ///     selection of a button color.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void ColorPickerButtonClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                colorSwitch.BackColor = colorDialog1.Color;
        }

        /// <summary>
        ///     Handles the removal of buttons from the menu bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButtonClick(object sender, EventArgs e)
        {
            var menu = ActiveMenu.GetInstance(this);
            if (menu.Items.Count > 0)
                menu.Items.RemoveAt(menu.Items.Count - 1);
        }
    }
}
