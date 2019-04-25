using System;

namespace HoNoSoFt.LibGio.Bindings.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor)]
    public class SinceVersionAttribute : Attribute
    {
        public string Version { get; }

        public SinceVersionAttribute(string version)
        {
            Version = version;
        }
    }
}
