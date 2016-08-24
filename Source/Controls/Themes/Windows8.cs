using System.Drawing;
using System.Windows.Forms;

namespace TheCodeKing.ActiveButtons.Controls.Themes
{
	internal class Windows8 : Aero
	{
		public Windows8(Form form)
			: base(form)
		{
		}

		public override Size SystemButtonSize
		{
			get
			{
				if (base.systemButtonSize == Size.Empty)
				{
					if (IsToolbar)
					{
						Size size = SystemInformation.SmallCaptionButtonSize;
						size.Height += 2;
						size.Width = 36;
						base.systemButtonSize = size;
					}
					else
					{
						Size size = SystemInformation.CaptionButtonSize;
						size.Height += 3;
						size.Width = 48;
						base.systemButtonSize = size;
					}
				}
				return base.systemButtonSize;
			}
		}
	}
}