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
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_sync")]
        public static extern void Sync();
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_value")]
        public static extern IntPtr GetValue(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_value")]
        public static extern bool SetValue(IntPtr settings, string key, IntPtr value);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_is_writable")]
        public static extern bool IsWritable(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_delay")]

        public static extern void Delay(IntPtr settings);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_apply")]
        public static extern void Apply(IntPtr settings);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_revert")]
        public static extern void Revert(IntPtr settings);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_has_unapplied")]
        public static extern bool HasUnApplied(IntPtr settings);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_child")]
        public static extern IntPtr GetChild(IntPtr settings, string childSchemaName);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_reset")]
        public static extern void Reset(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_user_value")]
        public static extern object GetUserValue(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_default_value")]
        public static extern object GetDefaultValue(IntPtr settings, string key);

        [Obsolete("Deprecated since Version 2.40, Use g_settings_schema_source_list_schemas() or g_settings_schema_source_lookup()")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_list_schemas")]
        public static extern string[] ListSchemas();

        [Obsolete("Deprecated since Version 2.40, Use g_settings_schema_source_list_schemas() instead")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_list_relocatable_schemas")]
        public static extern string[] ListRelocatableSchemas();

        [Obsolete("Deprecated: g_settings_list_keys should not be used in newly created code")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_list_keys")]
        public static extern IntPtr ListKeys(IntPtr settings);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_list_children")]
        public static extern IntPtr ListChildren(IntPtr settings);

        [Obsolete("Deprecated since Version 2.40, Use g_settings_schema_key_get_range() instead")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_range")]
        public static extern IntPtr GetRange(IntPtr settings, string key);
        [Obsolete("Deprecated since Version 2.40, Use g_settings_schema_key_range_check() instead")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_range_check")]
        public static extern bool RangeCheck(IntPtr settings, string key, object value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get")]
        public static extern void Get(IntPtr settings, string key, string format, params object[] value);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set")]
        public static extern void Set(IntPtr settings, string key, string format, params object[] formatArgs);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_boolean")]
        public static extern bool GetBoolean(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_boolean")]
        public static extern bool SetBoolean(IntPtr settings, string key, bool value);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_int")]
        public static extern int GetInt(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_int")]
        public static extern bool SetInt(IntPtr settings, string key, int value);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_uint")]
        public static extern bool SetUInt(IntPtr settings, string key, uint value);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_int64")]
        public static extern long GetInt64(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_int64")]
        public static extern bool SetInt64(IntPtr settings, string key, long value);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_uint")]
        public static extern uint GetUInt(IntPtr settings, string key);
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
        public static extern IntPtr GetStrv(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_strv")]
        public static extern bool SetStrv(IntPtr settings, string key, string[] values);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_enum")]
        public static extern int GetEnum(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_enum")]
        public static extern bool SetEnum(IntPtr settings, string key, int value);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_flags")]
        public static extern uint GetFlags(IntPtr settings, string key);
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_flags")]
        public static extern bool SetFlags(IntPtr settings, string key, uint value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_create_action")]
        public static extern IntPtr CreateAction(IntPtr settings, string key);
    }
}
