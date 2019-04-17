using HoNoSoFt.LibGio.Bindings.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings
{
    /// <summary>
    /// Created by GSettingsSchemaSource.Lookup(...)
    /// </summary>
    public class GSettingsSchema
    {
        internal IntPtr GSettingsSchemaPtr { get; private set; }
        private bool _isRef = false;

        internal GSettingsSchema(IntPtr gSettingsSchemaPtr) => GSettingsSchemaPtr = gSettingsSchemaPtr;

        public void Ref()
        {
            if (_isRef)
                throw new GSettingsSchemaException("The GSettingsSchema is already referenced");
            if (GSettingsSchemaPtr == IntPtr.Zero)
                throw new GSettingsSchemaException("Have been deferenced and we don't have access to it anymore");

            _isRef = true;
            GSettingsSchemaPtr = PInvokes.GSettingsSchema.Ref(GSettingsSchemaPtr);
        }

        public void UnRef()
        {
            if (!_isRef || GSettingsSchemaPtr == IntPtr.Zero)
                throw new GSettingsSchemaException("The GSettingsSchema is already un-referenced");

            _isRef = false;
         
            // Possibly unreference the pointer, so we'll get the default after unref.
            PInvokes.GSettingsSchema.UnRef(GSettingsSchemaPtr);
        }

        public string GetId() => Marshal.PtrToStringAnsi(PInvokes.GSettingsSchema.GetId(GSettingsSchemaPtr));
        public string GetPath() => Marshal.PtrToStringAnsi(PInvokes.GSettingsSchema.GetPath(GSettingsSchemaPtr));
        public bool HasKey(string key) => PInvokes.GSettingsSchema.HasKey(GSettingsSchemaPtr, key);
        public GSettingsSchemaKey GetKey(string key) => new GSettingsSchemaKey(PInvokes.GSettingsSchema.GetKey(GSettingsSchemaPtr, key));
        public ICollection<string> Listchildren() => Utilities.MarshalUtility.MarshalStringArray(PInvokes.GSettingsSchema.ListChildren(GSettingsSchemaPtr));
        public ICollection<string> ListKeys() => Utilities.MarshalUtility.MarshalStringArray(PInvokes.GSettingsSchema.ListKeys(GSettingsSchemaPtr));

        ~GSettingsSchema()
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
