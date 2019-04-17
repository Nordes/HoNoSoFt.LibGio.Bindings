namespace HoNoSoFt.LibGio.Bindings.GStructs
{
    /// <summary>
    /// Ref: https://developer.gnome.org/glib/stable/glib-Error-Reporting.html
    /// </summary>
    public struct GError
    {
        public uint domain;
        public int code;
        public string message;

        public GError(uint domain, int code, string message)
        {
            this.domain = domain;
            this.code = code;
            this.message = message;
        }
    }
}
