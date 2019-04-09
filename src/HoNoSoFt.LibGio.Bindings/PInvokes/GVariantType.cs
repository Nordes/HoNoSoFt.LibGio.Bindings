using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.PInvokes
{
    internal static class GVariantType
    {
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_dup_string")]
        internal static extern string TypePeekString(IntPtr gVariantType);

        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_get_string_length")]
        internal static extern int GetStringLength(IntPtr gVariantType);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariantType.html#g-variant-type-new
        /// </summary>
        /// <param name="typeString">
        /// See doc, but can be "b", "y", "n", "q", "i", "u", "x", "t", "h",
        /// "d", "s", "o", "g" and "?"
        /// </param>
        /// <returns>A new GVariantType pointer</returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_new")]
        internal static extern IntPtr New(string typeString);
    }
}
