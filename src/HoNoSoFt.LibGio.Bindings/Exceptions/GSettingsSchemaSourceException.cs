using HoNoSoFt.LibGio.Bindings.GStructs;
using System;
using System.Runtime.Serialization;

namespace HoNoSoFt.LibGio.Bindings.Exceptions
{
    public class GSettingsSchemaSourceException : Exception
    {
        public GError Details { get; private set; }

        public GSettingsSchemaSourceException()
        {
        }

        public GSettingsSchemaSourceException(string message) : base(message)
        {
        }

        public GSettingsSchemaSourceException(string message, GError details) : base(message)
        {
            Details = details;
        }

        public GSettingsSchemaSourceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public GSettingsSchemaSourceException(string message, GError details, Exception innerException) : base(message, innerException)
        {
            Details = details;
        }

        protected GSettingsSchemaSourceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
