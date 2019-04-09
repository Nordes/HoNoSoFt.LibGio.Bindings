using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HoNoSoFt.LibGio.Bindings.Utilities;

namespace HoNoSoFt.LibGio.Bindings
{
    // Start DBus manually: exec dbus-run-session -- bash
    // Start the Tests: GSETTINGS_SCHEMA_DIR=~/schemas/ dbus-run-session dotnet test
    // ref: https://dbus.freedesktop.org/doc/dbus-run-session.1.html
    // Should be using some kind of pattern regarding the value.
    // All API's defined by using command: `nm -D libgio-2.0.so`
    // https://developer.gnome.org/gio/stable/GSettings.html#g-settings-set-int64
    // https://developer.gnome.org/glib/stable/glib-Basic-Types.html#gint
    // Some example: https://lzone.de/examples/Glib
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

        // Not implemented: g_settings_new_with_backend
        // Not implemented: g_settings_new_with_backend_and_path
        // Not implemented: g_settings_new_full 

        internal GSettings(IntPtr rawGSettings)
        {
            Settings = rawGSettings;
        }

        /// <summary>
        /// https://developer.gnome.org/gio/stable/GSettings.html#g-settings-sync
        /// </summary>
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
        public string GetValue(string key)
        {
            var gVariantValue = PInvokes.GSettings.GetValue(Settings, key);
            var variantTypeStr = GVariant.GetType(gVariantValue);
            var gvariantType = new GVariantType(variantTypeStr);
            var typeAsString = gvariantType.TypePeekString(); // useless.
            // TypePeekString : Should be used with g_variant_type_get_string_length

            // depending on the string, we should then try to return the value
            throw new NotImplementedException("Missing the value (Can be completed after GVariant full implementation.");
            return typeAsString;
        }

        public bool SetValue(string key, GVariant value)
        {
            throw new NotImplementedException("Not implemented, not tested");
            return PInvokes.GSettings.SetValue(Settings, key, value.ValuePtr);
        }

        public bool IsWritable(string key)
        {
            // TODO write TESTS
            return PInvokes.GSettings.IsWritable(Settings, key);
        }

        /// <summary>
        /// https://developer.gnome.org/gio/stable/GSettings.html#g-settings-delay
        /// Combination with Apply() to create "transactions" and Revert() to "rollback"
        /// </summary>
        public void Delay() => PInvokes.GSettings.Delay(Settings);
        public void Apply() => PInvokes.GSettings.Apply(Settings);
        public void Revert() => PInvokes.GSettings.Revert(Settings);
        public bool HasUnApplied() => PInvokes.GSettings.HasUnApplied(Settings);

        public GSettings GetChild(string childSchemaName)
        {
            var childSettings = PInvokes.GSettings.GetChild(Settings, childSchemaName);

            return new GSettings(childSettings);
        }

        public void Reset(string key) => PInvokes.GSettings.Reset(Settings, key);

        public object GetUserValue(string key)
        {
            throw new NotImplementedException("GVariant is not implemented fully and this can't work yet.");
            PInvokes.GSettings.GetUserValue(Settings, key);
        }

        public object GetDefaultValue(string key)
        {
            throw new NotImplementedException("GVariant is not implemented fully and this can't work yet.");
            PInvokes.GSettings.GetDefaultValue(Settings, key);
        }

        [Obsolete("Deprecated since Version 2.40, Use SchemaSourceListSchemas() or SchemaSourceLookup() instead")]
        public string[] ListSchemas()
        {
            return PInvokes.GSettings.ListSchemas();
        }
        
        [Obsolete("Deprecated since Version 2.40, Use SchemaSourceListSchemas() instead")]
        public string[] ListRelocatableSchemas()
        {
            return PInvokes.GSettings.ListRelocatableSchemas();
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
        /// <returns>Collection of children.</returns>
        public ICollection<string> ListChildren()
        {
            var originalPointer = PInvokes.GSettings.ListChildren(Settings);
            var copyOriginalPointer = originalPointer;
            var children = MarshalUtility.MarshalStringArray(originalPointer);

            // You should free the return value with g_strfreev() when you are done with it.
            StringUtilityFunction.GStrFreeV(copyOriginalPointer);

            return children;
        }

        [Obsolete("Deprecated since Version 2.40, Use SchemaKeyGetRange instead")]
        public object GetRange(string key)
        {
            throw new NotImplementedException("GVariant is not implemented fully and this can't work yet.");
            var gVariant = PInvokes.GSettings.GetRange(Settings, key);
        }

        [Obsolete("Deprecated since Version 2.40, Use SchemaKeyRangeCheck instead")]
        public bool RangeCheck(string key, object value)
        {
            // value is a GVariant
            throw new NotImplementedException("GVariant is not implemented fully and this can't work yet.");
            return PInvokes.GSettings.RangeCheck(Settings, key, value);
        }

        public void Get(string key, string format, params object[] formatArgs)
        {
            throw new NotImplementedException("Not implemented.");
            PInvokes.GSettings.Get(Settings, key, format, formatArgs);
        }

        public void Set(string key, string format, params object[] formatArgs)
        {
            throw new NotImplementedException("Not implemented.");
            PInvokes.GSettings.Get(Settings, key, format, formatArgs);
        }

        public bool GetBoolean(string key) => PInvokes.GSettings.GetBoolean(Settings, key);
        public bool SetBoolean(string key, bool value) => PInvokes.GSettings.SetBoolean(Settings, key, value);
        public int GetInt(string key) => PInvokes.GSettings.GetInt(Settings, key);
        public bool SetInt(string key, int newValue) => PInvokes.GSettings.SetInt(Settings, key, newValue);
        public long GetInt64(string key) => PInvokes.GSettings.GetInt64(Settings, key);
        public bool SetInt64(string key, long newValue) => PInvokes.GSettings.SetInt64(Settings, key, newValue);
        public uint GetUInt(string key) => PInvokes.GSettings.GetUInt(Settings, key);
        public bool SetUInt(string key, uint newValue) => PInvokes.GSettings.SetUInt(Settings, key, newValue);
        public ulong GetUInt64(string key) => PInvokes.GSettings.GetUInt64(Settings, key);
        public bool SetUInt64(string key, ulong newValue) => PInvokes.GSettings.SetUInt64(Settings, key, newValue);
        public double GetDouble(string key) => PInvokes.GSettings.GetDouble(Settings, key);
        public bool SetDouble(string key, double value) => PInvokes.GSettings.SetDouble(Settings, key, value);
        public string GetString(string key) => PInvokes.GSettings.GetString(Settings, key);
        public bool SetString(string key, string value) => PInvokes.GSettings.SetString(Settings, key, value);

        public ICollection<string> GetStringV(string key)
        {
            var originalPointer = PInvokes.GSettings.GetStrv(Settings, key);
            var children = MarshalUtility.MarshalStringArray(originalPointer);

            return children;
        }

        public bool SetStringV(string key, ICollection<string> value) => PInvokes.GSettings.SetStrv(Settings, key, value.ToArray());

        public int GetEnum(string key) => PInvokes.GSettings.GetEnum(Settings, key);
        public bool SetEnum(string key, int value) => PInvokes.GSettings.SetEnum(Settings, key, value);
        public uint GetFlags(string key) => PInvokes.GSettings.GetFlags(Settings, key);
        public bool SetFlags(string key, uint value) => PInvokes.GSettings.SetFlags(Settings, key, value);

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

        public GAction CreateAction(string key)
        {
            var gActionPtr = PInvokes.GSettings.CreateAction(Settings, key);

            return new GAction(gActionPtr);
        }
    }
}
