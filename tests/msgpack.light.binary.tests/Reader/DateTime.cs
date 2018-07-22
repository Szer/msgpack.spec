using System;
using System.Collections.Generic;

using Shouldly;

using Xunit;

namespace ProGaudi.MsgPack.Light.Tests.Reader
{
    public class DateTimeTest
    {
        [Fact]
        public void TestDateTime()
        {
            var tests = new List<KeyValuePair<byte[], System.DateTime>>()
            {
                new KeyValuePair<byte[], DateTime>(new byte[] {211, 247, 96, 128, 10, 8, 74, 128, 0,}, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)),
                new KeyValuePair<byte[], DateTime>(new byte[] {211, 35, 42, 168, 127, 252, 129, 152, 240,}, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Utc)),
                new KeyValuePair<byte[], DateTime>(new byte[] {211, 0, 51, 110, 236, 17, 171, 0, 0,}, new DateTime(2015, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc)),
                new KeyValuePair<byte[], DateTime>(new byte[] {211, 247, 96, 154, 26, 189, 97, 197, 0,}, new DateTime(1, 2, 3, 4, 5, 6, DateTimeKind.Utc)),
                new KeyValuePair<byte[], DateTime>(new byte[] {207, 247, 96, 128, 10, 8, 74, 128, 0,}, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)),
                new KeyValuePair<byte[], DateTime>(new byte[] {207, 35, 42, 168, 127, 252, 129, 152, 240,}, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Utc)),
                new KeyValuePair<byte[], DateTime>(new byte[] {207, 0, 51, 110, 236, 17, 171, 0, 0,}, new DateTime(2015, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc)),
                new KeyValuePair<byte[], DateTime>(new byte[] {207, 247, 96, 154, 26, 189, 97, 197, 0,}, new DateTime(1, 2, 3, 4, 5, 6, DateTimeKind.Utc)),
            };

            foreach (var test in tests)
            {
                MsgPackSerializer.Deserialize<System.DateTime>(test.Key).ShouldBe(test.Value);

                var token = Helpers.CheckTokenDeserialization(test.Key);
                ((DateTime)token).ShouldBe(test.Value);
            }
        }

        [Fact]
        public void TestDateTimeOffset()
        {
            var tests = new List<KeyValuePair<byte[], System.DateTimeOffset>>()
            {
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {211, 247, 96, 128, 10, 8, 74, 128, 0,}, DateTimeOffset.MinValue),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {211, 35, 42, 168, 127, 252, 129, 191, 255,}, DateTimeOffset.MaxValue),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {211, 0, 51, 110, 236, 17, 171, 0, 0,}, new DateTimeOffset(2015, 11, 17, 0, 0, 0, TimeSpan.Zero)),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {211, 247, 96, 154, 26, 189, 97, 197, 0,}, new DateTimeOffset(1, 2, 3, 4, 5, 6, TimeSpan.Zero)),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {211, 247, 96, 153, 182, 40, 44, 229, 0,}, new DateTimeOffset(1, 2, 3, 4, 5, 6, TimeSpan.FromHours(12))),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {211, 247, 96, 153, 232, 79, 4, 15, 0,}, new DateTimeOffset(1, 2, 3, 4, 5, 6, TimeSpan.FromMinutes(361))),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {207, 247, 96, 128, 10, 8, 74, 128, 0,}, DateTimeOffset.MinValue),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {207, 35, 42, 168, 127, 252, 129, 191, 255,}, DateTimeOffset.MaxValue),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {207, 0, 51, 110, 236, 17, 171, 0, 0,}, new DateTimeOffset(2015, 11, 17, 0, 0, 0, TimeSpan.Zero)),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {207, 247, 96, 154, 26, 189, 97, 197, 0,}, new DateTimeOffset(1, 2, 3, 4, 5, 6, TimeSpan.Zero)),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {207, 247, 96, 153, 182, 40, 44, 229, 0,}, new DateTimeOffset(1, 2, 3, 4, 5, 6, TimeSpan.FromHours(12))),
                new KeyValuePair<byte[], DateTimeOffset>(new byte[] {207, 247, 96, 153, 232, 79, 4, 15, 0,}, new DateTimeOffset(1, 2, 3, 4, 5, 6, TimeSpan.FromMinutes(361))),
            };

            foreach (var test in tests)
            {
                MsgPackSerializer.Deserialize<System.DateTimeOffset>(test.Key).ShouldBe(test.Value);

                var token = Helpers.CheckTokenDeserialization(test.Key);
                ((DateTimeOffset)token).ShouldBe(test.Value);
            }
        }
    }
}
