using System;
using System.Runtime.Serialization;

namespace HoNoSoFt.LibGio.Bindings.Exceptions
{
    public class GSettingsSchemaException : Exception
    {
        public GSettingsSchemaException()
        {
        }

        public GSettingsSchemaException(string message) : base(message)
        {
        }

        public GSettingsSchemaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GSettingsSchemaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
