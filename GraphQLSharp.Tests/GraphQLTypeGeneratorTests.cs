using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopify;
using System.Text.Json;

namespace GraphQLSharp.Tests;

[TestClass]
public class GraphQLSharp_Tests
{
    [TestMethod]
    public void GenerateShopifyTypes()
    {
        var options = new GraphQLSharpOptions
        {
            Namespace = "shopify",
            ScalarNameTypeToTypeName = new Dictionary<string, string>
                {
                    { "UnsignedInt64", "ulong" },
                    { "Money", "decimal" },
                    { "Float", "decimal" },
                    { "Decimal", "decimal" },
                    { "DateTime", "DateTime" },
                    { "Date", "DateOnly" },
                    { "UtcOffset", "TimeSpan" },
                    { "URL", "string" },
                    { "HTML", "string" },
                    { "JSON", "string" },
                    { "FormattedString", "string" },
                    { "ARN", "string" },
                    { "StorefrontID", "string" },
                    { "Color", "string" },
                    { "BigInt", "long" },
                },
            GraphQLTypeToTypeNameOverride = new Dictionary<(string, string), string>
                {
                    { ("ShopifyPaymentsDispute", "evidenceDueBy"), "DateTime" },
                    { ("ShopifyPaymentsDispute", "evidenceSentOn"), "DateTime" },
                    { ("ShopifyPaymentsDispute", "finalizedOn"), "DateTime" },
                },
            EnumMembersAsString = true
        };

        var generator = new GraphQLTypeGenerator();
        var shopifyDoc = JsonDocument.Parse(File.OpenRead(@"./shopify.json"));
        var code = generator.GenerateTypes(options, shopifyDoc);
        File.WriteAllText("../../../shopify.cs", code);
    }

    [TestMethod]
    public void GenerateSquareTypes()
    {
        var options = new GraphQLSharpOptions
        {
            Namespace = "square",
            ScalarNameTypeToTypeName = new Dictionary<string, string>
                {
                    { "Decimal", "decimal" },
                    { "DateTime", "DateTime" },
                    { "JsonSafeLong", "long" },
                    //there might be better types for these:
                    { "iCalendarEvent", "string" },
                    { "HexColor", "string" },
                    { "UID", "string" },
                    { "Url", "string" },
                    { "EmailAddress", "string" },
                    { "LanguageCode", "string" },
                    { "PhoneNumber", "string" },
                    { "TimeZone", "string" },
                    { "Duration", "string" },
                    { "Cursor", "string" },
                }
        };

        var generator = new GraphQLTypeGenerator();
        var shopifyDoc = JsonDocument.Parse(File.OpenRead(@"./square.json"));
        var code = generator.GenerateTypes(options, shopifyDoc);
        File.WriteAllText("../../../square.cs", code);
    }

    [TestMethod]
    public void SerializerMustRoundTrip()
    {
        var order1 = new Order
        {
            id = "123",
            customer = new Customer
            {
                id = "234"
            },
            purchasingEntity = new PurchasingCompany
            {
                contact = new CompanyContact
                {
                    id = "456"
                }
            }
        };
        string json1 = order1.ToJson();
        var order2 = Order.FromJson(json1);
        var json2 = order2.ToJson();
        Assert.AreEqual(json1, json2);
    }

    [TestMethod]
    public void SerializerMustRoundTripArray()
    {
        var orders1 = new[]
        {
                new Order
                {
                    id = "123",
                    customer = new Customer
                    {
                        id = "234"
                    },
                    purchasingEntity = new PurchasingCompany
                    {
                        contact = new CompanyContact
                        {
                            id = "456"
                        }
                    }
                },
                new Order
                {
                    id = "abc",
                    customer = new Customer
                    {
                        id = "def"
                    },
                    purchasingEntity = new PurchasingCompany
                    {
                        contact = new CompanyContact
                        {
                            id = "ghi"
                        }
                    }
                }
            };
        var json1 = Serializer.Serialize(orders1);
        var orders2 = Serializer.Deserialize<Order[]>(json1);
        var json2 = Serializer.Serialize(orders2);
        Assert.AreEqual(json1, json2);
    }
}