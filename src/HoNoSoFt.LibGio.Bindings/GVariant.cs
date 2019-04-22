using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings
{
    /// <summary>
    /// https://developer.gnome.org/glib/stable/glib-GVariant.html
    /// </summary>
    public class GVariant : IDisposable
    {
        /// <summary>
        /// GVariant pointer. It's usage should be only within this project.
        /// </summary>
        internal IntPtr GVariantPtr { get; private set; }

        internal GVariant(IntPtr gVariant) => RefVariant(gVariant);
        public GVariant(bool value) => RefVariant(PInvokes.GVariant.NewBoolean(value));
        public GVariant(byte value) => RefVariant(PInvokes.GVariant.NewByte(value));
        public GVariant(short value) => RefVariant(PInvokes.GVariant.NewInt16(value));
        public GVariant(int value) => RefVariant(PInvokes.GVariant.NewInt(value));
        public GVariant(uint value) => RefVariant(PInvokes.GVariant.NewUInt(value));
        public GVariant(long value) => RefVariant(PInvokes.GVariant.NewInt64(value));
        public GVariant(ulong value) => RefVariant(PInvokes.GVariant.NewUInt64(value));
        public GVariant(double value) => RefVariant(PInvokes.GVariant.NewDouble(value));
        public GVariant(string value) => RefVariant(PInvokes.GVariant.NewString(value));
        public GVariant(GVariant gVariant) => RefVariant(PInvokes.GVariant.NewVariant(gVariant.GVariantPtr));

        private void RefVariant(IntPtr valuePtr)
        {
            GVariantPtr = valuePtr;
            // Released when object is destroyed.
            //PInvokes.GVariant.Ref(GVariantPtr);
        }

        public GVariant Ref() => new GVariant(PInvokes.GVariant.Ref(GVariantPtr));
        public void Unref() => PInvokes.GVariant.Unref(GVariantPtr);
        public bool IsFloating() => PInvokes.GVariant.IsFloating(GVariantPtr);
        public bool IsContainer() => PInvokes.GVariant.IsContainer(GVariantPtr);
        public GVariant RefSink() => new GVariant(PInvokes.GVariant.RefSink(GVariantPtr));
        public GVariant TakeRef() => new GVariant(PInvokes.GVariant.TakeRef(GVariantPtr));
        public GVariantType GetVariantType() => new GVariantType(PInvokes.GVariant.GetType(GVariantPtr));
        public string GetTypeString() => Marshal.PtrToStringAnsi(PInvokes.GVariant.GetTypeString(GVariantPtr));
        public static bool IsObjectPathValid(string objectPath) => PInvokes.GVariant.IsObjectPath(objectPath);
        public static bool IsSignatureValid(string objectPath) => PInvokes.GVariant.IsSignature(objectPath);
        public bool GetBool() => PInvokes.GVariant.GetBoolean(GVariantPtr);
        public byte GetByte() => PInvokes.GVariant.GetByte(GVariantPtr);
        public short GetInt16() => PInvokes.GVariant.GetInt16(GVariantPtr);
        public ushort GetUInt16() => PInvokes.GVariant.GetUInt16(GVariantPtr);
        public int GetInt() => PInvokes.GVariant.GetInt(GVariantPtr);
        public uint GetUInt() => PInvokes.GVariant.GetUInt(GVariantPtr);
        public long GetInt64() => PInvokes.GVariant.GetInt64(GVariantPtr);
        public ulong GetUInt64() => PInvokes.GVariant.GetUInt64(GVariantPtr);
        public double GetDouble() => PInvokes.GVariant.GetDouble(GVariantPtr);
        public GVariant GetVariant() => new GVariant(PInvokes.GVariant.GetVariant(GVariantPtr));
        public GVariantClass Classify() => PInvokes.GVariant.Classify(GVariantPtr);
        public bool CheckFormatString(string formatString, bool copyOnly) => PInvokes.GVariant.CheckFormatString(GVariantPtr, formatString, copyOnly);
        public bool IsOfType(GVariantType gVariantType) => PInvokes.GVariant.IsOfType(GVariantPtr, gVariantType.GVariantTypePtr);
        public int Compare(GVariant compareTo) => PInvokes.GVariant.Compare(GVariantPtr, compareTo.GVariantPtr);

        // Returned GVariant can be null... so, we should look at the IntPtr value
        public GVariant GetMaybe() => new GVariant(PInvokes.GVariant.GetMaybe(GVariantPtr));
        public ulong NChildren() => PInvokes.GVariant.NChildren(GVariantPtr);
        public GVariant GetChildValue(ulong index) => new GVariant(PInvokes.GVariant.GetChildValue(GVariantPtr, index));
        public GVariant LookupValue(string key, GVariantType expectedType) => new GVariant(PInvokes.GVariant.LookupValue(GVariantPtr, key, expectedType.GVariantTypePtr));
        public ulong GetSize() => PInvokes.GVariant.GetSize(GVariantPtr);
        public byte[] GetDataAsBytes() => PInvokes.GVariant.GetDataAsByte(GVariantPtr);
        public GVariant ByteSwap() => new GVariant(PInvokes.GVariant.ByteSwap(GVariantPtr));
        public GVariant GetNormalForm() => new GVariant(PInvokes.GVariant.GetNormalForm(GVariantPtr));
        public bool IsNormalForm() => PInvokes.GVariant.IsNormalForm(GVariantPtr);
        public uint Hash() => PInvokes.GVariant.Hash(GVariantPtr);
        public bool Equal(GVariant equalsTo) => PInvokes.GVariant.Equal(GVariantPtr, equalsTo.GVariantPtr);
        public int GetHandle() => PInvokes.GVariant.GetHandle(GVariantPtr);
        public string GetString() => Marshal.PtrToStringAuto(PInvokes.GVariant.GetString(GVariantPtr, IntPtr.Zero));
        public string DupString() => Marshal.PtrToStringAuto(PInvokes.GVariant.DupString(GVariantPtr, IntPtr.Zero));

        public string Print(bool typeAnnotate) => PInvokes.GVariant.Print(GVariantPtr, typeAnnotate);
        public string PrintString(string startText, bool typeAnnotate)
        {
            GString resultGString;
            if (string.IsNullOrEmpty(startText))
            {
                resultGString = new GString(PInvokes.GVariant.PrintString(GVariantPtr, IntPtr.Zero, typeAnnotate));
            }
            else
            {
                resultGString = new GString(startText); // Going to be freed by the next call.
                resultGString = new GString(PInvokes.GVariant.PrintString(GVariantPtr, resultGString.GStringPtr, typeAnnotate));
            }

            var resultStr = resultGString.ToString();
            resultGString.Free(true);
            return resultStr;
        }

        /// <summary>
        /// Use the existing hash from GVariant. However, here we return an INT and a gvariant is a UINT.
        /// 
        /// Simply be careful if you use this.
        /// </summary>
        /// <returns>The GVariant hash code</returns>
        public override int GetHashCode()
        {
            return (int)Hash();
        }

        public void Dispose()
        {
            // Should this be disposed like this, or the user should do it himself...
            //PInvokes.GVariant.Unref(GVariantPtr);
        }
    }
}
