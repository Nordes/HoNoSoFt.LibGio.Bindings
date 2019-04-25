using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HoNoSoFt.LibGio.Bindings.Attributes;
using HoNoSoFt.LibGio.Bindings.Exceptions;
using HoNoSoFt.LibGio.Bindings.Utilities;

namespace HoNoSoFt.LibGio.Bindings
{
    // Start DBus manually: exec dbus-run-session -- bash
    // Start the Tests: GSETTINGS_SCHEMA_DIR=~/schemas/ dbus-run-session dotnet test
    // ref: https://dbus.freedesktop.org/doc/dbus-run-session.1.html
    // Should be using some kind of pattern regarding the value.
    // All API's defined by using command: `nm -D libgio-2.0.so.0`
    // https://developer.gnome.org/gio/stable/GSettings.html#g-settings-set-int64
    // https://developer.gnome.org/glib/stable/glib-Basic-Types.html#gint
    // Some example: https://lzone.de/examples/Glib
    public class GSettings
    {
        private readonly GSettingsSchema _gSettingsSchema;

        //// https://developer.gnome.org/gio/stable/GSettings.html#g-settings-get-int64
        // This should be disposed at some point... otherwise I suspect a memory leak.
        internal IntPtr GSettingsPtr { get; set; }

        internal GSettings(IntPtr rawGSettings, string schema)
        {
            if (rawGSettings == IntPtr.Zero)
            {
                throw new GSettingsSchemaException($"Settings Schema not found or not installed: {schema}");
            }

            var gss = new GSettingsSchemaSource();
            _gSettingsSchema = gss.Lookup(schema, true);

            GSettingsPtr = rawGSettings;
        }

        [SinceVersion("2.26")]
        public GSettings(string schema)
        {
            var gss = new GSettingsSchemaSource();
            _gSettingsSchema = gss.Lookup(schema, true);
            if (_gSettingsSchema == null)
            {
                throw new GSettingsSchemaException($"Settings Schema not found or not installed: {schema}");
            }

            GSettingsPtr = PInvokes.GSettings.New(schema);
        }

        [SinceVersion("2.26")]
        public GSettings(string schema, string path)
        {
            var gss = new GSettingsSchemaSource(path, null, true);
            var found = gss.Lookup(schema, true);
            if (found == null)
            {
                throw new GSettingsSchemaException($"Settings Schema not found or not installed: {schema}");
            }

            GSettingsPtr = PInvokes.GSettings.New(schema, path);
        }

        // Not implemented: g_settings_new_with_backend
        // Not implemented: g_settings_new_with_backend_and_path
        // Not implemented: g_settings_new_full 

        [SinceVersion("Unknown")]
        public static void Sync() => PInvokes.GSettings.Sync();

        [SinceVersion("2.26")]
        public GVariant GetValue(string key)
        {
            CheckKey(key);
            return new GVariant(PInvokes.GSettings.GetValue(GSettingsPtr, key));
        }

        [SinceVersion("2.26")]
        public bool SetValue(string key, GVariant value)
        {
            CheckKey(key);
            return PInvokes.GSettings.SetValue(GSettingsPtr, key, value.GVariantPtr);
        }

        [SinceVersion("2.26")]
        public bool IsWritable(string key)
        {
            CheckKey(key);
            return PInvokes.GSettings.IsWritable(GSettingsPtr, key);
        }

        [SinceVersion("2.26")]
        public void Delay() => PInvokes.GSettings.Delay(GSettingsPtr);
        [SinceVersion("Unknown")]
        public void Apply() => PInvokes.GSettings.Apply(GSettingsPtr);
        [SinceVersion("Unknown")]
        public void Revert() => PInvokes.GSettings.Revert(GSettingsPtr);
        [SinceVersion("2.26")]
        public bool HasUnApplied() => PInvokes.GSettings.HasUnApplied(GSettingsPtr);
        [SinceVersion("2.26")]
        public GSettings GetChild(string childSchemaName) => new GSettings(PInvokes.GSettings.GetChild(GSettingsPtr, childSchemaName), childSchemaName);

        [SinceVersion("Unknown")]
        public void Reset(string key)
        {
            CheckKey(key);
            PInvokes.GSettings.Reset(GSettingsPtr, key);
        }

        [SinceVersion("2.40")]
        public GVariant GetUserValue(string key)
        {
            CheckKey(key);
            return new GVariant(PInvokes.GSettings.GetUserValue(GSettingsPtr, key));
        }

        [SinceVersion("2.40")]
        public GVariant GetDefaultValue(string key) => new GVariant(PInvokes.GSettings.GetDefaultValue(GSettingsPtr, key));

        [Obsolete("Deprecated since Version 2.40, Use GSettingsSchemaSource.ListSchemas() or GSettingsSchemaSource.Lookup() instead")]
        [SinceVersion("2.26")]
        public static ICollection<string> ListSchemas() => MarshalUtility.MarshalStringArray(PInvokes.GSettings.ListSchemas());

        [Obsolete("Deprecated since Version 2.40, Use GSettingsSchemaSource.ListSchemas() instead")]
        [SinceVersion("2.28")]
        public ICollection<string> ListRelocatableSchemas() => MarshalUtility.MarshalStringArray(PInvokes.GSettings.ListRelocatableSchemas());

        [Obsolete("Deprecated, don't use except in real need. This function is intended for introspection reasons. Use GSettingsSchema.ListKeys instead")]
        [SinceVersion("Unknown")]
        public ICollection<string> ListKeys()
        {
            var originalPointer = PInvokes.GSettings.ListKeys(GSettingsPtr);
            var copyOriginalPointer = originalPointer;
            var keys = MarshalUtility.MarshalStringArray(originalPointer);

            // You should free the return value with g_strfreev() when you are done with it.
            StringUtilityFunction.GStrFreeV(copyOriginalPointer);

            return keys;
        }

        [SinceVersion("Unknown")]
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
        [SinceVersion("2.28")]
        public GVariant GetRange(string key)
        {
            CheckKey(key);
            return new GVariant(PInvokes.GSettings.GetRange(GSettingsPtr, key));
        }

        [Obsolete("Deprecated since Version 2.40, Use GSettingsSchemaKey.RangeCheck instead")]
        [SinceVersion("2.28")]
        public bool RangeCheck(string key, GVariant value)
        {
            CheckKey(key);
            // Todo, check if the value is in range.
            return PInvokes.GSettings.RangeCheck(GSettingsPtr, key, value.GVariantPtr);
        }

        //internal void Get(string key, string format, params object[] formatArgs)
        //{
        //    PInvokes.GSettings.Get(GSettingsPtr, key, format, formatArgs);
        //}

        //internal void Set(string key, string format, params object[] formatArgs)
        //{
        //    PInvokes.GSettings.Get(GSettingsPtr, key, format, formatArgs);
        //}

        [SinceVersion("2.26")]
        public bool GetBoolean(string key)
        {
            CheckKey(key);
            return PInvokes.GSettings.GetBoolean(GSettingsPtr, key);
        }

        [SinceVersion("2.26")]
        public bool SetBoolean(string key, bool value)
        {
            CheckKey(key);
            return PInvokes.GSettings.SetBoolean(GSettingsPtr, key, value);
        }

        [SinceVersion("2.26")]
        public int GetInt(string key)
        {
            CheckKey(key);
            return PInvokes.GSettings.GetInt(GSettingsPtr, key);
        }

        [SinceVersion("2.26")]
        public bool SetInt(string key, int newValue)
        {
            CheckKey(key);
            // Todo, check if the value is in range.
            return PInvokes.GSettings.SetInt(GSettingsPtr, key, newValue);
        }

        [SinceVersion("2.50")]
        public long GetInt64(string key)
        {
            CheckKey(key);
            return PInvokes.GSettings.GetInt64(GSettingsPtr, key);
        }

        [SinceVersion("2.50")]
        public bool SetInt64(string key, long newValue)
        {
            CheckKey(key);
            // Todo, check if the value is in range.
            return PInvokes.GSettings.SetInt64(GSettingsPtr, key, newValue);
        }

        [SinceVersion("2.30")]
        public uint GetUInt(string key)
        {
            CheckKey(key);
            return PInvokes.GSettings.GetUInt(GSettingsPtr, key);
        }

        [SinceVersion("2.30")]
        public bool SetUInt(string key, uint newValue)
        {
            CheckKey(key);
            // Todo, check if the value is in range.
            return PInvokes.GSettings.SetUInt(GSettingsPtr, key, newValue);
        }

        [SinceVersion("2.50")]
        public ulong GetUInt64(string key)
        {
            CheckKey(key);
            return PInvokes.GSettings.GetUInt64(GSettingsPtr, key);
        }

        [SinceVersion("2.50")]
        public bool SetUInt64(string key, ulong newValue)
        {
            CheckKey(key);
            // Todo, check if the value is in range.
            return PInvokes.GSettings.SetUInt64(GSettingsPtr, key, newValue);
        }

        [SinceVersion("2.26")]
        public double GetDouble(string key)
        {
            CheckKey(key);
            return PInvokes.GSettings.GetDouble(GSettingsPtr, key);
        }

        [SinceVersion("2.26")]
        public bool SetDouble(string key, double value)
        {
            CheckKey(key);
            // Todo, check if the value is in range.
            return PInvokes.GSettings.SetDouble(GSettingsPtr, key, value);
        }

        [SinceVersion("2.26")]
        public string GetString(string key)
        {
            CheckKey(key);
            var result = Marshal.PtrToStringAnsi(PInvokes.GSettings.GetString(GSettingsPtr, key));
            return !string.IsNullOrEmpty(result) ? result : string.Empty;
        }

        [SinceVersion("2.26")]
        public bool SetString(string key, string value)
        {
            CheckKey(key);
            // Todo, check if the value is in range.
            return PInvokes.GSettings.SetString(GSettingsPtr, key, value);
        }

        [SinceVersion("2.26")]
        public ICollection<string> GetStringV(string key)
        {
            CheckKey(key);
            var originalPointer = PInvokes.GSettings.GetStrv(GSettingsPtr, key);
            var children = MarshalUtility.MarshalStringArray(originalPointer);

            return children;
        }

        [SinceVersion("2.26")]
        public bool SetStringV(string key, ICollection<string> value)
        {
            CheckKey(key);
            var stringVtoSet = new List<string>();

            // Todo, check if the value is in range. (should we?)
            if (value != null)
            {
                stringVtoSet.AddRange(value.ToList());
            }

            // Solution for array of "something" that you need to pass to c/c++
            // https://stackoverflow.com/questions/25137788/how-to-p-invoke-char-in-c-sharp
            // add the "zero"/null terminated array value.
            stringVtoSet.Add(null);

            return PInvokes.GSettings.SetStrV(GSettingsPtr, key, stringVtoSet.ToArray());
        }

        [SinceVersion("2.26")]
        public int GetEnum(string key)
        {
            CheckKey(key);
            return PInvokes.GSettings.GetEnum(GSettingsPtr, key);
        }

        [SinceVersion("Unknown")]
        public bool SetEnum(string key, int value)
        {
            CheckKey(key);
            // Todo, check if the value is in range.
            return PInvokes.GSettings.SetEnum(GSettingsPtr, key, value);
        }

        [SinceVersion("2.26")]
        public uint GetFlags(string key)
        {
            CheckKey(key);
            return PInvokes.GSettings.GetFlags(GSettingsPtr, key);
        }

        [SinceVersion("Unknown")]
        public bool SetFlags(string key, uint value)
        {
            CheckKey(key);
            // Todo, check if the value is in range.
            return PInvokes.GSettings.SetFlags(GSettingsPtr, key, value);
        }

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

        [SinceVersion("2.32")]
        public GAction CreateAction(string key)
        {
            // CheckKey?
            return new GAction(PInvokes.GSettings.CreateAction(GSettingsPtr, key));
        }

        private void CheckKey(string key)
        {
            if (!_gSettingsSchema.HasKey(key))
            {
                throw new GSettingsSchemaKeyException($"Key '{key}' not found.");
            }
        }
    }
}
