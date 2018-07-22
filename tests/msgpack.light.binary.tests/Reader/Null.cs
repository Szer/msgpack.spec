using System.Collections.Generic;

using Shouldly;

using Xunit;

namespace ProGaudi.MsgPack.Light.Tests.Reader
{
    public class Null
    {
        [Fact]
        public void ReadNullArray()
        {
            MsgPackSerializer.Deserialize<int[]>(new[] { (byte)DataTypes.Null }).ShouldBe(null);
        }

        [Fact]
        public void ReadNullByteArray()
        {
            MsgPackSerializer.Deserialize<byte[]>(new[] { (byte)DataTypes.Null }).ShouldBe(null);
        }

        [Fact]
        public void ReadNullMap()
        {
            MsgPackSerializer.Deserialize<Dictionary<int, int>>(new[] { (byte)DataTypes.Null }).ShouldBe(null);
        }

        [Fact]
        public void ReadNullString()
        {
            MsgPackSerializer.Deserialize<string>(new[] { (byte)DataTypes.Null }).ShouldBe(null);
        }
    }
}
