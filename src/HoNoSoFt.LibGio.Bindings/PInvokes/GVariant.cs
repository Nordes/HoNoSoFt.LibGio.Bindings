using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.PInvokes
{
    internal static class GVariant
    {
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_boolean")]
        public static extern IntPtr NewBoolean(bool value);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_byte")]
        public static extern IntPtr NewByte(byte value);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_int16")]
        public static extern IntPtr NewInt16(short value);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_int32")]
        public static extern IntPtr NewInt(int value);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_uint32")]
        public static extern IntPtr NewUInt(uint value);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_int64")]
        public static extern IntPtr NewInt64(long value);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_uint64")]
        public static extern IntPtr NewUInt64(ulong value);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_double")]
        public static extern IntPtr NewDouble(double value);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_string")]
        public static extern IntPtr NewString(string value);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_new_variant")]
        public static extern IntPtr NewVariant(IntPtr value);


        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-unref
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_unref")]
        public static extern void Unref(IntPtr gVariant);
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-ref
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_ref")]
        public static extern IntPtr Ref(IntPtr gVariant);
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-ref-sink
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_ref_sink")]
        public static extern IntPtr RefSink(IntPtr gVariantValue);
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-is-floating
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_is_floating")]
        public static extern bool IsFloating(IntPtr gVariantValue);
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-take-ref
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_take_ref")]
        public static extern bool TakeRef(IntPtr gVariantValue);
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-get-type
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_type")]
        public static extern IntPtr GetType(IntPtr gVariantValue);
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-get-type-string
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_type_string")]
        public static extern IntPtr GetTypeString(IntPtr gVariantValue);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_is_of_type")]
        public static extern bool IsOfType(IntPtr gVariantValue, IntPtr gVariantType);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_is_container")]
        public static extern bool IsContainer(IntPtr gVariantValue);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_is_object_path")]
        public static extern bool IsObjectPath(string objectPath);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_is_signature")]
        public static extern bool IsSignature(string objectPath);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_boolean")]
        public static extern bool GetBoolean(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_byte")]
        public static extern byte GetByte(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_int16")]
        public static extern short GetInt16(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_uint16")]
        public static extern ushort GetUInt16(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_int32")]
        public static extern int GetInt(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_uint32")]
        public static extern uint GetUInt(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_int64")]
        public static extern long GetInt64(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_uint64")]
        public static extern ulong GetUInt64(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_handle")]
        public static extern int GetHandle(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_double")]
        public static extern double GetDouble(IntPtr gVariant);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_string")]
        public static extern string GetString(IntPtr gVariant, IntPtr size);

        // Require to free "The return value must be freed using g_free()."
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_dup_string")]
        public static extern string DupString(IntPtr gVariant, IntPtr size);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_variant")]
        public static extern IntPtr GetVariant(IntPtr gVariant);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_print_string")]
        public static extern IntPtr PrintString(IntPtr gVariant, IntPtr gString, bool typeAnnotate);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_compare")]
        public static extern int Compare(IntPtr one, IntPtr two);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_classify")]
        public static extern GVariantClass Classify(IntPtr gVariantValue);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_check_format_string")]
        public static extern bool CheckFormatString(IntPtr gVariantValue, string formatString, bool copyOnly);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get")]
        public static extern void Get(IntPtr gVariantValue, string formatString, params string[] formatParams);

        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-print
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_print")]
        public static extern string Print(IntPtr gVariantValue, bool typeAnnotate);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_maybe")]
        public static extern IntPtr GetMaybe(IntPtr gVariantValue);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_n_children")]
        public static extern ulong NChildren(IntPtr gVariantValue);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_child_value")]
        public static extern IntPtr GetChildValue(IntPtr gVariantValue, ulong index);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_lookup_value")]
        public static extern IntPtr LookupValue(IntPtr gVariantDictionary, string key, IntPtr expectedType);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_size")]
        public static extern ulong GetSize(IntPtr gVariantValue);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_data_as_bytes")]
        public static extern byte[] GetDataAsByte(IntPtr gVariantValue);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_byteswap")]
        public static extern IntPtr ByteSwap(IntPtr gVariantValue);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_get_normal_form")]
        public static extern IntPtr GetNormalForm(IntPtr gVariantValue);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_is_normal_form")]
        public static extern bool IsNormalForm(IntPtr gVariantValue);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_hash")]
        public static extern uint Hash(IntPtr gVariantValue);
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_variant_equal")]
        public static extern bool Equal(IntPtr one, IntPtr two);
    }
}
