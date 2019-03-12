using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings
{
    public static class GSettings
    {
        // https://developer.gnome.org/gio/stable/GSettings.html#g-settings-set-int64
        // https://developer.gnome.org/glib/stable/glib-Basic-Types.html#gint
        // Some example: https://lzone.de/examples/Glib

        /// <summary>
        /// Gets the GSettings pointer for the requested schema.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_new")]
        public static extern IntPtr New(string schema);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_new_with_path")]
        public static extern IntPtr New(string schema, string path);

        // Not implemented: g_settings_new_with_backend
        // Not implemented: g_settings_new_with_backend_and_path
        // Not implemented: g_settings_new_full 

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_sync")]
        public static extern void Sync();

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_is_writable")]
        public static extern bool IsWritable(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_delay")]
        public static extern void Delay(IntPtr settings);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_apply")]
        public static extern void Apply(IntPtr settings);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_revert")]
        public static extern void Revert(IntPtr settings);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_has_unapplied")]
        public static extern bool UnApplied(IntPtr settings);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_child")]
        public static extern IntPtr GetChild(IntPtr settings, string childSchemaName);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_reset")]
        public static extern void Reset(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_user_value")]
        public static extern object GetUserValue(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_default_value")]
        public static extern object GetDefaultValue(IntPtr settings, string key);

        [Obsolete("Deprecated since Version 2.40")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_list_schemas")]
        public static extern string[] ListSchemas();
        // Deprecated: g_settings_list_relocatable_schemas 
        // Deprecated: g_settings_list_keys 


        /// <summary>
        /// Get the value.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="key"></param>
        /// <returns>A GVariant</returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_value")]
        public static extern object GetValue(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_value")]
        public static extern bool SetValue(IntPtr settings, string key, object value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_int")]
        public static extern int GetInt(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_int")]
        public static extern bool SetInt(IntPtr settings, string key, int value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_int64")]
        public static extern long GetInt64(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_int64")]
        public static extern bool SetInt64(IntPtr settings, string key, long value);
    }
}
