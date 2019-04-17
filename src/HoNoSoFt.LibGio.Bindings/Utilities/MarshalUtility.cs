using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings.Utilities
{
    internal static class MarshalUtility
    {
        // https://stackoverflow.com/a/22126873/80527 I changed the IEnumerable to ICollection to be able to release the memory later.
        public static ICollection<string> MarshalStringArray(IntPtr arrayPtr)
        {
            var data = new List<string>();
            if (arrayPtr != IntPtr.Zero)
            {
                IntPtr ptr = Marshal.ReadIntPtr(arrayPtr);
                while (ptr != IntPtr.Zero)
                {
                    string key = Marshal.PtrToStringAnsi(ptr);
                    data.Add(key);
                    arrayPtr = new IntPtr(arrayPtr.ToInt64() + IntPtr.Size);
                    ptr = Marshal.ReadIntPtr(arrayPtr);
                }
            }

            return data;
        }
    }
}
