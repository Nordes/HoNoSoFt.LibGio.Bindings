using System;
using System.Collections.Generic;
using System.Linq;
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
        internal IntPtr GSettingsPtr { get; set; }

        internal GSettings(IntPtr rawGSettings) => GSettingsPtr = rawGSettings;
        public GSettings(string schema) => GSettingsPtr = PInvokes.GSettings.New(schema);
        public GSettings(string schema, string path) => GSettingsPtr = PInvokes.GSettings.New(schema, path);
        // Not implemented: g_settings_new_with_backend
        // Not implemented: g_settings_new_with_backend_and_path
        // Not implemented: g_settings_new_full 

        public static void Sync() => PInvokes.GSettings.Sync();

        public GVariant GetValue(string key) => new GVariant(PInvokes.GSettings.GetValue(GSettingsPtr, key));
        public bool SetValue(string key, GVariant value) => PInvokes.GSettings.SetValue(GSettingsPtr, key, value.GVariantPtr);
        public bool IsWritable(string key) => PInvokes.GSettings.IsWritable(GSettingsPtr, key);
        public void Delay() => PInvokes.GSettings.Delay(GSettingsPtr);
        public void Apply() => PInvokes.GSettings.Apply(GSettingsPtr);
        public void Revert() => PInvokes.GSettings.Revert(GSettingsPtr);
        public bool HasUnApplied() => PInvokes.GSettings.HasUnApplied(GSettingsPtr);
        public GSettings GetChild(string childSchemaName) => new GSettings(PInvokes.GSettings.GetChild(GSettingsPtr, childSchemaName));
        public void Reset(string key) => PInvokes.GSettings.Reset(GSettingsPtr, key);
        public GVariant GetUserValue(string key) => new GVariant(PInvokes.GSettings.GetUserValue(GSettingsPtr, key));
        public GVariant GetDefaultValue(string key) => new GVariant(PInvokes.GSettings.GetDefaultValue(GSettingsPtr, key));

        [Obsolete("Deprecated since Version 2.40, Use GSettingsSchemaSource.ListSchemas() or GSettingsSchemaSource.Lookup() instead")]
        public static ICollection<string> ListSchemas() => MarshalUtility.MarshalStringArray(PInvokes.GSettings.ListSchemas());

        [Obsolete("Deprecated since Version 2.40, Use GSettingsSchemaSource.ListSchemas() instead")]
        public ICollection<string> ListRelocatableSchemas() => MarshalUtility.MarshalStringArray(PInvokes.GSettings.ListRelocatableSchemas());

        [Obsolete("Deprecated, don't use except in real need. This function is intended for introspection reasons. Use GSettingsSchema.ListKeys instead")]
        public ICollection<string> ListKeys()
        {
            var originalPointer = PInvokes.GSettings.ListKeys(GSettingsPtr);
            var copyOriginalPointer = originalPointer;
            var keys = MarshalUtility.MarshalStringArray(originalPointer);

            // You should free the return value with g_strfreev() when you are done with it.
            StringUtilityFunction.GStrFreeV(copyOriginalPointer);

            return keys;
        }

        public ICollection<string> ListChildren()
        {
            var originalPointer = PInvokes.GSettings.ListChildren(GSettingsPtr);
            var copyOriginalPointer = originalPointer;
            var children = MarshalUtility.MarshalStringArray(originalPointer);

            // You should free the return value with g_strfreev() when you are done with it.
            StringUtilityFunction.GStrFreeV(copyOriginalPointer);

            return children;
        }

        [Obsolete("Deprecated since Version 2.40, Use GSettingsSchemaKey.GetRange instead")]
        public GVariant GetRange(string key) => new GVariant(PInvokes.GSettings.GetRange(GSettingsPtr, key));

        [Obsolete("Deprecated since Version 2.40, Use GSettingsSchemaKey.RangeCheck instead")]
        public bool RangeCheck(string key, GVariant value) => PInvokes.GSettings.RangeCheck(GSettingsPtr, key, value.GVariantPtr);

        internal void Get(string key, string format, params object[] formatArgs)
        {
            throw new NotImplementedException("Not implemented.");
            PInvokes.GSettings.Get(GSettingsPtr, key, format, formatArgs);
        }

        internal void Set(string key, string format, params object[] formatArgs)
        {
            throw new NotImplementedException("Not implemented.");
            PInvokes.GSettings.Get(GSettingsPtr, key, format, formatArgs);
        }

        public bool GetBoolean(string key) => PInvokes.GSettings.GetBoolean(GSettingsPtr, key);
        public bool SetBoolean(string key, bool value) => PInvokes.GSettings.SetBoolean(GSettingsPtr, key, value);
        public int GetInt(string key) => PInvokes.GSettings.GetInt(GSettingsPtr, key);
        public bool SetInt(string key, int newValue) => PInvokes.GSettings.SetInt(GSettingsPtr, key, newValue);
        public long GetInt64(string key) => PInvokes.GSettings.GetInt64(GSettingsPtr, key);
        public bool SetInt64(string key, long newValue) => PInvokes.GSettings.SetInt64(GSettingsPtr, key, newValue);
        public uint GetUInt(string key) => PInvokes.GSettings.GetUInt(GSettingsPtr, key);
        public bool SetUInt(string key, uint newValue) => PInvokes.GSettings.SetUInt(GSettingsPtr, key, newValue);
        public ulong GetUInt64(string key) => PInvokes.GSettings.GetUInt64(GSettingsPtr, key);
        public bool SetUInt64(string key, ulong newValue) => PInvokes.GSettings.SetUInt64(GSettingsPtr, key, newValue);
        public double GetDouble(string key) => PInvokes.GSettings.GetDouble(GSettingsPtr, key);
        public bool SetDouble(string key, double value) => PInvokes.GSettings.SetDouble(GSettingsPtr, key, value);
        public string GetString(string key) => PInvokes.GSettings.GetString(GSettingsPtr, key);
        public bool SetString(string key, string value) => PInvokes.GSettings.SetString(GSettingsPtr, key, value);

        public ICollection<string> GetStringV(string key)
        {
            var originalPointer = PInvokes.GSettings.GetStrv(GSettingsPtr, key);
            var children = MarshalUtility.MarshalStringArray(originalPointer);

            return children;
        }

        public bool SetStringV(string key, ICollection<string> value) => PInvokes.GSettings.SetStrv(GSettingsPtr, key, value.ToArray());
        public int GetEnum(string key) => PInvokes.GSettings.GetEnum(GSettingsPtr, key);
        public bool SetEnum(string key, int value) => PInvokes.GSettings.SetEnum(GSettingsPtr, key, value);
        public uint GetFlags(string key) => PInvokes.GSettings.GetFlags(GSettingsPtr, key);
        public bool SetFlags(string key, uint value) => PInvokes.GSettings.SetFlags(GSettingsPtr, key, value);

        /*
        (*GSettingsGetMapping) ()
        g_settings_get_mapped ()
        g_settings_bind ()
        g_settings_bind_with_mapping ()
        g_settings_bind_writable ()
        g_settings_unbind ()
        (*GSettingsBindSetMapping) ()
        (*GSettingsBindGetMapping) ()
        */
        public GAction CreateAction(string key) => new GAction(PInvokes.GSettings.CreateAction(GSettingsPtr, key));
    }
}
