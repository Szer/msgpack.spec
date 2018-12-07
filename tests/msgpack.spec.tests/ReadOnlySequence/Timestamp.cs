using Shouldly;
using Xunit;

namespace ProGaudi.MsgPack.Tests.ReadOnlySequence
{
    public sealed class Timestamp
    {
        [Theory]
        [InlineData(1514862245, 0, new byte[] { 0xd6, 0xff, 0x5a, 0x4a, 0xf6, 0xa5 })]
        [InlineData(1514862245, 678901234, new byte[] { 0xd7, 0xff, 0xa1, 0xdc, 0xd7, 0xc8, 0x5a, 0x4a, 0xf6, 0xa5 })]
        [InlineData(2147483647, 999999999, new byte[] { 0xd7, 0xff, 0xee, 0x6b, 0x27, 0xfc, 0x7f, 0xff, 0xff, 0xff })]
        [InlineData(2147483648, 0, new byte[] { 0xd6, 0xff, 0x80, 0x00, 0x00, 0x00 })]
        [InlineData(2147483648, 1, new byte[] { 0xd7, 0xff, 0x00, 0x00, 0x00, 0x04, 0x80, 0x00, 0x00, 0x00 })]
        [InlineData(4294967295, 0, new byte[] { 0xd6, 0xff, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(4294967295, 999999999, new byte[] { 0xd7, 0xff, 0xee, 0x6b, 0x27, 0xfc, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(4294967296, 0, new byte[] { 0xd7, 0xff, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 })]
        [InlineData(17179869183, 999999999, new byte[] { 0xd7, 0xff, 0xee, 0x6b, 0x27, 0xff, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(17179869184, 0, new byte[] { 0xc7, 0x0c, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00 })]
        [InlineData(-1, 0, new byte[] { 0xc7, 0x0c, 0xff, 0x00, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(-1, 999999999, new byte[] { 0xc7, 0x0c, 0xff, 0x3b, 0x9a, 0xc9, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(0, 0, new byte[] { 0xd6, 0xff, 0x00, 0x00, 0x00, 0x00 })]
        [InlineData(0, 1, new byte[] { 0xd7, 0xff, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00 })]
        [InlineData(1, 0, new byte[] { 0xd6, 0xff, 0x00, 0x00, 0x00, 0x01 })]
        [InlineData(-2208988801, 999999999, new byte[] { 0xc7, 0x0c, 0xff, 0x3b, 0x9a, 0xc9, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7c, 0x55, 0x81, 0x7f })]
        [InlineData(-2208988800, 0, new byte[] { 0xc7, 0x0c, 0xff, 0x00, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0x7c, 0x55, 0x81, 0x80 })]
        [InlineData(-62167219200, 0, new byte[] { 0xc7, 0x0c, 0xff, 0x00, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xf1, 0x86, 0x8b, 0x84, 0x00 })]
        [InlineData(253402300799, 999999999, new byte[] { 0xc7, 0x0c, 0xff, 0x3b, 0x9a, 0xc9, 0xff, 0x00, 0x00, 0x00, 0x3a, 0xff, 0xf4, 0x41, 0x7f })]
        public void Test(long seconds, uint nanoSeconds, byte[] data)
        {
            var x = MsgPackSpec.ReadTimestamp(data, out var readSize);
            readSize.ShouldBe(data.Length);
            x.Seconds.ShouldBe(seconds);
            x.NanoSeconds.ShouldBe(nanoSeconds);
        }
    }
}
