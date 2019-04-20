using System;
using System.Runtime.InteropServices;
using HoNoSoFt.LibGio.Bindings.Utilities;

namespace HoNoSoFt.LibGio.Bindings
{
    // https://developer.gnome.org/glib/stable/glib-GVariantType.html#GVariantType
    public class GVariantType
    {
        internal IntPtr GVariantTypePtr { get; }

        public GVariantType(string typeString)
        {
            GVariantTypePtr = PInvokes.GVariantType.New(typeString);
        }

        internal GVariantType(IntPtr gVariantType)
        {
            GVariantTypePtr = gVariantType;
        }

        public static bool StringIsValid(string typeString) => PInvokes.GVariantType.StringIsValid(typeString);
        public string TypePeekString() => Marshal.PtrToStringAnsi(PInvokes.GVariantType.TypePeekString(GVariantTypePtr));
        public int GetStringLength() => PInvokes.GVariantType.GetStringLength(GVariantTypePtr);

        /// <summary>
        /// Scan for the current type. E.g.: A String type is "s" and if you search "s" => true
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool StringScan(string search) => PInvokes.GVariantType.StringScan(search, IntPtr.Zero, out var endPtr);
        public string DupString() => Marshal.PtrToStringAnsi(PInvokes.GVariantType.DupString(GVariantTypePtr));
        public bool IsDefinite() => PInvokes.GVariantType.IsDefinite(GVariantTypePtr);
        public bool IsContainer() => PInvokes.GVariantType.IsContainer(GVariantTypePtr);
        public bool IsBasic() => PInvokes.GVariantType.IsBasic(GVariantTypePtr);
        public bool IsMaybe() => PInvokes.GVariantType.IsMaybe(GVariantTypePtr);
        public bool IsArray() => PInvokes.GVariantType.IsArray(GVariantTypePtr);
        public bool IsTuple() => PInvokes.GVariantType.IsTuple(GVariantTypePtr);
        public bool IsDictEntry() => PInvokes.GVariantType.IsDictEntry(GVariantTypePtr);
        public bool IsVariant() => PInvokes.GVariantType.IsVariant(GVariantTypePtr);
        public uint Hash() => PInvokes.GVariantType.Hash(GVariantTypePtr);
        public bool Equal(GVariantType equalTo) => PInvokes.GVariantType.Equal(GVariantTypePtr, equalTo.GVariantTypePtr);
        public bool IsSubTypeOf(GVariantType superType) => PInvokes.GVariantType.IsSubTypeOf(GVariantTypePtr, superType.GVariantTypePtr);
        public static GVariantType NewMaybe(GVariantType gVariantType) => new GVariantType(PInvokes.GVariantType.NewMaybe(gVariantType.GVariantTypePtr));
        public static GVariantType NewArray(GVariantType gVariantType) => new GVariantType(PInvokes.GVariantType.NewArray(gVariantType.GVariantTypePtr));
        public static GVariantType NewTuple(GVariantType gVariantType, int length) => new GVariantType(PInvokes.GVariantType.NewTuple(gVariantType.GVariantTypePtr, length));
        public static GVariantType NewDictEntry(GVariantType key, GVariantType value) => new GVariantType(PInvokes.GVariantType.NewDictEntry(key.GVariantTypePtr, value.GVariantTypePtr));
        public GVariantType Element() => new GVariantType(PInvokes.GVariantType.Element(GVariantTypePtr));
        public ulong NItems() => PInvokes.GVariantType.NItems(GVariantTypePtr);
        public GVariantType First() => new GVariantType(PInvokes.GVariantType.First(GVariantTypePtr));
        public GVariantType Next() => new GVariantType(PInvokes.GVariantType.Next(GVariantTypePtr));
        public GVariantType Key() => new GVariantType(PInvokes.GVariantType.Key(GVariantTypePtr));
        public GVariantType Value() => new GVariantType(PInvokes.GVariantType.Value(GVariantTypePtr));

        // Many, many, many methods missing here.
        public void Free() => PInvokes.GVariantType.Free(GVariantTypePtr);
        public GVariantType Copy() => new GVariantType(PInvokes.GVariantType.Copy(GVariantTypePtr));

    }
}
