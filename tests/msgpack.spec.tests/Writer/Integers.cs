using System;
using System.Buffers;
using Shouldly;
using Xunit;

namespace ProGaudi.MsgPack.Tests.Writer
{
    public class Integers
    {
        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(-1, new byte[] { 0xff })]
        [InlineData(sbyte.MinValue, new byte[] { 208, 128 })]
        [InlineData(sbyte.MaxValue, new byte[] { 127 })]
        [InlineData(short.MinValue, new byte[] { 209, 128, 0 })]
        [InlineData(short.MaxValue, new byte[] { 205, 127, 0xff })]
        [InlineData(int.MinValue, new byte[] { 210, 128, 0, 0, 0 })]
        [InlineData(int.MaxValue, new byte[] { 206, 127, 0xff, 0xff, 0xff })]
        [InlineData(long.MaxValue, new byte[] { 207, 127, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(long.MinValue, new byte[] { 211, 128, 0, 0, 0, 0, 0, 0, 0 })]
        public void TestSignedLong(long number, byte[] data)
        {
            var buffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(10));
            var length = MsgPackSpec.WriteInt64(buffer, number);
            length.ShouldBe(data.Length);
            buffer.Slice(0, length).ToArray().ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(-1, new byte[] { 0xff })]
        [InlineData(sbyte.MinValue, new byte[] { 208, 128 })]
        [InlineData(sbyte.MaxValue, new byte[] { 127 })]
        [InlineData(short.MinValue, new byte[] { 209, 128, 0 })]
        [InlineData(short.MaxValue, new byte[] { 205, 127, 0xff })]
        [InlineData(int.MinValue, new byte[] { 210, 128, 0, 0, 0 })]
        [InlineData(int.MaxValue, new byte[] { 206, 127, 0xff, 0xff, 0xff })]
        [InlineData(50505, new byte[] { 205, 197, 73 })]
        public void TestSignedInt(int number, byte[] data)
        {
            var buffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(10));
            var length = MsgPackSpec.WriteInt32(buffer, number);
            length.ShouldBe(data.Length);
            buffer.Slice(0, length).ToArray().ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(-1, new byte[] { 0xff })]
        [InlineData(sbyte.MinValue, new byte[] { 208, 128 })]
        [InlineData(sbyte.MaxValue, new byte[] { 127 })]
        [InlineData(short.MinValue, new byte[] { 209, 128, 0 })]
        [InlineData(short.MaxValue, new byte[] { 205, 127, 0xff })]
        public void TestSignedShort(short number, byte[] data)
        {
            var buffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(10));
            var length = MsgPackSpec.WriteInt16(buffer, number);
            length.ShouldBe(data.Length);
            buffer.Slice(0, length).ToArray().ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(-1, new byte[] { 0xff })]
        [InlineData(sbyte.MinValue, new byte[] { 208, 128 })]
        [InlineData(sbyte.MaxValue, new byte[] { 127 })]
        public void TestSignedByte(sbyte number, byte[] data)
        {
            var buffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(10));
            var length = MsgPackSpec.WriteInt8(buffer, number);
            length.ShouldBe(data.Length);
            buffer.Slice(0, length).ToArray().ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(byte.MaxValue, new byte[] { 0xcc, 0xff })]
        [InlineData(ushort.MaxValue, new byte[] { 0xcd, 0xff, 0xff })]
        [InlineData(uint.MaxValue, new byte[] { 0xce, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(ulong.MaxValue, new byte[] { 0xcf, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff })]
        public void TetsUnsignedLong(ulong number, byte[] data)
        {
            var buffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(10));
            var length = MsgPackSpec.WriteUInt64(buffer, number);
            length.ShouldBe(data.Length);
            buffer.Slice(0, length).ToArray().ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(byte.MaxValue, new byte[] { 0xcc, 0xff })]
        [InlineData(ushort.MaxValue, new byte[] { 0xcd, 0xff, 0xff })]
        [InlineData(uint.MaxValue, new byte[] { 0xce, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(0x10000000, new byte[] { 0xce, 0x10, 0x00, 0x00, 0x00 })]
        public void TetsUnsignedInt(uint number, byte[] data)
        {
            var buffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(10));
            var length = MsgPackSpec.WriteUInt32(buffer, number);
            length.ShouldBe(data.Length);
            buffer.Slice(0, length).ToArray().ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(byte.MaxValue, new byte[] { 0xcc, 0xff })]
        [InlineData(ushort.MaxValue, new byte[] { 0xcd, 0xff, 0xff })]
        public void TetsUnsignedShort(ushort number, byte[] data)
        {
            var buffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(10));
            var length = MsgPackSpec.WriteUInt16(buffer, number);
            length.ShouldBe(data.Length);
            buffer.Slice(0, length).ToArray().ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] {0x00})]
        [InlineData(1, new byte[] {1})]
        [InlineData(byte.MaxValue, new byte[] {0xcc, 0xff})]
        public void TetsUnsignedByte(byte number, byte[] data)
        {
            var buffer = new Span<byte>(ArrayPool<byte>.Shared.Rent(10));
            var length = MsgPackSpec.WriteUInt8(buffer, number);
            length.ShouldBe(data.Length);
            buffer.Slice(0, length).ToArray().ShouldBe(data);
        }
    }
}
