namespace HoNoSoFt.LibGio.Bindings
{
    public enum GVariantClass
    {
        // Extra details in http://svn.netlabs.org/repos/ports/glib/trunk/glib/gvariant.h
        G_VARIANT_CLASS_BOOLEAN = 'b',
        G_VARIANT_CLASS_BYTE = 'y',
        G_VARIANT_CLASS_INT16 = 'n',
        G_VARIANT_CLASS_UINT16 = 'q',
        G_VARIANT_CLASS_INT32 = 'i',
        G_VARIANT_CLASS_UINT32 = 'u',
        G_VARIANT_CLASS_INT64 = 'x',
        G_VARIANT_CLASS_UINT64 = 't',
        G_VARIANT_CLASS_HANDLE = 'h',
        G_VARIANT_CLASS_DOUBLE = 'd',
        G_VARIANT_CLASS_STRING = 's',
        // The GVariant is a D-Bus object path string.
        G_VARIANT_CLASS_OBJECT_PATH = 'o',
        // The GVariant is a D-Bus signature string.
        G_VARIANT_CLASS_SIGNATURE = 'g',
        G_VARIANT_CLASS_VARIANT = 'v',
        G_VARIANT_CLASS_MAYBE = 'm',
        G_VARIANT_CLASS_ARRAY = 'a',
        G_VARIANT_CLASS_TUPLE = '(',
        G_VARIANT_CLASS_DICT_ENTRY = '{'
    }
}
