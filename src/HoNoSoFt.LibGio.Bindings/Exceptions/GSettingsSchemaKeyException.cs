using System;
using System.Runtime.Serialization;

namespace HoNoSoFt.LibGio.Bindings.Exceptions
{
    public class GSettingsSchemaKeyException : Exception
    {
        public GSettingsSchemaKeyException()
        {
        }

        public GSettingsSchemaKeyException(string message) : base(message)
        {
        }

        public GSettingsSchemaKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GSettingsSchemaKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
