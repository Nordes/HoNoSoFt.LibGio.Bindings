    using System;
    using System.Runtime.InteropServices;

    namespace HoNoSoFt.LibGio.Bindings
    {
    public static class GSettings
    {
        // All API's defined by using command: `nm -D libgio-2.0.so`
        // https://developer.gnome.org/gio/stable/GSettings.html#g-settings-set-int64
        // https://developer.gnome.org/glib/stable/glib-Basic-Types.html#gint
        // Some example: https://lzone.de/examples/Glib

        /// <summary>
        /// Creates a new GSettings object with the schema specified by schema_id.
        ///
        /// Signals on the newly created GSettings object will be dispatched via the thread-default
        /// GMainContext in effect at the time of the call to g_settings_new(). The new GSettings will
        /// hold a reference on the context.See g_main_context_push_thread_default().
        /// </summary>
        /// <param name="schema">the ID of the schema</param>
        /// <returns>A new GSettings object (pointer)</returns>
        /// <remarks>Since: 2.26</remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_new")]
        public static extern IntPtr New(string schema);

        /// <summary>
        /// Creates a new GSettings object with the relocatable schema specified by schema_id and a given path.
        ///
        /// You only need to do this if you want to directly create a settings object with a schema that doesn't
        /// have a specified path of its own. That's quite rare.
        ///
        /// It is a programmer error to call this function for a schema that has an explicitly specified path.
        ///
        /// It is a programmer error if path is not a valid path. A valid path begins and ends with '/' and
        /// does not contain two consecutive '/' characters.
        /// </summary>
        /// <param name="schema">The ID of the schema</param>
        /// <param name="path">The path to use</param>
        /// <returns>A new GSettings object (pointer)</returns>
        /// <remarks>Since: 2.26</remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_new_with_path")]
        public static extern IntPtr New(string schema, string path);

        // Not implemented: g_settings_new_with_backend
        // Not implemented: g_settings_new_with_backend_and_path
        // Not implemented: g_settings_new_full 

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_sync")]
        public static extern void Sync();

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

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_list_children")]
        public static extern string[] ListChildren(IntPtr settings);

        // Deprecated: g_settings_get_range
        
        [Obsolete("Deprecated since Version 2.40")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_range_check")]
        public static extern bool RangeCheck(IntPtr settings, string key, object value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get")]
        public static extern void Get(IntPtr settings, string key, string format, params object[] value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set")]
        public static extern void Set(IntPtr settings, string key, string format, params object[] value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_boolean")]
        public static extern bool GetBoolean(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_boolean")]
        public static extern bool SetBoolean(IntPtr settings, string key, bool value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_int")]
        public static extern int GetInt(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_int")]
        public static extern bool SetInt(IntPtr settings, string key, int value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_int64")]
        public static extern long GetInt64(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_int64")]
        public static extern bool SetInt64(IntPtr settings, string key, long value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_uint")]
        public static extern uint GetUInt(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_uint")]
        public static extern bool SetUInt(IntPtr settings, string key, uint value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_uint64")]
        public static extern ulong GetUInt64(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_uint64")]
        public static extern bool SetUInt64(IntPtr settings, string key, ulong value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_double")]
        public static extern double GetDouble(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_double")]
        public static extern bool SetDouble(IntPtr settings, string key, double value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_string")]
        public static extern string GetString(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_string")]
        public static extern bool SetString(IntPtr settings, string key, string value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_strv")]
        public static extern string[] GetStrv(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_strv")]
        public static extern bool SetStrv(IntPtr settings, string key, string[] values);
 
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_enum")]
        public static extern int GetEnum(IntPtr settings, string key);
 
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_enum")]
        public static extern bool GetEnum(IntPtr settings, string key, int value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_flags")]
        public static extern uint GetFlags(IntPtr settings, string key);
 
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_flags")]
        public static extern bool GetFlags(IntPtr settings, string key, uint value);

        [DllImport("libgio-2.0.so", EntryPoint = "GSettingsGetMapping")]
        public static extern unsafe bool GetMapping(object value, void* result, void* userData);

        //[DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_mapped")]
        //public static extern unsafe void* GetMapped(uint settings, string key, gSettingMapping mapping, void* userData);

        // g_settings_bind 
        // g_settings_bind_with_mapping 
        // g_settings_bind_writable
        // g_settings_unbind
        // GSettingsBindSetMapping
        // GSettingsBindGetMapping
        // g_settings_create_action
    }
}
