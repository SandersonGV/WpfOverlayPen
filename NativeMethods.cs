﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

internal static class NativeMethods
{
    [DllImportAttribute("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();
}
