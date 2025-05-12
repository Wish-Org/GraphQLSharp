#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace square
{
    public static class Serializer
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Converters =
            {
                new JsonStringEnumConverter()
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        public static string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj, obj.GetType(), Options);
        }

        public static object? Deserialize(string json, Type type)
        {
            return JsonSerializer.Deserialize(json, type, Options);
        }

        public static T? Deserialize<T>(string json)
            where T : class
        {
            return JsonSerializer.Deserialize<T>(json, Options);
        }
    }

    public interface IGraphQLObject
    {
    }

    public abstract class GraphQLObject<TSelf> : IGraphQLObject where TSelf : GraphQLObject<TSelf>
    {
        public static TSelf? FromJson(string json) => Serializer.Deserialize<TSelf>(json);
    }

    public static class GraphQLObjectExtensions
    {
        public static string ToJson(this IGraphQLObject o) => Serializer.Serialize(o);
    }

    public interface IEdge
    {
        string? cursor { get; set; }

        object? node { get; set; }
    }

    public interface IEdge<TNode> : IEdge
    {
        object? IEdge.node { get => this.node; set => this.node = (TNode? )value; }
        new TNode? node { get; set; }
    }

    public interface IConnection
    {
        PageInfo? pageInfo { get; set; }

        Type GetNodeType();
        IEnumerable? GetNodes();
    }

    public interface IConnectionWithNodes : IConnection
    {
        IEnumerable? nodes { get; set; }

        IEnumerable? IConnection.GetNodes() => this.nodes;
    }

    public interface IConnectionWithNodes<TNode> : IConnectionWithNodes
    {
        IEnumerable? IConnectionWithNodes.nodes { get => this.nodes; set => this.nodes = (IEnumerable<TNode>? )value; }
        new IEnumerable<TNode>? nodes { get; set; }

        Type IConnection.GetNodeType() => typeof(TNode);
    }

    public interface IConnectionWithEdges : IConnection
    {
        IEnumerable<IEdge>? edges { get; set; }

        Type GetEdgeType();
        IEnumerable? IConnection.GetNodes() => this.edges?.Select(e => e.node);
    }

    public interface IConnectionWithEdges<TNode> : IConnectionWithEdges
    {
        IEnumerable<IEdge>? IConnectionWithEdges.edges { get => this.edges; set => this.edges = (IEnumerable<IEdge<TNode>>? )value; }
        new IEnumerable<IEdge<TNode>>? edges { get; set; }

        Type IConnection.GetNodeType() => typeof(TNode);
    }

    public interface IConnectionWithEdges<TEdge, TNode> : IConnectionWithEdges<TNode> where TEdge : IEdge<TNode>
    {
        IEnumerable<IEdge<TNode>>? IConnectionWithEdges<TNode>.edges { get => this.edges?.Cast<IEdge<TNode>>(); set => this.edges = value?.Cast<TEdge>(); }
        new IEnumerable<TEdge>? edges { get; set; }

        Type IConnectionWithEdges.GetEdgeType() => typeof(TEdge);
    }

    public interface IConnectionWithNodesAndEdges<TEdge, TNode> : IConnectionWithEdges<TEdge, TNode>, IConnectionWithNodes<TNode> where TEdge : IEdge<TNode>
    {
        Type IConnection.GetNodeType() => typeof(TNode);
        IEnumerable? IConnection.GetNodes() => this.nodes ?? this.edges?.Select(e => e.node);
    }

    ///<summary>
    ///Represents a postal address in a country.
    ///For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
    ///</summary>
    public class Address : GraphQLObject<Address>
    {
        ///<summary>
        ///The first line of the address.
        ///Fields that start with `addressLine` provide the address's most specific
        ///details, like street number, street name, and building name. They do *not*
        ///provide less specific details like city, state/province, or country (these
        ///details are provided in other fields).
        ///</summary>
        public string? addressLine1 { get; set; }
        ///<summary>
        ///The second line of the address, if any.
        ///</summary>
        public string? addressLine2 { get; set; }
        ///<summary>
        ///The third line of the address, if any.
        ///</summary>
        public string? addressLine3 { get; set; }
        ///<summary>
        ///A civil entity within the address's country. In the US, this is the state.
        ///For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        ///</summary>
        public string? administrativeDistrictLevel1 { get; set; }
        ///<summary>
        ///The address's country, in the two-letter format of ISO 3166. For example, `US` or `FR`.
        ///</summary>
        public Country? country { get; set; }

        ///<summary>
        ///The address's country, in the two-letter format of ISO 3166. For example, `US` or `FR`.
        ///</summary>
        [Obsolete("Use `country` instead.")]
        public CountryCode? countryCode { get; set; }
        ///<summary>
        ///The city or town of the address. For a full list of field meanings by country,
        ///see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        ///</summary>
        public string? locality { get; set; }
        ///<summary>
        ///The address's postal code. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        ///</summary>
        public string? postalCode { get; set; }
        ///<summary>
        ///A civil region within the address's `locality`, if any.
        ///</summary>
        public string? sublocality { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about Afterpay payments.
    ///</summary>
    public class AfterpayPaymentDetails : GraphQLObject<AfterpayPaymentDetails>
    {
        ///<summary>
        ///Email address on the buyer's Afterpay account.
        ///</summary>
        public string? emailAddress { get; set; }
    }

    ///<summary>
    ///Defines the values for the `archived_state` query expression 
    ///used in [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems) 
    ///to return the archived, not archived or either type of catalog items.
    ///</summary>
    public enum ArchivedState
    {
        ///<summary>
        ///Requested items are not archived with the `is_archived` attribute set to `false`.
        ///</summary>
        ARCHIVED_STATE_NOT_ARCHIVED,
        ///<summary>
        ///Requested items are archived with the `is_archived` attribute set to `true`.
        ///</summary>
        ARCHIVED_STATE_ARCHIVED,
        ///<summary>
        ///Requested items can be archived or not archived.
        ///</summary>
        ARCHIVED_STATE_ALL,
    }

    public enum AUTH_TARGET_TYPE
    {
        ///<summary>
        ///The annotated element must be an ID corresponding to a Merchant.
        ///</summary>
        MERCHANT,
    }

    ///<summary>
    ///The annotated element must be an ID corresponding to a Merchant
    ///</summary>
    public enum AuthTarget
    {
        ///<summary>
        ///The annotated element must be an ID corresponding to a Merchant.
        ///</summary>
        MERCHANT,
    }

    ///<summary>
    ///The ownership type of the bank account performing the transfer.
    ///</summary>
    public enum BankAccountPaymentAccountOwnershipType
    {
        ACCOUNT_TYPE_UNKNOWN,
        COMPANY,
        INDIVIDUAL,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///ACH-specific details about `BANK_ACCOUNT` type payments with the `transferType` of `ACH`.
    ///</summary>
    public class BankAccountPaymentAchDetails : GraphQLObject<BankAccountPaymentAchDetails>
    {
        ///<summary>
        ///The last few digits of the bank account number.
        ///</summary>
        public string? accountNumberSuffix { get; set; }
        ///<summary>
        ///The type of the bank account performing the transfer. The account type can be `CHECKING`, `SAVINGS`, or `UNKNOWN`.
        ///</summary>
        public BankAccountType? accountType { get; set; }
        ///<summary>
        ///The routing number for the bank account.
        ///</summary>
        public string? routingNumber { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about BANK_ACCOUNT type payments.
    ///</summary>
    public class BankAccountPaymentDetails : GraphQLObject<BankAccountPaymentDetails>
    {
        ///<summary>
        ///The ownership type of the bank account performing the transfer.
        ///</summary>
        public BankAccountPaymentAccountOwnershipType? accountOwnershipType { get; set; }
        ///<summary>
        ///ACH-specific information about the transfer. The information is only populated if the `transferType` is `ACH`.
        ///</summary>
        public BankAccountPaymentAchDetails? achDetails { get; set; }
        ///<summary>
        ///The name of the bank associated with the bank account.
        ///</summary>
        public string? bankName { get; set; }
        ///<summary>
        ///The two-letter ISO code representing the country the bank account is located in.
        ///</summary>
        public Country? country { get; set; }
        ///<summary>
        ///Information about errors encountered during the request.
        ///</summary>
        public IEnumerable<Error>? errors { get; set; }
        ///<summary>
        ///Uniquely identifies the bank account for this seller and can be used to
        ///determine if payments are from the same bank account.
        ///</summary>
        public string? fingerprint { get; set; }
        ///<summary>
        ///The statement description as sent to the bank.
        ///</summary>
        public string? statementDescription { get; set; }
        ///<summary>
        ///The type of the bank transfer.
        ///</summary>
        public BankAccountPaymentTransferType? transferType { get; set; }
    }

    ///<summary>
    ///The type of the bank transfer.
    ///</summary>
    public enum BankAccountPaymentTransferType
    {
        ACH,
        OPEN_BANKING,
        UNKNOWN,
    }

    ///<summary>
    ///Indicates the financial purpose of the bank account.
    ///</summary>
    public enum BankAccountType
    {
        ///<summary>
        ///An account at a financial institution against which checks can be
        ///drawn specifically for business purposes (non-personal use).
        ///</summary>
        BUSINESS_CHECKING,
        ///<summary>
        ///An account at a financial institution against which checks can be
        ///drawn by the account depositor.
        ///</summary>
        CHECKING,
        ///<summary>
        ///An account at a financial institution that contains a deposit of funds
        ///and/or securities.
        ///</summary>
        INVESTMENT,
        ///<summary>
        ///An account at a financial institution which cannot be described by the
        ///other types.
        ///</summary>
        OTHER,
        ///<summary>
        ///An account at a financial institution that pays interest but cannot be
        ///used directly as money in the narrow sense of a medium of exchange.
        ///</summary>
        SAVINGS,
        ///<summary>
        ///Reserved value for unknown.
        ///</summary>
        UNKNOWN,
    }

    ///<summary>
    ///The hours of operation for a business location.
    ///</summary>
    public class BusinessHours : GraphQLObject<BusinessHours>
    {
        ///<summary>
        ///The list of time periods during which the business is open. There can be at most 10 periods per day.
        ///</summary>
        public IEnumerable<BusinessHoursPeriod>? periods { get; set; }
    }

    ///<summary>
    ///A period of time during which a business location is open.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    public class BusinessHoursPeriod : GraphQLObject<BusinessHoursPeriod>
    {
        ///<summary>
        ///The day of week for this time period.
        ///</summary>
        public DayOfWeek? dayOfWeek { get; set; }
        ///<summary>
        ///The end time of a business hours period, specified in local time using partial-time RFC 3339 format.
        ///</summary>
        public string? endLocalTime { get; set; }
        ///<summary>
        ///The start time of a business hours period, specified in local time using partial-time RFC 3339 format.
        ///</summary>
        public string? startLocalTime { get; set; }
    }

    ///<summary>
    ///The brand used for a Buy Now Pay Later payment.
    ///</summary>
    public enum BuyNowPayLaterPaymentBrand
    {
        AFTERPAY,
        CLEARPAY,
        UNKNOWN,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about a Buy Now Pay Later payment type.
    ///</summary>
    public class BuyNowPayLaterPaymentDetails : GraphQLObject<BuyNowPayLaterPaymentDetails>
    {
        ///<summary>
        ///Details about an Afterpay payment. These details are only populated if the `brand` is `AFTERPAY`.
        ///</summary>
        public AfterpayPaymentDetails? afterpayDetails { get; set; }
        ///<summary>
        ///The brand used for the Buy Now Pay Later payment.
        ///</summary>
        public BuyNowPayLaterPaymentBrand? brand { get; set; }
        ///<summary>
        ///Details about a Clearpay payment. These details are only populated if the `brand` is `CLEARPAY`.
        ///</summary>
        public ClearpayPaymentDetails? clearpayDetails { get; set; }
    }

    ///<summary>
    ///Represents the payment details of a card used for a payments.
    ///
    ///Permissions:PAYMENTS_READ
    ///</summary>
    public class Card : GraphQLObject<Card>
    {
        ///<summary>
        ///The billing address for this card.
        ///</summary>
        public Address? billingAddress { get; set; }
        ///<summary>
        ///The first six digits of the card number, known as the Bank Identification Number (BIN). Only the Payments API
        ///returns this field.
        ///</summary>
        public string? bin { get; set; }
        ///<summary>
        ///The card's brand.
        ///</summary>
        public CardBrand? cardBrand { get; set; }
        ///<summary>
        ///The type of the card.
        ///The Card object includes this field only in response to Payments API calls.
        ///</summary>
        public CardType? cardType { get; set; }
        ///<summary>
        ///The name of the cardholder.
        ///</summary>
        public string? cardholderName { get; set; }
        ///<summary>
        ///The expiration month of the associated card as an integer, generally between 1
        ///and 12. Can be outside that normally valid range on failed payments--we just
        ///record this value as we received it.
        ///</summary>
        public int? expMonth { get; set; }
        ///<summary>
        ///The four-digit year of the card's expiration date.
        ///</summary>
        public int? expYear { get; set; }
        ///<summary>
        ///__Not currently set.__ Intended as a Square-assigned identifier, based
        ///on the card number, to identify the card across multiple locations within a
        ///single application.
        ///</summary>
        public string? fingerprint { get; set; }
        ///<summary>
        ///Unique ID for this card. Generated by Square.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The last 4 digits of the card number; null if the card number was less than 4 characters.
        ///</summary>
        public string? last4 { get; set; }
        ///<summary>
        ///Indicates whether the Card is prepaid or not.
        ///The Card object includes this field only in response to Payments API calls.
        ///</summary>
        public CardPrepaidType? prepaidType { get; set; }
    }

    ///<summary>
    ///Indicates a card's brand, such as `VISA` or `MASTERCARD`.
    ///This enumeration is essentially the union of 3 separate protobuf enums:
    ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
    ///This enum is what we present to external clients in our `/v2/payments` API.
    ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
    ///This enum is what is used from a [`CardFilter`](https://prototype.sqprod.co/#/docs/squareup.payments.search.Filter.CardFilter#card_brand)
    ///that is accepted by Spot's Search API. It includes 3 extra enum values not present on the `Card.Brand` filter
    ///and also has an alternate name for 3 enum values.
    ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
    ///This enum is what is used within a [`CardTransaction`'s](https://prototype.sqprod.co/#/docs/squareup.esperanto.model.CardTransaction)
    ///[`Tender`](https://prototype.sqprod.co/#/docs/squareup.esperanto.model.Tender) on a
    ///[`PaymentRecord`](https://prototype.sqprod.co/#/docs/squareup.esperanto.model.PaymentRecord#card_transaction) within Spot.
    ///It is just like `CardTenderType` (including the 3 extra values, and 3 renamed
    ///values) but also includes 1 additional value.
    ///Ideally we would only have a single source enum here. However, to handle the full dataset and all use cases
    ///we need to cover, we have defined this as a union of these 3 enums. When an enum value exists on both the
    ///public `Card.Brand` enum and the internal enums, but with a different name, we have chosen the public name.
    ///</summary>
    public enum CardBrand
    {
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        AFTERPAY,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        ALIPAY,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        AMERICAN_EXPRESS,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        AU_PAY,
        ///<summary>
        ///Comes from the internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) or
        ///internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enums.
        ///</summary>
        BALANCE,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        CASH_APP,
        ///<summary>
        ///Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///
        ///Also known as `UNIONPAY` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///</summary>
        CHINA_UNIONPAY,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        DISCOVER,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        DISCOVER_DINERS,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        D_BARAI,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        EBT,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        EFTPOS,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        FELICA,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        INTERAC,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        JCB,
        ///<summary>
        ///Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///
        ///Also known as `MASTER_CARD` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///</summary>
        MASTERCARD,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        MERPAY,
        ///<summary>
        ///Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///
        ///Also known as `UNKNOWN` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///</summary>
        OTHER_BRAND,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        PAYPAY,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        RAKUTEN_PAY,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        SQUARE_ACCOUNT_BALANCE,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        SQUARE_CAPITAL_CARD,
        ///<summary>
        ///Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///
        ///Also known as `SQUARE_GIFT_CARD_V2` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///</summary>
        SQUARE_GIFT_CARD,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        VISA,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        WECHAT_PAY,
    }

    ///<summary>
    ///Indicates the brand for a co-branded card.
    ///</summary>
    public enum CardCoBrand
    {
        UNKNOWN,
        AFTERPAY,
        CLEARPAY,
    }

    ///<summary>
    ///Represents the payment details of a card to be used for payments.These
    ///details are determined by the payment token generated by Web Payments SDK.
    ///</summary>
    public class CardOnFile : GraphQLObject<CardOnFile>
    {
        ///<summary>
        ///Unique ID for this card. Generated by Square.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The ID of the merchant associated with the card.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The card's brand.
        ///</summary>
        public CardBrand? cardBrand { get; set; }
        ///<summary>
        ///The last 4 digits of the card number.
        ///</summary>
        public string? last4 { get; set; }
        ///<summary>
        ///The expiration month of the associated card as an integer between 1 and 12.
        ///</summary>
        public int? expMonth { get; set; }
        ///<summary>
        ///The four-digit year of the card's expiration date.
        ///</summary>
        public int? expYear { get; set; }
        ///<summary>
        ///The name of the cardholder.
        ///</summary>
        public string? cardholderName { get; set; }
        ///<summary>
        ///The billing address for this card.
        ///</summary>
        public Address? billingAddress { get; set; }
        ///<summary>
        ///Intended as a Square-assigned identifier, based
        ///on the card number, to identify the card across multiple locations within a
        ///single application.
        ///</summary>
        public string? fingerprint { get; set; }
        ///<summary>
        ///An optional user-defined reference ID that associates this card with
        ///another entity in an external system. For example, a customer ID from an
        ///external customer management system.
        ///</summary>
        public string? referenceId { get; set; }
        ///<summary>
        ///Indicates whether or not a card can be used for payments.
        ///</summary>
        public bool? enabled { get; set; }
        ///<summary>
        ///The type of the card.
        ///The Card object includes this field only in response to Payments API calls.
        ///</summary>
        public CardType? cardType { get; set; }
        ///<summary>
        ///Indicates whether the Card is prepaid or not.
        ///The Card object includes this field only in response to Payments API calls.
        ///</summary>
        public CardPrepaidType? prepaidType { get; set; }
        ///<summary>
        ///The first six digits of the card number, known as the Bank Identification Number (BIN). Only the Payments API
        ///returns this field.
        ///</summary>
        public string? bin { get; set; }
        ///<summary>
        ///Current version number of the card. Increments with each card update. Requests to update an
        ///existing Card object will be rejected unless the version in the request matches the current
        ///version for the Card.
        ///</summary>
        public int? version { get; set; }
        ///<summary>
        ///The card's co-brand if available. For example, an Afterpay virtual card would have a
        ///co-brand of AFTERPAY.
        ///</summary>
        public CardCoBrand? coBrand { get; set; }
        ///<summary>
        ///The merchant associated with the card.
        ///</summary>
        public Merchant? merchant { get; set; }
        ///<summary>
        ///The customer created using the Customers API to be associated with the card.
        ///</summary>
        public Customer? customer { get; set; }
    }

    ///<summary>
    ///Contains information of CardOnFile query result.
    ///
    ///Permissions:PAYMENTS_READ
    ///</summary>
    public class CardOnFileConnection : GraphQLObject<CardOnFileConnection>, IConnectionWithNodes<CardOnFile>
    {
        ///<summary>
        ///Provides information about the specific fetched page. This implements the PageInfo specification from the [Relay GraphQL Cursor Connections Specification](https://relay.dev/graphql/connections.htm#sec-undefined.PageInfo).
        ///</summary>
        public PageInfo? pageInfo { get; set; }
        ///<summary>
        ///CardOnFile query result.
        ///</summary>
        public IEnumerable<CardOnFile>? nodes { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Reflects the current status of a card payment. Contains only non-confidential information.
    ///</summary>
    public class CardPaymentDetails : GraphQLObject<CardPaymentDetails>
    {
        ///<summary>
        ///For EMV payments, the cryptogram generated for the payment.
        ///</summary>
        public string? applicationCryptogram { get; set; }
        ///<summary>
        ///For EMV payments, the application ID identifies the EMV application used for the payment.
        ///</summary>
        public string? applicationIdentifier { get; set; }
        ///<summary>
        ///For EMV payments, the human-readable name of the EMV application used for the payment.
        ///</summary>
        public string? applicationName { get; set; }
        ///<summary>
        ///The status code returned by the card issuer that describes the payment's authorization status.
        ///</summary>
        public string? authResultCode { get; set; }
        ///<summary>
        ///The status code returned from the Address Verification System (AVS) check.
        ///</summary>
        public CardPaymentDetailsAvsStatus? avsStatus { get; set; }
        ///<summary>
        ///The credit card's non-confidential details.
        ///</summary>
        public Card? card { get; set; }
        ///<summary>
        ///The timeline for card payments.
        ///</summary>
        public CardPaymentTimeline? cardPaymentTimeline { get; set; }
        ///<summary>
        ///The status code returned from the Card Verification Value (CVV) check.
        ///</summary>
        public CardPaymentDetailsCvvStatus? cvvStatus { get; set; }
        ///<summary>
        ///The method used to enter the card's details for the payment.
        ///</summary>
        public CardPaymentDetailsEntryMethod? entryMethod { get; set; }
        ///<summary>
        ///Information about errors encountered during the request.
        ///</summary>
        public IEnumerable<Error>? errors { get; set; }
        ///<summary>
        ///Whether the card must be physically present for the payment to be refunded.  If set to `true`, the card must be present.
        ///</summary>
        public bool? refundRequiresCardPresence { get; set; }
        ///<summary>
        ///The statement description sent to the card networks.
        ///Note: The actual statement description varies and is likely to be truncated and appended with
        ///additional information on a per issuer basis.
        ///</summary>
        public string? statementDescription { get; set; }
        ///<summary>
        ///The card payment's current state.
        ///</summary>
        public CardPaymentDetailsStatus? status { get; set; }
        ///<summary>
        ///For EMV payments, the method used to verify the cardholder's identity.
        ///</summary>
        public CardPaymentDetailsVerificationMethod? verificationMethod { get; set; }
        ///<summary>
        ///For EMV payments, the results of the cardholder verification.
        ///</summary>
        public CardPaymentDetailsVerificationResult? verificationResults { get; set; }
    }

    ///<summary>
    ///Enumeration of possible status codes returned from an Address Verification System (AVS) check.
    ///</summary>
    public enum CardPaymentDetailsAvsStatus
    {
        AVS_ACCEPTED,
        AVS_NOT_CHECKED,
        AVS_REJECTED,
    }

    ///<summary>
    ///Enumeration of possible status codes returned from a Card Verification Value (CVV) check.
    ///</summary>
    public enum CardPaymentDetailsCvvStatus
    {
        CVV_ACCEPTED,
        CVV_NOT_CHECKED,
        CVV_REJECTED,
    }

    ///<summary>
    ///The method used to enter a card's details for the payment.
    ///</summary>
    public enum CardPaymentDetailsEntryMethod
    {
        ///<summary>
        ///Card was tapped to a reader (eg NFC).
        ///</summary>
        CONTACTLESS,
        ///<summary>
        ///Card was dipped into an EMV reader, and went through the EMV payment flow.
        ///</summary>
        EMV,
        ///<summary>
        ///Card was keyed in. A CNP payment.
        ///</summary>
        KEYED,
        ///<summary>
        ///Card data was pulled from an instrument store.
        ///</summary>
        ON_FILE,
        ///<summary>
        ///Card was swiped through a reader or stand.
        ///</summary>
        SWIPED,
    }

    ///<summary>
    ///A card payment's current state.
    ///</summary>
    public enum CardPaymentDetailsStatus
    {
        AUTHORIZED,
        CAPTURED,
        FAILED,
        VOIDED,
    }

    ///<summary>
    ///Enumeration of possible methods used for EMV paymentsto verify the cardholder's identity.
    ///</summary>
    public enum CardPaymentDetailsVerificationMethod
    {
        NONE,
        ON_DEVICE,
        PIN,
        PIN_AND_SIGNATURE,
        SIGNATURE,
    }

    ///<summary>
    ///Enumeration of possible card verification results for EMV payments.
    ///</summary>
    public enum CardPaymentDetailsVerificationResult
    {
        FAILURE,
        SUCCESS,
        UNKNOWN,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///The timeline for card payments.
    ///</summary>
    public class CardPaymentTimeline : GraphQLObject<CardPaymentTimeline>
    {
        ///<summary>
        ///The timestamp when the payment was authorized, in RFC 3339 format.
        ///</summary>
        public DateTime? authorizedAt { get; set; }
        ///<summary>
        ///The timestamp when the payment was captured, in RFC 3339 format.
        ///</summary>
        public DateTime? capturedAt { get; set; }
        ///<summary>
        ///The timestamp when the payment was voided, in RFC 3339 format.
        ///</summary>
        public DateTime? voidedAt { get; set; }
    }

    ///<summary>
    ///Indicates a card's prepaid type, such as `NOT_PREPAID` or `PREPAID`.
    ///</summary>
    public enum CardPrepaidType
    {
        NOT_PREPAID,
        PREPAID,
        UNKNOWN_PREPAID_TYPE,
    }

    ///<summary>
    ///Indicates a card's type, such as `CREDIT` or `DEBIT`.
    ///</summary>
    public enum CardType
    {
        CREDIT,
        DEBIT,
        UNKNOWN_CARD_TYPE,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about `WALLET` type payments with the `brand` of `CASH_APP`.
    ///</summary>
    public class CashAppPaymentDetails : GraphQLObject<CashAppPaymentDetails>
    {
        ///<summary>
        ///$Cashtag of the Cash App account holder.
        ///</summary>
        public string? buyerCashtag { get; set; }
        ///<summary>
        ///The country of the Cash App account holder.
        ///</summary>
        public Country? buyerCountryCode { get; set; }
        ///<summary>
        ///The name of the Cash App account holder.
        ///</summary>
        public string? buyerFullName { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Stores details about a cash payment. Contains only non-confidential information. For more information, see
    ///[Take Cash Payments](https://developer.squareup.com/docs/payments-api/take-payments/cash-payments).
    ///</summary>
    public class CashPaymentDetails : GraphQLObject<CashPaymentDetails>
    {
        ///<summary>
        ///The amount and currency of the money supplied by the buyer.
        ///</summary>
        public Money? buyerSuppliedMoney { get; set; }
        ///<summary>
        ///The amount of change due back to the buyer.
        ///This read-only field is calculated from the `amountMoney` and `buyerSuppliedMoney` fields.
        ///</summary>
        public Money? changeBackMoney { get; set; }
    }

    ///<summary>
    ///A category to which a `CatalogItem` instance belongs.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogCategory : GraphQLObject<CatalogCategory>, ICatalogObject
    {
        ///<summary>
        ///The category name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The IDs of images associated with this `CatalogCategory` instance.
        ///Currently these images are not displayed by Square, but are free to be displayed in 3rd party applications.
        ///</summary>
        public IEnumerable<CatalogImage>? images { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Provides information when CatalogCustomAttributeValue.value is Boolean.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeBoolean : GraphQLObject<CatalogCustomAttributeBoolean>, ICatalogCustomAttributeValueUnion
    {
        ///<summary>
        ///A true or false value.
        ///</summary>
        public bool? value { get; set; }
    }

    ///<summary>
    ///Contains information defining a custom attribute.Custom attributes are
    ///intended to store additional information about a catalog object or to associate a
    ///catalog object with an entity in another system. Do not use custom attributes
    ///to store any sensitive information (personally identifiable information, card details, etc.).
    ///[Read more about custom attributes](https://developer.squareup.com/docs/catalog-api/add-custom-attributes)
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeDefinition : GraphQLObject<CatalogCustomAttributeDefinition>, ICatalogObject
    {
        ///<summary>
        ///The type of this custom attribute. Cannot be modified after creation.
        ///Required.
        ///</summary>
        public CatalogCustomAttributeType? type { get; set; }
        ///<summary>
        /// The name of this definition for API and seller-facing UI purposes.
        ///The name must be unique within the (merchant, application) pair. Required.
        ///May not be empty and may not exceed 255 characters. Can be modified after creation.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///Seller-oriented description of the meaning of this Custom Attribute,
        ///any constraints that the seller should observe, etc. May be displayed as a tooltip in Square UIs.
        ///</summary>
        public string? description { get; set; }
        ///<summary>
        ///__Read only.__ Contains information about the application that
        ///created this custom attribute definition.
        ///</summary>
        public SourceApplication? sourceApplication { get; set; }
        ///<summary>
        ///The set of `CatalogObject` types that this custom atttribute may be applied to.
        ///Currently, only `ITEM`, `ITEM_VARIATION`, and `MODIFIER` are allowed. At least one type must be included.
        ///</summary>
        public IEnumerable<CatalogObjectType>? allowedObjectTypes { get; set; }
        ///<summary>
        ///The visibility of a custom attribute in seller-facing UIs (including Square Point
        ///of Sale applications and Square Dashboard). May be modified.
        ///</summary>
        public CatalogCustomAttributeDefinitionSellerVisibility? sellerVisibility { get; set; }
        ///<summary>
        ///The visibility of a custom attribute to applications other than the application
        ///that created the attribute.
        ///</summary>
        public CatalogCustomAttributeDefinitionAppVisibility? appVisibility { get; set; }
        ///<summary>
        ///The name of the desired custom attribute key that can be used to access
        ///the custom attribute value on catalog objects. Cannot be modified after the
        ///custom attribute definition has been created.
        ///Must be between 1 and 60 characters, and may only contain the characters `[a-zA-Z0-9_-]`.
        ///</summary>
        public string? key { get; set; }
        ///<summary>
        ///The number of custom attributes that reference this
        ///custom attribute definition. Set by the server in response to a ListCatalog
        ///request with `include_counts` set to `true`.  If the actual count is greater
        ///than 100, `custom_attribute_usage_count` will be set to `100`.
        ///</summary>
        public int? usageCount { get; set; }
        ///<summary>
        ///Configuration for CatalogCustomAttributeDefinition
        ///</summary>
        public ICatalogCustomAttributeDefinitionConfig? config { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Defines the visibility of a custom attribute to applications other than their
    ///creating application.
    ///</summary>
    public enum CatalogCustomAttributeDefinitionAppVisibility
    {
        ///<summary>
        ///Other applications cannot read this custom attribute.
        ///</summary>
        APP_VISIBILITY_HIDDEN,
        ///<summary>
        ///Other applications can read this custom attribute definition and
        ///values.
        ///</summary>
        APP_VISIBILITY_READ_ONLY,
        ///<summary>
        ///Other applications can read and write custom attribute values on objects.
        ///They can read but cannot edit the custom attribute definition.
        ///</summary>
        APP_VISIBILITY_READ_WRITE_VALUES,
    }

    ///<summary>
    ///Defines the config for CatalogCustomAttributeDefinition.
    ///</summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "__typename")]
    [JsonDerivedType(typeof(CatalogCustomAttributeNumberConfig), typeDiscriminator: "CatalogCustomAttributeNumberConfig")]
    [JsonDerivedType(typeof(CatalogCustomAttributeSelectionConfig), typeDiscriminator: "CatalogCustomAttributeSelectionConfig")]
    [JsonDerivedType(typeof(CatalogCustomAttributeStringConfig), typeDiscriminator: "CatalogCustomAttributeStringConfig")]
    public interface ICatalogCustomAttributeDefinitionConfig : IGraphQLObject
    {
        public CatalogCustomAttributeNumberConfig? AsCatalogCustomAttributeNumberConfig() => this as CatalogCustomAttributeNumberConfig;
        public CatalogCustomAttributeSelectionConfig? AsCatalogCustomAttributeSelectionConfig() => this as CatalogCustomAttributeSelectionConfig;
        public CatalogCustomAttributeStringConfig? AsCatalogCustomAttributeStringConfig() => this as CatalogCustomAttributeStringConfig;
    }

    ///<summary>
    ///Defines the visibility of a custom attribute to sellers in Square
    ///client applications, Square APIs or in Square UIs (including Square Point
    ///of Sale applications and Square Dashboard).
    ///</summary>
    public enum CatalogCustomAttributeDefinitionSellerVisibility
    {
        ///<summary>
        ///Sellers cannot read this custom attribute in Square client
        ///applications or Square APIs.
        ///</summary>
        SELLER_VISIBILITY_HIDDEN,
        ///<summary>
        ///Sellers can read and write this custom attribute value in catalog objects,
        ///but cannot edit the custom attribute definition.
        ///</summary>
        SELLER_VISIBILITY_READ_WRITE_VALUES,
    }

    ///<summary>
    ///Provides information when CatalogCustomAttributeValue.value is Number.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeNumber : GraphQLObject<CatalogCustomAttributeNumber>, ICatalogCustomAttributeValueUnion
    {
        ///<summary>
        ///Contains a string representation of a decimal number, using a . as the decimal separator.
        ///</summary>
        public decimal? value { get; set; }
    }

    ///<summary>
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeNumberConfig : GraphQLObject<CatalogCustomAttributeNumberConfig>, ICatalogCustomAttributeDefinitionConfig
    {
        ///<summary>
        ///An integer between 0 and 5 that represents the maximum number of
        ///positions allowed after the decimal in number custom attribute values
        ///For example:
        ///
        ///- if the precision is 0, the quantity can be 1, 2, 3, etc.
        ///- if the precision is 1, the quantity can be 0.1, 0.2, etc.
        ///- if the precision is 2, the quantity can be 0.01, 0.12, etc.
        ///
        ///Default: 5
        ///</summary>
        public int? precision { get; set; }
    }

    ///<summary>
    ///Provides information when CatalogCustomAttributeValue.value is Selection.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeSelection : GraphQLObject<CatalogCustomAttributeSelection>, ICatalogCustomAttributeValueUnion
    {
        ///<summary>
        ///One or more choices from allowed_selections.
        ///</summary>
        public IEnumerable<string>? uids { get; set; }
    }

    ///<summary>
    ///Configuration associated with `SELECTION`-type custom attribute definitions.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeSelectionConfig : GraphQLObject<CatalogCustomAttributeSelectionConfig>, ICatalogCustomAttributeDefinitionConfig
    {
        ///<summary>
        ///The maximum number of selections that can be set. The maximum value for this
        ///attribute is 100. The default value is 1. The value can be modified, but changing the value will not
        ///affect existing custom attribute values on objects. Clients need to
        ///handle custom attributes with more selected values than allowed by this limit.
        ///</summary>
        public int? maxAllowedSelections { get; set; }
        ///<summary>
        ///The set of valid `CatalogCustomAttributeSelections`. Up to a maximum of 100
        ///selections can be defined. Can be modified.
        ///</summary>
        public IEnumerable<CatalogCustomAttributeSelectionDefinition>? allowedSelections { get; set; }
    }

    ///<summary>
    ///A named selection for this `SELECTION`-type custom attribute definition.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeSelectionDefinition : GraphQLObject<CatalogCustomAttributeSelectionDefinition>
    {
        ///<summary>
        ///Unique ID set by Square.
        ///</summary>
        public string? uid { get; set; }
        ///<summary>
        ///Selection name, unique within `allowed_selections`.
        ///</summary>
        public string? name { get; set; }
    }

    ///<summary>
    ///Provides information when CatalogCustomAttributeValue.value is String.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeString : GraphQLObject<CatalogCustomAttributeString>, ICatalogCustomAttributeValueUnion
    {
        ///<summary>
        ///The string value of the custom attribute.
        ///</summary>
        public string? value { get; set; }
    }

    ///<summary>
    ///Configuration associated with Custom Attribute Definitions of type `STRING`.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeStringConfig : GraphQLObject<CatalogCustomAttributeStringConfig>, ICatalogCustomAttributeDefinitionConfig
    {
        ///<summary>
        ///If true, each Custom Attribute instance associated with this Custom Attribute
        ///Definition must have a unique value within the seller's catalog. For
        ///example, this may be used for a value like a SKU that should not be
        ///duplicated within a seller's catalog. May not be modified after the
        ///definition has been created.
        ///</summary>
        public bool? enforceUniqueness { get; set; }
    }

    ///<summary>
    ///Defines the possible types for a custom attribute.
    ///</summary>
    public enum CatalogCustomAttributeType
    {
        ///<summary>
        ///A free-form string containing up to 255 characters.
        ///</summary>
        STRING,
        ///<summary>
        ///A `true` or `false` value.
        ///</summary>
        BOOLEAN,
        ///<summary>
        ///A decimal string representation of a number. Can support up to 5 digits after the decimal point.
        ///</summary>
        NUMBER,
        ///<summary>
        ///One or more choices from `allowed_selections`.
        ///</summary>
        SELECTION,
    }

    ///<summary>
    ///An instance of a custom attribute.
    ///Custom attributes can be defined and added to ITEM and ITEM_VARIATION type catalog objects.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class CatalogCustomAttributeValue : GraphQLObject<CatalogCustomAttributeValue>
    {
        ///<summary>
        ///Contains information defining a custom attribute.
        ///</summary>
        public CatalogCustomAttributeDefinition? definition { get; set; }
        ///<summary>
        ///Provides information for CatalogCustomAttributeValue.value
        ///</summary>
        public ICatalogCustomAttributeValueUnion? value { get; set; }
    }

    ///<summary>
    ///Provides information for CatalogCustomAttributeValue.value
    ///</summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "__typename")]
    [JsonDerivedType(typeof(CatalogCustomAttributeBoolean), typeDiscriminator: "CatalogCustomAttributeBoolean")]
    [JsonDerivedType(typeof(CatalogCustomAttributeString), typeDiscriminator: "CatalogCustomAttributeString")]
    [JsonDerivedType(typeof(CatalogCustomAttributeNumber), typeDiscriminator: "CatalogCustomAttributeNumber")]
    [JsonDerivedType(typeof(CatalogCustomAttributeSelection), typeDiscriminator: "CatalogCustomAttributeSelection")]
    public interface ICatalogCustomAttributeValueUnion : IGraphQLObject
    {
        public CatalogCustomAttributeBoolean? AsCatalogCustomAttributeBoolean() => this as CatalogCustomAttributeBoolean;
        public CatalogCustomAttributeString? AsCatalogCustomAttributeString() => this as CatalogCustomAttributeString;
        public CatalogCustomAttributeNumber? AsCatalogCustomAttributeNumber() => this as CatalogCustomAttributeNumber;
        public CatalogCustomAttributeSelection? AsCatalogCustomAttributeSelection() => this as CatalogCustomAttributeSelection;
    }

    ///<summary>
    ///A discount applicable to items.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogDiscount : GraphQLObject<CatalogDiscount>, ICatalogObject
    {
        ///<summary>
        ///The discount name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///Indicates whether the discount is a fixed amount or percentage, or entered at the time of sale.
        ///</summary>
        public CatalogDiscountType? discountType { get; set; }
        ///<summary>
        ///The amount of the discount. Specify an amount of `0` if `discount_type` is `VARIABLE_AMOUNT`.
        ///
        ///Do not use this field for percentage-based or variable discounts.
        ///</summary>
        public Money? amountMoney { get; set; }
        ///<summary>
        ///Indicates whether a mobile staff member needs to enter their PIN to apply the
        ///discount to a payment in the Square Point of Sale app.
        ///</summary>
        public bool? pinRequired { get; set; }
        ///<summary>
        ///Indicates whether this discount should reduce the price used to calculate tax.
        ///
        ///Most discounts should use `MODIFY_TAX_BASIS`. However, in some circumstances taxes must
        ///be calculated based on an item's price, ignoring a particular discount. For example,
        ///in many US jurisdictions, a manufacturer coupon or instant rebate reduces the price a
        ///customer pays but does not reduce the sale price used to calculate how much sales tax is
        ///due. In this case, the discount representing that manufacturer coupon should have
        ///`DO_NOT_MODIFY_TAX_BASIS` for this field.
        ///
        ///If you are unsure whether you need to use this field, consult your tax professional.
        ///</summary>
        public CatalogDiscountModifyTaxBasis? modifyTaxBasis { get; set; }
        ///<summary>
        ///For a percentage discount, the maximum absolute value of the discount. For example, if a
        ///50% discount has a `maximum_amount_money` of $20, a $100 purchase will yield a $20 discount,
        ///not a $50 discount.
        ///</summary>
        public Money? maximumAmountMoney { get; set; }
        ///<summary>
        ///The color of the discount display label in the Square Point of Sale app. This must be a valid hex color code.
        ///</summary>
        public string? labelColor { get; set; }
        ///<summary>
        ///The percentage of the discount as a string representation of a decimal number, using a `.` as the decimal
        ///separator and without a `%` sign. A value of `7.5` corresponds to `7.5%`. Specify a percentage of `0` if `discount_type`
        ///is `VARIABLE_PERCENTAGE`.
        ///
        ///Do not use this field for amount-based or variable discounts.
        ///</summary>
        public decimal? percentage { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    public enum CatalogDiscountModifyTaxBasis
    {
        ///<summary>
        ///Application of the discount will modify the tax basis.
        ///</summary>
        MODIFY_TAX_BASIS,
        ///<summary>
        ///Application of the discount will not modify the tax basis.
        ///</summary>
        DO_NOT_MODIFY_TAX_BASIS,
    }

    ///<summary>
    ///How to apply a CatalogDiscount to a CatalogItem.
    ///</summary>
    public enum CatalogDiscountType
    {
        ///<summary>
        ///Apply the discount as a fixed percentage (e.g., 5%) off the item price.
        ///</summary>
        FIXED_PERCENTAGE,
        ///<summary>
        ///Apply the discount as a fixed amount (e.g., $1.00) off the item price.
        ///</summary>
        FIXED_AMOUNT,
        ///<summary>
        ///Apply the discount as a variable percentage off the item price. The percentage will be specified at the time of sale.
        ///</summary>
        VARIABLE_PERCENTAGE,
        ///<summary>
        ///Apply the discount as a variable amount off the item price. The amount will be specified at the time of sale.
        ///</summary>
        VARIABLE_AMOUNT,
    }

    ///<summary>
    ///An image file to use in Square catalogs.It can be associated with
    ///`CatalogItem`, `CatalogItemVariation`, `CatalogCategory`, and `CatalogModifierList` objects.
    ///Only the images on items and item variations are exposed in Dashboard.
    ///Only the first image on an item is displayed in Square Point of Sale (SPOS).
    ///Images on items and variations are displayed through Square Online Store.
    ///Images on other object types are for use by 3rd party application developers.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogImage : GraphQLObject<CatalogImage>, ICatalogObject
    {
        ///<summary>
        ///The internal name to identify this image in calls to the Square API.
        ///This is a searchable attribute for use in applicable query filters
        ///using the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects).
        ///It is not unique and should not be shown in a buyer facing context.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///A caption that describes what is shown in the image. Displayed in the
        ///Square Online Store. This is a searchable attribute for use in applicable query filters
        ///using the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects).
        ///</summary>
        public string? caption { get; set; }
        ///<summary>
        ///The immutable order ID for this image object created by the Photo Studio service in Square Online Store.
        ///</summary>
        public string? photoStudioOrderId { get; set; }
        ///<summary>
        ///The URL of this image, generated by Square after an image is uploaded
        ///using the [CreateCatalogImage](api-endpoint:Catalog-CreateCatalogImage) endpoint.
        ///To modify the image, use the UpdateCatalogImage endpoint. Do not change the URL field.
        ///</summary>
        public string? url { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///An CatalogObject instance of the ITEM type, also referred to as an item, in the catalog.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class CatalogItem : GraphQLObject<CatalogItem>, ICatalogObject
    {
        ///<summary>
        ///The item's name. This is a searchable attribute for use in applicable query filters, its value must not be empty, and the length is of Unicode code points.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The item's description. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///
        ///Deprecated at 2022-07-20, this field is planned to retire in 6 months. You should migrate to use `description_html` to set the description
        ///of the CatalogItem instance.  The `description` and `description_html` field values are kept in sync. If you try to
        ///set the both fields, the `description_html` text value overwrites the `description` value. Updates in one field are also reflected in the other,
        ///except for when you use an early version before Square API 2022-07-20 and `description_html` is set to blank, setting the `description` value to null
        ///does not nullify `description_html`.
        ///</summary>
        public string? description { get; set; }
        ///<summary>
        ///The text of the item's display label in the Square Point of Sale app. Only up to the first five characters of the string are used.
        ///This attribute is searchable, and its value length is of Unicode code points.
        ///</summary>
        public string? abbreviation { get; set; }
        ///<summary>
        ///If `true`, the item can be added to shipping orders from the merchant's online store.
        ///</summary>
        public bool? availableOnline { get; set; }
        ///<summary>
        ///If `true`, the item can be added to pickup orders from the merchant's online store.
        ///</summary>
        public bool? availableForPickup { get; set; }
        ///<summary>
        ///If `true`, the item can be added to electronically fulfilled orders from the merchant's online store.
        ///</summary>
        public bool? availableElectronically { get; set; }
        ///<summary>
        ///The product type of the item. May not be changed once an item has been created.
        ///
        ///Only items of product type `REGULAR` or `APPOINTMENTS_SERVICE` may be created by this API; items with other product
        ///types are read-only.
        ///</summary>
        public CatalogItemProductType? productType { get; set; }
        ///<summary>
        ///If `false`, the Square Point of Sale app will present the `CatalogItem`'s
        ///details screen immediately, allowing the merchant to choose `CatalogModifier`s
        ///before adding the item to the cart.  This is the default behavior.
        ///
        ///If `true`, the Square Point of Sale app will immediately add the item to the cart with the pre-selected
        ///modifiers, and merchants can edit modifiers by drilling down onto the item's details.
        ///
        ///Third-party clients are encouraged to implement similar behaviors.
        ///</summary>
        public bool? skipModifierScreen { get; set; }
        ///<summary>
        ///A name to sort the item by. If this name is unspecified, namely, the `sort_name` field is absent, the regular `name` field is used for sorting.
        ///Its value must not be empty.
        ///
        ///It is currently supported for sellers of the Japanese locale only.
        ///</summary>
        public string? sortName { get; set; }
        ///<summary>
        ///The item's description as expressed in valid HTML elements. The length of this field value, including those of HTML tags,
        ///is of Unicode points. With application query filters, the text values of the HTML elements and attributes are searchable. Invalid or
        ///unsupported HTML elements or attributes are ignored.
        ///
        ///Supported HTML elements include:
        ///- `a`: Link. Supports linking to website URLs, email address, and telephone numbers.
        ///- `b`, `strong`:  Bold text
        ///- `br`: Line break
        ///- `code`: Computer code
        ///- `div`: Section
        ///- `h1-h6`: Headings
        ///- `i`, `em`: Italics
        ///- `li`: List element
        ///- `ol`: Numbered list
        ///- `p`: Paragraph
        ///- `ul`: Bullet list
        ///- `u`: Underline
        ///
        ///
        ///Supported HTML attributes include:
        ///- `align`: Alignment of the text content
        ///- `href`: Link destination
        ///- `rel`: Relationship between link's target and source
        ///- `target`: Place to open the linked document
        ///</summary>
        public string? descriptionHtml { get; set; }
        ///<summary>
        ///A server-generated plaintext version of the `description_html` field, without formatting tags.
        ///</summary>
        public string? descriptionPlaintext { get; set; }
        ///<summary>
        ///Indicates whether this item is archived (`true`) or not (`false`).
        ///</summary>
        public bool? isArchived { get; set; }
        ///<summary>
        ///The color of the item's display label in the Square Point of Sale app. This must be a valid hex color code.
        ///</summary>
        public string? labelColor { get; set; }
        ///<summary>
        ///The ID of the item's category, if any.
        ///</summary>
        public CatalogCategory? category { get; set; }
        ///<summary>
        ///List of item options IDs for this item. Used to manage and group item
        ///variations in a specified order.
        ///
        ///Maximum: 6 item options.
        ///</summary>
        public IEnumerable<CatalogItemOption>? options { get; set; }
        ///<summary>
        ///A set of IDs indicating the taxes enabled for
        ///this item. When updating an item, any taxes listed here will be added to the item.
        ///Taxes may also be added to or deleted from an item using `UpdateItemTaxes`.
        ///</summary>
        public IEnumerable<CatalogTax>? taxes { get; set; }
        ///<summary>
        ///A list of CatalogItemVariation objects for this item. An item must have
        ///at least one variation.
        ///</summary>
        public IEnumerable<CatalogItemVariation>? variations { get; set; }
        ///<summary>
        ///The IDs of images associated with this `CatalogItem` instance.
        ///These images will be shown to customers in Square Online Store.
        ///The first image will show up as the icon for this item in POS.
        ///</summary>
        public IEnumerable<CatalogImage>? images { get; set; }
        ///<summary>
        ///A set of `CatalogItemModifierListInfo` objects
        ///representing the modifier lists that apply to this item, along with the overrides and min
        ///and max limits that are specific to this item. Modifier lists
        ///may also be added to or deleted from an item using `UpdateItemModifierLists`.
        ///</summary>
        public IEnumerable<CatalogItemModifierListInfo>? modifierListInfos { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a "#" character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///When the server receives the new object, it will supply a unique identifier that replaces the temporary identifier for all future references.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Contains information of items query result.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class CatalogItemConnection : GraphQLObject<CatalogItemConnection>, IConnectionWithNodes<CatalogItem>
    {
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
        ///<summary>
        ///List of CatalogItems
        ///</summary>
        public IEnumerable<CatalogItem>? nodes { get; set; }
    }

    ///<summary>
    ///Options to control the properties of a `CatalogModifierList` applied to a `CatalogItem` instance.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogItemModifierListInfo : GraphQLObject<CatalogItemModifierListInfo>
    {
        ///<summary>
        ///A set of `CatalogModifierOverride` objects that override whether a given `CatalogModifier` is enabled by default.
        ///</summary>
        public IEnumerable<CatalogModifierOverride>? modifierOverrides { get; set; }
        ///<summary>
        ///If `true`, enable this `CatalogModifierList`. The default value is `true`.
        ///</summary>
        public bool? enabled { get; set; }
        ///<summary>
        ///The ID of the `CatalogModifierList` controlled by this `CatalogModifierListInfo`.
        ///</summary>
        public CatalogModifierList? modifierList { get; set; }
        ///<summary>
        ///If 0 or larger, the smallest number of `CatalogModifier`s that must be selected from this `CatalogModifierList`.
        ///</summary>
        public long? minSelectedModifiers { get; set; }
        ///<summary>
        ///If 0 or larger, the largest number of `CatalogModifier`s that can be selected from this `CatalogModifierList`.
        ///</summary>
        public long? maxSelectedModifiers { get; set; }
    }

    ///<summary>
    ///A group of variations for a `CatalogItem`.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogItemOption : GraphQLObject<CatalogItemOption>, ICatalogObject
    {
        ///<summary>
        ///The item option's display name for the seller. Must be unique across
        ///all item options. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The item option's display name for the customer. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        public string? displayName { get; set; }
        ///<summary>
        ///The item option's human-readable description. Displayed in the Square
        ///Point of Sale app for the seller and in the Online Store or on receipts for
        ///the buyer. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        public string? description { get; set; }
        ///<summary>
        ///If true, display colors for entries in `values` when present.
        ///</summary>
        public bool? showColors { get; set; }
        ///<summary>
        ///A list of CatalogObjects containing the
        ///`CatalogItemOptionValue`s for this item.
        ///</summary>
        public IEnumerable<CatalogItemOptionValue>? values { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///An enumerated value that can link a
    ///`CatalogItemVariation` to an item option as one of
    ///its item option values.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogItemOptionValue : GraphQLObject<CatalogItemOptionValue>, ICatalogObject
    {
        ///<summary>
        ///Name of this item option value. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///A human-readable description for the option value. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        public string? description { get; set; }
        ///<summary>
        ///The HTML-supported hex color for the item option (e.g., "#ff8d4e85").
        ///Only displayed if `show_colors` is enabled on the parent `ItemOption`. When
        ///left unset, `color` defaults to white ("#ffffff") when `show_colors` is
        ///enabled on the parent `ItemOption`.
        ///</summary>
        public string? color { get; set; }
        ///<summary>
        ///Determines where this option value appears in a list of option values.
        ///</summary>
        public long? ordinal { get; set; }
        ///<summary>
        ///Unique ID of the associated item option.
        ///</summary>
        public CatalogItemOption? option { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///The type of a CatalogItem.Connect V2 only allows the creation of `REGULAR` or `APPOINTMENTS_SERVICE` items.
    ///</summary>
    public enum CatalogItemProductType
    {
        ///<summary>
        ///An ordinary item.
        ///</summary>
        REGULAR,
        ///<summary>
        ///A Square gift card.
        ///</summary>
        GIFT_CARD,
        ///<summary>
        ///A service that can be booked using the Square Appointments app.
        ///</summary>
        APPOINTMENTS_SERVICE,
    }

    ///<summary>
    ///An item variation, representing a product for sale, in the Catalog object model.Each item must have at least one
    ///item variation and can have at most 250 item variations.
    ///
    ///An item variation can be sellable, stockable, or both if it has a unit of measure for its count for the sold number of the variation, the stocked
    ///number of the variation, or both. For example, when a variation representing wine is stocked and sold by the bottle, the variation is both
    ///stockable and sellable. But when a variation of the wine is sold by the glass, the sold units cannot be used as a measure of the stocked units. This by-the-glass
    ///variation is sellable, but not stockable. To accurately keep track of the wine's inventory count at any time, the sellable count must be
    ///converted to stockable count. Typically, the seller defines this unit conversion. For example, 1 bottle equals 5 glasses. The Square API exposes
    ///the `stockable_conversion` property on the variation to specify the conversion. Thus, when two glasses of the wine are sold, the sellable count
    ///decreases by 2, and the stockable count automatically decreases by 0.4 bottle according to the conversion.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogItemVariation : GraphQLObject<CatalogItemVariation>, ICatalogObject
    {
        ///<summary>
        ///The item variation's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The item variation's SKU, if any. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        public string? sku { get; set; }
        ///<summary>
        ///The universal product code (UPC) of the item variation, if any. This is a searchable attribute for use in applicable query filters.
        ///
        ///The value of this attribute should be a number of 12-14 digits long.  This restriction is enforced on the Square Seller Dashboard,
        ///Square Point of Sale or Retail Point of Sale apps, where this attribute shows in the GTIN field. If a non-compliant UPC value is assigned
        ///to this attribute using the API, the value is not editable on the Seller Dashboard, Square Point of Sale or Retail Point of Sale apps
        ///unless it is updated to fit the expected format.
        ///</summary>
        public string? upc { get; set; }
        ///<summary>
        ///Indicates whether the item variation's price is fixed or determined at the time
        ///of sale.
        ///</summary>
        public CatalogPricingType? pricingType { get; set; }
        ///<summary>
        ///The item variation's price, if fixed pricing is used.
        ///</summary>
        public Money? priceMoney { get; set; }
        ///<summary>
        ///Per-location price and inventory overrides.
        ///</summary>
        public IEnumerable<CatalogItemVariationLocationOverride>? locationOverrides { get; set; }
        ///<summary>
        ///If `true`, inventory tracking is active for the variation.
        ///</summary>
        public bool? trackInventory { get; set; }
        ///<summary>
        ///Arbitrary user metadata to associate with the item variation. This attribute value length is of Unicode code points.
        ///</summary>
        public string? userData { get; set; }
        ///<summary>
        ///If the `CatalogItem` that owns this item variation is of type
        ///`APPOINTMENTS_SERVICE`, then this is the duration of the service in milliseconds. For
        ///example, a 30 minute appointment would have the value `1800000`, which is equal to
        ///30 (minutes) * 60 (seconds per minute) * 1000 (milliseconds per second).
        ///</summary>
        public int? serviceDuration { get; set; }
        ///<summary>
        ///If the `CatalogItem` that owns this item variation is of type
        ///`APPOINTMENTS_SERVICE`, a bool representing whether this service is available for booking.
        ///</summary>
        public bool? availableForBooking { get; set; }
        ///<summary>
        ///Whether this variation can be sold. The inventory count of a sellable variation indicates
        ///the number of units available for sale. When a variation is both stockable and sellable,
        ///its sellable inventory count can be smaller than or equal to its stockable count.
        ///</summary>
        public bool? sellable { get; set; }
        ///<summary>
        ///Whether stock is counted directly on this variation (TRUE) or only on its components (FALSE).
        ///When a variation is both stockable and sellable, the inventory count of a stockable variation keeps track of the number of units of this variation in stock
        ///and is not an indicator of the number of units of the variation that can be sold.
        ///</summary>
        public bool? stockable { get; set; }
        ///<summary>
        ///Tokens of employees that can perform the service represented by this variation. Only valid for
        ///variations of type `APPOINTMENTS_SERVICE`.
        ///</summary>
        public IEnumerable<string>? teamMemberIds { get; set; }
        ///<summary>
        ///The unit conversion rule, as prescribed by the CatalogStockConversion type,
        ///that describes how this non-stockable (i.e., sellable/receivable) item variation is converted
        ///to/from the stockable item variation sharing the same parent item. With the stock conversion,
        ///you can accurately track inventory when an item variation is sold in one unit, but stocked in
        ///another unit.
        ///</summary>
        public CatalogStockConversion? stockableConversion { get; set; }
        ///<summary>
        ///The order in which this item variation should be displayed. This value is read-only. On writes, the ordinal
        ///for each item variation within a parent `CatalogItem` is set according to the item variations's
        ///position. On reads, the value is not guaranteed to be sequential or unique.
        ///</summary>
        public long? ordinal { get; set; }
        ///<summary>
        ///The ID of the `CatalogItem` associated with this item variation.
        ///</summary>
        public CatalogItem? item { get; set; }
        ///<summary>
        ///ID of the ‘CatalogMeasurementUnit’ that is used to measure the quantity
        ///sold of this item variation. If left unset, the item will be sold in
        ///whole quantities.
        ///</summary>
        public CatalogMeasurementUnit? unit { get; set; }
        ///<summary>
        ///The IDs of images associated with this `CatalogItemVariation` instance.
        ///These images will be shown to customers in Square Online Store.
        ///</summary>
        public IEnumerable<CatalogImage>? images { get; set; }
        ///<summary>
        ///List of item option values associated with this item variation. Listed
        ///in the same order as the item options of the parent item.
        ///</summary>
        public IEnumerable<CatalogItemOptionValue>? optionValues { get; set; }
        ///<summary>
        ///Indicates whether the item variation displays an alert when its inventory quantity is less than or equal
        ///to its `inventory_alert_threshold`.
        ///</summary>
        public InventoryAlert? inventoryAlert { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a "#" character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///When the server receives the new object, it will supply a unique identifier that replaces the temporary identifier for all future references.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Price and inventory alerting overrides for a `CatalogItemVariation` at a specific `Location`.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogItemVariationLocationOverride : GraphQLObject<CatalogItemVariationLocationOverride>
    {
        ///<summary>
        ///The price of the `CatalogItemVariation` at the given `Location`, or blank for variable pricing.
        ///</summary>
        public Money? priceMoney { get; set; }
        ///<summary>
        ///The pricing type (fixed or variable) for the `CatalogItemVariation` at the given `Location`.
        ///</summary>
        public CatalogPricingType? pricingType { get; set; }
        ///<summary>
        ///If `true`, inventory tracking is active for the `CatalogItemVariation` at this `Location`.
        ///</summary>
        public bool? trackInventory { get; set; }
        ///<summary>
        ///Indicates whether the overridden item variation is sold out at the specified location.
        ///
        ///When inventory tracking is enabled on the item variation either globally or at the specified location,
        ///the item variation is automatically marked as sold out when its inventory count reaches zero. The seller
        ///can manually set the item variation as sold out even when the inventory count is greater than zero.
        ///Attempts by an application to set this attribute are ignored. Regardless how the sold-out status is set,
        ///applications should treat its inventory count as zero when this attribute value is `true`.
        ///</summary>
        public bool? soldOut { get; set; }
        ///<summary>
        ///The seller-assigned timestamp, of the RFC 3339 format, to indicate when this sold-out variation
        ///becomes available again at the specified location. Attempts by an application to set this attribute are ignored.
        ///When the current time is later than this attribute value, the affected item variation is no longer sold out.
        ///
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///
        ///UTC:  2020-01-26T02:25:34Z
        ///
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public string? soldOutValidUntil { get; set; }
        ///<summary>
        ///Indicates whether the `CatalogItemVariation` displays an alert when its inventory
        ///quantity is less than or equal to its `inventory_alert_threshold`.
        ///</summary>
        public InventoryAlert? inventoryAlert { get; set; }
        ///<summary>
        ///The ID of the `Location`. This can include locations that are deactivated.
        ///</summary>
        public Location? location { get; set; }
    }

    ///<summary>
    ///Represents the unit used to measure a `CatalogItemVariation` and
    ///specifies the precision for decimal quantities.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogMeasurementUnit : GraphQLObject<CatalogMeasurementUnit>, ICatalogObject
    {
        ///<summary>
        ///An integer between 0 and 5 that represents the maximum number of
        ///positions allowed after the decimal in quantities measured with this unit.
        ///For example:
        ///
        ///- if the precision is 0, the quantity can be 1, 2, 3, etc.
        ///- if the precision is 1, the quantity can be 0.1, 0.2, etc.
        ///- if the precision is 2, the quantity can be 0.01, 0.12, etc.
        ///
        ///Default: 3
        ///</summary>
        public int? precision { get; set; }
        ///<summary>
        ///Indicates the unit used to measure the quantity of a catalog item variation.
        ///</summary>
        public IMeasurementUnit? unit { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///A modifier applicable to items at the time of sale.An example of a modifier is a Cheese add-on to a Burger item.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogModifier : GraphQLObject<CatalogModifier>, ICatalogObject
    {
        ///<summary>
        ///The modifier name.  This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The modifier price.
        ///</summary>
        public Money? priceMoney { get; set; }
        ///<summary>
        ///Location-specific price overrides.
        ///</summary>
        public IEnumerable<ModifierLocationOverride>? locationOverrides { get; set; }
        ///<summary>
        ///Determines where this `CatalogModifier` appears in the `CatalogModifierList`.
        ///</summary>
        public long? ordinal { get; set; }
        ///<summary>
        ///The ID of the image associated with this `CatalogModifier` instance.
        ///Currently this image is not displayed by Square, but is free to be displayed in 3rd party applications.
        ///</summary>
        public CatalogImage? image { get; set; }
        ///<summary>
        ///The ID of the `CatalogModifierList` associated with this modifier.
        ///</summary>
        public CatalogModifierList? modifierList { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///A list of modifiers applicable to items at the time of sale.For example, a "Condiments" modifier list applicable to a "Hot Dog" item
    ///may contain "Ketchup", "Mustard", and "Relish" modifiers.
    ///Use the `selection_type` field to specify whether or not multiple selections from
    ///the modifier list are allowed.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogModifierList : GraphQLObject<CatalogModifierList>, ICatalogObject
    {
        ///<summary>
        ///The name for the `CatalogModifierList` instance. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///Indicates whether multiple options from the modifier list
        ///can be applied to a single `CatalogItem`.
        ///</summary>
        public CatalogModifierListSelectionType? selectionType { get; set; }
        ///<summary>
        ///Determines where this modifier list appears in a list of `CatalogModifierList` values.
        ///</summary>
        public long? ordinal { get; set; }
        ///<summary>
        ///The options included in the `CatalogModifierList`.
        ///You must include at least one `CatalogModifier`.
        ///Each CatalogObject must have type `MODIFIER` and contain
        ///`CatalogModifier` data.
        ///</summary>
        public IEnumerable<CatalogModifier>? modifiers { get; set; }
        ///<summary>
        ///The IDs of images associated with this `CatalogModifierList` instance.
        ///Currently these images are not displayed by Square, but are free to be displayed in 3rd party applications.
        ///</summary>
        public IEnumerable<CatalogImage>? images { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Indicates whether a CatalogModifierList supports multiple selections.
    ///</summary>
    public enum CatalogModifierListSelectionType
    {
        ///<summary>
        ///Indicates that a CatalogModifierList allows only a
        ///single CatalogModifier to be selected.
        ///</summary>
        SINGLE,
        ///<summary>
        ///Indicates that a CatalogModifierList allows multiple
        ///CatalogModifier to be selected.
        ///</summary>
        MULTIPLE,
    }

    ///<summary>
    ///Options to control how to override the default behavior of the specified modifier.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogModifierOverride : GraphQLObject<CatalogModifierOverride>
    {
        ///<summary>
        ///If `true`, this `CatalogModifier` should be selected by default for this `CatalogItem`.
        ///</summary>
        public bool? onByDefault { get; set; }
        ///<summary>
        ///The ID of the `CatalogModifier` whose default behavior is being overridden.
        ///</summary>
        public CatalogModifier? modifier { get; set; }
    }

    ///<summary>
    ///The wrapper object for the catalog entries of a given object type.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "__typename")]
    [JsonDerivedType(typeof(CatalogCategory), typeDiscriminator: "CatalogCategory")]
    [JsonDerivedType(typeof(CatalogCustomAttributeDefinition), typeDiscriminator: "CatalogCustomAttributeDefinition")]
    [JsonDerivedType(typeof(CatalogDiscount), typeDiscriminator: "CatalogDiscount")]
    [JsonDerivedType(typeof(CatalogImage), typeDiscriminator: "CatalogImage")]
    [JsonDerivedType(typeof(CatalogItem), typeDiscriminator: "CatalogItem")]
    [JsonDerivedType(typeof(CatalogItemOption), typeDiscriminator: "CatalogItemOption")]
    [JsonDerivedType(typeof(CatalogItemOptionValue), typeDiscriminator: "CatalogItemOptionValue")]
    [JsonDerivedType(typeof(CatalogItemVariation), typeDiscriminator: "CatalogItemVariation")]
    [JsonDerivedType(typeof(CatalogMeasurementUnit), typeDiscriminator: "CatalogMeasurementUnit")]
    [JsonDerivedType(typeof(CatalogModifier), typeDiscriminator: "CatalogModifier")]
    [JsonDerivedType(typeof(CatalogModifierList), typeDiscriminator: "CatalogModifierList")]
    [JsonDerivedType(typeof(CatalogPricingRule), typeDiscriminator: "CatalogPricingRule")]
    [JsonDerivedType(typeof(CatalogProductSet), typeDiscriminator: "CatalogProductSet")]
    [JsonDerivedType(typeof(CatalogQuickAmountsSettings), typeDiscriminator: "CatalogQuickAmountsSettings")]
    [JsonDerivedType(typeof(CatalogSubscriptionPlan), typeDiscriminator: "CatalogSubscriptionPlan")]
    [JsonDerivedType(typeof(CatalogSubscriptionPlanVariation), typeDiscriminator: "CatalogSubscriptionPlanVariation")]
    [JsonDerivedType(typeof(CatalogTax), typeDiscriminator: "CatalogTax")]
    [JsonDerivedType(typeof(CatalogTimePeriod), typeDiscriminator: "CatalogTimePeriod")]
    public interface ICatalogObject : IGraphQLObject
    {
        public CatalogCategory? AsCatalogCategory() => this as CatalogCategory;
        public CatalogCustomAttributeDefinition? AsCatalogCustomAttributeDefinition() => this as CatalogCustomAttributeDefinition;
        public CatalogDiscount? AsCatalogDiscount() => this as CatalogDiscount;
        public CatalogImage? AsCatalogImage() => this as CatalogImage;
        public CatalogItem? AsCatalogItem() => this as CatalogItem;
        public CatalogItemOption? AsCatalogItemOption() => this as CatalogItemOption;
        public CatalogItemOptionValue? AsCatalogItemOptionValue() => this as CatalogItemOptionValue;
        public CatalogItemVariation? AsCatalogItemVariation() => this as CatalogItemVariation;
        public CatalogMeasurementUnit? AsCatalogMeasurementUnit() => this as CatalogMeasurementUnit;
        public CatalogModifier? AsCatalogModifier() => this as CatalogModifier;
        public CatalogModifierList? AsCatalogModifierList() => this as CatalogModifierList;
        public CatalogPricingRule? AsCatalogPricingRule() => this as CatalogPricingRule;
        public CatalogProductSet? AsCatalogProductSet() => this as CatalogProductSet;
        public CatalogQuickAmountsSettings? AsCatalogQuickAmountsSettings() => this as CatalogQuickAmountsSettings;
        public CatalogSubscriptionPlan? AsCatalogSubscriptionPlan() => this as CatalogSubscriptionPlan;
        public CatalogSubscriptionPlanVariation? AsCatalogSubscriptionPlanVariation() => this as CatalogSubscriptionPlanVariation;
        public CatalogTax? AsCatalogTax() => this as CatalogTax;
        public CatalogTimePeriod? AsCatalogTimePeriod() => this as CatalogTimePeriod;
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; }
    }

    ///<summary>
    ///Contains information of a query result.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class CatalogObjectConnection : GraphQLObject<CatalogObjectConnection>, IConnectionWithNodes<ICatalogObject>
    {
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
        ///<summary>
        ///List of CatalogObjects
        ///</summary>
        public IEnumerable<ICatalogObject>? nodes { get; set; }
    }

    ///<summary>
    ///Possible types of CatalogObjects returned from the catalog, each
    ///containing type-specific properties in the `*_data` field corresponding to the specified object type.
    ///</summary>
    public enum CatalogObjectType
    {
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogItem](entity:CatalogItem) type and represents an item. The item-specific data
        ///must be set on the `item_data` field.
        ///</summary>
        ITEM,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogImage](entity:CatalogImage) type and represents an image. The image-specific data
        ///must be set on the `image_data` field.
        ///</summary>
        IMAGE,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogCategory](entity:CatalogCategory) type and represents a category. The category-specific data
        ///must be set on the `category_data` field.
        ///</summary>
        CATEGORY,
        ///<summary>
        ///The `CatalogObject` instance is of the  [CatalogItemVariation](entity:CatalogItemVariation) type and represents an item variation, also referred to as variation.
        ///The item variation-specific data must be set on the `item_variation_data` field.
        ///</summary>
        ITEM_VARIATION,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogTax](entity:CatalogTax) type and represents a tax. The tax-specific data
        ///must be set on the `tax_data` field.
        ///</summary>
        TAX,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogDiscount](entity:CatalogDiscount) type and represents a discount. The discount-specific data
        ///must be set on the `discount_data` field.
        ///</summary>
        DISCOUNT,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogModifierList](entity:CatalogModifierList) type and represents a modifier list.
        ///The modifier-list-specific data must be set on the `modifier_list_data` field.
        ///</summary>
        MODIFIER_LIST,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogModifier](entity:CatalogModifier) type and represents a modifier. The modifier-specific data
        ///must be set on the `modifier_data` field.
        ///</summary>
        MODIFIER,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogPricingRule](entity:CatalogPricingRule) type and represents a pricing rule. The pricing-rule-specific data
        ///must be set on the `pricing_rule_data` field.
        ///</summary>
        PRICING_RULE,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogProductSet](entity:CatalogProductSet) type and represents a product set.
        ///The product-set-specific data will be stored in the `product_set_data` field.
        ///</summary>
        PRODUCT_SET,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogTimePeriod](entity:CatalogTimePeriod) type and represents a time period.
        ///The time-period-specific data must be set on the `time_period_data` field.
        ///</summary>
        TIME_PERIOD,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogMeasurementUnit](entity:CatalogMeasurementUnit) type and represents a measurement unit specifying the unit of
        ///measure and precision in which an item variation is sold. The measurement-unit-specific data must set on the `measurement_unit_data` field.
        ///</summary>
        MEASUREMENT_UNIT,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogSubscriptionPlan](entity:CatalogSubscriptionPlan) type and represents a subscription plan.
        ///The subscription-plan-specific data must be stored on the `subscription_plan_data` field.
        ///</summary>
        SUBSCRIPTION_PLAN_VARIATION,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogItemOption](entity:CatalogItemOption) type and represents a list of options (such as a color or size of a T-shirt)
        ///that can be assigned to item variations. The item-option-specific data must be on the `item_option_data` field.
        ///</summary>
        ITEM_OPTION,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogItemOptionValue](entity:CatalogItemOptionValue) type and represents a value associated with one or more item options.
        ///For example, an item option of "Size" may have item option values such as "Small" or "Medium".
        ///The item-option-value-specific data must be on the `item_option_value_data` field.
        ///</summary>
        ITEM_OPTION_VAL,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogCustomAttributeDefinition](entity:CatalogCustomAttributeDefinition) type and represents the definition of a custom attribute.
        ///The custom-attribute-definition-specific data must be set on the `custom_attribute_definition_data` field.
        ///</summary>
        CUSTOM_ATTRIBUTE_DEFINITION,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogQuickAmountsSettings](entity:CatalogQuickAmountsSettings) type and represents settings to configure preset charges for quick payments at each location.
        ///For example, a location may have a list of both AUTO and MANUAL quick amounts that are set to DISABLED.
        ///The quick-amounts-settings-specific data must be set on the `quick_amounts_settings_data` field.
        ///</summary>
        QUICK_AMOUNTS_SETTINGS,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogSubscriptionPlan](entity:CatalogSubscriptionPlan) type and represents a subscription plan.
        ///The subscription plan specific data must be stored on the `subscription_plan_data` field.
        ///</summary>
        SUBSCRIPTION_PLAN,
    }

    ///<summary>
    ///Defines how discounts are automatically applied to a set of items that match the pricing rule
    ///during the active time period.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogPricingRule : GraphQLObject<CatalogPricingRule>, ICatalogObject
    {
        ///<summary>
        ///User-defined name for the pricing rule. For example, "Buy one get one
        ///free" or "10% off".
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///Represents the date the Pricing Rule is valid from. Represented in RFC 3339 full-date format (YYYY-MM-DD).
        ///</summary>
        public string? validFromDate { get; set; }
        ///<summary>
        ///Represents the local time the pricing rule should be valid from. Represented in RFC 3339 partial-time format
        ///(HH:MM:SS). Partial seconds will be truncated.
        ///</summary>
        public string? validFromLocalTime { get; set; }
        ///<summary>
        ///Represents the date the Pricing Rule is valid until. Represented in RFC 3339 full-date format (YYYY-MM-DD).
        ///</summary>
        public string? validUntilDate { get; set; }
        ///<summary>
        ///Represents the local time the pricing rule should be valid until. Represented in RFC 3339 partial-time format
        ///(HH:MM:SS). Partial seconds will be truncated.
        ///</summary>
        public string? validUntilLocalTime { get; set; }
        ///<summary>
        ///If an `exclude_products_id` was given, controls which subset of matched
        ///products is excluded from any discounts.
        ///
        ///Default value: `LEAST_EXPENSIVE`
        ///</summary>
        public ExcludeStrategy? excludeStrategy { get; set; }
        ///<summary>
        ///The minimum order subtotal (before discounts or taxes are applied)
        ///that must be met before this rule may be applied.
        ///</summary>
        public Money? minimumOrderSubtotalMoney { get; set; }
        ///<summary>
        ///Unique ID for the `CatalogDiscount` to take off
        ///the price of all matched items.
        ///</summary>
        public CatalogDiscount? discount { get; set; }
        ///<summary>
        ///Unique ID for the `CatalogProductSet` that will be matched by this rule. A match rule
        ///matches within the entire cart, and can match multiple times. This field will always be set.
        ///</summary>
        public CatalogProductSet? matchProducts { get; set; }
        ///<summary>
        ///__Deprecated__: Please use the `exclude_products_id` field to apply
        ///an exclude set instead. Exclude sets allow better control over quantity
        ///ranges and offer more flexibility for which matched items receive a discount.
        ///
        ///`CatalogProductSet` to apply the pricing to.
        ///An apply rule matches within the subset of the cart that fits the match rules (the match set).
        ///An apply rule can only match once in the match set.
        ///If not supplied, the pricing will be applied to all products in the match set.
        ///Other products retain their base price, or a price generated by other rules.
        ///</summary>
        public CatalogProductSet? applyProducts { get; set; }
        ///<summary>
        ///`CatalogProductSet` to exclude from the pricing rule.
        ///An exclude rule matches within the subset of the cart that fits the match rules (the match set).
        ///An exclude rule can only match once in the match set.
        ///If not supplied, the pricing will be applied to all products in the match set.
        ///Other products retain their base price, or a price generated by other rules.
        ///</summary>
        public CatalogProductSet? excludeProducts { get; set; }
        ///<summary>
        ///A list of unique IDs for the catalog time periods when
        ///this pricing rule is in effect. If left unset, the pricing rule is always
        ///in effect.
        ///</summary>
        public IEnumerable<CatalogTimePeriod>? timePeriods { get; set; }
        ///<summary>
        ///A list of IDs of customer groups, the members of which are eligible for discounts specified in this pricing rule.
        ///Notice that a group ID is generated by the Customers API.
        ///If this field is not set, the specified discount applies to matched products sold to anyone whether the buyer
        ///has a customer profile created or not. If this `customer_group_ids_any` field is set, the specified discount
        ///applies only to matched products sold to customers belonging to the specified customer groups.
        ///</summary>
        public IEnumerable<string>? customerGroupIds { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Indicates whether the price of a CatalogItemVariation should be entered manually at the time of sale.
    ///</summary>
    public enum CatalogPricingType
    {
        ///<summary>
        ///The catalog item variation's price is fixed.
        ///</summary>
        FIXED_PRICING,
        ///<summary>
        ///The catalog item variation's price is entered at the time of sale.
        ///</summary>
        VARIABLE_PRICING,
    }

    ///<summary>
    ///Represents a collection of catalog objects for the purpose of applying a
    ///`PricingRule`.Including a catalog object will include all of its subtypes.
    ///For example, including a category in a product set will include all of its
    ///items and associated item variations in the product set. Including an item in
    ///a product set will also include its item variations.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogProductSet : GraphQLObject<CatalogProductSet>, ICatalogObject
    {
        ///<summary>
        ///User-defined name for the product set. For example, "Clearance Items"
        ///or "Winter Sale Items".
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///If set, there must be exactly this many items from `products_any` or `products_all`
        ///in the cart for the discount to apply.
        ///
        ///Cannot be combined with either `quantity_min` or `quantity_max`.
        ///</summary>
        public int? quantityExact { get; set; }
        ///<summary>
        ///If set, there must be at least this many items from `products_any` or `products_all`
        ///in a cart for the discount to apply. See `quantity_exact`. Defaults to 0 if
        ///`quantity_exact`, `quantity_min` and `quantity_max` are all unspecified.
        ///</summary>
        public int? quantityMin { get; set; }
        ///<summary>
        ///If set, the pricing rule will apply to a maximum of this many items from
        ///`products_any` or `products_all`.
        ///</summary>
        public int? quantityMax { get; set; }
        ///<summary>
        ///If set to `true`, the product set will include every item in the catalog.
        ///Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        ///</summary>
        public bool? allProducts { get; set; }
        ///<summary>
        ///Unique IDs for any `CatalogObject` included in this product set.
        ///All objects in this set must be included in an order for a pricing rule to apply.
        ///
        ///Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        ///
        ///Max: 500 catalog object IDs.
        ///</summary>
        public IEnumerable<ICatalogObject>? allSetProducts { get; set; }
        ///<summary>
        /// Unique IDs for any `CatalogObject` included in this product set. Any
        ///number of these catalog objects can be in an order for a pricing rule to apply.
        ///
        ///This can be used with `product_ids_all` in a parent `CatalogProductSet` to
        ///match groups of products for a bulk discount, such as a discount for an
        ///entree and side combo.
        ///
        ///Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        ///
        ///Max: 500 catalog object IDs.
        ///</summary>
        public IEnumerable<ICatalogObject>? anySetProducts { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Represents a Quick Amount in the Catalog.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogQuickAmount : GraphQLObject<CatalogQuickAmount>
    {
        ///<summary>
        ///Represents the type of the Quick Amount.
        ///</summary>
        public CatalogQuickAmountType? type { get; set; }
        ///<summary>
        ///Represents the actual amount of the Quick Amount with Money type.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///Describes the ranking of the Quick Amount provided by machine learning model, in the range [0, 100].
        ///MANUAL type amount will always have score = 100.
        ///</summary>
        public int? score { get; set; }
        ///<summary>
        ///The order in which this Quick Amount should be displayed.
        ///</summary>
        public long? ordinal { get; set; }
    }

    ///<summary>
    ///A parent Catalog Object model represents a set of Quick Amounts and the settings control the amounts.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogQuickAmountsSettings : GraphQLObject<CatalogQuickAmountsSettings>, ICatalogObject
    {
        ///<summary>
        ///Represents the option seller currently uses on Quick Amounts.
        ///</summary>
        public CatalogQuickAmountsSettingsOption? option { get; set; }
        ///<summary>
        ///Represents location's eligibility for auto amounts
        ///The boolean should be consistent with whether there are AUTO amounts in the `amounts`.
        ///</summary>
        public bool? eligibleForAutoAmounts { get; set; }
        ///<summary>
        ///Represents a set of Quick Amounts at this location.
        ///</summary>
        public IEnumerable<CatalogQuickAmount>? amounts { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Determines a seller's option on Quick Amounts feature.
    ///</summary>
    public enum CatalogQuickAmountsSettingsOption
    {
        ///<summary>
        ///Option for seller to disable Quick Amounts.
        ///</summary>
        DISABLED,
        ///<summary>
        ///Option for seller to choose manually created Quick Amounts.
        ///</summary>
        MANUAL,
        ///<summary>
        ///Option for seller to choose automatically created Quick Amounts.
        ///</summary>
        AUTO,
    }

    ///<summary>
    ///Determines the type of a specific Quick Amount.
    ///</summary>
    public enum CatalogQuickAmountType
    {
        ///<summary>
        ///Quick Amount is created manually by the seller.
        ///</summary>
        QUICK_AMOUNT_TYPE_MANUAL,
        ///<summary>
        ///Quick Amount is generated automatically by machine learning algorithms.
        ///</summary>
        QUICK_AMOUNT_TYPE_AUTO,
    }

    ///<summary>
    ///Catalog service charge
    ///
    ///Permissions:ORDERS_READ
    ///</summary>
    public class CatalogServiceCharge : GraphQLObject<CatalogServiceCharge>
    {
        ///<summary>
        ///ID belonging to the service charge.
        ///</summary>
        public string? id { get; set; }
    }

    ///<summary>
    ///CatalogSort is used for sorting the result for items query
    ///</summary>
    public enum CatalogSort
    {
        name_DESC,
        name_ASC,
    }

    ///<summary>
    ///Represents the rule of conversion between a stockable CatalogItemVariation
    ///and a non-stockable sell-by or receive-by `CatalogItemVariation` that
    ///share the same underlying stock.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogStockConversion : GraphQLObject<CatalogStockConversion>
    {
        ///<summary>
        ///The quantity of the stockable item variation (as identified by `stockable_item_variation_id`)
        ///equivalent to the non-stockable item variation quantity (as specified in `nonstockable_quantity`)
        ///as defined by this stock conversion.  It accepts a decimal number in a string format that can take
        ///up to 10 digits before the decimal point and up to 5 digits after the decimal point.
        ///</summary>
        public string? stockableQuantity { get; set; }
        ///<summary>
        ///The converted equivalent quantity of the non-stockable CatalogItemVariation
        ///in its measurement unit. The `stockable_quantity` value and this `nonstockable_quantity` value together
        ///define the conversion ratio between stockable item variation and the non-stockable item variation.
        ///It accepts a decimal number in a string format that can take up to 10 digits before the decimal point
        ///and up to 5 digits after the decimal point.
        ///</summary>
        public string? nonstockableQuantity { get; set; }
        ///<summary>
        ///References to the stockable CatalogItemVariation
        ///for this stock conversion. Selling, receiving or recounting the non-stockable `CatalogItemVariation`
        ///defined with a stock conversion results in adjustments of this stockable `CatalogItemVariation`.
        ///This immutable field must reference a stockable `CatalogItemVariation`
        ///that shares the parent CatalogItem of the converted `CatalogItemVariation.`
        ///</summary>
        public CatalogItemVariation? stockableItemVariation { get; set; }
    }

    ///<summary>
    ///Defines supported stock levels of the item inventory.
    ///</summary>
    public enum CatalogStockLevel
    {
        ///<summary>
        ///The item inventory is empty.
        ///</summary>
        OUT,
        ///<summary>
        ///The item inventory is low.
        ///</summary>
        LOW,
    }

    ///<summary>
    ///Describes a subscription plan.A subscription plan represents what you want to sell in a subscription model, and includes references to each of the associated subscription plan variations. 
    ///For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogSubscriptionPlan : GraphQLObject<CatalogSubscriptionPlan>, ICatalogObject
    {
        ///<summary>
        ///The name of the plan.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///A list of SubscriptionPhase containing the SubscriptionPhase for this plan.
        ///This field it required. Not including this field will throw a REQUIRED_FIELD_MISSING error
        ///</summary>
        public IEnumerable<SubscriptionPhase>? phases { get; set; }
        ///<summary>
        ///If true, all items in the merchant's catalog are subscribable by this SubscriptionPlan.
        ///</summary>
        public bool? allItems { get; set; }
        ///<summary>
        ///The list of subscription plan variations available for this product
        ///</summary>
        public IEnumerable<CatalogSubscriptionPlanVariation>? subscriptionPlanVariations { get; set; }
        ///<summary>
        ///The list of IDs of `CatalogItems` that are eligible for subscription by this SubscriptionPlan's variations.
        ///</summary>
        public IEnumerable<CatalogItem>? eligibleItems { get; set; }
        ///<summary>
        ///The list of IDs of `CatalogCategory` that are eligible for subscription by this SubscriptionPlan's variations.
        ///</summary>
        public IEnumerable<CatalogCategory>? eligibleCategories { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Describes a subscription plan variation.A subscription plan variation represents how the subscription for a product or service is sold.
    ///For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogSubscriptionPlanVariation : GraphQLObject<CatalogSubscriptionPlanVariation>, ICatalogObject
    {
        ///<summary>
        ///The name of the plan variation.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///A list containing each SubscriptionPhase for this plan variation.
        ///</summary>
        public IEnumerable<SubscriptionPhase>? phases { get; set; }
        ///<summary>
        ///The id of the subscription plan, if there is one.
        ///</summary>
        public CatalogSubscriptionPlan? subscriptionPlan { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///A tax applicable to an item.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogTax : GraphQLObject<CatalogTax>, ICatalogObject
    {
        ///<summary>
        ///The tax's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///Whether the tax is calculated based on a payment's subtotal or total.
        ///</summary>
        public TaxCalculationPhase? calculationPhase { get; set; }
        ///<summary>
        ///Whether the tax is `ADDITIVE` or `INCLUSIVE`.
        ///</summary>
        public TaxInclusionType? inclusionType { get; set; }
        ///<summary>
        ///If `true`, the fee applies to custom amounts entered into the Square Point of Sale
        ///app that are not associated with a particular `CatalogItem`.
        ///</summary>
        public bool? appliesToCustomAmounts { get; set; }
        ///<summary>
        ///A Boolean flag to indicate whether the tax is displayed as enabled (`true`) in the Square Point of Sale app or not (`false`).
        ///</summary>
        public bool? enabled { get; set; }
        ///<summary>
        ///The percentage of the tax in decimal form, using a `'.'` as the decimal separator and without a `'%'` sign.
        ///A value of `7.5` corresponds to 7.5%. For a location-specific tax rate, contact the tax authority of the location or a tax consultant.
        ///</summary>
        public decimal? percentage { get; set; }
        ///<summary>
        ///The ID of a `CatalogProductSet` object. If set, the tax is applicable to all products in the product set.
        ///</summary>
        public CatalogProductSet? appliesToProductSet { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Represents a time period - either a single period or a repeating period.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class CatalogTimePeriod : GraphQLObject<CatalogTimePeriod>, ICatalogObject
    {
        ///<summary>
        ///An iCalendar (RFC 5545) [event](https://tools.ietf.org/html/rfc5545#section-3.6.1), which
        ///specifies the name, timing, duration and recurrence of this time period.
        ///
        ///Example:
        ///
        ///```
        ///DTSTART:20190707T180000
        ///DURATION:P2H
        ///RRULE:FREQ=WEEKLY;BYDAY=MO,WE,FR
        ///```
        ///
        ///Only `SUMMARY`, `DTSTART`, `DURATION` and `RRULE` fields are supported.
        ///`DTSTART` must be in local (unzoned) time format. Note that while `BEGIN:VEVENT`
        ///and `END:VEVENT` is not required in the request. The response will always
        ///include them.
        ///</summary>
        public string? @event { get; set; }
        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        public long? version { get; set; }
        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        public IEnumerable<string>? catalogV1Ids { get; set; }
        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        public bool? isDeleted { get; set; }
        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }
        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? absentAt { get; set; }
        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        public IEnumerable<Location>? presentAt { get; set; }
        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about Clearpay payments.
    ///</summary>
    public class ClearpayPaymentDetails : GraphQLObject<ClearpayPaymentDetails>
    {
        ///<summary>
        ///Email address on the buyer's Clearpay account.
        ///</summary>
        public string? emailAddress { get; set; }
    }

    ///<summary>
    ///Indicates the country associated with another entity, such as a business.
    ///Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
    ///</summary>
    public enum Country
    {
        ///<summary>
        ///Andorra
        ///</summary>
        AD,
        ///<summary>
        ///United Arab Emirates
        ///</summary>
        AE,
        ///<summary>
        ///Afghanistan
        ///</summary>
        AF,
        ///<summary>
        ///Antigua and Barbuda
        ///</summary>
        AG,
        ///<summary>
        ///Anguilla
        ///</summary>
        AI,
        ///<summary>
        ///Albania
        ///</summary>
        AL,
        ///<summary>
        ///Armenia
        ///</summary>
        AM,
        ///<summary>
        ///Angola
        ///</summary>
        AO,
        ///<summary>
        ///Antartica
        ///</summary>
        AQ,
        ///<summary>
        ///Argentina
        ///</summary>
        AR,
        ///<summary>
        ///American Samoa
        ///</summary>
        AS,
        ///<summary>
        ///Austria
        ///</summary>
        AT,
        ///<summary>
        ///Australia
        ///</summary>
        AU,
        ///<summary>
        ///Aruba
        ///</summary>
        AW,
        ///<summary>
        ///Åland Islands
        ///</summary>
        AX,
        ///<summary>
        ///Azerbaijan
        ///</summary>
        AZ,
        ///<summary>
        ///Bosnia and Herzegovina
        ///</summary>
        BA,
        ///<summary>
        ///Barbados
        ///</summary>
        BB,
        ///<summary>
        ///Bangladesh
        ///</summary>
        BD,
        ///<summary>
        ///Belgium
        ///</summary>
        BE,
        ///<summary>
        ///Burkina Faso
        ///</summary>
        BF,
        ///<summary>
        ///Bulgaria
        ///</summary>
        BG,
        ///<summary>
        ///Bahrain
        ///</summary>
        BH,
        ///<summary>
        ///Burundi
        ///</summary>
        BI,
        ///<summary>
        ///Benin
        ///</summary>
        BJ,
        ///<summary>
        ///Saint Barthélemy
        ///</summary>
        BL,
        ///<summary>
        ///Bermuda
        ///</summary>
        BM,
        ///<summary>
        ///Brunei
        ///</summary>
        BN,
        ///<summary>
        ///Bolivia
        ///</summary>
        BO,
        ///<summary>
        ///Bonaire
        ///</summary>
        BQ,
        ///<summary>
        ///Brazil
        ///</summary>
        BR,
        ///<summary>
        ///Bahamas
        ///</summary>
        BS,
        ///<summary>
        ///Bhutan
        ///</summary>
        BT,
        ///<summary>
        ///Bouvet Island
        ///</summary>
        BV,
        ///<summary>
        ///Botswana
        ///</summary>
        BW,
        ///<summary>
        ///Belarus
        ///</summary>
        BY,
        ///<summary>
        ///Belize
        ///</summary>
        BZ,
        ///<summary>
        ///Canada
        ///</summary>
        CA,
        ///<summary>
        ///Cocos Islands
        ///</summary>
        CC,
        ///<summary>
        ///Democratic Republic of the Congo
        ///</summary>
        CD,
        ///<summary>
        ///Central African Republic
        ///</summary>
        CF,
        ///<summary>
        ///Congo
        ///</summary>
        CG,
        ///<summary>
        ///Switzerland
        ///</summary>
        CH,
        ///<summary>
        ///Ivory Coast
        ///</summary>
        CI,
        ///<summary>
        ///Cook Islands
        ///</summary>
        CK,
        ///<summary>
        ///Chile
        ///</summary>
        CL,
        ///<summary>
        ///Cameroon
        ///</summary>
        CM,
        ///<summary>
        ///China
        ///</summary>
        CN,
        ///<summary>
        ///Colombia
        ///</summary>
        CO,
        ///<summary>
        ///Costa Rica
        ///</summary>
        CR,
        ///<summary>
        ///Cuba
        ///</summary>
        CU,
        ///<summary>
        ///Cabo Verde
        ///</summary>
        CV,
        ///<summary>
        ///Curaçao
        ///</summary>
        CW,
        ///<summary>
        ///Christmas Island
        ///</summary>
        CX,
        ///<summary>
        ///Cyprus
        ///</summary>
        CY,
        ///<summary>
        ///Czechia
        ///</summary>
        CZ,
        ///<summary>
        ///Germany
        ///</summary>
        DE,
        ///<summary>
        ///Djibouti
        ///</summary>
        DJ,
        ///<summary>
        ///Denmark
        ///</summary>
        DK,
        ///<summary>
        ///Dominica
        ///</summary>
        DM,
        ///<summary>
        ///Dominican Republic
        ///</summary>
        DO,
        ///<summary>
        ///Algeria
        ///</summary>
        DZ,
        ///<summary>
        ///Ecuador
        ///</summary>
        EC,
        ///<summary>
        ///Estonia
        ///</summary>
        EE,
        ///<summary>
        ///Egypt
        ///</summary>
        EG,
        ///<summary>
        ///Western Sahara
        ///</summary>
        EH,
        ///<summary>
        ///Eritrea
        ///</summary>
        ER,
        ///<summary>
        ///Spain
        ///</summary>
        ES,
        ///<summary>
        ///Ethiopia
        ///</summary>
        ET,
        ///<summary>
        ///Finland
        ///</summary>
        FI,
        ///<summary>
        ///Fiji
        ///</summary>
        FJ,
        ///<summary>
        ///Falkland Islands
        ///</summary>
        FK,
        ///<summary>
        ///Federated States of Micronesia
        ///</summary>
        FM,
        ///<summary>
        ///Faroe Islands
        ///</summary>
        FO,
        ///<summary>
        ///France
        ///</summary>
        FR,
        ///<summary>
        ///Gabon
        ///</summary>
        GA,
        ///<summary>
        ///United Kingdom
        ///</summary>
        GB,
        ///<summary>
        ///Grenada
        ///</summary>
        GD,
        ///<summary>
        ///Georgia
        ///</summary>
        GE,
        ///<summary>
        ///French Guiana
        ///</summary>
        GF,
        ///<summary>
        ///Guernsey
        ///</summary>
        GG,
        ///<summary>
        ///Ghana
        ///</summary>
        GH,
        ///<summary>
        ///Gibraltar
        ///</summary>
        GI,
        ///<summary>
        ///Greenland
        ///</summary>
        GL,
        ///<summary>
        ///Gambia
        ///</summary>
        GM,
        ///<summary>
        ///Guinea
        ///</summary>
        GN,
        ///<summary>
        ///Guadeloupe
        ///</summary>
        GP,
        ///<summary>
        ///Equatorial Guinea
        ///</summary>
        GQ,
        ///<summary>
        ///Greece
        ///</summary>
        GR,
        ///<summary>
        ///South Georgia and the South Sandwich Islands
        ///</summary>
        GS,
        ///<summary>
        ///Guatemala
        ///</summary>
        GT,
        ///<summary>
        ///Guam
        ///</summary>
        GU,
        ///<summary>
        ///Guinea-Bissau
        ///</summary>
        GW,
        ///<summary>
        ///Guyana
        ///</summary>
        GY,
        ///<summary>
        ///Hong Kong
        ///</summary>
        HK,
        ///<summary>
        ///Heard Island and McDonald Islands
        ///</summary>
        HM,
        ///<summary>
        ///Honduras
        ///</summary>
        HN,
        ///<summary>
        ///Croatia
        ///</summary>
        HR,
        ///<summary>
        ///Haiti
        ///</summary>
        HT,
        ///<summary>
        ///Hungary
        ///</summary>
        HU,
        ///<summary>
        ///Indonesia
        ///</summary>
        ID,
        ///<summary>
        ///Ireland
        ///</summary>
        IE,
        ///<summary>
        ///Israel
        ///</summary>
        IL,
        ///<summary>
        ///Isle of Man
        ///</summary>
        IM,
        ///<summary>
        ///India
        ///</summary>
        IN,
        ///<summary>
        ///British Indian Ocean Territory
        ///</summary>
        IO,
        ///<summary>
        ///Iraq
        ///</summary>
        IQ,
        ///<summary>
        ///Iran
        ///</summary>
        IR,
        ///<summary>
        ///Iceland
        ///</summary>
        IS,
        ///<summary>
        ///Italy
        ///</summary>
        IT,
        ///<summary>
        ///Jersey
        ///</summary>
        JE,
        ///<summary>
        ///Jamaica
        ///</summary>
        JM,
        ///<summary>
        ///Jordan
        ///</summary>
        JO,
        ///<summary>
        ///Japan
        ///</summary>
        JP,
        ///<summary>
        ///Kenya
        ///</summary>
        KE,
        ///<summary>
        ///Kyrgyzstan
        ///</summary>
        KG,
        ///<summary>
        ///Cambodia
        ///</summary>
        KH,
        ///<summary>
        ///Kiribati
        ///</summary>
        KI,
        ///<summary>
        ///Comoros
        ///</summary>
        KM,
        ///<summary>
        ///Saint Kitts and Nevis
        ///</summary>
        KN,
        ///<summary>
        ///Democratic People's Republic of Korea
        ///</summary>
        KP,
        ///<summary>
        ///Republic of Korea
        ///</summary>
        KR,
        ///<summary>
        ///Kuwait
        ///</summary>
        KW,
        ///<summary>
        ///Cayman Islands
        ///</summary>
        KY,
        ///<summary>
        ///Kazakhstan
        ///</summary>
        KZ,
        ///<summary>
        ///Lao People's Democratic Republic
        ///</summary>
        LA,
        ///<summary>
        ///Lebanon
        ///</summary>
        LB,
        ///<summary>
        ///Saint Lucia
        ///</summary>
        LC,
        ///<summary>
        ///Liechtenstein
        ///</summary>
        LI,
        ///<summary>
        ///Sri Lanka
        ///</summary>
        LK,
        ///<summary>
        ///Liberia
        ///</summary>
        LR,
        ///<summary>
        ///Lesotho
        ///</summary>
        LS,
        ///<summary>
        ///Lithuania
        ///</summary>
        LT,
        ///<summary>
        ///Luxembourg
        ///</summary>
        LU,
        ///<summary>
        ///Latvia
        ///</summary>
        LV,
        ///<summary>
        ///Libya
        ///</summary>
        LY,
        ///<summary>
        ///Morocco
        ///</summary>
        MA,
        ///<summary>
        ///Monaco
        ///</summary>
        MC,
        ///<summary>
        ///Moldova
        ///</summary>
        MD,
        ///<summary>
        ///Montenegro
        ///</summary>
        ME,
        ///<summary>
        ///Saint Martin
        ///</summary>
        MF,
        ///<summary>
        ///Madagascar
        ///</summary>
        MG,
        ///<summary>
        ///Marshall Islands
        ///</summary>
        MH,
        ///<summary>
        ///North Macedonia
        ///</summary>
        MK,
        ///<summary>
        ///Mali
        ///</summary>
        ML,
        ///<summary>
        ///Myanmar
        ///</summary>
        MM,
        ///<summary>
        ///Mongolia
        ///</summary>
        MN,
        ///<summary>
        ///Macao
        ///</summary>
        MO,
        ///<summary>
        ///Northern Mariana Islands
        ///</summary>
        MP,
        ///<summary>
        ///Martinique
        ///</summary>
        MQ,
        ///<summary>
        ///Mauritania
        ///</summary>
        MR,
        ///<summary>
        ///Montserrat
        ///</summary>
        MS,
        ///<summary>
        ///Malta
        ///</summary>
        MT,
        ///<summary>
        ///Mauritius
        ///</summary>
        MU,
        ///<summary>
        ///Maldives
        ///</summary>
        MV,
        ///<summary>
        ///Malawi
        ///</summary>
        MW,
        ///<summary>
        ///Mexico
        ///</summary>
        MX,
        ///<summary>
        ///Malaysia
        ///</summary>
        MY,
        ///<summary>
        ///Mozambique
        ///</summary>
        MZ,
        ///<summary>
        ///Namibia
        ///</summary>
        NA,
        ///<summary>
        ///New Caledonia
        ///</summary>
        NC,
        ///<summary>
        ///Niger
        ///</summary>
        NE,
        ///<summary>
        ///Norfolk Island
        ///</summary>
        NF,
        ///<summary>
        ///Nigeria
        ///</summary>
        NG,
        ///<summary>
        ///Nicaragua
        ///</summary>
        NI,
        ///<summary>
        ///Netherlands
        ///</summary>
        NL,
        ///<summary>
        ///Norway
        ///</summary>
        NO,
        ///<summary>
        ///Nepal
        ///</summary>
        NP,
        ///<summary>
        ///Nauru
        ///</summary>
        NR,
        ///<summary>
        ///Niue
        ///</summary>
        NU,
        ///<summary>
        ///New Zealand
        ///</summary>
        NZ,
        ///<summary>
        ///Oman
        ///</summary>
        OM,
        ///<summary>
        ///Panama
        ///</summary>
        PA,
        ///<summary>
        ///Peru
        ///</summary>
        PE,
        ///<summary>
        ///French Polynesia
        ///</summary>
        PF,
        ///<summary>
        ///Papua New Guinea
        ///</summary>
        PG,
        ///<summary>
        ///Philippines
        ///</summary>
        PH,
        ///<summary>
        ///Pakistan
        ///</summary>
        PK,
        ///<summary>
        ///Poland
        ///</summary>
        PL,
        ///<summary>
        ///Saint Pierre and Miquelon
        ///</summary>
        PM,
        ///<summary>
        ///Pitcairn
        ///</summary>
        PN,
        ///<summary>
        ///Puerto Rico
        ///</summary>
        PR,
        ///<summary>
        ///Palestine
        ///</summary>
        PS,
        ///<summary>
        ///Portugal
        ///</summary>
        PT,
        ///<summary>
        ///Palau
        ///</summary>
        PW,
        ///<summary>
        ///Paraguay
        ///</summary>
        PY,
        ///<summary>
        ///Qatar
        ///</summary>
        QA,
        ///<summary>
        ///Réunion
        ///</summary>
        RE,
        ///<summary>
        ///Romania
        ///</summary>
        RO,
        ///<summary>
        ///Serbia
        ///</summary>
        RS,
        ///<summary>
        ///Russia
        ///</summary>
        RU,
        ///<summary>
        ///Rwanda
        ///</summary>
        RW,
        ///<summary>
        ///Saudi Arabia
        ///</summary>
        SA,
        ///<summary>
        ///Solomon Islands
        ///</summary>
        SB,
        ///<summary>
        ///Seychelles
        ///</summary>
        SC,
        ///<summary>
        ///Sudan
        ///</summary>
        SD,
        ///<summary>
        ///Sweden
        ///</summary>
        SE,
        ///<summary>
        ///Singapore
        ///</summary>
        SG,
        ///<summary>
        ///Saint Helena, Ascension and Tristan da Cunha
        ///</summary>
        SH,
        ///<summary>
        ///Slovenia
        ///</summary>
        SI,
        ///<summary>
        ///Svalbard and Jan Mayen
        ///</summary>
        SJ,
        ///<summary>
        ///Slovakia
        ///</summary>
        SK,
        ///<summary>
        ///Sierra Leone
        ///</summary>
        SL,
        ///<summary>
        ///San Marino
        ///</summary>
        SM,
        ///<summary>
        ///Senegal
        ///</summary>
        SN,
        ///<summary>
        ///Somalia
        ///</summary>
        SO,
        ///<summary>
        ///Suriname
        ///</summary>
        SR,
        ///<summary>
        ///South Sudan
        ///</summary>
        SS,
        ///<summary>
        ///Sao Tome and Principe
        ///</summary>
        ST,
        ///<summary>
        ///El Salvador
        ///</summary>
        SV,
        ///<summary>
        ///Sint Maarten
        ///</summary>
        SX,
        ///<summary>
        ///Syrian Arab Republic
        ///</summary>
        SY,
        ///<summary>
        ///Eswatini
        ///</summary>
        SZ,
        ///<summary>
        ///Turks and Caicos Islands
        ///</summary>
        TC,
        ///<summary>
        ///Chad
        ///</summary>
        TD,
        ///<summary>
        ///French Southern Territories
        ///</summary>
        TF,
        ///<summary>
        ///Togo
        ///</summary>
        TG,
        ///<summary>
        ///Thailand
        ///</summary>
        TH,
        ///<summary>
        ///Tajikistan
        ///</summary>
        TJ,
        ///<summary>
        ///Tokelau
        ///</summary>
        TK,
        ///<summary>
        ///Timor-Leste
        ///</summary>
        TL,
        ///<summary>
        ///Turkmenistan
        ///</summary>
        TM,
        ///<summary>
        ///Tunisia
        ///</summary>
        TN,
        ///<summary>
        ///Tonga
        ///</summary>
        TO,
        ///<summary>
        ///Turkey
        ///</summary>
        TR,
        ///<summary>
        ///Trinidad and Tobago
        ///</summary>
        TT,
        ///<summary>
        ///Tuvalu
        ///</summary>
        TV,
        ///<summary>
        ///Taiwan
        ///</summary>
        TW,
        ///<summary>
        ///Tanzania
        ///</summary>
        TZ,
        ///<summary>
        ///Ukraine
        ///</summary>
        UA,
        ///<summary>
        ///Uganda
        ///</summary>
        UG,
        ///<summary>
        ///United States Minor Outlying Islands
        ///</summary>
        UM,
        ///<summary>
        ///United States of America
        ///</summary>
        US,
        ///<summary>
        ///Uruguay
        ///</summary>
        UY,
        ///<summary>
        ///Uzbekistan
        ///</summary>
        UZ,
        ///<summary>
        ///Vatican City
        ///</summary>
        VA,
        ///<summary>
        ///Saint Vincent and the Grenadines
        ///</summary>
        VC,
        ///<summary>
        ///Venezuela
        ///</summary>
        VE,
        ///<summary>
        ///British Virgin Islands
        ///</summary>
        VG,
        ///<summary>
        ///U.S. Virgin Islands
        ///</summary>
        VI,
        ///<summary>
        ///Vietnam
        ///</summary>
        VN,
        ///<summary>
        ///Vanuatu
        ///</summary>
        VU,
        ///<summary>
        ///Wallis and Futuna
        ///</summary>
        WF,
        ///<summary>
        ///Samoa
        ///</summary>
        WS,
        ///<summary>
        ///Yemen
        ///</summary>
        YE,
        ///<summary>
        ///Mayotte
        ///</summary>
        YT,
        ///<summary>
        ///South Africa
        ///</summary>
        ZA,
        ///<summary>
        ///Zambia
        ///</summary>
        ZM,
        ///<summary>
        ///Zimbabwe
        ///</summary>
        ZW,
        ///<summary>
        ///Unknown
        ///</summary>
        ZZ,
    }

    ///<summary>
    ///Indicates the country associated with another entity, such as a business.
    ///Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
    ///</summary>
    public enum CountryCode
    {
        ///<summary>
        ///Andorra
        ///</summary>
        AD,
        ///<summary>
        ///United Arab Emirates
        ///</summary>
        AE,
        ///<summary>
        ///Afghanistan
        ///</summary>
        AF,
        ///<summary>
        ///Antigua and Barbuda
        ///</summary>
        AG,
        ///<summary>
        ///Anguilla
        ///</summary>
        AI,
        ///<summary>
        ///Albania
        ///</summary>
        AL,
        ///<summary>
        ///Armenia
        ///</summary>
        AM,
        ///<summary>
        ///Angola
        ///</summary>
        AO,
        ///<summary>
        ///Antartica
        ///</summary>
        AQ,
        ///<summary>
        ///Argentina
        ///</summary>
        AR,
        ///<summary>
        ///American Samoa
        ///</summary>
        AS,
        ///<summary>
        ///Austria
        ///</summary>
        AT,
        ///<summary>
        ///Australia
        ///</summary>
        AU,
        ///<summary>
        ///Aruba
        ///</summary>
        AW,
        ///<summary>
        ///Åland Islands
        ///</summary>
        AX,
        ///<summary>
        ///Azerbaijan
        ///</summary>
        AZ,
        ///<summary>
        ///Bosnia and Herzegovina
        ///</summary>
        BA,
        ///<summary>
        ///Barbados
        ///</summary>
        BB,
        ///<summary>
        ///Bangladesh
        ///</summary>
        BD,
        ///<summary>
        ///Belgium
        ///</summary>
        BE,
        ///<summary>
        ///Burkina Faso
        ///</summary>
        BF,
        ///<summary>
        ///Bulgaria
        ///</summary>
        BG,
        ///<summary>
        ///Bahrain
        ///</summary>
        BH,
        ///<summary>
        ///Burundi
        ///</summary>
        BI,
        ///<summary>
        ///Benin
        ///</summary>
        BJ,
        ///<summary>
        ///Saint Barthélemy
        ///</summary>
        BL,
        ///<summary>
        ///Bermuda
        ///</summary>
        BM,
        ///<summary>
        ///Brunei
        ///</summary>
        BN,
        ///<summary>
        ///Bolivia
        ///</summary>
        BO,
        ///<summary>
        ///Bonaire
        ///</summary>
        BQ,
        ///<summary>
        ///Brazil
        ///</summary>
        BR,
        ///<summary>
        ///Bahamas
        ///</summary>
        BS,
        ///<summary>
        ///Bhutan
        ///</summary>
        BT,
        ///<summary>
        ///Bouvet Island
        ///</summary>
        BV,
        ///<summary>
        ///Botswana
        ///</summary>
        BW,
        ///<summary>
        ///Belarus
        ///</summary>
        BY,
        ///<summary>
        ///Belize
        ///</summary>
        BZ,
        ///<summary>
        ///Canada
        ///</summary>
        CA,
        ///<summary>
        ///Cocos Islands
        ///</summary>
        CC,
        ///<summary>
        ///Democratic Republic of the Congo
        ///</summary>
        CD,
        ///<summary>
        ///Central African Republic
        ///</summary>
        CF,
        ///<summary>
        ///Congo
        ///</summary>
        CG,
        ///<summary>
        ///Switzerland
        ///</summary>
        CH,
        ///<summary>
        ///Ivory Coast
        ///</summary>
        CI,
        ///<summary>
        ///Cook Islands
        ///</summary>
        CK,
        ///<summary>
        ///Chile
        ///</summary>
        CL,
        ///<summary>
        ///Cameroon
        ///</summary>
        CM,
        ///<summary>
        ///China
        ///</summary>
        CN,
        ///<summary>
        ///Colombia
        ///</summary>
        CO,
        ///<summary>
        ///Costa Rica
        ///</summary>
        CR,
        ///<summary>
        ///Cuba
        ///</summary>
        CU,
        ///<summary>
        ///Cabo Verde
        ///</summary>
        CV,
        ///<summary>
        ///Curaçao
        ///</summary>
        CW,
        ///<summary>
        ///Christmas Island
        ///</summary>
        CX,
        ///<summary>
        ///Cyprus
        ///</summary>
        CY,
        ///<summary>
        ///Czechia
        ///</summary>
        CZ,
        ///<summary>
        ///Germany
        ///</summary>
        DE,
        ///<summary>
        ///Djibouti
        ///</summary>
        DJ,
        ///<summary>
        ///Denmark
        ///</summary>
        DK,
        ///<summary>
        ///Dominica
        ///</summary>
        DM,
        ///<summary>
        ///Dominican Republic
        ///</summary>
        DO,
        ///<summary>
        ///Algeria
        ///</summary>
        DZ,
        ///<summary>
        ///Ecuador
        ///</summary>
        EC,
        ///<summary>
        ///Estonia
        ///</summary>
        EE,
        ///<summary>
        ///Egypt
        ///</summary>
        EG,
        ///<summary>
        ///Western Sahara
        ///</summary>
        EH,
        ///<summary>
        ///Eritrea
        ///</summary>
        ER,
        ///<summary>
        ///Spain
        ///</summary>
        ES,
        ///<summary>
        ///Ethiopia
        ///</summary>
        ET,
        ///<summary>
        ///Finland
        ///</summary>
        FI,
        ///<summary>
        ///Fiji
        ///</summary>
        FJ,
        ///<summary>
        ///Falkland Islands
        ///</summary>
        FK,
        ///<summary>
        ///Federated States of Micronesia
        ///</summary>
        FM,
        ///<summary>
        ///Faroe Islands
        ///</summary>
        FO,
        ///<summary>
        ///France
        ///</summary>
        FR,
        ///<summary>
        ///Gabon
        ///</summary>
        GA,
        ///<summary>
        ///United Kingdom
        ///</summary>
        GB,
        ///<summary>
        ///Grenada
        ///</summary>
        GD,
        ///<summary>
        ///Georgia
        ///</summary>
        GE,
        ///<summary>
        ///French Guiana
        ///</summary>
        GF,
        ///<summary>
        ///Guernsey
        ///</summary>
        GG,
        ///<summary>
        ///Ghana
        ///</summary>
        GH,
        ///<summary>
        ///Gibraltar
        ///</summary>
        GI,
        ///<summary>
        ///Greenland
        ///</summary>
        GL,
        ///<summary>
        ///Gambia
        ///</summary>
        GM,
        ///<summary>
        ///Guinea
        ///</summary>
        GN,
        ///<summary>
        ///Guadeloupe
        ///</summary>
        GP,
        ///<summary>
        ///Equatorial Guinea
        ///</summary>
        GQ,
        ///<summary>
        ///Greece
        ///</summary>
        GR,
        ///<summary>
        ///South Georgia and the South Sandwich Islands
        ///</summary>
        GS,
        ///<summary>
        ///Guatemala
        ///</summary>
        GT,
        ///<summary>
        ///Guam
        ///</summary>
        GU,
        ///<summary>
        ///Guinea-Bissau
        ///</summary>
        GW,
        ///<summary>
        ///Guyana
        ///</summary>
        GY,
        ///<summary>
        ///Hong Kong
        ///</summary>
        HK,
        ///<summary>
        ///Heard Island and McDonald Islands
        ///</summary>
        HM,
        ///<summary>
        ///Honduras
        ///</summary>
        HN,
        ///<summary>
        ///Croatia
        ///</summary>
        HR,
        ///<summary>
        ///Haiti
        ///</summary>
        HT,
        ///<summary>
        ///Hungary
        ///</summary>
        HU,
        ///<summary>
        ///Indonesia
        ///</summary>
        ID,
        ///<summary>
        ///Ireland
        ///</summary>
        IE,
        ///<summary>
        ///Israel
        ///</summary>
        IL,
        ///<summary>
        ///Isle of Man
        ///</summary>
        IM,
        ///<summary>
        ///India
        ///</summary>
        IN,
        ///<summary>
        ///British Indian Ocean Territory
        ///</summary>
        IO,
        ///<summary>
        ///Iraq
        ///</summary>
        IQ,
        ///<summary>
        ///Iran
        ///</summary>
        IR,
        ///<summary>
        ///Iceland
        ///</summary>
        IS,
        ///<summary>
        ///Italy
        ///</summary>
        IT,
        ///<summary>
        ///Jersey
        ///</summary>
        JE,
        ///<summary>
        ///Jamaica
        ///</summary>
        JM,
        ///<summary>
        ///Jordan
        ///</summary>
        JO,
        ///<summary>
        ///Japan
        ///</summary>
        JP,
        ///<summary>
        ///Kenya
        ///</summary>
        KE,
        ///<summary>
        ///Kyrgyzstan
        ///</summary>
        KG,
        ///<summary>
        ///Cambodia
        ///</summary>
        KH,
        ///<summary>
        ///Kiribati
        ///</summary>
        KI,
        ///<summary>
        ///Comoros
        ///</summary>
        KM,
        ///<summary>
        ///Saint Kitts and Nevis
        ///</summary>
        KN,
        ///<summary>
        ///Democratic People's Republic of Korea
        ///</summary>
        KP,
        ///<summary>
        ///Republic of Korea
        ///</summary>
        KR,
        ///<summary>
        ///Kuwait
        ///</summary>
        KW,
        ///<summary>
        ///Cayman Islands
        ///</summary>
        KY,
        ///<summary>
        ///Kazakhstan
        ///</summary>
        KZ,
        ///<summary>
        ///Lao People's Democratic Republic
        ///</summary>
        LA,
        ///<summary>
        ///Lebanon
        ///</summary>
        LB,
        ///<summary>
        ///Saint Lucia
        ///</summary>
        LC,
        ///<summary>
        ///Liechtenstein
        ///</summary>
        LI,
        ///<summary>
        ///Sri Lanka
        ///</summary>
        LK,
        ///<summary>
        ///Liberia
        ///</summary>
        LR,
        ///<summary>
        ///Lesotho
        ///</summary>
        LS,
        ///<summary>
        ///Lithuania
        ///</summary>
        LT,
        ///<summary>
        ///Luxembourg
        ///</summary>
        LU,
        ///<summary>
        ///Latvia
        ///</summary>
        LV,
        ///<summary>
        ///Libya
        ///</summary>
        LY,
        ///<summary>
        ///Morocco
        ///</summary>
        MA,
        ///<summary>
        ///Monaco
        ///</summary>
        MC,
        ///<summary>
        ///Moldova
        ///</summary>
        MD,
        ///<summary>
        ///Montenegro
        ///</summary>
        ME,
        ///<summary>
        ///Saint Martin
        ///</summary>
        MF,
        ///<summary>
        ///Madagascar
        ///</summary>
        MG,
        ///<summary>
        ///Marshall Islands
        ///</summary>
        MH,
        ///<summary>
        ///North Macedonia
        ///</summary>
        MK,
        ///<summary>
        ///Mali
        ///</summary>
        ML,
        ///<summary>
        ///Myanmar
        ///</summary>
        MM,
        ///<summary>
        ///Mongolia
        ///</summary>
        MN,
        ///<summary>
        ///Macao
        ///</summary>
        MO,
        ///<summary>
        ///Northern Mariana Islands
        ///</summary>
        MP,
        ///<summary>
        ///Martinique
        ///</summary>
        MQ,
        ///<summary>
        ///Mauritania
        ///</summary>
        MR,
        ///<summary>
        ///Montserrat
        ///</summary>
        MS,
        ///<summary>
        ///Malta
        ///</summary>
        MT,
        ///<summary>
        ///Mauritius
        ///</summary>
        MU,
        ///<summary>
        ///Maldives
        ///</summary>
        MV,
        ///<summary>
        ///Malawi
        ///</summary>
        MW,
        ///<summary>
        ///Mexico
        ///</summary>
        MX,
        ///<summary>
        ///Malaysia
        ///</summary>
        MY,
        ///<summary>
        ///Mozambique
        ///</summary>
        MZ,
        ///<summary>
        ///Namibia
        ///</summary>
        NA,
        ///<summary>
        ///New Caledonia
        ///</summary>
        NC,
        ///<summary>
        ///Niger
        ///</summary>
        NE,
        ///<summary>
        ///Norfolk Island
        ///</summary>
        NF,
        ///<summary>
        ///Nigeria
        ///</summary>
        NG,
        ///<summary>
        ///Nicaragua
        ///</summary>
        NI,
        ///<summary>
        ///Netherlands
        ///</summary>
        NL,
        ///<summary>
        ///Norway
        ///</summary>
        NO,
        ///<summary>
        ///Nepal
        ///</summary>
        NP,
        ///<summary>
        ///Nauru
        ///</summary>
        NR,
        ///<summary>
        ///Niue
        ///</summary>
        NU,
        ///<summary>
        ///New Zealand
        ///</summary>
        NZ,
        ///<summary>
        ///Oman
        ///</summary>
        OM,
        ///<summary>
        ///Panama
        ///</summary>
        PA,
        ///<summary>
        ///Peru
        ///</summary>
        PE,
        ///<summary>
        ///French Polynesia
        ///</summary>
        PF,
        ///<summary>
        ///Papua New Guinea
        ///</summary>
        PG,
        ///<summary>
        ///Philippines
        ///</summary>
        PH,
        ///<summary>
        ///Pakistan
        ///</summary>
        PK,
        ///<summary>
        ///Poland
        ///</summary>
        PL,
        ///<summary>
        ///Saint Pierre and Miquelon
        ///</summary>
        PM,
        ///<summary>
        ///Pitcairn
        ///</summary>
        PN,
        ///<summary>
        ///Puerto Rico
        ///</summary>
        PR,
        ///<summary>
        ///Palestine
        ///</summary>
        PS,
        ///<summary>
        ///Portugal
        ///</summary>
        PT,
        ///<summary>
        ///Palau
        ///</summary>
        PW,
        ///<summary>
        ///Paraguay
        ///</summary>
        PY,
        ///<summary>
        ///Qatar
        ///</summary>
        QA,
        ///<summary>
        ///Réunion
        ///</summary>
        RE,
        ///<summary>
        ///Romania
        ///</summary>
        RO,
        ///<summary>
        ///Serbia
        ///</summary>
        RS,
        ///<summary>
        ///Russia
        ///</summary>
        RU,
        ///<summary>
        ///Rwanda
        ///</summary>
        RW,
        ///<summary>
        ///Saudi Arabia
        ///</summary>
        SA,
        ///<summary>
        ///Solomon Islands
        ///</summary>
        SB,
        ///<summary>
        ///Seychelles
        ///</summary>
        SC,
        ///<summary>
        ///Sudan
        ///</summary>
        SD,
        ///<summary>
        ///Sweden
        ///</summary>
        SE,
        ///<summary>
        ///Singapore
        ///</summary>
        SG,
        ///<summary>
        ///Saint Helena, Ascension and Tristan da Cunha
        ///</summary>
        SH,
        ///<summary>
        ///Slovenia
        ///</summary>
        SI,
        ///<summary>
        ///Svalbard and Jan Mayen
        ///</summary>
        SJ,
        ///<summary>
        ///Slovakia
        ///</summary>
        SK,
        ///<summary>
        ///Sierra Leone
        ///</summary>
        SL,
        ///<summary>
        ///San Marino
        ///</summary>
        SM,
        ///<summary>
        ///Senegal
        ///</summary>
        SN,
        ///<summary>
        ///Somalia
        ///</summary>
        SO,
        ///<summary>
        ///Suriname
        ///</summary>
        SR,
        ///<summary>
        ///South Sudan
        ///</summary>
        SS,
        ///<summary>
        ///Sao Tome and Principe
        ///</summary>
        ST,
        ///<summary>
        ///El Salvador
        ///</summary>
        SV,
        ///<summary>
        ///Sint Maarten
        ///</summary>
        SX,
        ///<summary>
        ///Syrian Arab Republic
        ///</summary>
        SY,
        ///<summary>
        ///Eswatini
        ///</summary>
        SZ,
        ///<summary>
        ///Turks and Caicos Islands
        ///</summary>
        TC,
        ///<summary>
        ///Chad
        ///</summary>
        TD,
        ///<summary>
        ///French Southern Territories
        ///</summary>
        TF,
        ///<summary>
        ///Togo
        ///</summary>
        TG,
        ///<summary>
        ///Thailand
        ///</summary>
        TH,
        ///<summary>
        ///Tajikistan
        ///</summary>
        TJ,
        ///<summary>
        ///Tokelau
        ///</summary>
        TK,
        ///<summary>
        ///Timor-Leste
        ///</summary>
        TL,
        ///<summary>
        ///Turkmenistan
        ///</summary>
        TM,
        ///<summary>
        ///Tunisia
        ///</summary>
        TN,
        ///<summary>
        ///Tonga
        ///</summary>
        TO,
        ///<summary>
        ///Turkey
        ///</summary>
        TR,
        ///<summary>
        ///Trinidad and Tobago
        ///</summary>
        TT,
        ///<summary>
        ///Tuvalu
        ///</summary>
        TV,
        ///<summary>
        ///Taiwan
        ///</summary>
        TW,
        ///<summary>
        ///Tanzania
        ///</summary>
        TZ,
        ///<summary>
        ///Ukraine
        ///</summary>
        UA,
        ///<summary>
        ///Uganda
        ///</summary>
        UG,
        ///<summary>
        ///United States Minor Outlying Islands
        ///</summary>
        UM,
        ///<summary>
        ///United States of America
        ///</summary>
        US,
        ///<summary>
        ///Uruguay
        ///</summary>
        UY,
        ///<summary>
        ///Uzbekistan
        ///</summary>
        UZ,
        ///<summary>
        ///Vatican City
        ///</summary>
        VA,
        ///<summary>
        ///Saint Vincent and the Grenadines
        ///</summary>
        VC,
        ///<summary>
        ///Venezuela
        ///</summary>
        VE,
        ///<summary>
        ///British Virgin Islands
        ///</summary>
        VG,
        ///<summary>
        ///U.S. Virgin Islands
        ///</summary>
        VI,
        ///<summary>
        ///Vietnam
        ///</summary>
        VN,
        ///<summary>
        ///Vanuatu
        ///</summary>
        VU,
        ///<summary>
        ///Wallis and Futuna
        ///</summary>
        WF,
        ///<summary>
        ///Samoa
        ///</summary>
        WS,
        ///<summary>
        ///Test country.
        ///</summary>
        XT,
        ///<summary>
        ///Yemen
        ///</summary>
        YE,
        ///<summary>
        ///Mayotte
        ///</summary>
        YT,
        ///<summary>
        ///South Africa
        ///</summary>
        ZA,
        ///<summary>
        ///Zambia
        ///</summary>
        ZM,
        ///<summary>
        ///Zimbabwe
        ///</summary>
        ZW,
        ///<summary>
        ///Unknown
        ///</summary>
        ZZ,
    }

    ///<summary>
    ///Indicates the associated currency for an amount of money.
    ///
    ///Values correspond to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).
    ///</summary>
    public enum Currency
    {
        ///<summary>
        ///United Arab Emirates dirham
        ///</summary>
        AED,
        ///<summary>
        ///Afghan afghani
        ///</summary>
        AFN,
        ///<summary>
        ///Albanian lek
        ///</summary>
        ALL,
        ///<summary>
        ///Armenian dram
        ///</summary>
        AMD,
        ///<summary>
        ///Netherlands Antillean guilder
        ///</summary>
        ANG,
        ///<summary>
        ///Angolan kwanza
        ///</summary>
        AOA,
        ///<summary>
        ///Argentine peso
        ///</summary>
        ARS,
        ///<summary>
        ///Australian dollar
        ///</summary>
        AUD,
        ///<summary>
        ///Aruban florin
        ///</summary>
        AWG,
        ///<summary>
        ///Azerbaijani manat
        ///</summary>
        AZN,
        ///<summary>
        ///Bosnia and Herzegovina convertible mark
        ///</summary>
        BAM,
        ///<summary>
        ///Barbados dollar
        ///</summary>
        BBD,
        ///<summary>
        ///Bangladeshi taka
        ///</summary>
        BDT,
        ///<summary>
        ///Bulgarian lev
        ///</summary>
        BGN,
        ///<summary>
        ///Bahraini dinar
        ///</summary>
        BHD,
        ///<summary>
        ///Burundian franc
        ///</summary>
        BIF,
        ///<summary>
        ///Bermudian dollar
        ///</summary>
        BMD,
        ///<summary>
        ///Brunei dollar
        ///</summary>
        BND,
        ///<summary>
        ///Boliviano
        ///</summary>
        BOB,
        ///<summary>
        ///Bolivian Mvdol
        ///</summary>
        BOV,
        ///<summary>
        ///Brazilian real
        ///</summary>
        BRL,
        ///<summary>
        ///Bahamian dollar
        ///</summary>
        BSD,
        ///<summary>
        ///Bitcoin
        ///</summary>
        BTC,
        ///<summary>
        ///Bhutanese ngultrum
        ///</summary>
        BTN,
        ///<summary>
        ///Botswana pula
        ///</summary>
        BWP,
        ///<summary>
        ///Belarusian ruble
        ///</summary>
        BYR,
        ///<summary>
        ///Belize dollar
        ///</summary>
        BZD,
        ///<summary>
        ///Canadian dollar
        ///</summary>
        CAD,
        ///<summary>
        ///Congolese franc
        ///</summary>
        CDF,
        ///<summary>
        ///WIR Euro
        ///</summary>
        CHE,
        ///<summary>
        ///Swiss franc
        ///</summary>
        CHF,
        ///<summary>
        ///WIR Franc
        ///</summary>
        CHW,
        ///<summary>
        ///Unidad de Fomento
        ///</summary>
        CLF,
        ///<summary>
        ///Chilean peso
        ///</summary>
        CLP,
        ///<summary>
        ///Chinese yuan
        ///</summary>
        CNY,
        ///<summary>
        ///Colombian peso
        ///</summary>
        COP,
        ///<summary>
        ///Unidad de Valor Real
        ///</summary>
        COU,
        ///<summary>
        ///Costa Rican colon
        ///</summary>
        CRC,
        ///<summary>
        ///Cuban convertible peso
        ///</summary>
        CUC,
        ///<summary>
        ///Cuban peso
        ///</summary>
        CUP,
        ///<summary>
        ///Cape Verdean escudo
        ///</summary>
        CVE,
        ///<summary>
        ///Czech koruna
        ///</summary>
        CZK,
        ///<summary>
        ///Djiboutian franc
        ///</summary>
        DJF,
        ///<summary>
        ///Danish krone
        ///</summary>
        DKK,
        ///<summary>
        ///Dominican peso
        ///</summary>
        DOP,
        ///<summary>
        ///Algerian dinar
        ///</summary>
        DZD,
        ///<summary>
        ///Egyptian pound
        ///</summary>
        EGP,
        ///<summary>
        ///Eritrean nakfa
        ///</summary>
        ERN,
        ///<summary>
        ///Ethiopian birr
        ///</summary>
        ETB,
        ///<summary>
        ///Euro
        ///</summary>
        EUR,
        ///<summary>
        ///Fiji dollar
        ///</summary>
        FJD,
        ///<summary>
        ///Falkland Islands pound
        ///</summary>
        FKP,
        ///<summary>
        ///Pound sterling
        ///</summary>
        GBP,
        ///<summary>
        ///Georgian lari
        ///</summary>
        GEL,
        ///<summary>
        ///Ghanaian cedi
        ///</summary>
        GHS,
        ///<summary>
        ///Gibraltar pound
        ///</summary>
        GIP,
        ///<summary>
        ///Gambian dalasi
        ///</summary>
        GMD,
        ///<summary>
        ///Guinean franc
        ///</summary>
        GNF,
        ///<summary>
        ///Guatemalan quetzal
        ///</summary>
        GTQ,
        ///<summary>
        ///Guyanese dollar
        ///</summary>
        GYD,
        ///<summary>
        ///Hong Kong dollar
        ///</summary>
        HKD,
        ///<summary>
        ///Honduran lempira
        ///</summary>
        HNL,
        ///<summary>
        ///Croatian kuna
        ///</summary>
        HRK,
        ///<summary>
        ///Haitian gourde
        ///</summary>
        HTG,
        ///<summary>
        ///Hungarian forint
        ///</summary>
        HUF,
        ///<summary>
        ///Indonesian rupiah
        ///</summary>
        IDR,
        ///<summary>
        ///Israeli new shekel
        ///</summary>
        ILS,
        ///<summary>
        ///Indian rupee
        ///</summary>
        INR,
        ///<summary>
        ///Iraqi dinar
        ///</summary>
        IQD,
        ///<summary>
        ///Iranian rial
        ///</summary>
        IRR,
        ///<summary>
        ///Icelandic króna
        ///</summary>
        ISK,
        ///<summary>
        ///Jamaican dollar
        ///</summary>
        JMD,
        ///<summary>
        ///Jordanian dinar
        ///</summary>
        JOD,
        ///<summary>
        ///Japanese yen
        ///</summary>
        JPY,
        ///<summary>
        ///Kenyan shilling
        ///</summary>
        KES,
        ///<summary>
        ///Kyrgyzstani som
        ///</summary>
        KGS,
        ///<summary>
        ///Cambodian riel
        ///</summary>
        KHR,
        ///<summary>
        ///Comoro franc
        ///</summary>
        KMF,
        ///<summary>
        ///North Korean won
        ///</summary>
        KPW,
        ///<summary>
        ///South Korean won
        ///</summary>
        KRW,
        ///<summary>
        ///Kuwaiti dinar
        ///</summary>
        KWD,
        ///<summary>
        ///Cayman Islands dollar
        ///</summary>
        KYD,
        ///<summary>
        ///Kazakhstani tenge
        ///</summary>
        KZT,
        ///<summary>
        ///Lao kip
        ///</summary>
        LAK,
        ///<summary>
        ///Lebanese pound
        ///</summary>
        LBP,
        ///<summary>
        ///Sri Lankan rupee
        ///</summary>
        LKR,
        ///<summary>
        ///Liberian dollar
        ///</summary>
        LRD,
        ///<summary>
        ///Lesotho loti
        ///</summary>
        LSL,
        ///<summary>
        ///Lithuanian litas
        ///</summary>
        LTL,
        ///<summary>
        ///Latvian lats
        ///</summary>
        LVL,
        ///<summary>
        ///Libyan dinar
        ///</summary>
        LYD,
        ///<summary>
        ///Moroccan dirham
        ///</summary>
        MAD,
        ///<summary>
        ///Moldovan leu
        ///</summary>
        MDL,
        ///<summary>
        ///Malagasy ariary
        ///</summary>
        MGA,
        ///<summary>
        ///Macedonian denar
        ///</summary>
        MKD,
        ///<summary>
        ///Myanmar kyat
        ///</summary>
        MMK,
        ///<summary>
        ///Mongolian tögrög
        ///</summary>
        MNT,
        ///<summary>
        ///Macanese pataca
        ///</summary>
        MOP,
        ///<summary>
        ///Mauritanian ouguiya
        ///</summary>
        MRO,
        ///<summary>
        ///Mauritian rupee
        ///</summary>
        MUR,
        ///<summary>
        ///Maldivian rufiyaa
        ///</summary>
        MVR,
        ///<summary>
        ///Malawian kwacha
        ///</summary>
        MWK,
        ///<summary>
        ///Mexican peso
        ///</summary>
        MXN,
        ///<summary>
        ///Mexican Unidad de Inversion
        ///</summary>
        MXV,
        ///<summary>
        ///Malaysian ringgit
        ///</summary>
        MYR,
        ///<summary>
        ///Mozambican metical
        ///</summary>
        MZN,
        ///<summary>
        ///Namibian dollar
        ///</summary>
        NAD,
        ///<summary>
        ///Nigerian naira
        ///</summary>
        NGN,
        ///<summary>
        ///Nicaraguan córdoba
        ///</summary>
        NIO,
        ///<summary>
        ///Norwegian krone
        ///</summary>
        NOK,
        ///<summary>
        ///Nepalese rupee
        ///</summary>
        NPR,
        ///<summary>
        ///New Zealand dollar
        ///</summary>
        NZD,
        ///<summary>
        ///Omani rial
        ///</summary>
        OMR,
        ///<summary>
        ///Panamanian balboa
        ///</summary>
        PAB,
        ///<summary>
        ///Peruvian sol
        ///</summary>
        PEN,
        ///<summary>
        ///Papua New Guinean kina
        ///</summary>
        PGK,
        ///<summary>
        ///Philippine peso
        ///</summary>
        PHP,
        ///<summary>
        ///Pakistani rupee
        ///</summary>
        PKR,
        ///<summary>
        ///Polish złoty
        ///</summary>
        PLN,
        ///<summary>
        ///Paraguayan guaraní
        ///</summary>
        PYG,
        ///<summary>
        ///Qatari riyal
        ///</summary>
        QAR,
        ///<summary>
        ///Romanian leu
        ///</summary>
        RON,
        ///<summary>
        ///Serbian dinar
        ///</summary>
        RSD,
        ///<summary>
        ///Russian ruble
        ///</summary>
        RUB,
        ///<summary>
        ///Rwandan franc
        ///</summary>
        RWF,
        ///<summary>
        ///Saudi riyal
        ///</summary>
        SAR,
        ///<summary>
        ///Solomon Islands dollar
        ///</summary>
        SBD,
        ///<summary>
        ///Seychelles rupee
        ///</summary>
        SCR,
        ///<summary>
        ///Sudanese pound
        ///</summary>
        SDG,
        ///<summary>
        ///Swedish krona
        ///</summary>
        SEK,
        ///<summary>
        ///Singapore dollar
        ///</summary>
        SGD,
        ///<summary>
        ///Saint Helena pound
        ///</summary>
        SHP,
        ///<summary>
        ///Sierra Leonean leone
        ///</summary>
        SLL,
        ///<summary>
        ///Somali shilling
        ///</summary>
        SOS,
        ///<summary>
        ///Surinamese dollar
        ///</summary>
        SRD,
        ///<summary>
        ///South Sudanese pound
        ///</summary>
        SSP,
        ///<summary>
        ///São Tomé and Príncipe dobra
        ///</summary>
        STD,
        ///<summary>
        ///Salvadoran colón
        ///</summary>
        SVC,
        ///<summary>
        ///Syrian pound
        ///</summary>
        SYP,
        ///<summary>
        ///Swazi lilangeni
        ///</summary>
        SZL,
        ///<summary>
        ///Thai baht
        ///</summary>
        THB,
        ///<summary>
        ///Tajikstani somoni
        ///</summary>
        TJS,
        ///<summary>
        ///Turkmenistan manat
        ///</summary>
        TMT,
        ///<summary>
        ///Tunisian dinar
        ///</summary>
        TND,
        ///<summary>
        ///Tongan pa'anga
        ///</summary>
        TOP,
        ///<summary>
        ///Turkish lira
        ///</summary>
        TRY,
        ///<summary>
        ///Trinidad and Tobago dollar
        ///</summary>
        TTD,
        ///<summary>
        ///New Taiwan dollar
        ///</summary>
        TWD,
        ///<summary>
        ///Tanzanian shilling
        ///</summary>
        TZS,
        ///<summary>
        ///Ukrainian hryvnia
        ///</summary>
        UAH,
        ///<summary>
        ///Ugandan shilling
        ///</summary>
        UGX,
        ///<summary>
        ///Unknown currency
        ///</summary>
        UNKNOWN_CURRENCY,
        ///<summary>
        ///United States dollar
        ///</summary>
        USD,
        ///<summary>
        ///United States dollar (next day)
        ///</summary>
        USN,
        ///<summary>
        ///United States dollar (same day)
        ///</summary>
        USS,
        ///<summary>
        ///Uruguay Peso en Unidedades Indexadas
        ///</summary>
        UYI,
        ///<summary>
        ///Uruguyan peso
        ///</summary>
        UYU,
        ///<summary>
        ///Uzbekistan som
        ///</summary>
        UZS,
        ///<summary>
        ///Venezuelan bolívar soberano
        ///</summary>
        VEF,
        ///<summary>
        ///Vietnamese đồng
        ///</summary>
        VND,
        ///<summary>
        ///Vanuatu vatu
        ///</summary>
        VUV,
        ///<summary>
        ///Samoan tala
        ///</summary>
        WST,
        ///<summary>
        ///CFA franc BEAC
        ///</summary>
        XAF,
        ///<summary>
        ///Silver
        ///</summary>
        XAG,
        ///<summary>
        ///Gold
        ///</summary>
        XAU,
        ///<summary>
        ///European Composite Unit
        ///</summary>
        XBA,
        ///<summary>
        ///European Monetary Unit
        ///</summary>
        XBB,
        ///<summary>
        ///European Unit of Account 9
        ///</summary>
        XBC,
        ///<summary>
        ///European Unit of Account 17
        ///</summary>
        XBD,
        ///<summary>
        ///East Caribbean dollar
        ///</summary>
        XCD,
        ///<summary>
        ///Special drawing rights (International Monetary Fund)
        ///</summary>
        XDR,
        ///<summary>
        ///CFA franc BCEAO
        ///</summary>
        XOF,
        ///<summary>
        ///Palladium
        ///</summary>
        XPD,
        ///<summary>
        ///CFP franc
        ///</summary>
        XPF,
        ///<summary>
        ///Platinum
        ///</summary>
        XPT,
        ///<summary>
        ///Code reserved for testing
        ///</summary>
        XTS,
        ///<summary>
        ///USD Coin
        ///</summary>
        XUS,
        ///<summary>
        ///No currency
        ///</summary>
        XXX,
        ///<summary>
        ///Yemeni rial
        ///</summary>
        YER,
        ///<summary>
        ///South African rand
        ///</summary>
        ZAR,
        ///<summary>
        ///Zambian kwacha
        ///</summary>
        ZMK,
        ///<summary>
        ///Zambian kwacha
        ///</summary>
        ZMW,
    }

    ///<summary>
    ///Indicates the associated currency for an amount of money. Values correspond to
    ///[ISO 4217](https://wikipedia.org/wiki/ISO_4217), with the exception of BTC (Bitcoin).
    ///</summary>
    public enum CurrencyCode
    {
        ///<summary>
        ///United Arab Emirates dirham
        ///</summary>
        AED,
        ///<summary>
        ///Afghan afghani
        ///</summary>
        AFN,
        ///<summary>
        ///Albanian lek
        ///</summary>
        ALL,
        ///<summary>
        ///Armenian dram
        ///</summary>
        AMD,
        ///<summary>
        ///Netherlands Antillean guilder
        ///</summary>
        ANG,
        ///<summary>
        ///Angolan kwanza
        ///</summary>
        AOA,
        ///<summary>
        ///Argentine peso
        ///</summary>
        ARS,
        ///<summary>
        ///Australian dollar
        ///</summary>
        AUD,
        ///<summary>
        ///Aruban florin
        ///</summary>
        AWG,
        ///<summary>
        ///Azerbaijani manat
        ///</summary>
        AZN,
        ///<summary>
        ///Bosnia and Herzegovina convertible mark
        ///</summary>
        BAM,
        ///<summary>
        ///Barbados dollar
        ///</summary>
        BBD,
        ///<summary>
        ///Bangladeshi taka
        ///</summary>
        BDT,
        ///<summary>
        ///Bulgarian lev
        ///</summary>
        BGN,
        ///<summary>
        ///Bahraini dinar
        ///</summary>
        BHD,
        ///<summary>
        ///Burundian franc
        ///</summary>
        BIF,
        ///<summary>
        ///Bermudian dollar
        ///</summary>
        BMD,
        ///<summary>
        ///Brunei dollar
        ///</summary>
        BND,
        ///<summary>
        ///Boliviano
        ///</summary>
        BOB,
        ///<summary>
        ///Bolivian Mvdol
        ///</summary>
        BOV,
        ///<summary>
        ///Brazilian real
        ///</summary>
        BRL,
        ///<summary>
        ///Bahamian dollar
        ///</summary>
        BSD,
        ///<summary>
        ///Bitcoin
        ///</summary>
        BTC,
        ///<summary>
        ///Bhutanese ngultrum
        ///</summary>
        BTN,
        ///<summary>
        ///Botswana pula
        ///</summary>
        BWP,
        ///<summary>
        ///Belarusian ruble
        ///</summary>
        BYR,
        ///<summary>
        ///Belize dollar
        ///</summary>
        BZD,
        ///<summary>
        ///Canadian dollar
        ///</summary>
        CAD,
        ///<summary>
        ///Congolese franc
        ///</summary>
        CDF,
        ///<summary>
        ///WIR Euro
        ///</summary>
        CHE,
        ///<summary>
        ///Swiss franc
        ///</summary>
        CHF,
        ///<summary>
        ///WIR Franc
        ///</summary>
        CHW,
        ///<summary>
        ///Unidad de Fomento
        ///</summary>
        CLF,
        ///<summary>
        ///Chilean peso
        ///</summary>
        CLP,
        ///<summary>
        ///Chinese yuan
        ///</summary>
        CNY,
        ///<summary>
        ///Colombian peso
        ///</summary>
        COP,
        ///<summary>
        ///Unidad de Valor Real
        ///</summary>
        COU,
        ///<summary>
        ///Costa Rican colon
        ///</summary>
        CRC,
        ///<summary>
        ///Cuban convertible peso
        ///</summary>
        CUC,
        ///<summary>
        ///Cuban peso
        ///</summary>
        CUP,
        ///<summary>
        ///Cape Verdean escudo
        ///</summary>
        CVE,
        ///<summary>
        ///Czech koruna
        ///</summary>
        CZK,
        ///<summary>
        ///Djiboutian franc
        ///</summary>
        DJF,
        ///<summary>
        ///Danish krone
        ///</summary>
        DKK,
        ///<summary>
        ///Dominican peso
        ///</summary>
        DOP,
        ///<summary>
        ///Algerian dinar
        ///</summary>
        DZD,
        ///<summary>
        ///Egyptian pound
        ///</summary>
        EGP,
        ///<summary>
        ///Eritrean nakfa
        ///</summary>
        ERN,
        ///<summary>
        ///Ethiopian birr
        ///</summary>
        ETB,
        ///<summary>
        ///Euro
        ///</summary>
        EUR,
        ///<summary>
        ///Fiji dollar
        ///</summary>
        FJD,
        ///<summary>
        ///Falkland Islands pound
        ///</summary>
        FKP,
        ///<summary>
        ///Pound sterling
        ///</summary>
        GBP,
        ///<summary>
        ///Georgian lari
        ///</summary>
        GEL,
        ///<summary>
        ///Ghanaian cedi
        ///</summary>
        GHS,
        ///<summary>
        ///Gibraltar pound
        ///</summary>
        GIP,
        ///<summary>
        ///Gambian dalasi
        ///</summary>
        GMD,
        ///<summary>
        ///Guinean franc
        ///</summary>
        GNF,
        ///<summary>
        ///Guatemalan quetzal
        ///</summary>
        GTQ,
        ///<summary>
        ///Guyanese dollar
        ///</summary>
        GYD,
        ///<summary>
        ///Hong Kong dollar
        ///</summary>
        HKD,
        ///<summary>
        ///Honduran lempira
        ///</summary>
        HNL,
        ///<summary>
        ///Croatian kuna
        ///</summary>
        HRK,
        ///<summary>
        ///Haitian gourde
        ///</summary>
        HTG,
        ///<summary>
        ///Hungarian forint
        ///</summary>
        HUF,
        ///<summary>
        ///Indonesian rupiah
        ///</summary>
        IDR,
        ///<summary>
        ///Israeli new shekel
        ///</summary>
        ILS,
        ///<summary>
        ///Indian rupee
        ///</summary>
        INR,
        ///<summary>
        ///Iraqi dinar
        ///</summary>
        IQD,
        ///<summary>
        ///Iranian rial
        ///</summary>
        IRR,
        ///<summary>
        ///Icelandic króna
        ///</summary>
        ISK,
        ///<summary>
        ///Jamaican dollar
        ///</summary>
        JMD,
        ///<summary>
        ///Jordanian dinar
        ///</summary>
        JOD,
        ///<summary>
        ///Japanese yen
        ///</summary>
        JPY,
        ///<summary>
        ///Kenyan shilling
        ///</summary>
        KES,
        ///<summary>
        ///Kyrgyzstani som
        ///</summary>
        KGS,
        ///<summary>
        ///Cambodian riel
        ///</summary>
        KHR,
        ///<summary>
        ///Comoro franc
        ///</summary>
        KMF,
        ///<summary>
        ///North Korean won
        ///</summary>
        KPW,
        ///<summary>
        ///South Korean won
        ///</summary>
        KRW,
        ///<summary>
        ///Kuwaiti dinar
        ///</summary>
        KWD,
        ///<summary>
        ///Cayman Islands dollar
        ///</summary>
        KYD,
        ///<summary>
        ///Kazakhstani tenge
        ///</summary>
        KZT,
        ///<summary>
        ///Lao kip
        ///</summary>
        LAK,
        ///<summary>
        ///Lebanese pound
        ///</summary>
        LBP,
        ///<summary>
        ///Sri Lankan rupee
        ///</summary>
        LKR,
        ///<summary>
        ///Liberian dollar
        ///</summary>
        LRD,
        ///<summary>
        ///Lesotho loti
        ///</summary>
        LSL,
        ///<summary>
        ///Lithuanian litas
        ///</summary>
        LTL,
        ///<summary>
        ///Latvian lats
        ///</summary>
        LVL,
        ///<summary>
        ///Libyan dinar
        ///</summary>
        LYD,
        ///<summary>
        ///Moroccan dirham
        ///</summary>
        MAD,
        ///<summary>
        ///Moldovan leu
        ///</summary>
        MDL,
        ///<summary>
        ///Malagasy ariary
        ///</summary>
        MGA,
        ///<summary>
        ///Macedonian denar
        ///</summary>
        MKD,
        ///<summary>
        ///Myanmar kyat
        ///</summary>
        MMK,
        ///<summary>
        ///Mongolian tögrög
        ///</summary>
        MNT,
        ///<summary>
        ///Macanese pataca
        ///</summary>
        MOP,
        ///<summary>
        ///Mauritanian ouguiya
        ///</summary>
        MRO,
        ///<summary>
        ///Mauritian rupee
        ///</summary>
        MUR,
        ///<summary>
        ///Maldivian rufiyaa
        ///</summary>
        MVR,
        ///<summary>
        ///Malawian kwacha
        ///</summary>
        MWK,
        ///<summary>
        ///Mexican peso
        ///</summary>
        MXN,
        ///<summary>
        ///Mexican Unidad de Inversion
        ///</summary>
        MXV,
        ///<summary>
        ///Malaysian ringgit
        ///</summary>
        MYR,
        ///<summary>
        ///Mozambican metical
        ///</summary>
        MZN,
        ///<summary>
        ///Namibian dollar
        ///</summary>
        NAD,
        ///<summary>
        ///Nigerian naira
        ///</summary>
        NGN,
        ///<summary>
        ///Nicaraguan córdoba
        ///</summary>
        NIO,
        ///<summary>
        ///Norwegian krone
        ///</summary>
        NOK,
        ///<summary>
        ///Nepalese rupee
        ///</summary>
        NPR,
        ///<summary>
        ///New Zealand dollar
        ///</summary>
        NZD,
        ///<summary>
        ///Omani rial
        ///</summary>
        OMR,
        ///<summary>
        ///Panamanian balboa
        ///</summary>
        PAB,
        ///<summary>
        ///Peruvian sol
        ///</summary>
        PEN,
        ///<summary>
        ///Papua New Guinean kina
        ///</summary>
        PGK,
        ///<summary>
        ///Philippine peso
        ///</summary>
        PHP,
        ///<summary>
        ///Pakistani rupee
        ///</summary>
        PKR,
        ///<summary>
        ///Polish złoty
        ///</summary>
        PLN,
        ///<summary>
        ///Paraguayan guaraní
        ///</summary>
        PYG,
        ///<summary>
        ///Qatari riyal
        ///</summary>
        QAR,
        ///<summary>
        ///Romanian leu
        ///</summary>
        RON,
        ///<summary>
        ///Serbian dinar
        ///</summary>
        RSD,
        ///<summary>
        ///Russian ruble
        ///</summary>
        RUB,
        ///<summary>
        ///Rwandan franc
        ///</summary>
        RWF,
        ///<summary>
        ///Saudi riyal
        ///</summary>
        SAR,
        ///<summary>
        ///Solomon Islands dollar
        ///</summary>
        SBD,
        ///<summary>
        ///Seychelles rupee
        ///</summary>
        SCR,
        ///<summary>
        ///Sudanese pound
        ///</summary>
        SDG,
        ///<summary>
        ///Swedish krona
        ///</summary>
        SEK,
        ///<summary>
        ///Singapore dollar
        ///</summary>
        SGD,
        ///<summary>
        ///Saint Helena pound
        ///</summary>
        SHP,
        ///<summary>
        ///Sierra Leonean leone
        ///</summary>
        SLL,
        ///<summary>
        ///Somali shilling
        ///</summary>
        SOS,
        ///<summary>
        ///Surinamese dollar
        ///</summary>
        SRD,
        ///<summary>
        ///South Sudanese pound
        ///</summary>
        SSP,
        ///<summary>
        ///São Tomé and Príncipe dobra
        ///</summary>
        STD,
        ///<summary>
        ///Salvadoran colón
        ///</summary>
        SVC,
        ///<summary>
        ///Syrian pound
        ///</summary>
        SYP,
        ///<summary>
        ///Swazi lilangeni
        ///</summary>
        SZL,
        ///<summary>
        ///Thai baht
        ///</summary>
        THB,
        ///<summary>
        ///Tajikstani somoni
        ///</summary>
        TJS,
        ///<summary>
        ///Turkmenistan manat
        ///</summary>
        TMT,
        ///<summary>
        ///Tunisian dinar
        ///</summary>
        TND,
        ///<summary>
        ///Tongan pa'anga
        ///</summary>
        TOP,
        ///<summary>
        ///Turkish lira
        ///</summary>
        TRY,
        ///<summary>
        ///Trinidad and Tobago dollar
        ///</summary>
        TTD,
        ///<summary>
        ///New Taiwan dollar
        ///</summary>
        TWD,
        ///<summary>
        ///Tanzanian shilling
        ///</summary>
        TZS,
        ///<summary>
        ///Ukrainian hryvnia
        ///</summary>
        UAH,
        ///<summary>
        ///Ugandan shilling
        ///</summary>
        UGX,
        ///<summary>
        ///United States dollar
        ///</summary>
        USD,
        ///<summary>
        ///United States dollar (next day)
        ///</summary>
        USN,
        ///<summary>
        ///United States dollar (same day)
        ///</summary>
        USS,
        ///<summary>
        ///Uruguay Peso en Unidedades Indexadas
        ///</summary>
        UYI,
        ///<summary>
        ///Uruguyan peso
        ///</summary>
        UYU,
        ///<summary>
        ///Uzbekistan som
        ///</summary>
        UZS,
        ///<summary>
        ///Venezuelan bolívar soberano
        ///</summary>
        VEF,
        ///<summary>
        ///Vietnamese đồng
        ///</summary>
        VND,
        ///<summary>
        ///Vanuatu vatu
        ///</summary>
        VUV,
        ///<summary>
        ///Samoan tala
        ///</summary>
        WST,
        ///<summary>
        ///CFA franc BEAC
        ///</summary>
        XAF,
        ///<summary>
        ///Silver
        ///</summary>
        XAG,
        ///<summary>
        ///Gold
        ///</summary>
        XAU,
        ///<summary>
        ///European Composite Unit
        ///</summary>
        XBA,
        ///<summary>
        ///European Monetary Unit
        ///</summary>
        XBB,
        ///<summary>
        ///European Unit of Account 9
        ///</summary>
        XBC,
        ///<summary>
        ///European Unit of Account 17
        ///</summary>
        XBD,
        ///<summary>
        ///East Caribbean dollar
        ///</summary>
        XCD,
        ///<summary>
        ///Special drawing rights (International Monetary Fund)
        ///</summary>
        XDR,
        ///<summary>
        ///CFA franc BCEAO
        ///</summary>
        XOF,
        ///<summary>
        ///Palladium
        ///</summary>
        XPD,
        ///<summary>
        ///CFP franc
        ///</summary>
        XPF,
        ///<summary>
        ///Platinum
        ///</summary>
        XPT,
        ///<summary>
        ///Code reserved for testing
        ///</summary>
        XTS,
        ///<summary>
        ///USD Coin
        ///</summary>
        XUS,
        ///<summary>
        ///No currency
        ///</summary>
        XXX,
        ///<summary>
        ///Yemeni rial
        ///</summary>
        YER,
        ///<summary>
        ///South African rand
        ///</summary>
        ZAR,
        ///<summary>
        ///Zambian kwacha
        ///</summary>
        ZMK,
        ///<summary>
        ///Zambian kwacha
        ///</summary>
        ZMW,
    }

    ///<summary>
    ///Indicates the associated currency for an amount of money.
    ///
    ///Values correspond to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).
    ///</summary>
    public enum CurrencyInput
    {
        AED,
        AFN,
        ALL,
        AMD,
        ANG,
        AOA,
        ARS,
        AUD,
        AWG,
        AZN,
        BAM,
        BBD,
        BDT,
        BGN,
        BHD,
        BIF,
        BMD,
        BND,
        BOB,
        BOV,
        BRL,
        BSD,
        BTC,
        BTN,
        BWP,
        BYR,
        BZD,
        CAD,
        CDF,
        CHE,
        CHF,
        CHW,
        CLF,
        CLP,
        CNY,
        COP,
        COU,
        CRC,
        CUC,
        CUP,
        CVE,
        CZK,
        DJF,
        DKK,
        DOP,
        DZD,
        EGP,
        ERN,
        ETB,
        EUR,
        FJD,
        FKP,
        GBP,
        GEL,
        GHS,
        GIP,
        GMD,
        GNF,
        GTQ,
        GYD,
        HKD,
        HNL,
        HRK,
        HTG,
        HUF,
        IDR,
        ILS,
        INR,
        IQD,
        IRR,
        ISK,
        JMD,
        JOD,
        JPY,
        KES,
        KGS,
        KHR,
        KMF,
        KPW,
        KRW,
        KWD,
        KYD,
        KZT,
        LAK,
        LBP,
        LKR,
        LRD,
        LSL,
        LTL,
        LVL,
        LYD,
        MAD,
        MDL,
        MGA,
        MKD,
        MMK,
        MNT,
        MOP,
        MRO,
        MUR,
        MVR,
        MWK,
        MXN,
        MXV,
        MYR,
        MZN,
        NAD,
        NGN,
        NIO,
        NOK,
        NPR,
        NZD,
        OMR,
        PAB,
        PEN,
        PGK,
        PHP,
        PKR,
        PLN,
        PYG,
        QAR,
        RON,
        RSD,
        RUB,
        RWF,
        SAR,
        SBD,
        SCR,
        SDG,
        SEK,
        SGD,
        SHP,
        SLL,
        SOS,
        SRD,
        SSP,
        STD,
        SVC,
        SYP,
        SZL,
        THB,
        TJS,
        TMT,
        TND,
        TOP,
        TRY,
        TTD,
        TWD,
        TZS,
        UAH,
        UGX,
        UNKNOWN_CURRENCY,
        USD,
        USN,
        USS,
        UYI,
        UYU,
        UZS,
        VEF,
        VND,
        VUV,
        WST,
        XAF,
        XAG,
        XAU,
        XBA,
        XBB,
        XBC,
        XBD,
        XCD,
        XDR,
        XOF,
        XPD,
        XPF,
        XPT,
        XTS,
        XUS,
        XXX,
        YER,
        ZAR,
        ZMK,
        ZMW,
    }

    ///<summary>
    ///References to Customers subgraph entities
    ///
    ///Permissions:CUSTOMERS_READ
    ///</summary>
    public class Customer : GraphQLObject<Customer>
    {
        ///<summary>
        ///A unique Square-assigned ID for the customer profile.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The physical address associated with the customer profile.
        ///</summary>
        public Address? address { get; set; }
        ///<summary>
        ///The birthday associated with the customer profile, in YYYY-MM-DD format. For example, 1998-09-21 represents September 21, 1998, and 0000-09-21 represents September 21 (without a birth year).
        ///</summary>
        public string? birthday { get; set; }
        ///<summary>
        ///A business name associated with the customer profile.
        ///</summary>
        public string? companyName { get; set; }
        ///<summary>
        ///The timestamp when the customer profile was created, in RFC 3339 format.
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///The method used to create the customer profile.
        ///</summary>
        public string? creationSource { get; set; }
        ///<summary>
        ///The email address associated with the customer profile.
        ///</summary>
        public string? emailAddress { get; set; }
        ///<summary>
        ///The family name (that is, the last name) associated with the customer profile.
        ///</summary>
        public string? familyName { get; set; }
        ///<summary>
        ///The given name (that is, the first name) associated with the customer profile.
        ///</summary>
        public string? givenName { get; set; }
        ///<summary>
        ///The IDs of customer groups the customer belongs to.
        ///</summary>
        public IEnumerable<string>? groupIds { get; set; }
        ///<summary>
        ///A nickname for the customer profile.
        ///</summary>
        public string? nickname { get; set; }
        ///<summary>
        ///A custom note associated with the customer profile.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The phone number associated with the customer profile.
        ///</summary>
        public string? phoneNumber { get; set; }
        ///<summary>
        ///Represents general customer preferences.
        ///</summary>
        public CustomerPreferences? preferences { get; set; }
        ///<summary>
        ///An optional second ID used to associate the customer profile with an entity in another system.
        ///</summary>
        public string? referenceId { get; set; }
        ///<summary>
        ///The IDs of customer segments the customer belongs to.
        ///</summary>
        public IEnumerable<string>? segmentIds { get; set; }
        ///<summary>
        ///The tax ID associated with the customer profile. This field is present only for customers of sellers in EU countries or the United Kingdom. For more information, see Customer tax IDs.
        ///</summary>
        public TaxIds? taxIds { get; set; }
        ///<summary>
        ///The timestamp when the customer profile was last updated, in RFC 3339 format.
        ///</summary>
        public DateTime? updatedAt { get; set; }
    }

    ///<summary>
    ///A list of Customer.
    ///
    ///Permissions:CUSTOMERS_READ
    ///</summary>
    public class CustomerConnection : GraphQLObject<CustomerConnection>, IConnectionWithNodes<Customer>
    {
        ///<summary>
        ///List of Customer.
        ///</summary>
        public IEnumerable<Customer>? nodes { get; set; }
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///Represents communication preferences for the customer profile.
    ///
    ///Permissions:CUSTOMERS_READ
    ///</summary>
    public class CustomerPreferences : GraphQLObject<CustomerPreferences>
    {
        ///<summary>
        ///Indicates whether the customer has unsubscribed from marketing campaign emails.
        ///A value of true means that the customer chose to opt out of email marketing from the current Square seller or from all Square sellers.
        ///This value is read-only from the Customers API.
        ///</summary>
        public bool? emailUnsubscribed { get; set; }
    }

    ///<summary>
    ///Enumeration of `DateTime` units.
    ///</summary>
    public enum DateTimeUnit
    {
        ///<summary>
        ///The time period of a full rotation of the Earth with respect to the Sun.
        ///</summary>
        DAY,
        ///<summary>
        ///1/24th of a day.
        ///</summary>
        HOUR,
        ///<summary>
        ///1/1000th of a second.
        ///</summary>
        MILLISECOND,
        ///<summary>
        ///1/60th of an hour.
        ///</summary>
        MINUTE,
        ///<summary>
        ///1/60th of a minute.
        ///</summary>
        SECOND,
    }

    ///<summary>
    ///Indicates the specific day of the week.
    ///</summary>
    public enum DayOfWeek
    {
        ///<summary>
        ///Friday
        ///</summary>
        FRI,
        ///<summary>
        ///Monday
        ///</summary>
        MON,
        ///<summary>
        ///Saturday
        ///</summary>
        SAT,
        ///<summary>
        ///Sunday
        ///</summary>
        SUN,
        ///<summary>
        ///Thursday
        ///</summary>
        THU,
        ///<summary>
        ///Tuesday
        ///</summary>
        TUE,
        ///<summary>
        ///Wednesday
        ///</summary>
        WED,
    }

    ///<summary>
    ///The brand used for a `WALLET` payment.
    ///</summary>
    public enum DigitalWalletPaymentBrand
    {
        ALIPAY,
        CASH_APP,
        PAYPAY,
        UNKNOWN,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about `WALLET` type payments. Contains only non-confidential information.
    ///</summary>
    public class DigitalWalletPaymentDetails : GraphQLObject<DigitalWalletPaymentDetails>
    {
        ///<summary>
        ///The brand used for the `WALLET` payment.
        ///</summary>
        public DigitalWalletPaymentBrand? brand { get; set; }
        ///<summary>
        ///Brand-specific details for payments with the `brand` of `CASH_APP`.
        ///</summary>
        public CashAppPaymentDetails? cashAppDetails { get; set; }
        ///<summary>
        ///The status of the `WALLET` payment.
        ///</summary>
        public DigitalWalletPaymentStatus? status { get; set; }
    }

    ///<summary>
    ///The status of a `WALLET` payment.
    ///</summary>
    public enum DigitalWalletPaymentStatus
    {
        AUTHORIZED,
        CAPTURED,
        FAILED,
        VOIDED,
    }

    ///<summary>
    ///Discount code belonging to the order.
    ///
    ///Permissions:ORDERS_READ
    ///</summary>
    public class DiscountCode : GraphQLObject<DiscountCode>
    {
        ///<summary>
        ///The identifier of the Discount Code.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The ID of the pricing rule corresponding to this discount code.
        ///</summary>
        public string? pricingRuleId { get; set; }
        ///<summary>
        ///The number of instances of the Discount Code.
        ///</summary>
        public int? quantity { get; set; }
    }

    ///<summary>
    ///Enumerates the supported distance units.
    ///</summary>
    public enum DistanceUnit
    {
        ///<summary>
        ///A metric system unit equal to 1/100th of a meter.
        ///</summary>
        CENTIMETER,
        ///<summary>
        ///A United States customary unit of 12 inches.
        ///</summary>
        FOOT,
        ///<summary>
        ///A United States customary unit equal to 1/12th of a foot.
        ///</summary>
        INCH,
        ///<summary>
        ///A metric system unit equal to 1,000 meters.
        ///</summary>
        KILOMETER,
        ///<summary>
        ///The base unit of length in the metric system.
        ///</summary>
        METER,
        ///<summary>
        ///A United States customary unit of 5,280 feet.
        ///</summary>
        MILE,
        ///<summary>
        ///A metric system unit equal to 1/1,000th of a meter.
        ///</summary>
        MILLIMETER,
        ///<summary>
        ///An international unit of length used for air, marine, and space navigation. Equivalent to 1,852 meters.
        ///</summary>
        NAUTICAL_MILE,
        ///<summary>
        ///A United States customary unit of 3 feet.
        ///</summary>
        YARD,
    }

    ///<summary>
    ///An employee object that is used by the external API.
    ///
    ///Permissions:EMPLOYEES_READ
    ///</summary>
    public class Employee : GraphQLObject<Employee>
    {
        ///<summary>
        ///The Square-issued ID of the employee.
        ///</summary>
        public string? id { get; set; }
    }

    ///<summary>
    ///Represents an error encountered during a request to the Connect API.
    ///
    ///See [Handling errors](https://developer.squareup.com/docs/build-basics/handling-errors) for more information.
    ///</summary>
    public class Error : GraphQLObject<Error>
    {
        ///<summary>
        ///The high-level category for the error.
        ///</summary>
        public ErrorCategory? category { get; set; }
        ///<summary>
        ///The specific code of the error.
        ///</summary>
        public ErrorCode? code { get; set; }
        ///<summary>
        ///A human-readable description of the error for debugging purposes.
        ///</summary>
        public string? detail { get; set; }
        ///<summary>
        ///The name of the field provided in the original request (if any) that the error pertains to.
        ///</summary>
        public string? field { get; set; }
    }

    ///<summary>
    ///Indicates which high-level category of error has occurred during a request to the Connect API.
    ///</summary>
    public enum ErrorCategory
    {
        ///<summary>
        ///An error occurred with the Connect API itself.
        ///</summary>
        API_ERROR,
        ///<summary>
        ///An authentication error occurred. Most commonly, the request had a missing,
        ///malformed, or otherwise invalid `Authorization` header.
        ///</summary>
        AUTHENTICATION_ERROR,
        ///<summary>
        ///An error that is returned from an external vendor's API.
        ///</summary>
        EXTERNAL_VENDOR_ERROR,
        ///<summary>
        ///The request was invalid. Most commonly, a required parameter was missing, or a provided parameter had an invalid value.
        ///</summary>
        INVALID_REQUEST_ERROR,
        ///<summary>
        ///An error occurred when checking a merchant subscription status.
        ///</summary>
        MERCHANT_SUBSCRIPTION_ERROR,
        ///<summary>
        ///An error occurred while processing a payment method. Most commonly, the
        ///details of the payment method were invalid (such as a card's CVV or expiration date).
        ///</summary>
        PAYMENT_METHOD_ERROR,
        ///<summary>
        ///Your application reached the Square API rate limit. You might receive this
        ///error if your application sends a high number of requests
        ///to Square APIs in a short period of time.
        ///
        ///Your application should monitor responses for `429 RATE_LIMITED` errors and
        ///use a retry mechanism with an [exponential
        ///backoff](https://en.wikipedia.org/wiki/Exponential_backoff)
        ///schedule to resend the requests at an increasingly slower rate. It is also a
        ///good practice to use a randomized delay (jitter) in your retry schedule.
        ///</summary>
        RATE_LIMIT_ERROR,
        ///<summary>
        ///An error occurred while attempting to process a refund.
        ///</summary>
        REFUND_ERROR,
    }

    ///<summary>
    ///Indicates the specific error that occurred during a request to a Square API.
    ///</summary>
    public enum ErrorCode
    {
        ///<summary>
        ///The provided access token has expired.
        ///</summary>
        ACCESS_TOKEN_EXPIRED,
        ///<summary>
        ///The provided access token has been revoked.
        ///</summary>
        ACCESS_TOKEN_REVOKED,
        ///<summary>
        ///The account provided cannot carry out transactions.
        ///</summary>
        ACCOUNT_UNUSABLE,
        ///<summary>
        ///The card issuer declined the request because the postal code is invalid.
        ///</summary>
        ADDRESS_VERIFICATION_FAILURE,
        ///<summary>
        ///The card has exhausted its available pin entry retries set by the card issuer.
        ///Resolving the error typically requires the card holder to contact the card issuer.
        ///</summary>
        ALLOWABLE_PIN_TRIES_EXCEEDED,
        ///<summary>
        ///The requested payment amount is too high for the provided payment source.
        ///</summary>
        AMOUNT_TOO_HIGH,
        ///<summary>
        ///The provided Square-Version is incompatible with the requested action.
        ///</summary>
        API_VERSION_INCOMPATIBLE,
        ///<summary>
        ///Square could not find the associated Apple Pay certificate.
        ///</summary>
        APPLE_PAYMENT_PROCESSING_CERTIFICATE_HASH_NOT_FOUND,
        ///<summary>
        ///The payment was declined by the card issuer during an Apple Tap to Pay (TTP) transaction with a request for the
        ///card's PIN. This code will be returned alongside CARD_DECLINED_VERIFICATION_REQUIRED as a supplemental error,
        ///and will include an issuer-provided token in the details field that is needed to initiate the PIN collection
        ///flow on the iOS device.
        ///</summary>
        APPLE_TTP_PIN_TOKEN,
        ///<summary>
        ///The calling application was disabled.
        ///</summary>
        APPLICATION_DISABLED,
        ///<summary>
        ///The provided array is empty.
        ///</summary>
        ARRAY_EMPTY,
        ///<summary>
        ///The provided array has too many elements.
        ///</summary>
        ARRAY_LENGTH_TOO_LONG,
        ///<summary>
        ///The provided array has too few elements.
        ///</summary>
        ARRAY_LENGTH_TOO_SHORT,
        ///<summary>
        ///Bad certificate.
        ///</summary>
        BAD_CERTIFICATE,
        ///<summary>
        ///The card expiration date is either missing or incorrectly formatted.
        ///</summary>
        BAD_EXPIRATION,
        ///<summary>
        ///Bad Gateway - a general error occurred.
        ///</summary>
        BAD_GATEWAY,
        ///<summary>
        ///A general error occurred with the request.
        ///</summary>
        BAD_REQUEST,
        ///<summary>
        ///The card issuer declined the refund.
        ///</summary>
        BLOCKED_BY_BLOCKLIST,
        ///<summary>
        ///The provided buyer id can't be found
        ///</summary>
        BUYER_NOT_FOUND,
        ///<summary>
        ///Bank account rejected or was not authorized for the payment.
        ///</summary>
        BUYER_REFUSED_PAYMENT,
        ///<summary>
        ///Fulfillment type is not supported for calculating fulfillment rates.
        ///</summary>
        CALCULATE_FULFILLMENT_RATES_FULFILLMENT_TYPE_NOT_SUPPORTED,
        ///<summary>
        ///No profiles are configured with the requested shipment destination.
        ///</summary>
        CALCULATE_FULFILLMENT_RATES_INVALID_RECIPIENT_ADDRESS,
        ///<summary>
        ///No profiles are configured for the fufillment type requested.
        ///</summary>
        CALCULATE_FULFILLMENT_RATES_NO_PROFILES_CONFIGURED,
        ///<summary>
        ///No profiles are configured with the requested shipment destination.
        ///</summary>
        CALCULATE_FULFILLMENT_RATES_SHIPMENT_DESTINATION_NOT_CONFIGURED,
        ///<summary>
        ///The card issuer has declined the transaction due to restrictions on where the
        ///card can be used.  For example, a gift card is limited to a single merchant.
        ///</summary>
        CARDHOLDER_INSUFFICIENT_PERMISSIONS,
        ///<summary>
        ///The card was declined.
        ///</summary>
        CARD_DECLINED,
        ///<summary>
        ///The payment card was declined with a request for the card holder to call the issuer.
        ///</summary>
        CARD_DECLINED_CALL_ISSUER,
        ///<summary>
        ///The payment card was declined with a request for additional verification.
        ///</summary>
        CARD_DECLINED_VERIFICATION_REQUIRED,
        ///<summary>
        ///The card issuer declined the request because the card is expired.
        ///</summary>
        CARD_EXPIRED,
        ///<summary>
        ///The API request references an unsupported source type.
        ///</summary>
        CARD_MISMATCH,
        ///<summary>
        ///The card is not supported either in the geographic region or by the [merchant category code](https://developer.squareup.com/docs/locations-api#initialize-a-merchant-category-code) (MCC).
        ///</summary>
        CARD_NOT_SUPPORTED,
        ///<summary>
        ///The transaction requires that a card be present.
        ///</summary>
        CARD_PRESENCE_REQUIRED,
        ///<summary>
        ///The location provided in the API call is not enabled for credit card processing.
        ///</summary>
        CARD_PROCESSING_NOT_ENABLED,
        ///<summary>
        ///The provided card token (nonce) has expired.
        ///</summary>
        CARD_TOKEN_EXPIRED,
        ///<summary>
        ///The provided card token (nonce) was already used to process the payment or refund.
        ///</summary>
        CARD_TOKEN_USED,
        ///<summary>
        ///The provided checkout URL has expired.
        ///</summary>
        CHECKOUT_EXPIRED,
        ///<summary>
        ///The card issuer requires that the card be read using a chip reader.
        ///</summary>
        CHIP_INSERTION_REQUIRED,
        ///<summary>
        ///External clients are not supposed to see this response code as used to reflect
        ///when clients close the connection before we're able to serve a response.
        ///This non-standard response code was adopted by ngnix.
        ///</summary>
        CLIENT_CLOSED_REQUEST,
        ///<summary>
        ///The provided client has been disabled.
        ///</summary>
        CLIENT_DISABLED,
        ///<summary>
        ///The provided client is not supported.
        ///</summary>
        CLIENT_NOT_SUPPORTED,
        ///<summary>
        ///Conflict - a general error occurred.
        ///</summary>
        CONFLICT,
        ///<summary>
        ///One or more of the request parameters conflict with each other.
        ///</summary>
        CONFLICTING_PARAMETERS,
        ///<summary>
        ///The currency associated with the payment is not valid for the provided funding
        ///source. For example, a gift card funded in USD cannot be used to process
        ///payments in GBP.
        ///</summary>
        CURRENCY_MISMATCH,
        ///<summary>
        ///The provided customer does not have a recorded email.
        ///</summary>
        CUSTOMER_MISSING_EMAIL,
        ///<summary>
        ///The provided customer does not have a recorded name.
        ///</summary>
        CUSTOMER_MISSING_NAME,
        ///<summary>
        ///The provided customer id can't be found in the merchant's customers list.
        ///</summary>
        CUSTOMER_NOT_FOUND,
        ///<summary>
        ///The card issuer declined the request because the CVV value is invalid.
        ///</summary>
        CVV_FAILURE,
        ///<summary>
        ///The application tried to cancel a delayed-capture payment that was already cancelled.
        ///</summary>
        DELAYED_TRANSACTION_CANCELED,
        ///<summary>
        ///The application tried to capture a delayed-capture payment that was already captured.
        ///</summary>
        DELAYED_TRANSACTION_CAPTURED,
        ///<summary>
        ///The application tried to update a delayed-capture payment that has expired.
        ///</summary>
        DELAYED_TRANSACTION_EXPIRED,
        ///<summary>
        ///The application tried to update a delayed-capture payment that failed.
        ///</summary>
        DELAYED_TRANSACTION_FAILED,
        ///<summary>
        ///Deprecated now means only that the field is listed as such in the API tech ref. This is not an error.
        ///</summary>
        DEPRECATED_FIELD_SET,
        ///<summary>
        ///The endpoint expected the provided value to be an array or list.
        ///</summary>
        EXPECTED_ARRAY,
        ///<summary>
        ///The endpoint expected the provided value to be an array encoded in base64.
        ///</summary>
        EXPECTED_BASE64_ENCODED_BYTE_ARRAY,
        ///<summary>
        ///The endpoint expected the provided value to be a boolean.
        ///</summary>
        EXPECTED_BOOLEAN,
        ///<summary>
        ///The endpoint expected the provided value to be a float.
        ///</summary>
        EXPECTED_FLOAT,
        ///<summary>
        ///The endpoint expected the provided value to be an integer.
        ///</summary>
        EXPECTED_INTEGER,
        ///<summary>
        ///The request body is not a JSON object.
        ///</summary>
        EXPECTED_JSON_BODY,
        ///<summary>
        ///The endpoint expected the provided value to be a map or associative array.
        ///</summary>
        EXPECTED_MAP,
        ///<summary>
        ///The endpoint expected the provided value to be a JSON object.
        ///</summary>
        EXPECTED_OBJECT,
        ///<summary>
        ///The endpoint expected the provided value to be a string.
        ///</summary>
        EXPECTED_STRING,
        ///<summary>
        ///The card expiration date is either invalid or indicates that the card is expired.
        ///</summary>
        EXPIRATION_FAILURE,
        ///<summary>
        ///A general access error occurred.
        ///</summary>
        FORBIDDEN,
        ///<summary>
        ///Unable to re-assign preferences assignment. Preferences assignment is a write-once field.
        ///</summary>
        FULFILLMENT_PREFERENCES_ASSIGNMENT_IS_IMMUTABLE,
        ///<summary>
        ///The provided preferences assignment types should be consistent within request
        ///</summary>
        FULFILLMENT_PREFERENCES_CONFLICTING_ASSIGNMENT_TYPE,
        ///<summary>
        ///Fulfillment Preferences with fulfillment schedules cannot be assigned to a CATALOG_ITEM
        ///</summary>
        FULFILLMENT_PREFERENCES_FULFILLMENT_SCHEDULE_NOT_ALLOWED,
        ///<summary>
        ///Parameters being used for FulfillmentAvailabilityWindow object are not valid.
        ///</summary>
        FULFILLMENT_PREFERENCES_INVALID_FULFILLMENT_AVAILABILITY_WINDOW,
        ///<summary>
        ///The datetime value is not in the correct format per app business logic.
        ///</summary>
        FULFILLMENT_PREFERENCES_INVALID_SCHEDULING_DATETIME,
        ///<summary>
        ///This restricted date is a duplicate within the list.
        ///</summary>
        FULFILLMENT_PREFERENCES_RESTRICTED_DATE_NOT_UNIQUE,
        ///<summary>
        ///Gateway Timeout - a general error occurred.
        ///</summary>
        GATEWAY_TIMEOUT,
        ///<summary>
        ///Square received a decline without any additional information.  If the payment
        ///information seems correct, the buyer can contact their issuer to ask for more information.
        ///</summary>
        GENERIC_DECLINE,
        ///<summary>
        ///When a Gift Card is a payment source, you can allow taking a partial payment
        ///by adding the `accept_partial_authorization` parameter in the request.
        ///However, taking such a partial payment does not work if your request also includes
        ///`tipMoney`, `appFeeMoney`, or both. Square declines such payments and returns
        ///the `GIFT_CARD_AVAILABLE_AMOUNT` error.
        ///For more information, see
        ///[CreatePayment errors (additional information)](https://developer.squareup.com/docs/payments-api/error-codes#createpayment-errors-additional-information).
        ///</summary>
        GIFT_CARD_AVAILABLE_AMOUNT,
        ///<summary>
        ///The buyer attempting to add value to the gift card has reached daily purchase limits.
        ///</summary>
        GIFT_CARD_BUYER_DAILY_LIMIT_REACHED,
        ///<summary>
        ///The specified gift card amount is zero, negative, in the incorrect currency, or too large.
        ///</summary>
        GIFT_CARD_INVALID_AMOUNT,
        ///<summary>
        ///The gift card's maximum value has been reached.
        ///</summary>
        GIFT_CARD_MAX_VALUE_REACHED,
        ///<summary>
        ///The merchant's maximum total of outstanding gift card balances has been reached.
        ///</summary>
        GIFT_CARD_MERCHANT_MAX_OUTSTANDING_BALANCE_REACHED,
        ///<summary>
        ///Attempted to add an amount to a gift card that is beyond its limits.
        ///</summary>
        GIFT_CARD_VALUE_ADDITION_LIMIT_REACHED,
        ///<summary>
        ///The target resource is no longer available and this condition is likely to be permanent.
        ///</summary>
        GONE,
        ///<summary>
        ///HTTPS only.
        ///</summary>
        HTTPS_ONLY,
        ///<summary>
        ///The provided idempotency key has already been used.
        ///</summary>
        IDEMPOTENCY_KEY_REUSED,
        ///<summary>
        ///The value provided in the request is the wrong type. For example, a string instead of an integer.
        ///</summary>
        INCORRECT_TYPE,
        ///<summary>
        ///The funding source has insufficient funds to cover the payment.
        ///</summary>
        INSUFFICIENT_FUNDS,
        ///<summary>
        ///The referenced inventory item has insufficient inventory.
        ///</summary>
        INSUFFICIENT_INVENTORY,
        ///<summary>
        ///The Square account does not have the permissions to accept this payment. For
        ///example, Square may limit which merchants are allowed to receive gift card payments.
        ///</summary>
        INSUFFICIENT_PERMISSIONS,
        ///<summary>
        ///The Square account does not have the permissions to process this refund.
        ///</summary>
        INSUFFICIENT_PERMISSIONS_FOR_REFUND,
        ///<summary>
        ///The provided access token does not have permission to execute the requested action.
        ///</summary>
        INSUFFICIENT_SCOPES,
        ///<summary>
        ///A general server error occurred.
        ///</summary>
        INTERNAL_SERVER_ERROR,
        ///<summary>
        ///The issuer was not able to locate the account on record.
        ///</summary>
        INVALID_ACCOUNT,
        ///<summary>
        ///One or more objects in the array does not match the array type.
        ///</summary>
        INVALID_ARRAY_VALUE,
        ///<summary>
        ///The credit card cannot be validated based on the provided details.
        ///</summary>
        INVALID_CARD,
        ///<summary>
        ///Generic error - the provided card data is invalid.
        ///</summary>
        INVALID_CARD_DATA,
        ///<summary>
        ///Invalid content type header.
        ///</summary>
        INVALID_CONTENT_TYPE,
        ///<summary>
        ///The pagination cursor included in the request is invalid.
        ///</summary>
        INVALID_CURSOR,
        ///<summary>
        ///The subscription cannot be paused/resumed on the given date.
        ///</summary>
        INVALID_DATE,
        ///<summary>
        ///The provided email address is invalid.
        ///</summary>
        INVALID_EMAIL_ADDRESS,
        ///<summary>
        ///The encrypted card information is invalid.
        ///</summary>
        INVALID_ENCRYPTED_CARD,
        ///<summary>
        ///The provided static string is not valid for the field.
        ///</summary>
        INVALID_ENUM_VALUE,
        ///<summary>
        ///The expiration date for the payment card is invalid. For example, it indicates a date in the past.
        ///</summary>
        INVALID_EXPIRATION,
        ///<summary>
        ///The expiration date for the payment card is invalid. For example, it contains invalid characters.
        ///</summary>
        INVALID_EXPIRATION_DATE,
        ///<summary>
        ///The expiration year for the payment card is invalid. For example, it indicates
        ///a year in the past or contains invalid characters.
        ///</summary>
        INVALID_EXPIRATION_YEAR,
        ///<summary>
        ///The app_fee_money on a payment is too high.
        ///</summary>
        INVALID_FEES,
        ///<summary>
        ///Only relevant for applications created prior to 2016-03-30. Indicates there was an error while parsing form values.
        ///</summary>
        INVALID_FORM_VALUE,
        ///<summary>
        ///The Square account cannot take payments in the specified region.  A Square
        ///account can take payments only from the region where the account was created.
        ///</summary>
        INVALID_LOCATION,
        ///<summary>
        ///The subscription cannot be paused longer than the duration of the current phase.
        ///</summary>
        INVALID_PAUSE_LENGTH,
        ///<summary>
        ///The provided phone number is invalid.
        ///</summary>
        INVALID_PHONE_NUMBER,
        ///<summary>
        ///The card issuer declined the request because the PIN is invalid.
        ///</summary>
        INVALID_PIN,
        ///<summary>
        ///The postal code is incorrectly formatted.
        ///</summary>
        INVALID_POSTAL_CODE,
        ///<summary>
        ///The provided sort order is not a valid key.  Currently, sort order must be `ASC` or `DESC`.
        ///</summary>
        INVALID_SORT_ORDER,
        ///<summary>
        ///The provided Square-Version is incorrectly formatted.
        ///</summary>
        INVALID_SQUARE_VERSION_FORMAT,
        ///<summary>
        ///Formatting for the provided time value is incorrect.
        ///</summary>
        INVALID_TIME,
        ///<summary>
        ///Value is not a valid timezone.
        ///</summary>
        INVALID_TIMEZONE,
        ///<summary>
        ///The time range provided in the request is invalid.  For example, the end time is before the start time.
        ///</summary>
        INVALID_TIME_RANGE,
        ///<summary>
        ///The provided API URL is invalid.
        ///</summary>
        INVALID_URL,
        ///<summary>
        ///The provided value is invalid. For example, including `%` in a phone number.
        ///</summary>
        INVALID_VALUE,
        ///<summary>
        ///The verification code provided is invalid.
        ///</summary>
        INVALID_VERIFICATION_CODE,
        ///<summary>
        ///There already exists a job template with the given name.
        ///</summary>
        JOB_TEMPLATE_NAME_TAKEN,
        ///<summary>
        ///Generic error - the given location does not matching what is expected.
        ///</summary>
        LOCATION_MISMATCH,
        ///<summary>
        ///The card must be swiped, tapped, or dipped. Payments attempted by manually entering the card number are declined.
        ///</summary>
        MANUALLY_ENTERED_PAYMENT_NOT_SUPPORTED,
        ///<summary>
        ///The length of one of the provided keys in the map is too long.
        ///</summary>
        MAP_KEY_LENGTH_TOO_LONG,
        ///<summary>
        ///The length of one of the provided keys in the map is too short.
        ///</summary>
        MAP_KEY_LENGTH_TOO_SHORT,
        ///<summary>
        ///A required subscription was not found for the merchant
        ///</summary>
        MERCHANT_SUBSCRIPTION_NOT_FOUND,
        ///<summary>
        ///Method Not Allowed - a general error occurred.
        ///</summary>
        METHOD_NOT_ALLOWED,
        ///<summary>
        ///The payment is missing a required ACCOUNT_TYPE parameter.
        ///</summary>
        MISSING_ACCOUNT_TYPE,
        ///<summary>
        ///The payment is missing a required PIN.
        ///</summary>
        MISSING_PIN,
        ///<summary>
        ///The request is missing a required path, query, or body parameter.
        ///</summary>
        MISSING_REQUIRED_PARAMETER,
        ///<summary>
        ///Not Acceptable - a general error occurred.
        ///</summary>
        NOT_ACCEPTABLE,
        ///<summary>
        ///Not Found - a general error occurred.
        ///</summary>
        NOT_FOUND,
        ///<summary>
        ///Not Implemented - a general error occurred.
        ///</summary>
        NOT_IMPLEMENTED,
        ///<summary>
        ///A general error occurred.
        ///</summary>
        NO_FIELDS_SET,
        ///<summary>
        ///A general error occurred.
        ///</summary>
        ONE_INSTRUMENT_EXPECTED,
        ///<summary>
        ///The order was already used.
        ///</summary>
        ORDER_ALREADY_USED,
        ///<summary>
        ///The requested order has expired and cannot be updated.
        ///</summary>
        ORDER_EXPIRED,
        ///<summary>
        ///The creation request contains too many catalog IDs.
        ///</summary>
        ORDER_TOO_MANY_CATALOG_OBJECTS,
        ///<summary>
        ///The specified card number is invalid. For example, it is of incorrect length or is incorrectly formatted.
        ///</summary>
        PAN_FAILURE,
        ///<summary>
        ///The payment was declined because there was a payment amount mismatch.  The
        ///money amount Square was expecting does not match the amount provided.
        ///</summary>
        PAYMENT_AMOUNT_MISMATCH,
        ///<summary>
        ///Square declined the request because the payment amount exceeded the processing limit for this merchant.
        ///</summary>
        PAYMENT_LIMIT_EXCEEDED,
        ///<summary>
        ///The payment is not refundable. For example, the payment has been disputed and is no longer eligible for refunds.
        ///</summary>
        PAYMENT_NOT_REFUNDABLE,
        ///<summary>
        ///Generic plaid error.
        ///</summary>
        PLAID_ERROR,
        ///<summary>
        ///Plaid error - ITEM_LOGIN_REQUIRED.
        ///</summary>
        PLAID_ERROR_ITEM_LOGIN_REQUIRED,
        ///<summary>
        ///Plaid error - RATE_LIMIT.
        ///</summary>
        PLAID_ERROR_RATE_LIMIT,
        ///<summary>
        ///There is a price mismatch.
        ///</summary>
        PRICE_MISMATCH,
        ///<summary>
        ///Rate Limited - a general error occurred.
        ///</summary>
        RATE_LIMITED,
        ///<summary>
        ///The payment already has a pending refund.
        ///</summary>
        REFUND_ALREADY_PENDING,
        ///<summary>
        ///The requested refund amount exceeds the amount available to refund.
        ///</summary>
        REFUND_AMOUNT_INVALID,
        ///<summary>
        ///Request failed - The card issuer declined the refund.
        ///</summary>
        REFUND_DECLINED,
        ///<summary>
        ///Request Entity Too Large - a general error occurred.
        ///</summary>
        REQUEST_ENTITY_TOO_LARGE,
        ///<summary>
        ///Request Timeout - a general error occurred.
        ///</summary>
        REQUEST_TIMEOUT,
        ///<summary>
        ///The card issuer declined the refund.
        ///</summary>
        RESERVATION_DECLINED,
        ///<summary>
        ///The fields are not accessible at the request api version. Use API_VERSION_INCOMPATIBLE instead.
        ///</summary>
        RETIRED_FIELD_SET,
        ///<summary>
        ///The API request is not supported in sandbox.
        ///</summary>
        SANDBOX_NOT_SUPPORTED,
        ///<summary>
        ///Service Unavailable - a general error occurred.
        ///</summary>
        SERVICE_UNAVAILABLE,
        ///<summary>
        ///A session associated with the payment has expired.
        ///</summary>
        SESSION_EXPIRED,
        ///<summary>
        ///The provided source id has expired.
        ///</summary>
        SOURCE_EXPIRED,
        ///<summary>
        ///The provided source id was already used to create a card.
        ///</summary>
        SOURCE_USED,
        ///<summary>
        ///A temporary internal error occurred. You can safely retry your call using the same idempotency key.
        ///</summary>
        TEMPORARY_ERROR,
        ///<summary>
        ///Too many entries in the map field.
        ///</summary>
        TOO_MANY_MAP_ENTRIES,
        ///<summary>
        ///The card issuer has determined the payment amount is either too high or too low.
        ///The API returns the error code mostly for credit cards (for example, the card reached
        ///the credit limit). However, sometimes the issuer bank can indicate the error for debit
        ///or prepaid cards (for example, card has insufficient funds).
        ///</summary>
        TRANSACTION_LIMIT,
        ///<summary>
        ///A general authorization error occurred.
        ///</summary>
        UNAUTHORIZED,
        ///<summary>
        ///General error - the value provided was unexpected.
        ///</summary>
        UNEXPECTED_VALUE,
        ///<summary>
        ///The body parameter is not recognized by the requested endpoint.
        ///</summary>
        UNKNOWN_BODY_PARAMETER,
        ///<summary>
        ///The query parameters provided is invalid for the requested endpoint.
        ///</summary>
        UNKNOWN_QUERY_PARAMETER,
        ///<summary>
        ///Unprocessable Entity - a general error occurred.
        ///</summary>
        UNPROCESSABLE_ENTITY,
        ///<summary>
        ///The provided URL is unreachable.
        ///</summary>
        UNREACHABLE_URL,
        ///<summary>
        ///The credit card provided is not from a supported issuer.
        ///</summary>
        UNSUPPORTED_CARD_BRAND,
        ///<summary>
        ///The API request references an unsupported country.
        ///</summary>
        UNSUPPORTED_COUNTRY,
        ///<summary>
        ///The API request references an unsupported currency.
        ///</summary>
        UNSUPPORTED_CURRENCY,
        ///<summary>
        ///The entry method for the credit card (swipe, dip, tap) is not supported.
        ///</summary>
        UNSUPPORTED_ENTRY_METHOD,
        ///<summary>
        ///The API request references an unsupported instrument type/
        ///</summary>
        UNSUPPORTED_INSTRUMENT_TYPE,
        ///<summary>
        ///The referenced loyalty program reward tier is not supported.  This could
        ///happen if the reward tier created in a first party application is incompatible
        ///with the Loyalty API.
        ///</summary>
        UNSUPPORTED_LOYALTY_REWARD_TIER,
        ///<summary>
        ///Unsupported Media Type - a general error occurred.
        ///</summary>
        UNSUPPORTED_MEDIA_TYPE,
        ///<summary>
        ///The API request references an unsupported source type.
        ///</summary>
        UNSUPPORTED_SOURCE_TYPE,
        ///<summary>
        ///The calling application is using an access token created prior to 2016-03-30
        ///and is not compatible with v2 Square API calls.
        ///</summary>
        V1_ACCESS_TOKEN,
        ///<summary>
        ///The calling application was created prior to 2016-03-30 and is not compatible with v2 Square API calls.
        ///</summary>
        V1_APPLICATION,
        ///<summary>
        ///The provided value has a default (empty) value such as a blank string.
        ///</summary>
        VALUE_EMPTY,
        ///<summary>
        ///The provided value does not match an expected regular expression.
        ///</summary>
        VALUE_REGEX_MISMATCH,
        ///<summary>
        ///The provided value is greater than the supported maximum.
        ///</summary>
        VALUE_TOO_HIGH,
        ///<summary>
        ///The provided string value is longer than the maximum length allowed.
        ///</summary>
        VALUE_TOO_LONG,
        ///<summary>
        ///The provided value is less than the supported minimum.
        ///</summary>
        VALUE_TOO_LOW,
        ///<summary>
        ///The provided string value is shorter than the minimum length allowed.
        ///</summary>
        VALUE_TOO_SHORT,
        ///<summary>
        ///The AVS could not be verified.
        ///</summary>
        VERIFY_AVS_FAILURE,
        ///<summary>
        ///The CVV could not be verified.
        ///</summary>
        VERIFY_CVV_FAILURE,
        ///<summary>
        ///The provided object version does not match the expected value.
        ///</summary>
        VERSION_MISMATCH,
        ///<summary>
        ///The card issuer declined the request because the issuer requires voice authorization from the cardholder.
        ///</summary>
        VOICE_FAILURE,
    }

    ///<summary>
    ///Indicates which products matched by a CatalogPricingRule
    ///will be excluded if the pricing rule uses an exclude set.
    ///</summary>
    public enum ExcludeStrategy
    {
        ///<summary>
        ///The least expensive matched products are excluded from the pricing. If
        ///the pricing rule is set to exclude one product and multiple products in the
        ///match set qualify as least expensive, then one will be excluded at random.
        ///
        ///Excluding the least expensive product gives the best discount value to the buyer.
        ///</summary>
        LEAST_EXPENSIVE,
        ///<summary>
        ///The most expensive matched product is excluded from the pricing rule.
        ///If multiple products have the same price and all qualify as least expensive,
        ///one will be excluded at random.
        ///
        ///This guarantees that the most expensive product is purchased at full price.
        ///</summary>
        MOST_EXPENSIVE,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Stores details about an external payment. Contains only non-confidential information.
    ///For more information, see
    ///[Take External Payments](https://developer.squareup.com/docs/payments-api/take-payments/external-payments).
    ///</summary>
    public class ExternalPaymentDetails : GraphQLObject<ExternalPaymentDetails>
    {
        ///<summary>
        ///A description of the external payment source. For example, "Food Delivery Service".
        ///</summary>
        public string? source { get; set; }
        ///<summary>
        ///The fees paid to the source. The `amountMoney` minus this field is the net amount seller receives.
        ///</summary>
        public Money? sourceFeeMoney { get; set; }
        ///<summary>
        ///An ID to associate the payment to its originating source.
        ///</summary>
        public string? sourceId { get; set; }
        ///<summary>
        ///The type of external payment the seller received.
        ///</summary>
        public ExternalPaymentType? type { get; set; }
    }

    ///<summary>
    ///The type of external payment the seller received.
    ///</summary>
    public enum ExternalPaymentType
    {
        ///<summary>
        ///Paid using external bank transfer.
        ///</summary>
        BANK_TRANSFER,
        ///<summary>
        ///A credit or debit card that Square does not support.
        ///</summary>
        CARD,
        ///<summary>
        ///Paid using a physical check.
        ///</summary>
        CHECK,
        ///<summary>
        ///Paid using a crypto currency.
        ///</summary>
        CRYPTO,
        ///<summary>
        ///Paid using an E-money provider.
        ///</summary>
        EMONEY,
        ///<summary>
        ///A third-party application gathered this payment outside of Square.
        ///</summary>
        EXTERNAL,
        ///<summary>
        ///Restaurant voucher provided by employers to employees to pay for meals.
        ///</summary>
        FOOD_VOUCHER,
        ///<summary>
        ///A type not listed here.
        ///</summary>
        OTHER,
        ///<summary>
        ///Paid using a non-Square gift card.
        ///</summary>
        OTHER_GIFT_CARD,
        ///<summary>
        ///Paid using peer-to-peer payment applications.
        ///</summary>
        SOCIAL,
        ///<summary>
        ///Paid using Square Cash App.
        ///</summary>
        SQUARE_CASH,
        ///<summary>
        ///Use for house accounts, store credit, and so forth.
        ///</summary>
        STORED_BALANCE,
    }

    ///<summary>
    ///Latitude and longitude coordinates.
    ///</summary>
    public class GeoCoordinates : GraphQLObject<GeoCoordinates>
    {
        ///<summary>
        ///The latitude of the coordinate expressed in degrees.
        ///</summary>
        public double? latitude { get; set; }
        ///<summary>
        ///The longitude of the coordinate expressed in degrees.
        ///</summary>
        public double? longitude { get; set; }
    }

    ///<summary>
    ///Geographic coordinates representing a location on the Earth's surface.
    ///</summary>
    public class GeoLocation : GraphQLObject<GeoLocation>
    {
        ///<summary>
        ///Angular distance north or south of the Earth's equator, measured in degrees from -90 to +90.
        ///</summary>
        public double? latitude { get; set; }
        ///<summary>
        ///Angular distance east or west of the Prime Meridian at Greenwich, UK, measured in degrees from -180 to +180.
        ///</summary>
        public double? longitude { get; set; }
    }

    ///<summary>
    ///Represents a change in state or quantity of product inventory at a
    ///particular time and location.
    ///Permissions: INVENTORY_READ
    ///</summary>
    public class InventoryAdjustment : GraphQLObject<InventoryAdjustment>, IInventoryChange
    {
        ///<summary>
        ///A unique ID generated by Square
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///An optional ID provided by the application to tie the InventoryChange to an external system.
        ///</summary>
        public string? referenceId { get; set; }
        ///<summary>
        ///The inventory state of the related quantity
        ///of items before the adjustment.
        ///</summary>
        public InventoryState? fromState { get; set; }
        ///<summary>
        ///The inventory state of the related quantity
        ///of items after the adjustment.
        ///</summary>
        public InventoryState? toState { get; set; }
        ///<summary>
        ///The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.
        ///</summary>
        public string? quantity { get; set; }
        ///<summary>
        ///The total price paid for goods associated with the
        ///adjustment. Present if and only if `to_state` is `SOLD`. Always
        ///non-negative.
        ///</summary>
        public Money? totalPriceMoney { get; set; }
        ///<summary>
        ///A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? occurredAt { get; set; }
        ///<summary>
        ///An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///Information about the application with which the physical count is submitted.
        ///</summary>
        public SourceApplication? source { get; set; }
        ///<summary>
        ///The Square-generated ID of the Transaction that
        ///caused the adjustment. Only relevant for payment-related state
        ///transitions.
        ///</summary>
        public string? transactionId { get; set; }
        ///<summary>
        ///The Square-generated ID of the Refund that
        ///caused the adjustment. Only relevant for refund-related state
        ///transitions.
        ///</summary>
        public string? refundId { get; set; }
        ///<summary>
        ///The Square-generated ID of the purchase order that caused the
        ///adjustment. Only relevant for state transitions from the Square for Retail
        ///app.
        ///</summary>
        public string? purchaseOrderId { get; set; }
        ///<summary>
        ///The Square-generated ID of the goods receipt that caused the
        ///adjustment. Only relevant for state transitions from the Square for Retail
        ///app.
        ///</summary>
        public string? goodsReceiptId { get; set; }
        ///<summary>
        ///An adjustment group bundling the related adjustments of item variations through stock conversions in a single inventory event.
        ///</summary>
        public InventoryAdjustmentGroup? adjustmentGroup { get; set; }
        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items is being tracked.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The CatalogObject being tracked.
        ///</summary>
        public ICatalogObject? catalog { get; set; }
        ///<summary>
        ///Indicates how the inventory change is applied. See
        ///[InventoryChangeType](entity:InventoryChangeType) for all possible values.
        ///See [InventoryChangeType](#type-inventorychangetype) for possible values
        ///</summary>
        public InventoryChangeType? type { get; set; }
        ///<summary>
        ///The Employee responsible for
        ///</summary>
        public Employee? employee { get; set; }
        ///<summary>
        ///The Team Member responsible for
        ///</summary>
        public TeamMember? teamMember { get; set; }
    }

    ///<summary>
    ///Permissions: INVENTORY_READ
    ///</summary>
    public class InventoryAdjustmentGroup : GraphQLObject<InventoryAdjustmentGroup>
    {
        ///<summary>
        ///A unique ID generated by Square for the
        ///`InventoryAdjustmentGroup`.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The inventory adjustment of the composed variation.
        ///</summary>
        public string? rootAdjustmentId { get; set; }
        ///<summary>
        ///Representative `from_state` for adjustments within the group. For example, for a group adjustment from `IN_STOCK` to `SOLD`,
        ///there can be two component adjustments in the group: one from `IN_STOCK`to `COMPOSED` and the other one from `COMPOSED` to `SOLD`.
        ///Here, the representative `from_state` for the `InventoryAdjustmentGroup` is `IN_STOCK`.
        ///</summary>
        public InventoryState? fromState { get; set; }
        ///<summary>
        ///Representative `to_state` for adjustments within group. For example, for a group adjustment from `IN_STOCK` to `SOLD`,
        ///the two component adjustments in the group can be from `IN_STOCK` to `COMPOSED` and from `COMPOSED` to `SOLD`.
        ///Here, the representative `to_state` of the `InventoryAdjustmentGroup` is `SOLD`.
        ///</summary>
        public InventoryState? toState { get; set; }
    }

    ///<summary>
    ///Inventory alert definition's associated values.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class InventoryAlert : GraphQLObject<InventoryAlert>
    {
        ///<summary>
        ///If the inventory quantity for the variation is less than or equal to this value and type is LOW_QUANTITY, the variation displays an alert in the merchant dashboard.
        ///This value is always an integer.
        ///</summary>
        public long? threshold { get; set; }
        ///<summary>
        ///Indicates whether the item variation displays an alert when its inventory quantity is less than or equal to its threshold.
        ///</summary>
        public InventoryAlertType? type { get; set; }
    }

    ///<summary>
    ///Indicates whether Square should alert the merchant when the inventory quantity of a CatalogItemVariation is low.
    ///</summary>
    public enum InventoryAlertType
    {
        ///<summary>
        ///The variation does not display an alert.
        ///</summary>
        NONE,
        ///<summary>
        ///The variation generates an alert when its quantity is low.
        ///</summary>
        LOW_QUANTITY,
    }

    ///<summary>
    ///Represents a single physical count, inventory, adjustment, or transfer
    ///that is part of the history of inventory changes for a particular
    ///[CatalogObject](entity:CatalogObject) instance.
    ///</summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "__typename")]
    [JsonDerivedType(typeof(InventoryAdjustment), typeDiscriminator: "InventoryAdjustment")]
    [JsonDerivedType(typeof(InventoryPhysicalCount), typeDiscriminator: "InventoryPhysicalCount")]
    [JsonDerivedType(typeof(InventoryTransfer), typeDiscriminator: "InventoryTransfer")]
    public interface IInventoryChange : IGraphQLObject
    {
        public InventoryAdjustment? AsInventoryAdjustment() => this as InventoryAdjustment;
        public InventoryPhysicalCount? AsInventoryPhysicalCount() => this as InventoryPhysicalCount;
        public InventoryTransfer? AsInventoryTransfer() => this as InventoryTransfer;
        ///<summary>
        ///A unique ID generated by Square
        ///</summary>
        public string? id { get; }
        ///<summary>
        ///Indicates how the inventory change is applied. See
        ///[InventoryChangeType](entity:InventoryChangeType) for all possible values.
        ///See [InventoryChangeType](#type-inventorychangetype) for possible values
        ///</summary>
        public InventoryChangeType? type { get; }
        ///<summary>
        ///The CatalogObject being tracked.
        ///</summary>
        public ICatalogObject? catalog { get; }
        ///<summary>
        ///An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; }
        ///<summary>
        ///An optional ID provided by the application to tie the InventoryChange to an external system.
        ///</summary>
        public string? referenceId { get; }
        ///<summary>
        ///The Employee responsible for
        ///</summary>
        public Employee? employee { get; }
        ///<summary>
        ///The Team Member responsible for
        ///</summary>
        public TeamMember? teamMember { get; }
        ///<summary>
        ///A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? occurredAt { get; }
        ///<summary>
        ///Information about the application with which the physical count is submitted.
        ///</summary>
        public SourceApplication? source { get; }
        ///<summary>
        ///The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.
        ///</summary>
        public string? quantity { get; }
    }

    ///<summary>
    ///Contains information of InventoryChange result.
    ///
    ///Permissions:INVENTORY_READ
    ///</summary>
    public class InventoryChangeConnection : GraphQLObject<InventoryChangeConnection>, IConnectionWithNodes<IInventoryChange>
    {
        ///<summary>
        ///List of InventoryChange
        ///</summary>
        public IEnumerable<IInventoryChange>? nodes { get; set; }
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///Indicates how the inventory change was applied to a tracked product quantity.
    ///</summary>
    public enum InventoryChangeType
    {
        ///<summary>
        ///The change occurred as part of a physical count update.
        ///</summary>
        PHYSICAL_COUNT,
        ///<summary>
        ///The change occurred as part of the normal lifecycle of goods
        ///(e.g., as an inventory adjustment).
        ///</summary>
        ADJUSTMENT,
        ///<summary>
        ///The change occurred as part of an inventory transfer.
        ///</summary>
        TRANSFER,
    }

    ///<summary>
    ///Represents Square-estimated quantity of items in a particular state at a
    ///particular seller location based on the known history of physical counts and
    ///inventory adjustments.
    ///Permissions: INVENTORY_READ
    ///</summary>
    public class InventoryCount : GraphQLObject<InventoryCount>
    {
        ///<summary>
        ///The current inventory state for the related
        ///quantity of items.
        ///</summary>
        public InventoryState? state { get; set; }
        ///<summary>
        ///The number of items affected by the estimated count as a decimal string.
        ///Can support up to 5 digits after the decimal point.
        ///</summary>
        public string? quantity { get; set; }
        ///<summary>
        ///Whether the inventory count is for composed variation (TRUE) or not (FALSE). If true, the inventory count will not be present in the response of
        ///any of these endpoints: [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory),
        ///[BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges),
        ///[BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts), and
        ///[RetrieveInventoryChanges](api-endpoint:Inventory-RetrieveInventoryChanges).
        ///</summary>
        public bool? isEstimated { get; set; }
        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items is being tracked.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The Square-generated ID of the
        ///CatalogObject being tracked.
        ///</summary>
        public ICatalogObject? catalog { get; set; }
        ///<summary>
        ///An RFC 3339-formatted timestamp that indicates when the most recent physical count or adjustment affecting
        ///the estimated count is received.
        ///
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///
        ///UTC:  2020-01-26T02:25:34Z
        ///
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? calculatedAt { get; set; }
    }

    ///<summary>
    ///Contains information of InventoryCount result.
    ///
    ///Permissions:INVENTORY_READ
    ///</summary>
    public class InventoryCountConnection : GraphQLObject<InventoryCountConnection>, IConnectionWithNodes<InventoryCount>
    {
        ///<summary>
        ///List of InventoryCount
        ///</summary>
        public IEnumerable<InventoryCount>? nodes { get; set; }
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///Represents the quantity of an item variation that is physically present
    ///at a specific location, verified by a seller or a seller's employee.For example,
    ///a physical count might come from an employee counting the item variations on
    ///hand or from syncing with an external system.
    ///Permissions: INVENTORY_READ
    ///</summary>
    public class InventoryPhysicalCount : GraphQLObject<InventoryPhysicalCount>, IInventoryChange
    {
        ///<summary>
        ///A unique ID generated by Square
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///An optional ID provided by the application to tie the InventoryChange to an external system.
        ///</summary>
        public string? referenceId { get; set; }
        ///<summary>
        ///The current inventory state for the related
        ///quantity of items.
        ///</summary>
        public InventoryState? state { get; set; }
        ///<summary>
        ///The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.
        ///</summary>
        public string? quantity { get; set; }
        ///<summary>
        ///Information about the application with which the physical count is submitted.
        ///</summary>
        public SourceApplication? source { get; set; }
        ///<summary>
        ///A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? occurredAt { get; set; }
        ///<summary>
        ///An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items is being tracked.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The CatalogObject being tracked.
        ///</summary>
        public ICatalogObject? catalog { get; set; }
        ///<summary>
        ///Indicates how the inventory change is applied. See
        ///[InventoryChangeType](entity:InventoryChangeType) for all possible values.
        ///See [InventoryChangeType](#type-inventorychangetype) for possible values
        ///</summary>
        public InventoryChangeType? type { get; set; }
        ///<summary>
        ///The Employee responsible for
        ///</summary>
        public Employee? employee { get; set; }
        ///<summary>
        ///The Team Member responsible for
        ///</summary>
        public TeamMember? teamMember { get; set; }
    }

    ///<summary>
    ///Indicates the state of a tracked item quantity in the lifecycle of goods.
    ///</summary>
    public enum InventoryState
    {
        ///<summary>
        ///The related quantity of items are in a custom state. **READ-ONLY**:
        ///the Inventory API cannot move quantities to or from this state.
        ///</summary>
        CUSTOM,
        ///<summary>
        ///The related quantity of items are on hand and available for sale.
        ///</summary>
        IN_STOCK,
        ///<summary>
        ///The related quantity of items were sold as part of an itemized
        ///transaction. Quantities in the `SOLD` state are no longer tracked.
        ///</summary>
        SOLD,
        ///<summary>
        ///The related quantity of items were returned through the Square Point
        ///of Sale application, but are not yet available for sale. **READ-ONLY**:
        ///the Inventory API cannot move quantities to or from this state.
        ///</summary>
        RETURNED_BY_CUSTOMER,
        ///<summary>
        ///The related quantity of items are on hand, but not currently
        ///available for sale. **READ-ONLY**: the Inventory API cannot move
        ///quantities to or from this state.
        ///</summary>
        RESERVED_FOR_SALE,
        ///<summary>
        ///The related quantity of items were sold online. **READ-ONLY**: the
        ///Inventory API cannot move quantities to or from this state.
        ///</summary>
        SOLD_ONLINE,
        ///<summary>
        ///The related quantity of items were ordered from a vendor but not yet
        ///received. **READ-ONLY**: the Inventory API cannot move quantities to or
        ///from this state.
        ///</summary>
        ORDERED_FROM_VENDOR,
        ///<summary>
        ///The related quantity of items were received from a vendor but are
        ///not yet available for sale. **READ-ONLY**: the Inventory API cannot move
        ///quantities to or from this state.
        ///</summary>
        RECEIVED_FROM_VENDOR,
        ///<summary>
        ///Replaced by `IN_TRANSIT` to represent quantities
        ///of items that are in transit between locations.
        ///</summary>
        IN_TRANSIT_TO,
        ///<summary>
        ///A placeholder indicating that the related quantity of items are not
        ///currently tracked in Square. Transferring quantities from the `NONE` state
        ///to a tracked state (e.g., `IN_STOCK`) introduces stock into the system.
        ///</summary>
        NONE,
        ///<summary>
        ///The related quantity of items are lost or damaged and cannot be
        ///sold.
        ///</summary>
        WASTE,
        ///<summary>
        ///The related quantity of items were returned but not linked to a
        ///previous transaction. Unlinked returns are not tracked in Square.
        ///Transferring a quantity from `UNLINKED_RETURN` to a tracked state (e.g.,
        ///`IN_STOCK`) introduces new stock into the system.
        ///</summary>
        UNLINKED_RETURN,
        ///<summary>
        ///The related quantity of items that are part of a composition consisting one or more components.
        ///</summary>
        COMPOSED,
        ///<summary>
        ///The related quantity of items that are part of a component.
        ///</summary>
        DECOMPOSED,
        ///<summary>
        ///This state is not supported by this version of the Square API. We recommend that you upgrade the client to use the appropriate version of the Square API supporting this state.
        ///</summary>
        SUPPORTED_BY_NEWER_VERSION,
        ///<summary>
        ///The related quantity of items are in transit between locations. **READ-ONLY:** the Inventory API cannot currently be used to move quantities to or from this inventory state.
        ///</summary>
        IN_TRANSIT,
    }

    ///<summary>
    ///Represents the transfer of a quantity of product inventory at a
    ///particular time from one location to another.
    ///Permissions: INVENTORY_READ
    ///</summary>
    public class InventoryTransfer : GraphQLObject<InventoryTransfer>, IInventoryChange
    {
        ///<summary>
        ///A unique ID generated by Square
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///An optional ID provided by the application to tie the InventoryChange to an external system.
        ///</summary>
        public string? referenceId { get; set; }
        ///<summary>
        ///The inventory state for the quantity of
        ///items being transferred.
        ///</summary>
        public InventoryState? state { get; set; }
        ///<summary>
        ///The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.
        ///</summary>
        public string? quantity { get; set; }
        ///<summary>
        ///A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? occurredAt { get; set; }
        ///<summary>
        ///An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///Information about the application with which the physical count is submitted.
        ///</summary>
        public SourceApplication? source { get; set; }
        ///<summary>
        ///The CatalogObject being tracked.
        ///</summary>
        public ICatalogObject? catalog { get; set; }
        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items was tracked before the transfer.
        ///</summary>
        public Location? fromLocation { get; set; }
        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items was tracked after the transfer.
        ///</summary>
        public Location? toLocation { get; set; }
        ///<summary>
        ///Indicates how the inventory change is applied. See
        ///[InventoryChangeType](entity:InventoryChangeType) for all possible values.
        ///See [InventoryChangeType](#type-inventorychangetype) for possible values
        ///</summary>
        public InventoryChangeType? type { get; set; }
        ///<summary>
        ///The Employee responsible for
        ///</summary>
        public Employee? employee { get; set; }
        ///<summary>
        ///The Team Member responsible for
        ///</summary>
        public TeamMember? teamMember { get; set; }
    }

    ///<summary>
    ///A location for a Merchant. The location may be a physical location, such as a storefront, or it may be an abstract
    ///location, such as an online store, facebook/instagram property, etc.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    public class Location : GraphQLObject<Location>
    {
        ///<summary>
        ///The Square-issued ID of the location.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The physical address of the location.
        ///</summary>
        public Address? address { get; set; }
        ///<summary>
        ///The email of the location. This email is visible to the customers of the location. For example, the email appears on customer receipts
        ///</summary>
        public string? businessEmail { get; set; }
        ///<summary>
        ///The hours of operation for the location.
        ///</summary>
        public BusinessHours? businessHours { get; set; }
        ///<summary>
        ///The business name of the location This is the name visible to the customers of the location. For example, this name appears on customer receipts.
        ///</summary>
        public string? businessName { get; set; }
        ///<summary>
        ///The Square features that are enabled for the location.
        ///</summary>
        public IEnumerable<LocationCapability>? capabilities { get; set; }
        ///<summary>
        ///The physical coordinates (latitude and longitude) of the location.
        ///</summary>
        public GeoCoordinates? coordinates { get; set; }
        ///<summary>
        ///The country of the location.
        ///</summary>
        public Country? country { get; set; }
        ///<summary>
        ///The time when the location was created, in RFC 3339 format. For more information, see Working with Dates.
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///The currency used for all transactions at this location.
        ///</summary>
        public Currency? currency { get; set; }
        ///<summary>
        ///The description of the location.
        ///</summary>
        public string? description { get; set; }
        ///<summary>
        ///The Facebook profile URL of the location. The URL's domain should be 'facebook.com'.
        ///</summary>
        public string? facebookUrl { get; set; }
        ///<summary>
        ///The Instagram username of the location without the '@' symbol.
        ///</summary>
        public string? instagramUsername { get; set; }
        ///<summary>
        ///The language associated with the location.
        ///</summary>
        public string? language { get; set; }
        ///<summary>
        ///The URL of the logo image for the location.
        ///</summary>
        public string? logoUrl { get; set; }
        ///<summary>
        ///A four-digit number that describes the kind of goods or services sold at the location.
        ///The merchant category code (MCC) of the location as standardized by ISO 18245.
        ///For example, 5045, for a location that sells computer goods and software.
        ///</summary>
        public string? mcc { get; set; }
        ///<summary>
        ///The merchant of the location.
        ///</summary>
        public Merchant? merchant { get; set; }
        ///<summary>
        ///The name of the location. This information appears in the Seller Dashboard as the nickname. A location name must be unique within a seller account.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The phone number of the location.
        ///</summary>
        public string? phoneNumber { get; set; }
        ///<summary>
        ///The URL of the Point of Sal background image for the location.
        ///</summary>
        public string? posBackgroundUrl { get; set; }
        ///<summary>
        ///The status of the location, e.g. whether a location is active or inactive.
        ///</summary>
        public LocationStatus? status { get; set; }
        ///<summary>
        ///The timezone of the location.
        ///</summary>
        public string? timezone { get; set; }
        ///<summary>
        ///The Twitter username of the location without the '@' symbol.
        ///</summary>
        public string? twitterUsername { get; set; }
        ///<summary>
        ///The type of the location.
        ///</summary>
        public LocationType? type { get; set; }
        ///<summary>
        ///The website URL of the location.
        ///</summary>
        public string? websiteUrl { get; set; }
    }

    ///<summary>
    ///The capabilities a location might have.
    ///</summary>
    public enum LocationCapability
    {
        ///<summary>
        ///The capability to receive automatic transfers from Square.
        ///</summary>
        AUTOMATIC_TRANSFERS,
        ///<summary>
        ///The capability to process credit card transactions with Square.
        ///</summary>
        CREDIT_CARD_PROCESSING,
    }

    ///<summary>
    ///A list of Location.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    public class LocationConnection : GraphQLObject<LocationConnection>, IConnectionWithNodes<Location>
    {
        ///<summary>
        ///A list of Location.
        ///</summary>
        public IEnumerable<Location>? nodes { get; set; }
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///A location's status.
    ///</summary>
    public enum LocationStatus
    {
        ///<summary>
        ///A location that is active for business.
        ///</summary>
        ACTIVE,
        ///<summary>
        ///A location that is not active for business. Inactive locations provide historical
        ///information. Hide inactive locations unless the user has requested to see them.
        ///</summary>
        INACTIVE,
    }

    ///<summary>
    ///A location's type.
    ///</summary>
    public enum LocationType
    {
        ///<summary>
        ///A place of business that is mobile, such as a food truck or online store.
        ///</summary>
        MOBILE,
        ///<summary>
        ///A place of business with a physical location.
        ///</summary>
        PHYSICAL,
    }

    ///<summary>
    ///Represents a unit of measurement to use with a quantity, such as ounces or inches.
    ///</summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "__typename")]
    [JsonDerivedType(typeof(MeasurementUnitAreaValue), typeDiscriminator: "MeasurementUnitAreaValue")]
    [JsonDerivedType(typeof(MeasurementUnitCustom), typeDiscriminator: "MeasurementUnitCustom")]
    [JsonDerivedType(typeof(MeasurementUnitGenericValue), typeDiscriminator: "MeasurementUnitGenericValue")]
    [JsonDerivedType(typeof(MeasurementUnitLengthValue), typeDiscriminator: "MeasurementUnitLengthValue")]
    [JsonDerivedType(typeof(MeasurementUnitTimeValue), typeDiscriminator: "MeasurementUnitTimeValue")]
    [JsonDerivedType(typeof(MeasurementUnitVolumeValue), typeDiscriminator: "MeasurementUnitVolumeValue")]
    [JsonDerivedType(typeof(MeasurementUnitWeightValue), typeDiscriminator: "MeasurementUnitWeightValue")]
    public interface IMeasurementUnit : IGraphQLObject
    {
        public MeasurementUnitAreaValue? AsMeasurementUnitAreaValue() => this as MeasurementUnitAreaValue;
        public MeasurementUnitCustom? AsMeasurementUnitCustom() => this as MeasurementUnitCustom;
        public MeasurementUnitGenericValue? AsMeasurementUnitGenericValue() => this as MeasurementUnitGenericValue;
        public MeasurementUnitLengthValue? AsMeasurementUnitLengthValue() => this as MeasurementUnitLengthValue;
        public MeasurementUnitTimeValue? AsMeasurementUnitTimeValue() => this as MeasurementUnitTimeValue;
        public MeasurementUnitVolumeValue? AsMeasurementUnitVolumeValue() => this as MeasurementUnitVolumeValue;
        public MeasurementUnitWeightValue? AsMeasurementUnitWeightValue() => this as MeasurementUnitWeightValue;
    }

    ///<summary>
    ///Unit of area used to measure a quantity.
    ///</summary>
    public enum MeasurementUnitArea
    {
        ///<summary>
        ///The area is measured in acres.
        ///</summary>
        IMPERIAL_ACRE,
        ///<summary>
        ///The area is measured in square inches.
        ///</summary>
        IMPERIAL_SQUARE_INCH,
        ///<summary>
        ///The area is measured in square feet.
        ///</summary>
        IMPERIAL_SQUARE_FOOT,
        ///<summary>
        ///The area is measured in square yards.
        ///</summary>
        IMPERIAL_SQUARE_YARD,
        ///<summary>
        ///The area is measured in square miles.
        ///</summary>
        IMPERIAL_SQUARE_MILE,
        ///<summary>
        ///The area is measured in square centimeters.
        ///</summary>
        METRIC_SQUARE_CENTIMETER,
        ///<summary>
        ///The area is measured in square meters.
        ///</summary>
        METRIC_SQUARE_METER,
        ///<summary>
        ///The area is measured in square kilometers.
        ///</summary>
        METRIC_SQUARE_KILOMETER,
    }

    ///<summary>
    ///MeasurementUnitAreaValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class MeasurementUnitAreaValue : GraphQLObject<MeasurementUnitAreaValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard area unit.
        ///</summary>
        public MeasurementUnitArea? value { get; set; }
    }

    ///<summary>
    ///The information needed to define a custom unit, provided by the seller.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class MeasurementUnitCustom : GraphQLObject<MeasurementUnitCustom>, IMeasurementUnit
    {
        ///<summary>
        ///The abbreviation of the custom unit, such as bsh (bushel). This appears in the cart for the Point of Sale app, and in reports.
        ///</summary>
        public string? abbreviation { get; set; }
        ///<summary>
        ///The name of the custom unit, for example bushel
        ///</summary>
        public string? name { get; set; }
    }

    public enum MeasurementUnitGeneric
    {
        ///<summary>
        ///The generic unit.
        ///</summary>
        UNIT,
    }

    ///<summary>
    ///MeasurementUnitGenericValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class MeasurementUnitGenericValue : GraphQLObject<MeasurementUnitGenericValue>, IMeasurementUnit
    {
        ///<summary>
        ///Reserved for API integrations that lack the ability to specify a real measurement unit
        ///</summary>
        public MeasurementUnitGeneric? value { get; set; }
    }

    ///<summary>
    ///The unit of length used to measure a quantity.
    ///</summary>
    public enum MeasurementUnitLength
    {
        ///<summary>
        ///The length is measured in inches.
        ///</summary>
        IMPERIAL_INCH,
        ///<summary>
        ///The length is measured in feet.
        ///</summary>
        IMPERIAL_FOOT,
        ///<summary>
        ///The length is measured in yards.
        ///</summary>
        IMPERIAL_YARD,
        ///<summary>
        ///The length is measured in miles.
        ///</summary>
        IMPERIAL_MILE,
        ///<summary>
        ///The length is measured in millimeters.
        ///</summary>
        METRIC_MILLIMETER,
        ///<summary>
        ///The length is measured in centimeters.
        ///</summary>
        METRIC_CENTIMETER,
        ///<summary>
        ///The length is measured in meters.
        ///</summary>
        METRIC_METER,
        ///<summary>
        ///The length is measured in kilometers.
        ///</summary>
        METRIC_KILOMETER,
    }

    ///<summary>
    ///MeasurementUnitLengthValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class MeasurementUnitLengthValue : GraphQLObject<MeasurementUnitLengthValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard length unit.
        ///</summary>
        public MeasurementUnitLength? value { get; set; }
    }

    ///<summary>
    ///Unit of time used to measure a quantity (a duration).
    ///</summary>
    public enum MeasurementUnitTime
    {
        ///<summary>
        ///The time is measured in milliseconds.
        ///</summary>
        GENERIC_MILLISECOND,
        ///<summary>
        ///The time is measured in seconds.
        ///</summary>
        GENERIC_SECOND,
        ///<summary>
        ///The time is measured in minutes.
        ///</summary>
        GENERIC_MINUTE,
        ///<summary>
        ///The time is measured in hours.
        ///</summary>
        GENERIC_HOUR,
        ///<summary>
        ///The time is measured in days.
        ///</summary>
        GENERIC_DAY,
    }

    ///<summary>
    ///MeasurementUnitTimeValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class MeasurementUnitTimeValue : GraphQLObject<MeasurementUnitTimeValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard unit of time.
        ///</summary>
        public MeasurementUnitTime? value { get; set; }
    }

    ///<summary>
    ///Describes the type of this unit and indicates which field contains the unit information.This is an ‘open’ enum.
    ///</summary>
    public enum MeasurementUnitUnitType
    {
        ///<summary>
        ///The unit details are contained in the custom_unit field.
        ///</summary>
        TYPE_CUSTOM,
        ///<summary>
        ///The unit details are contained in the area_unit field.
        ///</summary>
        TYPE_AREA,
        ///<summary>
        ///The unit details are contained in the length_unit field.
        ///</summary>
        TYPE_LENGTH,
        ///<summary>
        ///The unit details are contained in the volume_unit field.
        ///</summary>
        TYPE_VOLUME,
        ///<summary>
        ///The unit details are contained in the weight_unit field.
        ///</summary>
        TYPE_WEIGHT,
        ///<summary>
        ///The unit details are contained in the generic_unit field.
        ///</summary>
        TYPE_GENERIC,
    }

    ///<summary>
    ///The unit of volume used to measure a quantity.
    ///</summary>
    public enum MeasurementUnitVolume
    {
        ///<summary>
        ///The volume is measured in ounces.
        ///</summary>
        GENERIC_FLUID_OUNCE,
        ///<summary>
        ///The volume is measured in shots.
        ///</summary>
        GENERIC_SHOT,
        ///<summary>
        ///The volume is measured in cups.
        ///</summary>
        GENERIC_CUP,
        ///<summary>
        ///The volume is measured in pints.
        ///</summary>
        GENERIC_PINT,
        ///<summary>
        ///The volume is measured in quarts.
        ///</summary>
        GENERIC_QUART,
        ///<summary>
        ///The volume is measured in gallons.
        ///</summary>
        GENERIC_GALLON,
        ///<summary>
        ///The volume is measured in cubic inches.
        ///</summary>
        IMPERIAL_CUBIC_INCH,
        ///<summary>
        ///The volume is measured in cubic feet.
        ///</summary>
        IMPERIAL_CUBIC_FOOT,
        ///<summary>
        ///The volume is measured in cubic yards.
        ///</summary>
        IMPERIAL_CUBIC_YARD,
        ///<summary>
        ///The volume is measured in metric milliliters.
        ///</summary>
        METRIC_MILLILITER,
        ///<summary>
        ///The volume is measured in metric liters.
        ///</summary>
        METRIC_LITER,
    }

    ///<summary>
    ///MeasurementUnitVolumeValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class MeasurementUnitVolumeValue : GraphQLObject<MeasurementUnitVolumeValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard volume unit.
        ///</summary>
        public MeasurementUnitVolume? value { get; set; }
    }

    ///<summary>
    ///Unit of weight used to measure a quantity.
    ///</summary>
    public enum MeasurementUnitWeight
    {
        ///<summary>
        ///The weight is measured in ounces.
        ///</summary>
        IMPERIAL_WEIGHT_OUNCE,
        ///<summary>
        ///The weight is measured in pounds.
        ///</summary>
        IMPERIAL_POUND,
        ///<summary>
        ///The weight is measured in stones.
        ///</summary>
        IMPERIAL_STONE,
        ///<summary>
        ///The weight is measured in milligrams.
        ///</summary>
        METRIC_MILLIGRAM,
        ///<summary>
        ///The weight is measured in grams.
        ///</summary>
        METRIC_GRAM,
        ///<summary>
        ///The weight is measured in kilograms.
        ///</summary>
        METRIC_KILOGRAM,
    }

    ///<summary>
    ///MeasurementUnitWeightValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    public class MeasurementUnitWeightValue : GraphQLObject<MeasurementUnitWeightValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard unit of weight or mass.
        ///</summary>
        public MeasurementUnitWeight? value { get; set; }
    }

    ///<summary>
    ///A Square seller.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    public class Merchant : GraphQLObject<Merchant>
    {
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The business name of the merchant.
        ///</summary>
        public string? businessName { get; set; }
        ///<summary>
        ///The country associated with the merchant.
        ///</summary>
        public Country? country { get; set; }
        ///<summary>
        ///The time when the merchant was created, in RFC 3339 format. For more information, see Working with Dates.
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///The currency associated with the merchant.
        ///</summary>
        public Currency? currency { get; set; }
        ///<summary>
        ///The language associated with the merchant account.
        ///</summary>
        public string? language { get; set; }
        ///<summary>
        ///The locations for the merchant.
        ///</summary>
        public LocationConnection? locations { get; set; }
        ///<summary>
        ///The main location of the merchant.
        ///</summary>
        public Location? mainLocation { get; set; }
        ///<summary>
        ///The merchant's status.
        ///</summary>
        public MerchantStatus? status { get; set; }
    }

    ///<summary>
    ///List of Merchant.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    public class MerchantConnection : GraphQLObject<MerchantConnection>, IConnectionWithNodes<Merchant>
    {
        ///<summary>
        ///A list of Merchant.
        ///</summary>
        public IEnumerable<Merchant>? nodes { get; set; }
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///The public capabilities a merchant might have.
    ///</summary>
    public enum MerchantPublicCapability
    {
        IS_SANDBOX,
        POINT_OF_SALE,
        SELL_CANNABIS,
        UNKNOWN_CAPABILITY,
    }

    ///<summary>
    ///Merchant status.
    ///</summary>
    public enum MerchantStatus
    {
        ///<summary>
        ///A fully operational merchant account. The merchant can interact with Square products and APIs.
        ///</summary>
        ACTIVE,
        DELETED,
        ///<summary>
        ///A functionally limited merchant account. The merchant can only have limited interaction via Square APIs. The merchant cannot log in or access the seller dashboard.
        ///</summary>
        INACTIVE,
    }

    ///<summary>
    ///Application-defined data attached to an object. Metadata fields are intended to store descriptive references or
    ///associations with an entity in another system or store brief information about the object. Square does not process
    ///this field; it only stores and returns it in relevant API calls. Do not use metadata to store any sensitive
    ///information (personally identifiable information, card details, etc.).
    ///
    ///Keys written by applications must be 60 characters or less and must be in the character set [a-zA-Z0-9_-]. Entries
    ///may also include metadata generated by Square. These keys are prefixed with a namespace, separated from the key with
    ///a ':' character.
    ///
    ///Values have a max length of 255 characters.
    ///
    ///An application may have up to 10 entries per metadata field.
    ///
    ///Entries written by applications are private and can only be read or modified by the same application.
    ///
    ///See [Metadata](https://developer.squareup.com/docs/orders-api/metadata) for more information.
    ///</summary>
    public class Metadata : GraphQLObject<Metadata>
    {
        ///<summary>
        ///A list of entries.
        ///</summary>
        public IEnumerable<MetadataEntry>? entries { get; set; }
    }

    ///<summary>
    ///A key-value pair for Metadata.
    ///</summary>
    public class MetadataEntry : GraphQLObject<MetadataEntry>
    {
        ///<summary>
        ///The key of the Metadata entry
        ///</summary>
        public string? key { get; set; }
        ///<summary>
        ///The value of the Metadata entry
        ///</summary>
        public string? value { get; set; }
    }

    ///<summary>
    ///Location-specific overrides for specified properties of a `CatalogModifier` object.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class ModifierLocationOverride : GraphQLObject<ModifierLocationOverride>
    {
        ///<summary>
        ///The overridden price at the specified location. If this is unspecified, the modifier price is not overridden. 
        ///The modifier becomes free of charge at the specified location, when this `price_money` field is set to 0.
        ///</summary>
        public Money? priceMoney { get; set; }
        ///<summary>
        ///The ID of the `Location` object representing the location. This can include a deactivated location.
        ///</summary>
        public Location? location { get; set; }
    }

    ///<summary>
    ///Represents an amount of money.
    ///
    ///Money fields can be signed or unsigned. Fields that do not explicitly define whether they are signed or unsigned are
    ///considered unsigned and can only hold positive amounts. For signed fields, the sign of the value indicates the purpose
    ///of the money transfer. See
    ///[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts) for
    ///more information.
    ///</summary>
    public class Money : GraphQLObject<Money>
    {
        ///<summary>
        ///The amount of money, in the smallest denomination of the currency indicated by currency. For example, when currency
        ///is USD, amount is in cents. Monetary amounts can be positive or negative. See the specific field description to
        ///determine the meaning of the sign in a particular case.
        ///</summary>
        public long? amount { get; set; }
        ///<summary>
        ///The type of currency in currency code.
        ///</summary>
        public Currency? currency { get; set; }
    }

    ///<summary>
    ///OAuth scopes
    ///</summary>
    public enum OAuthScope
    {
        APPOINTMENTS_ALL_READ,
        APPOINTMENTS_READ,
        BANK_ACCOUNTS_READ,
        CASH_DRAWER_READ,
        CUSTOMERS_READ,
        DISPUTES_READ,
        EMPLOYEES_READ,
        GIFTCARDS_READ,
        INVENTORY_READ,
        INVOICES_READ,
        ITEMS_READ,
        LOYALTY_READ,
        MERCHANT_PROFILE_READ,
        NONE,
        ONLINE_STORE_SITE_READ,
        ONLINE_STORE_SNIPPETS_READ,
        ORDERS_READ,
        PAYMENTS_READ,
        SETTLEMENTS_READ,
        SUBSCRIPTIONS_READ,
        TIMECARDS_READ,
        TIMECARDS_SETTINGS_READ,
        VENDOR_READ,
    }

    ///<summary>
    ///Contains all information related to a single order to process with Square,
    ///including line items that specify the products to purchase.`Order` objects also
    ///include information about any associated tenders, refunds, and returns.
    ///
    ///All Connect V2 Transactions have all been converted to Orders including all associated
    ///itemization data.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class Order : GraphQLObject<Order>
    {
        ///<summary>
        ///The timestamp for when the order reached a terminal state, in RFC 3339 format (for example "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? closedAt { get; set; }
        ///<summary>
        ///The timestamp for when the order was created, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///The ID of the customer associated with the order.
        ///  
        ///You should specify a `customer_id` on the order (or the payment) to ensure that transactions
        ///are reliably linked to customers. Omitting this field might result in the creation of new
        ///[instant profiles](https://developer.squareup.com/docs/customers-api/what-it-does#instant-profiles).
        ///</summary>
        public Customer? customer { get; set; }
        ///<summary>
        ///A set-like list of DiscountCodes that have been added to the Order.
        ///</summary>
        public IEnumerable<DiscountCode>? discountCodes { get; set; }
        ///<summary>
        ///The list of all discounts associated with the order.
        ///  
        ///Discounts can be scoped to either `ORDER` or `LINE_ITEM`. For discounts scoped to `LINE_ITEM`,
        ///an `OrderLineItemAppliedDiscount` must be added to each line item that the discount applies to.
        ///For discounts with `ORDER` scope, the server generates an `OrderLineItemAppliedDiscount`
        ///for every line item.
        ///  
        ///__IMPORTANT__: If `LINE_ITEM` scope is set on any discounts in this field, using the deprecated
        ///`line_items.discounts` field results in an error. Use `line_items.applied_discounts`
        ///instead.
        ///</summary>
        public IEnumerable<OrderLineItemDiscount>? discounts { get; set; }
        ///<summary>
        ///Details about order fulfillment.
        ///  
        ///Orders can only be created with at most one fulfillment. However, orders returned
        ///by the API might contain multiple fulfillments.
        ///</summary>
        public IEnumerable<OrderFulfillment>? fulfillments { get; set; }
        ///<summary>
        ///The order's unique ID.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The line items included in the order.
        ///</summary>
        public IEnumerable<OrderLineItem>? lineItems { get; set; }
        ///<summary>
        ///The ID of the seller location that this order is associated with.
        ///</summary>
        public Location? location { get; set; }
        public string? merchantId { get; set; }
        ///<summary>
        ///Application-defined data attached to this order. Metadata fields are intended
        ///to store descriptive references or associations with an entity in another system or store brief
        ///information about the object. Square does not process this field; it only stores and returns it
        ///in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        ///identifiable information or card details).
        ///  
        ///Keys written by applications must be 60 characters or less and must be in the character set
        ///`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        ///with a namespace, separated from the key with a ':' character.
        ///  
        ///Values have a maximum length of 255 characters.
        ///  
        ///An application can have up to 10 entries per metadata field.
        ///  
        ///Entries written by applications are private and can only be read or modified by the same
        ///application.
        ///  
        ///For more information, see  [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        ///</summary>
        public Metadata? metadata { get; set; }
        ///<summary>
        ///The net amount of money due on the order.
        ///</summary>
        public Money? netAmountDue { get; set; }
        ///<summary>
        ///The net money amounts (sale money - return money).
        ///</summary>
        public OrderMoneyAmounts? netAmounts { get; set; }
        ///<summary>
        ///Pricing options for an order. The options affect how the order's price is calculated.
        ///They can be used, for example, to apply automatic price adjustments that are based on
        ///preconfigured pricing rules.
        ///</summary>
        public OrderPricingOptions? pricingOptions { get; set; }
        ///<summary>
        ///A client-specified ID to associate an entity in another system
        ///with this order.
        ///</summary>
        public string? referenceId { get; set; }
        ///<summary>
        ///The refunds that are part of this order.
        ///</summary>
        public IEnumerable<Refund>? refunds { get; set; }
        ///<summary>
        ///The rollup of the returned money amounts.
        ///</summary>
        public OrderMoneyAmounts? returnAmounts { get; set; }
        ///<summary>
        ///A collection of items from sale orders being returned in this one. Normally part of an
        ///itemized return or exchange. There is exactly one `Return` object per sale `Order` being
        ///referenced.
        ///</summary>
        public IEnumerable<OrderReturn>? returns { get; set; }
        ///<summary>
        ///A set-like list of Rewards that have been added to the Order.
        ///</summary>
        public IEnumerable<Reward>? rewards { get; set; }
        ///<summary>
        ///A positive rounding adjustment to the total of the order. This adjustment is commonly
        ///used to apply cash rounding when the minimum unit of account is smaller than the lowest physical
        ///denomination of the currency.
        ///</summary>
        public OrderRoundingAdjustment? roundingAdjustment { get; set; }
        ///<summary>
        ///A list of service charges applied to the order.
        ///</summary>
        public IEnumerable<OrderServiceCharge>? serviceCharges { get; set; }
        ///<summary>
        ///The origination details of the order.
        ///</summary>
        public OrderSource? source { get; set; }
        ///<summary>
        ///The current state of the order.
        ///</summary>
        public OrderState? state { get; set; }
        ///<summary>
        ///The list of all taxes associated with the order.
        ///  
        ///Taxes can be scoped to either `ORDER` or `LINE_ITEM`. For taxes with `LINE_ITEM` scope, an
        ///`OrderLineItemAppliedTax` must be added to each line item that the tax applies to. For taxes
        ///with `ORDER` scope, the server generates an `OrderLineItemAppliedTax` for every line item.
        ///  
        ///On reads, each tax in the list includes the total amount of that tax applied to the order.
        ///  
        ///__IMPORTANT__: If `LINE_ITEM` scope is set on any taxes in this field, using the deprecated
        ///`line_items.taxes` field results in an error. Use `line_items.applied_taxes`
        ///instead.
        ///</summary>
        public IEnumerable<OrderLineItemTax>? taxes { get; set; }
        ///<summary>
        ///The tenders that were used to pay for the order.
        ///</summary>
        public IEnumerable<IOrderTender>? tenders { get; set; }
        ///<summary>
        ///A short-term identifier for the order (such as a customer first name,
        ///table number, or auto-generated order number that resets daily).
        ///</summary>
        public string? ticketName { get; set; }
        ///<summary>
        ///The total amount of discount money to collect for the order.
        ///</summary>
        public Money? totalDiscount { get; set; }
        ///<summary>
        ///The total amount of money to collect for the order.
        ///</summary>
        public Money? totalMoney { get; set; }
        ///<summary>
        ///The total amount of money collected in service charges for the order.
        ///  
        ///Note: `total_service_charge_money` is the sum of `applied_money` fields for each individual
        ///service charge. Therefore, `total_service_charge_money` only includes inclusive tax amounts,
        ///not additive tax amounts.
        ///</summary>
        public Money? totalServiceCharge { get; set; }
        ///<summary>
        ///The total amount of tax money to collect for the order.
        ///</summary>
        public Money? totalTax { get; set; }
        ///<summary>
        ///The total amount of tip money to collect for the order.
        ///</summary>
        public Money? totalTip { get; set; }
        ///<summary>
        ///The timestamp for when the order was last updated, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///The version number, which is incremented each time an update is committed to the order.
        ///Orders not created through the API do not include a version number and
        ///therefore cannot be updated.
        ///  
        ///[Read more about working with versions](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders).
        ///</summary>
        public long? version { get; set; }
    }

    ///<summary>
    ///Represents the details of a tender with `type` `BANK_ACCOUNT`.See BankAccountPaymentDetails
    ///for more exposed details of a bank account payment.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderBankAccountTender : GraphQLObject<OrderBankAccountTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The timestamp for when the tender was created, in RFC 3339 format.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        public Customer? customer { get; set; }
        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        public Payment? payment { get; set; }
        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        public Money? processingFee { get; set; }
        ///<summary>
        ///The bank account payment's current state.
        ///</summary>
        public OrderBankAccountTenderStatus? status { get; set; }
        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        public Money? tip { get; set; }
        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        public string? transactionId { get; set; }
        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        public OrderTenderType? type { get; set; }
    }

    ///<summary>
    ///Indicates the bank account payment's current status.
    ///</summary>
    public enum OrderBankAccountTenderStatus
    {
        ///<summary>
        ///The bank account payment has been completed.
        ///</summary>
        COMPLETED,
        ///<summary>
        ///The bank account payment failed.
        ///</summary>
        FAILED,
        ///<summary>
        ///The bank account payment is in progress.
        ///</summary>
        PENDING,
    }

    ///<summary>
    ///Represents the details of a tender with `type` `BUY_NOW_PAY_LATER`.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderBuyNowPayLaterTender : GraphQLObject<OrderBuyNowPayLaterTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The Buy Now Pay Later brand.
        ///</summary>
        public OrderBuyNowPayLaterTenderBrand? buyNowPayLaterBrand { get; set; }
        ///<summary>
        ///The timestamp for when the tender was created, in RFC 3339 format.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        public Customer? customer { get; set; }
        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        public Payment? payment { get; set; }
        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        public Money? processingFee { get; set; }
        ///<summary>
        ///The buy now pay later payment's current state (such as `AUTHORIZED` or
        ///`CAPTURED`). See TenderBuyNowPayLaterDetailsStatus
        ///for possible values.
        ///</summary>
        public OrderBuyNowPayLaterTenderStatus? status { get; set; }
        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        public Money? tip { get; set; }
        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        public string? transactionId { get; set; }
        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        public OrderTenderType? type { get; set; }
    }

    public enum OrderBuyNowPayLaterTenderBrand
    {
        AFTERPAY,
        OTHER_BRAND,
    }

    public enum OrderBuyNowPayLaterTenderStatus
    {
        ///<summary>
        ///The buy now pay later payment has been authorized but not yet captured.
        ///</summary>
        AUTHORIZED,
        ///<summary>
        ///The buy now pay later payment was authorized and subsequently captured (i.e., completed).
        ///</summary>
        CAPTURED,
        ///<summary>
        ///The buy now pay later payment failed.
        ///</summary>
        FAILED,
        ///<summary>
        ///The buy now pay later payment was authorized and subsequently voided (i.e., canceled).
        ///</summary>
        VOIDED,
    }

    ///<summary>
    ///Represents additional details of a tender with `type` `CARD` or `SQUARE_GIFT_CARD`
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderCardTender : GraphQLObject<OrderCardTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The credit card's non-confidential details.
        ///</summary>
        public Card? card { get; set; }
        ///<summary>
        ///The timestamp for when the tender was created, in RFC 3339 format.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        public Customer? customer { get; set; }
        ///<summary>
        ///The method used to enter the card's details for the transaction.
        ///</summary>
        public OrderCardTenderEntryMethod? entryMethod { get; set; }
        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        public Payment? payment { get; set; }
        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        public Money? processingFee { get; set; }
        ///<summary>
        ///The credit card payment's current state (such as `AUTHORIZED` or
        ///`CAPTURED`). See TenderCardDetailsStatus
        ///for possible values.
        ///</summary>
        public OrderCardTenderStatus? status { get; set; }
        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        public Money? tip { get; set; }
        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        public string? transactionId { get; set; }
        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        public OrderTenderType? type { get; set; }
    }

    ///<summary>
    ///Indicates the method used to enter the card's details.
    ///</summary>
    public enum OrderCardTenderEntryMethod
    {
        ///<summary>
        ///The card was processed via a contactless (i.e., NFC) transaction
        ///with a Square reader.
        ///</summary>
        CONTACTLESS,
        ///<summary>
        ///The card was processed via EMV with a Square reader.
        ///</summary>
        EMV,
        ///<summary>
        ///The card information was keyed manually into Square Point of Sale or a
        ///Square-hosted web form.
        ///</summary>
        KEYED,
        ///<summary>
        ///The buyer's card details were already on file with Square.
        ///</summary>
        ON_FILE,
        ///<summary>
        ///The card was swiped through a Square reader or Square stand.
        ///</summary>
        SWIPED,
    }

    ///<summary>
    ///Indicates the card transaction's current status.
    ///</summary>
    public enum OrderCardTenderStatus
    {
        ///<summary>
        ///The card transaction has been authorized but not yet captured.
        ///</summary>
        AUTHORIZED,
        ///<summary>
        ///The card transaction was authorized and subsequently captured (i.e., completed).
        ///</summary>
        CAPTURED,
        ///<summary>
        ///The card transaction failed.
        ///</summary>
        FAILED,
        ///<summary>
        ///The card transaction was authorized and subsequently voided (i.e., canceled).
        ///</summary>
        VOIDED,
    }

    ///<summary>
    ///Represents the details of a tender with `type` `CASH`.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderCashTender : GraphQLObject<OrderCashTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The total amount of cash provided by the buyer, before change is given.
        ///</summary>
        public Money? buyerTenderedMoney { get; set; }
        ///<summary>
        ///The amount of change returned to the buyer.
        ///</summary>
        public Money? changeBackMoney { get; set; }
        ///<summary>
        ///The timestamp for when the tender was created, in RFC 3339 format.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        public Customer? customer { get; set; }
        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        public Payment? payment { get; set; }
        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        public Money? processingFee { get; set; }
        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        public Money? tip { get; set; }
        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        public string? transactionId { get; set; }
        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        public OrderTenderType? type { get; set; }
    }

    ///<summary>
    ///A list of Orders.
    ///
    ///Permissions:ORDERS_READ
    ///</summary>
    public class OrderConnection : GraphQLObject<OrderConnection>, IConnectionWithNodes<Order>
    {
        ///<summary>
        ///List of Order.
        ///</summary>
        public IEnumerable<Order>? nodes { get; set; }
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///Specific details for curbside pickup.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderCurbsidePickup : GraphQLObject<OrderCurbsidePickup>
    {
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the buyer arrived and is waiting for pickup. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? buyerArrivedAt { get; set; }
        ///<summary>
        ///Specific details for curbside pickup, such as parking number and vehicle model.
        ///</summary>
        public string? curbsideDetails { get; set; }
    }

    ///<summary>
    ///Describes delivery details of an order fulfillment.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderDelivery : GraphQLObject<OrderDelivery>
    {
        ///<summary>
        ///The delivery cancellation reason. Max length: 100 characters.
        ///</summary>
        public string? cancelReason { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment was canceled. This field is automatically
        ///set when the fulfillment `state` changes to `CANCELED`.
        ///  
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? canceledAt { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicates when the seller completed the fulfillment.
        ///This field is automatically set when  fulfillment `state` changes to `COMPLETED`.
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? completedAt { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when an order can be picked up by the courier for delivery.
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? courierPickupAt { get; set; }
        ///<summary>
        ///The period of time in which the order should be picked up by the courier after the
        ///`courier_pickup_at` timestamp.
        ///The time must be in RFC 3339 format (for example, "P1W3D").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public string? courierPickupWindowDuration { get; set; }
        ///<summary>
        ///The name of the courier provider.
        ///</summary>
        public string? courierProviderName { get; set; }
        ///<summary>
        ///The support phone number of the courier.
        ///</summary>
        public string? courierSupportPhoneNumber { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///that represents the start of the delivery period.
        ///When the fulfillment `schedule_type` is `ASAP`, the field is automatically
        ///set to the current time plus the `prep_time_duration`.
        ///Otherwise, the application can set this field while the fulfillment `state` is
        ///`PROPOSED`, `RESERVED`, or `PREPARED` (any time before the
        ///terminal state such as `COMPLETED`, `CANCELED`, and `FAILED`).
        ///  
        ///The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? deliverAt { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment was delivered to the recipient.
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? deliveredAt { get; set; }
        ///<summary>
        ///The time period after the `deliver_at` timestamp in which to deliver the order.
        ///Applications can set this field when the fulfillment `state` is
        ///`PROPOSED`, `RESERVED`, or `PREPARED` (any time before the terminal state
        ///such as `COMPLETED`, `CANCELED`, and `FAILED`).
        ///  
        ///The timestamp must be in RFC 3339 format (for example, "P1W3D").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public string? deliveryWindowDuration { get; set; }
        ///<summary>
        ///A note to provide additional instructions about how to deliver the order.
        ///</summary>
        public string? dropoffNotes { get; set; }
        ///<summary>
        ///The identifier for the delivery created by the third-party courier service.
        ///</summary>
        public string? externalDeliveryId { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicates when the seller started processing the fulfillment.
        ///This field is automatically set when the fulfillment `state` changes to `RESERVED`.
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? inProgressAt { get; set; }
        ///<summary>
        ///Whether the delivery is preferred to be no contact.
        ///</summary>
        public bool? isNoContactDelivery { get; set; }
        ///<summary>
        ///The flag to indicate the delivery is managed by a third party (ie DoorDash), which means
        ///we may not receive all recipient information for PII purposes.
        ///</summary>
        public bool? managedDelivery { get; set; }
        ///<summary>
        ///Provides additional instructions about the delivery fulfillment.
        ///It is displayed in the Square Point of Sale application and set by the API.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment was placed.
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Must be in RFC 3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? placedAt { get; set; }
        ///<summary>
        ///The duration of time it takes to prepare and deliver this fulfillment.
        ///The timestamp must be in RFC 3339 format (for example, "P1W3D").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public string? prepTimeDuration { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the seller marked the fulfillment as ready for
        ///courier pickup. This field is automatically set when the fulfillment `state` changes
        ///to PREPARED.
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? readyAt { get; set; }
        ///<summary>
        ///The contact information for the person to receive the fulfillment.
        ///</summary>
        public OrderFulfillmentRecipient? recipient { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment was rejected. This field is
        ///automatically set when the fulfillment `state` changes to `FAILED`.
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? rejectedAt { get; set; }
        ///<summary>
        ///Indicates the fulfillment delivery schedule type. If `SCHEDULED`, then
        ///`deliver_at` is required. If `ASAP`, then `prep_time_duration` is required. The default is `SCHEDULED`.
        ///</summary>
        public OrderDeliveryScheduleType? scheduleType { get; set; }
        ///<summary>
        ///The identifier for the delivery created by Square.
        ///</summary>
        public string? squareDeliveryId { get; set; }
    }

    ///<summary>
    ///The schedule type of the delivery fulfillment.
    ///</summary>
    public enum OrderDeliveryScheduleType
    {
        ///<summary>
        ///Indicates that the fulfillment to deliver as soon as possible and should be prepared
        ///immediately.
        ///</summary>
        ASAP,
        ///<summary>
        ///Indicates the fulfillment to deliver at a scheduled deliver time.
        ///</summary>
        SCHEDULED,
    }

    ///<summary>
    ///Contains details about how to fulfill this order.Orders can only be created with at most one fulfillment using the API.
    ///However, orders returned by the Orders API might contain multiple fulfillments because sellers can create multiple fulfillments using Square products such as Square Online.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderFulfillment : GraphQLObject<OrderFulfillment>
    {
        public OrderDelivery? delivery { get; set; }
        ///<summary>
        ///A list of entries pertaining to the fulfillment of an order. Each entry must reference
        ///a valid `uid` for an order line item in the `line_item_uid` field, as well as a `quantity` to
        ///fulfill.
        ///  
        ///Multiple entries can reference the same line item `uid`, as long as the total quantity among
        ///all fulfillment entries referencing a single line item does not exceed the quantity of the
        ///order's line item itself.
        ///  
        ///An order cannot be marked as `COMPLETED` before all fulfillments are `COMPLETED`,
        ///`CANCELED`, or `FAILED`. Fulfillments can be created and completed independently
        ///before order completion.
        ///</summary>
        public IEnumerable<OrderFulfillmentFulfillmentEntry>? entries { get; set; }
        ///<summary>
        ///Describes what order line items this fulfillment applies to.
        ///It can be `ALL` or `ENTRY_LIST` with a supplied list of fulfillment entries.
        ///</summary>
        public OrderFulfillmentLineItemApplication? lineItemApplication { get; set; }
        ///<summary>
        ///Application-defined data attached to this fulfillment. Metadata fields are intended
        ///to store descriptive references or associations with an entity in another system or store brief
        ///information about the object. Square does not process this field; it only stores and returns it
        ///in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        ///identifiable information or card details).
        ///  
        ///Keys written by applications must be 60 characters or less and must be in the character set
        ///`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        ///with a namespace, separated from the key with a ':' character.
        ///  
        ///Values have a maximum length of 255 characters.
        ///  
        ///An application can have up to 10 entries per metadata field.
        ///  
        ///Entries written by applications are private and can only be read or modified by the same
        ///application.
        ///  
        ///For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        ///</summary>
        public Metadata? metadata { get; set; }
        ///<summary>
        ///Contains details for a pickup fulfillment. These details are required when the fulfillment
        ///type is `PICKUP`.
        ///</summary>
        public OrderPickup? pickup { get; set; }
        ///<summary>
        ///Contains details for a shipment fulfillment. These details are required when the fulfillment type
        ///is `SHIPMENT`.
        ///  
        ///A shipment fulfillment's relationship to fulfillment `state`:
        ///`PROPOSED`: A shipment is requested.
        ///`RESERVED`: Fulfillment accepted. Shipment processing.
        ///`PREPARED`: Shipment packaged. Shipping label created.
        ///`COMPLETED`: Package has been shipped.
        ///`CANCELED`: Shipment has been canceled.
        ///`FAILED`: Shipment has failed.
        ///</summary>
        public OrderShipment? shipment { get; set; }
        ///<summary>
        ///The state of the fulfillment.
        ///</summary>
        public OrderFulfillmentState? state { get; set; }
        ///<summary>
        ///The type of the fulfillment.
        ///</summary>
        public OrderFulfillmentType? type { get; set; }
        ///<summary>
        ///A unique ID that identifies the fulfillment only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Links an order line item to a fulfillment.Each entry must reference
    ///a valid `uid` for an order line item in the `line_item_uid` field, as well as a `quantity` to
    ///fulfill.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderFulfillmentFulfillmentEntry : GraphQLObject<OrderFulfillmentFulfillmentEntry>
    {
        ///<summary>
        ///The `uid` from the order line item.
        ///</summary>
        public string? lineItemUid { get; set; }
        ///<summary>
        ///Application-defined data attached to this fulfillment entry. Metadata fields are intended
        ///to store descriptive references or associations with an entity in another system or store brief
        ///information about the object. Square does not process this field; it only stores and returns it
        ///in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        ///identifiable information or card details).
        ///  
        ///Keys written by applications must be 60 characters or less and must be in the character set
        ///`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        ///with a namespace, separated from the key with a ':' character.
        ///  
        ///Values have a maximum length of 255 characters.
        ///  
        ///An application can have up to 10 entries per metadata field.
        ///  
        ///Entries written by applications are private and can only be read or modified by the same
        ///application.
        ///  
        ///For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        ///</summary>
        public Metadata? metadata { get; set; }
        ///<summary>
        ///The quantity of the line item being fulfilled, formatted as a decimal number.
        ///For example, `"3"`.
        ///  
        ///Fulfillments for line items with a `quantity_unit` can have non-integer quantities.
        ///For example, `"1.70000"`.
        ///</summary>
        public decimal? quantity { get; set; }
        ///<summary>
        ///A unique ID that identifies the fulfillment entry only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///The `line_item_application` describes what order line items this fulfillment applies
    ///to.It can be `ALL` or `ENTRY_LIST` with a supplied list of fulfillment entries.
    ///</summary>
    public enum OrderFulfillmentLineItemApplication
    {
        ///<summary>
        ///If `ALL`, `entries` must be unset.
        ///</summary>
        ALL,
        ///<summary>
        ///If `ENTRY_LIST`, supply a list of `entries`.
        ///</summary>
        ENTRY_LIST,
    }

    ///<summary>
    ///Information about the fulfillment recipient.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderFulfillmentRecipient : GraphQLObject<OrderFulfillmentRecipient>
    {
        ///<summary>
        ///The address of the fulfillment recipient. This field is required.
        ///  
        ///If provided, the address overrides the corresponding customer profile value
        ///indicated by `customer_id`.
        ///</summary>
        public Address? address { get; set; }
        ///<summary>
        ///The ID of the customer associated with the fulfillment.
        ///  
        ///If `customer_id` is provided, the fulfillment recipient's `display_name`,
        ///`email_address`, and `phone_number` are automatically populated from the
        ///targeted customer profile. If these fields are set in the request, the request
        ///values override the information from the customer profile. If the
        ///targeted customer profile does not contain the necessary information and
        ///these fields are left unset, the request results in an error.
        ///</summary>
        public Customer? customer { get; set; }
        ///<summary>
        ///The display name of the fulfillment recipient. This field is required.
        ///  
        ///If provided, the display name overrides the corresponding customer profile value
        ///indicated by `customer_id`.
        ///</summary>
        public string? displayName { get; set; }
        ///<summary>
        ///The email address of the fulfillment recipient.
        ///  
        ///If provided, the email address overrides the corresponding customer profile value
        ///indicated by `customer_id`.
        ///</summary>
        public string? emailAddress { get; set; }
        public string? merchantId { get; set; }
        ///<summary>
        ///The phone number of the fulfillment recipient. This field is required.
        ///  
        ///If provided, the phone number overrides the corresponding customer profile value
        ///indicated by `customer_id`.
        ///</summary>
        public string? phoneNumber { get; set; }
    }

    ///<summary>
    ///The current state of this fulfillment.
    ///</summary>
    public enum OrderFulfillmentState
    {
        ///<summary>
        ///Indicates that the fulfillment was canceled.
        ///</summary>
        CANCELED,
        ///<summary>
        ///Indicates that the fulfillment was successfully completed.
        ///</summary>
        COMPLETED,
        ///<summary>
        ///Indicates that the fulfillment failed to be completed, but was not explicitly
        ///canceled.
        ///</summary>
        FAILED,
        ///<summary>
        ///Indicates that the fulfillment has been prepared.
        ///</summary>
        PREPARED,
        ///<summary>
        ///Indicates that the fulfillment has been proposed.
        ///</summary>
        PROPOSED,
        ///<summary>
        ///Indicates that the fulfillment has been reserved.
        ///</summary>
        RESERVED,
    }

    ///<summary>
    ///The type of fulfillment.
    ///</summary>
    public enum OrderFulfillmentType
    {
        ///<summary>
        ///A courier to deliver the fulfillment.
        ///</summary>
        DELIVERY,
        ///<summary>
        ///A recipient to pick up the fulfillment from a physical [location](entity:Location).
        ///</summary>
        PICKUP,
        ///<summary>
        ///A shipping carrier to ship the fulfillment.
        ///</summary>
        SHIPMENT,
    }

    ///<summary>
    ///Represents a line item in an order.Each line item describes a different
    ///product to purchase, with its own quantity and price details.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItem : GraphQLObject<OrderLineItem>
    {
        ///<summary>
        ///The list of references to discounts applied to this line item. Each
        ///`OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
        ///`OrderLineItemDiscounts` applied to the line item. On reads, the amount
        ///applied is populated.
        ///  
        ///An `OrderLineItemAppliedDiscount` is automatically created on every line item for all
        ///`ORDER` scoped discounts that are added to the order. `OrderLineItemAppliedDiscount` records
        ///for `LINE_ITEM` scoped discounts must be added in requests for the discount to apply to any
        ///line items.
        ///  
        ///To change the amount of a discount, modify the referenced top-level discount.
        ///</summary>
        public IEnumerable<OrderLineItemAppliedDiscount>? appliedDiscounts { get; set; }
        ///<summary>
        ///The list of references to service charges applied to this line item. Each
        ///`OrderLineItemAppliedServiceCharge` has a `service_charge_id` that references the `uid` of a
        ///top-level `OrderServiceCharge` applied to the line item. On reads, the amount applied is
        ///populated.
        ///  
        ///To change the amount of a service charge, modify the referenced top-level service charge.
        ///</summary>
        public IEnumerable<OrderLineItemAppliedServiceCharge>? appliedServiceCharges { get; set; }
        ///<summary>
        ///The list of references to taxes applied to this line item. Each
        ///`OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a
        ///top-level `OrderLineItemTax` applied to the line item. On reads, the
        ///amount applied is populated.
        ///  
        ///An `OrderLineItemAppliedTax` is automatically created on every line
        ///item for all `ORDER` scoped taxes added to the order. `OrderLineItemAppliedTax`
        ///records for `LINE_ITEM` scoped taxes must be added in requests for the tax
        ///to apply to any line items.
        ///  
        ///To change the amount of a tax, modify the referenced top-level tax.
        ///</summary>
        public IEnumerable<OrderLineItemAppliedTax>? appliedTaxes { get; set; }
        ///<summary>
        ///The base price for a single unit of the line item.
        ///</summary>
        public Money? basePrice { get; set; }
        ///<summary>
        ///The amount of money made in gross sales for this line item.
        ///The amount is calculated as the sum of the variation's total price and each modifier's total price.
        ///</summary>
        public Money? grossSales { get; set; }
        ///<summary>
        ///The type of line item: an itemized sale, a non-itemized sale (custom amount), or the
        ///activation or reloading of a gift card.
        ///</summary>
        public OrderLineItemItemType? itemType { get; set; }
        ///<summary>
        ///The CatalogItemVariation ID applied to this line item.
        ///</summary>
        public CatalogItemVariation? itemVariation { get; set; }
        ///<summary>
        ///Application-defined data attached to this line item. Metadata fields are intended
        ///to store descriptive references or associations with an entity in another system or store brief
        ///information about the object. Square does not process this field; it only stores and returns it
        ///in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        ///identifiable information or card details).
        ///  
        ///Keys written by applications must be 60 characters or less and must be in the character set
        ///`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        ///with a namespace, separated from the key with a ':' character.
        ///  
        ///Values have a maximum length of 255 characters.
        ///  
        ///An application can have up to 10 entries per metadata field.
        ///  
        ///Entries written by applications are private and can only be read or modified by the same
        ///application.
        ///  
        ///For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        ///</summary>
        public Metadata? metadata { get; set; }
        ///<summary>
        ///The CatalogModifiers applied to this line item.
        ///</summary>
        public IEnumerable<OrderLineItemModifier>? modifiers { get; set; }
        ///<summary>
        ///The name of the line item.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The note of the line item.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///Describes pricing adjustments that are blocked from automatic
        ///application to a line item. For more information, see
        ///[Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).
        ///</summary>
        public OrderLineItemPricingBlocklists? pricingBlocklists { get; set; }
        ///<summary>
        ///The quantity purchased, formatted as a decimal number.
        ///For example, `"3"`.
        ///  
        ///Line items with a quantity of `"0"` are automatically removed
        ///when paying for or otherwise completing the order.
        ///  
        ///Line items with a `quantity_unit` can have non-integer quantities.
        ///For example, `"1.70000"`.
        ///</summary>
        public decimal? quantity { get; set; }
        ///<summary>
        ///The unit and precision that this line item's quantity is measured in.
        ///</summary>
        public OrderQuantityUnit? quantityUnit { get; set; }
        ///<summary>
        ///The total amount of discount money to collect for the line item.
        ///</summary>
        public Money? totalDiscount { get; set; }
        ///<summary>
        ///The total amount of money to collect for this line item.
        ///</summary>
        public Money? totalMoney { get; set; }
        ///<summary>
        ///The total amount of apportioned service charge money to collect for the line item.
        ///</summary>
        public Money? totalServiceCharge { get; set; }
        ///<summary>
        ///The total amount of tax money to collect for the line item.
        ///</summary>
        public Money? totalTax { get; set; }
        ///<summary>
        ///A unique ID that identifies the line item only within this order.
        ///</summary>
        public string? uid { get; set; }
        ///<summary>
        ///The total price of all item variations sold in this line item.
        ///The price is calculated as `base_price_money` multiplied by `quantity`.
        ///It does not include modifiers.
        ///</summary>
        public Money? variationTotalPrice { get; set; }
    }

    ///<summary>
    ///Represents an applied portion of a discount to a line item in an order.Order scoped discounts have automatically applied discounts present for each line item.
    ///Line-item scoped discounts must have applied discounts added manually for any applicable line
    ///items. The corresponding applied money is automatically computed based on participating
    ///line items.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItemAppliedDiscount : GraphQLObject<OrderLineItemAppliedDiscount>
    {
        ///<summary>
        ///The amount of money applied by the discount to the line item.
        ///</summary>
        public Money? appliedMoney { get; set; }
        ///<summary>
        ///The `uid` of the discount that the applied discount represents. It must
        ///reference a discount present in the `order.discounts` field.
        ///  
        ///This field is immutable. To change which discounts apply to a line item,
        ///you must delete the discount and re-add it as a new `OrderLineItemAppliedDiscount`.
        ///</summary>
        public string? discountUid { get; set; }
        ///<summary>
        ///A unique ID that identifies the applied discount only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItemAppliedServiceCharge : GraphQLObject<OrderLineItemAppliedServiceCharge>
    {
        ///<summary>
        ///The amount of money applied by the service charge to the line item.
        ///</summary>
        public Money? appliedMoney { get; set; }
        ///<summary>
        ///The `uid` of the service charge that the applied service charge represents. It must
        ///reference a service charge present in the `order.service_charges` field.
        ///  
        ///This field is immutable. To change which service charges apply to a line item,
        ///delete and add a new `OrderLineItemAppliedServiceCharge`.
        ///</summary>
        public string? serviceChargeUid { get; set; }
        ///<summary>
        ///A unique ID that identifies the applied service charge only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents an applied portion of a tax to a line item in an order.Order-scoped taxes automatically include the applied taxes in each line item.
    ///Line item taxes must be referenced from any applicable line items.
    ///The corresponding applied money is automatically computed, based on the
    ///set of participating line items.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItemAppliedTax : GraphQLObject<OrderLineItemAppliedTax>
    {
        ///<summary>
        ///The amount of money applied by the tax to the line item.
        ///</summary>
        public Money? appliedMoney { get; set; }
        ///<summary>
        ///The `uid` of the tax for which this applied tax represents. It must reference
        ///a tax present in the `order.taxes` field.
        ///  
        ///This field is immutable. To change which taxes apply to a line item, delete and add a new
        ///`OrderLineItemAppliedTax`.
        ///</summary>
        public string? taxUid { get; set; }
        ///<summary>
        ///A unique ID that identifies the applied tax only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a discount that applies to one or more line items in an
    ///order.Fixed-amount, order-scoped discounts are distributed across all non-zero line item totals.
    ///The amount distributed to each line item is relative to the
    ///amount contributed by the item to the order subtotal.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItemDiscount : GraphQLObject<OrderLineItemDiscount>
    {
        ///<summary>
        ///The total declared monetary amount of the discount.
        ///  
        ///`amount_money` is not set for percentage-based discounts.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The amount of discount actually applied to the line item.
        ///  
        ///The amount represents the amount of money applied as a line-item scoped discount.
        ///When an amount-based discount is scoped to the entire order, the value
        ///of `applied_money` is different than `amount_money` because the total
        ///amount of the discount is distributed across all line items.
        ///</summary>
        public Money? appliedMoney { get; set; }
        ///<summary>
        ///The catalog object ID referencing CatalogDiscount.
        ///</summary>
        public CatalogDiscount? discount { get; set; }
        ///<summary>
        ///The discount code IDs corresponding to this discount.
        ///</summary>
        public IEnumerable<string>? discountCodeIds { get; set; }
        ///<summary>
        ///Application-defined data attached to this discount. Metadata fields are intended
        ///to store descriptive references or associations with an entity in another system or store brief
        ///information about the object. Square does not process this field; it only stores and returns it
        ///in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        ///identifiable information or card details).
        ///  
        ///Keys written by applications must be 60 characters or less and must be in the character set
        ///`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        ///with a namespace, separated from the key with a ':' character.
        ///  
        ///Values have a maximum length of 255 characters.
        ///  
        ///An application can have up to 10 entries per metadata field.
        ///  
        ///Entries written by applications are private and can only be read or modified by the same
        ///application.
        ///  
        ///For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        ///</summary>
        public Metadata? metadata { get; set; }
        ///<summary>
        ///The discount's name.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The percentage of the discount, as a string representation of a decimal number.
        ///A value of `7.25` corresponds to a percentage of 7.25%.
        ///  
        ///`percentage` is not set for amount-based discounts.
        ///</summary>
        public decimal? percentage { get; set; }
        ///<summary>
        ///The object ID of a pricing rule to be applied
        ///automatically to this discount. The specification and application of the discounts, to
        ///which a `pricing_rule_id` is assigned, are completely controlled by the corresponding
        ///pricing rule.
        ///</summary>
        public CatalogPricingRule? pricingRule { get; set; }
        ///<summary>
        ///The reward IDs corresponding to this discount. The application and
        ///specification of discounts that have `reward_ids` are completely controlled by the backing
        ///criteria corresponding to the reward tiers of the rewards that are added to the order
        ///through the Loyalty API. To manually unapply discounts that are the result of added rewards,
        ///the rewards must be removed from the order through the Loyalty API.
        ///</summary>
        public IEnumerable<Reward>? rewards { get; set; }
        ///<summary>
        ///Indicates the level at which the discount applies. For `ORDER` scoped discounts,
        ///Square generates references in `applied_discounts` on all order line items that do
        ///not have them. For `LINE_ITEM` scoped discounts, the discount only applies to line items
        ///with a discount reference in their `applied_discounts` field.
        ///  
        ///This field is immutable. To change the scope of a discount, you must delete
        ///the discount and re-add it as a new discount.
        ///</summary>
        public OrderLineItemDiscountScope? scope { get; set; }
        ///<summary>
        ///The type of the discount.
        ///  
        ///Discounts that do not reference a catalog object ID must have a type of
        ///`FIXED_PERCENTAGE` or `FIXED_AMOUNT`.
        ///</summary>
        public OrderLineItemDiscountType? type { get; set; }
        ///<summary>
        ///A unique ID that identifies the discount only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Indicates whether this is a line-item or order-level discount.
    ///</summary>
    public enum OrderLineItemDiscountScope
    {
        ///<summary>
        ///The discount should be applied to only line items specified by
        ///`OrderLineItemAppliedDiscount` reference records.
        ///</summary>
        LINE_ITEM,
        ///<summary>
        ///The discount should be applied to the entire order.
        ///</summary>
        ORDER,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction discount scope is currently not supported by the API.
        ///</summary>
        OTHER_DISCOUNT_SCOPE,
    }

    ///<summary>
    ///Indicates how the discount is applied to the associated line item or order.
    ///</summary>
    public enum OrderLineItemDiscountType
    {
        ///<summary>
        ///Apply the discount as a fixed monetary value (such as $1.00) off the item price.
        ///</summary>
        FIXED_AMOUNT,
        ///<summary>
        ///Apply the discount as a fixed percentage (such as 5%) off the item price.
        ///</summary>
        FIXED_PERCENTAGE,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction discount type is currently not supported by the API.
        ///</summary>
        UNKNOWN_DISCOUNT,
        ///<summary>
        ///Apply the discount as a variable amount based on the item price.
        ///  
        ///The specific discount amount of a `VARIABLE_AMOUNT` discount
        ///is assigned at the time of the purchase.
        ///</summary>
        VARIABLE_AMOUNT,
        ///<summary>
        ///Apply the discount as a variable percentage based on the item
        ///price.
        ///  
        ///The specific discount percentage of a `VARIABLE_PERCENTAGE` discount
        ///is assigned at the time of the purchase.
        ///</summary>
        VARIABLE_PERCENTAGE,
    }

    ///<summary>
    ///Represents the line item type.
    ///</summary>
    public enum OrderLineItemItemType
    {
        ///<summary>
        ///Indicates that the line item is a non-itemized sale.
        ///</summary>
        CUSTOM_AMOUNT,
        ///<summary>
        ///Indicates that the line item is a gift card sale. Gift cards sold through
        ///the Orders API are sold in an unactivated state and can be activated through the
        ///Gift Cards API using the line item `uid`.
        ///</summary>
        GIFT_CARD,
        ///<summary>
        ///Indicates that the line item is an itemized sale.
        ///</summary>
        ITEM,
    }

    ///<summary>
    ///A CatalogModifier.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItemModifier : GraphQLObject<OrderLineItemModifier>
    {
        ///<summary>
        ///The base price for the modifier.
        ///  
        ///`base_price_money` is required for ad hoc modifiers.
        ///If both `catalog_object_id` and `base_price_money` are set, `base_price_money` will
        ///override the predefined CatalogModifier price.
        ///</summary>
        public Money? basePrice { get; set; }
        ///<summary>
        ///Application-defined data attached to this order. Metadata fields are intended
        ///to store descriptive references or associations with an entity in another system or store brief
        ///information about the object. Square does not process this field; it only stores and returns it
        ///in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        ///identifiable information or card details).
        ///  
        ///Keys written by applications must be 60 characters or less and must be in the character set
        ///`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        ///with a namespace, separated from the key with a ':' character.
        ///  
        ///Values have a maximum length of 255 characters.
        ///  
        ///An application can have up to 10 entries per metadata field.
        ///  
        ///Entries written by applications are private and can only be read or modified by the same
        ///application.
        ///  
        ///For more information, see  [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        ///</summary>
        public Metadata? metadata { get; set; }
        ///<summary>
        ///The catalog object ID referencing CatalogModifier.
        ///</summary>
        public CatalogModifier? modifier { get; set; }
        ///<summary>
        ///The name of the item modifier.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The quantity of the line item modifier. The modifier quantity can be 0 or more.
        ///For example, suppose a restaurant offers a cheeseburger on the menu. When a buyer orders
        ///this item, the restaurant records the purchase by creating an `Order` object with a line item
        ///for a burger. The line item includes a line item modifier: the name is cheese and the quantity
        ///is 1. The buyer has the option to order extra cheese (or no cheese). If the buyer chooses
        ///the extra cheese option, the modifier quantity increases to 2. If the buyer does not want
        ///any cheese, the modifier quantity is set to 0.
        ///</summary>
        public decimal? quantity { get; set; }
        ///<summary>
        ///The total price of the item modifier for its line item.
        ///This is the modifier's `base_price_money` multiplied by the line item's quantity.
        ///</summary>
        public Money? totalPrice { get; set; }
        ///<summary>
        ///A unique ID that identifies the modifier only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Describes pricing adjustments that are blocked from automatic
    ///application to a line item.For more information, see
    ///[Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItemPricingBlocklists : GraphQLObject<OrderLineItemPricingBlocklists>
    {
        ///<summary>
        ///A list of discounts blocked from applying to the line item.
        ///Discounts can be blocked by the `discount_uid` (for ad hoc discounts) or
        ///the `discount_catalog_object_id` (for catalog discounts).
        ///</summary>
        public IEnumerable<OrderLineItemPricingBlocklistsBlockedDiscount>? blockedDiscounts { get; set; }
        ///<summary>
        ///A list of taxes blocked from applying to the line item.
        ///Taxes can be blocked by the `tax_uid` (for ad hoc taxes) or
        ///the `tax_catalog_object_id` (for catalog taxes).
        ///</summary>
        public IEnumerable<OrderLineItemPricingBlocklistsBlockedTax>? blockedTaxes { get; set; }
    }

    ///<summary>
    ///A discount to block from applying to a line item.The discount must be
    ///identified by either `discount_uid` or `discount_catalog_object_id`, but not both.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItemPricingBlocklistsBlockedDiscount : GraphQLObject<OrderLineItemPricingBlocklistsBlockedDiscount>
    {
        ///<summary>
        ///The `catalog_object_id` of the discount that should be blocked.
        ///Use this field to block catalog discounts. For ad hoc discounts, use the
        ///`discount_uid` field.
        ///</summary>
        public string? discountCatalogObjectId { get; set; }
        ///<summary>
        ///The `uid` of the discount that should be blocked. Use this field to block
        ///ad hoc discounts. For catalog discounts, use the `discount_catalog_object_id` field.
        ///</summary>
        public string? discountUid { get; set; }
        ///<summary>
        ///A unique ID of the `BlockedDiscount` within the order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///A tax to block from applying to a line item.The tax must be
    ///identified by either `tax_uid` or `tax_catalog_object_id`, but not both.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItemPricingBlocklistsBlockedTax : GraphQLObject<OrderLineItemPricingBlocklistsBlockedTax>
    {
        ///<summary>
        ///The `catalog_object_id` of the tax that should be blocked.
        ///Use this field to block catalog taxes. For ad hoc taxes, use the
        ///`tax_uid` field.
        ///</summary>
        public string? taxCatalogObjectId { get; set; }
        ///<summary>
        ///The `uid` of the tax that should be blocked. Use this field to block
        ///ad hoc taxes. For catalog, taxes use the `tax_catalog_object_id` field.
        ///</summary>
        public string? taxUid { get; set; }
        ///<summary>
        ///A unique ID of the `BlockedTax` within the order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a tax that applies to one or more line item in the order.Fixed-amount, order-scoped taxes are distributed across all non-zero line item totals.
    ///The amount distributed to each line item is relative to the amount the item
    ///contributes to the order subtotal.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderLineItemTax : GraphQLObject<OrderLineItemTax>
    {
        ///<summary>
        ///The amount of money applied by the tax in the order.
        ///</summary>
        public Money? appliedMoney { get; set; }
        ///<summary>
        ///Determines whether the tax was automatically applied to the order based on
        ///the catalog configuration. For an example, see
        ///[Automatically Apply Taxes to an Order](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts/auto-apply-taxes).
        ///</summary>
        public bool? autoApplied { get; set; }
        ///<summary>
        ///Application-defined data attached to this tax. Metadata fields are intended
        ///to store descriptive references or associations with an entity in another system or store brief
        ///information about the object. Square does not process this field; it only stores and returns it
        ///in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        ///identifiable information or card details).
        ///  
        ///Keys written by applications must be 60 characters or less and must be in the character set
        ///`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        ///with a namespace, separated from the key with a ':' character.
        ///  
        ///Values have a maximum length of 255 characters.
        ///  
        ///An application can have up to 10 entries per metadata field.
        ///  
        ///Entries written by applications are private and can only be read or modified by the same
        ///application.
        ///  
        ///For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        ///</summary>
        public Metadata? metadata { get; set; }
        ///<summary>
        ///The tax's name.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The percentage of the tax, as a string representation of a decimal
        ///number. For example, a value of `"7.25"` corresponds to a percentage of
        ///7.25%.
        ///</summary>
        public decimal? percentage { get; set; }
        ///<summary>
        ///Indicates the level at which the tax applies. For `ORDER` scoped taxes,
        ///Square generates references in `applied_taxes` on all order line items that do
        ///not have them. For `LINE_ITEM` scoped taxes, the tax only applies to line items
        ///with references in their `applied_taxes` field.
        ///  
        ///This field is immutable. To change the scope, you must delete the tax and
        ///re-add it as a new tax.
        ///</summary>
        public OrderLineItemTaxScope? scope { get; set; }
        ///<summary>
        ///The catalog object ID referencing CatalogTax.
        ///</summary>
        public CatalogTax? tax { get; set; }
        ///<summary>
        ///Indicates the calculation method used to apply the tax.
        ///</summary>
        public OrderLineItemTaxType? type { get; set; }
        ///<summary>
        ///A unique ID that identifies the tax only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Indicates whether this is a line-item or order-level tax.
    ///</summary>
    public enum OrderLineItemTaxScope
    {
        ///<summary>
        ///The tax should be applied only to line items specified by
        ///the `OrderLineItemAppliedTax` reference records.
        ///</summary>
        LINE_ITEM,
        ///<summary>
        ///The tax should be applied to the entire order.
        ///</summary>
        ORDER,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction tax scope is currently not supported by the API.
        ///</summary>
        OTHER_TAX_SCOPE,
    }

    ///<summary>
    ///Indicates how the tax is applied to the associated line item or order.
    ///</summary>
    public enum OrderLineItemTaxType
    {
        ///<summary>
        ///The tax is an additive tax. The tax amount is added on top of the price.
        ///For example, an item with a cost of 1.00 USD and a 10% additive tax has a total
        ///cost to the buyer of 1.10 USD.
        ///</summary>
        ADDITIVE,
        ///<summary>
        ///The tax is an inclusive tax. Inclusive taxes are already included
        ///in the line item price or order total. For example, an item with a cost of
        ///1.00 USD and a 10% inclusive tax has a pretax cost of 0.91 USD
        ///(91 cents) and a 0.09 (9 cents) tax for a total cost of 1.00 USD to
        ///the buyer.
        ///</summary>
        INCLUSIVE,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction tax type is currently not supported by the API.
        ///</summary>
        UNKNOWN_TAX,
    }

    ///<summary>
    ///A collection of various money amounts.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderMoneyAmounts : GraphQLObject<OrderMoneyAmounts>
    {
        ///<summary>
        ///The money associated with discounts.
        ///</summary>
        public Money? discount { get; set; }
        ///<summary>
        ///The money associated with service charges.
        ///</summary>
        public Money? serviceCharge { get; set; }
        ///<summary>
        ///The money associated with taxes.
        ///</summary>
        public Money? tax { get; set; }
        ///<summary>
        ///The money associated with tips.
        ///</summary>
        public Money? tip { get; set; }
        ///<summary>
        ///The total money.
        ///</summary>
        public Money? totalMoney { get; set; }
    }

    ///<summary>
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderOtherTender : GraphQLObject<OrderOtherTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The timestamp for when the tender was created, in RFC 3339 format.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        public Customer? customer { get; set; }
        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        public Payment? payment { get; set; }
        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        public Money? processingFee { get; set; }
        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        public Money? tip { get; set; }
        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        public string? transactionId { get; set; }
        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        public OrderTenderType? type { get; set; }
    }

    ///<summary>
    ///Contains details necessary to fulfill a pickup order.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderPickup : GraphQLObject<OrderPickup>
    {
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment was accepted. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? acceptedAt { get; set; }
        ///<summary>
        ///The duration of time after which an open and accepted pickup fulfillment
        ///is automatically moved to the `COMPLETED` state. The duration must be in RFC 3339
        ///format (for example, "P1W3D").
        ///  
        ///If not set, this pickup fulfillment remains accepted until it is canceled or completed.
        ///  
        ///Example for 2 days, 12 hours, 30 minutes, and 15 seconds: P2DT12H30M15S
        ///</summary>
        public string? autoCompleteDuration { get; set; }
        ///<summary>
        ///A description of why the pickup was canceled. The maximum length: 100 characters.
        ///</summary>
        public string? cancelReason { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment was canceled. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? canceledAt { get; set; }
        ///<summary>
        ///Specific details for curbside pickup. These details can only be populated if `is_curbside_pickup` is set to `true`.
        ///</summary>
        public OrderCurbsidePickup? curbsidePickup { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment expired. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? expiredAt { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when this fulfillment expires if it is not accepted. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z"). The expiration time can only be set up to 7 days in the future.
        ///If `expires_at` is not set, this pickup fulfillment is automatically accepted when
        ///placed.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? expiresAt { get; set; }
        ///<summary>
        ///If set to `true`, indicates that this pickup order is for curbside pickup, not in-store pickup.
        ///</summary>
        public bool? isCurbsidePickup { get; set; }
        ///<summary>
        ///A note to provide additional instructions about the pickup
        ///fulfillment displayed in the Square Point of Sale application and set by the API.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment was picked up by the recipient. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? pickedUpAt { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///that represents the start of the pickup window. Must be in RFC 3339 timestamp format, e.g.,
        ///"2016-09-04T23:59:33.123Z".
        ///  
        ///For fulfillments with the schedule type `ASAP`, this is automatically set
        ///to the current time plus the expected duration to prepare the fulfillment.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? pickupAt { get; set; }
        ///<summary>
        ///The window of time in which the order should be picked up after the `pickup_at` timestamp.
        ///Must be in RFC 3339 duration format, e.g., "P1W3D". Can be used as an
        ///informational guideline for merchants.
        ///  
        ///Example for 2 days, 12 hours, 30 minutes, and 15 seconds: P2DT12H30M15S
        ///</summary>
        public string? pickupWindowDuration { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment was placed. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? placedAt { get; set; }
        ///<summary>
        ///The duration of time it takes to prepare this fulfillment.
        ///The duration must be in RFC 3339 format (for example, "P1W3D").
        ///  
        ///Example for 2 days, 12 hours, 30 minutes, and 15 seconds: P2DT12H30M15S
        ///</summary>
        public string? prepTimeDuration { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment is marked as ready for pickup. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? readyAt { get; set; }
        ///<summary>
        ///Information about the person to pick up this fulfillment from a physical
        ///location.
        ///</summary>
        public OrderFulfillmentRecipient? recipient { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the fulfillment was rejected. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? rejectedAt { get; set; }
        ///<summary>
        ///The schedule type of the pickup fulfillment. Defaults to `SCHEDULED`.
        ///</summary>
        public OrderPickupScheduleType? scheduleType { get; set; }
    }

    ///<summary>
    ///The schedule type of the pickup fulfillment.
    ///</summary>
    public enum OrderPickupScheduleType
    {
        ///<summary>
        ///Indicates that the fulfillment will be picked up as soon as possible and
        ///should be prepared immediately.
        ///</summary>
        ASAP,
        ///<summary>
        ///Indicates that the fulfillment will be picked up at a scheduled pickup time.
        ///</summary>
        SCHEDULED,
    }

    ///<summary>
    ///Pricing options for an order.The options affect how the order's price is calculated.
    ///They can be used, for example, to apply automatic price adjustments that are based on preconfigured
    ///pricing rules.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderPricingOptions : GraphQLObject<OrderPricingOptions>
    {
        ///<summary>
        ///The option to determine whether pricing rule-based
        ///discounts are automatically applied to an order.
        ///</summary>
        public bool? autoApplyDiscounts { get; set; }
        ///<summary>
        ///The option to determine whether rule-based taxes are automatically
        ///applied to an order when the criteria of the corresponding rules are met.
        ///</summary>
        public bool? autoApplyTaxes { get; set; }
    }

    ///<summary>
    ///Contains the measurement unit for a quantity and a precision that
    ///specifies the number of digits after the decimal point for decimal quantities.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderQuantityUnit : GraphQLObject<OrderQuantityUnit>
    {
        ///<summary>
        ///The catalog object ID referencing the
        ///CatalogMeasurementUnit.
        ///  
        ///This field is set when this is a catalog-backed measurement unit.
        ///</summary>
        public string? catalogObjectId { get; set; }
        ///<summary>
        ///A MeasurementUnit that represents the
        ///unit of measure for the quantity.
        ///</summary>
        public IMeasurementUnit? measurementUnit { get; set; }
        ///<summary>
        ///For non-integer quantities, represents the number of digits after the decimal point that are
        ///recorded for this quantity.
        ///  
        ///For example, a precision of 1 allows quantities such as `"1.0"` and `"1.1"`, but not `"1.01"`.
        ///  
        ///Min: 0. Max: 5.
        ///</summary>
        public int? precision { get; set; }
    }

    ///<summary>
    ///The set of line items, service charges, taxes, discounts, tips, and other items being returned in an order.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderReturn : GraphQLObject<OrderReturn>
    {
        ///<summary>
        ///An aggregate monetary value being returned by this return entry.
        ///</summary>
        public OrderMoneyAmounts? amounts { get; set; }
        ///<summary>
        ///A collection of references to discounts being returned for an order, including the total
        ///applied discount amount to be returned. The discounts must reference a top-level discount ID
        ///from the source order.
        ///</summary>
        public IEnumerable<OrderReturnDiscount>? discounts { get; set; }
        ///<summary>
        ///A collection of line items that are being returned.
        ///</summary>
        public IEnumerable<OrderReturnLineItem>? lineItems { get; set; }
        ///<summary>
        ///A positive or negative rounding adjustment to the total value being returned. Adjustments are commonly
        ///used to apply cash rounding when the minimum unit of the account is smaller than the lowest
        ///physical denomination of the currency.
        ///</summary>
        public OrderRoundingAdjustment? roundingAdjustment { get; set; }
        ///<summary>
        ///A collection of service charges that are being returned.
        ///</summary>
        public IEnumerable<OrderReturnServiceCharge>? serviceCharges { get; set; }
        ///<summary>
        ///An order that contains the original sale of these return line items. This is unset
        ///for unlinked returns.
        ///</summary>
        public Order? source { get; set; }
        ///<summary>
        ///A collection of references to taxes being returned for an order, including the total
        ///applied tax amount to be returned. The taxes must reference a top-level tax ID from the source
        ///order.
        ///</summary>
        public IEnumerable<OrderReturnTax>? taxes { get; set; }
        ///<summary>
        ///A unique ID that identifies the return only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a discount being returned that applies to one or more return line items in an
    ///order.Fixed-amount, order-scoped discounts are distributed across all non-zero return line item totals.
    ///The amount distributed to each return line item is relative to that item’s contribution to the
    ///order subtotal.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderReturnDiscount : GraphQLObject<OrderReturnDiscount>
    {
        ///<summary>
        ///The total declared monetary amount of the discount.
        ///  
        ///`amount_money` is not set for percentage-based discounts.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The amount of discount actually applied to this line item. When an amount-based
        ///discount is at the order level, this value is different from `amount_money` because the discount
        ///is distributed across the line items.
        ///</summary>
        public Money? appliedMoney { get; set; }
        ///<summary>
        ///The catalog object ID referencing CatalogDiscount.
        ///</summary>
        public CatalogDiscount? discount { get; set; }
        ///<summary>
        ///The discount's name.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The percentage of the tax, as a string representation of a decimal number.
        ///A value of `"7.25"` corresponds to a percentage of 7.25%.
        ///  
        ///`percentage` is not set for amount-based discounts.
        ///</summary>
        public decimal? percentage { get; set; }
        ///<summary>
        ///Indicates the level at which the `OrderReturnDiscount` applies. For `ORDER` scoped
        ///discounts, the server generates references in `applied_discounts` on all
        ///`OrderReturnLineItem`s. For `LINE_ITEM` scoped discounts, the discount is only applied to
        ///`OrderReturnLineItem`s with references in their `applied_discounts` field.
        ///</summary>
        public OrderLineItemDiscountScope? scope { get; set; }
        ///<summary>
        ///The discount `uid` from the order that contains the original application of this discount.
        ///</summary>
        public string? sourceDiscountUid { get; set; }
        ///<summary>
        ///The type of the discount. If it is created by the API, it is `FIXED_PERCENTAGE` or `FIXED_AMOUNT`.
        ///  
        ///Discounts that do not reference a catalog object ID must have a type of
        ///`FIXED_PERCENTAGE` or `FIXED_AMOUNT`.
        ///</summary>
        public OrderLineItemDiscountType? type { get; set; }
        ///<summary>
        ///A unique ID that identifies the returned discount only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///The line item being returned in an order.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderReturnLineItem : GraphQLObject<OrderReturnLineItem>
    {
        ///<summary>
        ///The list of references to `OrderReturnDiscount` entities applied to the return line item. Each
        ///`OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
        ///`OrderReturnDiscount` applied to the return line item. On reads, the applied amount
        ///is populated.
        ///</summary>
        public IEnumerable<OrderLineItemAppliedDiscount>? appliedDiscounts { get; set; }
        ///<summary>
        ///The list of references to `OrderReturnServiceCharge` entities applied to the return
        ///line item. Each `OrderLineItemAppliedServiceCharge` has a `service_charge_uid` that
        ///references the `uid` of a top-level `OrderReturnServiceCharge` applied to the return line
        ///item. On reads, the applied amount is populated.
        ///</summary>
        public IEnumerable<OrderLineItemAppliedServiceCharge>? appliedServiceCharges { get; set; }
        ///<summary>
        ///The list of references to `OrderReturnTax` entities applied to the return line item. Each
        ///`OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
        ///`OrderReturnTax` applied to the return line item. On reads, the applied amount
        ///is populated.
        ///</summary>
        public IEnumerable<OrderLineItemAppliedTax>? appliedTaxes { get; set; }
        ///<summary>
        ///The base price for a single unit of the line item.
        ///</summary>
        public Money? basePrice { get; set; }
        ///<summary>
        ///The gross return amount of money calculated as (item base price + modifiers price) * quantity.
        ///</summary>
        public Money? grossReturn { get; set; }
        ///<summary>
        ///The CatalogItemVariation ID applied to this return line item.
        ///</summary>
        public CatalogItemVariation? itemVariation { get; set; }
        ///<summary>
        ///The CatalogModifiers applied to this line item.
        ///</summary>
        public IEnumerable<OrderReturnLineItemModifier>? modifiers { get; set; }
        ///<summary>
        ///The name of the line item.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The note of the return line item.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The quantity returned, formatted as a decimal number.
        ///For example, `"3"`.
        ///  
        ///Line items with a `quantity_unit` can have non-integer quantities.
        ///For example, `"1.70000"`.
        ///</summary>
        public decimal? quantity { get; set; }
        ///<summary>
        ///The unit and precision that this return line item's quantity is measured in.
        ///</summary>
        public OrderQuantityUnit? quantityUnit { get; set; }
        ///<summary>
        ///The `uid` of the line item in the original sale order.
        ///</summary>
        public string? sourceLineItemUid { get; set; }
        ///<summary>
        ///The total amount of discount money to return for the line item.
        ///</summary>
        public Money? totalDiscount { get; set; }
        ///<summary>
        ///The total amount of money to return for this line item.
        ///</summary>
        public Money? totalMoney { get; set; }
        ///<summary>
        ///The total amount of apportioned service charge money to return for the line item.
        ///</summary>
        public Money? totalServiceCharge { get; set; }
        ///<summary>
        ///The total amount of tax money to return for the line item.
        ///</summary>
        public Money? totalTax { get; set; }
        ///<summary>
        ///A unique ID for this return line-item entry.
        ///</summary>
        public string? uid { get; set; }
        ///<summary>
        ///The name of the variation applied to this return line item.
        ///</summary>
        public string? variationName { get; set; }
        ///<summary>
        ///The total price of all item variations returned in this line item.
        ///The price is calculated as `base_price_money` multiplied by `quantity` and
        ///does not include modifiers.
        ///</summary>
        public Money? variationTotalPrice { get; set; }
    }

    ///<summary>
    ///A line item modifier being returned.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderReturnLineItemModifier : GraphQLObject<OrderReturnLineItemModifier>
    {
        ///<summary>
        ///The base price for the modifier.
        ///  
        ///`base_price_money` is required for ad hoc modifiers.
        ///If both `catalog_object_id` and `base_price_money` are set, `base_price_money` overrides the predefined CatalogModifier price.
        ///</summary>
        public Money? basePrice { get; set; }
        ///<summary>
        ///The catalog object ID referencing CatalogModifier.
        ///</summary>
        public CatalogModifier? modifier { get; set; }
        ///<summary>
        ///The name of the item modifier.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The quantity of the line item modifier. The modifier quantity can be 0 or more.
        ///For example, suppose a restaurant offers a cheeseburger on the menu. When a buyer orders
        ///this item, the restaurant records the purchase by creating an `Order` object with a line item
        ///for a burger. The line item includes a line item modifier: the name is cheese and the quantity
        ///is 1. The buyer has the option to order extra cheese (or no cheese). If the buyer chooses
        ///the extra cheese option, the modifier quantity increases to 2. If the buyer does not want
        ///any cheese, the modifier quantity is set to 0.
        ///</summary>
        public decimal? quantity { get; set; }
        ///<summary>
        ///The modifier `uid` from the order's line item that contains the
        ///original sale of this line item modifier.
        ///</summary>
        public string? sourceModifierUid { get; set; }
        ///<summary>
        ///The total price of the item modifier for its line item.
        ///This is the modifier's `base_price_money` multiplied by the line item's quantity.
        ///</summary>
        public Money? totalPrice { get; set; }
        ///<summary>
        ///A unique ID that identifies the return modifier only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents the service charge applied to the original order.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderReturnServiceCharge : GraphQLObject<OrderReturnServiceCharge>
    {
        ///<summary>
        ///The amount of a non-percentage-based service charge.
        ///  
        ///Either `percentage` or `amount_money` should be set, but not both.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The amount of money applied to the order by the service charge, including
        ///any inclusive tax amounts, as calculated by Square.
        ///  
        ///- For fixed-amount service charges, `applied_money` is equal to `amount_money`.
        ///- For percentage-based service charges, `applied_money` is the money calculated using the percentage.
        ///</summary>
        public Money? appliedMoney { get; set; }
        ///<summary>
        ///The list of references to `OrderReturnTax` entities applied to the
        ///`OrderReturnServiceCharge`. Each `OrderLineItemAppliedTax` has a `tax_uid`
        ///that references the `uid` of a top-level `OrderReturnTax` that is being
        ///applied to the `OrderReturnServiceCharge`. On reads, the applied amount is
        ///populated.
        ///</summary>
        public IEnumerable<OrderLineItemAppliedTax>? appliedTaxes { get; set; }
        ///<summary>
        ///The calculation phase after which to apply the service charge.
        ///</summary>
        public OrderServiceChargeCalculationPhase? calculationPhase { get; set; }
        ///<summary>
        ///The name of the service charge.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The percentage of the service charge, as a string representation of
        ///a decimal number. For example, a value of `"7.25"` corresponds to a
        ///percentage of 7.25%.
        ///  
        ///Either `percentage` or `amount_money` should be set, but not both.
        ///</summary>
        public decimal? percentage { get; set; }
        ///<summary>
        ///Indicates the level at which the apportioned service charge applies. For `ORDER`
        ///scoped service charges, Square generates references in `applied_service_charges` on
        ///all order line items that do not have them. For `LINE_ITEM` scoped service charges,
        ///the service charge only applies to line items with a service charge reference in their
        ///`applied_service_charges` field.
        ///  
        ///This field is immutable. To change the scope of an apportioned service charge, you must delete
        ///the apportioned service charge and re-add it as a new apportioned service charge.
        ///</summary>
        public OrderServiceChargeScope? scope { get; set; }
        ///<summary>
        ///The catalog object ID of the associated OrderServiceCharge.
        ///</summary>
        public CatalogServiceCharge? serviceCharge { get; set; }
        ///<summary>
        ///The service charge `uid` from the order containing the original
        ///service charge. `source_service_charge_uid` is `null` for
        ///unlinked returns.
        ///</summary>
        public string? sourceServiceChargeUid { get; set; }
        ///<summary>
        ///Indicates whether the surcharge can be taxed. Service charges
        ///calculated in the `TOTAL_PHASE` cannot be marked as taxable.
        ///</summary>
        public bool? taxable { get; set; }
        ///<summary>
        ///The total amount of money to collect for the service charge.
        ///  
        ///__NOTE__: If an inclusive tax is applied to the service charge, `total_money`
        ///does not equal `applied_money` plus `total_tax_money` because the inclusive
        ///tax amount is already included in both `applied_money` and `total_tax_money`.
        ///</summary>
        public Money? totalMoney { get; set; }
        ///<summary>
        ///The total amount of tax money to collect for the service charge.
        ///</summary>
        public Money? totalTax { get; set; }
        ///<summary>
        ///The treatment type of the service charge.
        ///</summary>
        public OrderServiceChargeTreatmentType? treatmentType { get; set; }
        ///<summary>
        ///A unique ID that identifies the return service charge only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a tax being returned that applies to one or more return line items in an order.Fixed-amount, order-scoped taxes are distributed across all non-zero return line item totals.
    ///The amount distributed to each return line item is relative to that item’s contribution to the
    ///order subtotal.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderReturnTax : GraphQLObject<OrderReturnTax>
    {
        ///<summary>
        ///The amount of money applied by the tax in an order.
        ///</summary>
        public Money? appliedMoney { get; set; }
        ///<summary>
        ///The tax's name.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The percentage of the tax, as a string representation of a decimal number.
        ///For example, a value of `"7.25"` corresponds to a percentage of 7.25%.
        ///</summary>
        public decimal? percentage { get; set; }
        ///<summary>
        ///Indicates the level at which the `OrderReturnTax` applies. For `ORDER` scoped
        ///taxes, Square generates references in `applied_taxes` on all
        ///`OrderReturnLineItem`s. For `LINE_ITEM` scoped taxes, the tax is only applied to
        ///`OrderReturnLineItem`s with references in their `applied_discounts` field.
        ///</summary>
        public OrderLineItemTaxScope? scope { get; set; }
        ///<summary>
        ///The tax `uid` from the order that contains the original tax charge.
        ///</summary>
        public string? sourceTaxUid { get; set; }
        ///<summary>
        ///The catalog object ID referencing CatalogTax.
        ///</summary>
        public CatalogTax? tax { get; set; }
        ///<summary>
        ///Indicates the calculation method used to apply the tax.
        ///</summary>
        public OrderLineItemTaxType? type { get; set; }
        ///<summary>
        ///A unique ID that identifies the returned tax only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///A rounding adjustment of the money being returned.Commonly used to apply cash rounding
    ///when the minimum unit of the account is smaller than the lowest physical denomination of the currency.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderRoundingAdjustment : GraphQLObject<OrderRoundingAdjustment>
    {
        ///<summary>
        ///The actual rounding adjustment amount.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The name of the rounding adjustment from the original sale order.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///A unique ID that identifies the rounding adjustment only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a service charge applied to an order.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderServiceCharge : GraphQLObject<OrderServiceCharge>
    {
        ///<summary>
        ///The amount of a non-percentage-based service charge.
        ///  
        ///Exactly one of `percentage` or `amount_money` should be set.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The amount of money applied to the order by the service charge,
        ///including any inclusive tax amounts, as calculated by Square.
        ///  
        ///- For fixed-amount service charges, `applied_money` is equal to `amount_money`.
        ///- For percentage-based service charges, `applied_money` is the money
        ///calculated using the percentage.
        ///</summary>
        public Money? appliedMoney { get; set; }
        ///<summary>
        ///The list of references to the taxes applied to this service charge. Each
        ///`OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
        ///`OrderLineItemTax` that is being applied to this service charge. On reads, the amount applied
        ///is populated.
        ///  
        ///An `OrderLineItemAppliedTax` is automatically created on every taxable service charge
        ///for all `ORDER` scoped taxes that are added to the order. `OrderLineItemAppliedTax` records
        ///for `LINE_ITEM` scoped taxes must be added in requests for the tax to apply to any taxable
        ///service charge. Taxable service charges have the `taxable` field set to `true` and calculated
        ///in the `SUBTOTAL_PHASE`.
        ///  
        ///To change the amount of a tax, modify the referenced top-level tax.
        ///</summary>
        public IEnumerable<OrderLineItemAppliedTax>? appliedTaxes { get; set; }
        ///<summary>
        ///The calculation phase at which to apply the service charge.
        ///</summary>
        public OrderServiceChargeCalculationPhase? calculationPhase { get; set; }
        ///<summary>
        ///Application-defined data attached to this service charge. Metadata fields are intended
        ///to store descriptive references or associations with an entity in another system or store brief
        ///information about the object. Square does not process this field; it only stores and returns it
        ///in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        ///identifiable information or card details).
        ///  
        ///Keys written by applications must be 60 characters or less and must be in the character set
        ///`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        ///with a namespace, separated from the key with a ':' character.
        ///  
        ///Values have a maximum length of 255 characters.
        ///  
        ///An application can have up to 10 entries per metadata field.
        ///  
        ///Entries written by applications are private and can only be read or modified by the same
        ///application.
        ///  
        ///For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        ///</summary>
        public Metadata? metadata { get; set; }
        ///<summary>
        ///The name of the service charge.
        ///</summary>
        public string? name { get; set; }
        ///<summary>
        ///The service charge percentage as a string representation of a
        ///decimal number. For example, `"7.25"` indicates a service charge of 7.25%.
        ///  
        ///Exactly 1 of `percentage` or `amount_money` should be set.
        ///</summary>
        public decimal? percentage { get; set; }
        ///<summary>
        ///Indicates the level at which the apportioned service charge applies. For `ORDER`
        ///scoped service charges, Square generates references in `applied_service_charges` on
        ///all order line items that do not have them. For `LINE_ITEM` scoped service charges,
        ///the service charge only applies to line items with a service charge reference in their
        ///`applied_service_charges` field.
        ///  
        ///This field is immutable. To change the scope of an apportioned service charge, you must delete
        ///the apportioned service charge and re-add it as a new apportioned service charge.
        ///</summary>
        public OrderServiceChargeScope? scope { get; set; }
        ///<summary>
        ///The catalog object ID referencing the service charge CatalogObject.
        ///</summary>
        public CatalogServiceCharge? serviceCharge { get; set; }
        ///<summary>
        ///Indicates whether the service charge can be taxed. If set to `true`,
        ///order-level taxes automatically apply to the service charge. Note that
        ///service charges calculated in the `TOTAL_PHASE` cannot be marked as taxable.
        ///</summary>
        public bool? taxable { get; set; }
        ///<summary>
        ///The total amount of money to collect for the service charge.
        ///  
        ///__Note__: If an inclusive tax is applied to the service charge,
        ///`total_money` does not equal `applied_money` plus `total_tax_money`
        ///because the inclusive tax amount is already included in both
        ///`applied_money` and `total_tax_money`.
        ///</summary>
        public Money? totalMoney { get; set; }
        ///<summary>
        ///The total amount of tax money to collect for the service charge.
        ///</summary>
        public Money? totalTax { get; set; }
        ///<summary>
        ///The treatment type of the service charge.
        ///</summary>
        public OrderServiceChargeTreatmentType? treatmentType { get; set; }
        ///<summary>
        ///The type of the service charge.
        ///</summary>
        public OrderServiceChargeType? type { get; set; }
        ///<summary>
        ///A unique ID that identifies the service charge only within this order.
        ///</summary>
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a phase in the process of calculating order totals.Service charges are applied after the indicated phase.
    ///
    ///[Read more about how order totals are calculated.](https://developer.squareup.com/docs/orders-api/how-it-works#how-totals-are-calculated)
    ///</summary>
    public enum OrderServiceChargeCalculationPhase
    {
        ///<summary>
        ///The service charge is calculated as a compounding adjustment
        ///after any discounts and percentage based apportioned service charges,
        ///but before any tax considerations.
        ///</summary>
        APPORTIONED_AMOUNT_PHASE,
        ///<summary>
        ///The service charge is calculated as a compounding adjustment
        ///after any discounts, but before amount based apportioned service charges
        ///and any tax considerations.
        ///</summary>
        APPORTIONED_PERCENTAGE_PHASE,
        ///<summary>
        ///The service charge is applied after discounts, but before
        ///taxes.
        ///</summary>
        SUBTOTAL_PHASE,
        ///<summary>
        ///The service charge is applied after all discounts and taxes
        ///are applied.
        ///</summary>
        TOTAL_PHASE,
    }

    ///<summary>
    ///Indicates whether this is a line-item or order-level apportioned
    ///service charge.
    ///</summary>
    public enum OrderServiceChargeScope
    {
        ///<summary>
        ///The service charge should be applied to only line items specified by
        ///`OrderLineItemAppliedServiceCharge` reference records.
        ///</summary>
        LINE_ITEM,
        ///<summary>
        ///The service charge should be applied to the entire order.
        ///</summary>
        ORDER,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction service charge scope is currently not supported by the API.
        ///</summary>
        OTHER_SERVICE_CHARGE_SCOPE,
    }

    ///<summary>
    ///Indicates whether the service charge will be treated as a value-holding line item or
    ///apportioned toward a line item.
    ///</summary>
    public enum OrderServiceChargeTreatmentType
    {
        APPORTIONED_TREATMENT,
        LINE_ITEM_TREATMENT,
    }

    public enum OrderServiceChargeType
    {
        AUTO_GRATUITY,
        CUSTOM,
    }

    ///<summary>
    ///Contains the details necessary to fulfill a shipment order.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderShipment : GraphQLObject<OrderShipment>
    {
        ///<summary>
        ///A description of why the shipment was canceled.
        ///</summary>
        public string? cancelReason { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating the shipment was canceled.
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? canceledAt { get; set; }
        ///<summary>
        ///The shipping carrier being used to ship this fulfillment (such as UPS, FedEx, or USPS).
        ///</summary>
        public string? carrier { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the shipment is expected to be delivered to the shipping carrier.
        ///The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? expectedShippedAt { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the shipment failed to be completed. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? failedAt { get; set; }
        ///<summary>
        ///A description of why the shipment failed to be completed.
        ///</summary>
        public string? failureReason { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when this fulfillment was moved to the `RESERVED` state, which  indicates that preparation
        ///of this shipment has begun. The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? inProgressAt { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when this fulfillment was moved to the `PREPARED` state, which indicates that the
        ///fulfillment is packaged. The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? packagedAt { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when the shipment was requested. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? placedAt { get; set; }
        ///<summary>
        ///Information about the person to receive this shipment fulfillment.
        ///</summary>
        public OrderFulfillmentRecipient? recipient { get; set; }
        ///<summary>
        ///The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        ///indicating when this fulfillment was moved to the `COMPLETED` state, which indicates that
        ///the fulfillment has been given to the shipping carrier. The timestamp must be in RFC 3339 format
        ///(for example, "2016-09-04T23:59:33.123Z").
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? shippedAt { get; set; }
        ///<summary>
        ///A note with additional information for the shipping carrier.
        ///</summary>
        public string? shippingNote { get; set; }
        ///<summary>
        ///A description of the type of shipping product purchased from the carrier
        ///(such as First Class, Priority, or Express).
        ///</summary>
        public string? shippingType { get; set; }
        ///<summary>
        ///The reference number provided by the carrier to track the shipment's progress.
        ///</summary>
        public string? trackingNumber { get; set; }
        ///<summary>
        ///A link to the tracking webpage on the carrier's website.
        ///</summary>
        public string? trackingUrl { get; set; }
    }

    ///<summary>
    ///Criteria to sort results by. The chronological order in which results are returned. Defaults to createdAt_DESC.
    ///
    ///When using a BasicDateTimeFilter, OrderSort must match the timestamp field that the BasicDateTimeFilter uses to filter. For example, If you set your sort_field to closedAt and you use a BasicDateTimeFilter,
    ///your BasicDateTimeFilter must filter for orders by their closedAt date. If this field does not match the timestamp field in BasicDateTimeFilter, it will return an error.
    ///</summary>
    public enum OrderSort
    {
        closedAt_ASC,
        closedAt_DESC,
        createdAt_ASC,
        createdAt_DESC,
        updatedAt_ASC,
        updatedAt_DESC,
    }

    ///<summary>
    ///Represents the origination details of an order.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderSource : GraphQLObject<OrderSource>
    {
        ///<summary>
        ///The name used to identify the place (physical or digital) that an order originates.
        ///If unset, the name defaults to the name of the application that created the order.
        ///</summary>
        public string? name { get; set; }
    }

    ///<summary>
    ///Represents the details of a tender with `type` `SQUARE_ACCOUNT`.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class OrderSquareAccountTender : GraphQLObject<OrderSquareAccountTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The timestamp for when the tender was created, in RFC 3339 format.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        public Customer? customer { get; set; }
        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        public Payment? payment { get; set; }
        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        public Money? processingFee { get; set; }
        ///<summary>
        ///The Square Account payment's current state (such as `AUTHORIZED` or
        ///`CAPTURED`). See TenderSquareAccountDetailsStatus
        ///for possible values.
        ///</summary>
        public OrderSquareAccountTenderStatus? status { get; set; }
        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        public Money? tip { get; set; }
        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        public string? transactionId { get; set; }
        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        public OrderTenderType? type { get; set; }
    }

    public enum OrderSquareAccountTenderStatus
    {
        ///<summary>
        ///The Square Account payment has been authorized but not yet captured.
        ///</summary>
        AUTHORIZED,
        ///<summary>
        ///The Square Account payment was authorized and subsequently captured (i.e., completed).
        ///</summary>
        CAPTURED,
        ///<summary>
        ///The Square Account payment failed.
        ///</summary>
        FAILED,
        ///<summary>
        ///The Square Account payment was authorized and subsequently voided (i.e., canceled).
        ///</summary>
        VOIDED,
    }

    ///<summary>
    ///The state of the order.
    ///</summary>
    public enum OrderState
    {
        ///<summary>
        ///Indicates that the order is canceled. Canceled orders are not paid. This is a terminal state.
        ///</summary>
        CANCELED,
        ///<summary>
        ///Indicates that the order is completed. Completed orders are fully paid. This is a terminal state.
        ///</summary>
        COMPLETED,
        ///<summary>
        ///Indicates that the order is in a draft state. Draft orders can be updated,
        ///but cannot be paid or fulfilled.
        ///For more information, see [Create Orders](https://developer.squareup.com/docs/orders-api/create-orders).
        ///</summary>
        DRAFT,
        ///<summary>
        ///Indicates that the order is open. Open orders can be updated.
        ///</summary>
        OPEN,
    }

    ///<summary>
    ///Represents a tender (i.e., a method of payment) used in a Square transaction.
    ///</summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "__typename")]
    [JsonDerivedType(typeof(OrderBankAccountTender), typeDiscriminator: "OrderBankAccountTender")]
    [JsonDerivedType(typeof(OrderBuyNowPayLaterTender), typeDiscriminator: "OrderBuyNowPayLaterTender")]
    [JsonDerivedType(typeof(OrderCardTender), typeDiscriminator: "OrderCardTender")]
    [JsonDerivedType(typeof(OrderCashTender), typeDiscriminator: "OrderCashTender")]
    [JsonDerivedType(typeof(OrderOtherTender), typeDiscriminator: "OrderOtherTender")]
    [JsonDerivedType(typeof(OrderSquareAccountTender), typeDiscriminator: "OrderSquareAccountTender")]
    public interface IOrderTender : IGraphQLObject
    {
        public OrderBankAccountTender? AsOrderBankAccountTender() => this as OrderBankAccountTender;
        public OrderBuyNowPayLaterTender? AsOrderBuyNowPayLaterTender() => this as OrderBuyNowPayLaterTender;
        public OrderCardTender? AsOrderCardTender() => this as OrderCardTender;
        public OrderCashTender? AsOrderCashTender() => this as OrderCashTender;
        public OrderOtherTender? AsOrderOtherTender() => this as OrderOtherTender;
        public OrderSquareAccountTender? AsOrderSquareAccountTender() => this as OrderSquareAccountTender;
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        public Money? amount { get; }
        ///<summary>
        ///The timestamp for when the tender was created, in RFC 3339 format.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; }
        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        public Customer? customer { get; }
        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        public string? id { get; }
        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        public Location? location { get; }
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        public string? merchantId { get; }
        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        public string? note { get; }
        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        public Payment? payment { get; }
        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        public Money? processingFee { get; }
        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        public Money? tip { get; }
        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        public string? transactionId { get; }
        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        public OrderTenderType? type { get; }
    }

    ///<summary>
    ///Indicates a tender's type.
    ///</summary>
    public enum OrderTenderType
    {
        ///<summary>
        ///A bank account payment.
        ///</summary>
        BANK_ACCOUNT,
        ///<summary>
        ///A Buy Now Pay Later payment.
        ///</summary>
        BUY_NOW_PAY_LATER,
        ///<summary>
        ///A credit card.
        ///</summary>
        CARD,
        ///<summary>
        ///Cash.
        ///</summary>
        CASH,
        ///<summary>
        ///This tender represents the register being opened for a "no sale" event.
        ///</summary>
        NO_SALE,
        ///<summary>
        ///A form of tender that does not match any other value.
        ///</summary>
        OTHER,
        ///<summary>
        ///A Square House Account payment.
        ///</summary>
        SQUARE_ACCOUNT,
        ///<summary>
        ///A Square gift card.
        ///</summary>
        SQUARE_GIFT_CARD,
        ///<summary>
        ///A credit card processed with a card processor other than Square.
        ///  
        ///This value applies only to merchants in countries where Square does not
        ///yet provide card processing.
        ///</summary>
        THIRD_PARTY_CARD,
        ///<summary>
        ///A payment from a digital wallet, e.g. Cash App.
        ///  
        ///Note: Some "digital wallets", including Google Pay and Apple Pay, facilitate
        ///card payments.  Those payments have the `CARD` type.
        ///</summary>
        WALLET,
    }

    ///<summary>
    ///Provides pagination-related information.
    ///</summary>
    public class PageInfo : GraphQLObject<PageInfo>
    {
        ///<summary>
        ///The `Cursor` of the last edge of the current page. This can be passed in the next query as
        ///a `after` argument to paginate forwards.
        ///</summary>
        public string? endCursor { get; set; }
        ///<summary>
        ///Indicates if there is another page of results available after the current one.
        ///</summary>
        public bool? hasNextPage { get; set; }
        ///<summary>
        ///Indicates if there is another page of results available before the current one.
        ///</summary>
        public bool? hasPreviousPage { get; set; }
        ///<summary>
        ///The `Cursor` of the first edge of the current page. This can be passed in the next query as
        ///a `before` argument to paginate backwards.
        ///</summary>
        public string? startCursor { get; set; }
    }

    ///<summary>
    ///References to Payments subgraph entities
    ///
    ///Permissions:PAYMENTS_READ
    ///</summary>
    public class Payment : GraphQLObject<Payment>
    {
        ///<summary>
        ///Unique ID for the payment.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The amount processed for this payment, not including `tipMoney`.
        ///
        ///The amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents). For more information, see
        ///[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
        ///</summary>
        public Money? amountMoney { get; set; }
        ///<summary>
        ///The amount the developer is taking as a fee for facilitating the payment on behalf
        ///of the seller. This amount is specified in the smallest denomination of the applicable currency
        ///(for example, US dollar amounts are specified in cents). For more information,
        ///see [Take Payments and Collect Fees](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees).
        ///
        ///The amount cannot be more than 90% of the `total_money` value.
        ///
        ///To set this field, `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required.
        ///For more information, see [Permissions](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees#permissions).
        ///</summary>
        public Money? appFeeMoney { get; set; }
        ///<summary>
        ///Details about the application that took the payment.
        ///</summary>
        public PaymentApplicationDetails? applicationDetails { get; set; }
        ///<summary>
        ///The initial amount of money approved for this payment.
        ///</summary>
        public Money? approvedMoney { get; set; }
        ///<summary>
        ///Details about a bank account payment. These details are only populated if the `sourceType` is `BANK_ACCOUNT`.
        ///</summary>
        public BankAccountPaymentDetails? bankAccountDetails { get; set; }
        ///<summary>
        ///The buyer's billing address.
        ///</summary>
        public Address? billingAddress { get; set; }
        ///<summary>
        ///Details about a Buy Now Pay Later payment. The details are only populated
        ///if the `source_type` is `BUY_NOW_PAY_LATER`. For more information, see
        ///[Afterpay Payments](https://developer.squareup.com/docs/payments-api/take-payments/afterpay-payments).
        ///</summary>
        public BuyNowPayLaterPaymentDetails? buyNowPayLaterDetails { get; set; }
        ///<summary>
        ///The buyer's email address.
        ///</summary>
        public string? buyerEmailAddress { get; set; }
        ///<summary>
        ///Actions that can be performed on this payment.
        ///</summary>
        public IEnumerable<PaymentCapability>? capabilities { get; set; }
        ///<summary>
        ///Details about a card payment. These details are only populated if the `sourceType` is CARD.
        ///</summary>
        public CardPaymentDetails? cardDetails { get; set; }
        ///<summary>
        ///Details about a cash payment. These details are only populated if the `sourceType` is `CASH`.
        ///</summary>
        public CashPaymentDetails? cashDetails { get; set; }
        ///<summary>
        ///The timestamp of when the payment was created, in RFC 3339 format.
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///The [Customer](https://developer.squareup.com/reference/square/payments-api/list-payments#type-customer)
        ///ID of the customer associated with the payment.
        ///</summary>
        public string? customerId { get; set; }
        ///<summary>
        ///The action to be applied to the payment when the `delay_duration` has elapsed.
        ///</summary>
        public PaymentDelayAction? delayAction { get; set; }
        ///<summary>
        ///The duration of time after the payment's creation when Square automatically applies the
        ///`delayAction` to the payment. This automatic `delayAction` applies only to payments that
        ///don't reach a terminal state (COMPLETED, CANCELED, or FAILED) before the `delayDuration`
        ///time period.
        ///
        ///This field is specified as a time duration, in RFC 3339 format.
        ///
        ///Notes:
        ///This feature is only supported for card payments.
        ///
        ///Default:
        ///
        ///  - Card Present payments: "PT36H" (36 hours) from the creation time.
        ///  - Card Not Present payments: "P7D" (7 days) from the creation time.
        ///</summary>
        public string? delayDuration { get; set; }
        ///<summary>
        ///The read-only timestamp of when the `delay_action` is automatically applied,
        ///in RFC 3339 format.
        ///
        ///Note that this field is calculated by summing the payment's `delay_duration` and `created_at`
        ///fields. The `created_at` field is generated by Square and might not exactly match the
        ///time on your local machine.
        ///</summary>
        public DateTime? delayedUntil { get; set; }
        ///<summary>
        ///Details about the device that took the payment.
        ///</summary>
        public PaymentDeviceDetails? deviceDetails { get; set; }
        ///<summary>
        ///Details about an external payment. The details are only populated if the `sourceType` is `EXTERNAL`.
        ///</summary>
        public ExternalPaymentDetails? externalDetails { get; set; }
        ///<summary>
        ///The ID of the location associated with the payment.
        ///</summary>
        public string? locationId { get; set; }
        ///<summary>
        ///The ID of the merchant associated with the payment.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///An optional note to include when creating a payment.
        ///</summary>
        public string? note { get; set; }
        ///<summary>
        ///The ID of the order associated with the payment.
        ///</summary>
        public string? orderId { get; set; }
        ///<summary>
        ///The processing fees and fee adjustments assessed by Square for this payment.
        ///</summary>
        public IEnumerable<PaymentProcessingFee>? processingFees { get; set; }
        ///<summary>
        ///The payment's receipt number.
        ///The field will be missing if a payment is canceled.
        ///</summary>
        public string? receiptNumber { get; set; }
        ///<summary>
        ///The URL for the payment's receipt.
        ///The field is only populated for COMPLETED payments.
        ///</summary>
        public string? receiptUrl { get; set; }
        ///<summary>
        ///An optional ID that associates this payment with an entity in another system.
        ///</summary>
        public string? referenceId { get; set; }
        ///<summary>
        ///The total amount of the payment refunded to date.
        ///
        ///This amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents).
        ///</summary>
        public Money? refundedMoney { get; set; }
        ///<summary>
        ///The refunds for this payment.
        ///</summary>
        public PaymentRefundConnection? refunds { get; set; }
        ///<summary>
        ///Provides information about the risk associated with this payment, as determined by Square.
        ///This field will be present for payments to sellers that have opted in to receive risk
        ///evaluations.
        ///</summary>
        public PaymentRiskEvaluation? riskEvaluation { get; set; }
        ///<summary>
        ///The buyer's shipping address.
        ///</summary>
        public Address? shippingAddress { get; set; }
        ///<summary>
        ///The source type for the payment.
        ///
        ///For information about these payment source types,
        ///see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
        ///</summary>
        public PaymentSourceType? sourceType { get; set; }
        ///<summary>
        ///Additional payment information that gets added on the customer's card statement
        ///as part of the statement description.
        ///
        ///Note that the `statementDescriptionIdentifier` may get truncated on the statement description
        ///to fit the required information including the Square identifier (SQ *) and name of the
        ///seller taking the payment.
        ///</summary>
        public string? statementDescriptionIdentifier { get; set; }
        ///<summary>
        ///Indicates whether the payment is APPROVED, PENDING, COMPLETED, CANCELED, or FAILED.
        ///</summary>
        public PaymentStatus? status { get; set; }
        ///<summary>
        ///An optional ID of the TeamMember associated with taking the payment.
        ///</summary>
        public string? teamMemberId { get; set; }
        ///<summary>
        ///The amount designated as a tip.
        ///
        ///This amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents). For more information, see
        ///[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
        ///</summary>
        public Money? tipMoney { get; set; }
        ///<summary>
        ///The total amount for the payment, including `amountMoney` and `tipMoney`.
        ///
        ///This amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents). For more information, see
        ///[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
        ///</summary>
        public Money? totalMoney { get; set; }
        ///<summary>
        ///The timestamp of when the payment was last updated, in RFC 3339 format.
        ///</summary>
        public DateTime? updatedAt { get; set; }
        ///<summary>
        ///Details about an wallet payment. The details are only populated if the `sourceType` is `WALLET`.
        ///</summary>
        public DigitalWalletPaymentDetails? walletDetails { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Details about the application that took the payment.
    ///</summary>
    public class PaymentApplicationDetails : GraphQLObject<PaymentApplicationDetails>
    {
        ///<summary>
        ///The Square ID assigned to the application used to take the payment.
        ///Application developers can use this information to identify payments that
        ///their application processed.
        ///For example, if a developer uses a custom application to process payments,
        ///this field contains the application ID from the Developer Dashboard.
        ///If a seller uses a [Square App Marketplace](https://developer.squareup.com/docs/app-marketplace)
        ///application to process payments, the field contains the corresponding application ID.
        ///</summary>
        public string? applicationId { get; set; }
        ///<summary>
        ///The Square product, such as Square Point of Sale (POS), Square Invoices, or Square Virtual Terminal.
        ///</summary>
        public PaymentApplicationDetailsExternalSquareProduct? squareProduct { get; set; }
    }

    ///<summary>
    ///A list of products to return to external callers.
    ///</summary>
    public enum PaymentApplicationDetailsExternalSquareProduct
    {
        APPOINTMENTS,
        ECOMMERCE_API,
        INVOICES,
        ONLINE_STORE,
        OTHER,
        RESTAURANTS,
        RETAIL,
        SQUARE_POS,
        TERMINAL_API,
        VIRTUAL_TERMINAL,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Represents an application processing fee.
    ///</summary>
    public class PaymentAppProcessingFee : GraphQLObject<PaymentAppProcessingFee>
    {
        ///<summary>
        ///The exact fee amount assessed based on the payment fee rate.
        ///</summary>
        public Money? amountMoney { get; set; }
        ///<summary>
        ///The timestamp of when the fee takes effect, in RFC 3339 format.
        ///</summary>
        public DateTime? effectiveAt { get; set; }
        ///<summary>
        ///The platform account token for this payment fee.
        ///For a capture, this is the recipient of funds. For a refund, this is the source of funds.
        ///</summary>
        public string? partyAccountId { get; set; }
        ///<summary>
        ///The price selector IDs of the payment fee being applied.
        ///</summary>
        public IEnumerable<string>? priceSelectors { get; set; }
        ///<summary>
        ///The type of payment fee being applied (for example, `THIRD_PARTY_PAYMENT_FEE` or `THIRD_PARTY_REFUND_FEE`).
        ///</summary>
        public PaymentAppProcessingFeeType? type { get; set; }
    }

    ///<summary>
    ///The type of payment fee being applied.
    ///</summary>
    public enum PaymentAppProcessingFeeType
    {
        THIRD_PARTY_PAYMENT_FEE,
        THIRD_PARTY_REFUND_FEE,
    }

    ///<summary>
    ///Actions that can be performed on a payment.
    ///</summary>
    public enum PaymentCapability
    {
        ///<summary>
        ///The payment amount can be edited down.
        ///</summary>
        EDIT_AMOUNT_DOWN,
        ///<summary>
        ///The payment amount can be edited up.
        ///</summary>
        EDIT_AMOUNT_UP,
        ///<summary>
        ///The delay action can be edited.
        ///</summary>
        EDIT_DELAY_ACTION,
        ///<summary>
        ///The tip amount can be edited down.
        ///</summary>
        EDIT_TIP_AMOUNT_DOWN,
        ///<summary>
        ///The tip amount can be edited up.
        ///</summary>
        EDIT_TIP_AMOUNT_UP,
    }

    ///<summary>
    ///Represents a paginated collection of `Payment` results.
    ///
    ///See the [Relay GraphQL Cursor Connections
    ///Specification](https://relay.dev/graphql/connections.htm#sec-Connection-Types) for more info.
    ///
    ///Permissions: PAYMENTS_READ.
    ///</summary>
    public class PaymentConnection : GraphQLObject<PaymentConnection>, IConnectionWithEdges<PaymentEdge, Payment>
    {
        ///<summary>
        ///Wraps a specific `Payment` to pair it with its pagination cursor.
        ///</summary>
        public IEnumerable<PaymentEdge>? edges { get; set; }
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
        ///<summary>
        ///The total number of edges available in this connection to paginate over.
        ///</summary>
        public long? totalEdgeCount { get; set; }
    }

    ///<summary>
    ///The action to be applied to the payment when the `delayDuration` has elapsed.
    ///</summary>
    public enum PaymentDelayAction
    {
        CANCEL,
        COMPLETE,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Details about the device that took the payment.
    ///</summary>
    public class PaymentDeviceDetails : GraphQLObject<PaymentDeviceDetails>
    {
        ///<summary>
        ///Square-issued ID of the device.
        ///</summary>
        public string? deviceId { get; set; }
        ///<summary>
        ///Square-issued installation ID for the device.
        ///</summary>
        public string? deviceInstallationId { get; set; }
        ///<summary>
        ///The name of the device set by the seller.
        ///</summary>
        public string? deviceName { get; set; }
    }

    ///<summary>
    ///Represents a specific `Payment` in the context of a `PaymentConnection`,
    ///providing access to both the `Payment` and a pagination `Cursor`.
    ///
    ///See the [Relay GraphQL Cursor Connections
    ///Specification](https://relay.dev/graphql/connections.htm#sec-Edge-Types) for more info.
    ///
    ///Permissions: PAYMENTS_READ.
    ///</summary>
    public class PaymentEdge : GraphQLObject<PaymentEdge>, IEdge<Payment>
    {
        ///<summary>
        ///The `Cursor` of this `Payment`. This can be passed in the next query as
        ///a `before` or `after` argument to continue paginating from this `Payment`.
        ///</summary>
        public string? cursor { get; set; }
        ///<summary>
        ///The `Payment` of this edge.
        ///</summary>
        public Payment? node { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Represents the Square processing fee.
    ///</summary>
    public class PaymentProcessingFee : GraphQLObject<PaymentProcessingFee>
    {
        ///<summary>
        ///The fee amount, which might be negative, that is assessed or adjusted by Square.
        ///
        ///Positive values represent funds being assessed, while negative values represent funds being returned.
        ///</summary>
        public Money? amountMoney { get; set; }
        ///<summary>
        ///The timestamp of when the fee takes effect, in RFC 3339 format.
        ///</summary>
        public string? effectiveAt { get; set; }
        ///<summary>
        ///The type of fee assessed or adjusted.
        ///</summary>
        public PaymentProcessingFeeType? type { get; set; }
    }

    ///<summary>
    ///The type of fee assessed or adjusted.
    ///</summary>
    public enum PaymentProcessingFeeType
    {
        ///<summary>
        ///Type used for an adjustment to the initial processing fee.
        ///</summary>
        ADJUSTMENT,
        ///<summary>
        ///Type used on the initial processing fee.
        ///</summary>
        INITIAL,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Represents a refund of a payment made using Square. Contains information about
    ///the original payment and the amount of money refunded.
    ///
    ///
    ///For more performant queries on this type, please filter on `merchantId` if possible.
    ///</summary>
    public class PaymentRefund : GraphQLObject<PaymentRefund>
    {
        ///<summary>
        ///The amount of money refunded. This amount is specified in the smallest denomination
        ///of the applicable currency (for example, US dollar amounts are specified in cents).
        ///</summary>
        public Money? amountMoney { get; set; }
        ///<summary>
        ///The amount of money the application developer contributed to help cover the refunded amount.
        ///This amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents). For more information, see
        ///[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
        ///</summary>
        public Money? appFeeMoney { get; set; }
        ///<summary>
        ///The timestamp of when the refund was created, in RFC 3339 format.
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///The unique ID for this refund, generated by Square.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The location ID associated with the payment this refund is attached to.
        ///</summary>
        public string? locationId { get; set; }
        ///<summary>
        ///The merchant ID associated with the payment this refund is attached to.
        ///</summary>
        public string? merchantId { get; set; }
        ///<summary>
        ///The ID of the order associated with the refund.
        ///</summary>
        public string? orderId { get; set; }
        ///<summary>
        ///The payment this refund belongs to.
        ///</summary>
        public Payment? payment { get; set; }
        ///<summary>
        ///The ID of the payment associated with this refund.
        ///</summary>
        public string? paymentId { get; set; }
        ///<summary>
        ///Processing fees and fee adjustments assessed by Square for this refund.
        ///</summary>
        public IEnumerable<PaymentProcessingFee>? processingFees { get; set; }
        ///<summary>
        ///The reason for the refund.
        ///</summary>
        public string? reason { get; set; }
        ///<summary>
        ///The refund's status.
        ///</summary>
        public PaymentRefundStatus? status { get; set; }
        ///<summary>
        ///An optional ID of the team member associated with taking the payment.
        ///</summary>
        public string? teamMemberId { get; set; }
        ///<summary>
        ///The timestamp of when the refund was last updated, in RFC 3339 format.
        ///</summary>
        public DateTime? updatedAt { get; set; }
    }

    ///<summary>
    ///Represents a paginated collection of `PaymentRefund` results.
    ///
    ///See the [Relay GraphQL Cursor Connections
    ///Specification](https://relay.dev/graphql/connections.htm#sec-Connection-Types) for more info.
    ///
    ///Permissions: PAYMENTS_READ.
    ///</summary>
    public class PaymentRefundConnection : GraphQLObject<PaymentRefundConnection>, IConnectionWithEdges<PaymentRefundEdge, PaymentRefund>
    {
        ///<summary>
        ///Wraps a specific `PaymentRefund` to pair it with its pagination cursor.
        ///</summary>
        public IEnumerable<PaymentRefundEdge>? edges { get; set; }
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        public PageInfo? pageInfo { get; set; }
        ///<summary>
        ///The total number of edges available in this connection to paginate over.
        ///</summary>
        public long? totalEdgeCount { get; set; }
    }

    ///<summary>
    ///Represents a specific `PaymentRefund` in the context of a `PaymentRefundConnection`,
    ///providing access to both the `PaymentRefund` and a pagination `Cursor`.
    ///
    ///See the [Relay GraphQL Cursor Connections
    ///Specification](https://relay.dev/graphql/connections.htm#sec-Edge-Types) for more info.
    ///
    ///Permissions: PAYMENTS_READ.
    ///</summary>
    public class PaymentRefundEdge : GraphQLObject<PaymentRefundEdge>, IEdge<PaymentRefund>
    {
        ///<summary>
        ///The `Cursor` of this `PaymentRefund`. This can be passed in the next query as
        ///a `before` or `after` argument to continue paginating from this `PaymentRefund`.
        ///</summary>
        public string? cursor { get; set; }
        ///<summary>
        ///The `PaymentRefund` of this edge.
        ///</summary>
        public PaymentRefund? node { get; set; }
    }

    ///<summary>
    ///Enumerates the ways `PaymentRefund`s can be sorted.
    ///</summary>
    public enum PaymentRefundSortOrder
    {
        ///<summary>
        ///Sorts ascending by the `amountMoney.amount` field.
        ///</summary>
        amountMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `amountMoney.amount` field.
        ///</summary>
        amountMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `amountMoney.currency` field.
        ///</summary>
        amountMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `amountMoney.currency` field.
        ///</summary>
        amountMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `appFeeMoney.amount` field.
        ///</summary>
        appFeeMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `appFeeMoney.amount` field.
        ///</summary>
        appFeeMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `appFeeMoney.currency` field.
        ///</summary>
        appFeeMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `appFeeMoney.currency` field.
        ///</summary>
        appFeeMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `createdAt` field.
        ///</summary>
        createdAt_ASC,
        ///<summary>
        ///Sorts descending by the `createdAt` field.
        ///</summary>
        createdAt_DESC,
        ///<summary>
        ///Sorts ascending by the `id` field.
        ///</summary>
        id_ASC,
        ///<summary>
        ///Sorts descending by the `id` field.
        ///</summary>
        id_DESC,
        ///<summary>
        ///Sorts ascending by the `locationId` field.
        ///</summary>
        locationId_ASC,
        ///<summary>
        ///Sorts descending by the `locationId` field.
        ///</summary>
        locationId_DESC,
        ///<summary>
        ///Sorts ascending by the `merchantId` field.
        ///</summary>
        merchantId_ASC,
        ///<summary>
        ///Sorts descending by the `merchantId` field.
        ///</summary>
        merchantId_DESC,
        ///<summary>
        ///Sorts ascending by the `orderId` field.
        ///</summary>
        orderId_ASC,
        ///<summary>
        ///Sorts descending by the `orderId` field.
        ///</summary>
        orderId_DESC,
        ///<summary>
        ///Sorts ascending by the `paymentId` field.
        ///</summary>
        paymentId_ASC,
        ///<summary>
        ///Sorts descending by the `paymentId` field.
        ///</summary>
        paymentId_DESC,
        ///<summary>
        ///Sorts ascending by the `reason` field.
        ///</summary>
        reason_ASC,
        ///<summary>
        ///Sorts descending by the `reason` field.
        ///</summary>
        reason_DESC,
        ///<summary>
        ///Sorts ascending by the `status` field.
        ///</summary>
        status_ASC,
        ///<summary>
        ///Sorts descending by the `status` field.
        ///</summary>
        status_DESC,
        ///<summary>
        ///Sorts ascending by the `teamMemberId` field.
        ///</summary>
        teamMemberId_ASC,
        ///<summary>
        ///Sorts descending by the `teamMemberId` field.
        ///</summary>
        teamMemberId_DESC,
        ///<summary>
        ///Sorts ascending by the `updatedAt` field.
        ///</summary>
        updatedAt_ASC,
        ///<summary>
        ///Sorts descending by the `updatedAt` field.
        ///</summary>
        updatedAt_DESC,
    }

    ///<summary>
    ///Indicates the current status of a `PaymentRefund` object.
    ///</summary>
    public enum PaymentRefundStatus
    {
        ///<summary>
        ///Successfully completed.
        ///</summary>
        COMPLETED,
        ///<summary>
        ///An error occurred.
        ///</summary>
        FAILED,
        ///<summary>
        ///Awaiting approval.
        ///</summary>
        PENDING,
        ///<summary>
        ///The refund was rejected.
        ///</summary>
        REJECTED,
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Represents fraud risk information for the associated payment.
    ///
    ///When you take a payment through Square's Payments API (using the `CreatePayment`
    ///endpoint), Square evaluates it and assigns a risk level to the payment. Sellers
    ///can use this information to determine the course of action (for example,
    ///provide the goods/services or refund the payment).
    ///</summary>
    public class PaymentRiskEvaluation : GraphQLObject<PaymentRiskEvaluation>
    {
        ///<summary>
        ///The timestamp when payment risk was evaluated, in RFC3339 format.
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///The risk level associated with the payment.
        ///</summary>
        public PaymentRiskEvaluationRiskLevel? riskLevel { get; set; }
    }

    ///<summary>
    ///Represents a risk level produced by evaluating a payment.
    ///</summary>
    public enum PaymentRiskEvaluationRiskLevel
    {
        ///<summary>
        ///Indicates significantly elevated risk level with the payment.
        ///</summary>
        HIGH,
        ///<summary>
        ///Indicates elevated risk level associated with the payment.
        ///</summary>
        MODERATE,
        ///<summary>
        ///Indicates payment risk is within the normal range.
        ///</summary>
        NORMAL,
        ///<summary>
        ///Indicates Square is still evaluating the payment.
        ///</summary>
        PENDING,
    }

    ///<summary>
    ///Enumerates the ways `Payment`s can be sorted.
    ///</summary>
    public enum PaymentSortOrder
    {
        ///<summary>
        ///Sorts ascending by the `amountMoney.amount` field.
        ///</summary>
        amountMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `amountMoney.amount` field.
        ///</summary>
        amountMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `amountMoney.currency` field.
        ///</summary>
        amountMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `amountMoney.currency` field.
        ///</summary>
        amountMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `appFeeMoney.amount` field.
        ///</summary>
        appFeeMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `appFeeMoney.amount` field.
        ///</summary>
        appFeeMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `appFeeMoney.currency` field.
        ///</summary>
        appFeeMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `appFeeMoney.currency` field.
        ///</summary>
        appFeeMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `applicationDetails.applicationId` field.
        ///</summary>
        applicationDetails_applicationId_ASC,
        ///<summary>
        ///Sorts descending by the `applicationDetails.applicationId` field.
        ///</summary>
        applicationDetails_applicationId_DESC,
        ///<summary>
        ///Sorts ascending by the `applicationDetails.squareProduct` field.
        ///</summary>
        applicationDetails_squareProduct_ASC,
        ///<summary>
        ///Sorts descending by the `applicationDetails.squareProduct` field.
        ///</summary>
        applicationDetails_squareProduct_DESC,
        ///<summary>
        ///Sorts ascending by the `approvedMoney.amount` field.
        ///</summary>
        approvedMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `approvedMoney.amount` field.
        ///</summary>
        approvedMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `approvedMoney.currency` field.
        ///</summary>
        approvedMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `approvedMoney.currency` field.
        ///</summary>
        approvedMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.accountOwnershipType` field.
        ///</summary>
        bankAccountDetails_accountOwnershipType_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.accountOwnershipType` field.
        ///</summary>
        bankAccountDetails_accountOwnershipType_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.bankName` field.
        ///</summary>
        bankAccountDetails_bankName_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.bankName` field.
        ///</summary>
        bankAccountDetails_bankName_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.country` field.
        ///</summary>
        bankAccountDetails_country_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.country` field.
        ///</summary>
        bankAccountDetails_country_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.fingerprint` field.
        ///</summary>
        bankAccountDetails_fingerprint_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.fingerprint` field.
        ///</summary>
        bankAccountDetails_fingerprint_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.statementDescription` field.
        ///</summary>
        bankAccountDetails_statementDescription_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.statementDescription` field.
        ///</summary>
        bankAccountDetails_statementDescription_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.transferType` field.
        ///</summary>
        bankAccountDetails_transferType_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.transferType` field.
        ///</summary>
        bankAccountDetails_transferType_DESC,
        ///<summary>
        ///Sorts ascending by the `buyNowPayLaterDetails.afterpayDetails.emailAddress` field.
        ///</summary>
        buyNowPayLaterDetails_afterpayDetails_emailAddress_ASC,
        ///<summary>
        ///Sorts descending by the `buyNowPayLaterDetails.afterpayDetails.emailAddress` field.
        ///</summary>
        buyNowPayLaterDetails_afterpayDetails_emailAddress_DESC,
        ///<summary>
        ///Sorts ascending by the `buyNowPayLaterDetails.brand` field.
        ///</summary>
        buyNowPayLaterDetails_brand_ASC,
        ///<summary>
        ///Sorts descending by the `buyNowPayLaterDetails.brand` field.
        ///</summary>
        buyNowPayLaterDetails_brand_DESC,
        ///<summary>
        ///Sorts ascending by the `buyNowPayLaterDetails.clearpayDetails.emailAddress` field.
        ///</summary>
        buyNowPayLaterDetails_clearpayDetails_emailAddress_ASC,
        ///<summary>
        ///Sorts descending by the `buyNowPayLaterDetails.clearpayDetails.emailAddress` field.
        ///</summary>
        buyNowPayLaterDetails_clearpayDetails_emailAddress_DESC,
        ///<summary>
        ///Sorts ascending by the `buyerEmailAddress` field.
        ///</summary>
        buyerEmailAddress_ASC,
        ///<summary>
        ///Sorts descending by the `buyerEmailAddress` field.
        ///</summary>
        buyerEmailAddress_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.applicationCryptogram` field.
        ///</summary>
        cardDetails_applicationCryptogram_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.applicationCryptogram` field.
        ///</summary>
        cardDetails_applicationCryptogram_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.applicationIdentifier` field.
        ///</summary>
        cardDetails_applicationIdentifier_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.applicationIdentifier` field.
        ///</summary>
        cardDetails_applicationIdentifier_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.applicationName` field.
        ///</summary>
        cardDetails_applicationName_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.applicationName` field.
        ///</summary>
        cardDetails_applicationName_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.authResultCode` field.
        ///</summary>
        cardDetails_authResultCode_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.authResultCode` field.
        ///</summary>
        cardDetails_authResultCode_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.avsStatus` field.
        ///</summary>
        cardDetails_avsStatus_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.avsStatus` field.
        ///</summary>
        cardDetails_avsStatus_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.cardPaymentTimeline.authorizedAt` field.
        ///</summary>
        cardDetails_cardPaymentTimeline_authorizedAt_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.cardPaymentTimeline.authorizedAt` field.
        ///</summary>
        cardDetails_cardPaymentTimeline_authorizedAt_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.cardPaymentTimeline.capturedAt` field.
        ///</summary>
        cardDetails_cardPaymentTimeline_capturedAt_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.cardPaymentTimeline.capturedAt` field.
        ///</summary>
        cardDetails_cardPaymentTimeline_capturedAt_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.cardPaymentTimeline.voidedAt` field.
        ///</summary>
        cardDetails_cardPaymentTimeline_voidedAt_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.cardPaymentTimeline.voidedAt` field.
        ///</summary>
        cardDetails_cardPaymentTimeline_voidedAt_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.bin` field.
        ///</summary>
        cardDetails_card_bin_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.bin` field.
        ///</summary>
        cardDetails_card_bin_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.cardBrand` field.
        ///</summary>
        cardDetails_card_cardBrand_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.cardBrand` field.
        ///</summary>
        cardDetails_card_cardBrand_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.cardCoBrand` field.
        ///</summary>
        cardDetails_card_cardCoBrand_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.cardCoBrand` field.
        ///</summary>
        cardDetails_card_cardCoBrand_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.cardType` field.
        ///</summary>
        cardDetails_card_cardType_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.cardType` field.
        ///</summary>
        cardDetails_card_cardType_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.cardholderName` field.
        ///</summary>
        cardDetails_card_cardholderName_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.cardholderName` field.
        ///</summary>
        cardDetails_card_cardholderName_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.expMonth` field.
        ///</summary>
        cardDetails_card_expMonth_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.expMonth` field.
        ///</summary>
        cardDetails_card_expMonth_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.expYear` field.
        ///</summary>
        cardDetails_card_expYear_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.expYear` field.
        ///</summary>
        cardDetails_card_expYear_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.fingerprint` field.
        ///</summary>
        cardDetails_card_fingerprint_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.fingerprint` field.
        ///</summary>
        cardDetails_card_fingerprint_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.last4` field.
        ///</summary>
        cardDetails_card_last4_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.last4` field.
        ///</summary>
        cardDetails_card_last4_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.prepaidType` field.
        ///</summary>
        cardDetails_card_prepaidType_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.prepaidType` field.
        ///</summary>
        cardDetails_card_prepaidType_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.cvvStatus` field.
        ///</summary>
        cardDetails_cvvStatus_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.cvvStatus` field.
        ///</summary>
        cardDetails_cvvStatus_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.entryMethod` field.
        ///</summary>
        cardDetails_entryMethod_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.entryMethod` field.
        ///</summary>
        cardDetails_entryMethod_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.statementDescription` field.
        ///</summary>
        cardDetails_statementDescription_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.statementDescription` field.
        ///</summary>
        cardDetails_statementDescription_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.status` field.
        ///</summary>
        cardDetails_status_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.status` field.
        ///</summary>
        cardDetails_status_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.verificationMethod` field.
        ///</summary>
        cardDetails_verificationMethod_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.verificationMethod` field.
        ///</summary>
        cardDetails_verificationMethod_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.verificationResults` field.
        ///</summary>
        cardDetails_verificationResults_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.verificationResults` field.
        ///</summary>
        cardDetails_verificationResults_DESC,
        ///<summary>
        ///Sorts ascending by the `cashDetails.buyerSuppliedMoney.amount` field.
        ///</summary>
        cashDetails_buyerSuppliedMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `cashDetails.buyerSuppliedMoney.amount` field.
        ///</summary>
        cashDetails_buyerSuppliedMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `cashDetails.buyerSuppliedMoney.currency` field.
        ///</summary>
        cashDetails_buyerSuppliedMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `cashDetails.buyerSuppliedMoney.currency` field.
        ///</summary>
        cashDetails_buyerSuppliedMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `cashDetails.changeBackMoney.amount` field.
        ///</summary>
        cashDetails_changeBackMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `cashDetails.changeBackMoney.amount` field.
        ///</summary>
        cashDetails_changeBackMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `cashDetails.changeBackMoney.currency` field.
        ///</summary>
        cashDetails_changeBackMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `cashDetails.changeBackMoney.currency` field.
        ///</summary>
        cashDetails_changeBackMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `createdAt` field.
        ///</summary>
        createdAt_ASC,
        ///<summary>
        ///Sorts descending by the `createdAt` field.
        ///</summary>
        createdAt_DESC,
        ///<summary>
        ///Sorts ascending by the `customerId` field.
        ///</summary>
        customerId_ASC,
        ///<summary>
        ///Sorts descending by the `customerId` field.
        ///</summary>
        customerId_DESC,
        ///<summary>
        ///Sorts ascending by the `delayAction` field.
        ///</summary>
        delayAction_ASC,
        ///<summary>
        ///Sorts descending by the `delayAction` field.
        ///</summary>
        delayAction_DESC,
        ///<summary>
        ///Sorts ascending by the `delayDuration` field.
        ///</summary>
        delayDuration_ASC,
        ///<summary>
        ///Sorts descending by the `delayDuration` field.
        ///</summary>
        delayDuration_DESC,
        ///<summary>
        ///Sorts ascending by the `delayedUntil` field.
        ///</summary>
        delayedUntil_ASC,
        ///<summary>
        ///Sorts descending by the `delayedUntil` field.
        ///</summary>
        delayedUntil_DESC,
        ///<summary>
        ///Sorts ascending by the `deviceDetails.deviceId` field.
        ///</summary>
        deviceDetails_deviceId_ASC,
        ///<summary>
        ///Sorts descending by the `deviceDetails.deviceId` field.
        ///</summary>
        deviceDetails_deviceId_DESC,
        ///<summary>
        ///Sorts ascending by the `deviceDetails.deviceInstallationId` field.
        ///</summary>
        deviceDetails_deviceInstallationId_ASC,
        ///<summary>
        ///Sorts descending by the `deviceDetails.deviceInstallationId` field.
        ///</summary>
        deviceDetails_deviceInstallationId_DESC,
        ///<summary>
        ///Sorts ascending by the `deviceDetails.deviceName` field.
        ///</summary>
        deviceDetails_deviceName_ASC,
        ///<summary>
        ///Sorts descending by the `deviceDetails.deviceName` field.
        ///</summary>
        deviceDetails_deviceName_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.sourceFeeMoney.amount` field.
        ///</summary>
        externalDetails_sourceFeeMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.sourceFeeMoney.amount` field.
        ///</summary>
        externalDetails_sourceFeeMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.sourceFeeMoney.currency` field.
        ///</summary>
        externalDetails_sourceFeeMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.sourceFeeMoney.currency` field.
        ///</summary>
        externalDetails_sourceFeeMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.sourceId` field.
        ///</summary>
        externalDetails_sourceId_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.sourceId` field.
        ///</summary>
        externalDetails_sourceId_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.source` field.
        ///</summary>
        externalDetails_source_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.source` field.
        ///</summary>
        externalDetails_source_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.type` field.
        ///</summary>
        externalDetails_type_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.type` field.
        ///</summary>
        externalDetails_type_DESC,
        ///<summary>
        ///Sorts ascending by the `id` field.
        ///</summary>
        id_ASC,
        ///<summary>
        ///Sorts descending by the `id` field.
        ///</summary>
        id_DESC,
        ///<summary>
        ///Sorts ascending by the `locationId` field.
        ///</summary>
        locationId_ASC,
        ///<summary>
        ///Sorts descending by the `locationId` field.
        ///</summary>
        locationId_DESC,
        ///<summary>
        ///Sorts ascending by the `merchantId` field.
        ///</summary>
        merchantId_ASC,
        ///<summary>
        ///Sorts descending by the `merchantId` field.
        ///</summary>
        merchantId_DESC,
        ///<summary>
        ///Sorts ascending by the `note` field.
        ///</summary>
        note_ASC,
        ///<summary>
        ///Sorts descending by the `note` field.
        ///</summary>
        note_DESC,
        ///<summary>
        ///Sorts ascending by the `orderId` field.
        ///</summary>
        orderId_ASC,
        ///<summary>
        ///Sorts descending by the `orderId` field.
        ///</summary>
        orderId_DESC,
        ///<summary>
        ///Sorts ascending by the `receiptNumber` field.
        ///</summary>
        receiptNumber_ASC,
        ///<summary>
        ///Sorts descending by the `receiptNumber` field.
        ///</summary>
        receiptNumber_DESC,
        ///<summary>
        ///Sorts ascending by the `receiptUrl` field.
        ///</summary>
        receiptUrl_ASC,
        ///<summary>
        ///Sorts descending by the `receiptUrl` field.
        ///</summary>
        receiptUrl_DESC,
        ///<summary>
        ///Sorts ascending by the `referenceId` field.
        ///</summary>
        referenceId_ASC,
        ///<summary>
        ///Sorts descending by the `referenceId` field.
        ///</summary>
        referenceId_DESC,
        ///<summary>
        ///Sorts ascending by the `refundedMoney.amount` field.
        ///</summary>
        refundedMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `refundedMoney.amount` field.
        ///</summary>
        refundedMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `refundedMoney.currency` field.
        ///</summary>
        refundedMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `refundedMoney.currency` field.
        ///</summary>
        refundedMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `riskEvaluation.createdAt` field.
        ///</summary>
        riskEvaluation_createdAt_ASC,
        ///<summary>
        ///Sorts descending by the `riskEvaluation.createdAt` field.
        ///</summary>
        riskEvaluation_createdAt_DESC,
        ///<summary>
        ///Sorts ascending by the `riskEvaluation.riskLevel` field.
        ///</summary>
        riskEvaluation_riskLevel_ASC,
        ///<summary>
        ///Sorts descending by the `riskEvaluation.riskLevel` field.
        ///</summary>
        riskEvaluation_riskLevel_DESC,
        ///<summary>
        ///Sorts ascending by the `sourceType` field.
        ///</summary>
        sourceType_ASC,
        ///<summary>
        ///Sorts descending by the `sourceType` field.
        ///</summary>
        sourceType_DESC,
        ///<summary>
        ///Sorts ascending by the `statementDescriptionIdentifier` field.
        ///</summary>
        statementDescriptionIdentifier_ASC,
        ///<summary>
        ///Sorts descending by the `statementDescriptionIdentifier` field.
        ///</summary>
        statementDescriptionIdentifier_DESC,
        ///<summary>
        ///Sorts ascending by the `status` field.
        ///</summary>
        status_ASC,
        ///<summary>
        ///Sorts descending by the `status` field.
        ///</summary>
        status_DESC,
        ///<summary>
        ///Sorts ascending by the `teamMemberId` field.
        ///</summary>
        teamMemberId_ASC,
        ///<summary>
        ///Sorts descending by the `teamMemberId` field.
        ///</summary>
        teamMemberId_DESC,
        ///<summary>
        ///Sorts ascending by the `tipMoney.amount` field.
        ///</summary>
        tipMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `tipMoney.amount` field.
        ///</summary>
        tipMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `tipMoney.currency` field.
        ///</summary>
        tipMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `tipMoney.currency` field.
        ///</summary>
        tipMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `totalMoney.amount` field.
        ///</summary>
        totalMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `totalMoney.amount` field.
        ///</summary>
        totalMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `totalMoney.currency` field.
        ///</summary>
        totalMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `totalMoney.currency` field.
        ///</summary>
        totalMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `updatedAt` field.
        ///</summary>
        updatedAt_ASC,
        ///<summary>
        ///Sorts descending by the `updatedAt` field.
        ///</summary>
        updatedAt_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.brand` field.
        ///</summary>
        walletDetails_brand_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.brand` field.
        ///</summary>
        walletDetails_brand_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.cashAppDetails.buyerCashtag` field.
        ///</summary>
        walletDetails_cashAppDetails_buyerCashtag_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.cashAppDetails.buyerCashtag` field.
        ///</summary>
        walletDetails_cashAppDetails_buyerCashtag_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.cashAppDetails.buyerCountryCode` field.
        ///</summary>
        walletDetails_cashAppDetails_buyerCountryCode_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.cashAppDetails.buyerCountryCode` field.
        ///</summary>
        walletDetails_cashAppDetails_buyerCountryCode_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.cashAppDetails.buyerFullName` field.
        ///</summary>
        walletDetails_cashAppDetails_buyerFullName_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.cashAppDetails.buyerFullName` field.
        ///</summary>
        walletDetails_cashAppDetails_buyerFullName_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.status` field.
        ///</summary>
        walletDetails_status_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.status` field.
        ///</summary>
        walletDetails_status_DESC,
    }

    ///<summary>
    ///The source type for a payment.
    ///
    ///For information about these payment source types,
    ///see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
    ///</summary>
    public enum PaymentSourceType
    {
        BANK_ACCOUNT,
        BUY_NOW_PAY_LATER,
        CARD,
        CASH,
        EXTERNAL,
        SQUARE_ACCOUNT,
        WALLET,
    }

    ///<summary>
    ///Indicates the current status of a `Payment` object.
    ///</summary>
    public enum PaymentStatus
    {
        APPROVED,
        CANCELED,
        COMPLETED,
        FAILED,
        PENDING,
    }

    ///<summary>
    ///Indicates the Square product used to generate a change.
    ///</summary>
    public enum Product
    {
        ///<summary>
        ///Square Point of Sale application.
        ///</summary>
        SQUARE_POS,
        ///<summary>
        ///Square Connect APIs (for example, Orders API or Checkout API).
        ///</summary>
        EXTERNAL_API,
        ///<summary>
        ///A Square subscription (various products).
        ///</summary>
        BILLING,
        ///<summary>
        ///Square Appointments.
        ///</summary>
        APPOINTMENTS,
        ///<summary>
        ///Square Invoices.
        ///</summary>
        INVOICES,
        ///<summary>
        ///Square Online Store.
        ///</summary>
        ONLINE_STORE,
        ///<summary>
        ///Square Payroll.
        ///</summary>
        PAYROLL,
        ///<summary>
        ///Square Dashboard.
        ///</summary>
        DASHBOARD,
        ///<summary>
        ///Item Library Import.
        ///</summary>
        ITEM_LIBRARY_IMPORT,
        ///<summary>
        ///A Square product that does not match any other value.
        ///</summary>
        OTHER,
    }

    ///<summary>
    ///The query entry point for the entire schema.
    ///</summary>
    public class Query : GraphQLObject<Query>
    {
        ///<summary>
        ///Retrieves a list of cards owned by the merchant. A max of 25 cards will be returned.
        ///
        ///Permissions:PAYMENTS_READ
        ///</summary>
        public CardOnFileConnection? cardsOnFile { get; set; }
        ///<summary>
        ///A list of Customer.
        ///
        ///Permissions:CUSTOMERS_READ
        ///</summary>
        public CustomerConnection? customers { get; set; }
        ///<summary>
        ///Returns the Merchant the access token is granted permission to view
        ///</summary>
        public Merchant? currentMerchant { get; set; }
        ///<summary>
        ///Query for catalog
        ///
        ///Permissions:ITEMS_READ
        ///</summary>
        public CatalogObjectConnection? catalog { get; set; }
        ///<summary>
        ///Query for CatalogItems
        ///
        ///Permissions:ITEMS_READ
        ///</summary>
        public CatalogItemConnection? catalogItems { get; set; }
        ///<summary>
        ///Retrieve InventoryChanges by the specified filter
        ///
        ///Permissions:INVENTORY_READ
        ///</summary>
        public InventoryChangeConnection? inventoryChanges { get; set; }
        ///<summary>
        ///Retrieve InventoryCounts by the specified filter
        ///
        ///Permissions:INVENTORY_READ
        ///</summary>
        public InventoryCountConnection? inventoryCounts { get; set; }
        ///<summary>
        ///Returns Orders by the specified filter.
        ///
        ///Permissions:ORDERS_READ
        ///</summary>
        public OrderConnection? orders { get; set; }
        ///<summary>
        ///Returns Merchants by IDs. Order is not guaranteed.
        ///
        ///Permissions:MERCHANT_PROFILE_READ
        ///</summary>
        public MerchantConnection? merchants { get; set; }
        ///<summary>
        ///Fetches `PaymentRefund`s based on the provided arguments.
        ///</summary>
        public PaymentRefundConnection? paymentRefunds { get; set; }
        ///<summary>
        ///Fetches `Payment`s based on the provided arguments.
        ///</summary>
        public PaymentConnection? payments { get; set; }
    }

    ///<summary>
    ///Represents a refund processed for a Square transaction.
    ///Permissions: ORDERS_READ
    ///</summary>
    public class Refund : GraphQLObject<Refund>
    {
        ///<summary>
        ///The amount of money refunded to the buyer.
        ///</summary>
        public Money? amount { get; set; }
        ///<summary>
        ///The timestamp for when the refund was created, in RFC 3339 format.
        ///  
        ///Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        ///  
        ///UTC:  2020-01-26T02:25:34Z
        ///  
        ///Pacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00
        ///</summary>
        public DateTime? createdAt { get; set; }
        ///<summary>
        ///The refund's unique ID.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The ID of the refund's associated location.
        ///</summary>
        public Location? location { get; set; }
        ///<summary>
        ///The amount of Square processing fee money refunded to the *merchant*.
        ///</summary>
        public Money? processingFee { get; set; }
        ///<summary>
        ///The reason for the refund being issued.
        ///</summary>
        public string? reason { get; set; }
        ///<summary>
        ///The current status of the refund (`PENDING`, `APPROVED`, `REJECTED`,
        ///or `FAILED`).
        ///</summary>
        public RefundStatus? status { get; set; }
        ///<summary>
        ///The ID of the refunded tender.
        ///</summary>
        public IOrderTender? tender { get; set; }
        ///<summary>
        ///The ID of the transaction that the refunded tender is part of.
        ///</summary>
        public string? transactionId { get; set; }
    }

    ///<summary>
    ///Indicates a refund's current status.
    ///</summary>
    public enum RefundStatus
    {
        ///<summary>
        ///The refund has been approved by Square.
        ///</summary>
        APPROVED,
        ///<summary>
        ///The refund failed.
        ///</summary>
        FAILED,
        ///<summary>
        ///The refund is pending.
        ///</summary>
        PENDING,
        ///<summary>
        ///The refund has been rejected by Square.
        ///</summary>
        REJECTED,
    }

    ///<summary>
    ///A loyalty reward.
    ///
    ///Loyalty rewards are not currently fully represented in graphql, and their details must be retrieved through the
    ///REST API.
    ///
    ///Permissions:LOYALTY_READ
    ///</summary>
    public class Reward : GraphQLObject<Reward>
    {
        ///<summary>
        ///The Square-assigned ID of the loyalty reward.
        ///</summary>
        public string? id { get; set; }
        ///<summary>
        ///The reward tier used to create the reward.
        ///</summary>
        public RewardTier? tier { get; set; }
    }

    ///<summary>
    ///A loyalty program reward tier.
    ///
    ///Loyalty reward tiers are not currently fully represented in graphql, and their details must be retrieved through the
    ///REST API.
    ///
    ///Permissions:LOYALTY_READ
    ///</summary>
    public class RewardTier : GraphQLObject<RewardTier>
    {
        ///<summary>
        ///The Square-assigned ID of the reward tier.
        ///</summary>
        public string? id { get; set; }
    }

    ///<summary>
    ///Specifies which timestamp to use to sort `SearchOrder` results.
    ///</summary>
    public enum SearchOrdersSortField
    {
        ///<summary>
        ///The time when the order was closed, in RFC-3339 format. If you use this
        ///value, you must also set a `StateFilter` with closed states. If you are also
        ///filtering for a time range in this query, you must set the `CLOSED_AT`
        ///field in your `DateTimeFilter`.
        ///</summary>
        CLOSED_AT,
        ///<summary>
        ///The time when the order was created, in RFC-3339 format. If you are also
        ///filtering for a time range in this query, you must set the `CREATED_AT`
        ///field in your `DateTimeFilter`.
        ///</summary>
        CREATED_AT,
        ///<summary>
        ///The time when the order last updated, in RFC-3339 format. If you are also
        ///filtering for a time range in this query, you must set the `UPDATED_AT`
        ///field in your `DateTimeFilter`.
        ///</summary>
        UPDATED_AT,
    }

    public enum SortOrder
    {
        ASC,
        DESC,
    }

    ///<summary>
    ///Represents information about the application used to generate a change.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class SourceApplication : GraphQLObject<SourceApplication>
    {
        ///<summary>
        ///__Read only__ The product type of the application.
        ///</summary>
        public Product? product { get; set; }
        ///<summary>
        ///__Read only__ The Square-assigned ID of the application. This field is used only if the
        ///product type is `EXTERNAL_API`.
        ///</summary>
        public string? applicationId { get; set; }
        ///<summary>
        ///__Read only__ The display name of the application
        ///(for example, `"Custom Application"` or `"Square POS 4.74 for Android"`).
        ///</summary>
        public string? name { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about Square Account payments.
    ///</summary>
    public class SquareAccountPaymentDetails : GraphQLObject<SquareAccountPaymentDetails>
    {
        ///<summary>
        ///Information about errors encountered during the request.
        ///</summary>
        public IEnumerable<Error>? errors { get; set; }
        ///<summary>
        ///Unique identifier for the payment source used for this payment.
        ///</summary>
        public string? paymentSourceToken { get; set; }
    }

    ///<summary>
    ///An enumeration of Square products.
    ///</summary>
    public enum SquareProduct
    {
        UNKNOWN_SQUARE_PRODUCT,
        CONNECT_API,
        DASHBOARD,
        REGISTER_CLIENT,
        BUYER_DASHBOARD,
        WEB,
        INVOICES,
        GIFT_CARD,
        VIRTUAL_TERMINAL,
        READER_SDK,
        SQUARE_PROFILE,
        SQUARE_LOCAL,
    }

    ///<summary>
    ///Determines the billing cadence of a Subscription
    ///</summary>
    public enum SubscriptionCadence
    {
        ///<summary>
        ///Once per day
        ///</summary>
        DAILY,
        ///<summary>
        ///Once per week
        ///</summary>
        WEEKLY,
        ///<summary>
        ///Every two weeks
        ///</summary>
        EVERY_TWO_WEEKS,
        ///<summary>
        ///Once every 30 days
        ///</summary>
        THIRTY_DAYS,
        ///<summary>
        ///Once every 60 days
        ///</summary>
        SIXTY_DAYS,
        ///<summary>
        ///Once every 90 days
        ///</summary>
        NINETY_DAYS,
        ///<summary>
        ///Once per month
        ///</summary>
        MONTHLY,
        ///<summary>
        ///Once every two months
        ///</summary>
        EVERY_TWO_MONTHS,
        ///<summary>
        ///Once every three months
        ///</summary>
        QUARTERLY,
        ///<summary>
        ///Once every four months
        ///</summary>
        EVERY_FOUR_MONTHS,
        ///<summary>
        ///Once every six months
        ///</summary>
        EVERY_SIX_MONTHS,
        ///<summary>
        ///Once per year
        ///</summary>
        ANNUAL,
        ///<summary>
        ///Once every two years
        ///</summary>
        EVERY_TWO_YEARS,
    }

    ///<summary>
    ///Describes a phase in a subscription plan variation.For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).
    ///Permissions: ITEMS_READ
    ///</summary>
    public class SubscriptionPhase : GraphQLObject<SubscriptionPhase>
    {
        ///<summary>
        ///The Square-assigned ID of the subscription phase. This field cannot be changed after a `SubscriptionPhase` is created.
        ///</summary>
        public string? uid { get; set; }
        ///<summary>
        ///The billing cadence of the phase. For example, weekly or monthly. This field cannot be changed after a `SubscriptionPhase` is created.
        ///</summary>
        public SubscriptionCadence? cadence { get; set; }
        ///<summary>
        ///The number of `cadence`s the phase lasts. If not set, the phase never ends. Only the last phase can be indefinite. This field cannot be changed after a `SubscriptionPhase` is created.
        ///</summary>
        public int? periods { get; set; }
        ///<summary>
        ///The amount to bill for each `cadence`. Failure to specify this field results in a `MISSING_REQUIRED_PARAMETER` error at runtime.
        ///</summary>
        public Money? recurringPriceMoney { get; set; }
        ///<summary>
        ///The subscription pricing.
        ///</summary>
        public SubscriptionPricing? pricing { get; set; }
        ///<summary>
        ///The position this phase appears in the sequence of phases defined for the plan, indexed from 0. This field cannot be changed after a `SubscriptionPhase` is created.
        ///</summary>
        public long? ordinal { get; set; }
    }

    ///<summary>
    ///Describes the pricing for the subscription.
    ///Permissions: ITEMS_READ
    ///</summary>
    public class SubscriptionPricing : GraphQLObject<SubscriptionPricing>
    {
        ///<summary>
        ///RELATIVE or STATIC
        ///</summary>
        public SubscriptionPricingType? type { get; set; }
        ///<summary>
        ///The ids of the discount catalog objects
        ///</summary>
        public IEnumerable<string>? discountIds { get; set; }
        ///<summary>
        ///The price of the subscription, if STATIC
        ///</summary>
        public Money? priceMoney { get; set; }
    }

    ///<summary>
    ///Determines the pricing of a Subscription
    ///</summary>
    public enum SubscriptionPricingType
    {
        ///<summary>
        ///Static pricing
        ///</summary>
        STATIC,
        ///<summary>
        ///Relative pricing
        ///</summary>
        RELATIVE,
    }

    ///<summary>
    ///When to calculate the taxes due on a cart.
    ///</summary>
    public enum TaxCalculationPhase
    {
        ///<summary>
        ///The fee is calculated based on the payment's subtotal.
        ///</summary>
        TAX_SUBTOTAL_PHASE,
        ///<summary>
        ///The fee is calculated based on the payment's total.
        ///</summary>
        TAX_TOTAL_PHASE,
    }

    ///<summary>
    ///Identifiers for the location used by various governments for tax purposes.
    ///
    ///Permissions:CUSTOMERS_READ
    ///</summary>
    public class TaxIds : GraphQLObject<TaxIds>
    {
        ///<summary>
        ///The EU VAT identification number for the customer. For example, IE3426675K. The ID can contain alphanumeric characters only.
        ///</summary>
        public string? euVat { get; set; }
    }

    ///<summary>
    ///Whether to the tax amount should be additional to or included in the CatalogItem price.
    ///</summary>
    public enum TaxInclusionType
    {
        ///<summary>
        ///The tax is an additive tax. The tax amount is added on top of the
        ///CatalogItemVariation price. For example, a $1.00 item with a 10% additive
        ///tax would have a total cost to the buyer of $1.10.
        ///</summary>
        ADDITIVE,
        ///<summary>
        ///The tax is an inclusive tax. The tax amount is included in the
        ///CatalogItemVariation price. For example, a $1.00 item with a 10% inclusive
        ///tax would have a total cost to the buyer of $1.00, with $0.91 (91 cents) of
        ///that total being the cost of the item and $0.09 (9 cents) being tax.
        ///</summary>
        INCLUSIVE,
    }

    ///<summary>
    ///A record representing an individual team member for a business.
    ///
    ///Permissions:EMPLOYEES_READ
    ///</summary>
    public class TeamMember : GraphQLObject<TeamMember>
    {
        ///<summary>
        ///The Square-issued ID of the team member.
        ///</summary>
        public string? id { get; set; }
    }

    ///<summary>
    ///A GraphQL Schema defines the capabilities of a GraphQL server. It exposes all available types and directives on the server, as well as the entry points for query, mutation, and subscription operations.
    ///</summary>
    public class __Schema : GraphQLObject<__Schema>
    {
        public string? description { get; set; }
        ///<summary>
        ///A list of all types supported by this server.
        ///</summary>
        public IEnumerable<__Type>? types { get; set; }
        ///<summary>
        ///The type that query operations will be rooted at.
        ///</summary>
        public __Type? queryType { get; set; }
        ///<summary>
        ///If this server supports mutation, the type that mutation operations will be rooted at.
        ///</summary>
        public __Type? mutationType { get; set; }
        ///<summary>
        ///If this server support subscription, the type that subscription operations will be rooted at.
        ///</summary>
        public __Type? subscriptionType { get; set; }
        ///<summary>
        ///A list of all directives supported by this server.
        ///</summary>
        public IEnumerable<__Directive>? directives { get; set; }
    }

    ///<summary>
    ///The fundamental unit of any GraphQL Schema is the type. There are many kinds of types in GraphQL as represented by the `__TypeKind` enum.
    ///
    ///Depending on the kind of a type, certain fields describe information about that type. Scalar types provide no information beyond a name, description and optional `specifiedByURL`, while Enum types provide their values. Object and Interface types provide the fields they describe. Abstract types, Union and Interface, provide the Object types possible at runtime. List and NonNull types compose other types.
    ///</summary>
    public class __Type : GraphQLObject<__Type>
    {
        public __TypeKind? kind { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? specifiedByURL { get; set; }
        public IEnumerable<__Field>? fields { get; set; }
        public IEnumerable<__Type>? interfaces { get; set; }
        public IEnumerable<__Type>? possibleTypes { get; set; }
        public IEnumerable<__EnumValue>? enumValues { get; set; }
        public IEnumerable<__InputValue>? inputFields { get; set; }
        public __Type? ofType { get; set; }
    }

    ///<summary>
    ///An enum describing what kind of type a given `__Type` is.
    ///</summary>
    public enum __TypeKind
    {
        ///<summary>
        ///Indicates this type is a scalar.
        ///</summary>
        SCALAR,
        ///<summary>
        ///Indicates this type is an object. `fields` and `interfaces` are valid fields.
        ///</summary>
        OBJECT,
        ///<summary>
        ///Indicates this type is an interface. `fields`, `interfaces`, and `possibleTypes` are valid fields.
        ///</summary>
        INTERFACE,
        ///<summary>
        ///Indicates this type is a union. `possibleTypes` is a valid field.
        ///</summary>
        UNION,
        ///<summary>
        ///Indicates this type is an enum. `enumValues` is a valid field.
        ///</summary>
        ENUM,
        ///<summary>
        ///Indicates this type is an input object. `inputFields` is a valid field.
        ///</summary>
        INPUT_OBJECT,
        ///<summary>
        ///Indicates this type is a list. `ofType` is a valid field.
        ///</summary>
        LIST,
        ///<summary>
        ///Indicates this type is a non-null. `ofType` is a valid field.
        ///</summary>
        NON_NULL,
    }

    ///<summary>
    ///Object and Interface types are described by a list of Fields, each of which has a name, potentially a list of arguments, and a return type.
    ///</summary>
    public class __Field : GraphQLObject<__Field>
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public IEnumerable<__InputValue>? args { get; set; }
        public __Type? type { get; set; }
        public bool? isDeprecated { get; set; }
        public string? deprecationReason { get; set; }
    }

    ///<summary>
    ///Arguments provided to Fields or Directives and the input fields of an InputObject are represented as Input Values which describe their type and optionally a default value.
    ///</summary>
    public class __InputValue : GraphQLObject<__InputValue>
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public __Type? type { get; set; }
        ///<summary>
        ///A GraphQL-formatted string representing the default value for this input value.
        ///</summary>
        public string? defaultValue { get; set; }
        public bool? isDeprecated { get; set; }
        public string? deprecationReason { get; set; }
    }

    ///<summary>
    ///One possible value for a given Enum. Enum values are unique values, not a placeholder for a string or numeric value. However an Enum value is returned in a JSON response as a string.
    ///</summary>
    public class __EnumValue : GraphQLObject<__EnumValue>
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public bool? isDeprecated { get; set; }
        public string? deprecationReason { get; set; }
    }

    ///<summary>
    ///A Directive provides a way to describe alternate runtime execution and type validation behavior in a GraphQL document.
    ///
    ///In some cases, you need to provide options to alter GraphQL's execution behavior in ways field arguments will not suffice, such as conditionally including or skipping a field. Directives provide this by describing additional information to the executor.
    ///</summary>
    public class __Directive : GraphQLObject<__Directive>
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public bool? isRepeatable { get; set; }
        public IEnumerable<__DirectiveLocation>? locations { get; set; }
        public IEnumerable<__InputValue>? args { get; set; }
    }

    ///<summary>
    ///A Directive can be adjacent to many parts of the GraphQL language, a __DirectiveLocation describes one such possible adjacencies.
    ///</summary>
    public enum __DirectiveLocation
    {
        ///<summary>
        ///Location adjacent to a query operation.
        ///</summary>
        QUERY,
        ///<summary>
        ///Location adjacent to a mutation operation.
        ///</summary>
        MUTATION,
        ///<summary>
        ///Location adjacent to a subscription operation.
        ///</summary>
        SUBSCRIPTION,
        ///<summary>
        ///Location adjacent to a field.
        ///</summary>
        FIELD,
        ///<summary>
        ///Location adjacent to a fragment definition.
        ///</summary>
        FRAGMENT_DEFINITION,
        ///<summary>
        ///Location adjacent to a fragment spread.
        ///</summary>
        FRAGMENT_SPREAD,
        ///<summary>
        ///Location adjacent to an inline fragment.
        ///</summary>
        INLINE_FRAGMENT,
        ///<summary>
        ///Location adjacent to a variable definition.
        ///</summary>
        VARIABLE_DEFINITION,
        ///<summary>
        ///Location adjacent to a schema definition.
        ///</summary>
        SCHEMA,
        ///<summary>
        ///Location adjacent to a scalar definition.
        ///</summary>
        SCALAR,
        ///<summary>
        ///Location adjacent to an object type definition.
        ///</summary>
        OBJECT,
        ///<summary>
        ///Location adjacent to a field definition.
        ///</summary>
        FIELD_DEFINITION,
        ///<summary>
        ///Location adjacent to an argument definition.
        ///</summary>
        ARGUMENT_DEFINITION,
        ///<summary>
        ///Location adjacent to an interface definition.
        ///</summary>
        INTERFACE,
        ///<summary>
        ///Location adjacent to a union definition.
        ///</summary>
        UNION,
        ///<summary>
        ///Location adjacent to an enum definition.
        ///</summary>
        ENUM,
        ///<summary>
        ///Location adjacent to an enum value definition.
        ///</summary>
        ENUM_VALUE,
        ///<summary>
        ///Location adjacent to an input object type definition.
        ///</summary>
        INPUT_OBJECT,
        ///<summary>
        ///Location adjacent to an input object field definition.
        ///</summary>
        INPUT_FIELD_DEFINITION,
    }
}