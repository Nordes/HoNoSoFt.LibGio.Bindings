using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.PInvokes
{
    internal static class GSettingsBackend
    {
        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_backend_get_default")]
        public static extern IntPtr GetDefault();

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_backend_changed")]
        internal static extern unsafe void Changed(IntPtr gSettingsBackend, string key, void* origin_tags);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_backend_path_changed")]
        public static extern unsafe void PathChanged(IntPtr gSettingsBackend, string path, void* originTag);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_backend_keys_changed")]
        public static extern unsafe void KeyChanged(IntPtr gSettingsBackend, string path, string[] items, void* originTag);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_backend_path_writable_changed")]
        public static extern void PathWritableChanged(IntPtr gSettingsBackend, string path);

        [DllImport("libgio-2.0.so", EntryPoint = "g_settings_backend_writable_changed")]
        public static extern void WritableChanged(IntPtr gSettingsBackend, string key);

        //[DllImport("libgio-2.0.so", EntryPoint = "g_settings_backend_changed_tree")]
        //public static extern unsafe void ChangedTree(IntPtr gSettingsBackend, GTree tree, void* originTag);

        // g_settings_backend_flatten_tree

        [DllImport("libgio-2.0.so", EntryPoint = "g_keyfile_settings_backend_new")]
        public static extern IntPtr NewKeyFile(string filename, string rootPath, string rootGroup);

        [DllImport("libgio-2.0.so", EntryPoint = "g_memory_settings_backend_new")]
        public static extern IntPtr NewMemory();

        /// <summary>
        /// Creates a readonly GSettingsBackend.
        /// 
        /// This backend does not allow changes to settings, so all settings will always have their
        /// default values.
        /// </summary>
        /// <returns>a newly created GSettingsBackend.</returns>
        /// <remarks>Since: 2.28</remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_null_settings_backend_new")]
        public static extern IntPtr NewNull();
    }
}
