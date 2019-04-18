using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings
{
    internal class GString : IDisposable
    {
        internal IntPtr GStringPtr { get; private set; } = IntPtr.Zero;

        internal GString(IntPtr gStringPtr) => GStringPtr = gStringPtr;
        public GString(string str) => GStringPtr = PInvokes.GString.New(str);

        public string Free(bool freeSegment)
        {
            var result = PInvokes.GString.Free(GStringPtr, freeSegment);

            return result;
        }

        public override string ToString()
        {
            var result = Marshal.PtrToStructure<GStringStruct>(GStringPtr);
            return result.str;
        }

        ~GString()
        {
            Dispose();
        }

        public void Dispose()
        {
            // Very hard to know if the pointer have been removed by the C library.
            //if (GStringPtr != IntPtr.Zero) { 
            //    Free(true);
            //}
        }

        internal struct GStringStruct
        {
            public string str;
            public ulong len;
            public ulong allocated_len;
        }
    }
}
