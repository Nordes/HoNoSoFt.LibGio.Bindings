using System;
using System.Collections.Generic;
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

        //public static IntPtr MarshalStringArrayToPtr(string[] arr)
        //{
        //    int size = arr.Length;
        //    //build array of pointers to string
        //    IntPtr[] InPointers = new IntPtr[size+1];
        //    int dim = IntPtr.Size * size;
        //    IntPtr rRoot = Marshal.AllocCoTaskMem(dim);
        //    for (int i = 0; i < size; i++)
        //    {
        //        InPointers[i] = Marshal.StringToCoTaskMemAnsi(arr[i]);
        //    }
        //    InPointers[InPointers.Length-1] = IntPtr.Zero;
        //    //copy the array of pointers
        //    Marshal.Copy(InPointers, 0, rRoot, size);
        //    return rRoot;

        //    //int size = arr.Length;
        //    //IntPtr[] InPointers = new IntPtr[size];
        //    //Marshal.StringToHGlobalAnsi()
        //    //var data = new List<string>();
        //    //if (arrayPtr != IntPtr.Zero)
        //    //{
        //    //    IntPtr ptr = Marshal.ReadIntPtr(arrayPtr);
        //    //    while (ptr != IntPtr.Zero)
        //    //    {
        //    //        string key = Marshal.PtrToStringAnsi(ptr);
        //    //        data.Add(key);
        //    //        arrayPtr = new IntPtr(arrayPtr.ToInt64() + IntPtr.Size);
        //    //        ptr = Marshal.ReadIntPtr(arrayPtr);
        //    //    }
        //    //}

        //    //return data;
        //}


        //public sealed class packLPArray
        //{
        //    private IntPtr taskAlloc;
        //    private readonly int _length;
        //    private IntPtr[] _strings;

        //    public packLPArray(string[] theArray)
        //    {
        //        int sizeIntPtr = IntPtr.Size;
        //        int neededSize = 0;
        //        if (theArray != null)

        //        {

        //            this._length = theArray.Length;

        //            this._strings = new IntPtr[this._length];

        //            // System.Diagnostics.Debugger.Break();

        //            neededSize = this._length * sizeIntPtr;

        //            this.taskAlloc = Marshal.AllocCoTaskMem(neededSize);

        //            for (int cx = this._length - 1; cx >= 0; cx--)
        //            {
        //                this._strings[cx] = Marshal.StringToCoTaskMemUni(theArray[cx]);
        //                Marshal.WriteIntPtr(this.taskAlloc, cx * sizeIntPtr, this._strings[cx]);
        //            }
        //        }
        //    }

        //    /// <summary>
        //    /// retrieves array length
        //    /// </summary>
        //    public int Length => _length;
        //    public IntPtr arrayPtr => this.taskAlloc;

        //    ~packLPArray() // clean up the rub
        //    {
        //        if (taskAlloc != IntPtr.Zero)
        //        {
        //            Marshal.FreeCoTaskMem(this.taskAlloc);
        //            int cx = this._length;
        //            while (cx-- != 0)
        //                Marshal.FreeCoTaskMem(this._strings[cx]);
        //        }
        //    }
        //}
    }
}
