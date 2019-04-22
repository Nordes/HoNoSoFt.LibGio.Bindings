using HoNoSoFt.LibGio.Bindings;
using System;
using System.Runtime.InteropServices;
using Xunit;

namespace HoNoSoFt.LibGio.IntegrationTests
{
    public class GStringTest : BaseTest
    {
        [Fact]
        public void Free_ShouldReturnStringWhenFreeSegmentIsFalse()
        {
            // prepare
            var str = "test 1 2 3";
            // execute
            var gs = new GString(str);
            var result = gs.Free(false);
            // assert
            Assert.Equal(str, result);
        }

        [Fact]
        public void Free_ShouldReturnNothingFreeSegmentIsTrue()
        {
            // prepare
            var str = "test 1 2 3";
            // execute
            using (var gs = new GString(str))
            {
                var result = gs.Free(true);
                // assert
                Assert.True(string.IsNullOrEmpty(result));
            }
        }

        [Fact]
        public void Ctr_Test()
        {
            // Prepare
            var expectedStr = "hello world";
            // Execute
            using (var gs = new GString(expectedStr))
            {
                // assert
                Assert.NotEqual(IntPtr.Zero, gs.GStringPtr);
            }
        }

        [Fact]
        public void ToString_ShouldReturnTheContent()
        {
            // Prepare
            var expectedStr = "hello world";
            using (var gs = new GString(expectedStr))
            {
                // Execute
                var result = gs.ToString();
                Assert.Equal(expectedStr, result);
            }
        }
    }
}
