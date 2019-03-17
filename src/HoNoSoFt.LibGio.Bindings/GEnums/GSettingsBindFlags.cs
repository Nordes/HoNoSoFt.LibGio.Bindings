using System;

namespace HoNoSoFt.LibGio.Bindings
{
    [Flags]
    internal enum GSettingsBindFlags
    {
        G_SETTINGS_BIND_DEFAULT = 0,
        G_SETTINGS_BIND_GET = (1 << 0),
        G_SETTINGS_BIND_SET = (1 << 1),
        G_SETTINGS_BIND_NO_SENSITIVITY = (1 << 2),
        G_SETTINGS_BIND_GET_NO_CHANGES = (1 << 3),
        G_SETTINGS_BIND_INVERT_BOOLEAN = (1 << 4)
    }
}