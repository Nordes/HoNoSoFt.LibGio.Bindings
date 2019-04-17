using HoNoSoFt.LibGio.Bindings.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HoNoSoFt.LibGio.Bindings
{
    /// <summary>
    /// CRef: https://developer.gnome.org/gio/stable/gio-GSettingsSchema-GSettingsSchemaSource.html
    /// </summary>
    public class GSettingsSchemaSource : IDisposable
    {
        internal IntPtr GSettingsSchemaSourcePtr { get; private set; }
        private bool _isRef = false;

        public GSettingsSchemaSource()
        {
            GSettingsSchemaSourcePtr = PInvokes.GSettingsSchemaSource.GetDefault();
        }

        public GSettingsSchemaSource(string directory, GSettingsSchemaSource parent, bool trusted)
        {
            IntPtr errorPtr;
            if (parent != null && parent.GSettingsSchemaSourcePtr != IntPtr.Zero)
            {
                GSettingsSchemaSourcePtr = PInvokes.GSettingsSchemaSource.NewFromDirectory(directory, parent.GSettingsSchemaSourcePtr, trusted, out errorPtr);
            }
            else
            {
                GSettingsSchemaSourcePtr = PInvokes.GSettingsSchemaSource.NewFromDirectory(directory, IntPtr.Zero, trusted, out errorPtr);
            }

            if (errorPtr != IntPtr.Zero)
            {
                var gerror = Marshal.PtrToStructure<GStructs.GError>(errorPtr);
                // There's an enum for the error id/message? (TBD by testing)
                throw new GSettingsSchemaSourceException($"Unable to create from directory: [Domain={gerror.domain}], [Code={gerror.code}], [Message={gerror.message}]", gerror);
            }
        }

        public void Ref()
        {
            if (_isRef)
                throw new GSettingsSchemaSourceException("The GSettingsSchemaSource is already referenced");

            _isRef = true;
            GSettingsSchemaSourcePtr = PInvokes.GSettingsSchemaSource.Ref(GSettingsSchemaSourcePtr);
        }

        public void UnRef()
        {
            if (!_isRef)
                throw new GSettingsSchemaSourceException("The GSettingsSchemaSource is already un-referenced");

            _isRef = false;

            // Possibly unreference the pointer, so we'll get the default after unref.
            PInvokes.GSettingsSchemaSource.UnRef(GSettingsSchemaSourcePtr);
            GSettingsSchemaSourcePtr = PInvokes.GSettingsSchemaSource.GetDefault();
        }

        public SchemasList ListSchemas(bool recursive)
        {
            PInvokes.GSettingsSchemaSource.ListSchemas(
                GSettingsSchemaSourcePtr,
                recursive,
                out IntPtr nonRelocatableSchemas,
                out IntPtr relocatableSchemas);

            var schemas = new SchemasList();
            if (nonRelocatableSchemas != IntPtr.Zero)
            {
                schemas.NonRelocatable.AddRange(Utilities.MarshalUtility.MarshalStringArray(nonRelocatableSchemas));
            }

            if (relocatableSchemas != IntPtr.Zero)
            {
                schemas.Relocatable.AddRange(Utilities.MarshalUtility.MarshalStringArray(relocatableSchemas));
            }

            return schemas;
        }

        public GSettingsSchema Lookup(string schemaId, bool recursive)
        {
            var gSettingsSchemaPtr = PInvokes.GSettingsSchemaSource.Lookup(GSettingsSchemaSourcePtr, schemaId, recursive);

            if (gSettingsSchemaPtr == IntPtr.Zero)
                return null;

            return new GSettingsSchema(gSettingsSchemaPtr);
        }

        ~GSettingsSchemaSource()
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

        public class SchemasList
        {
            public List<string> NonRelocatable { get; private set; } = new List<string>();
            public List<string> Relocatable { get; private set; } = new List<string>();
        }
    }
}
