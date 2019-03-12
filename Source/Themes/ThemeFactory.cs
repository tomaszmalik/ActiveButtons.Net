/*=============================================================================
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveButtons.Utils;
using Microsoft.Win32;

namespace ActiveButtons.Themes
{
    internal static class ThemeFactory
    {
        private static bool? s_isWin10;

        private static bool IsWin10
        {
            get
            {
                if (!s_isWin10.HasValue)
                {
                    s_isWin10 = Win32.SystemVersion == 10;
                    if (!s_isWin10.Value)
                        try
                        {
                            var key = Registry.GetValue(
                                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                                "CurrentMajorVersionNumber", null);
                            s_isWin10 = key?.ToString() == "10";
                        }
                        catch (Exception)
                        {
                            s_isWin10 = false;
                        }
                }

                return s_isWin10.Value;
            }
        }


        public static ITheme GetTheme(Form form)
        {
            if (Win32.DwmIsCompositionEnabled && IsWin10)
                return new Windows10(form);

            if (Win32.DwmIsCompositionEnabled && Win32.SystemVersion == 6 && Win32.SystemVersionMinor >= 2)
                return new Windows8(form);

            if (Win32.DwmIsCompositionEnabled)
                return new Aero(form);

            if (Application.RenderWithVisualStyles && Win32.SystemVersion > 6)
                return new Styled(form);

            if (Application.RenderWithVisualStyles)
                return new XPStyle(form);

            return new Standard(form);
        }
    }
}
