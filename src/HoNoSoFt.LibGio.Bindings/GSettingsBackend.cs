using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings
{
    /// <summary>
    /// https://developer.gnome.org/gio/stable/GSettingsBackend.html#g-memory-settings-backend-new
    /// </summary>
    /// <remarks>Not yet implemented</remarks>
    public class GSettingsBackend
    {
        internal IntPtr GSettingsBackendPtr { get;}

        public GSettingsBackend()
        {
            GSettingsBackendPtr = PInvokes.GSettingsBackend.GetDefault();
        }

        //public void Changed(string key, )
        // TODO
        /*
            g_settings_backend_changed ()
            g_settings_backend_path_changed ()
            g_settings_backend_keys_changed ()
            g_settings_backend_path_writable_changed ()
            g_settings_backend_writable_changed ()
            g_settings_backend_changed_tree ()
            g_settings_backend_flatten_tree ()
            g_keyfile_settings_backend_new ()
            g_memory_settings_backend_new ()
            g_null_settings_backend_new ()
         */
    }
}