/*=============================================================================
/*=============================================================================
*
*	(C) Copyright 2011, Michael Carlisle (mike.carlisle@thecodeking.co.uk)
*
*   http://www.TheCodeKing.co.uk
*  
*	All rights reserved.
*	The code and information is provided "as-is" without waranty of any kind,
*	either expresed or implied.
*
*-----------------------------------------------------------------------------
*	History:
*		01/09/2007	Michael Carlisle				Version 1.0
*=============================================================================
*/
using System.Windows.Forms;
using TheCodeKing.ActiveButtons.Controls.Enums;
using TheCodeKing.ActiveButtons.Utils;

namespace TheCodeKing.ActiveButtons.Controls.Themes {
    internal class ThemeFactory {
        private readonly Form _form;
        private readonly CustomThemes? _customTheme;

        public ThemeFactory(Form form, CustomThemes? customTheme = null) {
            this._form = form;

            if (customTheme != null && customTheme == CustomThemes.Netspeed) {
                this._customTheme = customTheme;
            }
        }

        public ITheme GetTheme() {
            if (_customTheme != null) {
                if (_customTheme == CustomThemes.Netspeed) {
                    return new Netspeed(_form);
                }
            }

            if (Win32.DwmIsCompositionEnabled && (Win32.version == 6 && Win32.versionMinor == 2)) {
                // vista
                return new Windows8(_form);
            } else if (Win32.DwmIsCompositionEnabled) {
                // vista
                return new Aero(_form);
            } else if (Application.RenderWithVisualStyles && Win32.version > 6) {
                // vista basic
                return new Styled(_form);
            } else if (Application.RenderWithVisualStyles) {
                // xp
                return new XPStyle(_form);
            } else {
                return new Standard(_form);
            }
        }
    }
}