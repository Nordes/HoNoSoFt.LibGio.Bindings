using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings
{
    public static class GSettings
    {
        // https://developer.gnome.org/gio/stable/GSettings.html#g-settings-set-int64
        // https://developer.gnome.org/glib/stable/glib-Basic-Types.html#gint

        /// <summary>
        /// Gets the GSettings pointer for the requested schema.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_new")]
        public static extern IntPtr New(string schema);

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
