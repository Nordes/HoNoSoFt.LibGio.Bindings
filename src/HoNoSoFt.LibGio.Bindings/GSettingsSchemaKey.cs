using HoNoSoFt.LibGio.Bindings.Exceptions;
using System;

namespace HoNoSoFt.LibGio.Bindings
{
    /// <summary>
    /// Created by GSettingsSchemaSource.Lookup(...)
    /// </summary>
    public class GSettingsSchemaKey
    {
        internal IntPtr GSettingsSchemaKeyPtr { get; private set; }
        private bool _isRef = false;

        internal GSettingsSchemaKey(IntPtr gSettingsSchemaKeyPtr) => GSettingsSchemaKeyPtr = gSettingsSchemaKeyPtr;

        public void Ref()
        {
            if (_isRef)
                throw new GSettingsSchemaKeyException("The GSettingsSchemaKey is already referenced");
            if (GSettingsSchemaKeyPtr == IntPtr.Zero)
                throw new GSettingsSchemaKeyException("Have been deferenced and we don't have access to it anymore");

            _isRef = true;
            GSettingsSchemaKeyPtr = PInvokes.GSettingsSchemaKey.Ref(GSettingsSchemaKeyPtr);
        }

        public void UnRef()
        {
            if (!_isRef || GSettingsSchemaKeyPtr == IntPtr.Zero)
                throw new GSettingsSchemaKeyException("The GSettingsSchemaKey is already un-referenced");

            _isRef = false;
         
            // Possibly unreference the pointer, so we'll get the default after unref.
            PInvokes.GSettingsSchemaKey.UnRef(GSettingsSchemaKeyPtr);
        }

        public GVariantType GetValueType() => new GVariantType(PInvokes.GSettingsSchemaKey.GetValueType(GSettingsSchemaKeyPtr));
        public GVariant GetDefaultValue() => new GVariant(PInvokes.GSettingsSchemaKey.GetDefaultValue(GSettingsSchemaKeyPtr));
        public GVariant GetRange() => new GVariant(PInvokes.GSettingsSchemaKey.GetRange(GSettingsSchemaKeyPtr));
        public bool RangeCheck(GVariant value) => PInvokes.GSettingsSchemaKey.RangeCheck(GSettingsSchemaKeyPtr, value.GVariantPtr);
        public string GetName() => PInvokes.GSettingsSchemaKey.GetName(GSettingsSchemaKeyPtr);
        public string GetSummary() => PInvokes.GSettingsSchemaKey.GetSummary(GSettingsSchemaKeyPtr);
        public string GetDescription() => PInvokes.GSettingsSchemaKey.GetDescription(GSettingsSchemaKeyPtr);

        ~GSettingsSchemaKey()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_isRef)
            {
                UnRef();
            }
        }
    }
}
