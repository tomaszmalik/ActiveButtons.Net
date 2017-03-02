using System.Drawing;
using System.Windows.Forms;

namespace TheCodeKing.ActiveButtons.Controls.Themes {
    internal class Netspeed : Aero {
        public Netspeed(Form form)
            : base(form) {
        }

        public override bool IsDisplayed {
            get {
                if (isDisplayed == null) {
                    if ((!form.ControlBox && string.IsNullOrEmpty(form.Text))) {
                        isDisplayed = false;
                    } else {
                        isDisplayed = true;
                    }
                }
                return (bool)isDisplayed;
            }
        }

        public override Size SystemButtonSize {
            get {
                if (IsToolbar) {
                    Size size = SystemInformation.SmallCaptionButtonSize;
                    size.Width = 36;
                    base.systemButtonSize = size;
                } else {
                    Size size = SystemInformation.CaptionButtonSize;
                    size.Width = 48;
                    base.systemButtonSize = size;
                }
                return base.systemButtonSize;
            }
        }

        public override bool ForceFlat {
            get {
                return true;
            }
        }
    }
}