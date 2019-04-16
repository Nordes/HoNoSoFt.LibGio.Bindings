using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.PInvokes
{
    internal static class GString
    {
        [DllImport("libgio-2.0.so", EntryPoint = "g_string_new")]
        public static extern IntPtr New(string str);

        [DllImport("libgio-2.0.so", EntryPoint = "g_string_assign")]
        public static extern IntPtr Assign(IntPtr gString, string str);
        //g_string_vprintf
        //g_string_append_vprintf
        //g_string_printf
        //g_string_append_printf
        [DllImport("libgio-2.0.so", EntryPoint = "g_string_append")]
        public static extern IntPtr Append(IntPtr gString, string str);
        [DllImport("libgio-2.0.so", EntryPoint = "g_string_append")]
        public static extern IntPtr Append(IntPtr gString, char ch);
        //g_string_append_unichar
        //g_string_append_len
        //g_string_append_uri_escaped
        [DllImport("libgio-2.0.so", EntryPoint = "g_string_prepend")]
        public static extern IntPtr Prepend(IntPtr gString, string str);
        [DllImport("libgio-2.0.so", EntryPoint = "g_string_prepend_c")]
        public static extern IntPtr Prepend(IntPtr gString, char ch);
        //g_string_prepend_unichar
        //g_string_prepend_len
        //g_string_insert
        //g_string_insert_c
        //g_string_insert_unichar
        //g_string_insert_len
        //g_string_overwrite
        //g_string_overwrite_len
        //g_string_erase
        //g_string_truncate
        //g_string_set_size

        [DllImport("libgio-2.0.so", EntryPoint = "g_string_free")]
        public static extern string Free(IntPtr gString, bool freeSegment);
        //g_string_free_to_bytes
        //g_string_up [Deprecated]
        //g_string_down [Deprecated]
        //g_string_hash
        //g_string_equal
        //
    }
}
