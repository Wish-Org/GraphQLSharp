using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphQLSharp.Tests;

[TestClass]
public class SerializationTests
{
    private class MyDateTimeObject
    {
        public DateTime at { get; set; }
        public DateTime? atNullable { get; set; }
        public DateTime? atNullable2 { get; set; }
        public DateTimeOffset atOffset { get; set; }
        public DateTimeOffset? atOffsetNullable { get; set; }
        public DateTimeOffset? atOffsetNullable2 { get; set; }
    }

    private class MyBigIntObject
    {
        public long longValue { get; set; }
        public ulong ulongValue { get; set; }
        public int intValue { get; set; }
        public uint uintValue { get; set; }
    }

    [TestMethod]
    public void DeserializeDateTimePropertyValid()
    {
        var utcNow = DateTime.UtcNow;
        var now = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Kind);
        var nowOffset = new DateTimeOffset(now.Ticks, TimeSpan.FromHours(3));
        string json = $$"""
                {
                    "at": "{{now:O}}", 
                    "atNullable": "{{now:O}}", 
                    "atOffset": "{{nowOffset:O}}", 
                    "atOffsetNullable": "{{nowOffset:O}}"
                }
                """;

        MyDateTimeObject result = JsonSerializer.Deserialize<MyDateTimeObject>(json, Serializer.GetOptions());
        Assert.AreEqual(now, result.at);
        Assert.AreEqual(now, result.atNullable);
        Assert.AreEqual(nowOffset, result.atOffset);
        Assert.AreEqual(nowOffset, result.atOffsetNullable);
    }

    [TestMethod]
    public void DeserializeDateTimePropertyMinValue()
    {
        string json = """
                { 
                    "at": "0000-01-01T00:00:00Z", 
                    "atNullable": "0000-01-01T00:00:00Z", 
                    "atNullable2": null,
                    "atOffset": "0000-01-01T00:00:00Z", 
                    "atOffsetNullable": "0000-01-01T00:00:00Z",
                    "atOffsetNullable2": null
                }
                """;
        MyDateTimeObject result = JsonSerializer.Deserialize<MyDateTimeObject>(json, Serializer.GetOptions());
        Assert.AreEqual(DateTime.MinValue, result.at);
        Assert.AreEqual(DateTime.MinValue, result.atNullable);
        Assert.IsNull(result.atNullable2);
        Assert.AreEqual(DateTimeOffset.MinValue, result.atOffset);
        Assert.AreEqual(DateTimeOffset.MinValue, result.atOffsetNullable);
        Assert.IsNull(result.atOffsetNullable2);
    }

    [TestMethod]
    [ExpectedException(typeof(JsonException))]
    public void DeserializeDateTimePropertyInvalid()
    {
        string json = """
                { 
                    "at": "invalid-date", 
                    "atNullable": "invalid-date"
                }
                """;
        JsonSerializer.Deserialize<MyDateTimeObject>(json, Serializer.GetOptions());
    }

    [TestMethod]
    public void DeserializeBigInt()
    {
        string json = $$"""
                {
                    "longValue": "9223372036854775807", 
                    "ulongValue": "18446744073709551615",
                    "intValue": 2147483647,
                    "uintValue": 4294967295
                }
                """;

        MyBigIntObject result = JsonSerializer.Deserialize<MyBigIntObject>(json, Serializer.GetOptions());
        Assert.AreEqual(9223372036854775807, result.longValue);
        Assert.AreEqual(18446744073709551615, result.ulongValue);
        Assert.AreEqual(2147483647, result.intValue);
        Assert.AreEqual(4294967295, result.uintValue);
    }

    [TestMethod]
    public void SerializeBigInt()
    {
        var obj = new MyBigIntObject
        {
            longValue = 9223372036854775807,
            ulongValue = 18446744073709551615,
            intValue = 2147483647,
            uintValue = 4294967295
        };

        string json = JsonSerializer.Serialize(obj, Serializer.GetOptions());
        Assert.IsTrue(json.Contains(@"""longValue"":""9223372036854775807"""));
        Assert.IsTrue(json.Contains(@"""ulongValue"":""18446744073709551615"""));
        Assert.IsTrue(json.Contains(@"""intValue"":2147483647"));
        Assert.IsTrue(json.Contains(@"""uintValue"":4294967295"));
    }
}