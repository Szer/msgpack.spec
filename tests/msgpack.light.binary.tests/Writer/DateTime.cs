using System;
using System.Collections.Generic;

using Shouldly;

using Xunit;

namespace ProGaudi.MsgPack.Light.Tests.Writer
{
    public class DateTimeTest
    {
        [Fact]
        public void TestDateTime()
        {
            var tests = new List<KeyValuePair<System.DateTime, byte[]>>()
            {
                new KeyValuePair<DateTime, byte[]>(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new byte[] {211, 247, 96, 128, 10, 8, 74, 128, 0,}),
                new KeyValuePair<DateTime, byte[]>(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Utc), new byte[] { 207, 35, 42, 168, 127, 252, 129, 152, 240,}),
                new KeyValuePair<DateTime, byte[]>(new DateTime(2015, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), new byte[] { 207, 0, 51, 110, 236, 17, 171, 0, 0,}),
                new KeyValuePair<DateTime, byte[]>(new DateTime(1, 2, 3, 4, 5, 6, DateTimeKind.Utc), new byte[] {211, 247, 96, 154, 26, 189, 97, 197, 0,}),
            };

            foreach (var test in tests)
            {
                MsgPackSerializer.Serialize(test.Key).ShouldBe(test.Value);
                ((MsgPackToken)test.Key).RawBytes.ShouldBe(test.Value);
            }
        }

        [Fact]
        public void TestDateTimeOffset()
        {
            var tests = new List<KeyValuePair<System.DateTimeOffset, byte[]>>()
            {
                new KeyValuePair<DateTimeOffset, byte[]>(DateTimeOffset.MinValue, new byte[] {211, 247, 96, 128, 10, 8, 74, 128, 0,}),
                new KeyValuePair<DateTimeOffset, byte[]>(DateTimeOffset.MaxValue, new byte[] {207, 35, 42, 168, 127, 252, 129, 191, 255,}),
                new KeyValuePair<DateTimeOffset, byte[]>(new DateTimeOffset(2015, 11, 17, 0, 0, 0, TimeSpan.Zero), new byte[] {207, 0, 51, 110, 236, 17, 171, 0, 0,}),
                new KeyValuePair<DateTimeOffset, byte[]>(new DateTimeOffset(1, 2, 3, 4, 5, 6, TimeSpan.Zero), new byte[] {211, 247, 96, 154, 26, 189, 97, 197, 0,}),
                new KeyValuePair<DateTimeOffset, byte[]>(new DateTimeOffset(1, 2, 3, 4, 5, 6, TimeSpan.FromHours(12)), new byte[] {211, 247, 96, 153, 182, 40, 44, 229, 0,}),
                new KeyValuePair<DateTimeOffset, byte[]>(new DateTimeOffset(1, 2, 3, 4, 5, 6, TimeSpan.FromMinutes(361)), new byte[] {211, 247, 96, 153, 232, 79, 4, 15, 0,}),
            };

            foreach (var test in tests)
            {
                MsgPackSerializer.Serialize(test.Key).ShouldBe(test.Value);
                ((MsgPackToken)test.Key).RawBytes.ShouldBe(test.Value);
            }
        }
    }
}
