using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.PInvokes
{
    /// <summary>
    /// CRef: https://developer.gnome.org/gio/stable/gio-GSettingsSchema-GSettingsSchemaSource.html
    /// </summary>
    internal class GSettingsSchemaKey
    {
        [DllImport("libgio-2.0.so.0", EntryPoint = "g_settings_schema_key_ref")]
        public static extern IntPtr Ref(IntPtr gSettingsSchemaKey);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_settings_schema_key_unref")]
        public static extern void UnRef(IntPtr gSettingsSchemaKey);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_settings_schema_key_get_value_type")]
        public static extern IntPtr GetValueType(IntPtr gSettingsSchemaKey);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_settings_schema_key_get_default_value")]
        public static extern IntPtr GetDefaultValue(IntPtr gSettingsSchemaKey);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_settings_schema_key_get_range")]
        public static extern IntPtr GetRange(IntPtr gSettingsSchemaKey);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_settings_schema_key_range_check")]
        public static extern bool RangeCheck(IntPtr gSettingsSchemaKey, IntPtr gVariantValue);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_settings_schema_key_get_name")]
        public static extern string GetName(IntPtr gSettingsSchemaKey);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_settings_schema_key_get_summary")]
        public static extern string GetSummary(IntPtr gSettingsSchemaKey);

        [DllImport("libgio-2.0.so.0", EntryPoint = "g_settings_schema_key_get_description")]
        public static extern string GetDescription(IntPtr gSettingsSchemaKey);
    }
}
