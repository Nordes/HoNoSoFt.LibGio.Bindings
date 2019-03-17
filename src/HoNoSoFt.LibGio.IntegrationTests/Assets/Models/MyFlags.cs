using System;
using System.Collections.Generic;
using System.Text;

namespace HoNoSoFt.LibGio.IntegrationTests.Assets.Models
{
    [Flags]
    internal enum MyFlags
    {
        Flag1 = 1 << 0,
        Flag2 = 1 << 1,
        Flag3 = 1 << 2
    }
}
