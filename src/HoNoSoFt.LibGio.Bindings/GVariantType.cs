using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings
{
    // https://developer.gnome.org/glib/stable/glib-GVariantType.html#GVariantType
    public class GVariantType
    {
        private readonly IntPtr _gvariantType;

        public GVariantType(string typeString)
        {
            _gvariantType = PInvokes.GVariantType.New(typeString);
        }

        internal GVariantType(IntPtr gVariantType)
        {
            _gvariantType = gVariantType;
        }

        public string TypePeekString() => PInvokes.GVariantType.TypePeekString(_gvariantType);
        public int GetStringLength() => PInvokes.GVariantType.GetStringLength(_gvariantType);

        // Many, many, many methods missing here.
    }
}
