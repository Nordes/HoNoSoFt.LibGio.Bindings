using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.PInvokes
{
    /// <summary>
    /// CRef: https://developer.gnome.org/gio/stable/gio-GSettingsSchema-GSettingsSchemaSource.html
    /// </summary>
    internal class GSettingsSchemaSource
    {
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_source_get_default")]
        public static extern IntPtr GetDefault();

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_source_ref")]
        public static extern IntPtr Ref(IntPtr gSettingsSchemaSource);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_source_unref")]
        public static extern void UnRef(IntPtr gSettingsSchemaSource);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_source_new_from_directory")]
        public static extern IntPtr NewFromDirectory(string directory, IntPtr parentSchemaSource, bool trusted, out IntPtr error);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_source_list_schemas")]
        public static extern void ListSchemas(IntPtr gSettingsSchemaSource, bool recursive, out IntPtr nonRelocatable, out IntPtr relocatable);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_schema_source_lookup")]
        public static extern IntPtr Lookup(IntPtr gSettingsSchemaSource, string schemaId, bool recursive);
    }
}
