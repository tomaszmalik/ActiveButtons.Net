using System.Drawing;
using System.Windows.Forms;

namespace TheCodeKing.ActiveButtons.Controls.Themes {
    internal class Windows8 : Aero {
        public Windows8(Form form)
            : base(form) {
        }

        public override Size SystemButtonSize {
            get {
                if (IsToolbar) {
                    Size size = SystemInformation.SmallCaptionButtonSize;
                    size.Height += 4;
                    size.Width = 36;
                    base.systemButtonSize = size;
                } else {
                    Size size = SystemInformation.CaptionButtonSize;
                    size.Height += base.Maximized ? 0 : 6;
                    size.Width = 48;
                    base.systemButtonSize = size;
                }
                return base.systemButtonSize;
            }
        }

        public override Point ButtonOffset {
            get {
                if (base.buttonOffset == Point.Empty) {
                    if (IsToolbar) {
                        base.buttonOffset = new Point(-40, 0);
                    } else {
                        base.buttonOffset = new Point(-40, 0);
                    }
                }

                return base.buttonOffset;
            }
        }

        public override bool ForceFlat {
            get {
                return true;
            }
        }
    }
}