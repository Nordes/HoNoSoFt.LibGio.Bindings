using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.PInvokes
{
    /// <summary>
    /// CRef: https://developer.gnome.org/gio/stable/gio-GSettingsSchema-GSettingsSchemaSource.html
    /// </summary>
    internal class GSettingsSchema
    {
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_ref")]
        public static extern IntPtr Ref(IntPtr gSettingsSchema);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_unref")]
        public static extern void UnRef(IntPtr gSettingsSchema);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_get_id")]
        public static extern IntPtr GetId(IntPtr gSettingsSchema);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_get_path")]
        public static extern IntPtr GetPath(IntPtr gSettingsSchema);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_has_key")]
        public static extern bool HasKey(IntPtr gSettingsSchema, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_get_key")]
        public static extern IntPtr GetKey(IntPtr gSettingsSchema, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_list_children")]
        public static extern IntPtr ListChildren(IntPtr gSettingsSchema);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_list_keys")]
        public static extern IntPtr ListKeys(IntPtr gSettingsSchema);
    }
}
