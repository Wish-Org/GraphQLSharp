using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphQLSharp.Tests;

[TestClass]
public class SerializationTests
{
    private class MyObject
    {
        public DateTime at { get; set; }
        public DateTime? atNullable { get; set; }
        public DateTime? atNullable2 { get; set; }
        public DateTimeOffset atOffset { get; set; }
        public DateTimeOffset? atOffsetNullable { get; set; }
        public DateTimeOffset? atOffsetNullable2 { get; set; }
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

        MyObject result = JsonSerializer.Deserialize<MyObject>(json, Serializer.Options);
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
        MyObject result = JsonSerializer.Deserialize<MyObject>(json, Serializer.Options);
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
                    "atNullable": "invalid-date", 
                }
                """;
        JsonSerializer.Deserialize<MyObject>(json, Serializer.Options);
    }
}