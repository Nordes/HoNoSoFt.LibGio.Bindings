using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HoNoSoFt.LibGio.Bindings.Utilities
{
    internal static class StringUtilityFunction
    {
        //https://developer.gnome.org/glib/stable/glib-String-Utility-Functions.html#g-strfreev
        [DllImport("libglib-2.0.so", EntryPoint = "g_strfreev")]
        internal static extern void GStrFreeV(IntPtr pointer);
    }
}
