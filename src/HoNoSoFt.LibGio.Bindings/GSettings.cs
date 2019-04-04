using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using HoNoSoFt.LibGio.Bindings.Utilities;

namespace HoNoSoFt.LibGio.Bindings
{
    // Start DBus manually: exec dbus-run-session -- bash
    // Start the Tests: GSETTINGS_SCHEMA_DIR=~/schemas/ dbus-run-session dotnet test
    // ref: https://dbus.freedesktop.org/doc/dbus-run-session.1.html
    public class GSettings
    {
        //// https://developer.gnome.org/gio/stable/GSettings.html#g-settings-get-int64
        // This should be disposed at some point... otherwise I suspect a memory leak.
        // Should be private.
        internal IntPtr Settings { get; set; }

        public GSettings(string schema)
        {
            Settings = PInvokes.GSettings.New(schema);
        }

        public GSettings(string schema, string path)
        {
            Settings = PInvokes.GSettings.New(schema, path);
        }

        public bool GetBoolean(string key)
        {
            return PInvokes.GSettings.GetBoolean(Settings, key);
        }

        public int GetInt(string key)
        {
            return PInvokes.GSettings.GetInt(Settings, key);
        }

        public long GetInt64(string key)
        {
            return PInvokes.GSettings.GetInt64(Settings, key);
        }

        public uint GetUInt(string key)
        {
            return PInvokes.GSettings.GetUInt(Settings, key);
        }

        public ulong GetUInt64(string key)
        {
            return PInvokes.GSettings.GetUInt64(Settings, key);
        }

        public uint GetFlags(string key)
        {
            return PInvokes.GSettings.GetFlags(Settings, key);
        }

        /// <summary>
        /// Deprecated, don't use except in real need.
        /// </summary>
        /// <returns>List of keys in the schema</returns>
        [Obsolete("Deprecated, don't use except in real need. This function is intended for introspection reasons.")]
        public ICollection<string> ListKeys()
        {
            var originalPointer = PInvokes.GSettings.ListKeys(Settings);
            var copyOriginalPointer = originalPointer;
            var keys = MarshalUtility.MarshalStringArray(originalPointer);

            // You should free the return value with g_strfreev() when you are done with it.
            StringUtilityFunction.GStrFreeV(copyOriginalPointer);

            return keys;
        }

        /// <summary>
        /// There is little reason to call this function from "normal" code, since you should already know what
        /// children are in your schema.
        /// </summary>
        /// <returns></returns>
        public ICollection<string> ListChildren()
        {
            var originalPointer = PInvokes.GSettings.ListChildren(Settings);
            var copyOriginalPointer = originalPointer;
            var children = MarshalUtility.MarshalStringArray(originalPointer);

            // You should free the return value with g_strfreev() when you are done with it.
            StringUtilityFunction.GStrFreeV(copyOriginalPointer);

            return children;
        }

        // Should be using some kind of pattern regarding the value.
        // All API's defined by using command: `nm -D libgio-2.0.so`
        // https://developer.gnome.org/gio/stable/GSettings.html#g-settings-set-int64
        // https://developer.gnome.org/glib/stable/glib-Basic-Types.html#gint
        // Some example: https://lzone.de/examples/Glib

        // Not implemented: g_settings_new_with_backend
        // Not implemented: g_settings_new_with_backend_and_path
        // Not implemented: g_settings_new_full 

        public void Sync()
        {
            PInvokes.GSettings.Sync();
        }

        /// <summary>
        /// Get the value.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="key"></param>
        /// <returns>A GVariant</returns>
        /// <remarks>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#GVariant
        /// https://developer.gnome.org/glib/stable/glib-GVariantType.html GVariant type...
        /// https://developer.gnome.org/gobject/stable/gobject-Enumeration-and-Flag-Types.html
        /// https://blog.spyzone.fr/2011/05/ecouter-les-messages-dbus-via-gio/
        ///
        /// https://stackoverflow.com/questions/17379492/marshal-c-struct-to-c-sharp
        /// https://people.gnome.org/~desrt/glib-docs/glib-GVariant.html
        /// https://github.com/GNOME/glib/blob/master/glib/gvariant.c
        /// </remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_value")]
        public static extern IntPtr GetValue(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_value")]
        public static extern bool SetValue(IntPtr settings, string key, IntPtr value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_is_writable")]
        public static extern bool IsWritable(IntPtr settings, string key);

        /// <summary>
        /// https://developer.gnome.org/gio/stable/GSettings.html#g-settings-delay
        /// Combination with Apply() to create "transactions" and Revert() to "rollback"
        /// </summary>
        /// <param name="settings"></param>
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

        public void Reset(string settingKey)
        {
            PInvokes.GSettings.Reset(Settings, settingKey);
        }

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_user_value")]
        public static extern object GetUserValue(IntPtr settings, string key);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get_default_value")]
        public static extern object GetDefaultValue(IntPtr settings, string key);

        [Obsolete("Deprecated since Version 2.40")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_list_schemas")]
        public static extern string[] ListSchemas();
        // Deprecated: g_settings_list_relocatable_schemas 



        // Deprecated: g_settings_get_range

        [Obsolete("Deprecated since Version 2.40")]
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_range_check")]
        public static extern bool RangeCheck(IntPtr settings, string key, object value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_get")]
        public static extern void Get(IntPtr settings, string key, string format, params object[] value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set")]
        public static extern void Set(IntPtr settings, string key, string format, params object[] value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_boolean")]
        public static extern bool SetBoolean(IntPtr settings, string key, bool value);

        public bool SetInt(string key, int newValue)
        {
            return PInvokes.GSettings.SetInt(Settings, key, newValue);
        }

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_int64")]
        public static extern bool SetInt64(IntPtr settings, string key, long value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_uint")]
        public static extern bool SetUInt(IntPtr settings, string key, uint value);

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
        public static extern bool SetEnum(IntPtr settings, string key, int value);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_set_flags")]
        public static extern bool SetFlags(IntPtr settings, string key, uint value);

        //[DllImport("libgio-2.0.so", EntryPoint = "GSettingsGetMapping")]
        //public static extern unsafe bool GetMapping(object value, void* result, void* userData);

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
