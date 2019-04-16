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
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_new_maybe")]
        internal static extern IntPtr NewMaybe(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_new_array")]
        internal static extern IntPtr NewArray(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_new_tuple")]
        internal static extern IntPtr NewTuple(IntPtr gVariantType, int length);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_new_dict_entry")]
        internal static extern IntPtr NewDictEntry(IntPtr key, IntPtr value);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_dup_string")]
        internal static extern string DupString(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_is_definite")]
        internal static extern bool IsDefinite(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_is_container")]
        internal static extern bool IsContainer(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_is_basic")]
        internal static extern bool IsBasic(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_is_maybe")]
        internal static extern bool IsMaybe(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_is_array")]
        internal static extern bool IsArray(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_is_tuple")]
        internal static extern bool IsTuple(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_is_dict_entry")]
        internal static extern bool IsDictEntry(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_is_variant")]
        internal static extern bool IsVariant(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_hash")]
        internal static extern uint Hash(IntPtr gVariantType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_equal")]
        internal static extern bool Equal(IntPtr gVariantType, IntPtr gVariantType2);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_is_subtype_of")]
        internal static extern bool IsSubTypeOf(IntPtr type, IntPtr superType);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_element")]
        internal static extern IntPtr Element(IntPtr type);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_n_items")]
        internal static extern ulong NItems(IntPtr type);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_first")]
        internal static extern IntPtr First(IntPtr type);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_next")]
        internal static extern IntPtr Next(IntPtr type);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_key")]
        internal static extern IntPtr Key(IntPtr type);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_value")]
        internal static extern IntPtr Value(IntPtr type);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_free")]
        internal static extern void Free(IntPtr type);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_copy")]
        internal static extern IntPtr Copy(IntPtr type);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_string_is_valid")]
        internal static extern bool StringIsValid(string typeString);
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_type_string_scan")]
        internal static extern bool StringIsValid(string typeString, string limit, IntPtr endPtr);
    }
}
