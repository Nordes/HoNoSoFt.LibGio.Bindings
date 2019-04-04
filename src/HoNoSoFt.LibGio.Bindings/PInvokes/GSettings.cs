using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.PInvokes
{
    internal static class GSettings
    {

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_new")]
        public static extern IntPtr New(string schema);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_new_with_path")]
        public static extern IntPtr New(string schema, string path);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_boolean")]
        public static extern bool GetBoolean(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_int")]
        public static extern int GetInt(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_int64")]
        public static extern long GetInt64(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_uint")]
        public static extern uint GetUInt(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_uint64")]
        public static extern ulong GetUInt64(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_flags")]
        public static extern uint GetFlags(IntPtr settings, string key);


        [Obsolete("Deprecated: g_settings_list_keys")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_list_keys")]
        public static extern IntPtr ListKeys(IntPtr settings);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_list_children")]
        public static extern IntPtr ListChildren(IntPtr settings);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_reset")]
        public static extern void Reset(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_int")]
        public static extern bool SetInt(IntPtr settings, string key, int value);


        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_sync")]
        public static extern void Sync();
    }
}
