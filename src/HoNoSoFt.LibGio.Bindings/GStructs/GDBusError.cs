namespace HoNoSoFt.LibGio.Bindings.GStructs
{
    /// <summary>
    /// Ref.: https://developer.gnome.org/gio/stable/gio-GDBusError.html#g-dbus-error-new-for-dbus-error
    /// </summary>
    internal struct GDBusErrorEntry
    {
        /// <summary>
        /// An error code.
        /// </summary>
        public int error_code;

        /// <summary>
        /// The D-Bus error name to associate with error_code
        /// </summary>
        public string dbus_error_name;
    }
}
