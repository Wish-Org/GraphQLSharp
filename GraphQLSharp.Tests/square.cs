#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using GraphQLSharp;

namespace square
{
    public class GraphQLClient : GraphQLClient<Query, GraphQLClientOptions>
    {
        public GraphQLClient(GraphQLClientOptions? defaultOptions = null) : base(defaultOptions!)
        {
        }
    }

    ///<summary>
    ///Represents a postal address in a country.
    ///For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
    ///</summary>
    [Description("Represents a postal address in a country.\nFor more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).")]
    public class Address : GraphQLObject<Address>
    {
        ///<summary>
        ///The first line of the address.
        ///Fields that start with `addressLine` provide the address's most specific
        ///details, like street number, street name, and building name. They do *not*
        ///provide less specific details like city, state/province, or country (these
        ///details are provided in other fields).
        ///</summary>
        [Description("The first line of the address.\nFields that start with `addressLine` provide the address's most specific\ndetails, like street number, street name, and building name. They do *not*\nprovide less specific details like city, state/province, or country (these\ndetails are provided in other fields).")]
        public string? addressLine1 { get; set; }

        ///<summary>
        ///The second line of the address, if any.
        ///</summary>
        [Description("The second line of the address, if any.")]
        public string? addressLine2 { get; set; }

        ///<summary>
        ///The third line of the address, if any.
        ///</summary>
        [Description("The third line of the address, if any.")]
        public string? addressLine3 { get; set; }

        ///<summary>
        ///A civil entity within the address's country. In the US, this is the state.
        ///For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        ///</summary>
        [Description("A civil entity within the address's country. In the US, this is the state.\nFor a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).")]
        public string? administrativeDistrictLevel1 { get; set; }

        ///<summary>
        ///The address's country, in the two-letter format of ISO 3166. For example, `US` or `FR`.
        ///</summary>
        [Description("The address's country, in the two-letter format of ISO 3166. For example, `US` or `FR`.")]
        [NonNull]
        public Country? country { get; set; }

        ///<summary>
        ///The address's country, in the two-letter format of ISO 3166. For example, `US` or `FR`.
        ///</summary>
        [Description("The address's country, in the two-letter format of ISO 3166. For example, `US` or `FR`.")]
        [Obsolete("Use `country` instead.")]
        [NonNull]
        public CountryCode? countryCode { get; set; }

        ///<summary>
        ///The city or town of the address. For a full list of field meanings by country,
        ///see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        ///</summary>
        [Description("The city or town of the address. For a full list of field meanings by country,\nsee [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).")]
        public string? locality { get; set; }

        ///<summary>
        ///The address's postal code. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        ///</summary>
        [Description("The address's postal code. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).")]
        public string? postalCode { get; set; }

        ///<summary>
        ///A civil region within the address's `locality`, if any.
        ///</summary>
        [Description("A civil region within the address's `locality`, if any.")]
        public string? sublocality { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about Afterpay payments.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nAdditional details about Afterpay payments.")]
    public class AfterpayPaymentDetails : GraphQLObject<AfterpayPaymentDetails>
    {
        ///<summary>
        ///Email address on the buyer's Afterpay account.
        ///</summary>
        [Description("Email address on the buyer's Afterpay account.")]
        public string? emailAddress { get; set; }
    }

    ///<summary>
    ///Defines the values for the `archived_state` query expression 
    ///used in [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems) 
    ///to return the archived, not archived or either type of catalog items.
    ///</summary>
    [Description("Defines the values for the `archived_state` query expression \nused in [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems) \nto return the archived, not archived or either type of catalog items.")]
    public enum ArchivedState
    {
        ///<summary>
        ///Requested items are not archived with the `is_archived` attribute set to `false`.
        ///</summary>
        [Description("Requested items are not archived with the `is_archived` attribute set to `false`.")]
        ARCHIVED_STATE_NOT_ARCHIVED,
        ///<summary>
        ///Requested items are archived with the `is_archived` attribute set to `true`.
        ///</summary>
        [Description("Requested items are archived with the `is_archived` attribute set to `true`.")]
        ARCHIVED_STATE_ARCHIVED,
        ///<summary>
        ///Requested items can be archived or not archived.
        ///</summary>
        [Description("Requested items can be archived or not archived.")]
        ARCHIVED_STATE_ALL,
    }

    public static class ArchivedStateStringValues
    {
        public const string ARCHIVED_STATE_NOT_ARCHIVED = @"ARCHIVED_STATE_NOT_ARCHIVED";
        public const string ARCHIVED_STATE_ARCHIVED = @"ARCHIVED_STATE_ARCHIVED";
        public const string ARCHIVED_STATE_ALL = @"ARCHIVED_STATE_ALL";
    }

    public enum AUTH_TARGET_TYPE
    {
        ///<summary>
        ///The annotated element must be an ID corresponding to a Merchant.
        ///</summary>
        [Description("The annotated element must be an ID corresponding to a Merchant.")]
        MERCHANT,
    }

    public static class AUTH_TARGET_TYPEStringValues
    {
        public const string MERCHANT = @"MERCHANT";
    }

    ///<summary>
    ///The annotated element must be an ID corresponding to a Merchant
    ///</summary>
    [Description("The annotated element must be an ID corresponding to a Merchant")]
    public enum AuthTarget
    {
        ///<summary>
        ///The annotated element must be an ID corresponding to a Merchant.
        ///</summary>
        [Description("The annotated element must be an ID corresponding to a Merchant.")]
        MERCHANT,
    }

    public static class AuthTargetStringValues
    {
        public const string MERCHANT = @"MERCHANT";
    }

    ///<summary>
    ///The ownership type of the bank account performing the transfer.
    ///</summary>
    [Description("The ownership type of the bank account performing the transfer.")]
    public enum BankAccountPaymentAccountOwnershipType
    {
        ACCOUNT_TYPE_UNKNOWN,
        COMPANY,
        INDIVIDUAL,
    }

    public static class BankAccountPaymentAccountOwnershipTypeStringValues
    {
        public const string ACCOUNT_TYPE_UNKNOWN = @"ACCOUNT_TYPE_UNKNOWN";
        public const string COMPANY = @"COMPANY";
        public const string INDIVIDUAL = @"INDIVIDUAL";
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///ACH-specific details about `BANK_ACCOUNT` type payments with the `transferType` of `ACH`.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nACH-specific details about `BANK_ACCOUNT` type payments with the `transferType` of `ACH`.")]
    public class BankAccountPaymentAchDetails : GraphQLObject<BankAccountPaymentAchDetails>
    {
        ///<summary>
        ///The last few digits of the bank account number.
        ///</summary>
        [Description("The last few digits of the bank account number.")]
        public string? accountNumberSuffix { get; set; }

        ///<summary>
        ///The type of the bank account performing the transfer. The account type can be `CHECKING`, `SAVINGS`, or `UNKNOWN`.
        ///</summary>
        [Description("The type of the bank account performing the transfer. The account type can be `CHECKING`, `SAVINGS`, or `UNKNOWN`.")]
        public BankAccountType? accountType { get; set; }

        ///<summary>
        ///The routing number for the bank account.
        ///</summary>
        [Description("The routing number for the bank account.")]
        public string? routingNumber { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about BANK_ACCOUNT type payments.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nAdditional details about BANK_ACCOUNT type payments.")]
    public class BankAccountPaymentDetails : GraphQLObject<BankAccountPaymentDetails>
    {
        ///<summary>
        ///The ownership type of the bank account performing the transfer.
        ///</summary>
        [Description("The ownership type of the bank account performing the transfer.")]
        public BankAccountPaymentAccountOwnershipType? accountOwnershipType { get; set; }

        ///<summary>
        ///ACH-specific information about the transfer. The information is only populated if the `transferType` is `ACH`.
        ///</summary>
        [Description("ACH-specific information about the transfer. The information is only populated if the `transferType` is `ACH`.")]
        public BankAccountPaymentAchDetails? achDetails { get; set; }

        ///<summary>
        ///The name of the bank associated with the bank account.
        ///</summary>
        [Description("The name of the bank associated with the bank account.")]
        public string? bankName { get; set; }

        ///<summary>
        ///The two-letter ISO code representing the country the bank account is located in.
        ///</summary>
        [Description("The two-letter ISO code representing the country the bank account is located in.")]
        public Country? country { get; set; }

        ///<summary>
        ///Information about errors encountered during the request.
        ///</summary>
        [Description("Information about errors encountered during the request.")]
        [NonNull]
        public IEnumerable<Error>? errors { get; set; }

        ///<summary>
        ///Uniquely identifies the bank account for this seller and can be used to
        ///determine if payments are from the same bank account.
        ///</summary>
        [Description("Uniquely identifies the bank account for this seller and can be used to\ndetermine if payments are from the same bank account.")]
        public string? fingerprint { get; set; }

        ///<summary>
        ///The statement description as sent to the bank.
        ///</summary>
        [Description("The statement description as sent to the bank.")]
        public string? statementDescription { get; set; }

        ///<summary>
        ///The type of the bank transfer.
        ///</summary>
        [Description("The type of the bank transfer.")]
        public BankAccountPaymentTransferType? transferType { get; set; }
    }

    ///<summary>
    ///The type of the bank transfer.
    ///</summary>
    [Description("The type of the bank transfer.")]
    public enum BankAccountPaymentTransferType
    {
        ACH,
        OPEN_BANKING,
        UNKNOWN,
    }

    public static class BankAccountPaymentTransferTypeStringValues
    {
        public const string ACH = @"ACH";
        public const string OPEN_BANKING = @"OPEN_BANKING";
        public const string UNKNOWN = @"UNKNOWN";
    }

    ///<summary>
    ///Indicates the financial purpose of the bank account.
    ///</summary>
    [Description("Indicates the financial purpose of the bank account.")]
    public enum BankAccountType
    {
        ///<summary>
        ///An account at a financial institution against which checks can be
        ///drawn specifically for business purposes (non-personal use).
        ///</summary>
        [Description("An account at a financial institution against which checks can be\ndrawn specifically for business purposes (non-personal use).")]
        BUSINESS_CHECKING,
        ///<summary>
        ///An account at a financial institution against which checks can be
        ///drawn by the account depositor.
        ///</summary>
        [Description("An account at a financial institution against which checks can be\ndrawn by the account depositor.")]
        CHECKING,
        ///<summary>
        ///An account at a financial institution that contains a deposit of funds
        ///and/or securities.
        ///</summary>
        [Description("An account at a financial institution that contains a deposit of funds\nand/or securities.")]
        INVESTMENT,
        ///<summary>
        ///An account at a financial institution which cannot be described by the
        ///other types.
        ///</summary>
        [Description("An account at a financial institution which cannot be described by the\nother types.")]
        OTHER,
        ///<summary>
        ///An account at a financial institution that pays interest but cannot be
        ///used directly as money in the narrow sense of a medium of exchange.
        ///</summary>
        [Description("An account at a financial institution that pays interest but cannot be\nused directly as money in the narrow sense of a medium of exchange.")]
        SAVINGS,
        ///<summary>
        ///Reserved value for unknown.
        ///</summary>
        [Description("Reserved value for unknown.")]
        UNKNOWN,
    }

    public static class BankAccountTypeStringValues
    {
        public const string BUSINESS_CHECKING = @"BUSINESS_CHECKING";
        public const string CHECKING = @"CHECKING";
        public const string INVESTMENT = @"INVESTMENT";
        public const string OTHER = @"OTHER";
        public const string SAVINGS = @"SAVINGS";
        public const string UNKNOWN = @"UNKNOWN";
    }

    ///<summary>
    ///The hours of operation for a business location.
    ///</summary>
    [Description("The hours of operation for a business location.")]
    public class BusinessHours : GraphQLObject<BusinessHours>
    {
        ///<summary>
        ///The list of time periods during which the business is open. There can be at most 10 periods per day.
        ///</summary>
        [Description("The list of time periods during which the business is open. There can be at most 10 periods per day.")]
        public IEnumerable<BusinessHoursPeriod>? periods { get; set; }
    }

    ///<summary>
    ///A period of time during which a business location is open.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    [Description("A period of time during which a business location is open.\n\nPermissions:MERCHANT_PROFILE_READ")]
    public class BusinessHoursPeriod : GraphQLObject<BusinessHoursPeriod>
    {
        ///<summary>
        ///The day of week for this time period.
        ///</summary>
        [Description("The day of week for this time period.")]
        public DayOfWeek? dayOfWeek { get; set; }

        ///<summary>
        ///The end time of a business hours period, specified in local time using partial-time RFC 3339 format.
        ///</summary>
        [Description("The end time of a business hours period, specified in local time using partial-time RFC 3339 format.")]
        public string? endLocalTime { get; set; }

        ///<summary>
        ///The start time of a business hours period, specified in local time using partial-time RFC 3339 format.
        ///</summary>
        [Description("The start time of a business hours period, specified in local time using partial-time RFC 3339 format.")]
        public string? startLocalTime { get; set; }
    }

    ///<summary>
    ///The brand used for a Buy Now Pay Later payment.
    ///</summary>
    [Description("The brand used for a Buy Now Pay Later payment.")]
    public enum BuyNowPayLaterPaymentBrand
    {
        AFTERPAY,
        CLEARPAY,
        UNKNOWN,
    }

    public static class BuyNowPayLaterPaymentBrandStringValues
    {
        public const string AFTERPAY = @"AFTERPAY";
        public const string CLEARPAY = @"CLEARPAY";
        public const string UNKNOWN = @"UNKNOWN";
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about a Buy Now Pay Later payment type.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nAdditional details about a Buy Now Pay Later payment type.")]
    public class BuyNowPayLaterPaymentDetails : GraphQLObject<BuyNowPayLaterPaymentDetails>
    {
        ///<summary>
        ///Details about an Afterpay payment. These details are only populated if the `brand` is `AFTERPAY`.
        ///</summary>
        [Description("Details about an Afterpay payment. These details are only populated if the `brand` is `AFTERPAY`.")]
        public AfterpayPaymentDetails? afterpayDetails { get; set; }

        ///<summary>
        ///The brand used for the Buy Now Pay Later payment.
        ///</summary>
        [Description("The brand used for the Buy Now Pay Later payment.")]
        public BuyNowPayLaterPaymentBrand? brand { get; set; }

        ///<summary>
        ///Details about a Clearpay payment. These details are only populated if the `brand` is `CLEARPAY`.
        ///</summary>
        [Description("Details about a Clearpay payment. These details are only populated if the `brand` is `CLEARPAY`.")]
        public ClearpayPaymentDetails? clearpayDetails { get; set; }
    }

    ///<summary>
    ///Represents the payment details of a card used for a payments.
    ///
    ///Permissions:PAYMENTS_READ
    ///</summary>
    [Description("Represents the payment details of a card used for a payments.\n\nPermissions:PAYMENTS_READ")]
    public class Card : GraphQLObject<Card>
    {
        ///<summary>
        ///The billing address for this card.
        ///</summary>
        [Description("The billing address for this card.")]
        public Address? billingAddress { get; set; }

        ///<summary>
        ///The first six digits of the card number, known as the Bank Identification Number (BIN). Only the Payments API
        ///returns this field.
        ///</summary>
        [Description("The first six digits of the card number, known as the Bank Identification Number (BIN). Only the Payments API\nreturns this field.")]
        public string? bin { get; set; }

        ///<summary>
        ///The card's brand.
        ///</summary>
        [Description("The card's brand.")]
        public CardBrand? cardBrand { get; set; }

        ///<summary>
        ///The type of the card.
        ///The Card object includes this field only in response to Payments API calls.
        ///</summary>
        [Description("The type of the card.\nThe Card object includes this field only in response to Payments API calls.")]
        public CardType? cardType { get; set; }

        ///<summary>
        ///The name of the cardholder.
        ///</summary>
        [Description("The name of the cardholder.")]
        public string? cardholderName { get; set; }

        ///<summary>
        ///The expiration month of the associated card as an integer, generally between 1
        ///and 12. Can be outside that normally valid range on failed payments--we just
        ///record this value as we received it.
        ///</summary>
        [Description("The expiration month of the associated card as an integer, generally between 1\nand 12. Can be outside that normally valid range on failed payments--we just\nrecord this value as we received it.")]
        public int? expMonth { get; set; }

        ///<summary>
        ///The four-digit year of the card's expiration date.
        ///</summary>
        [Description("The four-digit year of the card's expiration date.")]
        public int? expYear { get; set; }

        ///<summary>
        ///__Not currently set.__ Intended as a Square-assigned identifier, based
        ///on the card number, to identify the card across multiple locations within a
        ///single application.
        ///</summary>
        [Description("__Not currently set.__ Intended as a Square-assigned identifier, based\non the card number, to identify the card across multiple locations within a\nsingle application.")]
        public string? fingerprint { get; set; }

        ///<summary>
        ///Unique ID for this card. Generated by Square.
        ///</summary>
        [Description("Unique ID for this card. Generated by Square.")]
        public string? id { get; set; }

        ///<summary>
        ///The last 4 digits of the card number; null if the card number was less than 4 characters.
        ///</summary>
        [Description("The last 4 digits of the card number; null if the card number was less than 4 characters.")]
        public string? last4 { get; set; }

        ///<summary>
        ///Indicates whether the Card is prepaid or not.
        ///The Card object includes this field only in response to Payments API calls.
        ///</summary>
        [Description("Indicates whether the Card is prepaid or not.\nThe Card object includes this field only in response to Payments API calls.")]
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
    [Description("Indicates a card's brand, such as `VISA` or `MASTERCARD`.\nThis enumeration is essentially the union of 3 separate protobuf enums:\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\nThis enum is what we present to external clients in our `/v2/payments` API.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\nThis enum is what is used from a [`CardFilter`](https://prototype.sqprod.co/#/docs/squareup.payments.search.Filter.CardFilter#card_brand)\nthat is accepted by Spot's Search API. It includes 3 extra enum values not present on the `Card.Brand` filter\nand also has an alternate name for 3 enum values.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.\nThis enum is what is used within a [`CardTransaction`'s](https://prototype.sqprod.co/#/docs/squareup.esperanto.model.CardTransaction)\n[`Tender`](https://prototype.sqprod.co/#/docs/squareup.esperanto.model.Tender) on a\n[`PaymentRecord`](https://prototype.sqprod.co/#/docs/squareup.esperanto.model.PaymentRecord#card_transaction) within Spot.\nIt is just like `CardTenderType` (including the 3 extra values, and 3 renamed\nvalues) but also includes 1 additional value.\nIdeally we would only have a single source enum here. However, to handle the full dataset and all use cases\nwe need to cover, we have defined this as a union of these 3 enums. When an enum value exists on both the\npublic `Card.Brand` enum and the internal enums, but with a different name, we have chosen the public name.")]
    public enum CardBrand
    {
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        AFTERPAY,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        ALIPAY,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        AMERICAN_EXPRESS,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        AU_PAY,
        ///<summary>
        ///Comes from the internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) or
        ///internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enums.
        ///</summary>
        [Description("Comes from the internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) or\ninternal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enums.")]
        BALANCE,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        CASH_APP,
        ///<summary>
        ///Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///
        ///Also known as `UNIONPAY` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///</summary>
        [Description("Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n\nAlso known as `UNIONPAY` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.")]
        CHINA_UNIONPAY,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        DISCOVER,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        DISCOVER_DINERS,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        D_BARAI,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        EBT,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        EFTPOS,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        FELICA,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        INTERAC,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        JCB,
        ///<summary>
        ///Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///
        ///Also known as `MASTER_CARD` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///</summary>
        [Description("Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n\nAlso known as `MASTER_CARD` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.")]
        MASTERCARD,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        MERPAY,
        ///<summary>
        ///Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///
        ///Also known as `UNKNOWN` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///</summary>
        [Description("Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n\nAlso known as `UNKNOWN` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.")]
        OTHER_BRAND,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        PAYPAY,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        RAKUTEN_PAY,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        SQUARE_ACCOUNT_BALANCE,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        SQUARE_CAPITAL_CARD,
        ///<summary>
        ///Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///
        ///Also known as `SQUARE_GIFT_CARD_V2` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///</summary>
        [Description("Comes from the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n\nAlso known as `SQUARE_GIFT_CARD_V2` on the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.")]
        SQUARE_GIFT_CARD,
        ///<summary>
        ///Present on all 3 of the source enums:
        ///
        ///- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.
        ///- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.
        ///</summary>
        [Description("Present on all 3 of the source enums:\n\n- The public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.\n- The internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType) enum.\n- The internal [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enum.")]
        VISA,
        ///<summary>
        ///Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)
        ///and [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.
        ///
        ///Not present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.
        ///</summary>
        [Description("Comes from the internal [`CardTenderType`](https://prototype.sqprod.co/#/docs/squareup.common.tender.CardTenderType)\nand [`InstrumentType`](https://prototype.sqprod.co/#/docs/squareup.common.instrument.InstrumentType) enums.\n\nNot present on the public [`Card.Brand`](https://prototype.sqprod.co/#/docs/squareup.connect.v2.resources.Card.Brand) enum.")]
        WECHAT_PAY,
    }

    public static class CardBrandStringValues
    {
        public const string AFTERPAY = @"AFTERPAY";
        public const string ALIPAY = @"ALIPAY";
        public const string AMERICAN_EXPRESS = @"AMERICAN_EXPRESS";
        public const string AU_PAY = @"AU_PAY";
        public const string BALANCE = @"BALANCE";
        public const string CASH_APP = @"CASH_APP";
        public const string CHINA_UNIONPAY = @"CHINA_UNIONPAY";
        public const string DISCOVER = @"DISCOVER";
        public const string DISCOVER_DINERS = @"DISCOVER_DINERS";
        public const string D_BARAI = @"D_BARAI";
        public const string EBT = @"EBT";
        public const string EFTPOS = @"EFTPOS";
        public const string FELICA = @"FELICA";
        public const string INTERAC = @"INTERAC";
        public const string JCB = @"JCB";
        public const string MASTERCARD = @"MASTERCARD";
        public const string MERPAY = @"MERPAY";
        public const string OTHER_BRAND = @"OTHER_BRAND";
        public const string PAYPAY = @"PAYPAY";
        public const string RAKUTEN_PAY = @"RAKUTEN_PAY";
        public const string SQUARE_ACCOUNT_BALANCE = @"SQUARE_ACCOUNT_BALANCE";
        public const string SQUARE_CAPITAL_CARD = @"SQUARE_CAPITAL_CARD";
        public const string SQUARE_GIFT_CARD = @"SQUARE_GIFT_CARD";
        public const string VISA = @"VISA";
        public const string WECHAT_PAY = @"WECHAT_PAY";
    }

    ///<summary>
    ///Indicates the brand for a co-branded card.
    ///</summary>
    [Description("Indicates the brand for a co-branded card.")]
    public enum CardCoBrand
    {
        UNKNOWN,
        AFTERPAY,
        CLEARPAY,
    }

    public static class CardCoBrandStringValues
    {
        public const string UNKNOWN = @"UNKNOWN";
        public const string AFTERPAY = @"AFTERPAY";
        public const string CLEARPAY = @"CLEARPAY";
    }

    ///<summary>
    ///Represents the payment details of a card to be used for payments.These
    ///details are determined by the payment token generated by Web Payments SDK.
    ///</summary>
    [Description("Represents the payment details of a card to be used for payments.These\ndetails are determined by the payment token generated by Web Payments SDK.")]
    public class CardOnFile : GraphQLObject<CardOnFile>
    {
        ///<summary>
        ///Unique ID for this card. Generated by Square.
        ///</summary>
        [Description("Unique ID for this card. Generated by Square.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The ID of the merchant associated with the card.
        ///</summary>
        [Description("The ID of the merchant associated with the card.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The card's brand.
        ///</summary>
        [Description("The card's brand.")]
        public CardBrand? cardBrand { get; set; }

        ///<summary>
        ///The last 4 digits of the card number.
        ///</summary>
        [Description("The last 4 digits of the card number.")]
        public string? last4 { get; set; }

        ///<summary>
        ///The expiration month of the associated card as an integer between 1 and 12.
        ///</summary>
        [Description("The expiration month of the associated card as an integer between 1 and 12.")]
        public int? expMonth { get; set; }

        ///<summary>
        ///The four-digit year of the card's expiration date.
        ///</summary>
        [Description("The four-digit year of the card's expiration date.")]
        public int? expYear { get; set; }

        ///<summary>
        ///The name of the cardholder.
        ///</summary>
        [Description("The name of the cardholder.")]
        public string? cardholderName { get; set; }

        ///<summary>
        ///The billing address for this card.
        ///</summary>
        [Description("The billing address for this card.")]
        public Address? billingAddress { get; set; }

        ///<summary>
        ///Intended as a Square-assigned identifier, based
        ///on the card number, to identify the card across multiple locations within a
        ///single application.
        ///</summary>
        [Description("Intended as a Square-assigned identifier, based\non the card number, to identify the card across multiple locations within a\nsingle application.")]
        public string? fingerprint { get; set; }

        ///<summary>
        ///An optional user-defined reference ID that associates this card with
        ///another entity in an external system. For example, a customer ID from an
        ///external customer management system.
        ///</summary>
        [Description("An optional user-defined reference ID that associates this card with\nanother entity in an external system. For example, a customer ID from an\nexternal customer management system.")]
        public string? referenceId { get; set; }

        ///<summary>
        ///Indicates whether or not a card can be used for payments.
        ///</summary>
        [Description("Indicates whether or not a card can be used for payments.")]
        public bool? enabled { get; set; }

        ///<summary>
        ///The type of the card.
        ///The Card object includes this field only in response to Payments API calls.
        ///</summary>
        [Description("The type of the card.\nThe Card object includes this field only in response to Payments API calls.")]
        public CardType? cardType { get; set; }

        ///<summary>
        ///Indicates whether the Card is prepaid or not.
        ///The Card object includes this field only in response to Payments API calls.
        ///</summary>
        [Description("Indicates whether the Card is prepaid or not.\nThe Card object includes this field only in response to Payments API calls.")]
        public CardPrepaidType? prepaidType { get; set; }

        ///<summary>
        ///The first six digits of the card number, known as the Bank Identification Number (BIN). Only the Payments API
        ///returns this field.
        ///</summary>
        [Description("The first six digits of the card number, known as the Bank Identification Number (BIN). Only the Payments API\nreturns this field.")]
        public string? bin { get; set; }

        ///<summary>
        ///Current version number of the card. Increments with each card update. Requests to update an
        ///existing Card object will be rejected unless the version in the request matches the current
        ///version for the Card.
        ///</summary>
        [Description("Current version number of the card. Increments with each card update. Requests to update an\nexisting Card object will be rejected unless the version in the request matches the current\nversion for the Card.")]
        public int? version { get; set; }

        ///<summary>
        ///The card's co-brand if available. For example, an Afterpay virtual card would have a
        ///co-brand of AFTERPAY.
        ///</summary>
        [Description("The card's co-brand if available. For example, an Afterpay virtual card would have a\nco-brand of AFTERPAY.")]
        public CardCoBrand? coBrand { get; set; }

        ///<summary>
        ///The merchant associated with the card.
        ///</summary>
        [Description("The merchant associated with the card.")]
        public Merchant? merchant { get; set; }

        ///<summary>
        ///The customer created using the Customers API to be associated with the card.
        ///</summary>
        [Description("The customer created using the Customers API to be associated with the card.")]
        public Customer? customer { get; set; }
    }

    ///<summary>
    ///Contains information of CardOnFile query result.
    ///
    ///Permissions:PAYMENTS_READ
    ///</summary>
    [Description("Contains information of CardOnFile query result.\n\nPermissions:PAYMENTS_READ")]
    public class CardOnFileConnection : GraphQLObject<CardOnFileConnection>, IConnectionWithNodes<CardOnFile>
    {
        ///<summary>
        ///Provides information about the specific fetched page. This implements the PageInfo specification from the [Relay GraphQL Cursor Connections Specification](https://relay.dev/graphql/connections.htm#sec-undefined.PageInfo).
        ///</summary>
        [Description("Provides information about the specific fetched page. This implements the PageInfo specification from the [Relay GraphQL Cursor Connections Specification](https://relay.dev/graphql/connections.htm#sec-undefined.PageInfo).")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }

        ///<summary>
        ///CardOnFile query result.
        ///</summary>
        [Description("CardOnFile query result.")]
        [NonNull]
        public IEnumerable<CardOnFile>? nodes { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Reflects the current status of a card payment. Contains only non-confidential information.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nReflects the current status of a card payment. Contains only non-confidential information.")]
    public class CardPaymentDetails : GraphQLObject<CardPaymentDetails>
    {
        ///<summary>
        ///For EMV payments, the cryptogram generated for the payment.
        ///</summary>
        [Description("For EMV payments, the cryptogram generated for the payment.")]
        public string? applicationCryptogram { get; set; }

        ///<summary>
        ///For EMV payments, the application ID identifies the EMV application used for the payment.
        ///</summary>
        [Description("For EMV payments, the application ID identifies the EMV application used for the payment.")]
        public string? applicationIdentifier { get; set; }

        ///<summary>
        ///For EMV payments, the human-readable name of the EMV application used for the payment.
        ///</summary>
        [Description("For EMV payments, the human-readable name of the EMV application used for the payment.")]
        public string? applicationName { get; set; }

        ///<summary>
        ///The status code returned by the card issuer that describes the payment's authorization status.
        ///</summary>
        [Description("The status code returned by the card issuer that describes the payment's authorization status.")]
        public string? authResultCode { get; set; }

        ///<summary>
        ///The status code returned from the Address Verification System (AVS) check.
        ///</summary>
        [Description("The status code returned from the Address Verification System (AVS) check.")]
        public CardPaymentDetailsAvsStatus? avsStatus { get; set; }

        ///<summary>
        ///The credit card's non-confidential details.
        ///</summary>
        [Description("The credit card's non-confidential details.")]
        public Card? card { get; set; }

        ///<summary>
        ///The timeline for card payments.
        ///</summary>
        [Description("The timeline for card payments.")]
        public CardPaymentTimeline? cardPaymentTimeline { get; set; }

        ///<summary>
        ///The status code returned from the Card Verification Value (CVV) check.
        ///</summary>
        [Description("The status code returned from the Card Verification Value (CVV) check.")]
        public CardPaymentDetailsCvvStatus? cvvStatus { get; set; }

        ///<summary>
        ///The method used to enter the card's details for the payment.
        ///</summary>
        [Description("The method used to enter the card's details for the payment.")]
        public CardPaymentDetailsEntryMethod? entryMethod { get; set; }

        ///<summary>
        ///Information about errors encountered during the request.
        ///</summary>
        [Description("Information about errors encountered during the request.")]
        [NonNull]
        public IEnumerable<Error>? errors { get; set; }

        ///<summary>
        ///Whether the card must be physically present for the payment to be refunded.  If set to `true`, the card must be present.
        ///</summary>
        [Description("Whether the card must be physically present for the payment to be refunded.  If set to `true`, the card must be present.")]
        public bool? refundRequiresCardPresence { get; set; }

        ///<summary>
        ///The statement description sent to the card networks.
        ///Note: The actual statement description varies and is likely to be truncated and appended with
        ///additional information on a per issuer basis.
        ///</summary>
        [Description("The statement description sent to the card networks.\nNote: The actual statement description varies and is likely to be truncated and appended with\nadditional information on a per issuer basis.")]
        public string? statementDescription { get; set; }

        ///<summary>
        ///The card payment's current state.
        ///</summary>
        [Description("The card payment's current state.")]
        public CardPaymentDetailsStatus? status { get; set; }

        ///<summary>
        ///For EMV payments, the method used to verify the cardholder's identity.
        ///</summary>
        [Description("For EMV payments, the method used to verify the cardholder's identity.")]
        public CardPaymentDetailsVerificationMethod? verificationMethod { get; set; }

        ///<summary>
        ///For EMV payments, the results of the cardholder verification.
        ///</summary>
        [Description("For EMV payments, the results of the cardholder verification.")]
        public CardPaymentDetailsVerificationResult? verificationResults { get; set; }
    }

    ///<summary>
    ///Enumeration of possible status codes returned from an Address Verification System (AVS) check.
    ///</summary>
    [Description("Enumeration of possible status codes returned from an Address Verification System (AVS) check.")]
    public enum CardPaymentDetailsAvsStatus
    {
        AVS_ACCEPTED,
        AVS_NOT_CHECKED,
        AVS_REJECTED,
    }

    public static class CardPaymentDetailsAvsStatusStringValues
    {
        public const string AVS_ACCEPTED = @"AVS_ACCEPTED";
        public const string AVS_NOT_CHECKED = @"AVS_NOT_CHECKED";
        public const string AVS_REJECTED = @"AVS_REJECTED";
    }

    ///<summary>
    ///Enumeration of possible status codes returned from a Card Verification Value (CVV) check.
    ///</summary>
    [Description("Enumeration of possible status codes returned from a Card Verification Value (CVV) check.")]
    public enum CardPaymentDetailsCvvStatus
    {
        CVV_ACCEPTED,
        CVV_NOT_CHECKED,
        CVV_REJECTED,
    }

    public static class CardPaymentDetailsCvvStatusStringValues
    {
        public const string CVV_ACCEPTED = @"CVV_ACCEPTED";
        public const string CVV_NOT_CHECKED = @"CVV_NOT_CHECKED";
        public const string CVV_REJECTED = @"CVV_REJECTED";
    }

    ///<summary>
    ///The method used to enter a card's details for the payment.
    ///</summary>
    [Description("The method used to enter a card's details for the payment.")]
    public enum CardPaymentDetailsEntryMethod
    {
        ///<summary>
        ///Card was tapped to a reader (eg NFC).
        ///</summary>
        [Description("Card was tapped to a reader (eg NFC).")]
        CONTACTLESS,
        ///<summary>
        ///Card was dipped into an EMV reader, and went through the EMV payment flow.
        ///</summary>
        [Description("Card was dipped into an EMV reader, and went through the EMV payment flow.")]
        EMV,
        ///<summary>
        ///Card was keyed in. A CNP payment.
        ///</summary>
        [Description("Card was keyed in. A CNP payment.")]
        KEYED,
        ///<summary>
        ///Card data was pulled from an instrument store.
        ///</summary>
        [Description("Card data was pulled from an instrument store.")]
        ON_FILE,
        ///<summary>
        ///Card was swiped through a reader or stand.
        ///</summary>
        [Description("Card was swiped through a reader or stand.")]
        SWIPED,
    }

    public static class CardPaymentDetailsEntryMethodStringValues
    {
        public const string CONTACTLESS = @"CONTACTLESS";
        public const string EMV = @"EMV";
        public const string KEYED = @"KEYED";
        public const string ON_FILE = @"ON_FILE";
        public const string SWIPED = @"SWIPED";
    }

    ///<summary>
    ///A card payment's current state.
    ///</summary>
    [Description("A card payment's current state.")]
    public enum CardPaymentDetailsStatus
    {
        AUTHORIZED,
        CAPTURED,
        FAILED,
        VOIDED,
    }

    public static class CardPaymentDetailsStatusStringValues
    {
        public const string AUTHORIZED = @"AUTHORIZED";
        public const string CAPTURED = @"CAPTURED";
        public const string FAILED = @"FAILED";
        public const string VOIDED = @"VOIDED";
    }

    ///<summary>
    ///Enumeration of possible methods used for EMV paymentsto verify the cardholder's identity.
    ///</summary>
    [Description("Enumeration of possible methods used for EMV paymentsto verify the cardholder's identity.")]
    public enum CardPaymentDetailsVerificationMethod
    {
        NONE,
        ON_DEVICE,
        PIN,
        PIN_AND_SIGNATURE,
        SIGNATURE,
    }

    public static class CardPaymentDetailsVerificationMethodStringValues
    {
        public const string NONE = @"NONE";
        public const string ON_DEVICE = @"ON_DEVICE";
        public const string PIN = @"PIN";
        public const string PIN_AND_SIGNATURE = @"PIN_AND_SIGNATURE";
        public const string SIGNATURE = @"SIGNATURE";
    }

    ///<summary>
    ///Enumeration of possible card verification results for EMV payments.
    ///</summary>
    [Description("Enumeration of possible card verification results for EMV payments.")]
    public enum CardPaymentDetailsVerificationResult
    {
        FAILURE,
        SUCCESS,
        UNKNOWN,
    }

    public static class CardPaymentDetailsVerificationResultStringValues
    {
        public const string FAILURE = @"FAILURE";
        public const string SUCCESS = @"SUCCESS";
        public const string UNKNOWN = @"UNKNOWN";
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///The timeline for card payments.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nThe timeline for card payments.")]
    public class CardPaymentTimeline : GraphQLObject<CardPaymentTimeline>
    {
        ///<summary>
        ///The timestamp when the payment was authorized, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp when the payment was authorized, in RFC 3339 format.")]
        public DateTime? authorizedAt { get; set; }

        ///<summary>
        ///The timestamp when the payment was captured, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp when the payment was captured, in RFC 3339 format.")]
        public DateTime? capturedAt { get; set; }

        ///<summary>
        ///The timestamp when the payment was voided, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp when the payment was voided, in RFC 3339 format.")]
        public DateTime? voidedAt { get; set; }
    }

    ///<summary>
    ///Indicates a card's prepaid type, such as `NOT_PREPAID` or `PREPAID`.
    ///</summary>
    [Description("Indicates a card's prepaid type, such as `NOT_PREPAID` or `PREPAID`.")]
    public enum CardPrepaidType
    {
        NOT_PREPAID,
        PREPAID,
        UNKNOWN_PREPAID_TYPE,
    }

    public static class CardPrepaidTypeStringValues
    {
        public const string NOT_PREPAID = @"NOT_PREPAID";
        public const string PREPAID = @"PREPAID";
        public const string UNKNOWN_PREPAID_TYPE = @"UNKNOWN_PREPAID_TYPE";
    }

    ///<summary>
    ///Indicates a card's type, such as `CREDIT` or `DEBIT`.
    ///</summary>
    [Description("Indicates a card's type, such as `CREDIT` or `DEBIT`.")]
    public enum CardType
    {
        CREDIT,
        DEBIT,
        UNKNOWN_CARD_TYPE,
    }

    public static class CardTypeStringValues
    {
        public const string CREDIT = @"CREDIT";
        public const string DEBIT = @"DEBIT";
        public const string UNKNOWN_CARD_TYPE = @"UNKNOWN_CARD_TYPE";
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about `WALLET` type payments with the `brand` of `CASH_APP`.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nAdditional details about `WALLET` type payments with the `brand` of `CASH_APP`.")]
    public class CashAppPaymentDetails : GraphQLObject<CashAppPaymentDetails>
    {
        ///<summary>
        ///$Cashtag of the Cash App account holder.
        ///</summary>
        [Description("$Cashtag of the Cash App account holder.")]
        public string? buyerCashtag { get; set; }

        ///<summary>
        ///The country of the Cash App account holder.
        ///</summary>
        [Description("The country of the Cash App account holder.")]
        public Country? buyerCountryCode { get; set; }

        ///<summary>
        ///The name of the Cash App account holder.
        ///</summary>
        [Description("The name of the Cash App account holder.")]
        public string? buyerFullName { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Stores details about a cash payment. Contains only non-confidential information. For more information, see
    ///[Take Cash Payments](https://developer.squareup.com/docs/payments-api/take-payments/cash-payments).
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nStores details about a cash payment. Contains only non-confidential information. For more information, see\n[Take Cash Payments](https://developer.squareup.com/docs/payments-api/take-payments/cash-payments).")]
    public class CashPaymentDetails : GraphQLObject<CashPaymentDetails>
    {
        ///<summary>
        ///The amount and currency of the money supplied by the buyer.
        ///</summary>
        [Description("The amount and currency of the money supplied by the buyer.")]
        public Money? buyerSuppliedMoney { get; set; }

        ///<summary>
        ///The amount of change due back to the buyer.
        ///This read-only field is calculated from the `amountMoney` and `buyerSuppliedMoney` fields.
        ///</summary>
        [Description("The amount of change due back to the buyer.\nThis read-only field is calculated from the `amountMoney` and `buyerSuppliedMoney` fields.")]
        public Money? changeBackMoney { get; set; }
    }

    ///<summary>
    ///A category to which a `CatalogItem` instance belongs.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("A category to which a `CatalogItem` instance belongs.\nPermissions: ITEMS_READ")]
    public class CatalogCategory : GraphQLObject<CatalogCategory>, ICatalogObject
    {
        ///<summary>
        ///The category name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        [Description("The category name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.")]
        public string? name { get; set; }

        ///<summary>
        ///The IDs of images associated with this `CatalogCategory` instance.
        ///Currently these images are not displayed by Square, but are free to be displayed in 3rd party applications.
        ///</summary>
        [Description("The IDs of images associated with this `CatalogCategory` instance.\nCurrently these images are not displayed by Square, but are free to be displayed in 3rd party applications.")]
        public IEnumerable<CatalogImage>? images { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Provides information when CatalogCustomAttributeValue.value is Boolean.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("Provides information when CatalogCustomAttributeValue.value is Boolean.\n\nPermissions:ITEMS_READ")]
    public class CatalogCustomAttributeBoolean : GraphQLObject<CatalogCustomAttributeBoolean>, ICatalogCustomAttributeValueUnion
    {
        ///<summary>
        ///A true or false value.
        ///</summary>
        [Description("A true or false value.")]
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
    [Description("Contains information defining a custom attribute.Custom attributes are\nintended to store additional information about a catalog object or to associate a\ncatalog object with an entity in another system. Do not use custom attributes\nto store any sensitive information (personally identifiable information, card details, etc.).\n[Read more about custom attributes](https://developer.squareup.com/docs/catalog-api/add-custom-attributes)\nPermissions: ITEMS_READ")]
    public class CatalogCustomAttributeDefinition : GraphQLObject<CatalogCustomAttributeDefinition>, ICatalogObject
    {
        ///<summary>
        ///The type of this custom attribute. Cannot be modified after creation.
        ///Required.
        ///</summary>
        [Description("The type of this custom attribute. Cannot be modified after creation.\nRequired.")]
        public CatalogCustomAttributeType? type { get; set; }

        ///<summary>
        /// The name of this definition for API and seller-facing UI purposes.
        ///The name must be unique within the (merchant, application) pair. Required.
        ///May not be empty and may not exceed 255 characters. Can be modified after creation.
        ///</summary>
        [Description(" The name of this definition for API and seller-facing UI purposes.\nThe name must be unique within the (merchant, application) pair. Required.\nMay not be empty and may not exceed 255 characters. Can be modified after creation.")]
        public string? name { get; set; }

        ///<summary>
        ///Seller-oriented description of the meaning of this Custom Attribute,
        ///any constraints that the seller should observe, etc. May be displayed as a tooltip in Square UIs.
        ///</summary>
        [Description("Seller-oriented description of the meaning of this Custom Attribute,\nany constraints that the seller should observe, etc. May be displayed as a tooltip in Square UIs.")]
        public string? description { get; set; }

        ///<summary>
        ///__Read only.__ Contains information about the application that
        ///created this custom attribute definition.
        ///</summary>
        [Description("__Read only.__ Contains information about the application that\ncreated this custom attribute definition.")]
        public SourceApplication? sourceApplication { get; set; }

        ///<summary>
        ///The set of `CatalogObject` types that this custom atttribute may be applied to.
        ///Currently, only `ITEM`, `ITEM_VARIATION`, and `MODIFIER` are allowed. At least one type must be included.
        ///</summary>
        [Description("The set of `CatalogObject` types that this custom atttribute may be applied to.\nCurrently, only `ITEM`, `ITEM_VARIATION`, and `MODIFIER` are allowed. At least one type must be included.")]
        public IEnumerable<CatalogObjectType>? allowedObjectTypes { get; set; }

        ///<summary>
        ///The visibility of a custom attribute in seller-facing UIs (including Square Point
        ///of Sale applications and Square Dashboard). May be modified.
        ///</summary>
        [Description("The visibility of a custom attribute in seller-facing UIs (including Square Point\nof Sale applications and Square Dashboard). May be modified.")]
        public CatalogCustomAttributeDefinitionSellerVisibility? sellerVisibility { get; set; }

        ///<summary>
        ///The visibility of a custom attribute to applications other than the application
        ///that created the attribute.
        ///</summary>
        [Description("The visibility of a custom attribute to applications other than the application\nthat created the attribute.")]
        public CatalogCustomAttributeDefinitionAppVisibility? appVisibility { get; set; }

        ///<summary>
        ///The name of the desired custom attribute key that can be used to access
        ///the custom attribute value on catalog objects. Cannot be modified after the
        ///custom attribute definition has been created.
        ///Must be between 1 and 60 characters, and may only contain the characters `[a-zA-Z0-9_-]`.
        ///</summary>
        [Description("The name of the desired custom attribute key that can be used to access\nthe custom attribute value on catalog objects. Cannot be modified after the\ncustom attribute definition has been created.\nMust be between 1 and 60 characters, and may only contain the characters `[a-zA-Z0-9_-]`.")]
        public string? key { get; set; }

        ///<summary>
        ///The number of custom attributes that reference this
        ///custom attribute definition. Set by the server in response to a ListCatalog
        ///request with `include_counts` set to `true`.  If the actual count is greater
        ///than 100, `custom_attribute_usage_count` will be set to `100`.
        ///</summary>
        [Description("The number of custom attributes that reference this\ncustom attribute definition. Set by the server in response to a ListCatalog\nrequest with `include_counts` set to `true`.  If the actual count is greater\nthan 100, `custom_attribute_usage_count` will be set to `100`.")]
        public int? usageCount { get; set; }

        ///<summary>
        ///Configuration for CatalogCustomAttributeDefinition
        ///</summary>
        [Description("Configuration for CatalogCustomAttributeDefinition")]
        public ICatalogCustomAttributeDefinitionConfig? config { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Defines the visibility of a custom attribute to applications other than their
    ///creating application.
    ///</summary>
    [Description("Defines the visibility of a custom attribute to applications other than their\ncreating application.")]
    public enum CatalogCustomAttributeDefinitionAppVisibility
    {
        ///<summary>
        ///Other applications cannot read this custom attribute.
        ///</summary>
        [Description("Other applications cannot read this custom attribute.")]
        APP_VISIBILITY_HIDDEN,
        ///<summary>
        ///Other applications can read this custom attribute definition and
        ///values.
        ///</summary>
        [Description("Other applications can read this custom attribute definition and\nvalues.")]
        APP_VISIBILITY_READ_ONLY,
        ///<summary>
        ///Other applications can read and write custom attribute values on objects.
        ///They can read but cannot edit the custom attribute definition.
        ///</summary>
        [Description("Other applications can read and write custom attribute values on objects.\nThey can read but cannot edit the custom attribute definition.")]
        APP_VISIBILITY_READ_WRITE_VALUES,
    }

    public static class CatalogCustomAttributeDefinitionAppVisibilityStringValues
    {
        public const string APP_VISIBILITY_HIDDEN = @"APP_VISIBILITY_HIDDEN";
        public const string APP_VISIBILITY_READ_ONLY = @"APP_VISIBILITY_READ_ONLY";
        public const string APP_VISIBILITY_READ_WRITE_VALUES = @"APP_VISIBILITY_READ_WRITE_VALUES";
    }

    ///<summary>
    ///Defines the config for CatalogCustomAttributeDefinition.
    ///</summary>
    [Description("Defines the config for CatalogCustomAttributeDefinition.")]
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
    [Description("Defines the visibility of a custom attribute to sellers in Square\nclient applications, Square APIs or in Square UIs (including Square Point\nof Sale applications and Square Dashboard).")]
    public enum CatalogCustomAttributeDefinitionSellerVisibility
    {
        ///<summary>
        ///Sellers cannot read this custom attribute in Square client
        ///applications or Square APIs.
        ///</summary>
        [Description("Sellers cannot read this custom attribute in Square client\napplications or Square APIs.")]
        SELLER_VISIBILITY_HIDDEN,
        ///<summary>
        ///Sellers can read and write this custom attribute value in catalog objects,
        ///but cannot edit the custom attribute definition.
        ///</summary>
        [Description("Sellers can read and write this custom attribute value in catalog objects,\nbut cannot edit the custom attribute definition.")]
        SELLER_VISIBILITY_READ_WRITE_VALUES,
    }

    public static class CatalogCustomAttributeDefinitionSellerVisibilityStringValues
    {
        public const string SELLER_VISIBILITY_HIDDEN = @"SELLER_VISIBILITY_HIDDEN";
        public const string SELLER_VISIBILITY_READ_WRITE_VALUES = @"SELLER_VISIBILITY_READ_WRITE_VALUES";
    }

    ///<summary>
    ///Provides information when CatalogCustomAttributeValue.value is Number.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("Provides information when CatalogCustomAttributeValue.value is Number.\n\nPermissions:ITEMS_READ")]
    public class CatalogCustomAttributeNumber : GraphQLObject<CatalogCustomAttributeNumber>, ICatalogCustomAttributeValueUnion
    {
        ///<summary>
        ///Contains a string representation of a decimal number, using a . as the decimal separator.
        ///</summary>
        [Description("Contains a string representation of a decimal number, using a . as the decimal separator.")]
        public decimal? value { get; set; }
    }

    ///<summary>
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Permissions: ITEMS_READ")]
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
        [Description("An integer between 0 and 5 that represents the maximum number of\npositions allowed after the decimal in number custom attribute values\nFor example:\n\n- if the precision is 0, the quantity can be 1, 2, 3, etc.\n- if the precision is 1, the quantity can be 0.1, 0.2, etc.\n- if the precision is 2, the quantity can be 0.01, 0.12, etc.\n\nDefault: 5")]
        public int? precision { get; set; }
    }

    ///<summary>
    ///Provides information when CatalogCustomAttributeValue.value is Selection.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("Provides information when CatalogCustomAttributeValue.value is Selection.\n\nPermissions:ITEMS_READ")]
    public class CatalogCustomAttributeSelection : GraphQLObject<CatalogCustomAttributeSelection>, ICatalogCustomAttributeValueUnion
    {
        ///<summary>
        ///One or more choices from allowed_selections.
        ///</summary>
        [Description("One or more choices from allowed_selections.")]
        public IEnumerable<string>? uids { get; set; }
    }

    ///<summary>
    ///Configuration associated with `SELECTION`-type custom attribute definitions.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Configuration associated with `SELECTION`-type custom attribute definitions.\nPermissions: ITEMS_READ")]
    public class CatalogCustomAttributeSelectionConfig : GraphQLObject<CatalogCustomAttributeSelectionConfig>, ICatalogCustomAttributeDefinitionConfig
    {
        ///<summary>
        ///The maximum number of selections that can be set. The maximum value for this
        ///attribute is 100. The default value is 1. The value can be modified, but changing the value will not
        ///affect existing custom attribute values on objects. Clients need to
        ///handle custom attributes with more selected values than allowed by this limit.
        ///</summary>
        [Description("The maximum number of selections that can be set. The maximum value for this\nattribute is 100. The default value is 1. The value can be modified, but changing the value will not\naffect existing custom attribute values on objects. Clients need to\nhandle custom attributes with more selected values than allowed by this limit.")]
        public int? maxAllowedSelections { get; set; }

        ///<summary>
        ///The set of valid `CatalogCustomAttributeSelections`. Up to a maximum of 100
        ///selections can be defined. Can be modified.
        ///</summary>
        [Description("The set of valid `CatalogCustomAttributeSelections`. Up to a maximum of 100\nselections can be defined. Can be modified.")]
        public IEnumerable<CatalogCustomAttributeSelectionDefinition>? allowedSelections { get; set; }
    }

    ///<summary>
    ///A named selection for this `SELECTION`-type custom attribute definition.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("A named selection for this `SELECTION`-type custom attribute definition.\nPermissions: ITEMS_READ")]
    public class CatalogCustomAttributeSelectionDefinition : GraphQLObject<CatalogCustomAttributeSelectionDefinition>
    {
        ///<summary>
        ///Unique ID set by Square.
        ///</summary>
        [Description("Unique ID set by Square.")]
        public string? uid { get; set; }

        ///<summary>
        ///Selection name, unique within `allowed_selections`.
        ///</summary>
        [Description("Selection name, unique within `allowed_selections`.")]
        public string? name { get; set; }
    }

    ///<summary>
    ///Provides information when CatalogCustomAttributeValue.value is String.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("Provides information when CatalogCustomAttributeValue.value is String.\n\nPermissions:ITEMS_READ")]
    public class CatalogCustomAttributeString : GraphQLObject<CatalogCustomAttributeString>, ICatalogCustomAttributeValueUnion
    {
        ///<summary>
        ///The string value of the custom attribute.
        ///</summary>
        [Description("The string value of the custom attribute.")]
        public string? value { get; set; }
    }

    ///<summary>
    ///Configuration associated with Custom Attribute Definitions of type `STRING`.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Configuration associated with Custom Attribute Definitions of type `STRING`.\nPermissions: ITEMS_READ")]
    public class CatalogCustomAttributeStringConfig : GraphQLObject<CatalogCustomAttributeStringConfig>, ICatalogCustomAttributeDefinitionConfig
    {
        ///<summary>
        ///If true, each Custom Attribute instance associated with this Custom Attribute
        ///Definition must have a unique value within the seller's catalog. For
        ///example, this may be used for a value like a SKU that should not be
        ///duplicated within a seller's catalog. May not be modified after the
        ///definition has been created.
        ///</summary>
        [Description("If true, each Custom Attribute instance associated with this Custom Attribute\nDefinition must have a unique value within the seller's catalog. For\nexample, this may be used for a value like a SKU that should not be\nduplicated within a seller's catalog. May not be modified after the\ndefinition has been created.")]
        public bool? enforceUniqueness { get; set; }
    }

    ///<summary>
    ///Defines the possible types for a custom attribute.
    ///</summary>
    [Description("Defines the possible types for a custom attribute.")]
    public enum CatalogCustomAttributeType
    {
        ///<summary>
        ///A free-form string containing up to 255 characters.
        ///</summary>
        [Description("A free-form string containing up to 255 characters.")]
        STRING,
        ///<summary>
        ///A `true` or `false` value.
        ///</summary>
        [Description("A `true` or `false` value.")]
        BOOLEAN,
        ///<summary>
        ///A decimal string representation of a number. Can support up to 5 digits after the decimal point.
        ///</summary>
        [Description("A decimal string representation of a number. Can support up to 5 digits after the decimal point.")]
        NUMBER,
        ///<summary>
        ///One or more choices from `allowed_selections`.
        ///</summary>
        [Description("One or more choices from `allowed_selections`.")]
        SELECTION,
    }

    public static class CatalogCustomAttributeTypeStringValues
    {
        public const string STRING = @"STRING";
        public const string BOOLEAN = @"BOOLEAN";
        public const string NUMBER = @"NUMBER";
        public const string SELECTION = @"SELECTION";
    }

    ///<summary>
    ///An instance of a custom attribute.
    ///Custom attributes can be defined and added to ITEM and ITEM_VARIATION type catalog objects.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("An instance of a custom attribute.\nCustom attributes can be defined and added to ITEM and ITEM_VARIATION type catalog objects.\n\nPermissions:ITEMS_READ")]
    public class CatalogCustomAttributeValue : GraphQLObject<CatalogCustomAttributeValue>
    {
        ///<summary>
        ///Contains information defining a custom attribute.
        ///</summary>
        [Description("Contains information defining a custom attribute.")]
        public CatalogCustomAttributeDefinition? definition { get; set; }

        ///<summary>
        ///Provides information for CatalogCustomAttributeValue.value
        ///</summary>
        [Description("Provides information for CatalogCustomAttributeValue.value")]
        public ICatalogCustomAttributeValueUnion? value { get; set; }
    }

    ///<summary>
    ///Provides information for CatalogCustomAttributeValue.value
    ///</summary>
    [Description("Provides information for CatalogCustomAttributeValue.value")]
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
    [Description("A discount applicable to items.\nPermissions: ITEMS_READ")]
    public class CatalogDiscount : GraphQLObject<CatalogDiscount>, ICatalogObject
    {
        ///<summary>
        ///The discount name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        [Description("The discount name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.")]
        public string? name { get; set; }

        ///<summary>
        ///Indicates whether the discount is a fixed amount or percentage, or entered at the time of sale.
        ///</summary>
        [Description("Indicates whether the discount is a fixed amount or percentage, or entered at the time of sale.")]
        public CatalogDiscountType? discountType { get; set; }

        ///<summary>
        ///The amount of the discount. Specify an amount of `0` if `discount_type` is `VARIABLE_AMOUNT`.
        ///
        ///Do not use this field for percentage-based or variable discounts.
        ///</summary>
        [Description("The amount of the discount. Specify an amount of `0` if `discount_type` is `VARIABLE_AMOUNT`.\n\nDo not use this field for percentage-based or variable discounts.")]
        public Money? amountMoney { get; set; }

        ///<summary>
        ///Indicates whether a mobile staff member needs to enter their PIN to apply the
        ///discount to a payment in the Square Point of Sale app.
        ///</summary>
        [Description("Indicates whether a mobile staff member needs to enter their PIN to apply the\ndiscount to a payment in the Square Point of Sale app.")]
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
        [Description("Indicates whether this discount should reduce the price used to calculate tax.\n\nMost discounts should use `MODIFY_TAX_BASIS`. However, in some circumstances taxes must\nbe calculated based on an item's price, ignoring a particular discount. For example,\nin many US jurisdictions, a manufacturer coupon or instant rebate reduces the price a\ncustomer pays but does not reduce the sale price used to calculate how much sales tax is\ndue. In this case, the discount representing that manufacturer coupon should have\n`DO_NOT_MODIFY_TAX_BASIS` for this field.\n\nIf you are unsure whether you need to use this field, consult your tax professional.")]
        public CatalogDiscountModifyTaxBasis? modifyTaxBasis { get; set; }

        ///<summary>
        ///For a percentage discount, the maximum absolute value of the discount. For example, if a
        ///50% discount has a `maximum_amount_money` of $20, a $100 purchase will yield a $20 discount,
        ///not a $50 discount.
        ///</summary>
        [Description("For a percentage discount, the maximum absolute value of the discount. For example, if a\n50% discount has a `maximum_amount_money` of $20, a $100 purchase will yield a $20 discount,\nnot a $50 discount.")]
        public Money? maximumAmountMoney { get; set; }

        ///<summary>
        ///The color of the discount display label in the Square Point of Sale app. This must be a valid hex color code.
        ///</summary>
        [Description("The color of the discount display label in the Square Point of Sale app. This must be a valid hex color code.")]
        public string? labelColor { get; set; }

        ///<summary>
        ///The percentage of the discount as a string representation of a decimal number, using a `.` as the decimal
        ///separator and without a `%` sign. A value of `7.5` corresponds to `7.5%`. Specify a percentage of `0` if `discount_type`
        ///is `VARIABLE_PERCENTAGE`.
        ///
        ///Do not use this field for amount-based or variable discounts.
        ///</summary>
        [Description("The percentage of the discount as a string representation of a decimal number, using a `.` as the decimal\nseparator and without a `%` sign. A value of `7.5` corresponds to `7.5%`. Specify a percentage of `0` if `discount_type`\nis `VARIABLE_PERCENTAGE`.\n\nDo not use this field for amount-based or variable discounts.")]
        public decimal? percentage { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    public enum CatalogDiscountModifyTaxBasis
    {
        ///<summary>
        ///Application of the discount will modify the tax basis.
        ///</summary>
        [Description("Application of the discount will modify the tax basis.")]
        MODIFY_TAX_BASIS,
        ///<summary>
        ///Application of the discount will not modify the tax basis.
        ///</summary>
        [Description("Application of the discount will not modify the tax basis.")]
        DO_NOT_MODIFY_TAX_BASIS,
    }

    public static class CatalogDiscountModifyTaxBasisStringValues
    {
        public const string MODIFY_TAX_BASIS = @"MODIFY_TAX_BASIS";
        public const string DO_NOT_MODIFY_TAX_BASIS = @"DO_NOT_MODIFY_TAX_BASIS";
    }

    ///<summary>
    ///How to apply a CatalogDiscount to a CatalogItem.
    ///</summary>
    [Description("How to apply a CatalogDiscount to a CatalogItem.")]
    public enum CatalogDiscountType
    {
        ///<summary>
        ///Apply the discount as a fixed percentage (e.g., 5%) off the item price.
        ///</summary>
        [Description("Apply the discount as a fixed percentage (e.g., 5%) off the item price.")]
        FIXED_PERCENTAGE,
        ///<summary>
        ///Apply the discount as a fixed amount (e.g., $1.00) off the item price.
        ///</summary>
        [Description("Apply the discount as a fixed amount (e.g., $1.00) off the item price.")]
        FIXED_AMOUNT,
        ///<summary>
        ///Apply the discount as a variable percentage off the item price. The percentage will be specified at the time of sale.
        ///</summary>
        [Description("Apply the discount as a variable percentage off the item price. The percentage will be specified at the time of sale.")]
        VARIABLE_PERCENTAGE,
        ///<summary>
        ///Apply the discount as a variable amount off the item price. The amount will be specified at the time of sale.
        ///</summary>
        [Description("Apply the discount as a variable amount off the item price. The amount will be specified at the time of sale.")]
        VARIABLE_AMOUNT,
    }

    public static class CatalogDiscountTypeStringValues
    {
        public const string FIXED_PERCENTAGE = @"FIXED_PERCENTAGE";
        public const string FIXED_AMOUNT = @"FIXED_AMOUNT";
        public const string VARIABLE_PERCENTAGE = @"VARIABLE_PERCENTAGE";
        public const string VARIABLE_AMOUNT = @"VARIABLE_AMOUNT";
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
    [Description("An image file to use in Square catalogs.It can be associated with\n`CatalogItem`, `CatalogItemVariation`, `CatalogCategory`, and `CatalogModifierList` objects.\nOnly the images on items and item variations are exposed in Dashboard.\nOnly the first image on an item is displayed in Square Point of Sale (SPOS).\nImages on items and variations are displayed through Square Online Store.\nImages on other object types are for use by 3rd party application developers.\nPermissions: ITEMS_READ")]
    public class CatalogImage : GraphQLObject<CatalogImage>, ICatalogObject
    {
        ///<summary>
        ///The internal name to identify this image in calls to the Square API.
        ///This is a searchable attribute for use in applicable query filters
        ///using the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects).
        ///It is not unique and should not be shown in a buyer facing context.
        ///</summary>
        [Description("The internal name to identify this image in calls to the Square API.\nThis is a searchable attribute for use in applicable query filters\nusing the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects).\nIt is not unique and should not be shown in a buyer facing context.")]
        public string? name { get; set; }

        ///<summary>
        ///A caption that describes what is shown in the image. Displayed in the
        ///Square Online Store. This is a searchable attribute for use in applicable query filters
        ///using the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects).
        ///</summary>
        [Description("A caption that describes what is shown in the image. Displayed in the\nSquare Online Store. This is a searchable attribute for use in applicable query filters\nusing the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects).")]
        public string? caption { get; set; }

        ///<summary>
        ///The immutable order ID for this image object created by the Photo Studio service in Square Online Store.
        ///</summary>
        [Description("The immutable order ID for this image object created by the Photo Studio service in Square Online Store.")]
        public string? photoStudioOrderId { get; set; }

        ///<summary>
        ///The URL of this image, generated by Square after an image is uploaded
        ///using the [CreateCatalogImage](api-endpoint:Catalog-CreateCatalogImage) endpoint.
        ///To modify the image, use the UpdateCatalogImage endpoint. Do not change the URL field.
        ///</summary>
        [Description("The URL of this image, generated by Square after an image is uploaded\nusing the [CreateCatalogImage](api-endpoint:Catalog-CreateCatalogImage) endpoint.\nTo modify the image, use the UpdateCatalogImage endpoint. Do not change the URL field.")]
        public string? url { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///An CatalogObject instance of the ITEM type, also referred to as an item, in the catalog.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("An CatalogObject instance of the ITEM type, also referred to as an item, in the catalog.\n\nPermissions:ITEMS_READ")]
    public class CatalogItem : GraphQLObject<CatalogItem>, ICatalogObject
    {
        ///<summary>
        ///The item's name. This is a searchable attribute for use in applicable query filters, its value must not be empty, and the length is of Unicode code points.
        ///</summary>
        [Description("The item's name. This is a searchable attribute for use in applicable query filters, its value must not be empty, and the length is of Unicode code points.")]
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
        [Description("The item's description. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.\n\nDeprecated at 2022-07-20, this field is planned to retire in 6 months. You should migrate to use `description_html` to set the description\nof the CatalogItem instance.  The `description` and `description_html` field values are kept in sync. If you try to\nset the both fields, the `description_html` text value overwrites the `description` value. Updates in one field are also reflected in the other,\nexcept for when you use an early version before Square API 2022-07-20 and `description_html` is set to blank, setting the `description` value to null\ndoes not nullify `description_html`.")]
        public string? description { get; set; }

        ///<summary>
        ///The text of the item's display label in the Square Point of Sale app. Only up to the first five characters of the string are used.
        ///This attribute is searchable, and its value length is of Unicode code points.
        ///</summary>
        [Description("The text of the item's display label in the Square Point of Sale app. Only up to the first five characters of the string are used.\nThis attribute is searchable, and its value length is of Unicode code points.")]
        public string? abbreviation { get; set; }

        ///<summary>
        ///If `true`, the item can be added to shipping orders from the merchant's online store.
        ///</summary>
        [Description("If `true`, the item can be added to shipping orders from the merchant's online store.")]
        public bool? availableOnline { get; set; }

        ///<summary>
        ///If `true`, the item can be added to pickup orders from the merchant's online store.
        ///</summary>
        [Description("If `true`, the item can be added to pickup orders from the merchant's online store.")]
        public bool? availableForPickup { get; set; }

        ///<summary>
        ///If `true`, the item can be added to electronically fulfilled orders from the merchant's online store.
        ///</summary>
        [Description("If `true`, the item can be added to electronically fulfilled orders from the merchant's online store.")]
        public bool? availableElectronically { get; set; }

        ///<summary>
        ///The product type of the item. May not be changed once an item has been created.
        ///
        ///Only items of product type `REGULAR` or `APPOINTMENTS_SERVICE` may be created by this API; items with other product
        ///types are read-only.
        ///</summary>
        [Description("The product type of the item. May not be changed once an item has been created.\n\nOnly items of product type `REGULAR` or `APPOINTMENTS_SERVICE` may be created by this API; items with other product\ntypes are read-only.")]
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
        [Description("If `false`, the Square Point of Sale app will present the `CatalogItem`'s\ndetails screen immediately, allowing the merchant to choose `CatalogModifier`s\nbefore adding the item to the cart.  This is the default behavior.\n\nIf `true`, the Square Point of Sale app will immediately add the item to the cart with the pre-selected\nmodifiers, and merchants can edit modifiers by drilling down onto the item's details.\n\nThird-party clients are encouraged to implement similar behaviors.")]
        public bool? skipModifierScreen { get; set; }

        ///<summary>
        ///A name to sort the item by. If this name is unspecified, namely, the `sort_name` field is absent, the regular `name` field is used for sorting.
        ///Its value must not be empty.
        ///
        ///It is currently supported for sellers of the Japanese locale only.
        ///</summary>
        [Description("A name to sort the item by. If this name is unspecified, namely, the `sort_name` field is absent, the regular `name` field is used for sorting.\nIts value must not be empty.\n\nIt is currently supported for sellers of the Japanese locale only.")]
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
        [Description("The item's description as expressed in valid HTML elements. The length of this field value, including those of HTML tags,\nis of Unicode points. With application query filters, the text values of the HTML elements and attributes are searchable. Invalid or\nunsupported HTML elements or attributes are ignored.\n\nSupported HTML elements include:\n- `a`: Link. Supports linking to website URLs, email address, and telephone numbers.\n- `b`, `strong`:  Bold text\n- `br`: Line break\n- `code`: Computer code\n- `div`: Section\n- `h1-h6`: Headings\n- `i`, `em`: Italics\n- `li`: List element\n- `ol`: Numbered list\n- `p`: Paragraph\n- `ul`: Bullet list\n- `u`: Underline\n\n\nSupported HTML attributes include:\n- `align`: Alignment of the text content\n- `href`: Link destination\n- `rel`: Relationship between link's target and source\n- `target`: Place to open the linked document")]
        public string? descriptionHtml { get; set; }

        ///<summary>
        ///A server-generated plaintext version of the `description_html` field, without formatting tags.
        ///</summary>
        [Description("A server-generated plaintext version of the `description_html` field, without formatting tags.")]
        public string? descriptionPlaintext { get; set; }

        ///<summary>
        ///Indicates whether this item is archived (`true`) or not (`false`).
        ///</summary>
        [Description("Indicates whether this item is archived (`true`) or not (`false`).")]
        public bool? isArchived { get; set; }

        ///<summary>
        ///The color of the item's display label in the Square Point of Sale app. This must be a valid hex color code.
        ///</summary>
        [Description("The color of the item's display label in the Square Point of Sale app. This must be a valid hex color code.")]
        public string? labelColor { get; set; }

        ///<summary>
        ///The ID of the item's category, if any.
        ///</summary>
        [Description("The ID of the item's category, if any.")]
        public CatalogCategory? category { get; set; }

        ///<summary>
        ///List of item options IDs for this item. Used to manage and group item
        ///variations in a specified order.
        ///
        ///Maximum: 6 item options.
        ///</summary>
        [Description("List of item options IDs for this item. Used to manage and group item\nvariations in a specified order.\n\nMaximum: 6 item options.")]
        public IEnumerable<CatalogItemOption>? options { get; set; }

        ///<summary>
        ///A set of IDs indicating the taxes enabled for
        ///this item. When updating an item, any taxes listed here will be added to the item.
        ///Taxes may also be added to or deleted from an item using `UpdateItemTaxes`.
        ///</summary>
        [Description("A set of IDs indicating the taxes enabled for\nthis item. When updating an item, any taxes listed here will be added to the item.\nTaxes may also be added to or deleted from an item using `UpdateItemTaxes`.")]
        public IEnumerable<CatalogTax>? taxes { get; set; }

        ///<summary>
        ///A list of CatalogItemVariation objects for this item. An item must have
        ///at least one variation.
        ///</summary>
        [Description("A list of CatalogItemVariation objects for this item. An item must have\nat least one variation.")]
        public IEnumerable<CatalogItemVariation>? variations { get; set; }

        ///<summary>
        ///The IDs of images associated with this `CatalogItem` instance.
        ///These images will be shown to customers in Square Online Store.
        ///The first image will show up as the icon for this item in POS.
        ///</summary>
        [Description("The IDs of images associated with this `CatalogItem` instance.\nThese images will be shown to customers in Square Online Store.\nThe first image will show up as the icon for this item in POS.")]
        public IEnumerable<CatalogImage>? images { get; set; }

        ///<summary>
        ///A set of `CatalogItemModifierListInfo` objects
        ///representing the modifier lists that apply to this item, along with the overrides and min
        ///and max limits that are specific to this item. Modifier lists
        ///may also be added to or deleted from an item using `UpdateItemModifierLists`.
        ///</summary>
        [Description("A set of `CatalogItemModifierListInfo` objects\nrepresenting the modifier lists that apply to this item, along with the overrides and min\nand max limits that are specific to this item. Modifier lists\nmay also be added to or deleted from an item using `UpdateItemModifierLists`.")]
        public IEnumerable<CatalogItemModifierListInfo>? modifierListInfos { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a "#" character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///When the server receives the new object, it will supply a unique identifier that replaces the temporary identifier for all future references.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a \"#\" character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.\nWhen the server receives the new object, it will supply a unique identifier that replaces the temporary identifier for all future references.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Contains information of items query result.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("Contains information of items query result.\n\nPermissions:ITEMS_READ")]
    public class CatalogItemConnection : GraphQLObject<CatalogItemConnection>, IConnectionWithNodes<CatalogItem>
    {
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }

        ///<summary>
        ///List of CatalogItems
        ///</summary>
        [Description("List of CatalogItems")]
        [NonNull]
        public IEnumerable<CatalogItem>? nodes { get; set; }
    }

    ///<summary>
    ///Options to control the properties of a `CatalogModifierList` applied to a `CatalogItem` instance.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Options to control the properties of a `CatalogModifierList` applied to a `CatalogItem` instance.\nPermissions: ITEMS_READ")]
    public class CatalogItemModifierListInfo : GraphQLObject<CatalogItemModifierListInfo>
    {
        ///<summary>
        ///A set of `CatalogModifierOverride` objects that override whether a given `CatalogModifier` is enabled by default.
        ///</summary>
        [Description("A set of `CatalogModifierOverride` objects that override whether a given `CatalogModifier` is enabled by default.")]
        public IEnumerable<CatalogModifierOverride>? modifierOverrides { get; set; }

        ///<summary>
        ///If `true`, enable this `CatalogModifierList`. The default value is `true`.
        ///</summary>
        [Description("If `true`, enable this `CatalogModifierList`. The default value is `true`.")]
        public bool? enabled { get; set; }

        ///<summary>
        ///The ID of the `CatalogModifierList` controlled by this `CatalogModifierListInfo`.
        ///</summary>
        [Description("The ID of the `CatalogModifierList` controlled by this `CatalogModifierListInfo`.")]
        public CatalogModifierList? modifierList { get; set; }

        ///<summary>
        ///If 0 or larger, the smallest number of `CatalogModifier`s that must be selected from this `CatalogModifierList`.
        ///</summary>
        [Description("If 0 or larger, the smallest number of `CatalogModifier`s that must be selected from this `CatalogModifierList`.")]
        public long? minSelectedModifiers { get; set; }

        ///<summary>
        ///If 0 or larger, the largest number of `CatalogModifier`s that can be selected from this `CatalogModifierList`.
        ///</summary>
        [Description("If 0 or larger, the largest number of `CatalogModifier`s that can be selected from this `CatalogModifierList`.")]
        public long? maxSelectedModifiers { get; set; }
    }

    ///<summary>
    ///A group of variations for a `CatalogItem`.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("A group of variations for a `CatalogItem`.\nPermissions: ITEMS_READ")]
    public class CatalogItemOption : GraphQLObject<CatalogItemOption>, ICatalogObject
    {
        ///<summary>
        ///The item option's display name for the seller. Must be unique across
        ///all item options. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        [Description("The item option's display name for the seller. Must be unique across\nall item options. This is a searchable attribute for use in applicable query filters.")]
        public string? name { get; set; }

        ///<summary>
        ///The item option's display name for the customer. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        [Description("The item option's display name for the customer. This is a searchable attribute for use in applicable query filters.")]
        public string? displayName { get; set; }

        ///<summary>
        ///The item option's human-readable description. Displayed in the Square
        ///Point of Sale app for the seller and in the Online Store or on receipts for
        ///the buyer. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        [Description("The item option's human-readable description. Displayed in the Square\nPoint of Sale app for the seller and in the Online Store or on receipts for\nthe buyer. This is a searchable attribute for use in applicable query filters.")]
        public string? description { get; set; }

        ///<summary>
        ///If true, display colors for entries in `values` when present.
        ///</summary>
        [Description("If true, display colors for entries in `values` when present.")]
        public bool? showColors { get; set; }

        ///<summary>
        ///A list of CatalogObjects containing the
        ///`CatalogItemOptionValue`s for this item.
        ///</summary>
        [Description("A list of CatalogObjects containing the\n`CatalogItemOptionValue`s for this item.")]
        public IEnumerable<CatalogItemOptionValue>? values { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///An enumerated value that can link a
    ///`CatalogItemVariation` to an item option as one of
    ///its item option values.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("An enumerated value that can link a\n`CatalogItemVariation` to an item option as one of\nits item option values.\nPermissions: ITEMS_READ")]
    public class CatalogItemOptionValue : GraphQLObject<CatalogItemOptionValue>, ICatalogObject
    {
        ///<summary>
        ///Name of this item option value. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        [Description("Name of this item option value. This is a searchable attribute for use in applicable query filters.")]
        public string? name { get; set; }

        ///<summary>
        ///A human-readable description for the option value. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        [Description("A human-readable description for the option value. This is a searchable attribute for use in applicable query filters.")]
        public string? description { get; set; }

        ///<summary>
        ///The HTML-supported hex color for the item option (e.g., "#ff8d4e85").
        ///Only displayed if `show_colors` is enabled on the parent `ItemOption`. When
        ///left unset, `color` defaults to white ("#ffffff") when `show_colors` is
        ///enabled on the parent `ItemOption`.
        ///</summary>
        [Description("The HTML-supported hex color for the item option (e.g., \"#ff8d4e85\").\nOnly displayed if `show_colors` is enabled on the parent `ItemOption`. When\nleft unset, `color` defaults to white (\"#ffffff\") when `show_colors` is\nenabled on the parent `ItemOption`.")]
        public string? color { get; set; }

        ///<summary>
        ///Determines where this option value appears in a list of option values.
        ///</summary>
        [Description("Determines where this option value appears in a list of option values.")]
        public long? ordinal { get; set; }

        ///<summary>
        ///Unique ID of the associated item option.
        ///</summary>
        [Description("Unique ID of the associated item option.")]
        public CatalogItemOption? option { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///The type of a CatalogItem.Connect V2 only allows the creation of `REGULAR` or `APPOINTMENTS_SERVICE` items.
    ///</summary>
    [Description("The type of a CatalogItem.Connect V2 only allows the creation of `REGULAR` or `APPOINTMENTS_SERVICE` items.")]
    public enum CatalogItemProductType
    {
        ///<summary>
        ///An ordinary item.
        ///</summary>
        [Description("An ordinary item.")]
        REGULAR,
        ///<summary>
        ///A Square gift card.
        ///</summary>
        [Description("A Square gift card.")]
        GIFT_CARD,
        ///<summary>
        ///A service that can be booked using the Square Appointments app.
        ///</summary>
        [Description("A service that can be booked using the Square Appointments app.")]
        APPOINTMENTS_SERVICE,
    }

    public static class CatalogItemProductTypeStringValues
    {
        public const string REGULAR = @"REGULAR";
        public const string GIFT_CARD = @"GIFT_CARD";
        public const string APPOINTMENTS_SERVICE = @"APPOINTMENTS_SERVICE";
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
    [Description("An item variation, representing a product for sale, in the Catalog object model.Each item must have at least one\nitem variation and can have at most 250 item variations.\n\nAn item variation can be sellable, stockable, or both if it has a unit of measure for its count for the sold number of the variation, the stocked\nnumber of the variation, or both. For example, when a variation representing wine is stocked and sold by the bottle, the variation is both\nstockable and sellable. But when a variation of the wine is sold by the glass, the sold units cannot be used as a measure of the stocked units. This by-the-glass\nvariation is sellable, but not stockable. To accurately keep track of the wine's inventory count at any time, the sellable count must be\nconverted to stockable count. Typically, the seller defines this unit conversion. For example, 1 bottle equals 5 glasses. The Square API exposes\nthe `stockable_conversion` property on the variation to specify the conversion. Thus, when two glasses of the wine are sold, the sellable count\ndecreases by 2, and the stockable count automatically decreases by 0.4 bottle according to the conversion.\nPermissions: ITEMS_READ")]
    public class CatalogItemVariation : GraphQLObject<CatalogItemVariation>, ICatalogObject
    {
        ///<summary>
        ///The item variation's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        [Description("The item variation's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.")]
        public string? name { get; set; }

        ///<summary>
        ///The item variation's SKU, if any. This is a searchable attribute for use in applicable query filters.
        ///</summary>
        [Description("The item variation's SKU, if any. This is a searchable attribute for use in applicable query filters.")]
        public string? sku { get; set; }

        ///<summary>
        ///The universal product code (UPC) of the item variation, if any. This is a searchable attribute for use in applicable query filters.
        ///
        ///The value of this attribute should be a number of 12-14 digits long.  This restriction is enforced on the Square Seller Dashboard,
        ///Square Point of Sale or Retail Point of Sale apps, where this attribute shows in the GTIN field. If a non-compliant UPC value is assigned
        ///to this attribute using the API, the value is not editable on the Seller Dashboard, Square Point of Sale or Retail Point of Sale apps
        ///unless it is updated to fit the expected format.
        ///</summary>
        [Description("The universal product code (UPC) of the item variation, if any. This is a searchable attribute for use in applicable query filters.\n\nThe value of this attribute should be a number of 12-14 digits long.  This restriction is enforced on the Square Seller Dashboard,\nSquare Point of Sale or Retail Point of Sale apps, where this attribute shows in the GTIN field. If a non-compliant UPC value is assigned\nto this attribute using the API, the value is not editable on the Seller Dashboard, Square Point of Sale or Retail Point of Sale apps\nunless it is updated to fit the expected format.")]
        public string? upc { get; set; }

        ///<summary>
        ///Indicates whether the item variation's price is fixed or determined at the time
        ///of sale.
        ///</summary>
        [Description("Indicates whether the item variation's price is fixed or determined at the time\nof sale.")]
        public CatalogPricingType? pricingType { get; set; }

        ///<summary>
        ///The item variation's price, if fixed pricing is used.
        ///</summary>
        [Description("The item variation's price, if fixed pricing is used.")]
        public Money? priceMoney { get; set; }

        ///<summary>
        ///Per-location price and inventory overrides.
        ///</summary>
        [Description("Per-location price and inventory overrides.")]
        public IEnumerable<CatalogItemVariationLocationOverride>? locationOverrides { get; set; }

        ///<summary>
        ///If `true`, inventory tracking is active for the variation.
        ///</summary>
        [Description("If `true`, inventory tracking is active for the variation.")]
        public bool? trackInventory { get; set; }

        ///<summary>
        ///Arbitrary user metadata to associate with the item variation. This attribute value length is of Unicode code points.
        ///</summary>
        [Description("Arbitrary user metadata to associate with the item variation. This attribute value length is of Unicode code points.")]
        public string? userData { get; set; }

        ///<summary>
        ///If the `CatalogItem` that owns this item variation is of type
        ///`APPOINTMENTS_SERVICE`, then this is the duration of the service in milliseconds. For
        ///example, a 30 minute appointment would have the value `1800000`, which is equal to
        ///30 (minutes) * 60 (seconds per minute) * 1000 (milliseconds per second).
        ///</summary>
        [Description("If the `CatalogItem` that owns this item variation is of type\n`APPOINTMENTS_SERVICE`, then this is the duration of the service in milliseconds. For\nexample, a 30 minute appointment would have the value `1800000`, which is equal to\n30 (minutes) * 60 (seconds per minute) * 1000 (milliseconds per second).")]
        public int? serviceDuration { get; set; }

        ///<summary>
        ///If the `CatalogItem` that owns this item variation is of type
        ///`APPOINTMENTS_SERVICE`, a bool representing whether this service is available for booking.
        ///</summary>
        [Description("If the `CatalogItem` that owns this item variation is of type\n`APPOINTMENTS_SERVICE`, a bool representing whether this service is available for booking.")]
        public bool? availableForBooking { get; set; }

        ///<summary>
        ///Whether this variation can be sold. The inventory count of a sellable variation indicates
        ///the number of units available for sale. When a variation is both stockable and sellable,
        ///its sellable inventory count can be smaller than or equal to its stockable count.
        ///</summary>
        [Description("Whether this variation can be sold. The inventory count of a sellable variation indicates\nthe number of units available for sale. When a variation is both stockable and sellable,\nits sellable inventory count can be smaller than or equal to its stockable count.")]
        public bool? sellable { get; set; }

        ///<summary>
        ///Whether stock is counted directly on this variation (TRUE) or only on its components (FALSE).
        ///When a variation is both stockable and sellable, the inventory count of a stockable variation keeps track of the number of units of this variation in stock
        ///and is not an indicator of the number of units of the variation that can be sold.
        ///</summary>
        [Description("Whether stock is counted directly on this variation (TRUE) or only on its components (FALSE).\nWhen a variation is both stockable and sellable, the inventory count of a stockable variation keeps track of the number of units of this variation in stock\nand is not an indicator of the number of units of the variation that can be sold.")]
        public bool? stockable { get; set; }

        ///<summary>
        ///Tokens of employees that can perform the service represented by this variation. Only valid for
        ///variations of type `APPOINTMENTS_SERVICE`.
        ///</summary>
        [Description("Tokens of employees that can perform the service represented by this variation. Only valid for\nvariations of type `APPOINTMENTS_SERVICE`.")]
        public IEnumerable<string>? teamMemberIds { get; set; }

        ///<summary>
        ///The unit conversion rule, as prescribed by the CatalogStockConversion type,
        ///that describes how this non-stockable (i.e., sellable/receivable) item variation is converted
        ///to/from the stockable item variation sharing the same parent item. With the stock conversion,
        ///you can accurately track inventory when an item variation is sold in one unit, but stocked in
        ///another unit.
        ///</summary>
        [Description("The unit conversion rule, as prescribed by the CatalogStockConversion type,\nthat describes how this non-stockable (i.e., sellable/receivable) item variation is converted\nto/from the stockable item variation sharing the same parent item. With the stock conversion,\nyou can accurately track inventory when an item variation is sold in one unit, but stocked in\nanother unit.")]
        public CatalogStockConversion? stockableConversion { get; set; }

        ///<summary>
        ///The order in which this item variation should be displayed. This value is read-only. On writes, the ordinal
        ///for each item variation within a parent `CatalogItem` is set according to the item variations's
        ///position. On reads, the value is not guaranteed to be sequential or unique.
        ///</summary>
        [Description("The order in which this item variation should be displayed. This value is read-only. On writes, the ordinal\nfor each item variation within a parent `CatalogItem` is set according to the item variations's\nposition. On reads, the value is not guaranteed to be sequential or unique.")]
        public long? ordinal { get; set; }

        ///<summary>
        ///The ID of the `CatalogItem` associated with this item variation.
        ///</summary>
        [Description("The ID of the `CatalogItem` associated with this item variation.")]
        public CatalogItem? item { get; set; }

        ///<summary>
        ///ID of the ‘CatalogMeasurementUnit’ that is used to measure the quantity
        ///sold of this item variation. If left unset, the item will be sold in
        ///whole quantities.
        ///</summary>
        [Description("ID of the ‘CatalogMeasurementUnit’ that is used to measure the quantity\nsold of this item variation. If left unset, the item will be sold in\nwhole quantities.")]
        public CatalogMeasurementUnit? unit { get; set; }

        ///<summary>
        ///The IDs of images associated with this `CatalogItemVariation` instance.
        ///These images will be shown to customers in Square Online Store.
        ///</summary>
        [Description("The IDs of images associated with this `CatalogItemVariation` instance.\nThese images will be shown to customers in Square Online Store.")]
        public IEnumerable<CatalogImage>? images { get; set; }

        ///<summary>
        ///List of item option values associated with this item variation. Listed
        ///in the same order as the item options of the parent item.
        ///</summary>
        [Description("List of item option values associated with this item variation. Listed\nin the same order as the item options of the parent item.")]
        public IEnumerable<CatalogItemOptionValue>? optionValues { get; set; }

        ///<summary>
        ///Indicates whether the item variation displays an alert when its inventory quantity is less than or equal
        ///to its `inventory_alert_threshold`.
        ///</summary>
        [Description("Indicates whether the item variation displays an alert when its inventory quantity is less than or equal\nto its `inventory_alert_threshold`.")]
        public InventoryAlert? inventoryAlert { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a "#" character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///When the server receives the new object, it will supply a unique identifier that replaces the temporary identifier for all future references.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a \"#\" character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.\nWhen the server receives the new object, it will supply a unique identifier that replaces the temporary identifier for all future references.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Price and inventory alerting overrides for a `CatalogItemVariation` at a specific `Location`.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Price and inventory alerting overrides for a `CatalogItemVariation` at a specific `Location`.\nPermissions: ITEMS_READ")]
    public class CatalogItemVariationLocationOverride : GraphQLObject<CatalogItemVariationLocationOverride>
    {
        ///<summary>
        ///The price of the `CatalogItemVariation` at the given `Location`, or blank for variable pricing.
        ///</summary>
        [Description("The price of the `CatalogItemVariation` at the given `Location`, or blank for variable pricing.")]
        public Money? priceMoney { get; set; }

        ///<summary>
        ///The pricing type (fixed or variable) for the `CatalogItemVariation` at the given `Location`.
        ///</summary>
        [Description("The pricing type (fixed or variable) for the `CatalogItemVariation` at the given `Location`.")]
        public CatalogPricingType? pricingType { get; set; }

        ///<summary>
        ///If `true`, inventory tracking is active for the `CatalogItemVariation` at this `Location`.
        ///</summary>
        [Description("If `true`, inventory tracking is active for the `CatalogItemVariation` at this `Location`.")]
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
        [Description("Indicates whether the overridden item variation is sold out at the specified location.\n\nWhen inventory tracking is enabled on the item variation either globally or at the specified location,\nthe item variation is automatically marked as sold out when its inventory count reaches zero. The seller\ncan manually set the item variation as sold out even when the inventory count is greater than zero.\nAttempts by an application to set this attribute are ignored. Regardless how the sold-out status is set,\napplications should treat its inventory count as zero when this attribute value is `true`.")]
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
        [Description("The seller-assigned timestamp, of the RFC 3339 format, to indicate when this sold-out variation\nbecomes available again at the specified location. Attempts by an application to set this attribute are ignored.\nWhen the current time is later than this attribute value, the affected item variation is no longer sold out.\n\nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n\nUTC:  2020-01-26T02:25:34Z\n\nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public string? soldOutValidUntil { get; set; }

        ///<summary>
        ///Indicates whether the `CatalogItemVariation` displays an alert when its inventory
        ///quantity is less than or equal to its `inventory_alert_threshold`.
        ///</summary>
        [Description("Indicates whether the `CatalogItemVariation` displays an alert when its inventory\nquantity is less than or equal to its `inventory_alert_threshold`.")]
        public InventoryAlert? inventoryAlert { get; set; }

        ///<summary>
        ///The ID of the `Location`. This can include locations that are deactivated.
        ///</summary>
        [Description("The ID of the `Location`. This can include locations that are deactivated.")]
        public Location? location { get; set; }
    }

    ///<summary>
    ///Represents the unit used to measure a `CatalogItemVariation` and
    ///specifies the precision for decimal quantities.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Represents the unit used to measure a `CatalogItemVariation` and\nspecifies the precision for decimal quantities.\nPermissions: ITEMS_READ")]
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
        [Description("An integer between 0 and 5 that represents the maximum number of\npositions allowed after the decimal in quantities measured with this unit.\nFor example:\n\n- if the precision is 0, the quantity can be 1, 2, 3, etc.\n- if the precision is 1, the quantity can be 0.1, 0.2, etc.\n- if the precision is 2, the quantity can be 0.01, 0.12, etc.\n\nDefault: 3")]
        public int? precision { get; set; }

        ///<summary>
        ///Indicates the unit used to measure the quantity of a catalog item variation.
        ///</summary>
        [Description("Indicates the unit used to measure the quantity of a catalog item variation.")]
        public IMeasurementUnit? unit { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///A modifier applicable to items at the time of sale.An example of a modifier is a Cheese add-on to a Burger item.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("A modifier applicable to items at the time of sale.An example of a modifier is a Cheese add-on to a Burger item.\nPermissions: ITEMS_READ")]
    public class CatalogModifier : GraphQLObject<CatalogModifier>, ICatalogObject
    {
        ///<summary>
        ///The modifier name.  This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        [Description("The modifier name.  This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.")]
        public string? name { get; set; }

        ///<summary>
        ///The modifier price.
        ///</summary>
        [Description("The modifier price.")]
        public Money? priceMoney { get; set; }

        ///<summary>
        ///Location-specific price overrides.
        ///</summary>
        [Description("Location-specific price overrides.")]
        public IEnumerable<ModifierLocationOverride>? locationOverrides { get; set; }

        ///<summary>
        ///Determines where this `CatalogModifier` appears in the `CatalogModifierList`.
        ///</summary>
        [Description("Determines where this `CatalogModifier` appears in the `CatalogModifierList`.")]
        public long? ordinal { get; set; }

        ///<summary>
        ///The ID of the image associated with this `CatalogModifier` instance.
        ///Currently this image is not displayed by Square, but is free to be displayed in 3rd party applications.
        ///</summary>
        [Description("The ID of the image associated with this `CatalogModifier` instance.\nCurrently this image is not displayed by Square, but is free to be displayed in 3rd party applications.")]
        public CatalogImage? image { get; set; }

        ///<summary>
        ///The ID of the `CatalogModifierList` associated with this modifier.
        ///</summary>
        [Description("The ID of the `CatalogModifierList` associated with this modifier.")]
        public CatalogModifierList? modifierList { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///A list of modifiers applicable to items at the time of sale.For example, a "Condiments" modifier list applicable to a "Hot Dog" item
    ///may contain "Ketchup", "Mustard", and "Relish" modifiers.
    ///Use the `selection_type` field to specify whether or not multiple selections from
    ///the modifier list are allowed.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("A list of modifiers applicable to items at the time of sale.For example, a \"Condiments\" modifier list applicable to a \"Hot Dog\" item\nmay contain \"Ketchup\", \"Mustard\", and \"Relish\" modifiers.\nUse the `selection_type` field to specify whether or not multiple selections from\nthe modifier list are allowed.\nPermissions: ITEMS_READ")]
    public class CatalogModifierList : GraphQLObject<CatalogModifierList>, ICatalogObject
    {
        ///<summary>
        ///The name for the `CatalogModifierList` instance. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        [Description("The name for the `CatalogModifierList` instance. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.")]
        public string? name { get; set; }

        ///<summary>
        ///Indicates whether multiple options from the modifier list
        ///can be applied to a single `CatalogItem`.
        ///</summary>
        [Description("Indicates whether multiple options from the modifier list\ncan be applied to a single `CatalogItem`.")]
        public CatalogModifierListSelectionType? selectionType { get; set; }

        ///<summary>
        ///Determines where this modifier list appears in a list of `CatalogModifierList` values.
        ///</summary>
        [Description("Determines where this modifier list appears in a list of `CatalogModifierList` values.")]
        public long? ordinal { get; set; }

        ///<summary>
        ///The options included in the `CatalogModifierList`.
        ///You must include at least one `CatalogModifier`.
        ///Each CatalogObject must have type `MODIFIER` and contain
        ///`CatalogModifier` data.
        ///</summary>
        [Description("The options included in the `CatalogModifierList`.\nYou must include at least one `CatalogModifier`.\nEach CatalogObject must have type `MODIFIER` and contain\n`CatalogModifier` data.")]
        public IEnumerable<CatalogModifier>? modifiers { get; set; }

        ///<summary>
        ///The IDs of images associated with this `CatalogModifierList` instance.
        ///Currently these images are not displayed by Square, but are free to be displayed in 3rd party applications.
        ///</summary>
        [Description("The IDs of images associated with this `CatalogModifierList` instance.\nCurrently these images are not displayed by Square, but are free to be displayed in 3rd party applications.")]
        public IEnumerable<CatalogImage>? images { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Indicates whether a CatalogModifierList supports multiple selections.
    ///</summary>
    [Description("Indicates whether a CatalogModifierList supports multiple selections.")]
    public enum CatalogModifierListSelectionType
    {
        ///<summary>
        ///Indicates that a CatalogModifierList allows only a
        ///single CatalogModifier to be selected.
        ///</summary>
        [Description("Indicates that a CatalogModifierList allows only a\nsingle CatalogModifier to be selected.")]
        SINGLE,
        ///<summary>
        ///Indicates that a CatalogModifierList allows multiple
        ///CatalogModifier to be selected.
        ///</summary>
        [Description("Indicates that a CatalogModifierList allows multiple\nCatalogModifier to be selected.")]
        MULTIPLE,
    }

    public static class CatalogModifierListSelectionTypeStringValues
    {
        public const string SINGLE = @"SINGLE";
        public const string MULTIPLE = @"MULTIPLE";
    }

    ///<summary>
    ///Options to control how to override the default behavior of the specified modifier.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Options to control how to override the default behavior of the specified modifier.\nPermissions: ITEMS_READ")]
    public class CatalogModifierOverride : GraphQLObject<CatalogModifierOverride>
    {
        ///<summary>
        ///If `true`, this `CatalogModifier` should be selected by default for this `CatalogItem`.
        ///</summary>
        [Description("If `true`, this `CatalogModifier` should be selected by default for this `CatalogItem`.")]
        public bool? onByDefault { get; set; }

        ///<summary>
        ///The ID of the `CatalogModifier` whose default behavior is being overridden.
        ///</summary>
        [Description("The ID of the `CatalogModifier` whose default behavior is being overridden.")]
        public CatalogModifier? modifier { get; set; }
    }

    ///<summary>
    ///The wrapper object for the catalog entries of a given object type.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("The wrapper object for the catalog entries of a given object type.\n\nPermissions:ITEMS_READ")]
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
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; }
    }

    ///<summary>
    ///Contains information of a query result.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("Contains information of a query result.\n\nPermissions:ITEMS_READ")]
    public class CatalogObjectConnection : GraphQLObject<CatalogObjectConnection>, IConnectionWithNodes<ICatalogObject>
    {
        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }

        ///<summary>
        ///List of CatalogObjects
        ///</summary>
        [Description("List of CatalogObjects")]
        [NonNull]
        public IEnumerable<ICatalogObject>? nodes { get; set; }
    }

    ///<summary>
    ///Possible types of CatalogObjects returned from the catalog, each
    ///containing type-specific properties in the `*_data` field corresponding to the specified object type.
    ///</summary>
    [Description("Possible types of CatalogObjects returned from the catalog, each\ncontaining type-specific properties in the `*_data` field corresponding to the specified object type.")]
    public enum CatalogObjectType
    {
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogItem](entity:CatalogItem) type and represents an item. The item-specific data
        ///must be set on the `item_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogItem](entity:CatalogItem) type and represents an item. The item-specific data\nmust be set on the `item_data` field.")]
        ITEM,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogImage](entity:CatalogImage) type and represents an image. The image-specific data
        ///must be set on the `image_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogImage](entity:CatalogImage) type and represents an image. The image-specific data\nmust be set on the `image_data` field.")]
        IMAGE,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogCategory](entity:CatalogCategory) type and represents a category. The category-specific data
        ///must be set on the `category_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogCategory](entity:CatalogCategory) type and represents a category. The category-specific data\nmust be set on the `category_data` field.")]
        CATEGORY,
        ///<summary>
        ///The `CatalogObject` instance is of the  [CatalogItemVariation](entity:CatalogItemVariation) type and represents an item variation, also referred to as variation.
        ///The item variation-specific data must be set on the `item_variation_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the  [CatalogItemVariation](entity:CatalogItemVariation) type and represents an item variation, also referred to as variation.\nThe item variation-specific data must be set on the `item_variation_data` field.")]
        ITEM_VARIATION,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogTax](entity:CatalogTax) type and represents a tax. The tax-specific data
        ///must be set on the `tax_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogTax](entity:CatalogTax) type and represents a tax. The tax-specific data\nmust be set on the `tax_data` field.")]
        TAX,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogDiscount](entity:CatalogDiscount) type and represents a discount. The discount-specific data
        ///must be set on the `discount_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogDiscount](entity:CatalogDiscount) type and represents a discount. The discount-specific data\nmust be set on the `discount_data` field.")]
        DISCOUNT,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogModifierList](entity:CatalogModifierList) type and represents a modifier list.
        ///The modifier-list-specific data must be set on the `modifier_list_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogModifierList](entity:CatalogModifierList) type and represents a modifier list.\nThe modifier-list-specific data must be set on the `modifier_list_data` field.")]
        MODIFIER_LIST,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogModifier](entity:CatalogModifier) type and represents a modifier. The modifier-specific data
        ///must be set on the `modifier_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogModifier](entity:CatalogModifier) type and represents a modifier. The modifier-specific data\nmust be set on the `modifier_data` field.")]
        MODIFIER,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogPricingRule](entity:CatalogPricingRule) type and represents a pricing rule. The pricing-rule-specific data
        ///must be set on the `pricing_rule_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogPricingRule](entity:CatalogPricingRule) type and represents a pricing rule. The pricing-rule-specific data\nmust be set on the `pricing_rule_data` field.")]
        PRICING_RULE,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogProductSet](entity:CatalogProductSet) type and represents a product set.
        ///The product-set-specific data will be stored in the `product_set_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogProductSet](entity:CatalogProductSet) type and represents a product set.\nThe product-set-specific data will be stored in the `product_set_data` field.")]
        PRODUCT_SET,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogTimePeriod](entity:CatalogTimePeriod) type and represents a time period.
        ///The time-period-specific data must be set on the `time_period_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogTimePeriod](entity:CatalogTimePeriod) type and represents a time period.\nThe time-period-specific data must be set on the `time_period_data` field.")]
        TIME_PERIOD,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogMeasurementUnit](entity:CatalogMeasurementUnit) type and represents a measurement unit specifying the unit of
        ///measure and precision in which an item variation is sold. The measurement-unit-specific data must set on the `measurement_unit_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogMeasurementUnit](entity:CatalogMeasurementUnit) type and represents a measurement unit specifying the unit of\nmeasure and precision in which an item variation is sold. The measurement-unit-specific data must set on the `measurement_unit_data` field.")]
        MEASUREMENT_UNIT,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogSubscriptionPlan](entity:CatalogSubscriptionPlan) type and represents a subscription plan.
        ///The subscription-plan-specific data must be stored on the `subscription_plan_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogSubscriptionPlan](entity:CatalogSubscriptionPlan) type and represents a subscription plan.\nThe subscription-plan-specific data must be stored on the `subscription_plan_data` field.")]
        SUBSCRIPTION_PLAN_VARIATION,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogItemOption](entity:CatalogItemOption) type and represents a list of options (such as a color or size of a T-shirt)
        ///that can be assigned to item variations. The item-option-specific data must be on the `item_option_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogItemOption](entity:CatalogItemOption) type and represents a list of options (such as a color or size of a T-shirt)\nthat can be assigned to item variations. The item-option-specific data must be on the `item_option_data` field.")]
        ITEM_OPTION,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogItemOptionValue](entity:CatalogItemOptionValue) type and represents a value associated with one or more item options.
        ///For example, an item option of "Size" may have item option values such as "Small" or "Medium".
        ///The item-option-value-specific data must be on the `item_option_value_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogItemOptionValue](entity:CatalogItemOptionValue) type and represents a value associated with one or more item options.\nFor example, an item option of \"Size\" may have item option values such as \"Small\" or \"Medium\".\nThe item-option-value-specific data must be on the `item_option_value_data` field.")]
        ITEM_OPTION_VAL,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogCustomAttributeDefinition](entity:CatalogCustomAttributeDefinition) type and represents the definition of a custom attribute.
        ///The custom-attribute-definition-specific data must be set on the `custom_attribute_definition_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogCustomAttributeDefinition](entity:CatalogCustomAttributeDefinition) type and represents the definition of a custom attribute.\nThe custom-attribute-definition-specific data must be set on the `custom_attribute_definition_data` field.")]
        CUSTOM_ATTRIBUTE_DEFINITION,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogQuickAmountsSettings](entity:CatalogQuickAmountsSettings) type and represents settings to configure preset charges for quick payments at each location.
        ///For example, a location may have a list of both AUTO and MANUAL quick amounts that are set to DISABLED.
        ///The quick-amounts-settings-specific data must be set on the `quick_amounts_settings_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogQuickAmountsSettings](entity:CatalogQuickAmountsSettings) type and represents settings to configure preset charges for quick payments at each location.\nFor example, a location may have a list of both AUTO and MANUAL quick amounts that are set to DISABLED.\nThe quick-amounts-settings-specific data must be set on the `quick_amounts_settings_data` field.")]
        QUICK_AMOUNTS_SETTINGS,
        ///<summary>
        ///The `CatalogObject` instance is of the [CatalogSubscriptionPlan](entity:CatalogSubscriptionPlan) type and represents a subscription plan.
        ///The subscription plan specific data must be stored on the `subscription_plan_data` field.
        ///</summary>
        [Description("The `CatalogObject` instance is of the [CatalogSubscriptionPlan](entity:CatalogSubscriptionPlan) type and represents a subscription plan.\nThe subscription plan specific data must be stored on the `subscription_plan_data` field.")]
        SUBSCRIPTION_PLAN,
    }

    public static class CatalogObjectTypeStringValues
    {
        public const string ITEM = @"ITEM";
        public const string IMAGE = @"IMAGE";
        public const string CATEGORY = @"CATEGORY";
        public const string ITEM_VARIATION = @"ITEM_VARIATION";
        public const string TAX = @"TAX";
        public const string DISCOUNT = @"DISCOUNT";
        public const string MODIFIER_LIST = @"MODIFIER_LIST";
        public const string MODIFIER = @"MODIFIER";
        public const string PRICING_RULE = @"PRICING_RULE";
        public const string PRODUCT_SET = @"PRODUCT_SET";
        public const string TIME_PERIOD = @"TIME_PERIOD";
        public const string MEASUREMENT_UNIT = @"MEASUREMENT_UNIT";
        public const string SUBSCRIPTION_PLAN_VARIATION = @"SUBSCRIPTION_PLAN_VARIATION";
        public const string ITEM_OPTION = @"ITEM_OPTION";
        public const string ITEM_OPTION_VAL = @"ITEM_OPTION_VAL";
        public const string CUSTOM_ATTRIBUTE_DEFINITION = @"CUSTOM_ATTRIBUTE_DEFINITION";
        public const string QUICK_AMOUNTS_SETTINGS = @"QUICK_AMOUNTS_SETTINGS";
        public const string SUBSCRIPTION_PLAN = @"SUBSCRIPTION_PLAN";
    }

    ///<summary>
    ///Defines how discounts are automatically applied to a set of items that match the pricing rule
    ///during the active time period.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Defines how discounts are automatically applied to a set of items that match the pricing rule\nduring the active time period.\nPermissions: ITEMS_READ")]
    public class CatalogPricingRule : GraphQLObject<CatalogPricingRule>, ICatalogObject
    {
        ///<summary>
        ///User-defined name for the pricing rule. For example, "Buy one get one
        ///free" or "10% off".
        ///</summary>
        [Description("User-defined name for the pricing rule. For example, \"Buy one get one\nfree\" or \"10% off\".")]
        public string? name { get; set; }

        ///<summary>
        ///Represents the date the Pricing Rule is valid from. Represented in RFC 3339 full-date format (YYYY-MM-DD).
        ///</summary>
        [Description("Represents the date the Pricing Rule is valid from. Represented in RFC 3339 full-date format (YYYY-MM-DD).")]
        public string? validFromDate { get; set; }

        ///<summary>
        ///Represents the local time the pricing rule should be valid from. Represented in RFC 3339 partial-time format
        ///(HH:MM:SS). Partial seconds will be truncated.
        ///</summary>
        [Description("Represents the local time the pricing rule should be valid from. Represented in RFC 3339 partial-time format\n(HH:MM:SS). Partial seconds will be truncated.")]
        public string? validFromLocalTime { get; set; }

        ///<summary>
        ///Represents the date the Pricing Rule is valid until. Represented in RFC 3339 full-date format (YYYY-MM-DD).
        ///</summary>
        [Description("Represents the date the Pricing Rule is valid until. Represented in RFC 3339 full-date format (YYYY-MM-DD).")]
        public string? validUntilDate { get; set; }

        ///<summary>
        ///Represents the local time the pricing rule should be valid until. Represented in RFC 3339 partial-time format
        ///(HH:MM:SS). Partial seconds will be truncated.
        ///</summary>
        [Description("Represents the local time the pricing rule should be valid until. Represented in RFC 3339 partial-time format\n(HH:MM:SS). Partial seconds will be truncated.")]
        public string? validUntilLocalTime { get; set; }

        ///<summary>
        ///If an `exclude_products_id` was given, controls which subset of matched
        ///products is excluded from any discounts.
        ///
        ///Default value: `LEAST_EXPENSIVE`
        ///</summary>
        [Description("If an `exclude_products_id` was given, controls which subset of matched\nproducts is excluded from any discounts.\n\nDefault value: `LEAST_EXPENSIVE`")]
        public ExcludeStrategy? excludeStrategy { get; set; }

        ///<summary>
        ///The minimum order subtotal (before discounts or taxes are applied)
        ///that must be met before this rule may be applied.
        ///</summary>
        [Description("The minimum order subtotal (before discounts or taxes are applied)\nthat must be met before this rule may be applied.")]
        public Money? minimumOrderSubtotalMoney { get; set; }

        ///<summary>
        ///Unique ID for the `CatalogDiscount` to take off
        ///the price of all matched items.
        ///</summary>
        [Description("Unique ID for the `CatalogDiscount` to take off\nthe price of all matched items.")]
        public CatalogDiscount? discount { get; set; }

        ///<summary>
        ///Unique ID for the `CatalogProductSet` that will be matched by this rule. A match rule
        ///matches within the entire cart, and can match multiple times. This field will always be set.
        ///</summary>
        [Description("Unique ID for the `CatalogProductSet` that will be matched by this rule. A match rule\nmatches within the entire cart, and can match multiple times. This field will always be set.")]
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
        [Description("__Deprecated__: Please use the `exclude_products_id` field to apply\nan exclude set instead. Exclude sets allow better control over quantity\nranges and offer more flexibility for which matched items receive a discount.\n\n`CatalogProductSet` to apply the pricing to.\nAn apply rule matches within the subset of the cart that fits the match rules (the match set).\nAn apply rule can only match once in the match set.\nIf not supplied, the pricing will be applied to all products in the match set.\nOther products retain their base price, or a price generated by other rules.")]
        public CatalogProductSet? applyProducts { get; set; }

        ///<summary>
        ///`CatalogProductSet` to exclude from the pricing rule.
        ///An exclude rule matches within the subset of the cart that fits the match rules (the match set).
        ///An exclude rule can only match once in the match set.
        ///If not supplied, the pricing will be applied to all products in the match set.
        ///Other products retain their base price, or a price generated by other rules.
        ///</summary>
        [Description("`CatalogProductSet` to exclude from the pricing rule.\nAn exclude rule matches within the subset of the cart that fits the match rules (the match set).\nAn exclude rule can only match once in the match set.\nIf not supplied, the pricing will be applied to all products in the match set.\nOther products retain their base price, or a price generated by other rules.")]
        public CatalogProductSet? excludeProducts { get; set; }

        ///<summary>
        ///A list of unique IDs for the catalog time periods when
        ///this pricing rule is in effect. If left unset, the pricing rule is always
        ///in effect.
        ///</summary>
        [Description("A list of unique IDs for the catalog time periods when\nthis pricing rule is in effect. If left unset, the pricing rule is always\nin effect.")]
        public IEnumerable<CatalogTimePeriod>? timePeriods { get; set; }

        ///<summary>
        ///A list of IDs of customer groups, the members of which are eligible for discounts specified in this pricing rule.
        ///Notice that a group ID is generated by the Customers API.
        ///If this field is not set, the specified discount applies to matched products sold to anyone whether the buyer
        ///has a customer profile created or not. If this `customer_group_ids_any` field is set, the specified discount
        ///applies only to matched products sold to customers belonging to the specified customer groups.
        ///</summary>
        [Description("A list of IDs of customer groups, the members of which are eligible for discounts specified in this pricing rule.\nNotice that a group ID is generated by the Customers API.\nIf this field is not set, the specified discount applies to matched products sold to anyone whether the buyer\nhas a customer profile created or not. If this `customer_group_ids_any` field is set, the specified discount\napplies only to matched products sold to customers belonging to the specified customer groups.")]
        public IEnumerable<string>? customerGroupIds { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Indicates whether the price of a CatalogItemVariation should be entered manually at the time of sale.
    ///</summary>
    [Description("Indicates whether the price of a CatalogItemVariation should be entered manually at the time of sale.")]
    public enum CatalogPricingType
    {
        ///<summary>
        ///The catalog item variation's price is fixed.
        ///</summary>
        [Description("The catalog item variation's price is fixed.")]
        FIXED_PRICING,
        ///<summary>
        ///The catalog item variation's price is entered at the time of sale.
        ///</summary>
        [Description("The catalog item variation's price is entered at the time of sale.")]
        VARIABLE_PRICING,
    }

    public static class CatalogPricingTypeStringValues
    {
        public const string FIXED_PRICING = @"FIXED_PRICING";
        public const string VARIABLE_PRICING = @"VARIABLE_PRICING";
    }

    ///<summary>
    ///Represents a collection of catalog objects for the purpose of applying a
    ///`PricingRule`.Including a catalog object will include all of its subtypes.
    ///For example, including a category in a product set will include all of its
    ///items and associated item variations in the product set. Including an item in
    ///a product set will also include its item variations.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Represents a collection of catalog objects for the purpose of applying a\n`PricingRule`.Including a catalog object will include all of its subtypes.\nFor example, including a category in a product set will include all of its\nitems and associated item variations in the product set. Including an item in\na product set will also include its item variations.\nPermissions: ITEMS_READ")]
    public class CatalogProductSet : GraphQLObject<CatalogProductSet>, ICatalogObject
    {
        ///<summary>
        ///User-defined name for the product set. For example, "Clearance Items"
        ///or "Winter Sale Items".
        ///</summary>
        [Description("User-defined name for the product set. For example, \"Clearance Items\"\nor \"Winter Sale Items\".")]
        public string? name { get; set; }

        ///<summary>
        ///If set, there must be exactly this many items from `products_any` or `products_all`
        ///in the cart for the discount to apply.
        ///
        ///Cannot be combined with either `quantity_min` or `quantity_max`.
        ///</summary>
        [Description("If set, there must be exactly this many items from `products_any` or `products_all`\nin the cart for the discount to apply.\n\nCannot be combined with either `quantity_min` or `quantity_max`.")]
        public int? quantityExact { get; set; }

        ///<summary>
        ///If set, there must be at least this many items from `products_any` or `products_all`
        ///in a cart for the discount to apply. See `quantity_exact`. Defaults to 0 if
        ///`quantity_exact`, `quantity_min` and `quantity_max` are all unspecified.
        ///</summary>
        [Description("If set, there must be at least this many items from `products_any` or `products_all`\nin a cart for the discount to apply. See `quantity_exact`. Defaults to 0 if\n`quantity_exact`, `quantity_min` and `quantity_max` are all unspecified.")]
        public int? quantityMin { get; set; }

        ///<summary>
        ///If set, the pricing rule will apply to a maximum of this many items from
        ///`products_any` or `products_all`.
        ///</summary>
        [Description("If set, the pricing rule will apply to a maximum of this many items from\n`products_any` or `products_all`.")]
        public int? quantityMax { get; set; }

        ///<summary>
        ///If set to `true`, the product set will include every item in the catalog.
        ///Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        ///</summary>
        [Description("If set to `true`, the product set will include every item in the catalog.\nOnly one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.")]
        public bool? allProducts { get; set; }

        ///<summary>
        ///Unique IDs for any `CatalogObject` included in this product set.
        ///All objects in this set must be included in an order for a pricing rule to apply.
        ///
        ///Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        ///
        ///Max: 500 catalog object IDs.
        ///</summary>
        [Description("Unique IDs for any `CatalogObject` included in this product set.\nAll objects in this set must be included in an order for a pricing rule to apply.\n\nOnly one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.\n\nMax: 500 catalog object IDs.")]
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
        [Description(" Unique IDs for any `CatalogObject` included in this product set. Any\nnumber of these catalog objects can be in an order for a pricing rule to apply.\n\nThis can be used with `product_ids_all` in a parent `CatalogProductSet` to\nmatch groups of products for a bulk discount, such as a discount for an\nentree and side combo.\n\nOnly one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.\n\nMax: 500 catalog object IDs.")]
        public IEnumerable<ICatalogObject>? anySetProducts { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Represents a Quick Amount in the Catalog.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Represents a Quick Amount in the Catalog.\nPermissions: ITEMS_READ")]
    public class CatalogQuickAmount : GraphQLObject<CatalogQuickAmount>
    {
        ///<summary>
        ///Represents the type of the Quick Amount.
        ///</summary>
        [Description("Represents the type of the Quick Amount.")]
        public CatalogQuickAmountType? type { get; set; }

        ///<summary>
        ///Represents the actual amount of the Quick Amount with Money type.
        ///</summary>
        [Description("Represents the actual amount of the Quick Amount with Money type.")]
        public Money? amount { get; set; }

        ///<summary>
        ///Describes the ranking of the Quick Amount provided by machine learning model, in the range [0, 100].
        ///MANUAL type amount will always have score = 100.
        ///</summary>
        [Description("Describes the ranking of the Quick Amount provided by machine learning model, in the range [0, 100].\nMANUAL type amount will always have score = 100.")]
        public int? score { get; set; }

        ///<summary>
        ///The order in which this Quick Amount should be displayed.
        ///</summary>
        [Description("The order in which this Quick Amount should be displayed.")]
        public long? ordinal { get; set; }
    }

    ///<summary>
    ///A parent Catalog Object model represents a set of Quick Amounts and the settings control the amounts.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("A parent Catalog Object model represents a set of Quick Amounts and the settings control the amounts.\nPermissions: ITEMS_READ")]
    public class CatalogQuickAmountsSettings : GraphQLObject<CatalogQuickAmountsSettings>, ICatalogObject
    {
        ///<summary>
        ///Represents the option seller currently uses on Quick Amounts.
        ///</summary>
        [Description("Represents the option seller currently uses on Quick Amounts.")]
        public CatalogQuickAmountsSettingsOption? option { get; set; }

        ///<summary>
        ///Represents location's eligibility for auto amounts
        ///The boolean should be consistent with whether there are AUTO amounts in the `amounts`.
        ///</summary>
        [Description("Represents location's eligibility for auto amounts\nThe boolean should be consistent with whether there are AUTO amounts in the `amounts`.")]
        public bool? eligibleForAutoAmounts { get; set; }

        ///<summary>
        ///Represents a set of Quick Amounts at this location.
        ///</summary>
        [Description("Represents a set of Quick Amounts at this location.")]
        public IEnumerable<CatalogQuickAmount>? amounts { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Determines a seller's option on Quick Amounts feature.
    ///</summary>
    [Description("Determines a seller's option on Quick Amounts feature.")]
    public enum CatalogQuickAmountsSettingsOption
    {
        ///<summary>
        ///Option for seller to disable Quick Amounts.
        ///</summary>
        [Description("Option for seller to disable Quick Amounts.")]
        DISABLED,
        ///<summary>
        ///Option for seller to choose manually created Quick Amounts.
        ///</summary>
        [Description("Option for seller to choose manually created Quick Amounts.")]
        MANUAL,
        ///<summary>
        ///Option for seller to choose automatically created Quick Amounts.
        ///</summary>
        [Description("Option for seller to choose automatically created Quick Amounts.")]
        AUTO,
    }

    public static class CatalogQuickAmountsSettingsOptionStringValues
    {
        public const string DISABLED = @"DISABLED";
        public const string MANUAL = @"MANUAL";
        public const string AUTO = @"AUTO";
    }

    ///<summary>
    ///Determines the type of a specific Quick Amount.
    ///</summary>
    [Description("Determines the type of a specific Quick Amount.")]
    public enum CatalogQuickAmountType
    {
        ///<summary>
        ///Quick Amount is created manually by the seller.
        ///</summary>
        [Description("Quick Amount is created manually by the seller.")]
        QUICK_AMOUNT_TYPE_MANUAL,
        ///<summary>
        ///Quick Amount is generated automatically by machine learning algorithms.
        ///</summary>
        [Description("Quick Amount is generated automatically by machine learning algorithms.")]
        QUICK_AMOUNT_TYPE_AUTO,
    }

    public static class CatalogQuickAmountTypeStringValues
    {
        public const string QUICK_AMOUNT_TYPE_MANUAL = @"QUICK_AMOUNT_TYPE_MANUAL";
        public const string QUICK_AMOUNT_TYPE_AUTO = @"QUICK_AMOUNT_TYPE_AUTO";
    }

    ///<summary>
    ///Catalog service charge
    ///
    ///Permissions:ORDERS_READ
    ///</summary>
    [Description("Catalog service charge\n\nPermissions:ORDERS_READ")]
    public class CatalogServiceCharge : GraphQLObject<CatalogServiceCharge>
    {
        ///<summary>
        ///ID belonging to the service charge.
        ///</summary>
        [Description("ID belonging to the service charge.")]
        [NonNull]
        public string? id { get; set; }
    }

    ///<summary>
    ///CatalogSort is used for sorting the result for items query
    ///</summary>
    [Description("CatalogSort is used for sorting the result for items query")]
    public enum CatalogSort
    {
        name_DESC,
        name_ASC,
    }

    public static class CatalogSortStringValues
    {
        public const string name_DESC = @"name_DESC";
        public const string name_ASC = @"name_ASC";
    }

    ///<summary>
    ///Represents the rule of conversion between a stockable CatalogItemVariation
    ///and a non-stockable sell-by or receive-by `CatalogItemVariation` that
    ///share the same underlying stock.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Represents the rule of conversion between a stockable CatalogItemVariation\nand a non-stockable sell-by or receive-by `CatalogItemVariation` that\nshare the same underlying stock.\nPermissions: ITEMS_READ")]
    public class CatalogStockConversion : GraphQLObject<CatalogStockConversion>
    {
        ///<summary>
        ///The quantity of the stockable item variation (as identified by `stockable_item_variation_id`)
        ///equivalent to the non-stockable item variation quantity (as specified in `nonstockable_quantity`)
        ///as defined by this stock conversion.  It accepts a decimal number in a string format that can take
        ///up to 10 digits before the decimal point and up to 5 digits after the decimal point.
        ///</summary>
        [Description("The quantity of the stockable item variation (as identified by `stockable_item_variation_id`)\nequivalent to the non-stockable item variation quantity (as specified in `nonstockable_quantity`)\nas defined by this stock conversion.  It accepts a decimal number in a string format that can take\nup to 10 digits before the decimal point and up to 5 digits after the decimal point.")]
        public string? stockableQuantity { get; set; }

        ///<summary>
        ///The converted equivalent quantity of the non-stockable CatalogItemVariation
        ///in its measurement unit. The `stockable_quantity` value and this `nonstockable_quantity` value together
        ///define the conversion ratio between stockable item variation and the non-stockable item variation.
        ///It accepts a decimal number in a string format that can take up to 10 digits before the decimal point
        ///and up to 5 digits after the decimal point.
        ///</summary>
        [Description("The converted equivalent quantity of the non-stockable CatalogItemVariation\nin its measurement unit. The `stockable_quantity` value and this `nonstockable_quantity` value together\ndefine the conversion ratio between stockable item variation and the non-stockable item variation.\nIt accepts a decimal number in a string format that can take up to 10 digits before the decimal point\nand up to 5 digits after the decimal point.")]
        public string? nonstockableQuantity { get; set; }

        ///<summary>
        ///References to the stockable CatalogItemVariation
        ///for this stock conversion. Selling, receiving or recounting the non-stockable `CatalogItemVariation`
        ///defined with a stock conversion results in adjustments of this stockable `CatalogItemVariation`.
        ///This immutable field must reference a stockable `CatalogItemVariation`
        ///that shares the parent CatalogItem of the converted `CatalogItemVariation.`
        ///</summary>
        [Description("References to the stockable CatalogItemVariation\nfor this stock conversion. Selling, receiving or recounting the non-stockable `CatalogItemVariation`\ndefined with a stock conversion results in adjustments of this stockable `CatalogItemVariation`.\nThis immutable field must reference a stockable `CatalogItemVariation`\nthat shares the parent CatalogItem of the converted `CatalogItemVariation.`")]
        public CatalogItemVariation? stockableItemVariation { get; set; }
    }

    ///<summary>
    ///Defines supported stock levels of the item inventory.
    ///</summary>
    [Description("Defines supported stock levels of the item inventory.")]
    public enum CatalogStockLevel
    {
        ///<summary>
        ///The item inventory is empty.
        ///</summary>
        [Description("The item inventory is empty.")]
        OUT,
        ///<summary>
        ///The item inventory is low.
        ///</summary>
        [Description("The item inventory is low.")]
        LOW,
    }

    public static class CatalogStockLevelStringValues
    {
        public const string OUT = @"OUT";
        public const string LOW = @"LOW";
    }

    ///<summary>
    ///Describes a subscription plan.A subscription plan represents what you want to sell in a subscription model, and includes references to each of the associated subscription plan variations. 
    ///For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Describes a subscription plan.A subscription plan represents what you want to sell in a subscription model, and includes references to each of the associated subscription plan variations. \nFor more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).\nPermissions: ITEMS_READ")]
    public class CatalogSubscriptionPlan : GraphQLObject<CatalogSubscriptionPlan>, ICatalogObject
    {
        ///<summary>
        ///The name of the plan.
        ///</summary>
        [Description("The name of the plan.")]
        public string? name { get; set; }

        ///<summary>
        ///A list of SubscriptionPhase containing the SubscriptionPhase for this plan.
        ///This field it required. Not including this field will throw a REQUIRED_FIELD_MISSING error
        ///</summary>
        [Description("A list of SubscriptionPhase containing the SubscriptionPhase for this plan.\nThis field it required. Not including this field will throw a REQUIRED_FIELD_MISSING error")]
        public IEnumerable<SubscriptionPhase>? phases { get; set; }

        ///<summary>
        ///If true, all items in the merchant's catalog are subscribable by this SubscriptionPlan.
        ///</summary>
        [Description("If true, all items in the merchant's catalog are subscribable by this SubscriptionPlan.")]
        public bool? allItems { get; set; }

        ///<summary>
        ///The list of subscription plan variations available for this product
        ///</summary>
        [Description("The list of subscription plan variations available for this product")]
        public IEnumerable<CatalogSubscriptionPlanVariation>? subscriptionPlanVariations { get; set; }

        ///<summary>
        ///The list of IDs of `CatalogItems` that are eligible for subscription by this SubscriptionPlan's variations.
        ///</summary>
        [Description("The list of IDs of `CatalogItems` that are eligible for subscription by this SubscriptionPlan's variations.")]
        public IEnumerable<CatalogItem>? eligibleItems { get; set; }

        ///<summary>
        ///The list of IDs of `CatalogCategory` that are eligible for subscription by this SubscriptionPlan's variations.
        ///</summary>
        [Description("The list of IDs of `CatalogCategory` that are eligible for subscription by this SubscriptionPlan's variations.")]
        public IEnumerable<CatalogCategory>? eligibleCategories { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Describes a subscription plan variation.A subscription plan variation represents how the subscription for a product or service is sold.
    ///For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Describes a subscription plan variation.A subscription plan variation represents how the subscription for a product or service is sold.\nFor more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).\nPermissions: ITEMS_READ")]
    public class CatalogSubscriptionPlanVariation : GraphQLObject<CatalogSubscriptionPlanVariation>, ICatalogObject
    {
        ///<summary>
        ///The name of the plan variation.
        ///</summary>
        [Description("The name of the plan variation.")]
        public string? name { get; set; }

        ///<summary>
        ///A list containing each SubscriptionPhase for this plan variation.
        ///</summary>
        [Description("A list containing each SubscriptionPhase for this plan variation.")]
        public IEnumerable<SubscriptionPhase>? phases { get; set; }

        ///<summary>
        ///The id of the subscription plan, if there is one.
        ///</summary>
        [Description("The id of the subscription plan, if there is one.")]
        public CatalogSubscriptionPlan? subscriptionPlan { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///A tax applicable to an item.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("A tax applicable to an item.\nPermissions: ITEMS_READ")]
    public class CatalogTax : GraphQLObject<CatalogTax>, ICatalogObject
    {
        ///<summary>
        ///The tax's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        ///</summary>
        [Description("The tax's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.")]
        public string? name { get; set; }

        ///<summary>
        ///Whether the tax is calculated based on a payment's subtotal or total.
        ///</summary>
        [Description("Whether the tax is calculated based on a payment's subtotal or total.")]
        public TaxCalculationPhase? calculationPhase { get; set; }

        ///<summary>
        ///Whether the tax is `ADDITIVE` or `INCLUSIVE`.
        ///</summary>
        [Description("Whether the tax is `ADDITIVE` or `INCLUSIVE`.")]
        public TaxInclusionType? inclusionType { get; set; }

        ///<summary>
        ///If `true`, the fee applies to custom amounts entered into the Square Point of Sale
        ///app that are not associated with a particular `CatalogItem`.
        ///</summary>
        [Description("If `true`, the fee applies to custom amounts entered into the Square Point of Sale\napp that are not associated with a particular `CatalogItem`.")]
        public bool? appliesToCustomAmounts { get; set; }

        ///<summary>
        ///A Boolean flag to indicate whether the tax is displayed as enabled (`true`) in the Square Point of Sale app or not (`false`).
        ///</summary>
        [Description("A Boolean flag to indicate whether the tax is displayed as enabled (`true`) in the Square Point of Sale app or not (`false`).")]
        public bool? enabled { get; set; }

        ///<summary>
        ///The percentage of the tax in decimal form, using a `'.'` as the decimal separator and without a `'%'` sign.
        ///A value of `7.5` corresponds to 7.5%. For a location-specific tax rate, contact the tax authority of the location or a tax consultant.
        ///</summary>
        [Description("The percentage of the tax in decimal form, using a `'.'` as the decimal separator and without a `'%'` sign.\nA value of `7.5` corresponds to 7.5%. For a location-specific tax rate, contact the tax authority of the location or a tax consultant.")]
        public decimal? percentage { get; set; }

        ///<summary>
        ///The ID of a `CatalogProductSet` object. If set, the tax is applicable to all products in the product set.
        ///</summary>
        [Description("The ID of a `CatalogProductSet` object. If set, the tax is applicable to all products in the product set.")]
        public CatalogProductSet? appliesToProductSet { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Represents a time period - either a single period or a repeating period.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Represents a time period - either a single period or a repeating period.\nPermissions: ITEMS_READ")]
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
        [Description("An iCalendar (RFC 5545) [event](https://tools.ietf.org/html/rfc5545#section-3.6.1), which\nspecifies the name, timing, duration and recurrence of this time period.\n\nExample:\n\n```\nDTSTART:20190707T180000\nDURATION:P2H\nRRULE:FREQ=WEEKLY;BYDAY=MO,WE,FR\n```\n\nOnly `SUMMARY`, `DTSTART`, `DURATION` and `RRULE` fields are supported.\n`DTSTART` must be in local (unzoned) time format. Note that while `BEGIN:VEVENT`\nand `END:VEVENT` is not required in the request. The response will always\ninclude them.")]
        public string? @event { get; set; }

        ///<summary>
        ///An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.
        ///</summary>
        [Description("An identifier to reference this object in the catalog. When a new CatalogObject is inserted, the client should set the id to a temporary identifier starting with a '#' character. Other objects being inserted or updated within the same request may use this identifier to refer to the new object.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.
        ///</summary>
        [Description("The version of the object. For the REST API, when a new CatalogObject in inserted, the version supplied must match the version in the database otherwise the write will be rejected as conflicting.")]
        [NonNull]
        public long? version { get; set; }

        ///<summary>
        ///The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.
        ///</summary>
        [Description("The Connect v1 IDs for this object at each location where it is present, where they differ from the object's Connect V2 ID. The field will only be present for objects that have been created or modified by legacy APIs.")]
        public IEnumerable<string>? catalogV1Ids { get; set; }

        ///<summary>
        ///If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.
        ///</summary>
        [Description("If true, the object has been deleted from the database. Must be false for new objects being inserted. When deleted, updatedAt will equal the deletion time.")]
        public bool? isDeleted { get; set; }

        ///<summary>
        ///Last modification timestamp.
        ///</summary>
        [Description("Last modification timestamp.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///This value will always be null. Custom attributes do not apply to this object
        ///</summary>
        [Description("This value will always be null. Custom attributes do not apply to this object")]
        public IEnumerable<CatalogCustomAttributeValue>? customAttributes { get; set; }

        ///<summary>
        ///A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is not present, even if presentAtAll is true. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? absentAt { get; set; }

        ///<summary>
        ///A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.
        ///</summary>
        [Description("A list of locations where the object is present, even if presentAtAll is false. Only the Location.id will be filled in.")]
        public IEnumerable<Location>? presentAt { get; set; }

        ///<summary>
        ///If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.
        ///</summary>
        [Description("If true, this object is present at all locations (including future locations), except where specified in absentAt. If false, this object is not present at any locations (including future locations), except where specified in presentAt. If not specified, defaults to true.")]
        public bool? presentAtAll { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about Clearpay payments.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nAdditional details about Clearpay payments.")]
    public class ClearpayPaymentDetails : GraphQLObject<ClearpayPaymentDetails>
    {
        ///<summary>
        ///Email address on the buyer's Clearpay account.
        ///</summary>
        [Description("Email address on the buyer's Clearpay account.")]
        public string? emailAddress { get; set; }
    }

    ///<summary>
    ///Indicates the country associated with another entity, such as a business.
    ///Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
    ///</summary>
    [Description("Indicates the country associated with another entity, such as a business.\nValues are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).")]
    public enum Country
    {
        ///<summary>
        ///Andorra
        ///</summary>
        [Description("Andorra")]
        AD,
        ///<summary>
        ///United Arab Emirates
        ///</summary>
        [Description("United Arab Emirates")]
        AE,
        ///<summary>
        ///Afghanistan
        ///</summary>
        [Description("Afghanistan")]
        AF,
        ///<summary>
        ///Antigua and Barbuda
        ///</summary>
        [Description("Antigua and Barbuda")]
        AG,
        ///<summary>
        ///Anguilla
        ///</summary>
        [Description("Anguilla")]
        AI,
        ///<summary>
        ///Albania
        ///</summary>
        [Description("Albania")]
        AL,
        ///<summary>
        ///Armenia
        ///</summary>
        [Description("Armenia")]
        AM,
        ///<summary>
        ///Angola
        ///</summary>
        [Description("Angola")]
        AO,
        ///<summary>
        ///Antartica
        ///</summary>
        [Description("Antartica")]
        AQ,
        ///<summary>
        ///Argentina
        ///</summary>
        [Description("Argentina")]
        AR,
        ///<summary>
        ///American Samoa
        ///</summary>
        [Description("American Samoa")]
        AS,
        ///<summary>
        ///Austria
        ///</summary>
        [Description("Austria")]
        AT,
        ///<summary>
        ///Australia
        ///</summary>
        [Description("Australia")]
        AU,
        ///<summary>
        ///Aruba
        ///</summary>
        [Description("Aruba")]
        AW,
        ///<summary>
        ///Åland Islands
        ///</summary>
        [Description("Åland Islands")]
        AX,
        ///<summary>
        ///Azerbaijan
        ///</summary>
        [Description("Azerbaijan")]
        AZ,
        ///<summary>
        ///Bosnia and Herzegovina
        ///</summary>
        [Description("Bosnia and Herzegovina")]
        BA,
        ///<summary>
        ///Barbados
        ///</summary>
        [Description("Barbados")]
        BB,
        ///<summary>
        ///Bangladesh
        ///</summary>
        [Description("Bangladesh")]
        BD,
        ///<summary>
        ///Belgium
        ///</summary>
        [Description("Belgium")]
        BE,
        ///<summary>
        ///Burkina Faso
        ///</summary>
        [Description("Burkina Faso")]
        BF,
        ///<summary>
        ///Bulgaria
        ///</summary>
        [Description("Bulgaria")]
        BG,
        ///<summary>
        ///Bahrain
        ///</summary>
        [Description("Bahrain")]
        BH,
        ///<summary>
        ///Burundi
        ///</summary>
        [Description("Burundi")]
        BI,
        ///<summary>
        ///Benin
        ///</summary>
        [Description("Benin")]
        BJ,
        ///<summary>
        ///Saint Barthélemy
        ///</summary>
        [Description("Saint Barthélemy")]
        BL,
        ///<summary>
        ///Bermuda
        ///</summary>
        [Description("Bermuda")]
        BM,
        ///<summary>
        ///Brunei
        ///</summary>
        [Description("Brunei")]
        BN,
        ///<summary>
        ///Bolivia
        ///</summary>
        [Description("Bolivia")]
        BO,
        ///<summary>
        ///Bonaire
        ///</summary>
        [Description("Bonaire")]
        BQ,
        ///<summary>
        ///Brazil
        ///</summary>
        [Description("Brazil")]
        BR,
        ///<summary>
        ///Bahamas
        ///</summary>
        [Description("Bahamas")]
        BS,
        ///<summary>
        ///Bhutan
        ///</summary>
        [Description("Bhutan")]
        BT,
        ///<summary>
        ///Bouvet Island
        ///</summary>
        [Description("Bouvet Island")]
        BV,
        ///<summary>
        ///Botswana
        ///</summary>
        [Description("Botswana")]
        BW,
        ///<summary>
        ///Belarus
        ///</summary>
        [Description("Belarus")]
        BY,
        ///<summary>
        ///Belize
        ///</summary>
        [Description("Belize")]
        BZ,
        ///<summary>
        ///Canada
        ///</summary>
        [Description("Canada")]
        CA,
        ///<summary>
        ///Cocos Islands
        ///</summary>
        [Description("Cocos Islands")]
        CC,
        ///<summary>
        ///Democratic Republic of the Congo
        ///</summary>
        [Description("Democratic Republic of the Congo")]
        CD,
        ///<summary>
        ///Central African Republic
        ///</summary>
        [Description("Central African Republic")]
        CF,
        ///<summary>
        ///Congo
        ///</summary>
        [Description("Congo")]
        CG,
        ///<summary>
        ///Switzerland
        ///</summary>
        [Description("Switzerland")]
        CH,
        ///<summary>
        ///Ivory Coast
        ///</summary>
        [Description("Ivory Coast")]
        CI,
        ///<summary>
        ///Cook Islands
        ///</summary>
        [Description("Cook Islands")]
        CK,
        ///<summary>
        ///Chile
        ///</summary>
        [Description("Chile")]
        CL,
        ///<summary>
        ///Cameroon
        ///</summary>
        [Description("Cameroon")]
        CM,
        ///<summary>
        ///China
        ///</summary>
        [Description("China")]
        CN,
        ///<summary>
        ///Colombia
        ///</summary>
        [Description("Colombia")]
        CO,
        ///<summary>
        ///Costa Rica
        ///</summary>
        [Description("Costa Rica")]
        CR,
        ///<summary>
        ///Cuba
        ///</summary>
        [Description("Cuba")]
        CU,
        ///<summary>
        ///Cabo Verde
        ///</summary>
        [Description("Cabo Verde")]
        CV,
        ///<summary>
        ///Curaçao
        ///</summary>
        [Description("Curaçao")]
        CW,
        ///<summary>
        ///Christmas Island
        ///</summary>
        [Description("Christmas Island")]
        CX,
        ///<summary>
        ///Cyprus
        ///</summary>
        [Description("Cyprus")]
        CY,
        ///<summary>
        ///Czechia
        ///</summary>
        [Description("Czechia")]
        CZ,
        ///<summary>
        ///Germany
        ///</summary>
        [Description("Germany")]
        DE,
        ///<summary>
        ///Djibouti
        ///</summary>
        [Description("Djibouti")]
        DJ,
        ///<summary>
        ///Denmark
        ///</summary>
        [Description("Denmark")]
        DK,
        ///<summary>
        ///Dominica
        ///</summary>
        [Description("Dominica")]
        DM,
        ///<summary>
        ///Dominican Republic
        ///</summary>
        [Description("Dominican Republic")]
        DO,
        ///<summary>
        ///Algeria
        ///</summary>
        [Description("Algeria")]
        DZ,
        ///<summary>
        ///Ecuador
        ///</summary>
        [Description("Ecuador")]
        EC,
        ///<summary>
        ///Estonia
        ///</summary>
        [Description("Estonia")]
        EE,
        ///<summary>
        ///Egypt
        ///</summary>
        [Description("Egypt")]
        EG,
        ///<summary>
        ///Western Sahara
        ///</summary>
        [Description("Western Sahara")]
        EH,
        ///<summary>
        ///Eritrea
        ///</summary>
        [Description("Eritrea")]
        ER,
        ///<summary>
        ///Spain
        ///</summary>
        [Description("Spain")]
        ES,
        ///<summary>
        ///Ethiopia
        ///</summary>
        [Description("Ethiopia")]
        ET,
        ///<summary>
        ///Finland
        ///</summary>
        [Description("Finland")]
        FI,
        ///<summary>
        ///Fiji
        ///</summary>
        [Description("Fiji")]
        FJ,
        ///<summary>
        ///Falkland Islands
        ///</summary>
        [Description("Falkland Islands")]
        FK,
        ///<summary>
        ///Federated States of Micronesia
        ///</summary>
        [Description("Federated States of Micronesia")]
        FM,
        ///<summary>
        ///Faroe Islands
        ///</summary>
        [Description("Faroe Islands")]
        FO,
        ///<summary>
        ///France
        ///</summary>
        [Description("France")]
        FR,
        ///<summary>
        ///Gabon
        ///</summary>
        [Description("Gabon")]
        GA,
        ///<summary>
        ///United Kingdom
        ///</summary>
        [Description("United Kingdom")]
        GB,
        ///<summary>
        ///Grenada
        ///</summary>
        [Description("Grenada")]
        GD,
        ///<summary>
        ///Georgia
        ///</summary>
        [Description("Georgia")]
        GE,
        ///<summary>
        ///French Guiana
        ///</summary>
        [Description("French Guiana")]
        GF,
        ///<summary>
        ///Guernsey
        ///</summary>
        [Description("Guernsey")]
        GG,
        ///<summary>
        ///Ghana
        ///</summary>
        [Description("Ghana")]
        GH,
        ///<summary>
        ///Gibraltar
        ///</summary>
        [Description("Gibraltar")]
        GI,
        ///<summary>
        ///Greenland
        ///</summary>
        [Description("Greenland")]
        GL,
        ///<summary>
        ///Gambia
        ///</summary>
        [Description("Gambia")]
        GM,
        ///<summary>
        ///Guinea
        ///</summary>
        [Description("Guinea")]
        GN,
        ///<summary>
        ///Guadeloupe
        ///</summary>
        [Description("Guadeloupe")]
        GP,
        ///<summary>
        ///Equatorial Guinea
        ///</summary>
        [Description("Equatorial Guinea")]
        GQ,
        ///<summary>
        ///Greece
        ///</summary>
        [Description("Greece")]
        GR,
        ///<summary>
        ///South Georgia and the South Sandwich Islands
        ///</summary>
        [Description("South Georgia and the South Sandwich Islands")]
        GS,
        ///<summary>
        ///Guatemala
        ///</summary>
        [Description("Guatemala")]
        GT,
        ///<summary>
        ///Guam
        ///</summary>
        [Description("Guam")]
        GU,
        ///<summary>
        ///Guinea-Bissau
        ///</summary>
        [Description("Guinea-Bissau")]
        GW,
        ///<summary>
        ///Guyana
        ///</summary>
        [Description("Guyana")]
        GY,
        ///<summary>
        ///Hong Kong
        ///</summary>
        [Description("Hong Kong")]
        HK,
        ///<summary>
        ///Heard Island and McDonald Islands
        ///</summary>
        [Description("Heard Island and McDonald Islands")]
        HM,
        ///<summary>
        ///Honduras
        ///</summary>
        [Description("Honduras")]
        HN,
        ///<summary>
        ///Croatia
        ///</summary>
        [Description("Croatia")]
        HR,
        ///<summary>
        ///Haiti
        ///</summary>
        [Description("Haiti")]
        HT,
        ///<summary>
        ///Hungary
        ///</summary>
        [Description("Hungary")]
        HU,
        ///<summary>
        ///Indonesia
        ///</summary>
        [Description("Indonesia")]
        ID,
        ///<summary>
        ///Ireland
        ///</summary>
        [Description("Ireland")]
        IE,
        ///<summary>
        ///Israel
        ///</summary>
        [Description("Israel")]
        IL,
        ///<summary>
        ///Isle of Man
        ///</summary>
        [Description("Isle of Man")]
        IM,
        ///<summary>
        ///India
        ///</summary>
        [Description("India")]
        IN,
        ///<summary>
        ///British Indian Ocean Territory
        ///</summary>
        [Description("British Indian Ocean Territory")]
        IO,
        ///<summary>
        ///Iraq
        ///</summary>
        [Description("Iraq")]
        IQ,
        ///<summary>
        ///Iran
        ///</summary>
        [Description("Iran")]
        IR,
        ///<summary>
        ///Iceland
        ///</summary>
        [Description("Iceland")]
        IS,
        ///<summary>
        ///Italy
        ///</summary>
        [Description("Italy")]
        IT,
        ///<summary>
        ///Jersey
        ///</summary>
        [Description("Jersey")]
        JE,
        ///<summary>
        ///Jamaica
        ///</summary>
        [Description("Jamaica")]
        JM,
        ///<summary>
        ///Jordan
        ///</summary>
        [Description("Jordan")]
        JO,
        ///<summary>
        ///Japan
        ///</summary>
        [Description("Japan")]
        JP,
        ///<summary>
        ///Kenya
        ///</summary>
        [Description("Kenya")]
        KE,
        ///<summary>
        ///Kyrgyzstan
        ///</summary>
        [Description("Kyrgyzstan")]
        KG,
        ///<summary>
        ///Cambodia
        ///</summary>
        [Description("Cambodia")]
        KH,
        ///<summary>
        ///Kiribati
        ///</summary>
        [Description("Kiribati")]
        KI,
        ///<summary>
        ///Comoros
        ///</summary>
        [Description("Comoros")]
        KM,
        ///<summary>
        ///Saint Kitts and Nevis
        ///</summary>
        [Description("Saint Kitts and Nevis")]
        KN,
        ///<summary>
        ///Democratic People's Republic of Korea
        ///</summary>
        [Description("Democratic People's Republic of Korea")]
        KP,
        ///<summary>
        ///Republic of Korea
        ///</summary>
        [Description("Republic of Korea")]
        KR,
        ///<summary>
        ///Kuwait
        ///</summary>
        [Description("Kuwait")]
        KW,
        ///<summary>
        ///Cayman Islands
        ///</summary>
        [Description("Cayman Islands")]
        KY,
        ///<summary>
        ///Kazakhstan
        ///</summary>
        [Description("Kazakhstan")]
        KZ,
        ///<summary>
        ///Lao People's Democratic Republic
        ///</summary>
        [Description("Lao People's Democratic Republic")]
        LA,
        ///<summary>
        ///Lebanon
        ///</summary>
        [Description("Lebanon")]
        LB,
        ///<summary>
        ///Saint Lucia
        ///</summary>
        [Description("Saint Lucia")]
        LC,
        ///<summary>
        ///Liechtenstein
        ///</summary>
        [Description("Liechtenstein")]
        LI,
        ///<summary>
        ///Sri Lanka
        ///</summary>
        [Description("Sri Lanka")]
        LK,
        ///<summary>
        ///Liberia
        ///</summary>
        [Description("Liberia")]
        LR,
        ///<summary>
        ///Lesotho
        ///</summary>
        [Description("Lesotho")]
        LS,
        ///<summary>
        ///Lithuania
        ///</summary>
        [Description("Lithuania")]
        LT,
        ///<summary>
        ///Luxembourg
        ///</summary>
        [Description("Luxembourg")]
        LU,
        ///<summary>
        ///Latvia
        ///</summary>
        [Description("Latvia")]
        LV,
        ///<summary>
        ///Libya
        ///</summary>
        [Description("Libya")]
        LY,
        ///<summary>
        ///Morocco
        ///</summary>
        [Description("Morocco")]
        MA,
        ///<summary>
        ///Monaco
        ///</summary>
        [Description("Monaco")]
        MC,
        ///<summary>
        ///Moldova
        ///</summary>
        [Description("Moldova")]
        MD,
        ///<summary>
        ///Montenegro
        ///</summary>
        [Description("Montenegro")]
        ME,
        ///<summary>
        ///Saint Martin
        ///</summary>
        [Description("Saint Martin")]
        MF,
        ///<summary>
        ///Madagascar
        ///</summary>
        [Description("Madagascar")]
        MG,
        ///<summary>
        ///Marshall Islands
        ///</summary>
        [Description("Marshall Islands")]
        MH,
        ///<summary>
        ///North Macedonia
        ///</summary>
        [Description("North Macedonia")]
        MK,
        ///<summary>
        ///Mali
        ///</summary>
        [Description("Mali")]
        ML,
        ///<summary>
        ///Myanmar
        ///</summary>
        [Description("Myanmar")]
        MM,
        ///<summary>
        ///Mongolia
        ///</summary>
        [Description("Mongolia")]
        MN,
        ///<summary>
        ///Macao
        ///</summary>
        [Description("Macao")]
        MO,
        ///<summary>
        ///Northern Mariana Islands
        ///</summary>
        [Description("Northern Mariana Islands")]
        MP,
        ///<summary>
        ///Martinique
        ///</summary>
        [Description("Martinique")]
        MQ,
        ///<summary>
        ///Mauritania
        ///</summary>
        [Description("Mauritania")]
        MR,
        ///<summary>
        ///Montserrat
        ///</summary>
        [Description("Montserrat")]
        MS,
        ///<summary>
        ///Malta
        ///</summary>
        [Description("Malta")]
        MT,
        ///<summary>
        ///Mauritius
        ///</summary>
        [Description("Mauritius")]
        MU,
        ///<summary>
        ///Maldives
        ///</summary>
        [Description("Maldives")]
        MV,
        ///<summary>
        ///Malawi
        ///</summary>
        [Description("Malawi")]
        MW,
        ///<summary>
        ///Mexico
        ///</summary>
        [Description("Mexico")]
        MX,
        ///<summary>
        ///Malaysia
        ///</summary>
        [Description("Malaysia")]
        MY,
        ///<summary>
        ///Mozambique
        ///</summary>
        [Description("Mozambique")]
        MZ,
        ///<summary>
        ///Namibia
        ///</summary>
        [Description("Namibia")]
        NA,
        ///<summary>
        ///New Caledonia
        ///</summary>
        [Description("New Caledonia")]
        NC,
        ///<summary>
        ///Niger
        ///</summary>
        [Description("Niger")]
        NE,
        ///<summary>
        ///Norfolk Island
        ///</summary>
        [Description("Norfolk Island")]
        NF,
        ///<summary>
        ///Nigeria
        ///</summary>
        [Description("Nigeria")]
        NG,
        ///<summary>
        ///Nicaragua
        ///</summary>
        [Description("Nicaragua")]
        NI,
        ///<summary>
        ///Netherlands
        ///</summary>
        [Description("Netherlands")]
        NL,
        ///<summary>
        ///Norway
        ///</summary>
        [Description("Norway")]
        NO,
        ///<summary>
        ///Nepal
        ///</summary>
        [Description("Nepal")]
        NP,
        ///<summary>
        ///Nauru
        ///</summary>
        [Description("Nauru")]
        NR,
        ///<summary>
        ///Niue
        ///</summary>
        [Description("Niue")]
        NU,
        ///<summary>
        ///New Zealand
        ///</summary>
        [Description("New Zealand")]
        NZ,
        ///<summary>
        ///Oman
        ///</summary>
        [Description("Oman")]
        OM,
        ///<summary>
        ///Panama
        ///</summary>
        [Description("Panama")]
        PA,
        ///<summary>
        ///Peru
        ///</summary>
        [Description("Peru")]
        PE,
        ///<summary>
        ///French Polynesia
        ///</summary>
        [Description("French Polynesia")]
        PF,
        ///<summary>
        ///Papua New Guinea
        ///</summary>
        [Description("Papua New Guinea")]
        PG,
        ///<summary>
        ///Philippines
        ///</summary>
        [Description("Philippines")]
        PH,
        ///<summary>
        ///Pakistan
        ///</summary>
        [Description("Pakistan")]
        PK,
        ///<summary>
        ///Poland
        ///</summary>
        [Description("Poland")]
        PL,
        ///<summary>
        ///Saint Pierre and Miquelon
        ///</summary>
        [Description("Saint Pierre and Miquelon")]
        PM,
        ///<summary>
        ///Pitcairn
        ///</summary>
        [Description("Pitcairn")]
        PN,
        ///<summary>
        ///Puerto Rico
        ///</summary>
        [Description("Puerto Rico")]
        PR,
        ///<summary>
        ///Palestine
        ///</summary>
        [Description("Palestine")]
        PS,
        ///<summary>
        ///Portugal
        ///</summary>
        [Description("Portugal")]
        PT,
        ///<summary>
        ///Palau
        ///</summary>
        [Description("Palau")]
        PW,
        ///<summary>
        ///Paraguay
        ///</summary>
        [Description("Paraguay")]
        PY,
        ///<summary>
        ///Qatar
        ///</summary>
        [Description("Qatar")]
        QA,
        ///<summary>
        ///Réunion
        ///</summary>
        [Description("Réunion")]
        RE,
        ///<summary>
        ///Romania
        ///</summary>
        [Description("Romania")]
        RO,
        ///<summary>
        ///Serbia
        ///</summary>
        [Description("Serbia")]
        RS,
        ///<summary>
        ///Russia
        ///</summary>
        [Description("Russia")]
        RU,
        ///<summary>
        ///Rwanda
        ///</summary>
        [Description("Rwanda")]
        RW,
        ///<summary>
        ///Saudi Arabia
        ///</summary>
        [Description("Saudi Arabia")]
        SA,
        ///<summary>
        ///Solomon Islands
        ///</summary>
        [Description("Solomon Islands")]
        SB,
        ///<summary>
        ///Seychelles
        ///</summary>
        [Description("Seychelles")]
        SC,
        ///<summary>
        ///Sudan
        ///</summary>
        [Description("Sudan")]
        SD,
        ///<summary>
        ///Sweden
        ///</summary>
        [Description("Sweden")]
        SE,
        ///<summary>
        ///Singapore
        ///</summary>
        [Description("Singapore")]
        SG,
        ///<summary>
        ///Saint Helena, Ascension and Tristan da Cunha
        ///</summary>
        [Description("Saint Helena, Ascension and Tristan da Cunha")]
        SH,
        ///<summary>
        ///Slovenia
        ///</summary>
        [Description("Slovenia")]
        SI,
        ///<summary>
        ///Svalbard and Jan Mayen
        ///</summary>
        [Description("Svalbard and Jan Mayen")]
        SJ,
        ///<summary>
        ///Slovakia
        ///</summary>
        [Description("Slovakia")]
        SK,
        ///<summary>
        ///Sierra Leone
        ///</summary>
        [Description("Sierra Leone")]
        SL,
        ///<summary>
        ///San Marino
        ///</summary>
        [Description("San Marino")]
        SM,
        ///<summary>
        ///Senegal
        ///</summary>
        [Description("Senegal")]
        SN,
        ///<summary>
        ///Somalia
        ///</summary>
        [Description("Somalia")]
        SO,
        ///<summary>
        ///Suriname
        ///</summary>
        [Description("Suriname")]
        SR,
        ///<summary>
        ///South Sudan
        ///</summary>
        [Description("South Sudan")]
        SS,
        ///<summary>
        ///Sao Tome and Principe
        ///</summary>
        [Description("Sao Tome and Principe")]
        ST,
        ///<summary>
        ///El Salvador
        ///</summary>
        [Description("El Salvador")]
        SV,
        ///<summary>
        ///Sint Maarten
        ///</summary>
        [Description("Sint Maarten")]
        SX,
        ///<summary>
        ///Syrian Arab Republic
        ///</summary>
        [Description("Syrian Arab Republic")]
        SY,
        ///<summary>
        ///Eswatini
        ///</summary>
        [Description("Eswatini")]
        SZ,
        ///<summary>
        ///Turks and Caicos Islands
        ///</summary>
        [Description("Turks and Caicos Islands")]
        TC,
        ///<summary>
        ///Chad
        ///</summary>
        [Description("Chad")]
        TD,
        ///<summary>
        ///French Southern Territories
        ///</summary>
        [Description("French Southern Territories")]
        TF,
        ///<summary>
        ///Togo
        ///</summary>
        [Description("Togo")]
        TG,
        ///<summary>
        ///Thailand
        ///</summary>
        [Description("Thailand")]
        TH,
        ///<summary>
        ///Tajikistan
        ///</summary>
        [Description("Tajikistan")]
        TJ,
        ///<summary>
        ///Tokelau
        ///</summary>
        [Description("Tokelau")]
        TK,
        ///<summary>
        ///Timor-Leste
        ///</summary>
        [Description("Timor-Leste")]
        TL,
        ///<summary>
        ///Turkmenistan
        ///</summary>
        [Description("Turkmenistan")]
        TM,
        ///<summary>
        ///Tunisia
        ///</summary>
        [Description("Tunisia")]
        TN,
        ///<summary>
        ///Tonga
        ///</summary>
        [Description("Tonga")]
        TO,
        ///<summary>
        ///Turkey
        ///</summary>
        [Description("Turkey")]
        TR,
        ///<summary>
        ///Trinidad and Tobago
        ///</summary>
        [Description("Trinidad and Tobago")]
        TT,
        ///<summary>
        ///Tuvalu
        ///</summary>
        [Description("Tuvalu")]
        TV,
        ///<summary>
        ///Taiwan
        ///</summary>
        [Description("Taiwan")]
        TW,
        ///<summary>
        ///Tanzania
        ///</summary>
        [Description("Tanzania")]
        TZ,
        ///<summary>
        ///Ukraine
        ///</summary>
        [Description("Ukraine")]
        UA,
        ///<summary>
        ///Uganda
        ///</summary>
        [Description("Uganda")]
        UG,
        ///<summary>
        ///United States Minor Outlying Islands
        ///</summary>
        [Description("United States Minor Outlying Islands")]
        UM,
        ///<summary>
        ///United States of America
        ///</summary>
        [Description("United States of America")]
        US,
        ///<summary>
        ///Uruguay
        ///</summary>
        [Description("Uruguay")]
        UY,
        ///<summary>
        ///Uzbekistan
        ///</summary>
        [Description("Uzbekistan")]
        UZ,
        ///<summary>
        ///Vatican City
        ///</summary>
        [Description("Vatican City")]
        VA,
        ///<summary>
        ///Saint Vincent and the Grenadines
        ///</summary>
        [Description("Saint Vincent and the Grenadines")]
        VC,
        ///<summary>
        ///Venezuela
        ///</summary>
        [Description("Venezuela")]
        VE,
        ///<summary>
        ///British Virgin Islands
        ///</summary>
        [Description("British Virgin Islands")]
        VG,
        ///<summary>
        ///U.S. Virgin Islands
        ///</summary>
        [Description("U.S. Virgin Islands")]
        VI,
        ///<summary>
        ///Vietnam
        ///</summary>
        [Description("Vietnam")]
        VN,
        ///<summary>
        ///Vanuatu
        ///</summary>
        [Description("Vanuatu")]
        VU,
        ///<summary>
        ///Wallis and Futuna
        ///</summary>
        [Description("Wallis and Futuna")]
        WF,
        ///<summary>
        ///Samoa
        ///</summary>
        [Description("Samoa")]
        WS,
        ///<summary>
        ///Yemen
        ///</summary>
        [Description("Yemen")]
        YE,
        ///<summary>
        ///Mayotte
        ///</summary>
        [Description("Mayotte")]
        YT,
        ///<summary>
        ///South Africa
        ///</summary>
        [Description("South Africa")]
        ZA,
        ///<summary>
        ///Zambia
        ///</summary>
        [Description("Zambia")]
        ZM,
        ///<summary>
        ///Zimbabwe
        ///</summary>
        [Description("Zimbabwe")]
        ZW,
        ///<summary>
        ///Unknown
        ///</summary>
        [Description("Unknown")]
        ZZ,
    }

    public static class CountryStringValues
    {
        public const string AD = @"AD";
        public const string AE = @"AE";
        public const string AF = @"AF";
        public const string AG = @"AG";
        public const string AI = @"AI";
        public const string AL = @"AL";
        public const string AM = @"AM";
        public const string AO = @"AO";
        public const string AQ = @"AQ";
        public const string AR = @"AR";
        public const string AS = @"AS";
        public const string AT = @"AT";
        public const string AU = @"AU";
        public const string AW = @"AW";
        public const string AX = @"AX";
        public const string AZ = @"AZ";
        public const string BA = @"BA";
        public const string BB = @"BB";
        public const string BD = @"BD";
        public const string BE = @"BE";
        public const string BF = @"BF";
        public const string BG = @"BG";
        public const string BH = @"BH";
        public const string BI = @"BI";
        public const string BJ = @"BJ";
        public const string BL = @"BL";
        public const string BM = @"BM";
        public const string BN = @"BN";
        public const string BO = @"BO";
        public const string BQ = @"BQ";
        public const string BR = @"BR";
        public const string BS = @"BS";
        public const string BT = @"BT";
        public const string BV = @"BV";
        public const string BW = @"BW";
        public const string BY = @"BY";
        public const string BZ = @"BZ";
        public const string CA = @"CA";
        public const string CC = @"CC";
        public const string CD = @"CD";
        public const string CF = @"CF";
        public const string CG = @"CG";
        public const string CH = @"CH";
        public const string CI = @"CI";
        public const string CK = @"CK";
        public const string CL = @"CL";
        public const string CM = @"CM";
        public const string CN = @"CN";
        public const string CO = @"CO";
        public const string CR = @"CR";
        public const string CU = @"CU";
        public const string CV = @"CV";
        public const string CW = @"CW";
        public const string CX = @"CX";
        public const string CY = @"CY";
        public const string CZ = @"CZ";
        public const string DE = @"DE";
        public const string DJ = @"DJ";
        public const string DK = @"DK";
        public const string DM = @"DM";
        public const string DO = @"DO";
        public const string DZ = @"DZ";
        public const string EC = @"EC";
        public const string EE = @"EE";
        public const string EG = @"EG";
        public const string EH = @"EH";
        public const string ER = @"ER";
        public const string ES = @"ES";
        public const string ET = @"ET";
        public const string FI = @"FI";
        public const string FJ = @"FJ";
        public const string FK = @"FK";
        public const string FM = @"FM";
        public const string FO = @"FO";
        public const string FR = @"FR";
        public const string GA = @"GA";
        public const string GB = @"GB";
        public const string GD = @"GD";
        public const string GE = @"GE";
        public const string GF = @"GF";
        public const string GG = @"GG";
        public const string GH = @"GH";
        public const string GI = @"GI";
        public const string GL = @"GL";
        public const string GM = @"GM";
        public const string GN = @"GN";
        public const string GP = @"GP";
        public const string GQ = @"GQ";
        public const string GR = @"GR";
        public const string GS = @"GS";
        public const string GT = @"GT";
        public const string GU = @"GU";
        public const string GW = @"GW";
        public const string GY = @"GY";
        public const string HK = @"HK";
        public const string HM = @"HM";
        public const string HN = @"HN";
        public const string HR = @"HR";
        public const string HT = @"HT";
        public const string HU = @"HU";
        public const string ID = @"ID";
        public const string IE = @"IE";
        public const string IL = @"IL";
        public const string IM = @"IM";
        public const string IN = @"IN";
        public const string IO = @"IO";
        public const string IQ = @"IQ";
        public const string IR = @"IR";
        public const string IS = @"IS";
        public const string IT = @"IT";
        public const string JE = @"JE";
        public const string JM = @"JM";
        public const string JO = @"JO";
        public const string JP = @"JP";
        public const string KE = @"KE";
        public const string KG = @"KG";
        public const string KH = @"KH";
        public const string KI = @"KI";
        public const string KM = @"KM";
        public const string KN = @"KN";
        public const string KP = @"KP";
        public const string KR = @"KR";
        public const string KW = @"KW";
        public const string KY = @"KY";
        public const string KZ = @"KZ";
        public const string LA = @"LA";
        public const string LB = @"LB";
        public const string LC = @"LC";
        public const string LI = @"LI";
        public const string LK = @"LK";
        public const string LR = @"LR";
        public const string LS = @"LS";
        public const string LT = @"LT";
        public const string LU = @"LU";
        public const string LV = @"LV";
        public const string LY = @"LY";
        public const string MA = @"MA";
        public const string MC = @"MC";
        public const string MD = @"MD";
        public const string ME = @"ME";
        public const string MF = @"MF";
        public const string MG = @"MG";
        public const string MH = @"MH";
        public const string MK = @"MK";
        public const string ML = @"ML";
        public const string MM = @"MM";
        public const string MN = @"MN";
        public const string MO = @"MO";
        public const string MP = @"MP";
        public const string MQ = @"MQ";
        public const string MR = @"MR";
        public const string MS = @"MS";
        public const string MT = @"MT";
        public const string MU = @"MU";
        public const string MV = @"MV";
        public const string MW = @"MW";
        public const string MX = @"MX";
        public const string MY = @"MY";
        public const string MZ = @"MZ";
        public const string NA = @"NA";
        public const string NC = @"NC";
        public const string NE = @"NE";
        public const string NF = @"NF";
        public const string NG = @"NG";
        public const string NI = @"NI";
        public const string NL = @"NL";
        public const string NO = @"NO";
        public const string NP = @"NP";
        public const string NR = @"NR";
        public const string NU = @"NU";
        public const string NZ = @"NZ";
        public const string OM = @"OM";
        public const string PA = @"PA";
        public const string PE = @"PE";
        public const string PF = @"PF";
        public const string PG = @"PG";
        public const string PH = @"PH";
        public const string PK = @"PK";
        public const string PL = @"PL";
        public const string PM = @"PM";
        public const string PN = @"PN";
        public const string PR = @"PR";
        public const string PS = @"PS";
        public const string PT = @"PT";
        public const string PW = @"PW";
        public const string PY = @"PY";
        public const string QA = @"QA";
        public const string RE = @"RE";
        public const string RO = @"RO";
        public const string RS = @"RS";
        public const string RU = @"RU";
        public const string RW = @"RW";
        public const string SA = @"SA";
        public const string SB = @"SB";
        public const string SC = @"SC";
        public const string SD = @"SD";
        public const string SE = @"SE";
        public const string SG = @"SG";
        public const string SH = @"SH";
        public const string SI = @"SI";
        public const string SJ = @"SJ";
        public const string SK = @"SK";
        public const string SL = @"SL";
        public const string SM = @"SM";
        public const string SN = @"SN";
        public const string SO = @"SO";
        public const string SR = @"SR";
        public const string SS = @"SS";
        public const string ST = @"ST";
        public const string SV = @"SV";
        public const string SX = @"SX";
        public const string SY = @"SY";
        public const string SZ = @"SZ";
        public const string TC = @"TC";
        public const string TD = @"TD";
        public const string TF = @"TF";
        public const string TG = @"TG";
        public const string TH = @"TH";
        public const string TJ = @"TJ";
        public const string TK = @"TK";
        public const string TL = @"TL";
        public const string TM = @"TM";
        public const string TN = @"TN";
        public const string TO = @"TO";
        public const string TR = @"TR";
        public const string TT = @"TT";
        public const string TV = @"TV";
        public const string TW = @"TW";
        public const string TZ = @"TZ";
        public const string UA = @"UA";
        public const string UG = @"UG";
        public const string UM = @"UM";
        public const string US = @"US";
        public const string UY = @"UY";
        public const string UZ = @"UZ";
        public const string VA = @"VA";
        public const string VC = @"VC";
        public const string VE = @"VE";
        public const string VG = @"VG";
        public const string VI = @"VI";
        public const string VN = @"VN";
        public const string VU = @"VU";
        public const string WF = @"WF";
        public const string WS = @"WS";
        public const string YE = @"YE";
        public const string YT = @"YT";
        public const string ZA = @"ZA";
        public const string ZM = @"ZM";
        public const string ZW = @"ZW";
        public const string ZZ = @"ZZ";
    }

    ///<summary>
    ///Indicates the country associated with another entity, such as a business.
    ///Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
    ///</summary>
    [Description("Indicates the country associated with another entity, such as a business.\nValues are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).")]
    public enum CountryCode
    {
        ///<summary>
        ///Andorra
        ///</summary>
        [Description("Andorra")]
        AD,
        ///<summary>
        ///United Arab Emirates
        ///</summary>
        [Description("United Arab Emirates")]
        AE,
        ///<summary>
        ///Afghanistan
        ///</summary>
        [Description("Afghanistan")]
        AF,
        ///<summary>
        ///Antigua and Barbuda
        ///</summary>
        [Description("Antigua and Barbuda")]
        AG,
        ///<summary>
        ///Anguilla
        ///</summary>
        [Description("Anguilla")]
        AI,
        ///<summary>
        ///Albania
        ///</summary>
        [Description("Albania")]
        AL,
        ///<summary>
        ///Armenia
        ///</summary>
        [Description("Armenia")]
        AM,
        ///<summary>
        ///Angola
        ///</summary>
        [Description("Angola")]
        AO,
        ///<summary>
        ///Antartica
        ///</summary>
        [Description("Antartica")]
        AQ,
        ///<summary>
        ///Argentina
        ///</summary>
        [Description("Argentina")]
        AR,
        ///<summary>
        ///American Samoa
        ///</summary>
        [Description("American Samoa")]
        AS,
        ///<summary>
        ///Austria
        ///</summary>
        [Description("Austria")]
        AT,
        ///<summary>
        ///Australia
        ///</summary>
        [Description("Australia")]
        AU,
        ///<summary>
        ///Aruba
        ///</summary>
        [Description("Aruba")]
        AW,
        ///<summary>
        ///Åland Islands
        ///</summary>
        [Description("Åland Islands")]
        AX,
        ///<summary>
        ///Azerbaijan
        ///</summary>
        [Description("Azerbaijan")]
        AZ,
        ///<summary>
        ///Bosnia and Herzegovina
        ///</summary>
        [Description("Bosnia and Herzegovina")]
        BA,
        ///<summary>
        ///Barbados
        ///</summary>
        [Description("Barbados")]
        BB,
        ///<summary>
        ///Bangladesh
        ///</summary>
        [Description("Bangladesh")]
        BD,
        ///<summary>
        ///Belgium
        ///</summary>
        [Description("Belgium")]
        BE,
        ///<summary>
        ///Burkina Faso
        ///</summary>
        [Description("Burkina Faso")]
        BF,
        ///<summary>
        ///Bulgaria
        ///</summary>
        [Description("Bulgaria")]
        BG,
        ///<summary>
        ///Bahrain
        ///</summary>
        [Description("Bahrain")]
        BH,
        ///<summary>
        ///Burundi
        ///</summary>
        [Description("Burundi")]
        BI,
        ///<summary>
        ///Benin
        ///</summary>
        [Description("Benin")]
        BJ,
        ///<summary>
        ///Saint Barthélemy
        ///</summary>
        [Description("Saint Barthélemy")]
        BL,
        ///<summary>
        ///Bermuda
        ///</summary>
        [Description("Bermuda")]
        BM,
        ///<summary>
        ///Brunei
        ///</summary>
        [Description("Brunei")]
        BN,
        ///<summary>
        ///Bolivia
        ///</summary>
        [Description("Bolivia")]
        BO,
        ///<summary>
        ///Bonaire
        ///</summary>
        [Description("Bonaire")]
        BQ,
        ///<summary>
        ///Brazil
        ///</summary>
        [Description("Brazil")]
        BR,
        ///<summary>
        ///Bahamas
        ///</summary>
        [Description("Bahamas")]
        BS,
        ///<summary>
        ///Bhutan
        ///</summary>
        [Description("Bhutan")]
        BT,
        ///<summary>
        ///Bouvet Island
        ///</summary>
        [Description("Bouvet Island")]
        BV,
        ///<summary>
        ///Botswana
        ///</summary>
        [Description("Botswana")]
        BW,
        ///<summary>
        ///Belarus
        ///</summary>
        [Description("Belarus")]
        BY,
        ///<summary>
        ///Belize
        ///</summary>
        [Description("Belize")]
        BZ,
        ///<summary>
        ///Canada
        ///</summary>
        [Description("Canada")]
        CA,
        ///<summary>
        ///Cocos Islands
        ///</summary>
        [Description("Cocos Islands")]
        CC,
        ///<summary>
        ///Democratic Republic of the Congo
        ///</summary>
        [Description("Democratic Republic of the Congo")]
        CD,
        ///<summary>
        ///Central African Republic
        ///</summary>
        [Description("Central African Republic")]
        CF,
        ///<summary>
        ///Congo
        ///</summary>
        [Description("Congo")]
        CG,
        ///<summary>
        ///Switzerland
        ///</summary>
        [Description("Switzerland")]
        CH,
        ///<summary>
        ///Ivory Coast
        ///</summary>
        [Description("Ivory Coast")]
        CI,
        ///<summary>
        ///Cook Islands
        ///</summary>
        [Description("Cook Islands")]
        CK,
        ///<summary>
        ///Chile
        ///</summary>
        [Description("Chile")]
        CL,
        ///<summary>
        ///Cameroon
        ///</summary>
        [Description("Cameroon")]
        CM,
        ///<summary>
        ///China
        ///</summary>
        [Description("China")]
        CN,
        ///<summary>
        ///Colombia
        ///</summary>
        [Description("Colombia")]
        CO,
        ///<summary>
        ///Costa Rica
        ///</summary>
        [Description("Costa Rica")]
        CR,
        ///<summary>
        ///Cuba
        ///</summary>
        [Description("Cuba")]
        CU,
        ///<summary>
        ///Cabo Verde
        ///</summary>
        [Description("Cabo Verde")]
        CV,
        ///<summary>
        ///Curaçao
        ///</summary>
        [Description("Curaçao")]
        CW,
        ///<summary>
        ///Christmas Island
        ///</summary>
        [Description("Christmas Island")]
        CX,
        ///<summary>
        ///Cyprus
        ///</summary>
        [Description("Cyprus")]
        CY,
        ///<summary>
        ///Czechia
        ///</summary>
        [Description("Czechia")]
        CZ,
        ///<summary>
        ///Germany
        ///</summary>
        [Description("Germany")]
        DE,
        ///<summary>
        ///Djibouti
        ///</summary>
        [Description("Djibouti")]
        DJ,
        ///<summary>
        ///Denmark
        ///</summary>
        [Description("Denmark")]
        DK,
        ///<summary>
        ///Dominica
        ///</summary>
        [Description("Dominica")]
        DM,
        ///<summary>
        ///Dominican Republic
        ///</summary>
        [Description("Dominican Republic")]
        DO,
        ///<summary>
        ///Algeria
        ///</summary>
        [Description("Algeria")]
        DZ,
        ///<summary>
        ///Ecuador
        ///</summary>
        [Description("Ecuador")]
        EC,
        ///<summary>
        ///Estonia
        ///</summary>
        [Description("Estonia")]
        EE,
        ///<summary>
        ///Egypt
        ///</summary>
        [Description("Egypt")]
        EG,
        ///<summary>
        ///Western Sahara
        ///</summary>
        [Description("Western Sahara")]
        EH,
        ///<summary>
        ///Eritrea
        ///</summary>
        [Description("Eritrea")]
        ER,
        ///<summary>
        ///Spain
        ///</summary>
        [Description("Spain")]
        ES,
        ///<summary>
        ///Ethiopia
        ///</summary>
        [Description("Ethiopia")]
        ET,
        ///<summary>
        ///Finland
        ///</summary>
        [Description("Finland")]
        FI,
        ///<summary>
        ///Fiji
        ///</summary>
        [Description("Fiji")]
        FJ,
        ///<summary>
        ///Falkland Islands
        ///</summary>
        [Description("Falkland Islands")]
        FK,
        ///<summary>
        ///Federated States of Micronesia
        ///</summary>
        [Description("Federated States of Micronesia")]
        FM,
        ///<summary>
        ///Faroe Islands
        ///</summary>
        [Description("Faroe Islands")]
        FO,
        ///<summary>
        ///France
        ///</summary>
        [Description("France")]
        FR,
        ///<summary>
        ///Gabon
        ///</summary>
        [Description("Gabon")]
        GA,
        ///<summary>
        ///United Kingdom
        ///</summary>
        [Description("United Kingdom")]
        GB,
        ///<summary>
        ///Grenada
        ///</summary>
        [Description("Grenada")]
        GD,
        ///<summary>
        ///Georgia
        ///</summary>
        [Description("Georgia")]
        GE,
        ///<summary>
        ///French Guiana
        ///</summary>
        [Description("French Guiana")]
        GF,
        ///<summary>
        ///Guernsey
        ///</summary>
        [Description("Guernsey")]
        GG,
        ///<summary>
        ///Ghana
        ///</summary>
        [Description("Ghana")]
        GH,
        ///<summary>
        ///Gibraltar
        ///</summary>
        [Description("Gibraltar")]
        GI,
        ///<summary>
        ///Greenland
        ///</summary>
        [Description("Greenland")]
        GL,
        ///<summary>
        ///Gambia
        ///</summary>
        [Description("Gambia")]
        GM,
        ///<summary>
        ///Guinea
        ///</summary>
        [Description("Guinea")]
        GN,
        ///<summary>
        ///Guadeloupe
        ///</summary>
        [Description("Guadeloupe")]
        GP,
        ///<summary>
        ///Equatorial Guinea
        ///</summary>
        [Description("Equatorial Guinea")]
        GQ,
        ///<summary>
        ///Greece
        ///</summary>
        [Description("Greece")]
        GR,
        ///<summary>
        ///South Georgia and the South Sandwich Islands
        ///</summary>
        [Description("South Georgia and the South Sandwich Islands")]
        GS,
        ///<summary>
        ///Guatemala
        ///</summary>
        [Description("Guatemala")]
        GT,
        ///<summary>
        ///Guam
        ///</summary>
        [Description("Guam")]
        GU,
        ///<summary>
        ///Guinea-Bissau
        ///</summary>
        [Description("Guinea-Bissau")]
        GW,
        ///<summary>
        ///Guyana
        ///</summary>
        [Description("Guyana")]
        GY,
        ///<summary>
        ///Hong Kong
        ///</summary>
        [Description("Hong Kong")]
        HK,
        ///<summary>
        ///Heard Island and McDonald Islands
        ///</summary>
        [Description("Heard Island and McDonald Islands")]
        HM,
        ///<summary>
        ///Honduras
        ///</summary>
        [Description("Honduras")]
        HN,
        ///<summary>
        ///Croatia
        ///</summary>
        [Description("Croatia")]
        HR,
        ///<summary>
        ///Haiti
        ///</summary>
        [Description("Haiti")]
        HT,
        ///<summary>
        ///Hungary
        ///</summary>
        [Description("Hungary")]
        HU,
        ///<summary>
        ///Indonesia
        ///</summary>
        [Description("Indonesia")]
        ID,
        ///<summary>
        ///Ireland
        ///</summary>
        [Description("Ireland")]
        IE,
        ///<summary>
        ///Israel
        ///</summary>
        [Description("Israel")]
        IL,
        ///<summary>
        ///Isle of Man
        ///</summary>
        [Description("Isle of Man")]
        IM,
        ///<summary>
        ///India
        ///</summary>
        [Description("India")]
        IN,
        ///<summary>
        ///British Indian Ocean Territory
        ///</summary>
        [Description("British Indian Ocean Territory")]
        IO,
        ///<summary>
        ///Iraq
        ///</summary>
        [Description("Iraq")]
        IQ,
        ///<summary>
        ///Iran
        ///</summary>
        [Description("Iran")]
        IR,
        ///<summary>
        ///Iceland
        ///</summary>
        [Description("Iceland")]
        IS,
        ///<summary>
        ///Italy
        ///</summary>
        [Description("Italy")]
        IT,
        ///<summary>
        ///Jersey
        ///</summary>
        [Description("Jersey")]
        JE,
        ///<summary>
        ///Jamaica
        ///</summary>
        [Description("Jamaica")]
        JM,
        ///<summary>
        ///Jordan
        ///</summary>
        [Description("Jordan")]
        JO,
        ///<summary>
        ///Japan
        ///</summary>
        [Description("Japan")]
        JP,
        ///<summary>
        ///Kenya
        ///</summary>
        [Description("Kenya")]
        KE,
        ///<summary>
        ///Kyrgyzstan
        ///</summary>
        [Description("Kyrgyzstan")]
        KG,
        ///<summary>
        ///Cambodia
        ///</summary>
        [Description("Cambodia")]
        KH,
        ///<summary>
        ///Kiribati
        ///</summary>
        [Description("Kiribati")]
        KI,
        ///<summary>
        ///Comoros
        ///</summary>
        [Description("Comoros")]
        KM,
        ///<summary>
        ///Saint Kitts and Nevis
        ///</summary>
        [Description("Saint Kitts and Nevis")]
        KN,
        ///<summary>
        ///Democratic People's Republic of Korea
        ///</summary>
        [Description("Democratic People's Republic of Korea")]
        KP,
        ///<summary>
        ///Republic of Korea
        ///</summary>
        [Description("Republic of Korea")]
        KR,
        ///<summary>
        ///Kuwait
        ///</summary>
        [Description("Kuwait")]
        KW,
        ///<summary>
        ///Cayman Islands
        ///</summary>
        [Description("Cayman Islands")]
        KY,
        ///<summary>
        ///Kazakhstan
        ///</summary>
        [Description("Kazakhstan")]
        KZ,
        ///<summary>
        ///Lao People's Democratic Republic
        ///</summary>
        [Description("Lao People's Democratic Republic")]
        LA,
        ///<summary>
        ///Lebanon
        ///</summary>
        [Description("Lebanon")]
        LB,
        ///<summary>
        ///Saint Lucia
        ///</summary>
        [Description("Saint Lucia")]
        LC,
        ///<summary>
        ///Liechtenstein
        ///</summary>
        [Description("Liechtenstein")]
        LI,
        ///<summary>
        ///Sri Lanka
        ///</summary>
        [Description("Sri Lanka")]
        LK,
        ///<summary>
        ///Liberia
        ///</summary>
        [Description("Liberia")]
        LR,
        ///<summary>
        ///Lesotho
        ///</summary>
        [Description("Lesotho")]
        LS,
        ///<summary>
        ///Lithuania
        ///</summary>
        [Description("Lithuania")]
        LT,
        ///<summary>
        ///Luxembourg
        ///</summary>
        [Description("Luxembourg")]
        LU,
        ///<summary>
        ///Latvia
        ///</summary>
        [Description("Latvia")]
        LV,
        ///<summary>
        ///Libya
        ///</summary>
        [Description("Libya")]
        LY,
        ///<summary>
        ///Morocco
        ///</summary>
        [Description("Morocco")]
        MA,
        ///<summary>
        ///Monaco
        ///</summary>
        [Description("Monaco")]
        MC,
        ///<summary>
        ///Moldova
        ///</summary>
        [Description("Moldova")]
        MD,
        ///<summary>
        ///Montenegro
        ///</summary>
        [Description("Montenegro")]
        ME,
        ///<summary>
        ///Saint Martin
        ///</summary>
        [Description("Saint Martin")]
        MF,
        ///<summary>
        ///Madagascar
        ///</summary>
        [Description("Madagascar")]
        MG,
        ///<summary>
        ///Marshall Islands
        ///</summary>
        [Description("Marshall Islands")]
        MH,
        ///<summary>
        ///North Macedonia
        ///</summary>
        [Description("North Macedonia")]
        MK,
        ///<summary>
        ///Mali
        ///</summary>
        [Description("Mali")]
        ML,
        ///<summary>
        ///Myanmar
        ///</summary>
        [Description("Myanmar")]
        MM,
        ///<summary>
        ///Mongolia
        ///</summary>
        [Description("Mongolia")]
        MN,
        ///<summary>
        ///Macao
        ///</summary>
        [Description("Macao")]
        MO,
        ///<summary>
        ///Northern Mariana Islands
        ///</summary>
        [Description("Northern Mariana Islands")]
        MP,
        ///<summary>
        ///Martinique
        ///</summary>
        [Description("Martinique")]
        MQ,
        ///<summary>
        ///Mauritania
        ///</summary>
        [Description("Mauritania")]
        MR,
        ///<summary>
        ///Montserrat
        ///</summary>
        [Description("Montserrat")]
        MS,
        ///<summary>
        ///Malta
        ///</summary>
        [Description("Malta")]
        MT,
        ///<summary>
        ///Mauritius
        ///</summary>
        [Description("Mauritius")]
        MU,
        ///<summary>
        ///Maldives
        ///</summary>
        [Description("Maldives")]
        MV,
        ///<summary>
        ///Malawi
        ///</summary>
        [Description("Malawi")]
        MW,
        ///<summary>
        ///Mexico
        ///</summary>
        [Description("Mexico")]
        MX,
        ///<summary>
        ///Malaysia
        ///</summary>
        [Description("Malaysia")]
        MY,
        ///<summary>
        ///Mozambique
        ///</summary>
        [Description("Mozambique")]
        MZ,
        ///<summary>
        ///Namibia
        ///</summary>
        [Description("Namibia")]
        NA,
        ///<summary>
        ///New Caledonia
        ///</summary>
        [Description("New Caledonia")]
        NC,
        ///<summary>
        ///Niger
        ///</summary>
        [Description("Niger")]
        NE,
        ///<summary>
        ///Norfolk Island
        ///</summary>
        [Description("Norfolk Island")]
        NF,
        ///<summary>
        ///Nigeria
        ///</summary>
        [Description("Nigeria")]
        NG,
        ///<summary>
        ///Nicaragua
        ///</summary>
        [Description("Nicaragua")]
        NI,
        ///<summary>
        ///Netherlands
        ///</summary>
        [Description("Netherlands")]
        NL,
        ///<summary>
        ///Norway
        ///</summary>
        [Description("Norway")]
        NO,
        ///<summary>
        ///Nepal
        ///</summary>
        [Description("Nepal")]
        NP,
        ///<summary>
        ///Nauru
        ///</summary>
        [Description("Nauru")]
        NR,
        ///<summary>
        ///Niue
        ///</summary>
        [Description("Niue")]
        NU,
        ///<summary>
        ///New Zealand
        ///</summary>
        [Description("New Zealand")]
        NZ,
        ///<summary>
        ///Oman
        ///</summary>
        [Description("Oman")]
        OM,
        ///<summary>
        ///Panama
        ///</summary>
        [Description("Panama")]
        PA,
        ///<summary>
        ///Peru
        ///</summary>
        [Description("Peru")]
        PE,
        ///<summary>
        ///French Polynesia
        ///</summary>
        [Description("French Polynesia")]
        PF,
        ///<summary>
        ///Papua New Guinea
        ///</summary>
        [Description("Papua New Guinea")]
        PG,
        ///<summary>
        ///Philippines
        ///</summary>
        [Description("Philippines")]
        PH,
        ///<summary>
        ///Pakistan
        ///</summary>
        [Description("Pakistan")]
        PK,
        ///<summary>
        ///Poland
        ///</summary>
        [Description("Poland")]
        PL,
        ///<summary>
        ///Saint Pierre and Miquelon
        ///</summary>
        [Description("Saint Pierre and Miquelon")]
        PM,
        ///<summary>
        ///Pitcairn
        ///</summary>
        [Description("Pitcairn")]
        PN,
        ///<summary>
        ///Puerto Rico
        ///</summary>
        [Description("Puerto Rico")]
        PR,
        ///<summary>
        ///Palestine
        ///</summary>
        [Description("Palestine")]
        PS,
        ///<summary>
        ///Portugal
        ///</summary>
        [Description("Portugal")]
        PT,
        ///<summary>
        ///Palau
        ///</summary>
        [Description("Palau")]
        PW,
        ///<summary>
        ///Paraguay
        ///</summary>
        [Description("Paraguay")]
        PY,
        ///<summary>
        ///Qatar
        ///</summary>
        [Description("Qatar")]
        QA,
        ///<summary>
        ///Réunion
        ///</summary>
        [Description("Réunion")]
        RE,
        ///<summary>
        ///Romania
        ///</summary>
        [Description("Romania")]
        RO,
        ///<summary>
        ///Serbia
        ///</summary>
        [Description("Serbia")]
        RS,
        ///<summary>
        ///Russia
        ///</summary>
        [Description("Russia")]
        RU,
        ///<summary>
        ///Rwanda
        ///</summary>
        [Description("Rwanda")]
        RW,
        ///<summary>
        ///Saudi Arabia
        ///</summary>
        [Description("Saudi Arabia")]
        SA,
        ///<summary>
        ///Solomon Islands
        ///</summary>
        [Description("Solomon Islands")]
        SB,
        ///<summary>
        ///Seychelles
        ///</summary>
        [Description("Seychelles")]
        SC,
        ///<summary>
        ///Sudan
        ///</summary>
        [Description("Sudan")]
        SD,
        ///<summary>
        ///Sweden
        ///</summary>
        [Description("Sweden")]
        SE,
        ///<summary>
        ///Singapore
        ///</summary>
        [Description("Singapore")]
        SG,
        ///<summary>
        ///Saint Helena, Ascension and Tristan da Cunha
        ///</summary>
        [Description("Saint Helena, Ascension and Tristan da Cunha")]
        SH,
        ///<summary>
        ///Slovenia
        ///</summary>
        [Description("Slovenia")]
        SI,
        ///<summary>
        ///Svalbard and Jan Mayen
        ///</summary>
        [Description("Svalbard and Jan Mayen")]
        SJ,
        ///<summary>
        ///Slovakia
        ///</summary>
        [Description("Slovakia")]
        SK,
        ///<summary>
        ///Sierra Leone
        ///</summary>
        [Description("Sierra Leone")]
        SL,
        ///<summary>
        ///San Marino
        ///</summary>
        [Description("San Marino")]
        SM,
        ///<summary>
        ///Senegal
        ///</summary>
        [Description("Senegal")]
        SN,
        ///<summary>
        ///Somalia
        ///</summary>
        [Description("Somalia")]
        SO,
        ///<summary>
        ///Suriname
        ///</summary>
        [Description("Suriname")]
        SR,
        ///<summary>
        ///South Sudan
        ///</summary>
        [Description("South Sudan")]
        SS,
        ///<summary>
        ///Sao Tome and Principe
        ///</summary>
        [Description("Sao Tome and Principe")]
        ST,
        ///<summary>
        ///El Salvador
        ///</summary>
        [Description("El Salvador")]
        SV,
        ///<summary>
        ///Sint Maarten
        ///</summary>
        [Description("Sint Maarten")]
        SX,
        ///<summary>
        ///Syrian Arab Republic
        ///</summary>
        [Description("Syrian Arab Republic")]
        SY,
        ///<summary>
        ///Eswatini
        ///</summary>
        [Description("Eswatini")]
        SZ,
        ///<summary>
        ///Turks and Caicos Islands
        ///</summary>
        [Description("Turks and Caicos Islands")]
        TC,
        ///<summary>
        ///Chad
        ///</summary>
        [Description("Chad")]
        TD,
        ///<summary>
        ///French Southern Territories
        ///</summary>
        [Description("French Southern Territories")]
        TF,
        ///<summary>
        ///Togo
        ///</summary>
        [Description("Togo")]
        TG,
        ///<summary>
        ///Thailand
        ///</summary>
        [Description("Thailand")]
        TH,
        ///<summary>
        ///Tajikistan
        ///</summary>
        [Description("Tajikistan")]
        TJ,
        ///<summary>
        ///Tokelau
        ///</summary>
        [Description("Tokelau")]
        TK,
        ///<summary>
        ///Timor-Leste
        ///</summary>
        [Description("Timor-Leste")]
        TL,
        ///<summary>
        ///Turkmenistan
        ///</summary>
        [Description("Turkmenistan")]
        TM,
        ///<summary>
        ///Tunisia
        ///</summary>
        [Description("Tunisia")]
        TN,
        ///<summary>
        ///Tonga
        ///</summary>
        [Description("Tonga")]
        TO,
        ///<summary>
        ///Turkey
        ///</summary>
        [Description("Turkey")]
        TR,
        ///<summary>
        ///Trinidad and Tobago
        ///</summary>
        [Description("Trinidad and Tobago")]
        TT,
        ///<summary>
        ///Tuvalu
        ///</summary>
        [Description("Tuvalu")]
        TV,
        ///<summary>
        ///Taiwan
        ///</summary>
        [Description("Taiwan")]
        TW,
        ///<summary>
        ///Tanzania
        ///</summary>
        [Description("Tanzania")]
        TZ,
        ///<summary>
        ///Ukraine
        ///</summary>
        [Description("Ukraine")]
        UA,
        ///<summary>
        ///Uganda
        ///</summary>
        [Description("Uganda")]
        UG,
        ///<summary>
        ///United States Minor Outlying Islands
        ///</summary>
        [Description("United States Minor Outlying Islands")]
        UM,
        ///<summary>
        ///United States of America
        ///</summary>
        [Description("United States of America")]
        US,
        ///<summary>
        ///Uruguay
        ///</summary>
        [Description("Uruguay")]
        UY,
        ///<summary>
        ///Uzbekistan
        ///</summary>
        [Description("Uzbekistan")]
        UZ,
        ///<summary>
        ///Vatican City
        ///</summary>
        [Description("Vatican City")]
        VA,
        ///<summary>
        ///Saint Vincent and the Grenadines
        ///</summary>
        [Description("Saint Vincent and the Grenadines")]
        VC,
        ///<summary>
        ///Venezuela
        ///</summary>
        [Description("Venezuela")]
        VE,
        ///<summary>
        ///British Virgin Islands
        ///</summary>
        [Description("British Virgin Islands")]
        VG,
        ///<summary>
        ///U.S. Virgin Islands
        ///</summary>
        [Description("U.S. Virgin Islands")]
        VI,
        ///<summary>
        ///Vietnam
        ///</summary>
        [Description("Vietnam")]
        VN,
        ///<summary>
        ///Vanuatu
        ///</summary>
        [Description("Vanuatu")]
        VU,
        ///<summary>
        ///Wallis and Futuna
        ///</summary>
        [Description("Wallis and Futuna")]
        WF,
        ///<summary>
        ///Samoa
        ///</summary>
        [Description("Samoa")]
        WS,
        ///<summary>
        ///Test country.
        ///</summary>
        [Description("Test country.")]
        XT,
        ///<summary>
        ///Yemen
        ///</summary>
        [Description("Yemen")]
        YE,
        ///<summary>
        ///Mayotte
        ///</summary>
        [Description("Mayotte")]
        YT,
        ///<summary>
        ///South Africa
        ///</summary>
        [Description("South Africa")]
        ZA,
        ///<summary>
        ///Zambia
        ///</summary>
        [Description("Zambia")]
        ZM,
        ///<summary>
        ///Zimbabwe
        ///</summary>
        [Description("Zimbabwe")]
        ZW,
        ///<summary>
        ///Unknown
        ///</summary>
        [Description("Unknown")]
        ZZ,
    }

    public static class CountryCodeStringValues
    {
        public const string AD = @"AD";
        public const string AE = @"AE";
        public const string AF = @"AF";
        public const string AG = @"AG";
        public const string AI = @"AI";
        public const string AL = @"AL";
        public const string AM = @"AM";
        public const string AO = @"AO";
        public const string AQ = @"AQ";
        public const string AR = @"AR";
        public const string AS = @"AS";
        public const string AT = @"AT";
        public const string AU = @"AU";
        public const string AW = @"AW";
        public const string AX = @"AX";
        public const string AZ = @"AZ";
        public const string BA = @"BA";
        public const string BB = @"BB";
        public const string BD = @"BD";
        public const string BE = @"BE";
        public const string BF = @"BF";
        public const string BG = @"BG";
        public const string BH = @"BH";
        public const string BI = @"BI";
        public const string BJ = @"BJ";
        public const string BL = @"BL";
        public const string BM = @"BM";
        public const string BN = @"BN";
        public const string BO = @"BO";
        public const string BQ = @"BQ";
        public const string BR = @"BR";
        public const string BS = @"BS";
        public const string BT = @"BT";
        public const string BV = @"BV";
        public const string BW = @"BW";
        public const string BY = @"BY";
        public const string BZ = @"BZ";
        public const string CA = @"CA";
        public const string CC = @"CC";
        public const string CD = @"CD";
        public const string CF = @"CF";
        public const string CG = @"CG";
        public const string CH = @"CH";
        public const string CI = @"CI";
        public const string CK = @"CK";
        public const string CL = @"CL";
        public const string CM = @"CM";
        public const string CN = @"CN";
        public const string CO = @"CO";
        public const string CR = @"CR";
        public const string CU = @"CU";
        public const string CV = @"CV";
        public const string CW = @"CW";
        public const string CX = @"CX";
        public const string CY = @"CY";
        public const string CZ = @"CZ";
        public const string DE = @"DE";
        public const string DJ = @"DJ";
        public const string DK = @"DK";
        public const string DM = @"DM";
        public const string DO = @"DO";
        public const string DZ = @"DZ";
        public const string EC = @"EC";
        public const string EE = @"EE";
        public const string EG = @"EG";
        public const string EH = @"EH";
        public const string ER = @"ER";
        public const string ES = @"ES";
        public const string ET = @"ET";
        public const string FI = @"FI";
        public const string FJ = @"FJ";
        public const string FK = @"FK";
        public const string FM = @"FM";
        public const string FO = @"FO";
        public const string FR = @"FR";
        public const string GA = @"GA";
        public const string GB = @"GB";
        public const string GD = @"GD";
        public const string GE = @"GE";
        public const string GF = @"GF";
        public const string GG = @"GG";
        public const string GH = @"GH";
        public const string GI = @"GI";
        public const string GL = @"GL";
        public const string GM = @"GM";
        public const string GN = @"GN";
        public const string GP = @"GP";
        public const string GQ = @"GQ";
        public const string GR = @"GR";
        public const string GS = @"GS";
        public const string GT = @"GT";
        public const string GU = @"GU";
        public const string GW = @"GW";
        public const string GY = @"GY";
        public const string HK = @"HK";
        public const string HM = @"HM";
        public const string HN = @"HN";
        public const string HR = @"HR";
        public const string HT = @"HT";
        public const string HU = @"HU";
        public const string ID = @"ID";
        public const string IE = @"IE";
        public const string IL = @"IL";
        public const string IM = @"IM";
        public const string IN = @"IN";
        public const string IO = @"IO";
        public const string IQ = @"IQ";
        public const string IR = @"IR";
        public const string IS = @"IS";
        public const string IT = @"IT";
        public const string JE = @"JE";
        public const string JM = @"JM";
        public const string JO = @"JO";
        public const string JP = @"JP";
        public const string KE = @"KE";
        public const string KG = @"KG";
        public const string KH = @"KH";
        public const string KI = @"KI";
        public const string KM = @"KM";
        public const string KN = @"KN";
        public const string KP = @"KP";
        public const string KR = @"KR";
        public const string KW = @"KW";
        public const string KY = @"KY";
        public const string KZ = @"KZ";
        public const string LA = @"LA";
        public const string LB = @"LB";
        public const string LC = @"LC";
        public const string LI = @"LI";
        public const string LK = @"LK";
        public const string LR = @"LR";
        public const string LS = @"LS";
        public const string LT = @"LT";
        public const string LU = @"LU";
        public const string LV = @"LV";
        public const string LY = @"LY";
        public const string MA = @"MA";
        public const string MC = @"MC";
        public const string MD = @"MD";
        public const string ME = @"ME";
        public const string MF = @"MF";
        public const string MG = @"MG";
        public const string MH = @"MH";
        public const string MK = @"MK";
        public const string ML = @"ML";
        public const string MM = @"MM";
        public const string MN = @"MN";
        public const string MO = @"MO";
        public const string MP = @"MP";
        public const string MQ = @"MQ";
        public const string MR = @"MR";
        public const string MS = @"MS";
        public const string MT = @"MT";
        public const string MU = @"MU";
        public const string MV = @"MV";
        public const string MW = @"MW";
        public const string MX = @"MX";
        public const string MY = @"MY";
        public const string MZ = @"MZ";
        public const string NA = @"NA";
        public const string NC = @"NC";
        public const string NE = @"NE";
        public const string NF = @"NF";
        public const string NG = @"NG";
        public const string NI = @"NI";
        public const string NL = @"NL";
        public const string NO = @"NO";
        public const string NP = @"NP";
        public const string NR = @"NR";
        public const string NU = @"NU";
        public const string NZ = @"NZ";
        public const string OM = @"OM";
        public const string PA = @"PA";
        public const string PE = @"PE";
        public const string PF = @"PF";
        public const string PG = @"PG";
        public const string PH = @"PH";
        public const string PK = @"PK";
        public const string PL = @"PL";
        public const string PM = @"PM";
        public const string PN = @"PN";
        public const string PR = @"PR";
        public const string PS = @"PS";
        public const string PT = @"PT";
        public const string PW = @"PW";
        public const string PY = @"PY";
        public const string QA = @"QA";
        public const string RE = @"RE";
        public const string RO = @"RO";
        public const string RS = @"RS";
        public const string RU = @"RU";
        public const string RW = @"RW";
        public const string SA = @"SA";
        public const string SB = @"SB";
        public const string SC = @"SC";
        public const string SD = @"SD";
        public const string SE = @"SE";
        public const string SG = @"SG";
        public const string SH = @"SH";
        public const string SI = @"SI";
        public const string SJ = @"SJ";
        public const string SK = @"SK";
        public const string SL = @"SL";
        public const string SM = @"SM";
        public const string SN = @"SN";
        public const string SO = @"SO";
        public const string SR = @"SR";
        public const string SS = @"SS";
        public const string ST = @"ST";
        public const string SV = @"SV";
        public const string SX = @"SX";
        public const string SY = @"SY";
        public const string SZ = @"SZ";
        public const string TC = @"TC";
        public const string TD = @"TD";
        public const string TF = @"TF";
        public const string TG = @"TG";
        public const string TH = @"TH";
        public const string TJ = @"TJ";
        public const string TK = @"TK";
        public const string TL = @"TL";
        public const string TM = @"TM";
        public const string TN = @"TN";
        public const string TO = @"TO";
        public const string TR = @"TR";
        public const string TT = @"TT";
        public const string TV = @"TV";
        public const string TW = @"TW";
        public const string TZ = @"TZ";
        public const string UA = @"UA";
        public const string UG = @"UG";
        public const string UM = @"UM";
        public const string US = @"US";
        public const string UY = @"UY";
        public const string UZ = @"UZ";
        public const string VA = @"VA";
        public const string VC = @"VC";
        public const string VE = @"VE";
        public const string VG = @"VG";
        public const string VI = @"VI";
        public const string VN = @"VN";
        public const string VU = @"VU";
        public const string WF = @"WF";
        public const string WS = @"WS";
        public const string XT = @"XT";
        public const string YE = @"YE";
        public const string YT = @"YT";
        public const string ZA = @"ZA";
        public const string ZM = @"ZM";
        public const string ZW = @"ZW";
        public const string ZZ = @"ZZ";
    }

    ///<summary>
    ///Indicates the associated currency for an amount of money.
    ///
    ///Values correspond to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).
    ///</summary>
    [Description("Indicates the associated currency for an amount of money.\n\nValues correspond to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).")]
    public enum Currency
    {
        ///<summary>
        ///United Arab Emirates dirham
        ///</summary>
        [Description("United Arab Emirates dirham")]
        AED,
        ///<summary>
        ///Afghan afghani
        ///</summary>
        [Description("Afghan afghani")]
        AFN,
        ///<summary>
        ///Albanian lek
        ///</summary>
        [Description("Albanian lek")]
        ALL,
        ///<summary>
        ///Armenian dram
        ///</summary>
        [Description("Armenian dram")]
        AMD,
        ///<summary>
        ///Netherlands Antillean guilder
        ///</summary>
        [Description("Netherlands Antillean guilder")]
        ANG,
        ///<summary>
        ///Angolan kwanza
        ///</summary>
        [Description("Angolan kwanza")]
        AOA,
        ///<summary>
        ///Argentine peso
        ///</summary>
        [Description("Argentine peso")]
        ARS,
        ///<summary>
        ///Australian dollar
        ///</summary>
        [Description("Australian dollar")]
        AUD,
        ///<summary>
        ///Aruban florin
        ///</summary>
        [Description("Aruban florin")]
        AWG,
        ///<summary>
        ///Azerbaijani manat
        ///</summary>
        [Description("Azerbaijani manat")]
        AZN,
        ///<summary>
        ///Bosnia and Herzegovina convertible mark
        ///</summary>
        [Description("Bosnia and Herzegovina convertible mark")]
        BAM,
        ///<summary>
        ///Barbados dollar
        ///</summary>
        [Description("Barbados dollar")]
        BBD,
        ///<summary>
        ///Bangladeshi taka
        ///</summary>
        [Description("Bangladeshi taka")]
        BDT,
        ///<summary>
        ///Bulgarian lev
        ///</summary>
        [Description("Bulgarian lev")]
        BGN,
        ///<summary>
        ///Bahraini dinar
        ///</summary>
        [Description("Bahraini dinar")]
        BHD,
        ///<summary>
        ///Burundian franc
        ///</summary>
        [Description("Burundian franc")]
        BIF,
        ///<summary>
        ///Bermudian dollar
        ///</summary>
        [Description("Bermudian dollar")]
        BMD,
        ///<summary>
        ///Brunei dollar
        ///</summary>
        [Description("Brunei dollar")]
        BND,
        ///<summary>
        ///Boliviano
        ///</summary>
        [Description("Boliviano")]
        BOB,
        ///<summary>
        ///Bolivian Mvdol
        ///</summary>
        [Description("Bolivian Mvdol")]
        BOV,
        ///<summary>
        ///Brazilian real
        ///</summary>
        [Description("Brazilian real")]
        BRL,
        ///<summary>
        ///Bahamian dollar
        ///</summary>
        [Description("Bahamian dollar")]
        BSD,
        ///<summary>
        ///Bitcoin
        ///</summary>
        [Description("Bitcoin")]
        BTC,
        ///<summary>
        ///Bhutanese ngultrum
        ///</summary>
        [Description("Bhutanese ngultrum")]
        BTN,
        ///<summary>
        ///Botswana pula
        ///</summary>
        [Description("Botswana pula")]
        BWP,
        ///<summary>
        ///Belarusian ruble
        ///</summary>
        [Description("Belarusian ruble")]
        BYR,
        ///<summary>
        ///Belize dollar
        ///</summary>
        [Description("Belize dollar")]
        BZD,
        ///<summary>
        ///Canadian dollar
        ///</summary>
        [Description("Canadian dollar")]
        CAD,
        ///<summary>
        ///Congolese franc
        ///</summary>
        [Description("Congolese franc")]
        CDF,
        ///<summary>
        ///WIR Euro
        ///</summary>
        [Description("WIR Euro")]
        CHE,
        ///<summary>
        ///Swiss franc
        ///</summary>
        [Description("Swiss franc")]
        CHF,
        ///<summary>
        ///WIR Franc
        ///</summary>
        [Description("WIR Franc")]
        CHW,
        ///<summary>
        ///Unidad de Fomento
        ///</summary>
        [Description("Unidad de Fomento")]
        CLF,
        ///<summary>
        ///Chilean peso
        ///</summary>
        [Description("Chilean peso")]
        CLP,
        ///<summary>
        ///Chinese yuan
        ///</summary>
        [Description("Chinese yuan")]
        CNY,
        ///<summary>
        ///Colombian peso
        ///</summary>
        [Description("Colombian peso")]
        COP,
        ///<summary>
        ///Unidad de Valor Real
        ///</summary>
        [Description("Unidad de Valor Real")]
        COU,
        ///<summary>
        ///Costa Rican colon
        ///</summary>
        [Description("Costa Rican colon")]
        CRC,
        ///<summary>
        ///Cuban convertible peso
        ///</summary>
        [Description("Cuban convertible peso")]
        CUC,
        ///<summary>
        ///Cuban peso
        ///</summary>
        [Description("Cuban peso")]
        CUP,
        ///<summary>
        ///Cape Verdean escudo
        ///</summary>
        [Description("Cape Verdean escudo")]
        CVE,
        ///<summary>
        ///Czech koruna
        ///</summary>
        [Description("Czech koruna")]
        CZK,
        ///<summary>
        ///Djiboutian franc
        ///</summary>
        [Description("Djiboutian franc")]
        DJF,
        ///<summary>
        ///Danish krone
        ///</summary>
        [Description("Danish krone")]
        DKK,
        ///<summary>
        ///Dominican peso
        ///</summary>
        [Description("Dominican peso")]
        DOP,
        ///<summary>
        ///Algerian dinar
        ///</summary>
        [Description("Algerian dinar")]
        DZD,
        ///<summary>
        ///Egyptian pound
        ///</summary>
        [Description("Egyptian pound")]
        EGP,
        ///<summary>
        ///Eritrean nakfa
        ///</summary>
        [Description("Eritrean nakfa")]
        ERN,
        ///<summary>
        ///Ethiopian birr
        ///</summary>
        [Description("Ethiopian birr")]
        ETB,
        ///<summary>
        ///Euro
        ///</summary>
        [Description("Euro")]
        EUR,
        ///<summary>
        ///Fiji dollar
        ///</summary>
        [Description("Fiji dollar")]
        FJD,
        ///<summary>
        ///Falkland Islands pound
        ///</summary>
        [Description("Falkland Islands pound")]
        FKP,
        ///<summary>
        ///Pound sterling
        ///</summary>
        [Description("Pound sterling")]
        GBP,
        ///<summary>
        ///Georgian lari
        ///</summary>
        [Description("Georgian lari")]
        GEL,
        ///<summary>
        ///Ghanaian cedi
        ///</summary>
        [Description("Ghanaian cedi")]
        GHS,
        ///<summary>
        ///Gibraltar pound
        ///</summary>
        [Description("Gibraltar pound")]
        GIP,
        ///<summary>
        ///Gambian dalasi
        ///</summary>
        [Description("Gambian dalasi")]
        GMD,
        ///<summary>
        ///Guinean franc
        ///</summary>
        [Description("Guinean franc")]
        GNF,
        ///<summary>
        ///Guatemalan quetzal
        ///</summary>
        [Description("Guatemalan quetzal")]
        GTQ,
        ///<summary>
        ///Guyanese dollar
        ///</summary>
        [Description("Guyanese dollar")]
        GYD,
        ///<summary>
        ///Hong Kong dollar
        ///</summary>
        [Description("Hong Kong dollar")]
        HKD,
        ///<summary>
        ///Honduran lempira
        ///</summary>
        [Description("Honduran lempira")]
        HNL,
        ///<summary>
        ///Croatian kuna
        ///</summary>
        [Description("Croatian kuna")]
        HRK,
        ///<summary>
        ///Haitian gourde
        ///</summary>
        [Description("Haitian gourde")]
        HTG,
        ///<summary>
        ///Hungarian forint
        ///</summary>
        [Description("Hungarian forint")]
        HUF,
        ///<summary>
        ///Indonesian rupiah
        ///</summary>
        [Description("Indonesian rupiah")]
        IDR,
        ///<summary>
        ///Israeli new shekel
        ///</summary>
        [Description("Israeli new shekel")]
        ILS,
        ///<summary>
        ///Indian rupee
        ///</summary>
        [Description("Indian rupee")]
        INR,
        ///<summary>
        ///Iraqi dinar
        ///</summary>
        [Description("Iraqi dinar")]
        IQD,
        ///<summary>
        ///Iranian rial
        ///</summary>
        [Description("Iranian rial")]
        IRR,
        ///<summary>
        ///Icelandic króna
        ///</summary>
        [Description("Icelandic króna")]
        ISK,
        ///<summary>
        ///Jamaican dollar
        ///</summary>
        [Description("Jamaican dollar")]
        JMD,
        ///<summary>
        ///Jordanian dinar
        ///</summary>
        [Description("Jordanian dinar")]
        JOD,
        ///<summary>
        ///Japanese yen
        ///</summary>
        [Description("Japanese yen")]
        JPY,
        ///<summary>
        ///Kenyan shilling
        ///</summary>
        [Description("Kenyan shilling")]
        KES,
        ///<summary>
        ///Kyrgyzstani som
        ///</summary>
        [Description("Kyrgyzstani som")]
        KGS,
        ///<summary>
        ///Cambodian riel
        ///</summary>
        [Description("Cambodian riel")]
        KHR,
        ///<summary>
        ///Comoro franc
        ///</summary>
        [Description("Comoro franc")]
        KMF,
        ///<summary>
        ///North Korean won
        ///</summary>
        [Description("North Korean won")]
        KPW,
        ///<summary>
        ///South Korean won
        ///</summary>
        [Description("South Korean won")]
        KRW,
        ///<summary>
        ///Kuwaiti dinar
        ///</summary>
        [Description("Kuwaiti dinar")]
        KWD,
        ///<summary>
        ///Cayman Islands dollar
        ///</summary>
        [Description("Cayman Islands dollar")]
        KYD,
        ///<summary>
        ///Kazakhstani tenge
        ///</summary>
        [Description("Kazakhstani tenge")]
        KZT,
        ///<summary>
        ///Lao kip
        ///</summary>
        [Description("Lao kip")]
        LAK,
        ///<summary>
        ///Lebanese pound
        ///</summary>
        [Description("Lebanese pound")]
        LBP,
        ///<summary>
        ///Sri Lankan rupee
        ///</summary>
        [Description("Sri Lankan rupee")]
        LKR,
        ///<summary>
        ///Liberian dollar
        ///</summary>
        [Description("Liberian dollar")]
        LRD,
        ///<summary>
        ///Lesotho loti
        ///</summary>
        [Description("Lesotho loti")]
        LSL,
        ///<summary>
        ///Lithuanian litas
        ///</summary>
        [Description("Lithuanian litas")]
        LTL,
        ///<summary>
        ///Latvian lats
        ///</summary>
        [Description("Latvian lats")]
        LVL,
        ///<summary>
        ///Libyan dinar
        ///</summary>
        [Description("Libyan dinar")]
        LYD,
        ///<summary>
        ///Moroccan dirham
        ///</summary>
        [Description("Moroccan dirham")]
        MAD,
        ///<summary>
        ///Moldovan leu
        ///</summary>
        [Description("Moldovan leu")]
        MDL,
        ///<summary>
        ///Malagasy ariary
        ///</summary>
        [Description("Malagasy ariary")]
        MGA,
        ///<summary>
        ///Macedonian denar
        ///</summary>
        [Description("Macedonian denar")]
        MKD,
        ///<summary>
        ///Myanmar kyat
        ///</summary>
        [Description("Myanmar kyat")]
        MMK,
        ///<summary>
        ///Mongolian tögrög
        ///</summary>
        [Description("Mongolian tögrög")]
        MNT,
        ///<summary>
        ///Macanese pataca
        ///</summary>
        [Description("Macanese pataca")]
        MOP,
        ///<summary>
        ///Mauritanian ouguiya
        ///</summary>
        [Description("Mauritanian ouguiya")]
        MRO,
        ///<summary>
        ///Mauritian rupee
        ///</summary>
        [Description("Mauritian rupee")]
        MUR,
        ///<summary>
        ///Maldivian rufiyaa
        ///</summary>
        [Description("Maldivian rufiyaa")]
        MVR,
        ///<summary>
        ///Malawian kwacha
        ///</summary>
        [Description("Malawian kwacha")]
        MWK,
        ///<summary>
        ///Mexican peso
        ///</summary>
        [Description("Mexican peso")]
        MXN,
        ///<summary>
        ///Mexican Unidad de Inversion
        ///</summary>
        [Description("Mexican Unidad de Inversion")]
        MXV,
        ///<summary>
        ///Malaysian ringgit
        ///</summary>
        [Description("Malaysian ringgit")]
        MYR,
        ///<summary>
        ///Mozambican metical
        ///</summary>
        [Description("Mozambican metical")]
        MZN,
        ///<summary>
        ///Namibian dollar
        ///</summary>
        [Description("Namibian dollar")]
        NAD,
        ///<summary>
        ///Nigerian naira
        ///</summary>
        [Description("Nigerian naira")]
        NGN,
        ///<summary>
        ///Nicaraguan córdoba
        ///</summary>
        [Description("Nicaraguan córdoba")]
        NIO,
        ///<summary>
        ///Norwegian krone
        ///</summary>
        [Description("Norwegian krone")]
        NOK,
        ///<summary>
        ///Nepalese rupee
        ///</summary>
        [Description("Nepalese rupee")]
        NPR,
        ///<summary>
        ///New Zealand dollar
        ///</summary>
        [Description("New Zealand dollar")]
        NZD,
        ///<summary>
        ///Omani rial
        ///</summary>
        [Description("Omani rial")]
        OMR,
        ///<summary>
        ///Panamanian balboa
        ///</summary>
        [Description("Panamanian balboa")]
        PAB,
        ///<summary>
        ///Peruvian sol
        ///</summary>
        [Description("Peruvian sol")]
        PEN,
        ///<summary>
        ///Papua New Guinean kina
        ///</summary>
        [Description("Papua New Guinean kina")]
        PGK,
        ///<summary>
        ///Philippine peso
        ///</summary>
        [Description("Philippine peso")]
        PHP,
        ///<summary>
        ///Pakistani rupee
        ///</summary>
        [Description("Pakistani rupee")]
        PKR,
        ///<summary>
        ///Polish złoty
        ///</summary>
        [Description("Polish złoty")]
        PLN,
        ///<summary>
        ///Paraguayan guaraní
        ///</summary>
        [Description("Paraguayan guaraní")]
        PYG,
        ///<summary>
        ///Qatari riyal
        ///</summary>
        [Description("Qatari riyal")]
        QAR,
        ///<summary>
        ///Romanian leu
        ///</summary>
        [Description("Romanian leu")]
        RON,
        ///<summary>
        ///Serbian dinar
        ///</summary>
        [Description("Serbian dinar")]
        RSD,
        ///<summary>
        ///Russian ruble
        ///</summary>
        [Description("Russian ruble")]
        RUB,
        ///<summary>
        ///Rwandan franc
        ///</summary>
        [Description("Rwandan franc")]
        RWF,
        ///<summary>
        ///Saudi riyal
        ///</summary>
        [Description("Saudi riyal")]
        SAR,
        ///<summary>
        ///Solomon Islands dollar
        ///</summary>
        [Description("Solomon Islands dollar")]
        SBD,
        ///<summary>
        ///Seychelles rupee
        ///</summary>
        [Description("Seychelles rupee")]
        SCR,
        ///<summary>
        ///Sudanese pound
        ///</summary>
        [Description("Sudanese pound")]
        SDG,
        ///<summary>
        ///Swedish krona
        ///</summary>
        [Description("Swedish krona")]
        SEK,
        ///<summary>
        ///Singapore dollar
        ///</summary>
        [Description("Singapore dollar")]
        SGD,
        ///<summary>
        ///Saint Helena pound
        ///</summary>
        [Description("Saint Helena pound")]
        SHP,
        ///<summary>
        ///Sierra Leonean leone
        ///</summary>
        [Description("Sierra Leonean leone")]
        SLL,
        ///<summary>
        ///Somali shilling
        ///</summary>
        [Description("Somali shilling")]
        SOS,
        ///<summary>
        ///Surinamese dollar
        ///</summary>
        [Description("Surinamese dollar")]
        SRD,
        ///<summary>
        ///South Sudanese pound
        ///</summary>
        [Description("South Sudanese pound")]
        SSP,
        ///<summary>
        ///São Tomé and Príncipe dobra
        ///</summary>
        [Description("São Tomé and Príncipe dobra")]
        STD,
        ///<summary>
        ///Salvadoran colón
        ///</summary>
        [Description("Salvadoran colón")]
        SVC,
        ///<summary>
        ///Syrian pound
        ///</summary>
        [Description("Syrian pound")]
        SYP,
        ///<summary>
        ///Swazi lilangeni
        ///</summary>
        [Description("Swazi lilangeni")]
        SZL,
        ///<summary>
        ///Thai baht
        ///</summary>
        [Description("Thai baht")]
        THB,
        ///<summary>
        ///Tajikstani somoni
        ///</summary>
        [Description("Tajikstani somoni")]
        TJS,
        ///<summary>
        ///Turkmenistan manat
        ///</summary>
        [Description("Turkmenistan manat")]
        TMT,
        ///<summary>
        ///Tunisian dinar
        ///</summary>
        [Description("Tunisian dinar")]
        TND,
        ///<summary>
        ///Tongan pa'anga
        ///</summary>
        [Description("Tongan pa'anga")]
        TOP,
        ///<summary>
        ///Turkish lira
        ///</summary>
        [Description("Turkish lira")]
        TRY,
        ///<summary>
        ///Trinidad and Tobago dollar
        ///</summary>
        [Description("Trinidad and Tobago dollar")]
        TTD,
        ///<summary>
        ///New Taiwan dollar
        ///</summary>
        [Description("New Taiwan dollar")]
        TWD,
        ///<summary>
        ///Tanzanian shilling
        ///</summary>
        [Description("Tanzanian shilling")]
        TZS,
        ///<summary>
        ///Ukrainian hryvnia
        ///</summary>
        [Description("Ukrainian hryvnia")]
        UAH,
        ///<summary>
        ///Ugandan shilling
        ///</summary>
        [Description("Ugandan shilling")]
        UGX,
        ///<summary>
        ///Unknown currency
        ///</summary>
        [Description("Unknown currency")]
        UNKNOWN_CURRENCY,
        ///<summary>
        ///United States dollar
        ///</summary>
        [Description("United States dollar")]
        USD,
        ///<summary>
        ///United States dollar (next day)
        ///</summary>
        [Description("United States dollar (next day)")]
        USN,
        ///<summary>
        ///United States dollar (same day)
        ///</summary>
        [Description("United States dollar (same day)")]
        USS,
        ///<summary>
        ///Uruguay Peso en Unidedades Indexadas
        ///</summary>
        [Description("Uruguay Peso en Unidedades Indexadas")]
        UYI,
        ///<summary>
        ///Uruguyan peso
        ///</summary>
        [Description("Uruguyan peso")]
        UYU,
        ///<summary>
        ///Uzbekistan som
        ///</summary>
        [Description("Uzbekistan som")]
        UZS,
        ///<summary>
        ///Venezuelan bolívar soberano
        ///</summary>
        [Description("Venezuelan bolívar soberano")]
        VEF,
        ///<summary>
        ///Vietnamese đồng
        ///</summary>
        [Description("Vietnamese đồng")]
        VND,
        ///<summary>
        ///Vanuatu vatu
        ///</summary>
        [Description("Vanuatu vatu")]
        VUV,
        ///<summary>
        ///Samoan tala
        ///</summary>
        [Description("Samoan tala")]
        WST,
        ///<summary>
        ///CFA franc BEAC
        ///</summary>
        [Description("CFA franc BEAC")]
        XAF,
        ///<summary>
        ///Silver
        ///</summary>
        [Description("Silver")]
        XAG,
        ///<summary>
        ///Gold
        ///</summary>
        [Description("Gold")]
        XAU,
        ///<summary>
        ///European Composite Unit
        ///</summary>
        [Description("European Composite Unit")]
        XBA,
        ///<summary>
        ///European Monetary Unit
        ///</summary>
        [Description("European Monetary Unit")]
        XBB,
        ///<summary>
        ///European Unit of Account 9
        ///</summary>
        [Description("European Unit of Account 9")]
        XBC,
        ///<summary>
        ///European Unit of Account 17
        ///</summary>
        [Description("European Unit of Account 17")]
        XBD,
        ///<summary>
        ///East Caribbean dollar
        ///</summary>
        [Description("East Caribbean dollar")]
        XCD,
        ///<summary>
        ///Special drawing rights (International Monetary Fund)
        ///</summary>
        [Description("Special drawing rights (International Monetary Fund)")]
        XDR,
        ///<summary>
        ///CFA franc BCEAO
        ///</summary>
        [Description("CFA franc BCEAO")]
        XOF,
        ///<summary>
        ///Palladium
        ///</summary>
        [Description("Palladium")]
        XPD,
        ///<summary>
        ///CFP franc
        ///</summary>
        [Description("CFP franc")]
        XPF,
        ///<summary>
        ///Platinum
        ///</summary>
        [Description("Platinum")]
        XPT,
        ///<summary>
        ///Code reserved for testing
        ///</summary>
        [Description("Code reserved for testing")]
        XTS,
        ///<summary>
        ///USD Coin
        ///</summary>
        [Description("USD Coin")]
        XUS,
        ///<summary>
        ///No currency
        ///</summary>
        [Description("No currency")]
        XXX,
        ///<summary>
        ///Yemeni rial
        ///</summary>
        [Description("Yemeni rial")]
        YER,
        ///<summary>
        ///South African rand
        ///</summary>
        [Description("South African rand")]
        ZAR,
        ///<summary>
        ///Zambian kwacha
        ///</summary>
        [Description("Zambian kwacha")]
        ZMK,
        ///<summary>
        ///Zambian kwacha
        ///</summary>
        [Description("Zambian kwacha")]
        ZMW,
    }

    public static class CurrencyStringValues
    {
        public const string AED = @"AED";
        public const string AFN = @"AFN";
        public const string ALL = @"ALL";
        public const string AMD = @"AMD";
        public const string ANG = @"ANG";
        public const string AOA = @"AOA";
        public const string ARS = @"ARS";
        public const string AUD = @"AUD";
        public const string AWG = @"AWG";
        public const string AZN = @"AZN";
        public const string BAM = @"BAM";
        public const string BBD = @"BBD";
        public const string BDT = @"BDT";
        public const string BGN = @"BGN";
        public const string BHD = @"BHD";
        public const string BIF = @"BIF";
        public const string BMD = @"BMD";
        public const string BND = @"BND";
        public const string BOB = @"BOB";
        public const string BOV = @"BOV";
        public const string BRL = @"BRL";
        public const string BSD = @"BSD";
        public const string BTC = @"BTC";
        public const string BTN = @"BTN";
        public const string BWP = @"BWP";
        public const string BYR = @"BYR";
        public const string BZD = @"BZD";
        public const string CAD = @"CAD";
        public const string CDF = @"CDF";
        public const string CHE = @"CHE";
        public const string CHF = @"CHF";
        public const string CHW = @"CHW";
        public const string CLF = @"CLF";
        public const string CLP = @"CLP";
        public const string CNY = @"CNY";
        public const string COP = @"COP";
        public const string COU = @"COU";
        public const string CRC = @"CRC";
        public const string CUC = @"CUC";
        public const string CUP = @"CUP";
        public const string CVE = @"CVE";
        public const string CZK = @"CZK";
        public const string DJF = @"DJF";
        public const string DKK = @"DKK";
        public const string DOP = @"DOP";
        public const string DZD = @"DZD";
        public const string EGP = @"EGP";
        public const string ERN = @"ERN";
        public const string ETB = @"ETB";
        public const string EUR = @"EUR";
        public const string FJD = @"FJD";
        public const string FKP = @"FKP";
        public const string GBP = @"GBP";
        public const string GEL = @"GEL";
        public const string GHS = @"GHS";
        public const string GIP = @"GIP";
        public const string GMD = @"GMD";
        public const string GNF = @"GNF";
        public const string GTQ = @"GTQ";
        public const string GYD = @"GYD";
        public const string HKD = @"HKD";
        public const string HNL = @"HNL";
        public const string HRK = @"HRK";
        public const string HTG = @"HTG";
        public const string HUF = @"HUF";
        public const string IDR = @"IDR";
        public const string ILS = @"ILS";
        public const string INR = @"INR";
        public const string IQD = @"IQD";
        public const string IRR = @"IRR";
        public const string ISK = @"ISK";
        public const string JMD = @"JMD";
        public const string JOD = @"JOD";
        public const string JPY = @"JPY";
        public const string KES = @"KES";
        public const string KGS = @"KGS";
        public const string KHR = @"KHR";
        public const string KMF = @"KMF";
        public const string KPW = @"KPW";
        public const string KRW = @"KRW";
        public const string KWD = @"KWD";
        public const string KYD = @"KYD";
        public const string KZT = @"KZT";
        public const string LAK = @"LAK";
        public const string LBP = @"LBP";
        public const string LKR = @"LKR";
        public const string LRD = @"LRD";
        public const string LSL = @"LSL";
        public const string LTL = @"LTL";
        public const string LVL = @"LVL";
        public const string LYD = @"LYD";
        public const string MAD = @"MAD";
        public const string MDL = @"MDL";
        public const string MGA = @"MGA";
        public const string MKD = @"MKD";
        public const string MMK = @"MMK";
        public const string MNT = @"MNT";
        public const string MOP = @"MOP";
        public const string MRO = @"MRO";
        public const string MUR = @"MUR";
        public const string MVR = @"MVR";
        public const string MWK = @"MWK";
        public const string MXN = @"MXN";
        public const string MXV = @"MXV";
        public const string MYR = @"MYR";
        public const string MZN = @"MZN";
        public const string NAD = @"NAD";
        public const string NGN = @"NGN";
        public const string NIO = @"NIO";
        public const string NOK = @"NOK";
        public const string NPR = @"NPR";
        public const string NZD = @"NZD";
        public const string OMR = @"OMR";
        public const string PAB = @"PAB";
        public const string PEN = @"PEN";
        public const string PGK = @"PGK";
        public const string PHP = @"PHP";
        public const string PKR = @"PKR";
        public const string PLN = @"PLN";
        public const string PYG = @"PYG";
        public const string QAR = @"QAR";
        public const string RON = @"RON";
        public const string RSD = @"RSD";
        public const string RUB = @"RUB";
        public const string RWF = @"RWF";
        public const string SAR = @"SAR";
        public const string SBD = @"SBD";
        public const string SCR = @"SCR";
        public const string SDG = @"SDG";
        public const string SEK = @"SEK";
        public const string SGD = @"SGD";
        public const string SHP = @"SHP";
        public const string SLL = @"SLL";
        public const string SOS = @"SOS";
        public const string SRD = @"SRD";
        public const string SSP = @"SSP";
        public const string STD = @"STD";
        public const string SVC = @"SVC";
        public const string SYP = @"SYP";
        public const string SZL = @"SZL";
        public const string THB = @"THB";
        public const string TJS = @"TJS";
        public const string TMT = @"TMT";
        public const string TND = @"TND";
        public const string TOP = @"TOP";
        public const string TRY = @"TRY";
        public const string TTD = @"TTD";
        public const string TWD = @"TWD";
        public const string TZS = @"TZS";
        public const string UAH = @"UAH";
        public const string UGX = @"UGX";
        public const string UNKNOWN_CURRENCY = @"UNKNOWN_CURRENCY";
        public const string USD = @"USD";
        public const string USN = @"USN";
        public const string USS = @"USS";
        public const string UYI = @"UYI";
        public const string UYU = @"UYU";
        public const string UZS = @"UZS";
        public const string VEF = @"VEF";
        public const string VND = @"VND";
        public const string VUV = @"VUV";
        public const string WST = @"WST";
        public const string XAF = @"XAF";
        public const string XAG = @"XAG";
        public const string XAU = @"XAU";
        public const string XBA = @"XBA";
        public const string XBB = @"XBB";
        public const string XBC = @"XBC";
        public const string XBD = @"XBD";
        public const string XCD = @"XCD";
        public const string XDR = @"XDR";
        public const string XOF = @"XOF";
        public const string XPD = @"XPD";
        public const string XPF = @"XPF";
        public const string XPT = @"XPT";
        public const string XTS = @"XTS";
        public const string XUS = @"XUS";
        public const string XXX = @"XXX";
        public const string YER = @"YER";
        public const string ZAR = @"ZAR";
        public const string ZMK = @"ZMK";
        public const string ZMW = @"ZMW";
    }

    ///<summary>
    ///Indicates the associated currency for an amount of money. Values correspond to
    ///[ISO 4217](https://wikipedia.org/wiki/ISO_4217), with the exception of BTC (Bitcoin).
    ///</summary>
    [Description("Indicates the associated currency for an amount of money. Values correspond to\n[ISO 4217](https://wikipedia.org/wiki/ISO_4217), with the exception of BTC (Bitcoin).")]
    public enum CurrencyCode
    {
        ///<summary>
        ///United Arab Emirates dirham
        ///</summary>
        [Description("United Arab Emirates dirham")]
        AED,
        ///<summary>
        ///Afghan afghani
        ///</summary>
        [Description("Afghan afghani")]
        AFN,
        ///<summary>
        ///Albanian lek
        ///</summary>
        [Description("Albanian lek")]
        ALL,
        ///<summary>
        ///Armenian dram
        ///</summary>
        [Description("Armenian dram")]
        AMD,
        ///<summary>
        ///Netherlands Antillean guilder
        ///</summary>
        [Description("Netherlands Antillean guilder")]
        ANG,
        ///<summary>
        ///Angolan kwanza
        ///</summary>
        [Description("Angolan kwanza")]
        AOA,
        ///<summary>
        ///Argentine peso
        ///</summary>
        [Description("Argentine peso")]
        ARS,
        ///<summary>
        ///Australian dollar
        ///</summary>
        [Description("Australian dollar")]
        AUD,
        ///<summary>
        ///Aruban florin
        ///</summary>
        [Description("Aruban florin")]
        AWG,
        ///<summary>
        ///Azerbaijani manat
        ///</summary>
        [Description("Azerbaijani manat")]
        AZN,
        ///<summary>
        ///Bosnia and Herzegovina convertible mark
        ///</summary>
        [Description("Bosnia and Herzegovina convertible mark")]
        BAM,
        ///<summary>
        ///Barbados dollar
        ///</summary>
        [Description("Barbados dollar")]
        BBD,
        ///<summary>
        ///Bangladeshi taka
        ///</summary>
        [Description("Bangladeshi taka")]
        BDT,
        ///<summary>
        ///Bulgarian lev
        ///</summary>
        [Description("Bulgarian lev")]
        BGN,
        ///<summary>
        ///Bahraini dinar
        ///</summary>
        [Description("Bahraini dinar")]
        BHD,
        ///<summary>
        ///Burundian franc
        ///</summary>
        [Description("Burundian franc")]
        BIF,
        ///<summary>
        ///Bermudian dollar
        ///</summary>
        [Description("Bermudian dollar")]
        BMD,
        ///<summary>
        ///Brunei dollar
        ///</summary>
        [Description("Brunei dollar")]
        BND,
        ///<summary>
        ///Boliviano
        ///</summary>
        [Description("Boliviano")]
        BOB,
        ///<summary>
        ///Bolivian Mvdol
        ///</summary>
        [Description("Bolivian Mvdol")]
        BOV,
        ///<summary>
        ///Brazilian real
        ///</summary>
        [Description("Brazilian real")]
        BRL,
        ///<summary>
        ///Bahamian dollar
        ///</summary>
        [Description("Bahamian dollar")]
        BSD,
        ///<summary>
        ///Bitcoin
        ///</summary>
        [Description("Bitcoin")]
        BTC,
        ///<summary>
        ///Bhutanese ngultrum
        ///</summary>
        [Description("Bhutanese ngultrum")]
        BTN,
        ///<summary>
        ///Botswana pula
        ///</summary>
        [Description("Botswana pula")]
        BWP,
        ///<summary>
        ///Belarusian ruble
        ///</summary>
        [Description("Belarusian ruble")]
        BYR,
        ///<summary>
        ///Belize dollar
        ///</summary>
        [Description("Belize dollar")]
        BZD,
        ///<summary>
        ///Canadian dollar
        ///</summary>
        [Description("Canadian dollar")]
        CAD,
        ///<summary>
        ///Congolese franc
        ///</summary>
        [Description("Congolese franc")]
        CDF,
        ///<summary>
        ///WIR Euro
        ///</summary>
        [Description("WIR Euro")]
        CHE,
        ///<summary>
        ///Swiss franc
        ///</summary>
        [Description("Swiss franc")]
        CHF,
        ///<summary>
        ///WIR Franc
        ///</summary>
        [Description("WIR Franc")]
        CHW,
        ///<summary>
        ///Unidad de Fomento
        ///</summary>
        [Description("Unidad de Fomento")]
        CLF,
        ///<summary>
        ///Chilean peso
        ///</summary>
        [Description("Chilean peso")]
        CLP,
        ///<summary>
        ///Chinese yuan
        ///</summary>
        [Description("Chinese yuan")]
        CNY,
        ///<summary>
        ///Colombian peso
        ///</summary>
        [Description("Colombian peso")]
        COP,
        ///<summary>
        ///Unidad de Valor Real
        ///</summary>
        [Description("Unidad de Valor Real")]
        COU,
        ///<summary>
        ///Costa Rican colon
        ///</summary>
        [Description("Costa Rican colon")]
        CRC,
        ///<summary>
        ///Cuban convertible peso
        ///</summary>
        [Description("Cuban convertible peso")]
        CUC,
        ///<summary>
        ///Cuban peso
        ///</summary>
        [Description("Cuban peso")]
        CUP,
        ///<summary>
        ///Cape Verdean escudo
        ///</summary>
        [Description("Cape Verdean escudo")]
        CVE,
        ///<summary>
        ///Czech koruna
        ///</summary>
        [Description("Czech koruna")]
        CZK,
        ///<summary>
        ///Djiboutian franc
        ///</summary>
        [Description("Djiboutian franc")]
        DJF,
        ///<summary>
        ///Danish krone
        ///</summary>
        [Description("Danish krone")]
        DKK,
        ///<summary>
        ///Dominican peso
        ///</summary>
        [Description("Dominican peso")]
        DOP,
        ///<summary>
        ///Algerian dinar
        ///</summary>
        [Description("Algerian dinar")]
        DZD,
        ///<summary>
        ///Egyptian pound
        ///</summary>
        [Description("Egyptian pound")]
        EGP,
        ///<summary>
        ///Eritrean nakfa
        ///</summary>
        [Description("Eritrean nakfa")]
        ERN,
        ///<summary>
        ///Ethiopian birr
        ///</summary>
        [Description("Ethiopian birr")]
        ETB,
        ///<summary>
        ///Euro
        ///</summary>
        [Description("Euro")]
        EUR,
        ///<summary>
        ///Fiji dollar
        ///</summary>
        [Description("Fiji dollar")]
        FJD,
        ///<summary>
        ///Falkland Islands pound
        ///</summary>
        [Description("Falkland Islands pound")]
        FKP,
        ///<summary>
        ///Pound sterling
        ///</summary>
        [Description("Pound sterling")]
        GBP,
        ///<summary>
        ///Georgian lari
        ///</summary>
        [Description("Georgian lari")]
        GEL,
        ///<summary>
        ///Ghanaian cedi
        ///</summary>
        [Description("Ghanaian cedi")]
        GHS,
        ///<summary>
        ///Gibraltar pound
        ///</summary>
        [Description("Gibraltar pound")]
        GIP,
        ///<summary>
        ///Gambian dalasi
        ///</summary>
        [Description("Gambian dalasi")]
        GMD,
        ///<summary>
        ///Guinean franc
        ///</summary>
        [Description("Guinean franc")]
        GNF,
        ///<summary>
        ///Guatemalan quetzal
        ///</summary>
        [Description("Guatemalan quetzal")]
        GTQ,
        ///<summary>
        ///Guyanese dollar
        ///</summary>
        [Description("Guyanese dollar")]
        GYD,
        ///<summary>
        ///Hong Kong dollar
        ///</summary>
        [Description("Hong Kong dollar")]
        HKD,
        ///<summary>
        ///Honduran lempira
        ///</summary>
        [Description("Honduran lempira")]
        HNL,
        ///<summary>
        ///Croatian kuna
        ///</summary>
        [Description("Croatian kuna")]
        HRK,
        ///<summary>
        ///Haitian gourde
        ///</summary>
        [Description("Haitian gourde")]
        HTG,
        ///<summary>
        ///Hungarian forint
        ///</summary>
        [Description("Hungarian forint")]
        HUF,
        ///<summary>
        ///Indonesian rupiah
        ///</summary>
        [Description("Indonesian rupiah")]
        IDR,
        ///<summary>
        ///Israeli new shekel
        ///</summary>
        [Description("Israeli new shekel")]
        ILS,
        ///<summary>
        ///Indian rupee
        ///</summary>
        [Description("Indian rupee")]
        INR,
        ///<summary>
        ///Iraqi dinar
        ///</summary>
        [Description("Iraqi dinar")]
        IQD,
        ///<summary>
        ///Iranian rial
        ///</summary>
        [Description("Iranian rial")]
        IRR,
        ///<summary>
        ///Icelandic króna
        ///</summary>
        [Description("Icelandic króna")]
        ISK,
        ///<summary>
        ///Jamaican dollar
        ///</summary>
        [Description("Jamaican dollar")]
        JMD,
        ///<summary>
        ///Jordanian dinar
        ///</summary>
        [Description("Jordanian dinar")]
        JOD,
        ///<summary>
        ///Japanese yen
        ///</summary>
        [Description("Japanese yen")]
        JPY,
        ///<summary>
        ///Kenyan shilling
        ///</summary>
        [Description("Kenyan shilling")]
        KES,
        ///<summary>
        ///Kyrgyzstani som
        ///</summary>
        [Description("Kyrgyzstani som")]
        KGS,
        ///<summary>
        ///Cambodian riel
        ///</summary>
        [Description("Cambodian riel")]
        KHR,
        ///<summary>
        ///Comoro franc
        ///</summary>
        [Description("Comoro franc")]
        KMF,
        ///<summary>
        ///North Korean won
        ///</summary>
        [Description("North Korean won")]
        KPW,
        ///<summary>
        ///South Korean won
        ///</summary>
        [Description("South Korean won")]
        KRW,
        ///<summary>
        ///Kuwaiti dinar
        ///</summary>
        [Description("Kuwaiti dinar")]
        KWD,
        ///<summary>
        ///Cayman Islands dollar
        ///</summary>
        [Description("Cayman Islands dollar")]
        KYD,
        ///<summary>
        ///Kazakhstani tenge
        ///</summary>
        [Description("Kazakhstani tenge")]
        KZT,
        ///<summary>
        ///Lao kip
        ///</summary>
        [Description("Lao kip")]
        LAK,
        ///<summary>
        ///Lebanese pound
        ///</summary>
        [Description("Lebanese pound")]
        LBP,
        ///<summary>
        ///Sri Lankan rupee
        ///</summary>
        [Description("Sri Lankan rupee")]
        LKR,
        ///<summary>
        ///Liberian dollar
        ///</summary>
        [Description("Liberian dollar")]
        LRD,
        ///<summary>
        ///Lesotho loti
        ///</summary>
        [Description("Lesotho loti")]
        LSL,
        ///<summary>
        ///Lithuanian litas
        ///</summary>
        [Description("Lithuanian litas")]
        LTL,
        ///<summary>
        ///Latvian lats
        ///</summary>
        [Description("Latvian lats")]
        LVL,
        ///<summary>
        ///Libyan dinar
        ///</summary>
        [Description("Libyan dinar")]
        LYD,
        ///<summary>
        ///Moroccan dirham
        ///</summary>
        [Description("Moroccan dirham")]
        MAD,
        ///<summary>
        ///Moldovan leu
        ///</summary>
        [Description("Moldovan leu")]
        MDL,
        ///<summary>
        ///Malagasy ariary
        ///</summary>
        [Description("Malagasy ariary")]
        MGA,
        ///<summary>
        ///Macedonian denar
        ///</summary>
        [Description("Macedonian denar")]
        MKD,
        ///<summary>
        ///Myanmar kyat
        ///</summary>
        [Description("Myanmar kyat")]
        MMK,
        ///<summary>
        ///Mongolian tögrög
        ///</summary>
        [Description("Mongolian tögrög")]
        MNT,
        ///<summary>
        ///Macanese pataca
        ///</summary>
        [Description("Macanese pataca")]
        MOP,
        ///<summary>
        ///Mauritanian ouguiya
        ///</summary>
        [Description("Mauritanian ouguiya")]
        MRO,
        ///<summary>
        ///Mauritian rupee
        ///</summary>
        [Description("Mauritian rupee")]
        MUR,
        ///<summary>
        ///Maldivian rufiyaa
        ///</summary>
        [Description("Maldivian rufiyaa")]
        MVR,
        ///<summary>
        ///Malawian kwacha
        ///</summary>
        [Description("Malawian kwacha")]
        MWK,
        ///<summary>
        ///Mexican peso
        ///</summary>
        [Description("Mexican peso")]
        MXN,
        ///<summary>
        ///Mexican Unidad de Inversion
        ///</summary>
        [Description("Mexican Unidad de Inversion")]
        MXV,
        ///<summary>
        ///Malaysian ringgit
        ///</summary>
        [Description("Malaysian ringgit")]
        MYR,
        ///<summary>
        ///Mozambican metical
        ///</summary>
        [Description("Mozambican metical")]
        MZN,
        ///<summary>
        ///Namibian dollar
        ///</summary>
        [Description("Namibian dollar")]
        NAD,
        ///<summary>
        ///Nigerian naira
        ///</summary>
        [Description("Nigerian naira")]
        NGN,
        ///<summary>
        ///Nicaraguan córdoba
        ///</summary>
        [Description("Nicaraguan córdoba")]
        NIO,
        ///<summary>
        ///Norwegian krone
        ///</summary>
        [Description("Norwegian krone")]
        NOK,
        ///<summary>
        ///Nepalese rupee
        ///</summary>
        [Description("Nepalese rupee")]
        NPR,
        ///<summary>
        ///New Zealand dollar
        ///</summary>
        [Description("New Zealand dollar")]
        NZD,
        ///<summary>
        ///Omani rial
        ///</summary>
        [Description("Omani rial")]
        OMR,
        ///<summary>
        ///Panamanian balboa
        ///</summary>
        [Description("Panamanian balboa")]
        PAB,
        ///<summary>
        ///Peruvian sol
        ///</summary>
        [Description("Peruvian sol")]
        PEN,
        ///<summary>
        ///Papua New Guinean kina
        ///</summary>
        [Description("Papua New Guinean kina")]
        PGK,
        ///<summary>
        ///Philippine peso
        ///</summary>
        [Description("Philippine peso")]
        PHP,
        ///<summary>
        ///Pakistani rupee
        ///</summary>
        [Description("Pakistani rupee")]
        PKR,
        ///<summary>
        ///Polish złoty
        ///</summary>
        [Description("Polish złoty")]
        PLN,
        ///<summary>
        ///Paraguayan guaraní
        ///</summary>
        [Description("Paraguayan guaraní")]
        PYG,
        ///<summary>
        ///Qatari riyal
        ///</summary>
        [Description("Qatari riyal")]
        QAR,
        ///<summary>
        ///Romanian leu
        ///</summary>
        [Description("Romanian leu")]
        RON,
        ///<summary>
        ///Serbian dinar
        ///</summary>
        [Description("Serbian dinar")]
        RSD,
        ///<summary>
        ///Russian ruble
        ///</summary>
        [Description("Russian ruble")]
        RUB,
        ///<summary>
        ///Rwandan franc
        ///</summary>
        [Description("Rwandan franc")]
        RWF,
        ///<summary>
        ///Saudi riyal
        ///</summary>
        [Description("Saudi riyal")]
        SAR,
        ///<summary>
        ///Solomon Islands dollar
        ///</summary>
        [Description("Solomon Islands dollar")]
        SBD,
        ///<summary>
        ///Seychelles rupee
        ///</summary>
        [Description("Seychelles rupee")]
        SCR,
        ///<summary>
        ///Sudanese pound
        ///</summary>
        [Description("Sudanese pound")]
        SDG,
        ///<summary>
        ///Swedish krona
        ///</summary>
        [Description("Swedish krona")]
        SEK,
        ///<summary>
        ///Singapore dollar
        ///</summary>
        [Description("Singapore dollar")]
        SGD,
        ///<summary>
        ///Saint Helena pound
        ///</summary>
        [Description("Saint Helena pound")]
        SHP,
        ///<summary>
        ///Sierra Leonean leone
        ///</summary>
        [Description("Sierra Leonean leone")]
        SLL,
        ///<summary>
        ///Somali shilling
        ///</summary>
        [Description("Somali shilling")]
        SOS,
        ///<summary>
        ///Surinamese dollar
        ///</summary>
        [Description("Surinamese dollar")]
        SRD,
        ///<summary>
        ///South Sudanese pound
        ///</summary>
        [Description("South Sudanese pound")]
        SSP,
        ///<summary>
        ///São Tomé and Príncipe dobra
        ///</summary>
        [Description("São Tomé and Príncipe dobra")]
        STD,
        ///<summary>
        ///Salvadoran colón
        ///</summary>
        [Description("Salvadoran colón")]
        SVC,
        ///<summary>
        ///Syrian pound
        ///</summary>
        [Description("Syrian pound")]
        SYP,
        ///<summary>
        ///Swazi lilangeni
        ///</summary>
        [Description("Swazi lilangeni")]
        SZL,
        ///<summary>
        ///Thai baht
        ///</summary>
        [Description("Thai baht")]
        THB,
        ///<summary>
        ///Tajikstani somoni
        ///</summary>
        [Description("Tajikstani somoni")]
        TJS,
        ///<summary>
        ///Turkmenistan manat
        ///</summary>
        [Description("Turkmenistan manat")]
        TMT,
        ///<summary>
        ///Tunisian dinar
        ///</summary>
        [Description("Tunisian dinar")]
        TND,
        ///<summary>
        ///Tongan pa'anga
        ///</summary>
        [Description("Tongan pa'anga")]
        TOP,
        ///<summary>
        ///Turkish lira
        ///</summary>
        [Description("Turkish lira")]
        TRY,
        ///<summary>
        ///Trinidad and Tobago dollar
        ///</summary>
        [Description("Trinidad and Tobago dollar")]
        TTD,
        ///<summary>
        ///New Taiwan dollar
        ///</summary>
        [Description("New Taiwan dollar")]
        TWD,
        ///<summary>
        ///Tanzanian shilling
        ///</summary>
        [Description("Tanzanian shilling")]
        TZS,
        ///<summary>
        ///Ukrainian hryvnia
        ///</summary>
        [Description("Ukrainian hryvnia")]
        UAH,
        ///<summary>
        ///Ugandan shilling
        ///</summary>
        [Description("Ugandan shilling")]
        UGX,
        ///<summary>
        ///United States dollar
        ///</summary>
        [Description("United States dollar")]
        USD,
        ///<summary>
        ///United States dollar (next day)
        ///</summary>
        [Description("United States dollar (next day)")]
        USN,
        ///<summary>
        ///United States dollar (same day)
        ///</summary>
        [Description("United States dollar (same day)")]
        USS,
        ///<summary>
        ///Uruguay Peso en Unidedades Indexadas
        ///</summary>
        [Description("Uruguay Peso en Unidedades Indexadas")]
        UYI,
        ///<summary>
        ///Uruguyan peso
        ///</summary>
        [Description("Uruguyan peso")]
        UYU,
        ///<summary>
        ///Uzbekistan som
        ///</summary>
        [Description("Uzbekistan som")]
        UZS,
        ///<summary>
        ///Venezuelan bolívar soberano
        ///</summary>
        [Description("Venezuelan bolívar soberano")]
        VEF,
        ///<summary>
        ///Vietnamese đồng
        ///</summary>
        [Description("Vietnamese đồng")]
        VND,
        ///<summary>
        ///Vanuatu vatu
        ///</summary>
        [Description("Vanuatu vatu")]
        VUV,
        ///<summary>
        ///Samoan tala
        ///</summary>
        [Description("Samoan tala")]
        WST,
        ///<summary>
        ///CFA franc BEAC
        ///</summary>
        [Description("CFA franc BEAC")]
        XAF,
        ///<summary>
        ///Silver
        ///</summary>
        [Description("Silver")]
        XAG,
        ///<summary>
        ///Gold
        ///</summary>
        [Description("Gold")]
        XAU,
        ///<summary>
        ///European Composite Unit
        ///</summary>
        [Description("European Composite Unit")]
        XBA,
        ///<summary>
        ///European Monetary Unit
        ///</summary>
        [Description("European Monetary Unit")]
        XBB,
        ///<summary>
        ///European Unit of Account 9
        ///</summary>
        [Description("European Unit of Account 9")]
        XBC,
        ///<summary>
        ///European Unit of Account 17
        ///</summary>
        [Description("European Unit of Account 17")]
        XBD,
        ///<summary>
        ///East Caribbean dollar
        ///</summary>
        [Description("East Caribbean dollar")]
        XCD,
        ///<summary>
        ///Special drawing rights (International Monetary Fund)
        ///</summary>
        [Description("Special drawing rights (International Monetary Fund)")]
        XDR,
        ///<summary>
        ///CFA franc BCEAO
        ///</summary>
        [Description("CFA franc BCEAO")]
        XOF,
        ///<summary>
        ///Palladium
        ///</summary>
        [Description("Palladium")]
        XPD,
        ///<summary>
        ///CFP franc
        ///</summary>
        [Description("CFP franc")]
        XPF,
        ///<summary>
        ///Platinum
        ///</summary>
        [Description("Platinum")]
        XPT,
        ///<summary>
        ///Code reserved for testing
        ///</summary>
        [Description("Code reserved for testing")]
        XTS,
        ///<summary>
        ///USD Coin
        ///</summary>
        [Description("USD Coin")]
        XUS,
        ///<summary>
        ///No currency
        ///</summary>
        [Description("No currency")]
        XXX,
        ///<summary>
        ///Yemeni rial
        ///</summary>
        [Description("Yemeni rial")]
        YER,
        ///<summary>
        ///South African rand
        ///</summary>
        [Description("South African rand")]
        ZAR,
        ///<summary>
        ///Zambian kwacha
        ///</summary>
        [Description("Zambian kwacha")]
        ZMK,
        ///<summary>
        ///Zambian kwacha
        ///</summary>
        [Description("Zambian kwacha")]
        ZMW,
    }

    public static class CurrencyCodeStringValues
    {
        public const string AED = @"AED";
        public const string AFN = @"AFN";
        public const string ALL = @"ALL";
        public const string AMD = @"AMD";
        public const string ANG = @"ANG";
        public const string AOA = @"AOA";
        public const string ARS = @"ARS";
        public const string AUD = @"AUD";
        public const string AWG = @"AWG";
        public const string AZN = @"AZN";
        public const string BAM = @"BAM";
        public const string BBD = @"BBD";
        public const string BDT = @"BDT";
        public const string BGN = @"BGN";
        public const string BHD = @"BHD";
        public const string BIF = @"BIF";
        public const string BMD = @"BMD";
        public const string BND = @"BND";
        public const string BOB = @"BOB";
        public const string BOV = @"BOV";
        public const string BRL = @"BRL";
        public const string BSD = @"BSD";
        public const string BTC = @"BTC";
        public const string BTN = @"BTN";
        public const string BWP = @"BWP";
        public const string BYR = @"BYR";
        public const string BZD = @"BZD";
        public const string CAD = @"CAD";
        public const string CDF = @"CDF";
        public const string CHE = @"CHE";
        public const string CHF = @"CHF";
        public const string CHW = @"CHW";
        public const string CLF = @"CLF";
        public const string CLP = @"CLP";
        public const string CNY = @"CNY";
        public const string COP = @"COP";
        public const string COU = @"COU";
        public const string CRC = @"CRC";
        public const string CUC = @"CUC";
        public const string CUP = @"CUP";
        public const string CVE = @"CVE";
        public const string CZK = @"CZK";
        public const string DJF = @"DJF";
        public const string DKK = @"DKK";
        public const string DOP = @"DOP";
        public const string DZD = @"DZD";
        public const string EGP = @"EGP";
        public const string ERN = @"ERN";
        public const string ETB = @"ETB";
        public const string EUR = @"EUR";
        public const string FJD = @"FJD";
        public const string FKP = @"FKP";
        public const string GBP = @"GBP";
        public const string GEL = @"GEL";
        public const string GHS = @"GHS";
        public const string GIP = @"GIP";
        public const string GMD = @"GMD";
        public const string GNF = @"GNF";
        public const string GTQ = @"GTQ";
        public const string GYD = @"GYD";
        public const string HKD = @"HKD";
        public const string HNL = @"HNL";
        public const string HRK = @"HRK";
        public const string HTG = @"HTG";
        public const string HUF = @"HUF";
        public const string IDR = @"IDR";
        public const string ILS = @"ILS";
        public const string INR = @"INR";
        public const string IQD = @"IQD";
        public const string IRR = @"IRR";
        public const string ISK = @"ISK";
        public const string JMD = @"JMD";
        public const string JOD = @"JOD";
        public const string JPY = @"JPY";
        public const string KES = @"KES";
        public const string KGS = @"KGS";
        public const string KHR = @"KHR";
        public const string KMF = @"KMF";
        public const string KPW = @"KPW";
        public const string KRW = @"KRW";
        public const string KWD = @"KWD";
        public const string KYD = @"KYD";
        public const string KZT = @"KZT";
        public const string LAK = @"LAK";
        public const string LBP = @"LBP";
        public const string LKR = @"LKR";
        public const string LRD = @"LRD";
        public const string LSL = @"LSL";
        public const string LTL = @"LTL";
        public const string LVL = @"LVL";
        public const string LYD = @"LYD";
        public const string MAD = @"MAD";
        public const string MDL = @"MDL";
        public const string MGA = @"MGA";
        public const string MKD = @"MKD";
        public const string MMK = @"MMK";
        public const string MNT = @"MNT";
        public const string MOP = @"MOP";
        public const string MRO = @"MRO";
        public const string MUR = @"MUR";
        public const string MVR = @"MVR";
        public const string MWK = @"MWK";
        public const string MXN = @"MXN";
        public const string MXV = @"MXV";
        public const string MYR = @"MYR";
        public const string MZN = @"MZN";
        public const string NAD = @"NAD";
        public const string NGN = @"NGN";
        public const string NIO = @"NIO";
        public const string NOK = @"NOK";
        public const string NPR = @"NPR";
        public const string NZD = @"NZD";
        public const string OMR = @"OMR";
        public const string PAB = @"PAB";
        public const string PEN = @"PEN";
        public const string PGK = @"PGK";
        public const string PHP = @"PHP";
        public const string PKR = @"PKR";
        public const string PLN = @"PLN";
        public const string PYG = @"PYG";
        public const string QAR = @"QAR";
        public const string RON = @"RON";
        public const string RSD = @"RSD";
        public const string RUB = @"RUB";
        public const string RWF = @"RWF";
        public const string SAR = @"SAR";
        public const string SBD = @"SBD";
        public const string SCR = @"SCR";
        public const string SDG = @"SDG";
        public const string SEK = @"SEK";
        public const string SGD = @"SGD";
        public const string SHP = @"SHP";
        public const string SLL = @"SLL";
        public const string SOS = @"SOS";
        public const string SRD = @"SRD";
        public const string SSP = @"SSP";
        public const string STD = @"STD";
        public const string SVC = @"SVC";
        public const string SYP = @"SYP";
        public const string SZL = @"SZL";
        public const string THB = @"THB";
        public const string TJS = @"TJS";
        public const string TMT = @"TMT";
        public const string TND = @"TND";
        public const string TOP = @"TOP";
        public const string TRY = @"TRY";
        public const string TTD = @"TTD";
        public const string TWD = @"TWD";
        public const string TZS = @"TZS";
        public const string UAH = @"UAH";
        public const string UGX = @"UGX";
        public const string USD = @"USD";
        public const string USN = @"USN";
        public const string USS = @"USS";
        public const string UYI = @"UYI";
        public const string UYU = @"UYU";
        public const string UZS = @"UZS";
        public const string VEF = @"VEF";
        public const string VND = @"VND";
        public const string VUV = @"VUV";
        public const string WST = @"WST";
        public const string XAF = @"XAF";
        public const string XAG = @"XAG";
        public const string XAU = @"XAU";
        public const string XBA = @"XBA";
        public const string XBB = @"XBB";
        public const string XBC = @"XBC";
        public const string XBD = @"XBD";
        public const string XCD = @"XCD";
        public const string XDR = @"XDR";
        public const string XOF = @"XOF";
        public const string XPD = @"XPD";
        public const string XPF = @"XPF";
        public const string XPT = @"XPT";
        public const string XTS = @"XTS";
        public const string XUS = @"XUS";
        public const string XXX = @"XXX";
        public const string YER = @"YER";
        public const string ZAR = @"ZAR";
        public const string ZMK = @"ZMK";
        public const string ZMW = @"ZMW";
    }

    ///<summary>
    ///Indicates the associated currency for an amount of money.
    ///
    ///Values correspond to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).
    ///</summary>
    [Description("Indicates the associated currency for an amount of money.\n\nValues correspond to [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217).")]
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

    public static class CurrencyInputStringValues
    {
        public const string AED = @"AED";
        public const string AFN = @"AFN";
        public const string ALL = @"ALL";
        public const string AMD = @"AMD";
        public const string ANG = @"ANG";
        public const string AOA = @"AOA";
        public const string ARS = @"ARS";
        public const string AUD = @"AUD";
        public const string AWG = @"AWG";
        public const string AZN = @"AZN";
        public const string BAM = @"BAM";
        public const string BBD = @"BBD";
        public const string BDT = @"BDT";
        public const string BGN = @"BGN";
        public const string BHD = @"BHD";
        public const string BIF = @"BIF";
        public const string BMD = @"BMD";
        public const string BND = @"BND";
        public const string BOB = @"BOB";
        public const string BOV = @"BOV";
        public const string BRL = @"BRL";
        public const string BSD = @"BSD";
        public const string BTC = @"BTC";
        public const string BTN = @"BTN";
        public const string BWP = @"BWP";
        public const string BYR = @"BYR";
        public const string BZD = @"BZD";
        public const string CAD = @"CAD";
        public const string CDF = @"CDF";
        public const string CHE = @"CHE";
        public const string CHF = @"CHF";
        public const string CHW = @"CHW";
        public const string CLF = @"CLF";
        public const string CLP = @"CLP";
        public const string CNY = @"CNY";
        public const string COP = @"COP";
        public const string COU = @"COU";
        public const string CRC = @"CRC";
        public const string CUC = @"CUC";
        public const string CUP = @"CUP";
        public const string CVE = @"CVE";
        public const string CZK = @"CZK";
        public const string DJF = @"DJF";
        public const string DKK = @"DKK";
        public const string DOP = @"DOP";
        public const string DZD = @"DZD";
        public const string EGP = @"EGP";
        public const string ERN = @"ERN";
        public const string ETB = @"ETB";
        public const string EUR = @"EUR";
        public const string FJD = @"FJD";
        public const string FKP = @"FKP";
        public const string GBP = @"GBP";
        public const string GEL = @"GEL";
        public const string GHS = @"GHS";
        public const string GIP = @"GIP";
        public const string GMD = @"GMD";
        public const string GNF = @"GNF";
        public const string GTQ = @"GTQ";
        public const string GYD = @"GYD";
        public const string HKD = @"HKD";
        public const string HNL = @"HNL";
        public const string HRK = @"HRK";
        public const string HTG = @"HTG";
        public const string HUF = @"HUF";
        public const string IDR = @"IDR";
        public const string ILS = @"ILS";
        public const string INR = @"INR";
        public const string IQD = @"IQD";
        public const string IRR = @"IRR";
        public const string ISK = @"ISK";
        public const string JMD = @"JMD";
        public const string JOD = @"JOD";
        public const string JPY = @"JPY";
        public const string KES = @"KES";
        public const string KGS = @"KGS";
        public const string KHR = @"KHR";
        public const string KMF = @"KMF";
        public const string KPW = @"KPW";
        public const string KRW = @"KRW";
        public const string KWD = @"KWD";
        public const string KYD = @"KYD";
        public const string KZT = @"KZT";
        public const string LAK = @"LAK";
        public const string LBP = @"LBP";
        public const string LKR = @"LKR";
        public const string LRD = @"LRD";
        public const string LSL = @"LSL";
        public const string LTL = @"LTL";
        public const string LVL = @"LVL";
        public const string LYD = @"LYD";
        public const string MAD = @"MAD";
        public const string MDL = @"MDL";
        public const string MGA = @"MGA";
        public const string MKD = @"MKD";
        public const string MMK = @"MMK";
        public const string MNT = @"MNT";
        public const string MOP = @"MOP";
        public const string MRO = @"MRO";
        public const string MUR = @"MUR";
        public const string MVR = @"MVR";
        public const string MWK = @"MWK";
        public const string MXN = @"MXN";
        public const string MXV = @"MXV";
        public const string MYR = @"MYR";
        public const string MZN = @"MZN";
        public const string NAD = @"NAD";
        public const string NGN = @"NGN";
        public const string NIO = @"NIO";
        public const string NOK = @"NOK";
        public const string NPR = @"NPR";
        public const string NZD = @"NZD";
        public const string OMR = @"OMR";
        public const string PAB = @"PAB";
        public const string PEN = @"PEN";
        public const string PGK = @"PGK";
        public const string PHP = @"PHP";
        public const string PKR = @"PKR";
        public const string PLN = @"PLN";
        public const string PYG = @"PYG";
        public const string QAR = @"QAR";
        public const string RON = @"RON";
        public const string RSD = @"RSD";
        public const string RUB = @"RUB";
        public const string RWF = @"RWF";
        public const string SAR = @"SAR";
        public const string SBD = @"SBD";
        public const string SCR = @"SCR";
        public const string SDG = @"SDG";
        public const string SEK = @"SEK";
        public const string SGD = @"SGD";
        public const string SHP = @"SHP";
        public const string SLL = @"SLL";
        public const string SOS = @"SOS";
        public const string SRD = @"SRD";
        public const string SSP = @"SSP";
        public const string STD = @"STD";
        public const string SVC = @"SVC";
        public const string SYP = @"SYP";
        public const string SZL = @"SZL";
        public const string THB = @"THB";
        public const string TJS = @"TJS";
        public const string TMT = @"TMT";
        public const string TND = @"TND";
        public const string TOP = @"TOP";
        public const string TRY = @"TRY";
        public const string TTD = @"TTD";
        public const string TWD = @"TWD";
        public const string TZS = @"TZS";
        public const string UAH = @"UAH";
        public const string UGX = @"UGX";
        public const string UNKNOWN_CURRENCY = @"UNKNOWN_CURRENCY";
        public const string USD = @"USD";
        public const string USN = @"USN";
        public const string USS = @"USS";
        public const string UYI = @"UYI";
        public const string UYU = @"UYU";
        public const string UZS = @"UZS";
        public const string VEF = @"VEF";
        public const string VND = @"VND";
        public const string VUV = @"VUV";
        public const string WST = @"WST";
        public const string XAF = @"XAF";
        public const string XAG = @"XAG";
        public const string XAU = @"XAU";
        public const string XBA = @"XBA";
        public const string XBB = @"XBB";
        public const string XBC = @"XBC";
        public const string XBD = @"XBD";
        public const string XCD = @"XCD";
        public const string XDR = @"XDR";
        public const string XOF = @"XOF";
        public const string XPD = @"XPD";
        public const string XPF = @"XPF";
        public const string XPT = @"XPT";
        public const string XTS = @"XTS";
        public const string XUS = @"XUS";
        public const string XXX = @"XXX";
        public const string YER = @"YER";
        public const string ZAR = @"ZAR";
        public const string ZMK = @"ZMK";
        public const string ZMW = @"ZMW";
    }

    ///<summary>
    ///References to Customers subgraph entities
    ///
    ///Permissions:CUSTOMERS_READ
    ///</summary>
    [Description("References to Customers subgraph entities\n\nPermissions:CUSTOMERS_READ")]
    public class Customer : GraphQLObject<Customer>
    {
        ///<summary>
        ///A unique Square-assigned ID for the customer profile.
        ///</summary>
        [Description("A unique Square-assigned ID for the customer profile.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The physical address associated with the customer profile.
        ///</summary>
        [Description("The physical address associated with the customer profile.")]
        public Address? address { get; set; }

        ///<summary>
        ///The birthday associated with the customer profile, in YYYY-MM-DD format. For example, 1998-09-21 represents September 21, 1998, and 0000-09-21 represents September 21 (without a birth year).
        ///</summary>
        [Description("The birthday associated with the customer profile, in YYYY-MM-DD format. For example, 1998-09-21 represents September 21, 1998, and 0000-09-21 represents September 21 (without a birth year).")]
        public string? birthday { get; set; }

        ///<summary>
        ///A business name associated with the customer profile.
        ///</summary>
        [Description("A business name associated with the customer profile.")]
        public string? companyName { get; set; }

        ///<summary>
        ///The timestamp when the customer profile was created, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp when the customer profile was created, in RFC 3339 format.")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///The method used to create the customer profile.
        ///</summary>
        [Description("The method used to create the customer profile.")]
        public string? creationSource { get; set; }

        ///<summary>
        ///The email address associated with the customer profile.
        ///</summary>
        [Description("The email address associated with the customer profile.")]
        public string? emailAddress { get; set; }

        ///<summary>
        ///The family name (that is, the last name) associated with the customer profile.
        ///</summary>
        [Description("The family name (that is, the last name) associated with the customer profile.")]
        public string? familyName { get; set; }

        ///<summary>
        ///The given name (that is, the first name) associated with the customer profile.
        ///</summary>
        [Description("The given name (that is, the first name) associated with the customer profile.")]
        public string? givenName { get; set; }

        ///<summary>
        ///The IDs of customer groups the customer belongs to.
        ///</summary>
        [Description("The IDs of customer groups the customer belongs to.")]
        public IEnumerable<string>? groupIds { get; set; }

        ///<summary>
        ///A nickname for the customer profile.
        ///</summary>
        [Description("A nickname for the customer profile.")]
        public string? nickname { get; set; }

        ///<summary>
        ///A custom note associated with the customer profile.
        ///</summary>
        [Description("A custom note associated with the customer profile.")]
        public string? note { get; set; }

        ///<summary>
        ///The phone number associated with the customer profile.
        ///</summary>
        [Description("The phone number associated with the customer profile.")]
        public string? phoneNumber { get; set; }

        ///<summary>
        ///Represents general customer preferences.
        ///</summary>
        [Description("Represents general customer preferences.")]
        public CustomerPreferences? preferences { get; set; }

        ///<summary>
        ///An optional second ID used to associate the customer profile with an entity in another system.
        ///</summary>
        [Description("An optional second ID used to associate the customer profile with an entity in another system.")]
        public string? referenceId { get; set; }

        ///<summary>
        ///The IDs of customer segments the customer belongs to.
        ///</summary>
        [Description("The IDs of customer segments the customer belongs to.")]
        public IEnumerable<string>? segmentIds { get; set; }

        ///<summary>
        ///The tax ID associated with the customer profile. This field is present only for customers of sellers in EU countries or the United Kingdom. For more information, see Customer tax IDs.
        ///</summary>
        [Description("The tax ID associated with the customer profile. This field is present only for customers of sellers in EU countries or the United Kingdom. For more information, see Customer tax IDs.")]
        public TaxIds? taxIds { get; set; }

        ///<summary>
        ///The timestamp when the customer profile was last updated, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp when the customer profile was last updated, in RFC 3339 format.")]
        public DateTime? updatedAt { get; set; }
    }

    ///<summary>
    ///A list of Customer.
    ///
    ///Permissions:CUSTOMERS_READ
    ///</summary>
    [Description("A list of Customer.\n\nPermissions:CUSTOMERS_READ")]
    public class CustomerConnection : GraphQLObject<CustomerConnection>, IConnectionWithNodes<Customer>
    {
        ///<summary>
        ///List of Customer.
        ///</summary>
        [Description("List of Customer.")]
        [NonNull]
        public IEnumerable<Customer>? nodes { get; set; }

        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///Represents communication preferences for the customer profile.
    ///
    ///Permissions:CUSTOMERS_READ
    ///</summary>
    [Description("Represents communication preferences for the customer profile.\n\nPermissions:CUSTOMERS_READ")]
    public class CustomerPreferences : GraphQLObject<CustomerPreferences>
    {
        ///<summary>
        ///Indicates whether the customer has unsubscribed from marketing campaign emails.
        ///A value of true means that the customer chose to opt out of email marketing from the current Square seller or from all Square sellers.
        ///This value is read-only from the Customers API.
        ///</summary>
        [Description("Indicates whether the customer has unsubscribed from marketing campaign emails.\nA value of true means that the customer chose to opt out of email marketing from the current Square seller or from all Square sellers.\nThis value is read-only from the Customers API.")]
        public bool? emailUnsubscribed { get; set; }
    }

    ///<summary>
    ///Enumeration of `DateTime` units.
    ///</summary>
    [Description("Enumeration of `DateTime` units.")]
    public enum DateTimeUnit
    {
        ///<summary>
        ///The time period of a full rotation of the Earth with respect to the Sun.
        ///</summary>
        [Description("The time period of a full rotation of the Earth with respect to the Sun.")]
        DAY,
        ///<summary>
        ///1/24th of a day.
        ///</summary>
        [Description("1/24th of a day.")]
        HOUR,
        ///<summary>
        ///1/1000th of a second.
        ///</summary>
        [Description("1/1000th of a second.")]
        MILLISECOND,
        ///<summary>
        ///1/60th of an hour.
        ///</summary>
        [Description("1/60th of an hour.")]
        MINUTE,
        ///<summary>
        ///1/60th of a minute.
        ///</summary>
        [Description("1/60th of a minute.")]
        SECOND,
    }

    public static class DateTimeUnitStringValues
    {
        public const string DAY = @"DAY";
        public const string HOUR = @"HOUR";
        public const string MILLISECOND = @"MILLISECOND";
        public const string MINUTE = @"MINUTE";
        public const string SECOND = @"SECOND";
    }

    ///<summary>
    ///Indicates the specific day of the week.
    ///</summary>
    [Description("Indicates the specific day of the week.")]
    public enum DayOfWeek
    {
        ///<summary>
        ///Friday
        ///</summary>
        [Description("Friday")]
        FRI,
        ///<summary>
        ///Monday
        ///</summary>
        [Description("Monday")]
        MON,
        ///<summary>
        ///Saturday
        ///</summary>
        [Description("Saturday")]
        SAT,
        ///<summary>
        ///Sunday
        ///</summary>
        [Description("Sunday")]
        SUN,
        ///<summary>
        ///Thursday
        ///</summary>
        [Description("Thursday")]
        THU,
        ///<summary>
        ///Tuesday
        ///</summary>
        [Description("Tuesday")]
        TUE,
        ///<summary>
        ///Wednesday
        ///</summary>
        [Description("Wednesday")]
        WED,
    }

    public static class DayOfWeekStringValues
    {
        public const string FRI = @"FRI";
        public const string MON = @"MON";
        public const string SAT = @"SAT";
        public const string SUN = @"SUN";
        public const string THU = @"THU";
        public const string TUE = @"TUE";
        public const string WED = @"WED";
    }

    ///<summary>
    ///The brand used for a `WALLET` payment.
    ///</summary>
    [Description("The brand used for a `WALLET` payment.")]
    public enum DigitalWalletPaymentBrand
    {
        ALIPAY,
        CASH_APP,
        PAYPAY,
        UNKNOWN,
    }

    public static class DigitalWalletPaymentBrandStringValues
    {
        public const string ALIPAY = @"ALIPAY";
        public const string CASH_APP = @"CASH_APP";
        public const string PAYPAY = @"PAYPAY";
        public const string UNKNOWN = @"UNKNOWN";
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about `WALLET` type payments. Contains only non-confidential information.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nAdditional details about `WALLET` type payments. Contains only non-confidential information.")]
    public class DigitalWalletPaymentDetails : GraphQLObject<DigitalWalletPaymentDetails>
    {
        ///<summary>
        ///The brand used for the `WALLET` payment.
        ///</summary>
        [Description("The brand used for the `WALLET` payment.")]
        public DigitalWalletPaymentBrand? brand { get; set; }

        ///<summary>
        ///Brand-specific details for payments with the `brand` of `CASH_APP`.
        ///</summary>
        [Description("Brand-specific details for payments with the `brand` of `CASH_APP`.")]
        public CashAppPaymentDetails? cashAppDetails { get; set; }

        ///<summary>
        ///The status of the `WALLET` payment.
        ///</summary>
        [Description("The status of the `WALLET` payment.")]
        public DigitalWalletPaymentStatus? status { get; set; }
    }

    ///<summary>
    ///The status of a `WALLET` payment.
    ///</summary>
    [Description("The status of a `WALLET` payment.")]
    public enum DigitalWalletPaymentStatus
    {
        AUTHORIZED,
        CAPTURED,
        FAILED,
        VOIDED,
    }

    public static class DigitalWalletPaymentStatusStringValues
    {
        public const string AUTHORIZED = @"AUTHORIZED";
        public const string CAPTURED = @"CAPTURED";
        public const string FAILED = @"FAILED";
        public const string VOIDED = @"VOIDED";
    }

    ///<summary>
    ///Discount code belonging to the order.
    ///
    ///Permissions:ORDERS_READ
    ///</summary>
    [Description("Discount code belonging to the order.\n\nPermissions:ORDERS_READ")]
    public class DiscountCode : GraphQLObject<DiscountCode>
    {
        ///<summary>
        ///The identifier of the Discount Code.
        ///</summary>
        [Description("The identifier of the Discount Code.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The ID of the pricing rule corresponding to this discount code.
        ///</summary>
        [Description("The ID of the pricing rule corresponding to this discount code.")]
        public string? pricingRuleId { get; set; }

        ///<summary>
        ///The number of instances of the Discount Code.
        ///</summary>
        [Description("The number of instances of the Discount Code.")]
        public int? quantity { get; set; }
    }

    ///<summary>
    ///Enumerates the supported distance units.
    ///</summary>
    [Description("Enumerates the supported distance units.")]
    public enum DistanceUnit
    {
        ///<summary>
        ///A metric system unit equal to 1/100th of a meter.
        ///</summary>
        [Description("A metric system unit equal to 1/100th of a meter.")]
        CENTIMETER,
        ///<summary>
        ///A United States customary unit of 12 inches.
        ///</summary>
        [Description("A United States customary unit of 12 inches.")]
        FOOT,
        ///<summary>
        ///A United States customary unit equal to 1/12th of a foot.
        ///</summary>
        [Description("A United States customary unit equal to 1/12th of a foot.")]
        INCH,
        ///<summary>
        ///A metric system unit equal to 1,000 meters.
        ///</summary>
        [Description("A metric system unit equal to 1,000 meters.")]
        KILOMETER,
        ///<summary>
        ///The base unit of length in the metric system.
        ///</summary>
        [Description("The base unit of length in the metric system.")]
        METER,
        ///<summary>
        ///A United States customary unit of 5,280 feet.
        ///</summary>
        [Description("A United States customary unit of 5,280 feet.")]
        MILE,
        ///<summary>
        ///A metric system unit equal to 1/1,000th of a meter.
        ///</summary>
        [Description("A metric system unit equal to 1/1,000th of a meter.")]
        MILLIMETER,
        ///<summary>
        ///An international unit of length used for air, marine, and space navigation. Equivalent to 1,852 meters.
        ///</summary>
        [Description("An international unit of length used for air, marine, and space navigation. Equivalent to 1,852 meters.")]
        NAUTICAL_MILE,
        ///<summary>
        ///A United States customary unit of 3 feet.
        ///</summary>
        [Description("A United States customary unit of 3 feet.")]
        YARD,
    }

    public static class DistanceUnitStringValues
    {
        public const string CENTIMETER = @"CENTIMETER";
        public const string FOOT = @"FOOT";
        public const string INCH = @"INCH";
        public const string KILOMETER = @"KILOMETER";
        public const string METER = @"METER";
        public const string MILE = @"MILE";
        public const string MILLIMETER = @"MILLIMETER";
        public const string NAUTICAL_MILE = @"NAUTICAL_MILE";
        public const string YARD = @"YARD";
    }

    ///<summary>
    ///An employee object that is used by the external API.
    ///
    ///Permissions:EMPLOYEES_READ
    ///</summary>
    [Description("An employee object that is used by the external API.\n\nPermissions:EMPLOYEES_READ")]
    public class Employee : GraphQLObject<Employee>
    {
        ///<summary>
        ///The Square-issued ID of the employee.
        ///</summary>
        [Description("The Square-issued ID of the employee.")]
        [NonNull]
        public string? id { get; set; }
    }

    ///<summary>
    ///Represents an error encountered during a request to the Connect API.
    ///
    ///See [Handling errors](https://developer.squareup.com/docs/build-basics/handling-errors) for more information.
    ///</summary>
    [Description("Represents an error encountered during a request to the Connect API.\n\nSee [Handling errors](https://developer.squareup.com/docs/build-basics/handling-errors) for more information.")]
    public class Error : GraphQLObject<Error>
    {
        ///<summary>
        ///The high-level category for the error.
        ///</summary>
        [Description("The high-level category for the error.")]
        public ErrorCategory? category { get; set; }

        ///<summary>
        ///The specific code of the error.
        ///</summary>
        [Description("The specific code of the error.")]
        public ErrorCode? code { get; set; }

        ///<summary>
        ///A human-readable description of the error for debugging purposes.
        ///</summary>
        [Description("A human-readable description of the error for debugging purposes.")]
        public string? detail { get; set; }

        ///<summary>
        ///The name of the field provided in the original request (if any) that the error pertains to.
        ///</summary>
        [Description("The name of the field provided in the original request (if any) that the error pertains to.")]
        public string? field { get; set; }
    }

    ///<summary>
    ///Indicates which high-level category of error has occurred during a request to the Connect API.
    ///</summary>
    [Description("Indicates which high-level category of error has occurred during a request to the Connect API.")]
    public enum ErrorCategory
    {
        ///<summary>
        ///An error occurred with the Connect API itself.
        ///</summary>
        [Description("An error occurred with the Connect API itself.")]
        API_ERROR,
        ///<summary>
        ///An authentication error occurred. Most commonly, the request had a missing,
        ///malformed, or otherwise invalid `Authorization` header.
        ///</summary>
        [Description("An authentication error occurred. Most commonly, the request had a missing,\nmalformed, or otherwise invalid `Authorization` header.")]
        AUTHENTICATION_ERROR,
        ///<summary>
        ///An error that is returned from an external vendor's API.
        ///</summary>
        [Description("An error that is returned from an external vendor's API.")]
        EXTERNAL_VENDOR_ERROR,
        ///<summary>
        ///The request was invalid. Most commonly, a required parameter was missing, or a provided parameter had an invalid value.
        ///</summary>
        [Description("The request was invalid. Most commonly, a required parameter was missing, or a provided parameter had an invalid value.")]
        INVALID_REQUEST_ERROR,
        ///<summary>
        ///An error occurred when checking a merchant subscription status.
        ///</summary>
        [Description("An error occurred when checking a merchant subscription status.")]
        MERCHANT_SUBSCRIPTION_ERROR,
        ///<summary>
        ///An error occurred while processing a payment method. Most commonly, the
        ///details of the payment method were invalid (such as a card's CVV or expiration date).
        ///</summary>
        [Description("An error occurred while processing a payment method. Most commonly, the\ndetails of the payment method were invalid (such as a card's CVV or expiration date).")]
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
        [Description("Your application reached the Square API rate limit. You might receive this\nerror if your application sends a high number of requests\nto Square APIs in a short period of time.\n\nYour application should monitor responses for `429 RATE_LIMITED` errors and\nuse a retry mechanism with an [exponential\nbackoff](https://en.wikipedia.org/wiki/Exponential_backoff)\nschedule to resend the requests at an increasingly slower rate. It is also a\ngood practice to use a randomized delay (jitter) in your retry schedule.")]
        RATE_LIMIT_ERROR,
        ///<summary>
        ///An error occurred while attempting to process a refund.
        ///</summary>
        [Description("An error occurred while attempting to process a refund.")]
        REFUND_ERROR,
    }

    public static class ErrorCategoryStringValues
    {
        public const string API_ERROR = @"API_ERROR";
        public const string AUTHENTICATION_ERROR = @"AUTHENTICATION_ERROR";
        public const string EXTERNAL_VENDOR_ERROR = @"EXTERNAL_VENDOR_ERROR";
        public const string INVALID_REQUEST_ERROR = @"INVALID_REQUEST_ERROR";
        public const string MERCHANT_SUBSCRIPTION_ERROR = @"MERCHANT_SUBSCRIPTION_ERROR";
        public const string PAYMENT_METHOD_ERROR = @"PAYMENT_METHOD_ERROR";
        public const string RATE_LIMIT_ERROR = @"RATE_LIMIT_ERROR";
        public const string REFUND_ERROR = @"REFUND_ERROR";
    }

    ///<summary>
    ///Indicates the specific error that occurred during a request to a Square API.
    ///</summary>
    [Description("Indicates the specific error that occurred during a request to a Square API.")]
    public enum ErrorCode
    {
        ///<summary>
        ///The provided access token has expired.
        ///</summary>
        [Description("The provided access token has expired.")]
        ACCESS_TOKEN_EXPIRED,
        ///<summary>
        ///The provided access token has been revoked.
        ///</summary>
        [Description("The provided access token has been revoked.")]
        ACCESS_TOKEN_REVOKED,
        ///<summary>
        ///The account provided cannot carry out transactions.
        ///</summary>
        [Description("The account provided cannot carry out transactions.")]
        ACCOUNT_UNUSABLE,
        ///<summary>
        ///The card issuer declined the request because the postal code is invalid.
        ///</summary>
        [Description("The card issuer declined the request because the postal code is invalid.")]
        ADDRESS_VERIFICATION_FAILURE,
        ///<summary>
        ///The card has exhausted its available pin entry retries set by the card issuer.
        ///Resolving the error typically requires the card holder to contact the card issuer.
        ///</summary>
        [Description("The card has exhausted its available pin entry retries set by the card issuer.\nResolving the error typically requires the card holder to contact the card issuer.")]
        ALLOWABLE_PIN_TRIES_EXCEEDED,
        ///<summary>
        ///The requested payment amount is too high for the provided payment source.
        ///</summary>
        [Description("The requested payment amount is too high for the provided payment source.")]
        AMOUNT_TOO_HIGH,
        ///<summary>
        ///The provided Square-Version is incompatible with the requested action.
        ///</summary>
        [Description("The provided Square-Version is incompatible with the requested action.")]
        API_VERSION_INCOMPATIBLE,
        ///<summary>
        ///Square could not find the associated Apple Pay certificate.
        ///</summary>
        [Description("Square could not find the associated Apple Pay certificate.")]
        APPLE_PAYMENT_PROCESSING_CERTIFICATE_HASH_NOT_FOUND,
        ///<summary>
        ///The payment was declined by the card issuer during an Apple Tap to Pay (TTP) transaction with a request for the
        ///card's PIN. This code will be returned alongside CARD_DECLINED_VERIFICATION_REQUIRED as a supplemental error,
        ///and will include an issuer-provided token in the details field that is needed to initiate the PIN collection
        ///flow on the iOS device.
        ///</summary>
        [Description("The payment was declined by the card issuer during an Apple Tap to Pay (TTP) transaction with a request for the\ncard's PIN. This code will be returned alongside CARD_DECLINED_VERIFICATION_REQUIRED as a supplemental error,\nand will include an issuer-provided token in the details field that is needed to initiate the PIN collection\nflow on the iOS device.")]
        APPLE_TTP_PIN_TOKEN,
        ///<summary>
        ///The calling application was disabled.
        ///</summary>
        [Description("The calling application was disabled.")]
        APPLICATION_DISABLED,
        ///<summary>
        ///The provided array is empty.
        ///</summary>
        [Description("The provided array is empty.")]
        ARRAY_EMPTY,
        ///<summary>
        ///The provided array has too many elements.
        ///</summary>
        [Description("The provided array has too many elements.")]
        ARRAY_LENGTH_TOO_LONG,
        ///<summary>
        ///The provided array has too few elements.
        ///</summary>
        [Description("The provided array has too few elements.")]
        ARRAY_LENGTH_TOO_SHORT,
        ///<summary>
        ///Bad certificate.
        ///</summary>
        [Description("Bad certificate.")]
        BAD_CERTIFICATE,
        ///<summary>
        ///The card expiration date is either missing or incorrectly formatted.
        ///</summary>
        [Description("The card expiration date is either missing or incorrectly formatted.")]
        BAD_EXPIRATION,
        ///<summary>
        ///Bad Gateway - a general error occurred.
        ///</summary>
        [Description("Bad Gateway - a general error occurred.")]
        BAD_GATEWAY,
        ///<summary>
        ///A general error occurred with the request.
        ///</summary>
        [Description("A general error occurred with the request.")]
        BAD_REQUEST,
        ///<summary>
        ///The card issuer declined the refund.
        ///</summary>
        [Description("The card issuer declined the refund.")]
        BLOCKED_BY_BLOCKLIST,
        ///<summary>
        ///The provided buyer id can't be found
        ///</summary>
        [Description("The provided buyer id can't be found")]
        BUYER_NOT_FOUND,
        ///<summary>
        ///Bank account rejected or was not authorized for the payment.
        ///</summary>
        [Description("Bank account rejected or was not authorized for the payment.")]
        BUYER_REFUSED_PAYMENT,
        ///<summary>
        ///Fulfillment type is not supported for calculating fulfillment rates.
        ///</summary>
        [Description("Fulfillment type is not supported for calculating fulfillment rates.")]
        CALCULATE_FULFILLMENT_RATES_FULFILLMENT_TYPE_NOT_SUPPORTED,
        ///<summary>
        ///No profiles are configured with the requested shipment destination.
        ///</summary>
        [Description("No profiles are configured with the requested shipment destination.")]
        CALCULATE_FULFILLMENT_RATES_INVALID_RECIPIENT_ADDRESS,
        ///<summary>
        ///No profiles are configured for the fufillment type requested.
        ///</summary>
        [Description("No profiles are configured for the fufillment type requested.")]
        CALCULATE_FULFILLMENT_RATES_NO_PROFILES_CONFIGURED,
        ///<summary>
        ///No profiles are configured with the requested shipment destination.
        ///</summary>
        [Description("No profiles are configured with the requested shipment destination.")]
        CALCULATE_FULFILLMENT_RATES_SHIPMENT_DESTINATION_NOT_CONFIGURED,
        ///<summary>
        ///The card issuer has declined the transaction due to restrictions on where the
        ///card can be used.  For example, a gift card is limited to a single merchant.
        ///</summary>
        [Description("The card issuer has declined the transaction due to restrictions on where the\ncard can be used.  For example, a gift card is limited to a single merchant.")]
        CARDHOLDER_INSUFFICIENT_PERMISSIONS,
        ///<summary>
        ///The card was declined.
        ///</summary>
        [Description("The card was declined.")]
        CARD_DECLINED,
        ///<summary>
        ///The payment card was declined with a request for the card holder to call the issuer.
        ///</summary>
        [Description("The payment card was declined with a request for the card holder to call the issuer.")]
        CARD_DECLINED_CALL_ISSUER,
        ///<summary>
        ///The payment card was declined with a request for additional verification.
        ///</summary>
        [Description("The payment card was declined with a request for additional verification.")]
        CARD_DECLINED_VERIFICATION_REQUIRED,
        ///<summary>
        ///The card issuer declined the request because the card is expired.
        ///</summary>
        [Description("The card issuer declined the request because the card is expired.")]
        CARD_EXPIRED,
        ///<summary>
        ///The API request references an unsupported source type.
        ///</summary>
        [Description("The API request references an unsupported source type.")]
        CARD_MISMATCH,
        ///<summary>
        ///The card is not supported either in the geographic region or by the [merchant category code](https://developer.squareup.com/docs/locations-api#initialize-a-merchant-category-code) (MCC).
        ///</summary>
        [Description("The card is not supported either in the geographic region or by the [merchant category code](https://developer.squareup.com/docs/locations-api#initialize-a-merchant-category-code) (MCC).")]
        CARD_NOT_SUPPORTED,
        ///<summary>
        ///The transaction requires that a card be present.
        ///</summary>
        [Description("The transaction requires that a card be present.")]
        CARD_PRESENCE_REQUIRED,
        ///<summary>
        ///The location provided in the API call is not enabled for credit card processing.
        ///</summary>
        [Description("The location provided in the API call is not enabled for credit card processing.")]
        CARD_PROCESSING_NOT_ENABLED,
        ///<summary>
        ///The provided card token (nonce) has expired.
        ///</summary>
        [Description("The provided card token (nonce) has expired.")]
        CARD_TOKEN_EXPIRED,
        ///<summary>
        ///The provided card token (nonce) was already used to process the payment or refund.
        ///</summary>
        [Description("The provided card token (nonce) was already used to process the payment or refund.")]
        CARD_TOKEN_USED,
        ///<summary>
        ///The provided checkout URL has expired.
        ///</summary>
        [Description("The provided checkout URL has expired.")]
        CHECKOUT_EXPIRED,
        ///<summary>
        ///The card issuer requires that the card be read using a chip reader.
        ///</summary>
        [Description("The card issuer requires that the card be read using a chip reader.")]
        CHIP_INSERTION_REQUIRED,
        ///<summary>
        ///External clients are not supposed to see this response code as used to reflect
        ///when clients close the connection before we're able to serve a response.
        ///This non-standard response code was adopted by ngnix.
        ///</summary>
        [Description("External clients are not supposed to see this response code as used to reflect\nwhen clients close the connection before we're able to serve a response.\nThis non-standard response code was adopted by ngnix.")]
        CLIENT_CLOSED_REQUEST,
        ///<summary>
        ///The provided client has been disabled.
        ///</summary>
        [Description("The provided client has been disabled.")]
        CLIENT_DISABLED,
        ///<summary>
        ///The provided client is not supported.
        ///</summary>
        [Description("The provided client is not supported.")]
        CLIENT_NOT_SUPPORTED,
        ///<summary>
        ///Conflict - a general error occurred.
        ///</summary>
        [Description("Conflict - a general error occurred.")]
        CONFLICT,
        ///<summary>
        ///One or more of the request parameters conflict with each other.
        ///</summary>
        [Description("One or more of the request parameters conflict with each other.")]
        CONFLICTING_PARAMETERS,
        ///<summary>
        ///The currency associated with the payment is not valid for the provided funding
        ///source. For example, a gift card funded in USD cannot be used to process
        ///payments in GBP.
        ///</summary>
        [Description("The currency associated with the payment is not valid for the provided funding\nsource. For example, a gift card funded in USD cannot be used to process\npayments in GBP.")]
        CURRENCY_MISMATCH,
        ///<summary>
        ///The provided customer does not have a recorded email.
        ///</summary>
        [Description("The provided customer does not have a recorded email.")]
        CUSTOMER_MISSING_EMAIL,
        ///<summary>
        ///The provided customer does not have a recorded name.
        ///</summary>
        [Description("The provided customer does not have a recorded name.")]
        CUSTOMER_MISSING_NAME,
        ///<summary>
        ///The provided customer id can't be found in the merchant's customers list.
        ///</summary>
        [Description("The provided customer id can't be found in the merchant's customers list.")]
        CUSTOMER_NOT_FOUND,
        ///<summary>
        ///The card issuer declined the request because the CVV value is invalid.
        ///</summary>
        [Description("The card issuer declined the request because the CVV value is invalid.")]
        CVV_FAILURE,
        ///<summary>
        ///The application tried to cancel a delayed-capture payment that was already cancelled.
        ///</summary>
        [Description("The application tried to cancel a delayed-capture payment that was already cancelled.")]
        DELAYED_TRANSACTION_CANCELED,
        ///<summary>
        ///The application tried to capture a delayed-capture payment that was already captured.
        ///</summary>
        [Description("The application tried to capture a delayed-capture payment that was already captured.")]
        DELAYED_TRANSACTION_CAPTURED,
        ///<summary>
        ///The application tried to update a delayed-capture payment that has expired.
        ///</summary>
        [Description("The application tried to update a delayed-capture payment that has expired.")]
        DELAYED_TRANSACTION_EXPIRED,
        ///<summary>
        ///The application tried to update a delayed-capture payment that failed.
        ///</summary>
        [Description("The application tried to update a delayed-capture payment that failed.")]
        DELAYED_TRANSACTION_FAILED,
        ///<summary>
        ///Deprecated now means only that the field is listed as such in the API tech ref. This is not an error.
        ///</summary>
        [Description("Deprecated now means only that the field is listed as such in the API tech ref. This is not an error.")]
        DEPRECATED_FIELD_SET,
        ///<summary>
        ///The endpoint expected the provided value to be an array or list.
        ///</summary>
        [Description("The endpoint expected the provided value to be an array or list.")]
        EXPECTED_ARRAY,
        ///<summary>
        ///The endpoint expected the provided value to be an array encoded in base64.
        ///</summary>
        [Description("The endpoint expected the provided value to be an array encoded in base64.")]
        EXPECTED_BASE64_ENCODED_BYTE_ARRAY,
        ///<summary>
        ///The endpoint expected the provided value to be a boolean.
        ///</summary>
        [Description("The endpoint expected the provided value to be a boolean.")]
        EXPECTED_BOOLEAN,
        ///<summary>
        ///The endpoint expected the provided value to be a float.
        ///</summary>
        [Description("The endpoint expected the provided value to be a float.")]
        EXPECTED_FLOAT,
        ///<summary>
        ///The endpoint expected the provided value to be an integer.
        ///</summary>
        [Description("The endpoint expected the provided value to be an integer.")]
        EXPECTED_INTEGER,
        ///<summary>
        ///The request body is not a JSON object.
        ///</summary>
        [Description("The request body is not a JSON object.")]
        EXPECTED_JSON_BODY,
        ///<summary>
        ///The endpoint expected the provided value to be a map or associative array.
        ///</summary>
        [Description("The endpoint expected the provided value to be a map or associative array.")]
        EXPECTED_MAP,
        ///<summary>
        ///The endpoint expected the provided value to be a JSON object.
        ///</summary>
        [Description("The endpoint expected the provided value to be a JSON object.")]
        EXPECTED_OBJECT,
        ///<summary>
        ///The endpoint expected the provided value to be a string.
        ///</summary>
        [Description("The endpoint expected the provided value to be a string.")]
        EXPECTED_STRING,
        ///<summary>
        ///The card expiration date is either invalid or indicates that the card is expired.
        ///</summary>
        [Description("The card expiration date is either invalid or indicates that the card is expired.")]
        EXPIRATION_FAILURE,
        ///<summary>
        ///A general access error occurred.
        ///</summary>
        [Description("A general access error occurred.")]
        FORBIDDEN,
        ///<summary>
        ///Unable to re-assign preferences assignment. Preferences assignment is a write-once field.
        ///</summary>
        [Description("Unable to re-assign preferences assignment. Preferences assignment is a write-once field.")]
        FULFILLMENT_PREFERENCES_ASSIGNMENT_IS_IMMUTABLE,
        ///<summary>
        ///The provided preferences assignment types should be consistent within request
        ///</summary>
        [Description("The provided preferences assignment types should be consistent within request")]
        FULFILLMENT_PREFERENCES_CONFLICTING_ASSIGNMENT_TYPE,
        ///<summary>
        ///Fulfillment Preferences with fulfillment schedules cannot be assigned to a CATALOG_ITEM
        ///</summary>
        [Description("Fulfillment Preferences with fulfillment schedules cannot be assigned to a CATALOG_ITEM")]
        FULFILLMENT_PREFERENCES_FULFILLMENT_SCHEDULE_NOT_ALLOWED,
        ///<summary>
        ///Parameters being used for FulfillmentAvailabilityWindow object are not valid.
        ///</summary>
        [Description("Parameters being used for FulfillmentAvailabilityWindow object are not valid.")]
        FULFILLMENT_PREFERENCES_INVALID_FULFILLMENT_AVAILABILITY_WINDOW,
        ///<summary>
        ///The datetime value is not in the correct format per app business logic.
        ///</summary>
        [Description("The datetime value is not in the correct format per app business logic.")]
        FULFILLMENT_PREFERENCES_INVALID_SCHEDULING_DATETIME,
        ///<summary>
        ///This restricted date is a duplicate within the list.
        ///</summary>
        [Description("This restricted date is a duplicate within the list.")]
        FULFILLMENT_PREFERENCES_RESTRICTED_DATE_NOT_UNIQUE,
        ///<summary>
        ///Gateway Timeout - a general error occurred.
        ///</summary>
        [Description("Gateway Timeout - a general error occurred.")]
        GATEWAY_TIMEOUT,
        ///<summary>
        ///Square received a decline without any additional information.  If the payment
        ///information seems correct, the buyer can contact their issuer to ask for more information.
        ///</summary>
        [Description("Square received a decline without any additional information.  If the payment\ninformation seems correct, the buyer can contact their issuer to ask for more information.")]
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
        [Description("When a Gift Card is a payment source, you can allow taking a partial payment\nby adding the `accept_partial_authorization` parameter in the request.\nHowever, taking such a partial payment does not work if your request also includes\n`tipMoney`, `appFeeMoney`, or both. Square declines such payments and returns\nthe `GIFT_CARD_AVAILABLE_AMOUNT` error.\nFor more information, see\n[CreatePayment errors (additional information)](https://developer.squareup.com/docs/payments-api/error-codes#createpayment-errors-additional-information).")]
        GIFT_CARD_AVAILABLE_AMOUNT,
        ///<summary>
        ///The buyer attempting to add value to the gift card has reached daily purchase limits.
        ///</summary>
        [Description("The buyer attempting to add value to the gift card has reached daily purchase limits.")]
        GIFT_CARD_BUYER_DAILY_LIMIT_REACHED,
        ///<summary>
        ///The specified gift card amount is zero, negative, in the incorrect currency, or too large.
        ///</summary>
        [Description("The specified gift card amount is zero, negative, in the incorrect currency, or too large.")]
        GIFT_CARD_INVALID_AMOUNT,
        ///<summary>
        ///The gift card's maximum value has been reached.
        ///</summary>
        [Description("The gift card's maximum value has been reached.")]
        GIFT_CARD_MAX_VALUE_REACHED,
        ///<summary>
        ///The merchant's maximum total of outstanding gift card balances has been reached.
        ///</summary>
        [Description("The merchant's maximum total of outstanding gift card balances has been reached.")]
        GIFT_CARD_MERCHANT_MAX_OUTSTANDING_BALANCE_REACHED,
        ///<summary>
        ///Attempted to add an amount to a gift card that is beyond its limits.
        ///</summary>
        [Description("Attempted to add an amount to a gift card that is beyond its limits.")]
        GIFT_CARD_VALUE_ADDITION_LIMIT_REACHED,
        ///<summary>
        ///The target resource is no longer available and this condition is likely to be permanent.
        ///</summary>
        [Description("The target resource is no longer available and this condition is likely to be permanent.")]
        GONE,
        ///<summary>
        ///HTTPS only.
        ///</summary>
        [Description("HTTPS only.")]
        HTTPS_ONLY,
        ///<summary>
        ///The provided idempotency key has already been used.
        ///</summary>
        [Description("The provided idempotency key has already been used.")]
        IDEMPOTENCY_KEY_REUSED,
        ///<summary>
        ///The value provided in the request is the wrong type. For example, a string instead of an integer.
        ///</summary>
        [Description("The value provided in the request is the wrong type. For example, a string instead of an integer.")]
        INCORRECT_TYPE,
        ///<summary>
        ///The funding source has insufficient funds to cover the payment.
        ///</summary>
        [Description("The funding source has insufficient funds to cover the payment.")]
        INSUFFICIENT_FUNDS,
        ///<summary>
        ///The referenced inventory item has insufficient inventory.
        ///</summary>
        [Description("The referenced inventory item has insufficient inventory.")]
        INSUFFICIENT_INVENTORY,
        ///<summary>
        ///The Square account does not have the permissions to accept this payment. For
        ///example, Square may limit which merchants are allowed to receive gift card payments.
        ///</summary>
        [Description("The Square account does not have the permissions to accept this payment. For\nexample, Square may limit which merchants are allowed to receive gift card payments.")]
        INSUFFICIENT_PERMISSIONS,
        ///<summary>
        ///The Square account does not have the permissions to process this refund.
        ///</summary>
        [Description("The Square account does not have the permissions to process this refund.")]
        INSUFFICIENT_PERMISSIONS_FOR_REFUND,
        ///<summary>
        ///The provided access token does not have permission to execute the requested action.
        ///</summary>
        [Description("The provided access token does not have permission to execute the requested action.")]
        INSUFFICIENT_SCOPES,
        ///<summary>
        ///A general server error occurred.
        ///</summary>
        [Description("A general server error occurred.")]
        INTERNAL_SERVER_ERROR,
        ///<summary>
        ///The issuer was not able to locate the account on record.
        ///</summary>
        [Description("The issuer was not able to locate the account on record.")]
        INVALID_ACCOUNT,
        ///<summary>
        ///One or more objects in the array does not match the array type.
        ///</summary>
        [Description("One or more objects in the array does not match the array type.")]
        INVALID_ARRAY_VALUE,
        ///<summary>
        ///The credit card cannot be validated based on the provided details.
        ///</summary>
        [Description("The credit card cannot be validated based on the provided details.")]
        INVALID_CARD,
        ///<summary>
        ///Generic error - the provided card data is invalid.
        ///</summary>
        [Description("Generic error - the provided card data is invalid.")]
        INVALID_CARD_DATA,
        ///<summary>
        ///Invalid content type header.
        ///</summary>
        [Description("Invalid content type header.")]
        INVALID_CONTENT_TYPE,
        ///<summary>
        ///The pagination cursor included in the request is invalid.
        ///</summary>
        [Description("The pagination cursor included in the request is invalid.")]
        INVALID_CURSOR,
        ///<summary>
        ///The subscription cannot be paused/resumed on the given date.
        ///</summary>
        [Description("The subscription cannot be paused/resumed on the given date.")]
        INVALID_DATE,
        ///<summary>
        ///The provided email address is invalid.
        ///</summary>
        [Description("The provided email address is invalid.")]
        INVALID_EMAIL_ADDRESS,
        ///<summary>
        ///The encrypted card information is invalid.
        ///</summary>
        [Description("The encrypted card information is invalid.")]
        INVALID_ENCRYPTED_CARD,
        ///<summary>
        ///The provided static string is not valid for the field.
        ///</summary>
        [Description("The provided static string is not valid for the field.")]
        INVALID_ENUM_VALUE,
        ///<summary>
        ///The expiration date for the payment card is invalid. For example, it indicates a date in the past.
        ///</summary>
        [Description("The expiration date for the payment card is invalid. For example, it indicates a date in the past.")]
        INVALID_EXPIRATION,
        ///<summary>
        ///The expiration date for the payment card is invalid. For example, it contains invalid characters.
        ///</summary>
        [Description("The expiration date for the payment card is invalid. For example, it contains invalid characters.")]
        INVALID_EXPIRATION_DATE,
        ///<summary>
        ///The expiration year for the payment card is invalid. For example, it indicates
        ///a year in the past or contains invalid characters.
        ///</summary>
        [Description("The expiration year for the payment card is invalid. For example, it indicates\na year in the past or contains invalid characters.")]
        INVALID_EXPIRATION_YEAR,
        ///<summary>
        ///The app_fee_money on a payment is too high.
        ///</summary>
        [Description("The app_fee_money on a payment is too high.")]
        INVALID_FEES,
        ///<summary>
        ///Only relevant for applications created prior to 2016-03-30. Indicates there was an error while parsing form values.
        ///</summary>
        [Description("Only relevant for applications created prior to 2016-03-30. Indicates there was an error while parsing form values.")]
        INVALID_FORM_VALUE,
        ///<summary>
        ///The Square account cannot take payments in the specified region.  A Square
        ///account can take payments only from the region where the account was created.
        ///</summary>
        [Description("The Square account cannot take payments in the specified region.  A Square\naccount can take payments only from the region where the account was created.")]
        INVALID_LOCATION,
        ///<summary>
        ///The subscription cannot be paused longer than the duration of the current phase.
        ///</summary>
        [Description("The subscription cannot be paused longer than the duration of the current phase.")]
        INVALID_PAUSE_LENGTH,
        ///<summary>
        ///The provided phone number is invalid.
        ///</summary>
        [Description("The provided phone number is invalid.")]
        INVALID_PHONE_NUMBER,
        ///<summary>
        ///The card issuer declined the request because the PIN is invalid.
        ///</summary>
        [Description("The card issuer declined the request because the PIN is invalid.")]
        INVALID_PIN,
        ///<summary>
        ///The postal code is incorrectly formatted.
        ///</summary>
        [Description("The postal code is incorrectly formatted.")]
        INVALID_POSTAL_CODE,
        ///<summary>
        ///The provided sort order is not a valid key.  Currently, sort order must be `ASC` or `DESC`.
        ///</summary>
        [Description("The provided sort order is not a valid key.  Currently, sort order must be `ASC` or `DESC`.")]
        INVALID_SORT_ORDER,
        ///<summary>
        ///The provided Square-Version is incorrectly formatted.
        ///</summary>
        [Description("The provided Square-Version is incorrectly formatted.")]
        INVALID_SQUARE_VERSION_FORMAT,
        ///<summary>
        ///Formatting for the provided time value is incorrect.
        ///</summary>
        [Description("Formatting for the provided time value is incorrect.")]
        INVALID_TIME,
        ///<summary>
        ///Value is not a valid timezone.
        ///</summary>
        [Description("Value is not a valid timezone.")]
        INVALID_TIMEZONE,
        ///<summary>
        ///The time range provided in the request is invalid.  For example, the end time is before the start time.
        ///</summary>
        [Description("The time range provided in the request is invalid.  For example, the end time is before the start time.")]
        INVALID_TIME_RANGE,
        ///<summary>
        ///The provided API URL is invalid.
        ///</summary>
        [Description("The provided API URL is invalid.")]
        INVALID_URL,
        ///<summary>
        ///The provided value is invalid. For example, including `%` in a phone number.
        ///</summary>
        [Description("The provided value is invalid. For example, including `%` in a phone number.")]
        INVALID_VALUE,
        ///<summary>
        ///The verification code provided is invalid.
        ///</summary>
        [Description("The verification code provided is invalid.")]
        INVALID_VERIFICATION_CODE,
        ///<summary>
        ///There already exists a job template with the given name.
        ///</summary>
        [Description("There already exists a job template with the given name.")]
        JOB_TEMPLATE_NAME_TAKEN,
        ///<summary>
        ///Generic error - the given location does not matching what is expected.
        ///</summary>
        [Description("Generic error - the given location does not matching what is expected.")]
        LOCATION_MISMATCH,
        ///<summary>
        ///The card must be swiped, tapped, or dipped. Payments attempted by manually entering the card number are declined.
        ///</summary>
        [Description("The card must be swiped, tapped, or dipped. Payments attempted by manually entering the card number are declined.")]
        MANUALLY_ENTERED_PAYMENT_NOT_SUPPORTED,
        ///<summary>
        ///The length of one of the provided keys in the map is too long.
        ///</summary>
        [Description("The length of one of the provided keys in the map is too long.")]
        MAP_KEY_LENGTH_TOO_LONG,
        ///<summary>
        ///The length of one of the provided keys in the map is too short.
        ///</summary>
        [Description("The length of one of the provided keys in the map is too short.")]
        MAP_KEY_LENGTH_TOO_SHORT,
        ///<summary>
        ///A required subscription was not found for the merchant
        ///</summary>
        [Description("A required subscription was not found for the merchant")]
        MERCHANT_SUBSCRIPTION_NOT_FOUND,
        ///<summary>
        ///Method Not Allowed - a general error occurred.
        ///</summary>
        [Description("Method Not Allowed - a general error occurred.")]
        METHOD_NOT_ALLOWED,
        ///<summary>
        ///The payment is missing a required ACCOUNT_TYPE parameter.
        ///</summary>
        [Description("The payment is missing a required ACCOUNT_TYPE parameter.")]
        MISSING_ACCOUNT_TYPE,
        ///<summary>
        ///The payment is missing a required PIN.
        ///</summary>
        [Description("The payment is missing a required PIN.")]
        MISSING_PIN,
        ///<summary>
        ///The request is missing a required path, query, or body parameter.
        ///</summary>
        [Description("The request is missing a required path, query, or body parameter.")]
        MISSING_REQUIRED_PARAMETER,
        ///<summary>
        ///Not Acceptable - a general error occurred.
        ///</summary>
        [Description("Not Acceptable - a general error occurred.")]
        NOT_ACCEPTABLE,
        ///<summary>
        ///Not Found - a general error occurred.
        ///</summary>
        [Description("Not Found - a general error occurred.")]
        NOT_FOUND,
        ///<summary>
        ///Not Implemented - a general error occurred.
        ///</summary>
        [Description("Not Implemented - a general error occurred.")]
        NOT_IMPLEMENTED,
        ///<summary>
        ///A general error occurred.
        ///</summary>
        [Description("A general error occurred.")]
        NO_FIELDS_SET,
        ///<summary>
        ///A general error occurred.
        ///</summary>
        [Description("A general error occurred.")]
        ONE_INSTRUMENT_EXPECTED,
        ///<summary>
        ///The order was already used.
        ///</summary>
        [Description("The order was already used.")]
        ORDER_ALREADY_USED,
        ///<summary>
        ///The requested order has expired and cannot be updated.
        ///</summary>
        [Description("The requested order has expired and cannot be updated.")]
        ORDER_EXPIRED,
        ///<summary>
        ///The creation request contains too many catalog IDs.
        ///</summary>
        [Description("The creation request contains too many catalog IDs.")]
        ORDER_TOO_MANY_CATALOG_OBJECTS,
        ///<summary>
        ///The specified card number is invalid. For example, it is of incorrect length or is incorrectly formatted.
        ///</summary>
        [Description("The specified card number is invalid. For example, it is of incorrect length or is incorrectly formatted.")]
        PAN_FAILURE,
        ///<summary>
        ///The payment was declined because there was a payment amount mismatch.  The
        ///money amount Square was expecting does not match the amount provided.
        ///</summary>
        [Description("The payment was declined because there was a payment amount mismatch.  The\nmoney amount Square was expecting does not match the amount provided.")]
        PAYMENT_AMOUNT_MISMATCH,
        ///<summary>
        ///Square declined the request because the payment amount exceeded the processing limit for this merchant.
        ///</summary>
        [Description("Square declined the request because the payment amount exceeded the processing limit for this merchant.")]
        PAYMENT_LIMIT_EXCEEDED,
        ///<summary>
        ///The payment is not refundable. For example, the payment has been disputed and is no longer eligible for refunds.
        ///</summary>
        [Description("The payment is not refundable. For example, the payment has been disputed and is no longer eligible for refunds.")]
        PAYMENT_NOT_REFUNDABLE,
        ///<summary>
        ///Generic plaid error.
        ///</summary>
        [Description("Generic plaid error.")]
        PLAID_ERROR,
        ///<summary>
        ///Plaid error - ITEM_LOGIN_REQUIRED.
        ///</summary>
        [Description("Plaid error - ITEM_LOGIN_REQUIRED.")]
        PLAID_ERROR_ITEM_LOGIN_REQUIRED,
        ///<summary>
        ///Plaid error - RATE_LIMIT.
        ///</summary>
        [Description("Plaid error - RATE_LIMIT.")]
        PLAID_ERROR_RATE_LIMIT,
        ///<summary>
        ///There is a price mismatch.
        ///</summary>
        [Description("There is a price mismatch.")]
        PRICE_MISMATCH,
        ///<summary>
        ///Rate Limited - a general error occurred.
        ///</summary>
        [Description("Rate Limited - a general error occurred.")]
        RATE_LIMITED,
        ///<summary>
        ///The payment already has a pending refund.
        ///</summary>
        [Description("The payment already has a pending refund.")]
        REFUND_ALREADY_PENDING,
        ///<summary>
        ///The requested refund amount exceeds the amount available to refund.
        ///</summary>
        [Description("The requested refund amount exceeds the amount available to refund.")]
        REFUND_AMOUNT_INVALID,
        ///<summary>
        ///Request failed - The card issuer declined the refund.
        ///</summary>
        [Description("Request failed - The card issuer declined the refund.")]
        REFUND_DECLINED,
        ///<summary>
        ///Request Entity Too Large - a general error occurred.
        ///</summary>
        [Description("Request Entity Too Large - a general error occurred.")]
        REQUEST_ENTITY_TOO_LARGE,
        ///<summary>
        ///Request Timeout - a general error occurred.
        ///</summary>
        [Description("Request Timeout - a general error occurred.")]
        REQUEST_TIMEOUT,
        ///<summary>
        ///The card issuer declined the refund.
        ///</summary>
        [Description("The card issuer declined the refund.")]
        RESERVATION_DECLINED,
        ///<summary>
        ///The fields are not accessible at the request api version. Use API_VERSION_INCOMPATIBLE instead.
        ///</summary>
        [Description("The fields are not accessible at the request api version. Use API_VERSION_INCOMPATIBLE instead.")]
        RETIRED_FIELD_SET,
        ///<summary>
        ///The API request is not supported in sandbox.
        ///</summary>
        [Description("The API request is not supported in sandbox.")]
        SANDBOX_NOT_SUPPORTED,
        ///<summary>
        ///Service Unavailable - a general error occurred.
        ///</summary>
        [Description("Service Unavailable - a general error occurred.")]
        SERVICE_UNAVAILABLE,
        ///<summary>
        ///A session associated with the payment has expired.
        ///</summary>
        [Description("A session associated with the payment has expired.")]
        SESSION_EXPIRED,
        ///<summary>
        ///The provided source id has expired.
        ///</summary>
        [Description("The provided source id has expired.")]
        SOURCE_EXPIRED,
        ///<summary>
        ///The provided source id was already used to create a card.
        ///</summary>
        [Description("The provided source id was already used to create a card.")]
        SOURCE_USED,
        ///<summary>
        ///A temporary internal error occurred. You can safely retry your call using the same idempotency key.
        ///</summary>
        [Description("A temporary internal error occurred. You can safely retry your call using the same idempotency key.")]
        TEMPORARY_ERROR,
        ///<summary>
        ///Too many entries in the map field.
        ///</summary>
        [Description("Too many entries in the map field.")]
        TOO_MANY_MAP_ENTRIES,
        ///<summary>
        ///The card issuer has determined the payment amount is either too high or too low.
        ///The API returns the error code mostly for credit cards (for example, the card reached
        ///the credit limit). However, sometimes the issuer bank can indicate the error for debit
        ///or prepaid cards (for example, card has insufficient funds).
        ///</summary>
        [Description("The card issuer has determined the payment amount is either too high or too low.\nThe API returns the error code mostly for credit cards (for example, the card reached\nthe credit limit). However, sometimes the issuer bank can indicate the error for debit\nor prepaid cards (for example, card has insufficient funds).")]
        TRANSACTION_LIMIT,
        ///<summary>
        ///A general authorization error occurred.
        ///</summary>
        [Description("A general authorization error occurred.")]
        UNAUTHORIZED,
        ///<summary>
        ///General error - the value provided was unexpected.
        ///</summary>
        [Description("General error - the value provided was unexpected.")]
        UNEXPECTED_VALUE,
        ///<summary>
        ///The body parameter is not recognized by the requested endpoint.
        ///</summary>
        [Description("The body parameter is not recognized by the requested endpoint.")]
        UNKNOWN_BODY_PARAMETER,
        ///<summary>
        ///The query parameters provided is invalid for the requested endpoint.
        ///</summary>
        [Description("The query parameters provided is invalid for the requested endpoint.")]
        UNKNOWN_QUERY_PARAMETER,
        ///<summary>
        ///Unprocessable Entity - a general error occurred.
        ///</summary>
        [Description("Unprocessable Entity - a general error occurred.")]
        UNPROCESSABLE_ENTITY,
        ///<summary>
        ///The provided URL is unreachable.
        ///</summary>
        [Description("The provided URL is unreachable.")]
        UNREACHABLE_URL,
        ///<summary>
        ///The credit card provided is not from a supported issuer.
        ///</summary>
        [Description("The credit card provided is not from a supported issuer.")]
        UNSUPPORTED_CARD_BRAND,
        ///<summary>
        ///The API request references an unsupported country.
        ///</summary>
        [Description("The API request references an unsupported country.")]
        UNSUPPORTED_COUNTRY,
        ///<summary>
        ///The API request references an unsupported currency.
        ///</summary>
        [Description("The API request references an unsupported currency.")]
        UNSUPPORTED_CURRENCY,
        ///<summary>
        ///The entry method for the credit card (swipe, dip, tap) is not supported.
        ///</summary>
        [Description("The entry method for the credit card (swipe, dip, tap) is not supported.")]
        UNSUPPORTED_ENTRY_METHOD,
        ///<summary>
        ///The API request references an unsupported instrument type/
        ///</summary>
        [Description("The API request references an unsupported instrument type/")]
        UNSUPPORTED_INSTRUMENT_TYPE,
        ///<summary>
        ///The referenced loyalty program reward tier is not supported.  This could
        ///happen if the reward tier created in a first party application is incompatible
        ///with the Loyalty API.
        ///</summary>
        [Description("The referenced loyalty program reward tier is not supported.  This could\nhappen if the reward tier created in a first party application is incompatible\nwith the Loyalty API.")]
        UNSUPPORTED_LOYALTY_REWARD_TIER,
        ///<summary>
        ///Unsupported Media Type - a general error occurred.
        ///</summary>
        [Description("Unsupported Media Type - a general error occurred.")]
        UNSUPPORTED_MEDIA_TYPE,
        ///<summary>
        ///The API request references an unsupported source type.
        ///</summary>
        [Description("The API request references an unsupported source type.")]
        UNSUPPORTED_SOURCE_TYPE,
        ///<summary>
        ///The calling application is using an access token created prior to 2016-03-30
        ///and is not compatible with v2 Square API calls.
        ///</summary>
        [Description("The calling application is using an access token created prior to 2016-03-30\nand is not compatible with v2 Square API calls.")]
        V1_ACCESS_TOKEN,
        ///<summary>
        ///The calling application was created prior to 2016-03-30 and is not compatible with v2 Square API calls.
        ///</summary>
        [Description("The calling application was created prior to 2016-03-30 and is not compatible with v2 Square API calls.")]
        V1_APPLICATION,
        ///<summary>
        ///The provided value has a default (empty) value such as a blank string.
        ///</summary>
        [Description("The provided value has a default (empty) value such as a blank string.")]
        VALUE_EMPTY,
        ///<summary>
        ///The provided value does not match an expected regular expression.
        ///</summary>
        [Description("The provided value does not match an expected regular expression.")]
        VALUE_REGEX_MISMATCH,
        ///<summary>
        ///The provided value is greater than the supported maximum.
        ///</summary>
        [Description("The provided value is greater than the supported maximum.")]
        VALUE_TOO_HIGH,
        ///<summary>
        ///The provided string value is longer than the maximum length allowed.
        ///</summary>
        [Description("The provided string value is longer than the maximum length allowed.")]
        VALUE_TOO_LONG,
        ///<summary>
        ///The provided value is less than the supported minimum.
        ///</summary>
        [Description("The provided value is less than the supported minimum.")]
        VALUE_TOO_LOW,
        ///<summary>
        ///The provided string value is shorter than the minimum length allowed.
        ///</summary>
        [Description("The provided string value is shorter than the minimum length allowed.")]
        VALUE_TOO_SHORT,
        ///<summary>
        ///The AVS could not be verified.
        ///</summary>
        [Description("The AVS could not be verified.")]
        VERIFY_AVS_FAILURE,
        ///<summary>
        ///The CVV could not be verified.
        ///</summary>
        [Description("The CVV could not be verified.")]
        VERIFY_CVV_FAILURE,
        ///<summary>
        ///The provided object version does not match the expected value.
        ///</summary>
        [Description("The provided object version does not match the expected value.")]
        VERSION_MISMATCH,
        ///<summary>
        ///The card issuer declined the request because the issuer requires voice authorization from the cardholder.
        ///</summary>
        [Description("The card issuer declined the request because the issuer requires voice authorization from the cardholder.")]
        VOICE_FAILURE,
    }

    public static class ErrorCodeStringValues
    {
        public const string ACCESS_TOKEN_EXPIRED = @"ACCESS_TOKEN_EXPIRED";
        public const string ACCESS_TOKEN_REVOKED = @"ACCESS_TOKEN_REVOKED";
        public const string ACCOUNT_UNUSABLE = @"ACCOUNT_UNUSABLE";
        public const string ADDRESS_VERIFICATION_FAILURE = @"ADDRESS_VERIFICATION_FAILURE";
        public const string ALLOWABLE_PIN_TRIES_EXCEEDED = @"ALLOWABLE_PIN_TRIES_EXCEEDED";
        public const string AMOUNT_TOO_HIGH = @"AMOUNT_TOO_HIGH";
        public const string API_VERSION_INCOMPATIBLE = @"API_VERSION_INCOMPATIBLE";
        public const string APPLE_PAYMENT_PROCESSING_CERTIFICATE_HASH_NOT_FOUND = @"APPLE_PAYMENT_PROCESSING_CERTIFICATE_HASH_NOT_FOUND";
        public const string APPLE_TTP_PIN_TOKEN = @"APPLE_TTP_PIN_TOKEN";
        public const string APPLICATION_DISABLED = @"APPLICATION_DISABLED";
        public const string ARRAY_EMPTY = @"ARRAY_EMPTY";
        public const string ARRAY_LENGTH_TOO_LONG = @"ARRAY_LENGTH_TOO_LONG";
        public const string ARRAY_LENGTH_TOO_SHORT = @"ARRAY_LENGTH_TOO_SHORT";
        public const string BAD_CERTIFICATE = @"BAD_CERTIFICATE";
        public const string BAD_EXPIRATION = @"BAD_EXPIRATION";
        public const string BAD_GATEWAY = @"BAD_GATEWAY";
        public const string BAD_REQUEST = @"BAD_REQUEST";
        public const string BLOCKED_BY_BLOCKLIST = @"BLOCKED_BY_BLOCKLIST";
        public const string BUYER_NOT_FOUND = @"BUYER_NOT_FOUND";
        public const string BUYER_REFUSED_PAYMENT = @"BUYER_REFUSED_PAYMENT";
        public const string CALCULATE_FULFILLMENT_RATES_FULFILLMENT_TYPE_NOT_SUPPORTED = @"CALCULATE_FULFILLMENT_RATES_FULFILLMENT_TYPE_NOT_SUPPORTED";
        public const string CALCULATE_FULFILLMENT_RATES_INVALID_RECIPIENT_ADDRESS = @"CALCULATE_FULFILLMENT_RATES_INVALID_RECIPIENT_ADDRESS";
        public const string CALCULATE_FULFILLMENT_RATES_NO_PROFILES_CONFIGURED = @"CALCULATE_FULFILLMENT_RATES_NO_PROFILES_CONFIGURED";
        public const string CALCULATE_FULFILLMENT_RATES_SHIPMENT_DESTINATION_NOT_CONFIGURED = @"CALCULATE_FULFILLMENT_RATES_SHIPMENT_DESTINATION_NOT_CONFIGURED";
        public const string CARDHOLDER_INSUFFICIENT_PERMISSIONS = @"CARDHOLDER_INSUFFICIENT_PERMISSIONS";
        public const string CARD_DECLINED = @"CARD_DECLINED";
        public const string CARD_DECLINED_CALL_ISSUER = @"CARD_DECLINED_CALL_ISSUER";
        public const string CARD_DECLINED_VERIFICATION_REQUIRED = @"CARD_DECLINED_VERIFICATION_REQUIRED";
        public const string CARD_EXPIRED = @"CARD_EXPIRED";
        public const string CARD_MISMATCH = @"CARD_MISMATCH";
        public const string CARD_NOT_SUPPORTED = @"CARD_NOT_SUPPORTED";
        public const string CARD_PRESENCE_REQUIRED = @"CARD_PRESENCE_REQUIRED";
        public const string CARD_PROCESSING_NOT_ENABLED = @"CARD_PROCESSING_NOT_ENABLED";
        public const string CARD_TOKEN_EXPIRED = @"CARD_TOKEN_EXPIRED";
        public const string CARD_TOKEN_USED = @"CARD_TOKEN_USED";
        public const string CHECKOUT_EXPIRED = @"CHECKOUT_EXPIRED";
        public const string CHIP_INSERTION_REQUIRED = @"CHIP_INSERTION_REQUIRED";
        public const string CLIENT_CLOSED_REQUEST = @"CLIENT_CLOSED_REQUEST";
        public const string CLIENT_DISABLED = @"CLIENT_DISABLED";
        public const string CLIENT_NOT_SUPPORTED = @"CLIENT_NOT_SUPPORTED";
        public const string CONFLICT = @"CONFLICT";
        public const string CONFLICTING_PARAMETERS = @"CONFLICTING_PARAMETERS";
        public const string CURRENCY_MISMATCH = @"CURRENCY_MISMATCH";
        public const string CUSTOMER_MISSING_EMAIL = @"CUSTOMER_MISSING_EMAIL";
        public const string CUSTOMER_MISSING_NAME = @"CUSTOMER_MISSING_NAME";
        public const string CUSTOMER_NOT_FOUND = @"CUSTOMER_NOT_FOUND";
        public const string CVV_FAILURE = @"CVV_FAILURE";
        public const string DELAYED_TRANSACTION_CANCELED = @"DELAYED_TRANSACTION_CANCELED";
        public const string DELAYED_TRANSACTION_CAPTURED = @"DELAYED_TRANSACTION_CAPTURED";
        public const string DELAYED_TRANSACTION_EXPIRED = @"DELAYED_TRANSACTION_EXPIRED";
        public const string DELAYED_TRANSACTION_FAILED = @"DELAYED_TRANSACTION_FAILED";
        public const string DEPRECATED_FIELD_SET = @"DEPRECATED_FIELD_SET";
        public const string EXPECTED_ARRAY = @"EXPECTED_ARRAY";
        public const string EXPECTED_BASE64_ENCODED_BYTE_ARRAY = @"EXPECTED_BASE64_ENCODED_BYTE_ARRAY";
        public const string EXPECTED_BOOLEAN = @"EXPECTED_BOOLEAN";
        public const string EXPECTED_FLOAT = @"EXPECTED_FLOAT";
        public const string EXPECTED_INTEGER = @"EXPECTED_INTEGER";
        public const string EXPECTED_JSON_BODY = @"EXPECTED_JSON_BODY";
        public const string EXPECTED_MAP = @"EXPECTED_MAP";
        public const string EXPECTED_OBJECT = @"EXPECTED_OBJECT";
        public const string EXPECTED_STRING = @"EXPECTED_STRING";
        public const string EXPIRATION_FAILURE = @"EXPIRATION_FAILURE";
        public const string FORBIDDEN = @"FORBIDDEN";
        public const string FULFILLMENT_PREFERENCES_ASSIGNMENT_IS_IMMUTABLE = @"FULFILLMENT_PREFERENCES_ASSIGNMENT_IS_IMMUTABLE";
        public const string FULFILLMENT_PREFERENCES_CONFLICTING_ASSIGNMENT_TYPE = @"FULFILLMENT_PREFERENCES_CONFLICTING_ASSIGNMENT_TYPE";
        public const string FULFILLMENT_PREFERENCES_FULFILLMENT_SCHEDULE_NOT_ALLOWED = @"FULFILLMENT_PREFERENCES_FULFILLMENT_SCHEDULE_NOT_ALLOWED";
        public const string FULFILLMENT_PREFERENCES_INVALID_FULFILLMENT_AVAILABILITY_WINDOW = @"FULFILLMENT_PREFERENCES_INVALID_FULFILLMENT_AVAILABILITY_WINDOW";
        public const string FULFILLMENT_PREFERENCES_INVALID_SCHEDULING_DATETIME = @"FULFILLMENT_PREFERENCES_INVALID_SCHEDULING_DATETIME";
        public const string FULFILLMENT_PREFERENCES_RESTRICTED_DATE_NOT_UNIQUE = @"FULFILLMENT_PREFERENCES_RESTRICTED_DATE_NOT_UNIQUE";
        public const string GATEWAY_TIMEOUT = @"GATEWAY_TIMEOUT";
        public const string GENERIC_DECLINE = @"GENERIC_DECLINE";
        public const string GIFT_CARD_AVAILABLE_AMOUNT = @"GIFT_CARD_AVAILABLE_AMOUNT";
        public const string GIFT_CARD_BUYER_DAILY_LIMIT_REACHED = @"GIFT_CARD_BUYER_DAILY_LIMIT_REACHED";
        public const string GIFT_CARD_INVALID_AMOUNT = @"GIFT_CARD_INVALID_AMOUNT";
        public const string GIFT_CARD_MAX_VALUE_REACHED = @"GIFT_CARD_MAX_VALUE_REACHED";
        public const string GIFT_CARD_MERCHANT_MAX_OUTSTANDING_BALANCE_REACHED = @"GIFT_CARD_MERCHANT_MAX_OUTSTANDING_BALANCE_REACHED";
        public const string GIFT_CARD_VALUE_ADDITION_LIMIT_REACHED = @"GIFT_CARD_VALUE_ADDITION_LIMIT_REACHED";
        public const string GONE = @"GONE";
        public const string HTTPS_ONLY = @"HTTPS_ONLY";
        public const string IDEMPOTENCY_KEY_REUSED = @"IDEMPOTENCY_KEY_REUSED";
        public const string INCORRECT_TYPE = @"INCORRECT_TYPE";
        public const string INSUFFICIENT_FUNDS = @"INSUFFICIENT_FUNDS";
        public const string INSUFFICIENT_INVENTORY = @"INSUFFICIENT_INVENTORY";
        public const string INSUFFICIENT_PERMISSIONS = @"INSUFFICIENT_PERMISSIONS";
        public const string INSUFFICIENT_PERMISSIONS_FOR_REFUND = @"INSUFFICIENT_PERMISSIONS_FOR_REFUND";
        public const string INSUFFICIENT_SCOPES = @"INSUFFICIENT_SCOPES";
        public const string INTERNAL_SERVER_ERROR = @"INTERNAL_SERVER_ERROR";
        public const string INVALID_ACCOUNT = @"INVALID_ACCOUNT";
        public const string INVALID_ARRAY_VALUE = @"INVALID_ARRAY_VALUE";
        public const string INVALID_CARD = @"INVALID_CARD";
        public const string INVALID_CARD_DATA = @"INVALID_CARD_DATA";
        public const string INVALID_CONTENT_TYPE = @"INVALID_CONTENT_TYPE";
        public const string INVALID_CURSOR = @"INVALID_CURSOR";
        public const string INVALID_DATE = @"INVALID_DATE";
        public const string INVALID_EMAIL_ADDRESS = @"INVALID_EMAIL_ADDRESS";
        public const string INVALID_ENCRYPTED_CARD = @"INVALID_ENCRYPTED_CARD";
        public const string INVALID_ENUM_VALUE = @"INVALID_ENUM_VALUE";
        public const string INVALID_EXPIRATION = @"INVALID_EXPIRATION";
        public const string INVALID_EXPIRATION_DATE = @"INVALID_EXPIRATION_DATE";
        public const string INVALID_EXPIRATION_YEAR = @"INVALID_EXPIRATION_YEAR";
        public const string INVALID_FEES = @"INVALID_FEES";
        public const string INVALID_FORM_VALUE = @"INVALID_FORM_VALUE";
        public const string INVALID_LOCATION = @"INVALID_LOCATION";
        public const string INVALID_PAUSE_LENGTH = @"INVALID_PAUSE_LENGTH";
        public const string INVALID_PHONE_NUMBER = @"INVALID_PHONE_NUMBER";
        public const string INVALID_PIN = @"INVALID_PIN";
        public const string INVALID_POSTAL_CODE = @"INVALID_POSTAL_CODE";
        public const string INVALID_SORT_ORDER = @"INVALID_SORT_ORDER";
        public const string INVALID_SQUARE_VERSION_FORMAT = @"INVALID_SQUARE_VERSION_FORMAT";
        public const string INVALID_TIME = @"INVALID_TIME";
        public const string INVALID_TIMEZONE = @"INVALID_TIMEZONE";
        public const string INVALID_TIME_RANGE = @"INVALID_TIME_RANGE";
        public const string INVALID_URL = @"INVALID_URL";
        public const string INVALID_VALUE = @"INVALID_VALUE";
        public const string INVALID_VERIFICATION_CODE = @"INVALID_VERIFICATION_CODE";
        public const string JOB_TEMPLATE_NAME_TAKEN = @"JOB_TEMPLATE_NAME_TAKEN";
        public const string LOCATION_MISMATCH = @"LOCATION_MISMATCH";
        public const string MANUALLY_ENTERED_PAYMENT_NOT_SUPPORTED = @"MANUALLY_ENTERED_PAYMENT_NOT_SUPPORTED";
        public const string MAP_KEY_LENGTH_TOO_LONG = @"MAP_KEY_LENGTH_TOO_LONG";
        public const string MAP_KEY_LENGTH_TOO_SHORT = @"MAP_KEY_LENGTH_TOO_SHORT";
        public const string MERCHANT_SUBSCRIPTION_NOT_FOUND = @"MERCHANT_SUBSCRIPTION_NOT_FOUND";
        public const string METHOD_NOT_ALLOWED = @"METHOD_NOT_ALLOWED";
        public const string MISSING_ACCOUNT_TYPE = @"MISSING_ACCOUNT_TYPE";
        public const string MISSING_PIN = @"MISSING_PIN";
        public const string MISSING_REQUIRED_PARAMETER = @"MISSING_REQUIRED_PARAMETER";
        public const string NOT_ACCEPTABLE = @"NOT_ACCEPTABLE";
        public const string NOT_FOUND = @"NOT_FOUND";
        public const string NOT_IMPLEMENTED = @"NOT_IMPLEMENTED";
        public const string NO_FIELDS_SET = @"NO_FIELDS_SET";
        public const string ONE_INSTRUMENT_EXPECTED = @"ONE_INSTRUMENT_EXPECTED";
        public const string ORDER_ALREADY_USED = @"ORDER_ALREADY_USED";
        public const string ORDER_EXPIRED = @"ORDER_EXPIRED";
        public const string ORDER_TOO_MANY_CATALOG_OBJECTS = @"ORDER_TOO_MANY_CATALOG_OBJECTS";
        public const string PAN_FAILURE = @"PAN_FAILURE";
        public const string PAYMENT_AMOUNT_MISMATCH = @"PAYMENT_AMOUNT_MISMATCH";
        public const string PAYMENT_LIMIT_EXCEEDED = @"PAYMENT_LIMIT_EXCEEDED";
        public const string PAYMENT_NOT_REFUNDABLE = @"PAYMENT_NOT_REFUNDABLE";
        public const string PLAID_ERROR = @"PLAID_ERROR";
        public const string PLAID_ERROR_ITEM_LOGIN_REQUIRED = @"PLAID_ERROR_ITEM_LOGIN_REQUIRED";
        public const string PLAID_ERROR_RATE_LIMIT = @"PLAID_ERROR_RATE_LIMIT";
        public const string PRICE_MISMATCH = @"PRICE_MISMATCH";
        public const string RATE_LIMITED = @"RATE_LIMITED";
        public const string REFUND_ALREADY_PENDING = @"REFUND_ALREADY_PENDING";
        public const string REFUND_AMOUNT_INVALID = @"REFUND_AMOUNT_INVALID";
        public const string REFUND_DECLINED = @"REFUND_DECLINED";
        public const string REQUEST_ENTITY_TOO_LARGE = @"REQUEST_ENTITY_TOO_LARGE";
        public const string REQUEST_TIMEOUT = @"REQUEST_TIMEOUT";
        public const string RESERVATION_DECLINED = @"RESERVATION_DECLINED";
        public const string RETIRED_FIELD_SET = @"RETIRED_FIELD_SET";
        public const string SANDBOX_NOT_SUPPORTED = @"SANDBOX_NOT_SUPPORTED";
        public const string SERVICE_UNAVAILABLE = @"SERVICE_UNAVAILABLE";
        public const string SESSION_EXPIRED = @"SESSION_EXPIRED";
        public const string SOURCE_EXPIRED = @"SOURCE_EXPIRED";
        public const string SOURCE_USED = @"SOURCE_USED";
        public const string TEMPORARY_ERROR = @"TEMPORARY_ERROR";
        public const string TOO_MANY_MAP_ENTRIES = @"TOO_MANY_MAP_ENTRIES";
        public const string TRANSACTION_LIMIT = @"TRANSACTION_LIMIT";
        public const string UNAUTHORIZED = @"UNAUTHORIZED";
        public const string UNEXPECTED_VALUE = @"UNEXPECTED_VALUE";
        public const string UNKNOWN_BODY_PARAMETER = @"UNKNOWN_BODY_PARAMETER";
        public const string UNKNOWN_QUERY_PARAMETER = @"UNKNOWN_QUERY_PARAMETER";
        public const string UNPROCESSABLE_ENTITY = @"UNPROCESSABLE_ENTITY";
        public const string UNREACHABLE_URL = @"UNREACHABLE_URL";
        public const string UNSUPPORTED_CARD_BRAND = @"UNSUPPORTED_CARD_BRAND";
        public const string UNSUPPORTED_COUNTRY = @"UNSUPPORTED_COUNTRY";
        public const string UNSUPPORTED_CURRENCY = @"UNSUPPORTED_CURRENCY";
        public const string UNSUPPORTED_ENTRY_METHOD = @"UNSUPPORTED_ENTRY_METHOD";
        public const string UNSUPPORTED_INSTRUMENT_TYPE = @"UNSUPPORTED_INSTRUMENT_TYPE";
        public const string UNSUPPORTED_LOYALTY_REWARD_TIER = @"UNSUPPORTED_LOYALTY_REWARD_TIER";
        public const string UNSUPPORTED_MEDIA_TYPE = @"UNSUPPORTED_MEDIA_TYPE";
        public const string UNSUPPORTED_SOURCE_TYPE = @"UNSUPPORTED_SOURCE_TYPE";
        public const string V1_ACCESS_TOKEN = @"V1_ACCESS_TOKEN";
        public const string V1_APPLICATION = @"V1_APPLICATION";
        public const string VALUE_EMPTY = @"VALUE_EMPTY";
        public const string VALUE_REGEX_MISMATCH = @"VALUE_REGEX_MISMATCH";
        public const string VALUE_TOO_HIGH = @"VALUE_TOO_HIGH";
        public const string VALUE_TOO_LONG = @"VALUE_TOO_LONG";
        public const string VALUE_TOO_LOW = @"VALUE_TOO_LOW";
        public const string VALUE_TOO_SHORT = @"VALUE_TOO_SHORT";
        public const string VERIFY_AVS_FAILURE = @"VERIFY_AVS_FAILURE";
        public const string VERIFY_CVV_FAILURE = @"VERIFY_CVV_FAILURE";
        public const string VERSION_MISMATCH = @"VERSION_MISMATCH";
        public const string VOICE_FAILURE = @"VOICE_FAILURE";
    }

    ///<summary>
    ///Indicates which products matched by a CatalogPricingRule
    ///will be excluded if the pricing rule uses an exclude set.
    ///</summary>
    [Description("Indicates which products matched by a CatalogPricingRule\nwill be excluded if the pricing rule uses an exclude set.")]
    public enum ExcludeStrategy
    {
        ///<summary>
        ///The least expensive matched products are excluded from the pricing. If
        ///the pricing rule is set to exclude one product and multiple products in the
        ///match set qualify as least expensive, then one will be excluded at random.
        ///
        ///Excluding the least expensive product gives the best discount value to the buyer.
        ///</summary>
        [Description("The least expensive matched products are excluded from the pricing. If\nthe pricing rule is set to exclude one product and multiple products in the\nmatch set qualify as least expensive, then one will be excluded at random.\n\nExcluding the least expensive product gives the best discount value to the buyer.")]
        LEAST_EXPENSIVE,
        ///<summary>
        ///The most expensive matched product is excluded from the pricing rule.
        ///If multiple products have the same price and all qualify as least expensive,
        ///one will be excluded at random.
        ///
        ///This guarantees that the most expensive product is purchased at full price.
        ///</summary>
        [Description("The most expensive matched product is excluded from the pricing rule.\nIf multiple products have the same price and all qualify as least expensive,\none will be excluded at random.\n\nThis guarantees that the most expensive product is purchased at full price.")]
        MOST_EXPENSIVE,
    }

    public static class ExcludeStrategyStringValues
    {
        public const string LEAST_EXPENSIVE = @"LEAST_EXPENSIVE";
        public const string MOST_EXPENSIVE = @"MOST_EXPENSIVE";
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Stores details about an external payment. Contains only non-confidential information.
    ///For more information, see
    ///[Take External Payments](https://developer.squareup.com/docs/payments-api/take-payments/external-payments).
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nStores details about an external payment. Contains only non-confidential information.\nFor more information, see\n[Take External Payments](https://developer.squareup.com/docs/payments-api/take-payments/external-payments).")]
    public class ExternalPaymentDetails : GraphQLObject<ExternalPaymentDetails>
    {
        ///<summary>
        ///A description of the external payment source. For example, "Food Delivery Service".
        ///</summary>
        [Description("A description of the external payment source. For example, \"Food Delivery Service\".")]
        public string? source { get; set; }

        ///<summary>
        ///The fees paid to the source. The `amountMoney` minus this field is the net amount seller receives.
        ///</summary>
        [Description("The fees paid to the source. The `amountMoney` minus this field is the net amount seller receives.")]
        public Money? sourceFeeMoney { get; set; }

        ///<summary>
        ///An ID to associate the payment to its originating source.
        ///</summary>
        [Description("An ID to associate the payment to its originating source.")]
        public string? sourceId { get; set; }

        ///<summary>
        ///The type of external payment the seller received.
        ///</summary>
        [Description("The type of external payment the seller received.")]
        public ExternalPaymentType? type { get; set; }
    }

    ///<summary>
    ///The type of external payment the seller received.
    ///</summary>
    [Description("The type of external payment the seller received.")]
    public enum ExternalPaymentType
    {
        ///<summary>
        ///Paid using external bank transfer.
        ///</summary>
        [Description("Paid using external bank transfer.")]
        BANK_TRANSFER,
        ///<summary>
        ///A credit or debit card that Square does not support.
        ///</summary>
        [Description("A credit or debit card that Square does not support.")]
        CARD,
        ///<summary>
        ///Paid using a physical check.
        ///</summary>
        [Description("Paid using a physical check.")]
        CHECK,
        ///<summary>
        ///Paid using a crypto currency.
        ///</summary>
        [Description("Paid using a crypto currency.")]
        CRYPTO,
        ///<summary>
        ///Paid using an E-money provider.
        ///</summary>
        [Description("Paid using an E-money provider.")]
        EMONEY,
        ///<summary>
        ///A third-party application gathered this payment outside of Square.
        ///</summary>
        [Description("A third-party application gathered this payment outside of Square.")]
        EXTERNAL,
        ///<summary>
        ///Restaurant voucher provided by employers to employees to pay for meals.
        ///</summary>
        [Description("Restaurant voucher provided by employers to employees to pay for meals.")]
        FOOD_VOUCHER,
        ///<summary>
        ///A type not listed here.
        ///</summary>
        [Description("A type not listed here.")]
        OTHER,
        ///<summary>
        ///Paid using a non-Square gift card.
        ///</summary>
        [Description("Paid using a non-Square gift card.")]
        OTHER_GIFT_CARD,
        ///<summary>
        ///Paid using peer-to-peer payment applications.
        ///</summary>
        [Description("Paid using peer-to-peer payment applications.")]
        SOCIAL,
        ///<summary>
        ///Paid using Square Cash App.
        ///</summary>
        [Description("Paid using Square Cash App.")]
        SQUARE_CASH,
        ///<summary>
        ///Use for house accounts, store credit, and so forth.
        ///</summary>
        [Description("Use for house accounts, store credit, and so forth.")]
        STORED_BALANCE,
    }

    public static class ExternalPaymentTypeStringValues
    {
        public const string BANK_TRANSFER = @"BANK_TRANSFER";
        public const string CARD = @"CARD";
        public const string CHECK = @"CHECK";
        public const string CRYPTO = @"CRYPTO";
        public const string EMONEY = @"EMONEY";
        public const string EXTERNAL = @"EXTERNAL";
        public const string FOOD_VOUCHER = @"FOOD_VOUCHER";
        public const string OTHER = @"OTHER";
        public const string OTHER_GIFT_CARD = @"OTHER_GIFT_CARD";
        public const string SOCIAL = @"SOCIAL";
        public const string SQUARE_CASH = @"SQUARE_CASH";
        public const string STORED_BALANCE = @"STORED_BALANCE";
    }

    ///<summary>
    ///Latitude and longitude coordinates.
    ///</summary>
    [Description("Latitude and longitude coordinates.")]
    public class GeoCoordinates : GraphQLObject<GeoCoordinates>
    {
        ///<summary>
        ///The latitude of the coordinate expressed in degrees.
        ///</summary>
        [Description("The latitude of the coordinate expressed in degrees.")]
        public double? latitude { get; set; }

        ///<summary>
        ///The longitude of the coordinate expressed in degrees.
        ///</summary>
        [Description("The longitude of the coordinate expressed in degrees.")]
        public double? longitude { get; set; }
    }

    ///<summary>
    ///Geographic coordinates representing a location on the Earth's surface.
    ///</summary>
    [Description("Geographic coordinates representing a location on the Earth's surface.")]
    public class GeoLocation : GraphQLObject<GeoLocation>
    {
        ///<summary>
        ///Angular distance north or south of the Earth's equator, measured in degrees from -90 to +90.
        ///</summary>
        [Description("Angular distance north or south of the Earth's equator, measured in degrees from -90 to +90.")]
        public double? latitude { get; set; }

        ///<summary>
        ///Angular distance east or west of the Prime Meridian at Greenwich, UK, measured in degrees from -180 to +180.
        ///</summary>
        [Description("Angular distance east or west of the Prime Meridian at Greenwich, UK, measured in degrees from -180 to +180.")]
        public double? longitude { get; set; }
    }

    ///<summary>
    ///Represents a change in state or quantity of product inventory at a
    ///particular time and location.
    ///Permissions: INVENTORY_READ
    ///</summary>
    [Description("Represents a change in state or quantity of product inventory at a\nparticular time and location.\nPermissions: INVENTORY_READ")]
    public class InventoryAdjustment : GraphQLObject<InventoryAdjustment>, IInventoryChange
    {
        ///<summary>
        ///A unique ID generated by Square
        ///</summary>
        [Description("A unique ID generated by Square")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///An optional ID provided by the application to tie the InventoryChange to an external system.
        ///</summary>
        [Description("An optional ID provided by the application to tie the InventoryChange to an external system.")]
        public string? referenceId { get; set; }

        ///<summary>
        ///The inventory state of the related quantity
        ///of items before the adjustment.
        ///</summary>
        [Description("The inventory state of the related quantity\nof items before the adjustment.")]
        public InventoryState? fromState { get; set; }

        ///<summary>
        ///The inventory state of the related quantity
        ///of items after the adjustment.
        ///</summary>
        [Description("The inventory state of the related quantity\nof items after the adjustment.")]
        public InventoryState? toState { get; set; }

        ///<summary>
        ///The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.
        ///</summary>
        [Description("The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.")]
        public string? quantity { get; set; }

        ///<summary>
        ///The total price paid for goods associated with the
        ///adjustment. Present if and only if `to_state` is `SOLD`. Always
        ///non-negative.
        ///</summary>
        [Description("The total price paid for goods associated with the\nadjustment. Present if and only if `to_state` is `SOLD`. Always\nnon-negative.")]
        public Money? totalPriceMoney { get; set; }

        ///<summary>
        ///A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        [Description("A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00")]
        public DateTime? occurredAt { get; set; }

        ///<summary>
        ///An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        [Description("An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///Information about the application with which the physical count is submitted.
        ///</summary>
        [Description("Information about the application with which the physical count is submitted.")]
        public SourceApplication? source { get; set; }

        ///<summary>
        ///The Square-generated ID of the Transaction that
        ///caused the adjustment. Only relevant for payment-related state
        ///transitions.
        ///</summary>
        [Description("The Square-generated ID of the Transaction that\ncaused the adjustment. Only relevant for payment-related state\ntransitions.")]
        public string? transactionId { get; set; }

        ///<summary>
        ///The Square-generated ID of the Refund that
        ///caused the adjustment. Only relevant for refund-related state
        ///transitions.
        ///</summary>
        [Description("The Square-generated ID of the Refund that\ncaused the adjustment. Only relevant for refund-related state\ntransitions.")]
        public string? refundId { get; set; }

        ///<summary>
        ///The Square-generated ID of the purchase order that caused the
        ///adjustment. Only relevant for state transitions from the Square for Retail
        ///app.
        ///</summary>
        [Description("The Square-generated ID of the purchase order that caused the\nadjustment. Only relevant for state transitions from the Square for Retail\napp.")]
        public string? purchaseOrderId { get; set; }

        ///<summary>
        ///The Square-generated ID of the goods receipt that caused the
        ///adjustment. Only relevant for state transitions from the Square for Retail
        ///app.
        ///</summary>
        [Description("The Square-generated ID of the goods receipt that caused the\nadjustment. Only relevant for state transitions from the Square for Retail\napp.")]
        public string? goodsReceiptId { get; set; }

        ///<summary>
        ///An adjustment group bundling the related adjustments of item variations through stock conversions in a single inventory event.
        ///</summary>
        [Description("An adjustment group bundling the related adjustments of item variations through stock conversions in a single inventory event.")]
        public InventoryAdjustmentGroup? adjustmentGroup { get; set; }

        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items is being tracked.
        ///</summary>
        [Description("The Square-generated ID of the Location where the related\nquantity of items is being tracked.")]
        public Location? location { get; set; }

        ///<summary>
        ///The CatalogObject being tracked.
        ///</summary>
        [Description("The CatalogObject being tracked.")]
        public ICatalogObject? catalog { get; set; }

        ///<summary>
        ///Indicates how the inventory change is applied. See
        ///[InventoryChangeType](entity:InventoryChangeType) for all possible values.
        ///See [InventoryChangeType](#type-inventorychangetype) for possible values
        ///</summary>
        [Description("Indicates how the inventory change is applied. See\n[InventoryChangeType](entity:InventoryChangeType) for all possible values.\nSee [InventoryChangeType](#type-inventorychangetype) for possible values")]
        public InventoryChangeType? type { get; set; }

        ///<summary>
        ///The Employee responsible for
        ///</summary>
        [Description("The Employee responsible for")]
        public Employee? employee { get; set; }

        ///<summary>
        ///The Team Member responsible for
        ///</summary>
        [Description("The Team Member responsible for")]
        public TeamMember? teamMember { get; set; }
    }

    ///<summary>
    ///Permissions: INVENTORY_READ
    ///</summary>
    [Description("Permissions: INVENTORY_READ")]
    public class InventoryAdjustmentGroup : GraphQLObject<InventoryAdjustmentGroup>
    {
        ///<summary>
        ///A unique ID generated by Square for the
        ///`InventoryAdjustmentGroup`.
        ///</summary>
        [Description("A unique ID generated by Square for the\n`InventoryAdjustmentGroup`.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The inventory adjustment of the composed variation.
        ///</summary>
        [Description("The inventory adjustment of the composed variation.")]
        public string? rootAdjustmentId { get; set; }

        ///<summary>
        ///Representative `from_state` for adjustments within the group. For example, for a group adjustment from `IN_STOCK` to `SOLD`,
        ///there can be two component adjustments in the group: one from `IN_STOCK`to `COMPOSED` and the other one from `COMPOSED` to `SOLD`.
        ///Here, the representative `from_state` for the `InventoryAdjustmentGroup` is `IN_STOCK`.
        ///</summary>
        [Description("Representative `from_state` for adjustments within the group. For example, for a group adjustment from `IN_STOCK` to `SOLD`,\nthere can be two component adjustments in the group: one from `IN_STOCK`to `COMPOSED` and the other one from `COMPOSED` to `SOLD`.\nHere, the representative `from_state` for the `InventoryAdjustmentGroup` is `IN_STOCK`.")]
        public InventoryState? fromState { get; set; }

        ///<summary>
        ///Representative `to_state` for adjustments within group. For example, for a group adjustment from `IN_STOCK` to `SOLD`,
        ///the two component adjustments in the group can be from `IN_STOCK` to `COMPOSED` and from `COMPOSED` to `SOLD`.
        ///Here, the representative `to_state` of the `InventoryAdjustmentGroup` is `SOLD`.
        ///</summary>
        [Description("Representative `to_state` for adjustments within group. For example, for a group adjustment from `IN_STOCK` to `SOLD`,\nthe two component adjustments in the group can be from `IN_STOCK` to `COMPOSED` and from `COMPOSED` to `SOLD`.\nHere, the representative `to_state` of the `InventoryAdjustmentGroup` is `SOLD`.")]
        public InventoryState? toState { get; set; }
    }

    ///<summary>
    ///Inventory alert definition's associated values.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("Inventory alert definition's associated values.\n\nPermissions:ITEMS_READ")]
    public class InventoryAlert : GraphQLObject<InventoryAlert>
    {
        ///<summary>
        ///If the inventory quantity for the variation is less than or equal to this value and type is LOW_QUANTITY, the variation displays an alert in the merchant dashboard.
        ///This value is always an integer.
        ///</summary>
        [Description("If the inventory quantity for the variation is less than or equal to this value and type is LOW_QUANTITY, the variation displays an alert in the merchant dashboard.\nThis value is always an integer.")]
        public long? threshold { get; set; }

        ///<summary>
        ///Indicates whether the item variation displays an alert when its inventory quantity is less than or equal to its threshold.
        ///</summary>
        [Description("Indicates whether the item variation displays an alert when its inventory quantity is less than or equal to its threshold.")]
        public InventoryAlertType? type { get; set; }
    }

    ///<summary>
    ///Indicates whether Square should alert the merchant when the inventory quantity of a CatalogItemVariation is low.
    ///</summary>
    [Description("Indicates whether Square should alert the merchant when the inventory quantity of a CatalogItemVariation is low.")]
    public enum InventoryAlertType
    {
        ///<summary>
        ///The variation does not display an alert.
        ///</summary>
        [Description("The variation does not display an alert.")]
        NONE,
        ///<summary>
        ///The variation generates an alert when its quantity is low.
        ///</summary>
        [Description("The variation generates an alert when its quantity is low.")]
        LOW_QUANTITY,
    }

    public static class InventoryAlertTypeStringValues
    {
        public const string NONE = @"NONE";
        public const string LOW_QUANTITY = @"LOW_QUANTITY";
    }

    ///<summary>
    ///Represents a single physical count, inventory, adjustment, or transfer
    ///that is part of the history of inventory changes for a particular
    ///[CatalogObject](entity:CatalogObject) instance.
    ///</summary>
    [Description("Represents a single physical count, inventory, adjustment, or transfer\nthat is part of the history of inventory changes for a particular\n[CatalogObject](entity:CatalogObject) instance.")]
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
        [Description("A unique ID generated by Square")]
        [NonNull]
        public string? id { get; }

        ///<summary>
        ///Indicates how the inventory change is applied. See
        ///[InventoryChangeType](entity:InventoryChangeType) for all possible values.
        ///See [InventoryChangeType](#type-inventorychangetype) for possible values
        ///</summary>
        [Description("Indicates how the inventory change is applied. See\n[InventoryChangeType](entity:InventoryChangeType) for all possible values.\nSee [InventoryChangeType](#type-inventorychangetype) for possible values")]
        public InventoryChangeType? type { get; }

        ///<summary>
        ///The CatalogObject being tracked.
        ///</summary>
        [Description("The CatalogObject being tracked.")]
        public ICatalogObject? catalog { get; }

        ///<summary>
        ///An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        [Description("An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; }

        ///<summary>
        ///An optional ID provided by the application to tie the InventoryChange to an external system.
        ///</summary>
        [Description("An optional ID provided by the application to tie the InventoryChange to an external system.")]
        public string? referenceId { get; }

        ///<summary>
        ///The Employee responsible for
        ///</summary>
        [Description("The Employee responsible for")]
        public Employee? employee { get; }

        ///<summary>
        ///The Team Member responsible for
        ///</summary>
        [Description("The Team Member responsible for")]
        public TeamMember? teamMember { get; }

        ///<summary>
        ///A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        [Description("A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00")]
        public DateTime? occurredAt { get; }

        ///<summary>
        ///Information about the application with which the physical count is submitted.
        ///</summary>
        [Description("Information about the application with which the physical count is submitted.")]
        public SourceApplication? source { get; }

        ///<summary>
        ///The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.
        ///</summary>
        [Description("The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.")]
        public string? quantity { get; }
    }

    ///<summary>
    ///Contains information of InventoryChange result.
    ///
    ///Permissions:INVENTORY_READ
    ///</summary>
    [Description("Contains information of InventoryChange result.\n\nPermissions:INVENTORY_READ")]
    public class InventoryChangeConnection : GraphQLObject<InventoryChangeConnection>, IConnectionWithNodes<IInventoryChange>
    {
        ///<summary>
        ///List of InventoryChange
        ///</summary>
        [Description("List of InventoryChange")]
        [NonNull]
        public IEnumerable<IInventoryChange>? nodes { get; set; }

        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///Indicates how the inventory change was applied to a tracked product quantity.
    ///</summary>
    [Description("Indicates how the inventory change was applied to a tracked product quantity.")]
    public enum InventoryChangeType
    {
        ///<summary>
        ///The change occurred as part of a physical count update.
        ///</summary>
        [Description("The change occurred as part of a physical count update.")]
        PHYSICAL_COUNT,
        ///<summary>
        ///The change occurred as part of the normal lifecycle of goods
        ///(e.g., as an inventory adjustment).
        ///</summary>
        [Description("The change occurred as part of the normal lifecycle of goods\n(e.g., as an inventory adjustment).")]
        ADJUSTMENT,
        ///<summary>
        ///The change occurred as part of an inventory transfer.
        ///</summary>
        [Description("The change occurred as part of an inventory transfer.")]
        TRANSFER,
    }

    public static class InventoryChangeTypeStringValues
    {
        public const string PHYSICAL_COUNT = @"PHYSICAL_COUNT";
        public const string ADJUSTMENT = @"ADJUSTMENT";
        public const string TRANSFER = @"TRANSFER";
    }

    ///<summary>
    ///Represents Square-estimated quantity of items in a particular state at a
    ///particular seller location based on the known history of physical counts and
    ///inventory adjustments.
    ///Permissions: INVENTORY_READ
    ///</summary>
    [Description("Represents Square-estimated quantity of items in a particular state at a\nparticular seller location based on the known history of physical counts and\ninventory adjustments.\nPermissions: INVENTORY_READ")]
    public class InventoryCount : GraphQLObject<InventoryCount>
    {
        ///<summary>
        ///The current inventory state for the related
        ///quantity of items.
        ///</summary>
        [Description("The current inventory state for the related\nquantity of items.")]
        public InventoryState? state { get; set; }

        ///<summary>
        ///The number of items affected by the estimated count as a decimal string.
        ///Can support up to 5 digits after the decimal point.
        ///</summary>
        [Description("The number of items affected by the estimated count as a decimal string.\nCan support up to 5 digits after the decimal point.")]
        public string? quantity { get; set; }

        ///<summary>
        ///Whether the inventory count is for composed variation (TRUE) or not (FALSE). If true, the inventory count will not be present in the response of
        ///any of these endpoints: [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory),
        ///[BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges),
        ///[BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts), and
        ///[RetrieveInventoryChanges](api-endpoint:Inventory-RetrieveInventoryChanges).
        ///</summary>
        [Description("Whether the inventory count is for composed variation (TRUE) or not (FALSE). If true, the inventory count will not be present in the response of\nany of these endpoints: [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory),\n[BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges),\n[BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts), and\n[RetrieveInventoryChanges](api-endpoint:Inventory-RetrieveInventoryChanges).")]
        public bool? isEstimated { get; set; }

        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items is being tracked.
        ///</summary>
        [Description("The Square-generated ID of the Location where the related\nquantity of items is being tracked.")]
        public Location? location { get; set; }

        ///<summary>
        ///The Square-generated ID of the
        ///CatalogObject being tracked.
        ///</summary>
        [Description("The Square-generated ID of the\nCatalogObject being tracked.")]
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
        [Description("An RFC 3339-formatted timestamp that indicates when the most recent physical count or adjustment affecting\nthe estimated count is received.\n\nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n\nUTC:  2020-01-26T02:25:34Z\n\nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? calculatedAt { get; set; }
    }

    ///<summary>
    ///Contains information of InventoryCount result.
    ///
    ///Permissions:INVENTORY_READ
    ///</summary>
    [Description("Contains information of InventoryCount result.\n\nPermissions:INVENTORY_READ")]
    public class InventoryCountConnection : GraphQLObject<InventoryCountConnection>, IConnectionWithNodes<InventoryCount>
    {
        ///<summary>
        ///List of InventoryCount
        ///</summary>
        [Description("List of InventoryCount")]
        [NonNull]
        public IEnumerable<InventoryCount>? nodes { get; set; }

        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///Represents the quantity of an item variation that is physically present
    ///at a specific location, verified by a seller or a seller's employee.For example,
    ///a physical count might come from an employee counting the item variations on
    ///hand or from syncing with an external system.
    ///Permissions: INVENTORY_READ
    ///</summary>
    [Description("Represents the quantity of an item variation that is physically present\nat a specific location, verified by a seller or a seller's employee.For example,\na physical count might come from an employee counting the item variations on\nhand or from syncing with an external system.\nPermissions: INVENTORY_READ")]
    public class InventoryPhysicalCount : GraphQLObject<InventoryPhysicalCount>, IInventoryChange
    {
        ///<summary>
        ///A unique ID generated by Square
        ///</summary>
        [Description("A unique ID generated by Square")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///An optional ID provided by the application to tie the InventoryChange to an external system.
        ///</summary>
        [Description("An optional ID provided by the application to tie the InventoryChange to an external system.")]
        public string? referenceId { get; set; }

        ///<summary>
        ///The current inventory state for the related
        ///quantity of items.
        ///</summary>
        [Description("The current inventory state for the related\nquantity of items.")]
        public InventoryState? state { get; set; }

        ///<summary>
        ///The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.
        ///</summary>
        [Description("The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.")]
        public string? quantity { get; set; }

        ///<summary>
        ///Information about the application with which the physical count is submitted.
        ///</summary>
        [Description("Information about the application with which the physical count is submitted.")]
        public SourceApplication? source { get; set; }

        ///<summary>
        ///A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        [Description("A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00")]
        public DateTime? occurredAt { get; set; }

        ///<summary>
        ///An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        [Description("An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items is being tracked.
        ///</summary>
        [Description("The Square-generated ID of the Location where the related\nquantity of items is being tracked.")]
        public Location? location { get; set; }

        ///<summary>
        ///The CatalogObject being tracked.
        ///</summary>
        [Description("The CatalogObject being tracked.")]
        public ICatalogObject? catalog { get; set; }

        ///<summary>
        ///Indicates how the inventory change is applied. See
        ///[InventoryChangeType](entity:InventoryChangeType) for all possible values.
        ///See [InventoryChangeType](#type-inventorychangetype) for possible values
        ///</summary>
        [Description("Indicates how the inventory change is applied. See\n[InventoryChangeType](entity:InventoryChangeType) for all possible values.\nSee [InventoryChangeType](#type-inventorychangetype) for possible values")]
        public InventoryChangeType? type { get; set; }

        ///<summary>
        ///The Employee responsible for
        ///</summary>
        [Description("The Employee responsible for")]
        public Employee? employee { get; set; }

        ///<summary>
        ///The Team Member responsible for
        ///</summary>
        [Description("The Team Member responsible for")]
        public TeamMember? teamMember { get; set; }
    }

    ///<summary>
    ///Indicates the state of a tracked item quantity in the lifecycle of goods.
    ///</summary>
    [Description("Indicates the state of a tracked item quantity in the lifecycle of goods.")]
    public enum InventoryState
    {
        ///<summary>
        ///The related quantity of items are in a custom state. **READ-ONLY**:
        ///the Inventory API cannot move quantities to or from this state.
        ///</summary>
        [Description("The related quantity of items are in a custom state. **READ-ONLY**:\nthe Inventory API cannot move quantities to or from this state.")]
        CUSTOM,
        ///<summary>
        ///The related quantity of items are on hand and available for sale.
        ///</summary>
        [Description("The related quantity of items are on hand and available for sale.")]
        IN_STOCK,
        ///<summary>
        ///The related quantity of items were sold as part of an itemized
        ///transaction. Quantities in the `SOLD` state are no longer tracked.
        ///</summary>
        [Description("The related quantity of items were sold as part of an itemized\ntransaction. Quantities in the `SOLD` state are no longer tracked.")]
        SOLD,
        ///<summary>
        ///The related quantity of items were returned through the Square Point
        ///of Sale application, but are not yet available for sale. **READ-ONLY**:
        ///the Inventory API cannot move quantities to or from this state.
        ///</summary>
        [Description("The related quantity of items were returned through the Square Point\nof Sale application, but are not yet available for sale. **READ-ONLY**:\nthe Inventory API cannot move quantities to or from this state.")]
        RETURNED_BY_CUSTOMER,
        ///<summary>
        ///The related quantity of items are on hand, but not currently
        ///available for sale. **READ-ONLY**: the Inventory API cannot move
        ///quantities to or from this state.
        ///</summary>
        [Description("The related quantity of items are on hand, but not currently\navailable for sale. **READ-ONLY**: the Inventory API cannot move\nquantities to or from this state.")]
        RESERVED_FOR_SALE,
        ///<summary>
        ///The related quantity of items were sold online. **READ-ONLY**: the
        ///Inventory API cannot move quantities to or from this state.
        ///</summary>
        [Description("The related quantity of items were sold online. **READ-ONLY**: the\nInventory API cannot move quantities to or from this state.")]
        SOLD_ONLINE,
        ///<summary>
        ///The related quantity of items were ordered from a vendor but not yet
        ///received. **READ-ONLY**: the Inventory API cannot move quantities to or
        ///from this state.
        ///</summary>
        [Description("The related quantity of items were ordered from a vendor but not yet\nreceived. **READ-ONLY**: the Inventory API cannot move quantities to or\nfrom this state.")]
        ORDERED_FROM_VENDOR,
        ///<summary>
        ///The related quantity of items were received from a vendor but are
        ///not yet available for sale. **READ-ONLY**: the Inventory API cannot move
        ///quantities to or from this state.
        ///</summary>
        [Description("The related quantity of items were received from a vendor but are\nnot yet available for sale. **READ-ONLY**: the Inventory API cannot move\nquantities to or from this state.")]
        RECEIVED_FROM_VENDOR,
        ///<summary>
        ///Replaced by `IN_TRANSIT` to represent quantities
        ///of items that are in transit between locations.
        ///</summary>
        [Description("Replaced by `IN_TRANSIT` to represent quantities\nof items that are in transit between locations.")]
        IN_TRANSIT_TO,
        ///<summary>
        ///A placeholder indicating that the related quantity of items are not
        ///currently tracked in Square. Transferring quantities from the `NONE` state
        ///to a tracked state (e.g., `IN_STOCK`) introduces stock into the system.
        ///</summary>
        [Description("A placeholder indicating that the related quantity of items are not\ncurrently tracked in Square. Transferring quantities from the `NONE` state\nto a tracked state (e.g., `IN_STOCK`) introduces stock into the system.")]
        NONE,
        ///<summary>
        ///The related quantity of items are lost or damaged and cannot be
        ///sold.
        ///</summary>
        [Description("The related quantity of items are lost or damaged and cannot be\nsold.")]
        WASTE,
        ///<summary>
        ///The related quantity of items were returned but not linked to a
        ///previous transaction. Unlinked returns are not tracked in Square.
        ///Transferring a quantity from `UNLINKED_RETURN` to a tracked state (e.g.,
        ///`IN_STOCK`) introduces new stock into the system.
        ///</summary>
        [Description("The related quantity of items were returned but not linked to a\nprevious transaction. Unlinked returns are not tracked in Square.\nTransferring a quantity from `UNLINKED_RETURN` to a tracked state (e.g.,\n`IN_STOCK`) introduces new stock into the system.")]
        UNLINKED_RETURN,
        ///<summary>
        ///The related quantity of items that are part of a composition consisting one or more components.
        ///</summary>
        [Description("The related quantity of items that are part of a composition consisting one or more components.")]
        COMPOSED,
        ///<summary>
        ///The related quantity of items that are part of a component.
        ///</summary>
        [Description("The related quantity of items that are part of a component.")]
        DECOMPOSED,
        ///<summary>
        ///This state is not supported by this version of the Square API. We recommend that you upgrade the client to use the appropriate version of the Square API supporting this state.
        ///</summary>
        [Description("This state is not supported by this version of the Square API. We recommend that you upgrade the client to use the appropriate version of the Square API supporting this state.")]
        SUPPORTED_BY_NEWER_VERSION,
        ///<summary>
        ///The related quantity of items are in transit between locations. **READ-ONLY:** the Inventory API cannot currently be used to move quantities to or from this inventory state.
        ///</summary>
        [Description("The related quantity of items are in transit between locations. **READ-ONLY:** the Inventory API cannot currently be used to move quantities to or from this inventory state.")]
        IN_TRANSIT,
    }

    public static class InventoryStateStringValues
    {
        public const string CUSTOM = @"CUSTOM";
        public const string IN_STOCK = @"IN_STOCK";
        public const string SOLD = @"SOLD";
        public const string RETURNED_BY_CUSTOMER = @"RETURNED_BY_CUSTOMER";
        public const string RESERVED_FOR_SALE = @"RESERVED_FOR_SALE";
        public const string SOLD_ONLINE = @"SOLD_ONLINE";
        public const string ORDERED_FROM_VENDOR = @"ORDERED_FROM_VENDOR";
        public const string RECEIVED_FROM_VENDOR = @"RECEIVED_FROM_VENDOR";
        public const string IN_TRANSIT_TO = @"IN_TRANSIT_TO";
        public const string NONE = @"NONE";
        public const string WASTE = @"WASTE";
        public const string UNLINKED_RETURN = @"UNLINKED_RETURN";
        public const string COMPOSED = @"COMPOSED";
        public const string DECOMPOSED = @"DECOMPOSED";
        public const string SUPPORTED_BY_NEWER_VERSION = @"SUPPORTED_BY_NEWER_VERSION";
        public const string IN_TRANSIT = @"IN_TRANSIT";
    }

    ///<summary>
    ///Represents the transfer of a quantity of product inventory at a
    ///particular time from one location to another.
    ///Permissions: INVENTORY_READ
    ///</summary>
    [Description("Represents the transfer of a quantity of product inventory at a\nparticular time from one location to another.\nPermissions: INVENTORY_READ")]
    public class InventoryTransfer : GraphQLObject<InventoryTransfer>, IInventoryChange
    {
        ///<summary>
        ///A unique ID generated by Square
        ///</summary>
        [Description("A unique ID generated by Square")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///An optional ID provided by the application to tie the InventoryChange to an external system.
        ///</summary>
        [Description("An optional ID provided by the application to tie the InventoryChange to an external system.")]
        public string? referenceId { get; set; }

        ///<summary>
        ///The inventory state for the quantity of
        ///items being transferred.
        ///</summary>
        [Description("The inventory state for the quantity of\nitems being transferred.")]
        public InventoryState? state { get; set; }

        ///<summary>
        ///The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.
        ///</summary>
        [Description("The number of items affected as a decimal string. Can support up to 5 digits after the decimal point.")]
        public string? quantity { get; set; }

        ///<summary>
        ///A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        [Description("A client-generated RFC 3339-formatted timestamp that indicates when the physical count was examined.  For physical count updates, the occurred_at timestamp cannot be older than 24 hours or in the future relative to the time of the request. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00")]
        public DateTime? occurredAt { get; set; }

        ///<summary>
        ///An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        ///</summary>
        [Description("An RFC 3339-formatted timestamp that indicates when the physical count is received. Examples for January 25th, 2020 6:25:34pm Pacific Standard Time: UTC: 2020-01-26T02:25:34Z Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///Information about the application with which the physical count is submitted.
        ///</summary>
        [Description("Information about the application with which the physical count is submitted.")]
        public SourceApplication? source { get; set; }

        ///<summary>
        ///The CatalogObject being tracked.
        ///</summary>
        [Description("The CatalogObject being tracked.")]
        public ICatalogObject? catalog { get; set; }

        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items was tracked before the transfer.
        ///</summary>
        [Description("The Square-generated ID of the Location where the related\nquantity of items was tracked before the transfer.")]
        public Location? fromLocation { get; set; }

        ///<summary>
        ///The Square-generated ID of the Location where the related
        ///quantity of items was tracked after the transfer.
        ///</summary>
        [Description("The Square-generated ID of the Location where the related\nquantity of items was tracked after the transfer.")]
        public Location? toLocation { get; set; }

        ///<summary>
        ///Indicates how the inventory change is applied. See
        ///[InventoryChangeType](entity:InventoryChangeType) for all possible values.
        ///See [InventoryChangeType](#type-inventorychangetype) for possible values
        ///</summary>
        [Description("Indicates how the inventory change is applied. See\n[InventoryChangeType](entity:InventoryChangeType) for all possible values.\nSee [InventoryChangeType](#type-inventorychangetype) for possible values")]
        public InventoryChangeType? type { get; set; }

        ///<summary>
        ///The Employee responsible for
        ///</summary>
        [Description("The Employee responsible for")]
        public Employee? employee { get; set; }

        ///<summary>
        ///The Team Member responsible for
        ///</summary>
        [Description("The Team Member responsible for")]
        public TeamMember? teamMember { get; set; }
    }

    ///<summary>
    ///A location for a Merchant. The location may be a physical location, such as a storefront, or it may be an abstract
    ///location, such as an online store, facebook/instagram property, etc.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    [Description("A location for a Merchant. The location may be a physical location, such as a storefront, or it may be an abstract\nlocation, such as an online store, facebook/instagram property, etc.\n\nPermissions:MERCHANT_PROFILE_READ")]
    public class Location : GraphQLObject<Location>
    {
        ///<summary>
        ///The Square-issued ID of the location.
        ///</summary>
        [Description("The Square-issued ID of the location.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The physical address of the location.
        ///</summary>
        [Description("The physical address of the location.")]
        public Address? address { get; set; }

        ///<summary>
        ///The email of the location. This email is visible to the customers of the location. For example, the email appears on customer receipts
        ///</summary>
        [Description("The email of the location. This email is visible to the customers of the location. For example, the email appears on customer receipts")]
        public string? businessEmail { get; set; }

        ///<summary>
        ///The hours of operation for the location.
        ///</summary>
        [Description("The hours of operation for the location.")]
        public BusinessHours? businessHours { get; set; }

        ///<summary>
        ///The business name of the location This is the name visible to the customers of the location. For example, this name appears on customer receipts.
        ///</summary>
        [Description("The business name of the location This is the name visible to the customers of the location. For example, this name appears on customer receipts.")]
        public string? businessName { get; set; }

        ///<summary>
        ///The Square features that are enabled for the location.
        ///</summary>
        [Description("The Square features that are enabled for the location.")]
        public IEnumerable<LocationCapability>? capabilities { get; set; }

        ///<summary>
        ///The physical coordinates (latitude and longitude) of the location.
        ///</summary>
        [Description("The physical coordinates (latitude and longitude) of the location.")]
        public GeoCoordinates? coordinates { get; set; }

        ///<summary>
        ///The country of the location.
        ///</summary>
        [Description("The country of the location.")]
        public Country? country { get; set; }

        ///<summary>
        ///The time when the location was created, in RFC 3339 format. For more information, see Working with Dates.
        ///</summary>
        [Description("The time when the location was created, in RFC 3339 format. For more information, see Working with Dates.")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///The currency used for all transactions at this location.
        ///</summary>
        [Description("The currency used for all transactions at this location.")]
        public Currency? currency { get; set; }

        ///<summary>
        ///The description of the location.
        ///</summary>
        [Description("The description of the location.")]
        public string? description { get; set; }

        ///<summary>
        ///The Facebook profile URL of the location. The URL's domain should be 'facebook.com'.
        ///</summary>
        [Description("The Facebook profile URL of the location. The URL's domain should be 'facebook.com'.")]
        public string? facebookUrl { get; set; }

        ///<summary>
        ///The Instagram username of the location without the '@' symbol.
        ///</summary>
        [Description("The Instagram username of the location without the '@' symbol.")]
        public string? instagramUsername { get; set; }

        ///<summary>
        ///The language associated with the location.
        ///</summary>
        [Description("The language associated with the location.")]
        public string? language { get; set; }

        ///<summary>
        ///The URL of the logo image for the location.
        ///</summary>
        [Description("The URL of the logo image for the location.")]
        public string? logoUrl { get; set; }

        ///<summary>
        ///A four-digit number that describes the kind of goods or services sold at the location.
        ///The merchant category code (MCC) of the location as standardized by ISO 18245.
        ///For example, 5045, for a location that sells computer goods and software.
        ///</summary>
        [Description("A four-digit number that describes the kind of goods or services sold at the location.\nThe merchant category code (MCC) of the location as standardized by ISO 18245.\nFor example, 5045, for a location that sells computer goods and software.")]
        public string? mcc { get; set; }

        ///<summary>
        ///The merchant of the location.
        ///</summary>
        [Description("The merchant of the location.")]
        [NonNull]
        public Merchant? merchant { get; set; }

        ///<summary>
        ///The name of the location. This information appears in the Seller Dashboard as the nickname. A location name must be unique within a seller account.
        ///</summary>
        [Description("The name of the location. This information appears in the Seller Dashboard as the nickname. A location name must be unique within a seller account.")]
        public string? name { get; set; }

        ///<summary>
        ///The phone number of the location.
        ///</summary>
        [Description("The phone number of the location.")]
        public string? phoneNumber { get; set; }

        ///<summary>
        ///The URL of the Point of Sal background image for the location.
        ///</summary>
        [Description("The URL of the Point of Sal background image for the location.")]
        public string? posBackgroundUrl { get; set; }

        ///<summary>
        ///The status of the location, e.g. whether a location is active or inactive.
        ///</summary>
        [Description("The status of the location, e.g. whether a location is active or inactive.")]
        public LocationStatus? status { get; set; }

        ///<summary>
        ///The timezone of the location.
        ///</summary>
        [Description("The timezone of the location.")]
        public string? timezone { get; set; }

        ///<summary>
        ///The Twitter username of the location without the '@' symbol.
        ///</summary>
        [Description("The Twitter username of the location without the '@' symbol.")]
        public string? twitterUsername { get; set; }

        ///<summary>
        ///The type of the location.
        ///</summary>
        [Description("The type of the location.")]
        public LocationType? type { get; set; }

        ///<summary>
        ///The website URL of the location.
        ///</summary>
        [Description("The website URL of the location.")]
        public string? websiteUrl { get; set; }
    }

    ///<summary>
    ///The capabilities a location might have.
    ///</summary>
    [Description("The capabilities a location might have.")]
    public enum LocationCapability
    {
        ///<summary>
        ///The capability to receive automatic transfers from Square.
        ///</summary>
        [Description("The capability to receive automatic transfers from Square.")]
        AUTOMATIC_TRANSFERS,
        ///<summary>
        ///The capability to process credit card transactions with Square.
        ///</summary>
        [Description("The capability to process credit card transactions with Square.")]
        CREDIT_CARD_PROCESSING,
    }

    public static class LocationCapabilityStringValues
    {
        public const string AUTOMATIC_TRANSFERS = @"AUTOMATIC_TRANSFERS";
        public const string CREDIT_CARD_PROCESSING = @"CREDIT_CARD_PROCESSING";
    }

    ///<summary>
    ///A list of Location.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    [Description("A list of Location.\n\nPermissions:MERCHANT_PROFILE_READ")]
    public class LocationConnection : GraphQLObject<LocationConnection>, IConnectionWithNodes<Location>
    {
        ///<summary>
        ///A list of Location.
        ///</summary>
        [Description("A list of Location.")]
        [NonNull]
        public IEnumerable<Location>? nodes { get; set; }

        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///A location's status.
    ///</summary>
    [Description("A location's status.")]
    public enum LocationStatus
    {
        ///<summary>
        ///A location that is active for business.
        ///</summary>
        [Description("A location that is active for business.")]
        ACTIVE,
        ///<summary>
        ///A location that is not active for business. Inactive locations provide historical
        ///information. Hide inactive locations unless the user has requested to see them.
        ///</summary>
        [Description("A location that is not active for business. Inactive locations provide historical\ninformation. Hide inactive locations unless the user has requested to see them.")]
        INACTIVE,
    }

    public static class LocationStatusStringValues
    {
        public const string ACTIVE = @"ACTIVE";
        public const string INACTIVE = @"INACTIVE";
    }

    ///<summary>
    ///A location's type.
    ///</summary>
    [Description("A location's type.")]
    public enum LocationType
    {
        ///<summary>
        ///A place of business that is mobile, such as a food truck or online store.
        ///</summary>
        [Description("A place of business that is mobile, such as a food truck or online store.")]
        MOBILE,
        ///<summary>
        ///A place of business with a physical location.
        ///</summary>
        [Description("A place of business with a physical location.")]
        PHYSICAL,
    }

    public static class LocationTypeStringValues
    {
        public const string MOBILE = @"MOBILE";
        public const string PHYSICAL = @"PHYSICAL";
    }

    ///<summary>
    ///Represents a unit of measurement to use with a quantity, such as ounces or inches.
    ///</summary>
    [Description("Represents a unit of measurement to use with a quantity, such as ounces or inches.")]
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
    [Description("Unit of area used to measure a quantity.")]
    public enum MeasurementUnitArea
    {
        ///<summary>
        ///The area is measured in acres.
        ///</summary>
        [Description("The area is measured in acres.")]
        IMPERIAL_ACRE,
        ///<summary>
        ///The area is measured in square inches.
        ///</summary>
        [Description("The area is measured in square inches.")]
        IMPERIAL_SQUARE_INCH,
        ///<summary>
        ///The area is measured in square feet.
        ///</summary>
        [Description("The area is measured in square feet.")]
        IMPERIAL_SQUARE_FOOT,
        ///<summary>
        ///The area is measured in square yards.
        ///</summary>
        [Description("The area is measured in square yards.")]
        IMPERIAL_SQUARE_YARD,
        ///<summary>
        ///The area is measured in square miles.
        ///</summary>
        [Description("The area is measured in square miles.")]
        IMPERIAL_SQUARE_MILE,
        ///<summary>
        ///The area is measured in square centimeters.
        ///</summary>
        [Description("The area is measured in square centimeters.")]
        METRIC_SQUARE_CENTIMETER,
        ///<summary>
        ///The area is measured in square meters.
        ///</summary>
        [Description("The area is measured in square meters.")]
        METRIC_SQUARE_METER,
        ///<summary>
        ///The area is measured in square kilometers.
        ///</summary>
        [Description("The area is measured in square kilometers.")]
        METRIC_SQUARE_KILOMETER,
    }

    public static class MeasurementUnitAreaStringValues
    {
        public const string IMPERIAL_ACRE = @"IMPERIAL_ACRE";
        public const string IMPERIAL_SQUARE_INCH = @"IMPERIAL_SQUARE_INCH";
        public const string IMPERIAL_SQUARE_FOOT = @"IMPERIAL_SQUARE_FOOT";
        public const string IMPERIAL_SQUARE_YARD = @"IMPERIAL_SQUARE_YARD";
        public const string IMPERIAL_SQUARE_MILE = @"IMPERIAL_SQUARE_MILE";
        public const string METRIC_SQUARE_CENTIMETER = @"METRIC_SQUARE_CENTIMETER";
        public const string METRIC_SQUARE_METER = @"METRIC_SQUARE_METER";
        public const string METRIC_SQUARE_KILOMETER = @"METRIC_SQUARE_KILOMETER";
    }

    ///<summary>
    ///MeasurementUnitAreaValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("MeasurementUnitAreaValue\n\nPermissions:ITEMS_READ")]
    public class MeasurementUnitAreaValue : GraphQLObject<MeasurementUnitAreaValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard area unit.
        ///</summary>
        [Description("Represents a standard area unit.")]
        public MeasurementUnitArea? value { get; set; }
    }

    ///<summary>
    ///The information needed to define a custom unit, provided by the seller.
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("The information needed to define a custom unit, provided by the seller.\n\nPermissions:ITEMS_READ")]
    public class MeasurementUnitCustom : GraphQLObject<MeasurementUnitCustom>, IMeasurementUnit
    {
        ///<summary>
        ///The abbreviation of the custom unit, such as bsh (bushel). This appears in the cart for the Point of Sale app, and in reports.
        ///</summary>
        [Description("The abbreviation of the custom unit, such as bsh (bushel). This appears in the cart for the Point of Sale app, and in reports.")]
        public string? abbreviation { get; set; }

        ///<summary>
        ///The name of the custom unit, for example bushel
        ///</summary>
        [Description("The name of the custom unit, for example bushel")]
        public string? name { get; set; }
    }

    public enum MeasurementUnitGeneric
    {
        ///<summary>
        ///The generic unit.
        ///</summary>
        [Description("The generic unit.")]
        UNIT,
    }

    public static class MeasurementUnitGenericStringValues
    {
        public const string UNIT = @"UNIT";
    }

    ///<summary>
    ///MeasurementUnitGenericValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("MeasurementUnitGenericValue\n\nPermissions:ITEMS_READ")]
    public class MeasurementUnitGenericValue : GraphQLObject<MeasurementUnitGenericValue>, IMeasurementUnit
    {
        ///<summary>
        ///Reserved for API integrations that lack the ability to specify a real measurement unit
        ///</summary>
        [Description("Reserved for API integrations that lack the ability to specify a real measurement unit")]
        public MeasurementUnitGeneric? value { get; set; }
    }

    ///<summary>
    ///The unit of length used to measure a quantity.
    ///</summary>
    [Description("The unit of length used to measure a quantity.")]
    public enum MeasurementUnitLength
    {
        ///<summary>
        ///The length is measured in inches.
        ///</summary>
        [Description("The length is measured in inches.")]
        IMPERIAL_INCH,
        ///<summary>
        ///The length is measured in feet.
        ///</summary>
        [Description("The length is measured in feet.")]
        IMPERIAL_FOOT,
        ///<summary>
        ///The length is measured in yards.
        ///</summary>
        [Description("The length is measured in yards.")]
        IMPERIAL_YARD,
        ///<summary>
        ///The length is measured in miles.
        ///</summary>
        [Description("The length is measured in miles.")]
        IMPERIAL_MILE,
        ///<summary>
        ///The length is measured in millimeters.
        ///</summary>
        [Description("The length is measured in millimeters.")]
        METRIC_MILLIMETER,
        ///<summary>
        ///The length is measured in centimeters.
        ///</summary>
        [Description("The length is measured in centimeters.")]
        METRIC_CENTIMETER,
        ///<summary>
        ///The length is measured in meters.
        ///</summary>
        [Description("The length is measured in meters.")]
        METRIC_METER,
        ///<summary>
        ///The length is measured in kilometers.
        ///</summary>
        [Description("The length is measured in kilometers.")]
        METRIC_KILOMETER,
    }

    public static class MeasurementUnitLengthStringValues
    {
        public const string IMPERIAL_INCH = @"IMPERIAL_INCH";
        public const string IMPERIAL_FOOT = @"IMPERIAL_FOOT";
        public const string IMPERIAL_YARD = @"IMPERIAL_YARD";
        public const string IMPERIAL_MILE = @"IMPERIAL_MILE";
        public const string METRIC_MILLIMETER = @"METRIC_MILLIMETER";
        public const string METRIC_CENTIMETER = @"METRIC_CENTIMETER";
        public const string METRIC_METER = @"METRIC_METER";
        public const string METRIC_KILOMETER = @"METRIC_KILOMETER";
    }

    ///<summary>
    ///MeasurementUnitLengthValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("MeasurementUnitLengthValue\n\nPermissions:ITEMS_READ")]
    public class MeasurementUnitLengthValue : GraphQLObject<MeasurementUnitLengthValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard length unit.
        ///</summary>
        [Description("Represents a standard length unit.")]
        public MeasurementUnitLength? value { get; set; }
    }

    ///<summary>
    ///Unit of time used to measure a quantity (a duration).
    ///</summary>
    [Description("Unit of time used to measure a quantity (a duration).")]
    public enum MeasurementUnitTime
    {
        ///<summary>
        ///The time is measured in milliseconds.
        ///</summary>
        [Description("The time is measured in milliseconds.")]
        GENERIC_MILLISECOND,
        ///<summary>
        ///The time is measured in seconds.
        ///</summary>
        [Description("The time is measured in seconds.")]
        GENERIC_SECOND,
        ///<summary>
        ///The time is measured in minutes.
        ///</summary>
        [Description("The time is measured in minutes.")]
        GENERIC_MINUTE,
        ///<summary>
        ///The time is measured in hours.
        ///</summary>
        [Description("The time is measured in hours.")]
        GENERIC_HOUR,
        ///<summary>
        ///The time is measured in days.
        ///</summary>
        [Description("The time is measured in days.")]
        GENERIC_DAY,
    }

    public static class MeasurementUnitTimeStringValues
    {
        public const string GENERIC_MILLISECOND = @"GENERIC_MILLISECOND";
        public const string GENERIC_SECOND = @"GENERIC_SECOND";
        public const string GENERIC_MINUTE = @"GENERIC_MINUTE";
        public const string GENERIC_HOUR = @"GENERIC_HOUR";
        public const string GENERIC_DAY = @"GENERIC_DAY";
    }

    ///<summary>
    ///MeasurementUnitTimeValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("MeasurementUnitTimeValue\n\nPermissions:ITEMS_READ")]
    public class MeasurementUnitTimeValue : GraphQLObject<MeasurementUnitTimeValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard unit of time.
        ///</summary>
        [Description("Represents a standard unit of time.")]
        public MeasurementUnitTime? value { get; set; }
    }

    ///<summary>
    ///Describes the type of this unit and indicates which field contains the unit information.This is an ‘open’ enum.
    ///</summary>
    [Description("Describes the type of this unit and indicates which field contains the unit information.This is an ‘open’ enum.")]
    public enum MeasurementUnitUnitType
    {
        ///<summary>
        ///The unit details are contained in the custom_unit field.
        ///</summary>
        [Description("The unit details are contained in the custom_unit field.")]
        TYPE_CUSTOM,
        ///<summary>
        ///The unit details are contained in the area_unit field.
        ///</summary>
        [Description("The unit details are contained in the area_unit field.")]
        TYPE_AREA,
        ///<summary>
        ///The unit details are contained in the length_unit field.
        ///</summary>
        [Description("The unit details are contained in the length_unit field.")]
        TYPE_LENGTH,
        ///<summary>
        ///The unit details are contained in the volume_unit field.
        ///</summary>
        [Description("The unit details are contained in the volume_unit field.")]
        TYPE_VOLUME,
        ///<summary>
        ///The unit details are contained in the weight_unit field.
        ///</summary>
        [Description("The unit details are contained in the weight_unit field.")]
        TYPE_WEIGHT,
        ///<summary>
        ///The unit details are contained in the generic_unit field.
        ///</summary>
        [Description("The unit details are contained in the generic_unit field.")]
        TYPE_GENERIC,
    }

    public static class MeasurementUnitUnitTypeStringValues
    {
        public const string TYPE_CUSTOM = @"TYPE_CUSTOM";
        public const string TYPE_AREA = @"TYPE_AREA";
        public const string TYPE_LENGTH = @"TYPE_LENGTH";
        public const string TYPE_VOLUME = @"TYPE_VOLUME";
        public const string TYPE_WEIGHT = @"TYPE_WEIGHT";
        public const string TYPE_GENERIC = @"TYPE_GENERIC";
    }

    ///<summary>
    ///The unit of volume used to measure a quantity.
    ///</summary>
    [Description("The unit of volume used to measure a quantity.")]
    public enum MeasurementUnitVolume
    {
        ///<summary>
        ///The volume is measured in ounces.
        ///</summary>
        [Description("The volume is measured in ounces.")]
        GENERIC_FLUID_OUNCE,
        ///<summary>
        ///The volume is measured in shots.
        ///</summary>
        [Description("The volume is measured in shots.")]
        GENERIC_SHOT,
        ///<summary>
        ///The volume is measured in cups.
        ///</summary>
        [Description("The volume is measured in cups.")]
        GENERIC_CUP,
        ///<summary>
        ///The volume is measured in pints.
        ///</summary>
        [Description("The volume is measured in pints.")]
        GENERIC_PINT,
        ///<summary>
        ///The volume is measured in quarts.
        ///</summary>
        [Description("The volume is measured in quarts.")]
        GENERIC_QUART,
        ///<summary>
        ///The volume is measured in gallons.
        ///</summary>
        [Description("The volume is measured in gallons.")]
        GENERIC_GALLON,
        ///<summary>
        ///The volume is measured in cubic inches.
        ///</summary>
        [Description("The volume is measured in cubic inches.")]
        IMPERIAL_CUBIC_INCH,
        ///<summary>
        ///The volume is measured in cubic feet.
        ///</summary>
        [Description("The volume is measured in cubic feet.")]
        IMPERIAL_CUBIC_FOOT,
        ///<summary>
        ///The volume is measured in cubic yards.
        ///</summary>
        [Description("The volume is measured in cubic yards.")]
        IMPERIAL_CUBIC_YARD,
        ///<summary>
        ///The volume is measured in metric milliliters.
        ///</summary>
        [Description("The volume is measured in metric milliliters.")]
        METRIC_MILLILITER,
        ///<summary>
        ///The volume is measured in metric liters.
        ///</summary>
        [Description("The volume is measured in metric liters.")]
        METRIC_LITER,
    }

    public static class MeasurementUnitVolumeStringValues
    {
        public const string GENERIC_FLUID_OUNCE = @"GENERIC_FLUID_OUNCE";
        public const string GENERIC_SHOT = @"GENERIC_SHOT";
        public const string GENERIC_CUP = @"GENERIC_CUP";
        public const string GENERIC_PINT = @"GENERIC_PINT";
        public const string GENERIC_QUART = @"GENERIC_QUART";
        public const string GENERIC_GALLON = @"GENERIC_GALLON";
        public const string IMPERIAL_CUBIC_INCH = @"IMPERIAL_CUBIC_INCH";
        public const string IMPERIAL_CUBIC_FOOT = @"IMPERIAL_CUBIC_FOOT";
        public const string IMPERIAL_CUBIC_YARD = @"IMPERIAL_CUBIC_YARD";
        public const string METRIC_MILLILITER = @"METRIC_MILLILITER";
        public const string METRIC_LITER = @"METRIC_LITER";
    }

    ///<summary>
    ///MeasurementUnitVolumeValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("MeasurementUnitVolumeValue\n\nPermissions:ITEMS_READ")]
    public class MeasurementUnitVolumeValue : GraphQLObject<MeasurementUnitVolumeValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard volume unit.
        ///</summary>
        [Description("Represents a standard volume unit.")]
        public MeasurementUnitVolume? value { get; set; }
    }

    ///<summary>
    ///Unit of weight used to measure a quantity.
    ///</summary>
    [Description("Unit of weight used to measure a quantity.")]
    public enum MeasurementUnitWeight
    {
        ///<summary>
        ///The weight is measured in ounces.
        ///</summary>
        [Description("The weight is measured in ounces.")]
        IMPERIAL_WEIGHT_OUNCE,
        ///<summary>
        ///The weight is measured in pounds.
        ///</summary>
        [Description("The weight is measured in pounds.")]
        IMPERIAL_POUND,
        ///<summary>
        ///The weight is measured in stones.
        ///</summary>
        [Description("The weight is measured in stones.")]
        IMPERIAL_STONE,
        ///<summary>
        ///The weight is measured in milligrams.
        ///</summary>
        [Description("The weight is measured in milligrams.")]
        METRIC_MILLIGRAM,
        ///<summary>
        ///The weight is measured in grams.
        ///</summary>
        [Description("The weight is measured in grams.")]
        METRIC_GRAM,
        ///<summary>
        ///The weight is measured in kilograms.
        ///</summary>
        [Description("The weight is measured in kilograms.")]
        METRIC_KILOGRAM,
    }

    public static class MeasurementUnitWeightStringValues
    {
        public const string IMPERIAL_WEIGHT_OUNCE = @"IMPERIAL_WEIGHT_OUNCE";
        public const string IMPERIAL_POUND = @"IMPERIAL_POUND";
        public const string IMPERIAL_STONE = @"IMPERIAL_STONE";
        public const string METRIC_MILLIGRAM = @"METRIC_MILLIGRAM";
        public const string METRIC_GRAM = @"METRIC_GRAM";
        public const string METRIC_KILOGRAM = @"METRIC_KILOGRAM";
    }

    ///<summary>
    ///MeasurementUnitWeightValue
    ///
    ///Permissions:ITEMS_READ
    ///</summary>
    [Description("MeasurementUnitWeightValue\n\nPermissions:ITEMS_READ")]
    public class MeasurementUnitWeightValue : GraphQLObject<MeasurementUnitWeightValue>, IMeasurementUnit
    {
        ///<summary>
        ///Represents a standard unit of weight or mass.
        ///</summary>
        [Description("Represents a standard unit of weight or mass.")]
        public MeasurementUnitWeight? value { get; set; }
    }

    ///<summary>
    ///A Square seller.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    [Description("A Square seller.\n\nPermissions:MERCHANT_PROFILE_READ")]
    public class Merchant : GraphQLObject<Merchant>
    {
        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The business name of the merchant.
        ///</summary>
        [Description("The business name of the merchant.")]
        public string? businessName { get; set; }

        ///<summary>
        ///The country associated with the merchant.
        ///</summary>
        [Description("The country associated with the merchant.")]
        public Country? country { get; set; }

        ///<summary>
        ///The time when the merchant was created, in RFC 3339 format. For more information, see Working with Dates.
        ///</summary>
        [Description("The time when the merchant was created, in RFC 3339 format. For more information, see Working with Dates.")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///The currency associated with the merchant.
        ///</summary>
        [Description("The currency associated with the merchant.")]
        public Currency? currency { get; set; }

        ///<summary>
        ///The language associated with the merchant account.
        ///</summary>
        [Description("The language associated with the merchant account.")]
        public string? language { get; set; }

        ///<summary>
        ///The locations for the merchant.
        ///</summary>
        [Description("The locations for the merchant.")]
        public LocationConnection? locations { get; set; }

        ///<summary>
        ///The main location of the merchant.
        ///</summary>
        [Description("The main location of the merchant.")]
        [NonNull]
        public Location? mainLocation { get; set; }

        ///<summary>
        ///The merchant's status.
        ///</summary>
        [Description("The merchant's status.")]
        public MerchantStatus? status { get; set; }
    }

    ///<summary>
    ///List of Merchant.
    ///
    ///Permissions:MERCHANT_PROFILE_READ
    ///</summary>
    [Description("List of Merchant.\n\nPermissions:MERCHANT_PROFILE_READ")]
    public class MerchantConnection : GraphQLObject<MerchantConnection>, IConnectionWithNodes<Merchant>
    {
        ///<summary>
        ///A list of Merchant.
        ///</summary>
        [Description("A list of Merchant.")]
        [NonNull]
        public IEnumerable<Merchant>? nodes { get; set; }

        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///The public capabilities a merchant might have.
    ///</summary>
    [Description("The public capabilities a merchant might have.")]
    public enum MerchantPublicCapability
    {
        IS_SANDBOX,
        POINT_OF_SALE,
        SELL_CANNABIS,
        UNKNOWN_CAPABILITY,
    }

    public static class MerchantPublicCapabilityStringValues
    {
        public const string IS_SANDBOX = @"IS_SANDBOX";
        public const string POINT_OF_SALE = @"POINT_OF_SALE";
        public const string SELL_CANNABIS = @"SELL_CANNABIS";
        public const string UNKNOWN_CAPABILITY = @"UNKNOWN_CAPABILITY";
    }

    ///<summary>
    ///Merchant status.
    ///</summary>
    [Description("Merchant status.")]
    public enum MerchantStatus
    {
        ///<summary>
        ///A fully operational merchant account. The merchant can interact with Square products and APIs.
        ///</summary>
        [Description("A fully operational merchant account. The merchant can interact with Square products and APIs.")]
        ACTIVE,
        DELETED,
        ///<summary>
        ///A functionally limited merchant account. The merchant can only have limited interaction via Square APIs. The merchant cannot log in or access the seller dashboard.
        ///</summary>
        [Description("A functionally limited merchant account. The merchant can only have limited interaction via Square APIs. The merchant cannot log in or access the seller dashboard.")]
        INACTIVE,
    }

    public static class MerchantStatusStringValues
    {
        public const string ACTIVE = @"ACTIVE";
        public const string DELETED = @"DELETED";
        public const string INACTIVE = @"INACTIVE";
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
    [Description("Application-defined data attached to an object. Metadata fields are intended to store descriptive references or\nassociations with an entity in another system or store brief information about the object. Square does not process\nthis field; it only stores and returns it in relevant API calls. Do not use metadata to store any sensitive\ninformation (personally identifiable information, card details, etc.).\n\nKeys written by applications must be 60 characters or less and must be in the character set [a-zA-Z0-9_-]. Entries\nmay also include metadata generated by Square. These keys are prefixed with a namespace, separated from the key with\na ':' character.\n\nValues have a max length of 255 characters.\n\nAn application may have up to 10 entries per metadata field.\n\nEntries written by applications are private and can only be read or modified by the same application.\n\nSee [Metadata](https://developer.squareup.com/docs/orders-api/metadata) for more information.")]
    public class Metadata : GraphQLObject<Metadata>
    {
        ///<summary>
        ///A list of entries.
        ///</summary>
        [Description("A list of entries.")]
        public IEnumerable<MetadataEntry>? entries { get; set; }
    }

    ///<summary>
    ///A key-value pair for Metadata.
    ///</summary>
    [Description("A key-value pair for Metadata.")]
    public class MetadataEntry : GraphQLObject<MetadataEntry>
    {
        ///<summary>
        ///The key of the Metadata entry
        ///</summary>
        [Description("The key of the Metadata entry")]
        public string? key { get; set; }

        ///<summary>
        ///The value of the Metadata entry
        ///</summary>
        [Description("The value of the Metadata entry")]
        public string? value { get; set; }
    }

    ///<summary>
    ///Location-specific overrides for specified properties of a `CatalogModifier` object.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Location-specific overrides for specified properties of a `CatalogModifier` object.\nPermissions: ITEMS_READ")]
    public class ModifierLocationOverride : GraphQLObject<ModifierLocationOverride>
    {
        ///<summary>
        ///The overridden price at the specified location. If this is unspecified, the modifier price is not overridden. 
        ///The modifier becomes free of charge at the specified location, when this `price_money` field is set to 0.
        ///</summary>
        [Description("The overridden price at the specified location. If this is unspecified, the modifier price is not overridden. \nThe modifier becomes free of charge at the specified location, when this `price_money` field is set to 0.")]
        public Money? priceMoney { get; set; }

        ///<summary>
        ///The ID of the `Location` object representing the location. This can include a deactivated location.
        ///</summary>
        [Description("The ID of the `Location` object representing the location. This can include a deactivated location.")]
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
    [Description("Represents an amount of money.\n\nMoney fields can be signed or unsigned. Fields that do not explicitly define whether they are signed or unsigned are\nconsidered unsigned and can only hold positive amounts. For signed fields, the sign of the value indicates the purpose\nof the money transfer. See\n[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts) for\nmore information.")]
    public class Money : GraphQLObject<Money>
    {
        ///<summary>
        ///The amount of money, in the smallest denomination of the currency indicated by currency. For example, when currency
        ///is USD, amount is in cents. Monetary amounts can be positive or negative. See the specific field description to
        ///determine the meaning of the sign in a particular case.
        ///</summary>
        [Description("The amount of money, in the smallest denomination of the currency indicated by currency. For example, when currency\nis USD, amount is in cents. Monetary amounts can be positive or negative. See the specific field description to\ndetermine the meaning of the sign in a particular case.")]
        [NonNull]
        public long? amount { get; set; }

        ///<summary>
        ///The type of currency in currency code.
        ///</summary>
        [Description("The type of currency in currency code.")]
        public Currency? currency { get; set; }
    }

    ///<summary>
    ///OAuth scopes
    ///</summary>
    [Description("OAuth scopes")]
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

    public static class OAuthScopeStringValues
    {
        public const string APPOINTMENTS_ALL_READ = @"APPOINTMENTS_ALL_READ";
        public const string APPOINTMENTS_READ = @"APPOINTMENTS_READ";
        public const string BANK_ACCOUNTS_READ = @"BANK_ACCOUNTS_READ";
        public const string CASH_DRAWER_READ = @"CASH_DRAWER_READ";
        public const string CUSTOMERS_READ = @"CUSTOMERS_READ";
        public const string DISPUTES_READ = @"DISPUTES_READ";
        public const string EMPLOYEES_READ = @"EMPLOYEES_READ";
        public const string GIFTCARDS_READ = @"GIFTCARDS_READ";
        public const string INVENTORY_READ = @"INVENTORY_READ";
        public const string INVOICES_READ = @"INVOICES_READ";
        public const string ITEMS_READ = @"ITEMS_READ";
        public const string LOYALTY_READ = @"LOYALTY_READ";
        public const string MERCHANT_PROFILE_READ = @"MERCHANT_PROFILE_READ";
        public const string NONE = @"NONE";
        public const string ONLINE_STORE_SITE_READ = @"ONLINE_STORE_SITE_READ";
        public const string ONLINE_STORE_SNIPPETS_READ = @"ONLINE_STORE_SNIPPETS_READ";
        public const string ORDERS_READ = @"ORDERS_READ";
        public const string PAYMENTS_READ = @"PAYMENTS_READ";
        public const string SETTLEMENTS_READ = @"SETTLEMENTS_READ";
        public const string SUBSCRIPTIONS_READ = @"SUBSCRIPTIONS_READ";
        public const string TIMECARDS_READ = @"TIMECARDS_READ";
        public const string TIMECARDS_SETTINGS_READ = @"TIMECARDS_SETTINGS_READ";
        public const string VENDOR_READ = @"VENDOR_READ";
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
    [Description("Contains all information related to a single order to process with Square,\nincluding line items that specify the products to purchase.`Order` objects also\ninclude information about any associated tenders, refunds, and returns.\n\nAll Connect V2 Transactions have all been converted to Orders including all associated\nitemization data.\nPermissions: ORDERS_READ")]
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
        [Description("The timestamp for when the order reached a terminal state, in RFC 3339 format (for example \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The timestamp for when the order was created, in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///The ID of the customer associated with the order.
        ///  
        ///You should specify a `customer_id` on the order (or the payment) to ensure that transactions
        ///are reliably linked to customers. Omitting this field might result in the creation of new
        ///[instant profiles](https://developer.squareup.com/docs/customers-api/what-it-does#instant-profiles).
        ///</summary>
        [Description("The ID of the customer associated with the order.\n  \nYou should specify a `customer_id` on the order (or the payment) to ensure that transactions\nare reliably linked to customers. Omitting this field might result in the creation of new\n[instant profiles](https://developer.squareup.com/docs/customers-api/what-it-does#instant-profiles).")]
        public Customer? customer { get; set; }

        ///<summary>
        ///A set-like list of DiscountCodes that have been added to the Order.
        ///</summary>
        [Description("A set-like list of DiscountCodes that have been added to the Order.")]
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
        [Description("The list of all discounts associated with the order.\n  \nDiscounts can be scoped to either `ORDER` or `LINE_ITEM`. For discounts scoped to `LINE_ITEM`,\nan `OrderLineItemAppliedDiscount` must be added to each line item that the discount applies to.\nFor discounts with `ORDER` scope, the server generates an `OrderLineItemAppliedDiscount`\nfor every line item.\n  \n__IMPORTANT__: If `LINE_ITEM` scope is set on any discounts in this field, using the deprecated\n`line_items.discounts` field results in an error. Use `line_items.applied_discounts`\ninstead.")]
        public IEnumerable<OrderLineItemDiscount>? discounts { get; set; }

        ///<summary>
        ///Details about order fulfillment.
        ///  
        ///Orders can only be created with at most one fulfillment. However, orders returned
        ///by the API might contain multiple fulfillments.
        ///</summary>
        [Description("Details about order fulfillment.\n  \nOrders can only be created with at most one fulfillment. However, orders returned\nby the API might contain multiple fulfillments.")]
        public IEnumerable<OrderFulfillment>? fulfillments { get; set; }

        ///<summary>
        ///The order's unique ID.
        ///</summary>
        [Description("The order's unique ID.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The line items included in the order.
        ///</summary>
        [Description("The line items included in the order.")]
        public IEnumerable<OrderLineItem>? lineItems { get; set; }

        ///<summary>
        ///The ID of the seller location that this order is associated with.
        ///</summary>
        [Description("The ID of the seller location that this order is associated with.")]
        public Location? location { get; set; }

        [NonNull]
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
        [Description("Application-defined data attached to this order. Metadata fields are intended\nto store descriptive references or associations with an entity in another system or store brief\ninformation about the object. Square does not process this field; it only stores and returns it\nin relevant API calls. Do not use metadata to store any sensitive information (such as personally\nidentifiable information or card details).\n  \nKeys written by applications must be 60 characters or less and must be in the character set\n`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed\nwith a namespace, separated from the key with a ':' character.\n  \nValues have a maximum length of 255 characters.\n  \nAn application can have up to 10 entries per metadata field.\n  \nEntries written by applications are private and can only be read or modified by the same\napplication.\n  \nFor more information, see  [Metadata](https://developer.squareup.com/docs/build-basics/metadata).")]
        public Metadata? metadata { get; set; }

        ///<summary>
        ///The net amount of money due on the order.
        ///</summary>
        [Description("The net amount of money due on the order.")]
        public Money? netAmountDue { get; set; }

        ///<summary>
        ///The net money amounts (sale money - return money).
        ///</summary>
        [Description("The net money amounts (sale money - return money).")]
        public OrderMoneyAmounts? netAmounts { get; set; }

        ///<summary>
        ///Pricing options for an order. The options affect how the order's price is calculated.
        ///They can be used, for example, to apply automatic price adjustments that are based on
        ///preconfigured pricing rules.
        ///</summary>
        [Description("Pricing options for an order. The options affect how the order's price is calculated.\nThey can be used, for example, to apply automatic price adjustments that are based on\npreconfigured pricing rules.")]
        public OrderPricingOptions? pricingOptions { get; set; }

        ///<summary>
        ///A client-specified ID to associate an entity in another system
        ///with this order.
        ///</summary>
        [Description("A client-specified ID to associate an entity in another system\nwith this order.")]
        public string? referenceId { get; set; }

        ///<summary>
        ///The refunds that are part of this order.
        ///</summary>
        [Description("The refunds that are part of this order.")]
        public IEnumerable<Refund>? refunds { get; set; }

        ///<summary>
        ///The rollup of the returned money amounts.
        ///</summary>
        [Description("The rollup of the returned money amounts.")]
        public OrderMoneyAmounts? returnAmounts { get; set; }

        ///<summary>
        ///A collection of items from sale orders being returned in this one. Normally part of an
        ///itemized return or exchange. There is exactly one `Return` object per sale `Order` being
        ///referenced.
        ///</summary>
        [Description("A collection of items from sale orders being returned in this one. Normally part of an\nitemized return or exchange. There is exactly one `Return` object per sale `Order` being\nreferenced.")]
        public IEnumerable<OrderReturn>? returns { get; set; }

        ///<summary>
        ///A set-like list of Rewards that have been added to the Order.
        ///</summary>
        [Description("A set-like list of Rewards that have been added to the Order.")]
        public IEnumerable<Reward>? rewards { get; set; }

        ///<summary>
        ///A positive rounding adjustment to the total of the order. This adjustment is commonly
        ///used to apply cash rounding when the minimum unit of account is smaller than the lowest physical
        ///denomination of the currency.
        ///</summary>
        [Description("A positive rounding adjustment to the total of the order. This adjustment is commonly\nused to apply cash rounding when the minimum unit of account is smaller than the lowest physical\ndenomination of the currency.")]
        public OrderRoundingAdjustment? roundingAdjustment { get; set; }

        ///<summary>
        ///A list of service charges applied to the order.
        ///</summary>
        [Description("A list of service charges applied to the order.")]
        public IEnumerable<OrderServiceCharge>? serviceCharges { get; set; }

        ///<summary>
        ///The origination details of the order.
        ///</summary>
        [Description("The origination details of the order.")]
        public OrderSource? source { get; set; }

        ///<summary>
        ///The current state of the order.
        ///</summary>
        [Description("The current state of the order.")]
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
        [Description("The list of all taxes associated with the order.\n  \nTaxes can be scoped to either `ORDER` or `LINE_ITEM`. For taxes with `LINE_ITEM` scope, an\n`OrderLineItemAppliedTax` must be added to each line item that the tax applies to. For taxes\nwith `ORDER` scope, the server generates an `OrderLineItemAppliedTax` for every line item.\n  \nOn reads, each tax in the list includes the total amount of that tax applied to the order.\n  \n__IMPORTANT__: If `LINE_ITEM` scope is set on any taxes in this field, using the deprecated\n`line_items.taxes` field results in an error. Use `line_items.applied_taxes`\ninstead.")]
        public IEnumerable<OrderLineItemTax>? taxes { get; set; }

        ///<summary>
        ///The tenders that were used to pay for the order.
        ///</summary>
        [Description("The tenders that were used to pay for the order.")]
        public IEnumerable<IOrderTender>? tenders { get; set; }

        ///<summary>
        ///A short-term identifier for the order (such as a customer first name,
        ///table number, or auto-generated order number that resets daily).
        ///</summary>
        [Description("A short-term identifier for the order (such as a customer first name,\ntable number, or auto-generated order number that resets daily).")]
        public string? ticketName { get; set; }

        ///<summary>
        ///The total amount of discount money to collect for the order.
        ///</summary>
        [Description("The total amount of discount money to collect for the order.")]
        public Money? totalDiscount { get; set; }

        ///<summary>
        ///The total amount of money to collect for the order.
        ///</summary>
        [Description("The total amount of money to collect for the order.")]
        public Money? totalMoney { get; set; }

        ///<summary>
        ///The total amount of money collected in service charges for the order.
        ///  
        ///Note: `total_service_charge_money` is the sum of `applied_money` fields for each individual
        ///service charge. Therefore, `total_service_charge_money` only includes inclusive tax amounts,
        ///not additive tax amounts.
        ///</summary>
        [Description("The total amount of money collected in service charges for the order.\n  \nNote: `total_service_charge_money` is the sum of `applied_money` fields for each individual\nservice charge. Therefore, `total_service_charge_money` only includes inclusive tax amounts,\nnot additive tax amounts.")]
        public Money? totalServiceCharge { get; set; }

        ///<summary>
        ///The total amount of tax money to collect for the order.
        ///</summary>
        [Description("The total amount of tax money to collect for the order.")]
        public Money? totalTax { get; set; }

        ///<summary>
        ///The total amount of tip money to collect for the order.
        ///</summary>
        [Description("The total amount of tip money to collect for the order.")]
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
        [Description("The timestamp for when the order was last updated, in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///The version number, which is incremented each time an update is committed to the order.
        ///Orders not created through the API do not include a version number and
        ///therefore cannot be updated.
        ///  
        ///[Read more about working with versions](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders).
        ///</summary>
        [Description("The version number, which is incremented each time an update is committed to the order.\nOrders not created through the API do not include a version number and\ntherefore cannot be updated.\n  \n[Read more about working with versions](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders).")]
        public long? version { get; set; }
    }

    ///<summary>
    ///Represents the details of a tender with `type` `BANK_ACCOUNT`.See BankAccountPaymentDetails
    ///for more exposed details of a bank account payment.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents the details of a tender with `type` `BANK_ACCOUNT`.See BankAccountPaymentDetails\nfor more exposed details of a bank account payment.\nPermissions: ORDERS_READ")]
    public class OrderBankAccountTender : GraphQLObject<OrderBankAccountTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        [Description("The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,\nthe `total_money` of the corresponding Payment will be equal to the\n`amount_money` of the tender.")]
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
        [Description("The timestamp for when the tender was created, in RFC 3339 format.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        [Description("If the tender is associated with a customer or represents a customer's card on file,\nthis is the ID of the associated customer.")]
        public Customer? customer { get; set; }

        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        [Description("The tender's unique ID. It is the associated payment ID.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        [Description("The ID of the transaction's associated location.")]
        public Location? location { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        [Description("An optional note associated with the tender at the time of payment.")]
        public string? note { get; set; }

        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        [Description("The ID of the Payment that corresponds to this tender.\nThis value is only present for payments created with the v2 Payments API.")]
        public Payment? payment { get; set; }

        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        [Description("The amount of any Square processing fees applied to the tender.\n  \nThis field is not immediately populated when a new transaction is created.\nIt is usually available after about ten seconds.")]
        public Money? processingFee { get; set; }

        ///<summary>
        ///The bank account payment's current state.
        ///</summary>
        [Description("The bank account payment's current state.")]
        public OrderBankAccountTenderStatus? status { get; set; }

        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        [Description("The tip's amount of the tender.")]
        public Money? tip { get; set; }

        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        [Description("The ID of the tender's associated transaction.")]
        public string? transactionId { get; set; }

        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        [Description("The type of tender, such as `CARD` or `CASH`.")]
        public OrderTenderType? type { get; set; }
    }

    ///<summary>
    ///Indicates the bank account payment's current status.
    ///</summary>
    [Description("Indicates the bank account payment's current status.")]
    public enum OrderBankAccountTenderStatus
    {
        ///<summary>
        ///The bank account payment has been completed.
        ///</summary>
        [Description("The bank account payment has been completed.")]
        COMPLETED,
        ///<summary>
        ///The bank account payment failed.
        ///</summary>
        [Description("The bank account payment failed.")]
        FAILED,
        ///<summary>
        ///The bank account payment is in progress.
        ///</summary>
        [Description("The bank account payment is in progress.")]
        PENDING,
    }

    public static class OrderBankAccountTenderStatusStringValues
    {
        public const string COMPLETED = @"COMPLETED";
        public const string FAILED = @"FAILED";
        public const string PENDING = @"PENDING";
    }

    ///<summary>
    ///Represents the details of a tender with `type` `BUY_NOW_PAY_LATER`.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents the details of a tender with `type` `BUY_NOW_PAY_LATER`.\nPermissions: ORDERS_READ")]
    public class OrderBuyNowPayLaterTender : GraphQLObject<OrderBuyNowPayLaterTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        [Description("The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,\nthe `total_money` of the corresponding Payment will be equal to the\n`amount_money` of the tender.")]
        public Money? amount { get; set; }

        ///<summary>
        ///The Buy Now Pay Later brand.
        ///</summary>
        [Description("The Buy Now Pay Later brand.")]
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
        [Description("The timestamp for when the tender was created, in RFC 3339 format.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        [Description("If the tender is associated with a customer or represents a customer's card on file,\nthis is the ID of the associated customer.")]
        public Customer? customer { get; set; }

        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        [Description("The tender's unique ID. It is the associated payment ID.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        [Description("The ID of the transaction's associated location.")]
        public Location? location { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        [Description("An optional note associated with the tender at the time of payment.")]
        public string? note { get; set; }

        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        [Description("The ID of the Payment that corresponds to this tender.\nThis value is only present for payments created with the v2 Payments API.")]
        public Payment? payment { get; set; }

        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        [Description("The amount of any Square processing fees applied to the tender.\n  \nThis field is not immediately populated when a new transaction is created.\nIt is usually available after about ten seconds.")]
        public Money? processingFee { get; set; }

        ///<summary>
        ///The buy now pay later payment's current state (such as `AUTHORIZED` or
        ///`CAPTURED`). See TenderBuyNowPayLaterDetailsStatus
        ///for possible values.
        ///</summary>
        [Description("The buy now pay later payment's current state (such as `AUTHORIZED` or\n`CAPTURED`). See TenderBuyNowPayLaterDetailsStatus\nfor possible values.")]
        public OrderBuyNowPayLaterTenderStatus? status { get; set; }

        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        [Description("The tip's amount of the tender.")]
        public Money? tip { get; set; }

        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        [Description("The ID of the tender's associated transaction.")]
        public string? transactionId { get; set; }

        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        [Description("The type of tender, such as `CARD` or `CASH`.")]
        public OrderTenderType? type { get; set; }
    }

    public enum OrderBuyNowPayLaterTenderBrand
    {
        AFTERPAY,
        OTHER_BRAND,
    }

    public static class OrderBuyNowPayLaterTenderBrandStringValues
    {
        public const string AFTERPAY = @"AFTERPAY";
        public const string OTHER_BRAND = @"OTHER_BRAND";
    }

    public enum OrderBuyNowPayLaterTenderStatus
    {
        ///<summary>
        ///The buy now pay later payment has been authorized but not yet captured.
        ///</summary>
        [Description("The buy now pay later payment has been authorized but not yet captured.")]
        AUTHORIZED,
        ///<summary>
        ///The buy now pay later payment was authorized and subsequently captured (i.e., completed).
        ///</summary>
        [Description("The buy now pay later payment was authorized and subsequently captured (i.e., completed).")]
        CAPTURED,
        ///<summary>
        ///The buy now pay later payment failed.
        ///</summary>
        [Description("The buy now pay later payment failed.")]
        FAILED,
        ///<summary>
        ///The buy now pay later payment was authorized and subsequently voided (i.e., canceled).
        ///</summary>
        [Description("The buy now pay later payment was authorized and subsequently voided (i.e., canceled).")]
        VOIDED,
    }

    public static class OrderBuyNowPayLaterTenderStatusStringValues
    {
        public const string AUTHORIZED = @"AUTHORIZED";
        public const string CAPTURED = @"CAPTURED";
        public const string FAILED = @"FAILED";
        public const string VOIDED = @"VOIDED";
    }

    ///<summary>
    ///Represents additional details of a tender with `type` `CARD` or `SQUARE_GIFT_CARD`
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents additional details of a tender with `type` `CARD` or `SQUARE_GIFT_CARD`\nPermissions: ORDERS_READ")]
    public class OrderCardTender : GraphQLObject<OrderCardTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        [Description("The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,\nthe `total_money` of the corresponding Payment will be equal to the\n`amount_money` of the tender.")]
        public Money? amount { get; set; }

        ///<summary>
        ///The credit card's non-confidential details.
        ///</summary>
        [Description("The credit card's non-confidential details.")]
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
        [Description("The timestamp for when the tender was created, in RFC 3339 format.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        [Description("If the tender is associated with a customer or represents a customer's card on file,\nthis is the ID of the associated customer.")]
        public Customer? customer { get; set; }

        ///<summary>
        ///The method used to enter the card's details for the transaction.
        ///</summary>
        [Description("The method used to enter the card's details for the transaction.")]
        public OrderCardTenderEntryMethod? entryMethod { get; set; }

        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        [Description("The tender's unique ID. It is the associated payment ID.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        [Description("The ID of the transaction's associated location.")]
        public Location? location { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        [Description("An optional note associated with the tender at the time of payment.")]
        public string? note { get; set; }

        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        [Description("The ID of the Payment that corresponds to this tender.\nThis value is only present for payments created with the v2 Payments API.")]
        public Payment? payment { get; set; }

        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        [Description("The amount of any Square processing fees applied to the tender.\n  \nThis field is not immediately populated when a new transaction is created.\nIt is usually available after about ten seconds.")]
        public Money? processingFee { get; set; }

        ///<summary>
        ///The credit card payment's current state (such as `AUTHORIZED` or
        ///`CAPTURED`). See TenderCardDetailsStatus
        ///for possible values.
        ///</summary>
        [Description("The credit card payment's current state (such as `AUTHORIZED` or\n`CAPTURED`). See TenderCardDetailsStatus\nfor possible values.")]
        public OrderCardTenderStatus? status { get; set; }

        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        [Description("The tip's amount of the tender.")]
        public Money? tip { get; set; }

        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        [Description("The ID of the tender's associated transaction.")]
        public string? transactionId { get; set; }

        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        [Description("The type of tender, such as `CARD` or `CASH`.")]
        public OrderTenderType? type { get; set; }
    }

    ///<summary>
    ///Indicates the method used to enter the card's details.
    ///</summary>
    [Description("Indicates the method used to enter the card's details.")]
    public enum OrderCardTenderEntryMethod
    {
        ///<summary>
        ///The card was processed via a contactless (i.e., NFC) transaction
        ///with a Square reader.
        ///</summary>
        [Description("The card was processed via a contactless (i.e., NFC) transaction\nwith a Square reader.")]
        CONTACTLESS,
        ///<summary>
        ///The card was processed via EMV with a Square reader.
        ///</summary>
        [Description("The card was processed via EMV with a Square reader.")]
        EMV,
        ///<summary>
        ///The card information was keyed manually into Square Point of Sale or a
        ///Square-hosted web form.
        ///</summary>
        [Description("The card information was keyed manually into Square Point of Sale or a\nSquare-hosted web form.")]
        KEYED,
        ///<summary>
        ///The buyer's card details were already on file with Square.
        ///</summary>
        [Description("The buyer's card details were already on file with Square.")]
        ON_FILE,
        ///<summary>
        ///The card was swiped through a Square reader or Square stand.
        ///</summary>
        [Description("The card was swiped through a Square reader or Square stand.")]
        SWIPED,
    }

    public static class OrderCardTenderEntryMethodStringValues
    {
        public const string CONTACTLESS = @"CONTACTLESS";
        public const string EMV = @"EMV";
        public const string KEYED = @"KEYED";
        public const string ON_FILE = @"ON_FILE";
        public const string SWIPED = @"SWIPED";
    }

    ///<summary>
    ///Indicates the card transaction's current status.
    ///</summary>
    [Description("Indicates the card transaction's current status.")]
    public enum OrderCardTenderStatus
    {
        ///<summary>
        ///The card transaction has been authorized but not yet captured.
        ///</summary>
        [Description("The card transaction has been authorized but not yet captured.")]
        AUTHORIZED,
        ///<summary>
        ///The card transaction was authorized and subsequently captured (i.e., completed).
        ///</summary>
        [Description("The card transaction was authorized and subsequently captured (i.e., completed).")]
        CAPTURED,
        ///<summary>
        ///The card transaction failed.
        ///</summary>
        [Description("The card transaction failed.")]
        FAILED,
        ///<summary>
        ///The card transaction was authorized and subsequently voided (i.e., canceled).
        ///</summary>
        [Description("The card transaction was authorized and subsequently voided (i.e., canceled).")]
        VOIDED,
    }

    public static class OrderCardTenderStatusStringValues
    {
        public const string AUTHORIZED = @"AUTHORIZED";
        public const string CAPTURED = @"CAPTURED";
        public const string FAILED = @"FAILED";
        public const string VOIDED = @"VOIDED";
    }

    ///<summary>
    ///Represents the details of a tender with `type` `CASH`.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents the details of a tender with `type` `CASH`.\nPermissions: ORDERS_READ")]
    public class OrderCashTender : GraphQLObject<OrderCashTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        [Description("The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,\nthe `total_money` of the corresponding Payment will be equal to the\n`amount_money` of the tender.")]
        public Money? amount { get; set; }

        ///<summary>
        ///The total amount of cash provided by the buyer, before change is given.
        ///</summary>
        [Description("The total amount of cash provided by the buyer, before change is given.")]
        public Money? buyerTenderedMoney { get; set; }

        ///<summary>
        ///The amount of change returned to the buyer.
        ///</summary>
        [Description("The amount of change returned to the buyer.")]
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
        [Description("The timestamp for when the tender was created, in RFC 3339 format.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        [Description("If the tender is associated with a customer or represents a customer's card on file,\nthis is the ID of the associated customer.")]
        public Customer? customer { get; set; }

        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        [Description("The tender's unique ID. It is the associated payment ID.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        [Description("The ID of the transaction's associated location.")]
        public Location? location { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        [Description("An optional note associated with the tender at the time of payment.")]
        public string? note { get; set; }

        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        [Description("The ID of the Payment that corresponds to this tender.\nThis value is only present for payments created with the v2 Payments API.")]
        public Payment? payment { get; set; }

        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        [Description("The amount of any Square processing fees applied to the tender.\n  \nThis field is not immediately populated when a new transaction is created.\nIt is usually available after about ten seconds.")]
        public Money? processingFee { get; set; }

        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        [Description("The tip's amount of the tender.")]
        public Money? tip { get; set; }

        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        [Description("The ID of the tender's associated transaction.")]
        public string? transactionId { get; set; }

        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        [Description("The type of tender, such as `CARD` or `CASH`.")]
        public OrderTenderType? type { get; set; }
    }

    ///<summary>
    ///A list of Orders.
    ///
    ///Permissions:ORDERS_READ
    ///</summary>
    [Description("A list of Orders.\n\nPermissions:ORDERS_READ")]
    public class OrderConnection : GraphQLObject<OrderConnection>, IConnectionWithNodes<Order>
    {
        ///<summary>
        ///List of Order.
        ///</summary>
        [Description("List of Order.")]
        [NonNull]
        public IEnumerable<Order>? nodes { get; set; }

        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }
    }

    ///<summary>
    ///Specific details for curbside pickup.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Specific details for curbside pickup.\nPermissions: ORDERS_READ")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the buyer arrived and is waiting for pickup. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? buyerArrivedAt { get; set; }

        ///<summary>
        ///Specific details for curbside pickup, such as parking number and vehicle model.
        ///</summary>
        [Description("Specific details for curbside pickup, such as parking number and vehicle model.")]
        public string? curbsideDetails { get; set; }
    }

    ///<summary>
    ///Describes delivery details of an order fulfillment.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Describes delivery details of an order fulfillment.\nPermissions: ORDERS_READ")]
    public class OrderDelivery : GraphQLObject<OrderDelivery>
    {
        ///<summary>
        ///The delivery cancellation reason. Max length: 100 characters.
        ///</summary>
        [Description("The delivery cancellation reason. Max length: 100 characters.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment was canceled. This field is automatically\nset when the fulfillment `state` changes to `CANCELED`.\n  \nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicates when the seller completed the fulfillment.\nThis field is automatically set when  fulfillment `state` changes to `COMPLETED`.\nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when an order can be picked up by the courier for delivery.\nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The period of time in which the order should be picked up by the courier after the\n`courier_pickup_at` timestamp.\nThe time must be in RFC 3339 format (for example, \"P1W3D\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public string? courierPickupWindowDuration { get; set; }

        ///<summary>
        ///The name of the courier provider.
        ///</summary>
        [Description("The name of the courier provider.")]
        public string? courierProviderName { get; set; }

        ///<summary>
        ///The support phone number of the courier.
        ///</summary>
        [Description("The support phone number of the courier.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nthat represents the start of the delivery period.\nWhen the fulfillment `schedule_type` is `ASAP`, the field is automatically\nset to the current time plus the `prep_time_duration`.\nOtherwise, the application can set this field while the fulfillment `state` is\n`PROPOSED`, `RESERVED`, or `PREPARED` (any time before the\nterminal state such as `COMPLETED`, `CANCELED`, and `FAILED`).\n  \nThe timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment was delivered to the recipient.\nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The time period after the `deliver_at` timestamp in which to deliver the order.\nApplications can set this field when the fulfillment `state` is\n`PROPOSED`, `RESERVED`, or `PREPARED` (any time before the terminal state\nsuch as `COMPLETED`, `CANCELED`, and `FAILED`).\n  \nThe timestamp must be in RFC 3339 format (for example, \"P1W3D\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public string? deliveryWindowDuration { get; set; }

        ///<summary>
        ///A note to provide additional instructions about how to deliver the order.
        ///</summary>
        [Description("A note to provide additional instructions about how to deliver the order.")]
        public string? dropoffNotes { get; set; }

        ///<summary>
        ///The identifier for the delivery created by the third-party courier service.
        ///</summary>
        [Description("The identifier for the delivery created by the third-party courier service.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicates when the seller started processing the fulfillment.\nThis field is automatically set when the fulfillment `state` changes to `RESERVED`.\nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? inProgressAt { get; set; }

        ///<summary>
        ///Whether the delivery is preferred to be no contact.
        ///</summary>
        [Description("Whether the delivery is preferred to be no contact.")]
        public bool? isNoContactDelivery { get; set; }

        ///<summary>
        ///The flag to indicate the delivery is managed by a third party (ie DoorDash), which means
        ///we may not receive all recipient information for PII purposes.
        ///</summary>
        [Description("The flag to indicate the delivery is managed by a third party (ie DoorDash), which means\nwe may not receive all recipient information for PII purposes.")]
        public bool? managedDelivery { get; set; }

        ///<summary>
        ///Provides additional instructions about the delivery fulfillment.
        ///It is displayed in the Square Point of Sale application and set by the API.
        ///</summary>
        [Description("Provides additional instructions about the delivery fulfillment.\nIt is displayed in the Square Point of Sale application and set by the API.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment was placed.\nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nMust be in RFC 3339 timestamp format, e.g., \"2016-09-04T23:59:33.123Z\".\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The duration of time it takes to prepare and deliver this fulfillment.\nThe timestamp must be in RFC 3339 format (for example, \"P1W3D\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the seller marked the fulfillment as ready for\ncourier pickup. This field is automatically set when the fulfillment `state` changes\nto PREPARED.\nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? readyAt { get; set; }

        ///<summary>
        ///The contact information for the person to receive the fulfillment.
        ///</summary>
        [Description("The contact information for the person to receive the fulfillment.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment was rejected. This field is\nautomatically set when the fulfillment `state` changes to `FAILED`.\nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? rejectedAt { get; set; }

        ///<summary>
        ///Indicates the fulfillment delivery schedule type. If `SCHEDULED`, then
        ///`deliver_at` is required. If `ASAP`, then `prep_time_duration` is required. The default is `SCHEDULED`.
        ///</summary>
        [Description("Indicates the fulfillment delivery schedule type. If `SCHEDULED`, then\n`deliver_at` is required. If `ASAP`, then `prep_time_duration` is required. The default is `SCHEDULED`.")]
        public OrderDeliveryScheduleType? scheduleType { get; set; }

        ///<summary>
        ///The identifier for the delivery created by Square.
        ///</summary>
        [Description("The identifier for the delivery created by Square.")]
        public string? squareDeliveryId { get; set; }
    }

    ///<summary>
    ///The schedule type of the delivery fulfillment.
    ///</summary>
    [Description("The schedule type of the delivery fulfillment.")]
    public enum OrderDeliveryScheduleType
    {
        ///<summary>
        ///Indicates that the fulfillment to deliver as soon as possible and should be prepared
        ///immediately.
        ///</summary>
        [Description("Indicates that the fulfillment to deliver as soon as possible and should be prepared\nimmediately.")]
        ASAP,
        ///<summary>
        ///Indicates the fulfillment to deliver at a scheduled deliver time.
        ///</summary>
        [Description("Indicates the fulfillment to deliver at a scheduled deliver time.")]
        SCHEDULED,
    }

    public static class OrderDeliveryScheduleTypeStringValues
    {
        public const string ASAP = @"ASAP";
        public const string SCHEDULED = @"SCHEDULED";
    }

    ///<summary>
    ///Contains details about how to fulfill this order.Orders can only be created with at most one fulfillment using the API.
    ///However, orders returned by the Orders API might contain multiple fulfillments because sellers can create multiple fulfillments using Square products such as Square Online.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Contains details about how to fulfill this order.Orders can only be created with at most one fulfillment using the API.\nHowever, orders returned by the Orders API might contain multiple fulfillments because sellers can create multiple fulfillments using Square products such as Square Online.\nPermissions: ORDERS_READ")]
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
        [Description("A list of entries pertaining to the fulfillment of an order. Each entry must reference\na valid `uid` for an order line item in the `line_item_uid` field, as well as a `quantity` to\nfulfill.\n  \nMultiple entries can reference the same line item `uid`, as long as the total quantity among\nall fulfillment entries referencing a single line item does not exceed the quantity of the\norder's line item itself.\n  \nAn order cannot be marked as `COMPLETED` before all fulfillments are `COMPLETED`,\n`CANCELED`, or `FAILED`. Fulfillments can be created and completed independently\nbefore order completion.")]
        public IEnumerable<OrderFulfillmentFulfillmentEntry>? entries { get; set; }

        ///<summary>
        ///Describes what order line items this fulfillment applies to.
        ///It can be `ALL` or `ENTRY_LIST` with a supplied list of fulfillment entries.
        ///</summary>
        [Description("Describes what order line items this fulfillment applies to.\nIt can be `ALL` or `ENTRY_LIST` with a supplied list of fulfillment entries.")]
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
        [Description("Application-defined data attached to this fulfillment. Metadata fields are intended\nto store descriptive references or associations with an entity in another system or store brief\ninformation about the object. Square does not process this field; it only stores and returns it\nin relevant API calls. Do not use metadata to store any sensitive information (such as personally\nidentifiable information or card details).\n  \nKeys written by applications must be 60 characters or less and must be in the character set\n`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed\nwith a namespace, separated from the key with a ':' character.\n  \nValues have a maximum length of 255 characters.\n  \nAn application can have up to 10 entries per metadata field.\n  \nEntries written by applications are private and can only be read or modified by the same\napplication.\n  \nFor more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).")]
        public Metadata? metadata { get; set; }

        ///<summary>
        ///Contains details for a pickup fulfillment. These details are required when the fulfillment
        ///type is `PICKUP`.
        ///</summary>
        [Description("Contains details for a pickup fulfillment. These details are required when the fulfillment\ntype is `PICKUP`.")]
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
        [Description("Contains details for a shipment fulfillment. These details are required when the fulfillment type\nis `SHIPMENT`.\n  \nA shipment fulfillment's relationship to fulfillment `state`:\n`PROPOSED`: A shipment is requested.\n`RESERVED`: Fulfillment accepted. Shipment processing.\n`PREPARED`: Shipment packaged. Shipping label created.\n`COMPLETED`: Package has been shipped.\n`CANCELED`: Shipment has been canceled.\n`FAILED`: Shipment has failed.")]
        public OrderShipment? shipment { get; set; }

        ///<summary>
        ///The state of the fulfillment.
        ///</summary>
        [Description("The state of the fulfillment.")]
        public OrderFulfillmentState? state { get; set; }

        ///<summary>
        ///The type of the fulfillment.
        ///</summary>
        [Description("The type of the fulfillment.")]
        public OrderFulfillmentType? type { get; set; }

        ///<summary>
        ///A unique ID that identifies the fulfillment only within this order.
        ///</summary>
        [Description("A unique ID that identifies the fulfillment only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Links an order line item to a fulfillment.Each entry must reference
    ///a valid `uid` for an order line item in the `line_item_uid` field, as well as a `quantity` to
    ///fulfill.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Links an order line item to a fulfillment.Each entry must reference\na valid `uid` for an order line item in the `line_item_uid` field, as well as a `quantity` to\nfulfill.\nPermissions: ORDERS_READ")]
    public class OrderFulfillmentFulfillmentEntry : GraphQLObject<OrderFulfillmentFulfillmentEntry>
    {
        ///<summary>
        ///The `uid` from the order line item.
        ///</summary>
        [Description("The `uid` from the order line item.")]
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
        [Description("Application-defined data attached to this fulfillment entry. Metadata fields are intended\nto store descriptive references or associations with an entity in another system or store brief\ninformation about the object. Square does not process this field; it only stores and returns it\nin relevant API calls. Do not use metadata to store any sensitive information (such as personally\nidentifiable information or card details).\n  \nKeys written by applications must be 60 characters or less and must be in the character set\n`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed\nwith a namespace, separated from the key with a ':' character.\n  \nValues have a maximum length of 255 characters.\n  \nAn application can have up to 10 entries per metadata field.\n  \nEntries written by applications are private and can only be read or modified by the same\napplication.\n  \nFor more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).")]
        public Metadata? metadata { get; set; }

        ///<summary>
        ///The quantity of the line item being fulfilled, formatted as a decimal number.
        ///For example, `"3"`.
        ///  
        ///Fulfillments for line items with a `quantity_unit` can have non-integer quantities.
        ///For example, `"1.70000"`.
        ///</summary>
        [Description("The quantity of the line item being fulfilled, formatted as a decimal number.\nFor example, `\"3\"`.\n  \nFulfillments for line items with a `quantity_unit` can have non-integer quantities.\nFor example, `\"1.70000\"`.")]
        public decimal? quantity { get; set; }

        ///<summary>
        ///A unique ID that identifies the fulfillment entry only within this order.
        ///</summary>
        [Description("A unique ID that identifies the fulfillment entry only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///The `line_item_application` describes what order line items this fulfillment applies
    ///to.It can be `ALL` or `ENTRY_LIST` with a supplied list of fulfillment entries.
    ///</summary>
    [Description("The `line_item_application` describes what order line items this fulfillment applies\nto.It can be `ALL` or `ENTRY_LIST` with a supplied list of fulfillment entries.")]
    public enum OrderFulfillmentLineItemApplication
    {
        ///<summary>
        ///If `ALL`, `entries` must be unset.
        ///</summary>
        [Description("If `ALL`, `entries` must be unset.")]
        ALL,
        ///<summary>
        ///If `ENTRY_LIST`, supply a list of `entries`.
        ///</summary>
        [Description("If `ENTRY_LIST`, supply a list of `entries`.")]
        ENTRY_LIST,
    }

    public static class OrderFulfillmentLineItemApplicationStringValues
    {
        public const string ALL = @"ALL";
        public const string ENTRY_LIST = @"ENTRY_LIST";
    }

    ///<summary>
    ///Information about the fulfillment recipient.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Information about the fulfillment recipient.\nPermissions: ORDERS_READ")]
    public class OrderFulfillmentRecipient : GraphQLObject<OrderFulfillmentRecipient>
    {
        ///<summary>
        ///The address of the fulfillment recipient. This field is required.
        ///  
        ///If provided, the address overrides the corresponding customer profile value
        ///indicated by `customer_id`.
        ///</summary>
        [Description("The address of the fulfillment recipient. This field is required.\n  \nIf provided, the address overrides the corresponding customer profile value\nindicated by `customer_id`.")]
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
        [Description("The ID of the customer associated with the fulfillment.\n  \nIf `customer_id` is provided, the fulfillment recipient's `display_name`,\n`email_address`, and `phone_number` are automatically populated from the\ntargeted customer profile. If these fields are set in the request, the request\nvalues override the information from the customer profile. If the\ntargeted customer profile does not contain the necessary information and\nthese fields are left unset, the request results in an error.")]
        public Customer? customer { get; set; }

        ///<summary>
        ///The display name of the fulfillment recipient. This field is required.
        ///  
        ///If provided, the display name overrides the corresponding customer profile value
        ///indicated by `customer_id`.
        ///</summary>
        [Description("The display name of the fulfillment recipient. This field is required.\n  \nIf provided, the display name overrides the corresponding customer profile value\nindicated by `customer_id`.")]
        public string? displayName { get; set; }

        ///<summary>
        ///The email address of the fulfillment recipient.
        ///  
        ///If provided, the email address overrides the corresponding customer profile value
        ///indicated by `customer_id`.
        ///</summary>
        [Description("The email address of the fulfillment recipient.\n  \nIf provided, the email address overrides the corresponding customer profile value\nindicated by `customer_id`.")]
        public string? emailAddress { get; set; }

        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///The phone number of the fulfillment recipient. This field is required.
        ///  
        ///If provided, the phone number overrides the corresponding customer profile value
        ///indicated by `customer_id`.
        ///</summary>
        [Description("The phone number of the fulfillment recipient. This field is required.\n  \nIf provided, the phone number overrides the corresponding customer profile value\nindicated by `customer_id`.")]
        public string? phoneNumber { get; set; }
    }

    ///<summary>
    ///The current state of this fulfillment.
    ///</summary>
    [Description("The current state of this fulfillment.")]
    public enum OrderFulfillmentState
    {
        ///<summary>
        ///Indicates that the fulfillment was canceled.
        ///</summary>
        [Description("Indicates that the fulfillment was canceled.")]
        CANCELED,
        ///<summary>
        ///Indicates that the fulfillment was successfully completed.
        ///</summary>
        [Description("Indicates that the fulfillment was successfully completed.")]
        COMPLETED,
        ///<summary>
        ///Indicates that the fulfillment failed to be completed, but was not explicitly
        ///canceled.
        ///</summary>
        [Description("Indicates that the fulfillment failed to be completed, but was not explicitly\ncanceled.")]
        FAILED,
        ///<summary>
        ///Indicates that the fulfillment has been prepared.
        ///</summary>
        [Description("Indicates that the fulfillment has been prepared.")]
        PREPARED,
        ///<summary>
        ///Indicates that the fulfillment has been proposed.
        ///</summary>
        [Description("Indicates that the fulfillment has been proposed.")]
        PROPOSED,
        ///<summary>
        ///Indicates that the fulfillment has been reserved.
        ///</summary>
        [Description("Indicates that the fulfillment has been reserved.")]
        RESERVED,
    }

    public static class OrderFulfillmentStateStringValues
    {
        public const string CANCELED = @"CANCELED";
        public const string COMPLETED = @"COMPLETED";
        public const string FAILED = @"FAILED";
        public const string PREPARED = @"PREPARED";
        public const string PROPOSED = @"PROPOSED";
        public const string RESERVED = @"RESERVED";
    }

    ///<summary>
    ///The type of fulfillment.
    ///</summary>
    [Description("The type of fulfillment.")]
    public enum OrderFulfillmentType
    {
        ///<summary>
        ///A courier to deliver the fulfillment.
        ///</summary>
        [Description("A courier to deliver the fulfillment.")]
        DELIVERY,
        ///<summary>
        ///A recipient to pick up the fulfillment from a physical [location](entity:Location).
        ///</summary>
        [Description("A recipient to pick up the fulfillment from a physical [location](entity:Location).")]
        PICKUP,
        ///<summary>
        ///A shipping carrier to ship the fulfillment.
        ///</summary>
        [Description("A shipping carrier to ship the fulfillment.")]
        SHIPMENT,
    }

    public static class OrderFulfillmentTypeStringValues
    {
        public const string DELIVERY = @"DELIVERY";
        public const string PICKUP = @"PICKUP";
        public const string SHIPMENT = @"SHIPMENT";
    }

    ///<summary>
    ///Represents a line item in an order.Each line item describes a different
    ///product to purchase, with its own quantity and price details.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents a line item in an order.Each line item describes a different\nproduct to purchase, with its own quantity and price details.\nPermissions: ORDERS_READ")]
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
        [Description("The list of references to discounts applied to this line item. Each\n`OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level\n`OrderLineItemDiscounts` applied to the line item. On reads, the amount\napplied is populated.\n  \nAn `OrderLineItemAppliedDiscount` is automatically created on every line item for all\n`ORDER` scoped discounts that are added to the order. `OrderLineItemAppliedDiscount` records\nfor `LINE_ITEM` scoped discounts must be added in requests for the discount to apply to any\nline items.\n  \nTo change the amount of a discount, modify the referenced top-level discount.")]
        public IEnumerable<OrderLineItemAppliedDiscount>? appliedDiscounts { get; set; }

        ///<summary>
        ///The list of references to service charges applied to this line item. Each
        ///`OrderLineItemAppliedServiceCharge` has a `service_charge_id` that references the `uid` of a
        ///top-level `OrderServiceCharge` applied to the line item. On reads, the amount applied is
        ///populated.
        ///  
        ///To change the amount of a service charge, modify the referenced top-level service charge.
        ///</summary>
        [Description("The list of references to service charges applied to this line item. Each\n`OrderLineItemAppliedServiceCharge` has a `service_charge_id` that references the `uid` of a\ntop-level `OrderServiceCharge` applied to the line item. On reads, the amount applied is\npopulated.\n  \nTo change the amount of a service charge, modify the referenced top-level service charge.")]
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
        [Description("The list of references to taxes applied to this line item. Each\n`OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a\ntop-level `OrderLineItemTax` applied to the line item. On reads, the\namount applied is populated.\n  \nAn `OrderLineItemAppliedTax` is automatically created on every line\nitem for all `ORDER` scoped taxes added to the order. `OrderLineItemAppliedTax`\nrecords for `LINE_ITEM` scoped taxes must be added in requests for the tax\nto apply to any line items.\n  \nTo change the amount of a tax, modify the referenced top-level tax.")]
        public IEnumerable<OrderLineItemAppliedTax>? appliedTaxes { get; set; }

        ///<summary>
        ///The base price for a single unit of the line item.
        ///</summary>
        [Description("The base price for a single unit of the line item.")]
        public Money? basePrice { get; set; }

        ///<summary>
        ///The amount of money made in gross sales for this line item.
        ///The amount is calculated as the sum of the variation's total price and each modifier's total price.
        ///</summary>
        [Description("The amount of money made in gross sales for this line item.\nThe amount is calculated as the sum of the variation's total price and each modifier's total price.")]
        public Money? grossSales { get; set; }

        ///<summary>
        ///The type of line item: an itemized sale, a non-itemized sale (custom amount), or the
        ///activation or reloading of a gift card.
        ///</summary>
        [Description("The type of line item: an itemized sale, a non-itemized sale (custom amount), or the\nactivation or reloading of a gift card.")]
        public OrderLineItemItemType? itemType { get; set; }

        ///<summary>
        ///The CatalogItemVariation ID applied to this line item.
        ///</summary>
        [Description("The CatalogItemVariation ID applied to this line item.")]
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
        [Description("Application-defined data attached to this line item. Metadata fields are intended\nto store descriptive references or associations with an entity in another system or store brief\ninformation about the object. Square does not process this field; it only stores and returns it\nin relevant API calls. Do not use metadata to store any sensitive information (such as personally\nidentifiable information or card details).\n  \nKeys written by applications must be 60 characters or less and must be in the character set\n`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed\nwith a namespace, separated from the key with a ':' character.\n  \nValues have a maximum length of 255 characters.\n  \nAn application can have up to 10 entries per metadata field.\n  \nEntries written by applications are private and can only be read or modified by the same\napplication.\n  \nFor more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).")]
        public Metadata? metadata { get; set; }

        ///<summary>
        ///The CatalogModifiers applied to this line item.
        ///</summary>
        [Description("The CatalogModifiers applied to this line item.")]
        public IEnumerable<OrderLineItemModifier>? modifiers { get; set; }

        ///<summary>
        ///The name of the line item.
        ///</summary>
        [Description("The name of the line item.")]
        public string? name { get; set; }

        ///<summary>
        ///The note of the line item.
        ///</summary>
        [Description("The note of the line item.")]
        public string? note { get; set; }

        ///<summary>
        ///Describes pricing adjustments that are blocked from automatic
        ///application to a line item. For more information, see
        ///[Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).
        ///</summary>
        [Description("Describes pricing adjustments that are blocked from automatic\napplication to a line item. For more information, see\n[Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).")]
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
        [Description("The quantity purchased, formatted as a decimal number.\nFor example, `\"3\"`.\n  \nLine items with a quantity of `\"0\"` are automatically removed\nwhen paying for or otherwise completing the order.\n  \nLine items with a `quantity_unit` can have non-integer quantities.\nFor example, `\"1.70000\"`.")]
        public decimal? quantity { get; set; }

        ///<summary>
        ///The unit and precision that this line item's quantity is measured in.
        ///</summary>
        [Description("The unit and precision that this line item's quantity is measured in.")]
        public OrderQuantityUnit? quantityUnit { get; set; }

        ///<summary>
        ///The total amount of discount money to collect for the line item.
        ///</summary>
        [Description("The total amount of discount money to collect for the line item.")]
        public Money? totalDiscount { get; set; }

        ///<summary>
        ///The total amount of money to collect for this line item.
        ///</summary>
        [Description("The total amount of money to collect for this line item.")]
        public Money? totalMoney { get; set; }

        ///<summary>
        ///The total amount of apportioned service charge money to collect for the line item.
        ///</summary>
        [Description("The total amount of apportioned service charge money to collect for the line item.")]
        public Money? totalServiceCharge { get; set; }

        ///<summary>
        ///The total amount of tax money to collect for the line item.
        ///</summary>
        [Description("The total amount of tax money to collect for the line item.")]
        public Money? totalTax { get; set; }

        ///<summary>
        ///A unique ID that identifies the line item only within this order.
        ///</summary>
        [Description("A unique ID that identifies the line item only within this order.")]
        public string? uid { get; set; }

        ///<summary>
        ///The total price of all item variations sold in this line item.
        ///The price is calculated as `base_price_money` multiplied by `quantity`.
        ///It does not include modifiers.
        ///</summary>
        [Description("The total price of all item variations sold in this line item.\nThe price is calculated as `base_price_money` multiplied by `quantity`.\nIt does not include modifiers.")]
        public Money? variationTotalPrice { get; set; }
    }

    ///<summary>
    ///Represents an applied portion of a discount to a line item in an order.Order scoped discounts have automatically applied discounts present for each line item.
    ///Line-item scoped discounts must have applied discounts added manually for any applicable line
    ///items. The corresponding applied money is automatically computed based on participating
    ///line items.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents an applied portion of a discount to a line item in an order.Order scoped discounts have automatically applied discounts present for each line item.\nLine-item scoped discounts must have applied discounts added manually for any applicable line\nitems. The corresponding applied money is automatically computed based on participating\nline items.\nPermissions: ORDERS_READ")]
    public class OrderLineItemAppliedDiscount : GraphQLObject<OrderLineItemAppliedDiscount>
    {
        ///<summary>
        ///The amount of money applied by the discount to the line item.
        ///</summary>
        [Description("The amount of money applied by the discount to the line item.")]
        public Money? appliedMoney { get; set; }

        ///<summary>
        ///The `uid` of the discount that the applied discount represents. It must
        ///reference a discount present in the `order.discounts` field.
        ///  
        ///This field is immutable. To change which discounts apply to a line item,
        ///you must delete the discount and re-add it as a new `OrderLineItemAppliedDiscount`.
        ///</summary>
        [Description("The `uid` of the discount that the applied discount represents. It must\nreference a discount present in the `order.discounts` field.\n  \nThis field is immutable. To change which discounts apply to a line item,\nyou must delete the discount and re-add it as a new `OrderLineItemAppliedDiscount`.")]
        public string? discountUid { get; set; }

        ///<summary>
        ///A unique ID that identifies the applied discount only within this order.
        ///</summary>
        [Description("A unique ID that identifies the applied discount only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Permissions: ORDERS_READ")]
    public class OrderLineItemAppliedServiceCharge : GraphQLObject<OrderLineItemAppliedServiceCharge>
    {
        ///<summary>
        ///The amount of money applied by the service charge to the line item.
        ///</summary>
        [Description("The amount of money applied by the service charge to the line item.")]
        public Money? appliedMoney { get; set; }

        ///<summary>
        ///The `uid` of the service charge that the applied service charge represents. It must
        ///reference a service charge present in the `order.service_charges` field.
        ///  
        ///This field is immutable. To change which service charges apply to a line item,
        ///delete and add a new `OrderLineItemAppliedServiceCharge`.
        ///</summary>
        [Description("The `uid` of the service charge that the applied service charge represents. It must\nreference a service charge present in the `order.service_charges` field.\n  \nThis field is immutable. To change which service charges apply to a line item,\ndelete and add a new `OrderLineItemAppliedServiceCharge`.")]
        public string? serviceChargeUid { get; set; }

        ///<summary>
        ///A unique ID that identifies the applied service charge only within this order.
        ///</summary>
        [Description("A unique ID that identifies the applied service charge only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents an applied portion of a tax to a line item in an order.Order-scoped taxes automatically include the applied taxes in each line item.
    ///Line item taxes must be referenced from any applicable line items.
    ///The corresponding applied money is automatically computed, based on the
    ///set of participating line items.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents an applied portion of a tax to a line item in an order.Order-scoped taxes automatically include the applied taxes in each line item.\nLine item taxes must be referenced from any applicable line items.\nThe corresponding applied money is automatically computed, based on the\nset of participating line items.\nPermissions: ORDERS_READ")]
    public class OrderLineItemAppliedTax : GraphQLObject<OrderLineItemAppliedTax>
    {
        ///<summary>
        ///The amount of money applied by the tax to the line item.
        ///</summary>
        [Description("The amount of money applied by the tax to the line item.")]
        public Money? appliedMoney { get; set; }

        ///<summary>
        ///The `uid` of the tax for which this applied tax represents. It must reference
        ///a tax present in the `order.taxes` field.
        ///  
        ///This field is immutable. To change which taxes apply to a line item, delete and add a new
        ///`OrderLineItemAppliedTax`.
        ///</summary>
        [Description("The `uid` of the tax for which this applied tax represents. It must reference\na tax present in the `order.taxes` field.\n  \nThis field is immutable. To change which taxes apply to a line item, delete and add a new\n`OrderLineItemAppliedTax`.")]
        public string? taxUid { get; set; }

        ///<summary>
        ///A unique ID that identifies the applied tax only within this order.
        ///</summary>
        [Description("A unique ID that identifies the applied tax only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a discount that applies to one or more line items in an
    ///order.Fixed-amount, order-scoped discounts are distributed across all non-zero line item totals.
    ///The amount distributed to each line item is relative to the
    ///amount contributed by the item to the order subtotal.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents a discount that applies to one or more line items in an\norder.Fixed-amount, order-scoped discounts are distributed across all non-zero line item totals.\nThe amount distributed to each line item is relative to the\namount contributed by the item to the order subtotal.\nPermissions: ORDERS_READ")]
    public class OrderLineItemDiscount : GraphQLObject<OrderLineItemDiscount>
    {
        ///<summary>
        ///The total declared monetary amount of the discount.
        ///  
        ///`amount_money` is not set for percentage-based discounts.
        ///</summary>
        [Description("The total declared monetary amount of the discount.\n  \n`amount_money` is not set for percentage-based discounts.")]
        public Money? amount { get; set; }

        ///<summary>
        ///The amount of discount actually applied to the line item.
        ///  
        ///The amount represents the amount of money applied as a line-item scoped discount.
        ///When an amount-based discount is scoped to the entire order, the value
        ///of `applied_money` is different than `amount_money` because the total
        ///amount of the discount is distributed across all line items.
        ///</summary>
        [Description("The amount of discount actually applied to the line item.\n  \nThe amount represents the amount of money applied as a line-item scoped discount.\nWhen an amount-based discount is scoped to the entire order, the value\nof `applied_money` is different than `amount_money` because the total\namount of the discount is distributed across all line items.")]
        public Money? appliedMoney { get; set; }

        ///<summary>
        ///The catalog object ID referencing CatalogDiscount.
        ///</summary>
        [Description("The catalog object ID referencing CatalogDiscount.")]
        public CatalogDiscount? discount { get; set; }

        ///<summary>
        ///The discount code IDs corresponding to this discount.
        ///</summary>
        [Description("The discount code IDs corresponding to this discount.")]
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
        [Description("Application-defined data attached to this discount. Metadata fields are intended\nto store descriptive references or associations with an entity in another system or store brief\ninformation about the object. Square does not process this field; it only stores and returns it\nin relevant API calls. Do not use metadata to store any sensitive information (such as personally\nidentifiable information or card details).\n  \nKeys written by applications must be 60 characters or less and must be in the character set\n`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed\nwith a namespace, separated from the key with a ':' character.\n  \nValues have a maximum length of 255 characters.\n  \nAn application can have up to 10 entries per metadata field.\n  \nEntries written by applications are private and can only be read or modified by the same\napplication.\n  \nFor more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).")]
        public Metadata? metadata { get; set; }

        ///<summary>
        ///The discount's name.
        ///</summary>
        [Description("The discount's name.")]
        public string? name { get; set; }

        ///<summary>
        ///The percentage of the discount, as a string representation of a decimal number.
        ///A value of `7.25` corresponds to a percentage of 7.25%.
        ///  
        ///`percentage` is not set for amount-based discounts.
        ///</summary>
        [Description("The percentage of the discount, as a string representation of a decimal number.\nA value of `7.25` corresponds to a percentage of 7.25%.\n  \n`percentage` is not set for amount-based discounts.")]
        public decimal? percentage { get; set; }

        ///<summary>
        ///The object ID of a pricing rule to be applied
        ///automatically to this discount. The specification and application of the discounts, to
        ///which a `pricing_rule_id` is assigned, are completely controlled by the corresponding
        ///pricing rule.
        ///</summary>
        [Description("The object ID of a pricing rule to be applied\nautomatically to this discount. The specification and application of the discounts, to\nwhich a `pricing_rule_id` is assigned, are completely controlled by the corresponding\npricing rule.")]
        public CatalogPricingRule? pricingRule { get; set; }

        ///<summary>
        ///The reward IDs corresponding to this discount. The application and
        ///specification of discounts that have `reward_ids` are completely controlled by the backing
        ///criteria corresponding to the reward tiers of the rewards that are added to the order
        ///through the Loyalty API. To manually unapply discounts that are the result of added rewards,
        ///the rewards must be removed from the order through the Loyalty API.
        ///</summary>
        [Description("The reward IDs corresponding to this discount. The application and\nspecification of discounts that have `reward_ids` are completely controlled by the backing\ncriteria corresponding to the reward tiers of the rewards that are added to the order\nthrough the Loyalty API. To manually unapply discounts that are the result of added rewards,\nthe rewards must be removed from the order through the Loyalty API.")]
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
        [Description("Indicates the level at which the discount applies. For `ORDER` scoped discounts,\nSquare generates references in `applied_discounts` on all order line items that do\nnot have them. For `LINE_ITEM` scoped discounts, the discount only applies to line items\nwith a discount reference in their `applied_discounts` field.\n  \nThis field is immutable. To change the scope of a discount, you must delete\nthe discount and re-add it as a new discount.")]
        public OrderLineItemDiscountScope? scope { get; set; }

        ///<summary>
        ///The type of the discount.
        ///  
        ///Discounts that do not reference a catalog object ID must have a type of
        ///`FIXED_PERCENTAGE` or `FIXED_AMOUNT`.
        ///</summary>
        [Description("The type of the discount.\n  \nDiscounts that do not reference a catalog object ID must have a type of\n`FIXED_PERCENTAGE` or `FIXED_AMOUNT`.")]
        public OrderLineItemDiscountType? type { get; set; }

        ///<summary>
        ///A unique ID that identifies the discount only within this order.
        ///</summary>
        [Description("A unique ID that identifies the discount only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Indicates whether this is a line-item or order-level discount.
    ///</summary>
    [Description("Indicates whether this is a line-item or order-level discount.")]
    public enum OrderLineItemDiscountScope
    {
        ///<summary>
        ///The discount should be applied to only line items specified by
        ///`OrderLineItemAppliedDiscount` reference records.
        ///</summary>
        [Description("The discount should be applied to only line items specified by\n`OrderLineItemAppliedDiscount` reference records.")]
        LINE_ITEM,
        ///<summary>
        ///The discount should be applied to the entire order.
        ///</summary>
        [Description("The discount should be applied to the entire order.")]
        ORDER,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction discount scope is currently not supported by the API.
        ///</summary>
        [Description("Used for reporting only.\nThe original transaction discount scope is currently not supported by the API.")]
        OTHER_DISCOUNT_SCOPE,
    }

    public static class OrderLineItemDiscountScopeStringValues
    {
        public const string LINE_ITEM = @"LINE_ITEM";
        public const string ORDER = @"ORDER";
        public const string OTHER_DISCOUNT_SCOPE = @"OTHER_DISCOUNT_SCOPE";
    }

    ///<summary>
    ///Indicates how the discount is applied to the associated line item or order.
    ///</summary>
    [Description("Indicates how the discount is applied to the associated line item or order.")]
    public enum OrderLineItemDiscountType
    {
        ///<summary>
        ///Apply the discount as a fixed monetary value (such as $1.00) off the item price.
        ///</summary>
        [Description("Apply the discount as a fixed monetary value (such as $1.00) off the item price.")]
        FIXED_AMOUNT,
        ///<summary>
        ///Apply the discount as a fixed percentage (such as 5%) off the item price.
        ///</summary>
        [Description("Apply the discount as a fixed percentage (such as 5%) off the item price.")]
        FIXED_PERCENTAGE,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction discount type is currently not supported by the API.
        ///</summary>
        [Description("Used for reporting only.\nThe original transaction discount type is currently not supported by the API.")]
        UNKNOWN_DISCOUNT,
        ///<summary>
        ///Apply the discount as a variable amount based on the item price.
        ///  
        ///The specific discount amount of a `VARIABLE_AMOUNT` discount
        ///is assigned at the time of the purchase.
        ///</summary>
        [Description("Apply the discount as a variable amount based on the item price.\n  \nThe specific discount amount of a `VARIABLE_AMOUNT` discount\nis assigned at the time of the purchase.")]
        VARIABLE_AMOUNT,
        ///<summary>
        ///Apply the discount as a variable percentage based on the item
        ///price.
        ///  
        ///The specific discount percentage of a `VARIABLE_PERCENTAGE` discount
        ///is assigned at the time of the purchase.
        ///</summary>
        [Description("Apply the discount as a variable percentage based on the item\nprice.\n  \nThe specific discount percentage of a `VARIABLE_PERCENTAGE` discount\nis assigned at the time of the purchase.")]
        VARIABLE_PERCENTAGE,
    }

    public static class OrderLineItemDiscountTypeStringValues
    {
        public const string FIXED_AMOUNT = @"FIXED_AMOUNT";
        public const string FIXED_PERCENTAGE = @"FIXED_PERCENTAGE";
        public const string UNKNOWN_DISCOUNT = @"UNKNOWN_DISCOUNT";
        public const string VARIABLE_AMOUNT = @"VARIABLE_AMOUNT";
        public const string VARIABLE_PERCENTAGE = @"VARIABLE_PERCENTAGE";
    }

    ///<summary>
    ///Represents the line item type.
    ///</summary>
    [Description("Represents the line item type.")]
    public enum OrderLineItemItemType
    {
        ///<summary>
        ///Indicates that the line item is a non-itemized sale.
        ///</summary>
        [Description("Indicates that the line item is a non-itemized sale.")]
        CUSTOM_AMOUNT,
        ///<summary>
        ///Indicates that the line item is a gift card sale. Gift cards sold through
        ///the Orders API are sold in an unactivated state and can be activated through the
        ///Gift Cards API using the line item `uid`.
        ///</summary>
        [Description("Indicates that the line item is a gift card sale. Gift cards sold through\nthe Orders API are sold in an unactivated state and can be activated through the\nGift Cards API using the line item `uid`.")]
        GIFT_CARD,
        ///<summary>
        ///Indicates that the line item is an itemized sale.
        ///</summary>
        [Description("Indicates that the line item is an itemized sale.")]
        ITEM,
    }

    public static class OrderLineItemItemTypeStringValues
    {
        public const string CUSTOM_AMOUNT = @"CUSTOM_AMOUNT";
        public const string GIFT_CARD = @"GIFT_CARD";
        public const string ITEM = @"ITEM";
    }

    ///<summary>
    ///A CatalogModifier.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("A CatalogModifier.\nPermissions: ORDERS_READ")]
    public class OrderLineItemModifier : GraphQLObject<OrderLineItemModifier>
    {
        ///<summary>
        ///The base price for the modifier.
        ///  
        ///`base_price_money` is required for ad hoc modifiers.
        ///If both `catalog_object_id` and `base_price_money` are set, `base_price_money` will
        ///override the predefined CatalogModifier price.
        ///</summary>
        [Description("The base price for the modifier.\n  \n`base_price_money` is required for ad hoc modifiers.\nIf both `catalog_object_id` and `base_price_money` are set, `base_price_money` will\noverride the predefined CatalogModifier price.")]
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
        [Description("Application-defined data attached to this order. Metadata fields are intended\nto store descriptive references or associations with an entity in another system or store brief\ninformation about the object. Square does not process this field; it only stores and returns it\nin relevant API calls. Do not use metadata to store any sensitive information (such as personally\nidentifiable information or card details).\n  \nKeys written by applications must be 60 characters or less and must be in the character set\n`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed\nwith a namespace, separated from the key with a ':' character.\n  \nValues have a maximum length of 255 characters.\n  \nAn application can have up to 10 entries per metadata field.\n  \nEntries written by applications are private and can only be read or modified by the same\napplication.\n  \nFor more information, see  [Metadata](https://developer.squareup.com/docs/build-basics/metadata).")]
        public Metadata? metadata { get; set; }

        ///<summary>
        ///The catalog object ID referencing CatalogModifier.
        ///</summary>
        [Description("The catalog object ID referencing CatalogModifier.")]
        public CatalogModifier? modifier { get; set; }

        ///<summary>
        ///The name of the item modifier.
        ///</summary>
        [Description("The name of the item modifier.")]
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
        [Description("The quantity of the line item modifier. The modifier quantity can be 0 or more.\nFor example, suppose a restaurant offers a cheeseburger on the menu. When a buyer orders\nthis item, the restaurant records the purchase by creating an `Order` object with a line item\nfor a burger. The line item includes a line item modifier: the name is cheese and the quantity\nis 1. The buyer has the option to order extra cheese (or no cheese). If the buyer chooses\nthe extra cheese option, the modifier quantity increases to 2. If the buyer does not want\nany cheese, the modifier quantity is set to 0.")]
        public decimal? quantity { get; set; }

        ///<summary>
        ///The total price of the item modifier for its line item.
        ///This is the modifier's `base_price_money` multiplied by the line item's quantity.
        ///</summary>
        [Description("The total price of the item modifier for its line item.\nThis is the modifier's `base_price_money` multiplied by the line item's quantity.")]
        public Money? totalPrice { get; set; }

        ///<summary>
        ///A unique ID that identifies the modifier only within this order.
        ///</summary>
        [Description("A unique ID that identifies the modifier only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Describes pricing adjustments that are blocked from automatic
    ///application to a line item.For more information, see
    ///[Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Describes pricing adjustments that are blocked from automatic\napplication to a line item.For more information, see\n[Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).\nPermissions: ORDERS_READ")]
    public class OrderLineItemPricingBlocklists : GraphQLObject<OrderLineItemPricingBlocklists>
    {
        ///<summary>
        ///A list of discounts blocked from applying to the line item.
        ///Discounts can be blocked by the `discount_uid` (for ad hoc discounts) or
        ///the `discount_catalog_object_id` (for catalog discounts).
        ///</summary>
        [Description("A list of discounts blocked from applying to the line item.\nDiscounts can be blocked by the `discount_uid` (for ad hoc discounts) or\nthe `discount_catalog_object_id` (for catalog discounts).")]
        public IEnumerable<OrderLineItemPricingBlocklistsBlockedDiscount>? blockedDiscounts { get; set; }

        ///<summary>
        ///A list of taxes blocked from applying to the line item.
        ///Taxes can be blocked by the `tax_uid` (for ad hoc taxes) or
        ///the `tax_catalog_object_id` (for catalog taxes).
        ///</summary>
        [Description("A list of taxes blocked from applying to the line item.\nTaxes can be blocked by the `tax_uid` (for ad hoc taxes) or\nthe `tax_catalog_object_id` (for catalog taxes).")]
        public IEnumerable<OrderLineItemPricingBlocklistsBlockedTax>? blockedTaxes { get; set; }
    }

    ///<summary>
    ///A discount to block from applying to a line item.The discount must be
    ///identified by either `discount_uid` or `discount_catalog_object_id`, but not both.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("A discount to block from applying to a line item.The discount must be\nidentified by either `discount_uid` or `discount_catalog_object_id`, but not both.\nPermissions: ORDERS_READ")]
    public class OrderLineItemPricingBlocklistsBlockedDiscount : GraphQLObject<OrderLineItemPricingBlocklistsBlockedDiscount>
    {
        ///<summary>
        ///The `catalog_object_id` of the discount that should be blocked.
        ///Use this field to block catalog discounts. For ad hoc discounts, use the
        ///`discount_uid` field.
        ///</summary>
        [Description("The `catalog_object_id` of the discount that should be blocked.\nUse this field to block catalog discounts. For ad hoc discounts, use the\n`discount_uid` field.")]
        public string? discountCatalogObjectId { get; set; }

        ///<summary>
        ///The `uid` of the discount that should be blocked. Use this field to block
        ///ad hoc discounts. For catalog discounts, use the `discount_catalog_object_id` field.
        ///</summary>
        [Description("The `uid` of the discount that should be blocked. Use this field to block\nad hoc discounts. For catalog discounts, use the `discount_catalog_object_id` field.")]
        public string? discountUid { get; set; }

        ///<summary>
        ///A unique ID of the `BlockedDiscount` within the order.
        ///</summary>
        [Description("A unique ID of the `BlockedDiscount` within the order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///A tax to block from applying to a line item.The tax must be
    ///identified by either `tax_uid` or `tax_catalog_object_id`, but not both.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("A tax to block from applying to a line item.The tax must be\nidentified by either `tax_uid` or `tax_catalog_object_id`, but not both.\nPermissions: ORDERS_READ")]
    public class OrderLineItemPricingBlocklistsBlockedTax : GraphQLObject<OrderLineItemPricingBlocklistsBlockedTax>
    {
        ///<summary>
        ///The `catalog_object_id` of the tax that should be blocked.
        ///Use this field to block catalog taxes. For ad hoc taxes, use the
        ///`tax_uid` field.
        ///</summary>
        [Description("The `catalog_object_id` of the tax that should be blocked.\nUse this field to block catalog taxes. For ad hoc taxes, use the\n`tax_uid` field.")]
        public string? taxCatalogObjectId { get; set; }

        ///<summary>
        ///The `uid` of the tax that should be blocked. Use this field to block
        ///ad hoc taxes. For catalog, taxes use the `tax_catalog_object_id` field.
        ///</summary>
        [Description("The `uid` of the tax that should be blocked. Use this field to block\nad hoc taxes. For catalog, taxes use the `tax_catalog_object_id` field.")]
        public string? taxUid { get; set; }

        ///<summary>
        ///A unique ID of the `BlockedTax` within the order.
        ///</summary>
        [Description("A unique ID of the `BlockedTax` within the order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a tax that applies to one or more line item in the order.Fixed-amount, order-scoped taxes are distributed across all non-zero line item totals.
    ///The amount distributed to each line item is relative to the amount the item
    ///contributes to the order subtotal.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents a tax that applies to one or more line item in the order.Fixed-amount, order-scoped taxes are distributed across all non-zero line item totals.\nThe amount distributed to each line item is relative to the amount the item\ncontributes to the order subtotal.\nPermissions: ORDERS_READ")]
    public class OrderLineItemTax : GraphQLObject<OrderLineItemTax>
    {
        ///<summary>
        ///The amount of money applied by the tax in the order.
        ///</summary>
        [Description("The amount of money applied by the tax in the order.")]
        public Money? appliedMoney { get; set; }

        ///<summary>
        ///Determines whether the tax was automatically applied to the order based on
        ///the catalog configuration. For an example, see
        ///[Automatically Apply Taxes to an Order](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts/auto-apply-taxes).
        ///</summary>
        [Description("Determines whether the tax was automatically applied to the order based on\nthe catalog configuration. For an example, see\n[Automatically Apply Taxes to an Order](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts/auto-apply-taxes).")]
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
        [Description("Application-defined data attached to this tax. Metadata fields are intended\nto store descriptive references or associations with an entity in another system or store brief\ninformation about the object. Square does not process this field; it only stores and returns it\nin relevant API calls. Do not use metadata to store any sensitive information (such as personally\nidentifiable information or card details).\n  \nKeys written by applications must be 60 characters or less and must be in the character set\n`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed\nwith a namespace, separated from the key with a ':' character.\n  \nValues have a maximum length of 255 characters.\n  \nAn application can have up to 10 entries per metadata field.\n  \nEntries written by applications are private and can only be read or modified by the same\napplication.\n  \nFor more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).")]
        public Metadata? metadata { get; set; }

        ///<summary>
        ///The tax's name.
        ///</summary>
        [Description("The tax's name.")]
        public string? name { get; set; }

        ///<summary>
        ///The percentage of the tax, as a string representation of a decimal
        ///number. For example, a value of `"7.25"` corresponds to a percentage of
        ///7.25%.
        ///</summary>
        [Description("The percentage of the tax, as a string representation of a decimal\nnumber. For example, a value of `\"7.25\"` corresponds to a percentage of\n7.25%.")]
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
        [Description("Indicates the level at which the tax applies. For `ORDER` scoped taxes,\nSquare generates references in `applied_taxes` on all order line items that do\nnot have them. For `LINE_ITEM` scoped taxes, the tax only applies to line items\nwith references in their `applied_taxes` field.\n  \nThis field is immutable. To change the scope, you must delete the tax and\nre-add it as a new tax.")]
        public OrderLineItemTaxScope? scope { get; set; }

        ///<summary>
        ///The catalog object ID referencing CatalogTax.
        ///</summary>
        [Description("The catalog object ID referencing CatalogTax.")]
        public CatalogTax? tax { get; set; }

        ///<summary>
        ///Indicates the calculation method used to apply the tax.
        ///</summary>
        [Description("Indicates the calculation method used to apply the tax.")]
        public OrderLineItemTaxType? type { get; set; }

        ///<summary>
        ///A unique ID that identifies the tax only within this order.
        ///</summary>
        [Description("A unique ID that identifies the tax only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Indicates whether this is a line-item or order-level tax.
    ///</summary>
    [Description("Indicates whether this is a line-item or order-level tax.")]
    public enum OrderLineItemTaxScope
    {
        ///<summary>
        ///The tax should be applied only to line items specified by
        ///the `OrderLineItemAppliedTax` reference records.
        ///</summary>
        [Description("The tax should be applied only to line items specified by\nthe `OrderLineItemAppliedTax` reference records.")]
        LINE_ITEM,
        ///<summary>
        ///The tax should be applied to the entire order.
        ///</summary>
        [Description("The tax should be applied to the entire order.")]
        ORDER,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction tax scope is currently not supported by the API.
        ///</summary>
        [Description("Used for reporting only.\nThe original transaction tax scope is currently not supported by the API.")]
        OTHER_TAX_SCOPE,
    }

    public static class OrderLineItemTaxScopeStringValues
    {
        public const string LINE_ITEM = @"LINE_ITEM";
        public const string ORDER = @"ORDER";
        public const string OTHER_TAX_SCOPE = @"OTHER_TAX_SCOPE";
    }

    ///<summary>
    ///Indicates how the tax is applied to the associated line item or order.
    ///</summary>
    [Description("Indicates how the tax is applied to the associated line item or order.")]
    public enum OrderLineItemTaxType
    {
        ///<summary>
        ///The tax is an additive tax. The tax amount is added on top of the price.
        ///For example, an item with a cost of 1.00 USD and a 10% additive tax has a total
        ///cost to the buyer of 1.10 USD.
        ///</summary>
        [Description("The tax is an additive tax. The tax amount is added on top of the price.\nFor example, an item with a cost of 1.00 USD and a 10% additive tax has a total\ncost to the buyer of 1.10 USD.")]
        ADDITIVE,
        ///<summary>
        ///The tax is an inclusive tax. Inclusive taxes are already included
        ///in the line item price or order total. For example, an item with a cost of
        ///1.00 USD and a 10% inclusive tax has a pretax cost of 0.91 USD
        ///(91 cents) and a 0.09 (9 cents) tax for a total cost of 1.00 USD to
        ///the buyer.
        ///</summary>
        [Description("The tax is an inclusive tax. Inclusive taxes are already included\nin the line item price or order total. For example, an item with a cost of\n1.00 USD and a 10% inclusive tax has a pretax cost of 0.91 USD\n(91 cents) and a 0.09 (9 cents) tax for a total cost of 1.00 USD to\nthe buyer.")]
        INCLUSIVE,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction tax type is currently not supported by the API.
        ///</summary>
        [Description("Used for reporting only.\nThe original transaction tax type is currently not supported by the API.")]
        UNKNOWN_TAX,
    }

    public static class OrderLineItemTaxTypeStringValues
    {
        public const string ADDITIVE = @"ADDITIVE";
        public const string INCLUSIVE = @"INCLUSIVE";
        public const string UNKNOWN_TAX = @"UNKNOWN_TAX";
    }

    ///<summary>
    ///A collection of various money amounts.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("A collection of various money amounts.\nPermissions: ORDERS_READ")]
    public class OrderMoneyAmounts : GraphQLObject<OrderMoneyAmounts>
    {
        ///<summary>
        ///The money associated with discounts.
        ///</summary>
        [Description("The money associated with discounts.")]
        public Money? discount { get; set; }

        ///<summary>
        ///The money associated with service charges.
        ///</summary>
        [Description("The money associated with service charges.")]
        public Money? serviceCharge { get; set; }

        ///<summary>
        ///The money associated with taxes.
        ///</summary>
        [Description("The money associated with taxes.")]
        public Money? tax { get; set; }

        ///<summary>
        ///The money associated with tips.
        ///</summary>
        [Description("The money associated with tips.")]
        public Money? tip { get; set; }

        ///<summary>
        ///The total money.
        ///</summary>
        [Description("The total money.")]
        public Money? totalMoney { get; set; }
    }

    ///<summary>
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Permissions: ORDERS_READ")]
    public class OrderOtherTender : GraphQLObject<OrderOtherTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        [Description("The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,\nthe `total_money` of the corresponding Payment will be equal to the\n`amount_money` of the tender.")]
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
        [Description("The timestamp for when the tender was created, in RFC 3339 format.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        [Description("If the tender is associated with a customer or represents a customer's card on file,\nthis is the ID of the associated customer.")]
        public Customer? customer { get; set; }

        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        [Description("The tender's unique ID. It is the associated payment ID.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        [Description("The ID of the transaction's associated location.")]
        public Location? location { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        [Description("An optional note associated with the tender at the time of payment.")]
        public string? note { get; set; }

        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        [Description("The ID of the Payment that corresponds to this tender.\nThis value is only present for payments created with the v2 Payments API.")]
        public Payment? payment { get; set; }

        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        [Description("The amount of any Square processing fees applied to the tender.\n  \nThis field is not immediately populated when a new transaction is created.\nIt is usually available after about ten seconds.")]
        public Money? processingFee { get; set; }

        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        [Description("The tip's amount of the tender.")]
        public Money? tip { get; set; }

        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        [Description("The ID of the tender's associated transaction.")]
        public string? transactionId { get; set; }

        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        [Description("The type of tender, such as `CARD` or `CASH`.")]
        public OrderTenderType? type { get; set; }
    }

    ///<summary>
    ///Contains details necessary to fulfill a pickup order.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Contains details necessary to fulfill a pickup order.\nPermissions: ORDERS_READ")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment was accepted. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The duration of time after which an open and accepted pickup fulfillment\nis automatically moved to the `COMPLETED` state. The duration must be in RFC 3339\nformat (for example, \"P1W3D\").\n  \nIf not set, this pickup fulfillment remains accepted until it is canceled or completed.\n  \nExample for 2 days, 12 hours, 30 minutes, and 15 seconds: P2DT12H30M15S")]
        public string? autoCompleteDuration { get; set; }

        ///<summary>
        ///A description of why the pickup was canceled. The maximum length: 100 characters.
        ///</summary>
        [Description("A description of why the pickup was canceled. The maximum length: 100 characters.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment was canceled. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? canceledAt { get; set; }

        ///<summary>
        ///Specific details for curbside pickup. These details can only be populated if `is_curbside_pickup` is set to `true`.
        ///</summary>
        [Description("Specific details for curbside pickup. These details can only be populated if `is_curbside_pickup` is set to `true`.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment expired. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when this fulfillment expires if it is not accepted. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\"). The expiration time can only be set up to 7 days in the future.\nIf `expires_at` is not set, this pickup fulfillment is automatically accepted when\nplaced.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? expiresAt { get; set; }

        ///<summary>
        ///If set to `true`, indicates that this pickup order is for curbside pickup, not in-store pickup.
        ///</summary>
        [Description("If set to `true`, indicates that this pickup order is for curbside pickup, not in-store pickup.")]
        public bool? isCurbsidePickup { get; set; }

        ///<summary>
        ///A note to provide additional instructions about the pickup
        ///fulfillment displayed in the Square Point of Sale application and set by the API.
        ///</summary>
        [Description("A note to provide additional instructions about the pickup\nfulfillment displayed in the Square Point of Sale application and set by the API.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment was picked up by the recipient. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nthat represents the start of the pickup window. Must be in RFC 3339 timestamp format, e.g.,\n\"2016-09-04T23:59:33.123Z\".\n  \nFor fulfillments with the schedule type `ASAP`, this is automatically set\nto the current time plus the expected duration to prepare the fulfillment.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? pickupAt { get; set; }

        ///<summary>
        ///The window of time in which the order should be picked up after the `pickup_at` timestamp.
        ///Must be in RFC 3339 duration format, e.g., "P1W3D". Can be used as an
        ///informational guideline for merchants.
        ///  
        ///Example for 2 days, 12 hours, 30 minutes, and 15 seconds: P2DT12H30M15S
        ///</summary>
        [Description("The window of time in which the order should be picked up after the `pickup_at` timestamp.\nMust be in RFC 3339 duration format, e.g., \"P1W3D\". Can be used as an\ninformational guideline for merchants.\n  \nExample for 2 days, 12 hours, 30 minutes, and 15 seconds: P2DT12H30M15S")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment was placed. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? placedAt { get; set; }

        ///<summary>
        ///The duration of time it takes to prepare this fulfillment.
        ///The duration must be in RFC 3339 format (for example, "P1W3D").
        ///  
        ///Example for 2 days, 12 hours, 30 minutes, and 15 seconds: P2DT12H30M15S
        ///</summary>
        [Description("The duration of time it takes to prepare this fulfillment.\nThe duration must be in RFC 3339 format (for example, \"P1W3D\").\n  \nExample for 2 days, 12 hours, 30 minutes, and 15 seconds: P2DT12H30M15S")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment is marked as ready for pickup. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? readyAt { get; set; }

        ///<summary>
        ///Information about the person to pick up this fulfillment from a physical
        ///location.
        ///</summary>
        [Description("Information about the person to pick up this fulfillment from a physical\nlocation.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the fulfillment was rejected. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? rejectedAt { get; set; }

        ///<summary>
        ///The schedule type of the pickup fulfillment. Defaults to `SCHEDULED`.
        ///</summary>
        [Description("The schedule type of the pickup fulfillment. Defaults to `SCHEDULED`.")]
        public OrderPickupScheduleType? scheduleType { get; set; }
    }

    ///<summary>
    ///The schedule type of the pickup fulfillment.
    ///</summary>
    [Description("The schedule type of the pickup fulfillment.")]
    public enum OrderPickupScheduleType
    {
        ///<summary>
        ///Indicates that the fulfillment will be picked up as soon as possible and
        ///should be prepared immediately.
        ///</summary>
        [Description("Indicates that the fulfillment will be picked up as soon as possible and\nshould be prepared immediately.")]
        ASAP,
        ///<summary>
        ///Indicates that the fulfillment will be picked up at a scheduled pickup time.
        ///</summary>
        [Description("Indicates that the fulfillment will be picked up at a scheduled pickup time.")]
        SCHEDULED,
    }

    public static class OrderPickupScheduleTypeStringValues
    {
        public const string ASAP = @"ASAP";
        public const string SCHEDULED = @"SCHEDULED";
    }

    ///<summary>
    ///Pricing options for an order.The options affect how the order's price is calculated.
    ///They can be used, for example, to apply automatic price adjustments that are based on preconfigured
    ///pricing rules.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Pricing options for an order.The options affect how the order's price is calculated.\nThey can be used, for example, to apply automatic price adjustments that are based on preconfigured\npricing rules.\nPermissions: ORDERS_READ")]
    public class OrderPricingOptions : GraphQLObject<OrderPricingOptions>
    {
        ///<summary>
        ///The option to determine whether pricing rule-based
        ///discounts are automatically applied to an order.
        ///</summary>
        [Description("The option to determine whether pricing rule-based\ndiscounts are automatically applied to an order.")]
        public bool? autoApplyDiscounts { get; set; }

        ///<summary>
        ///The option to determine whether rule-based taxes are automatically
        ///applied to an order when the criteria of the corresponding rules are met.
        ///</summary>
        [Description("The option to determine whether rule-based taxes are automatically\napplied to an order when the criteria of the corresponding rules are met.")]
        public bool? autoApplyTaxes { get; set; }
    }

    ///<summary>
    ///Contains the measurement unit for a quantity and a precision that
    ///specifies the number of digits after the decimal point for decimal quantities.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Contains the measurement unit for a quantity and a precision that\nspecifies the number of digits after the decimal point for decimal quantities.\nPermissions: ORDERS_READ")]
    public class OrderQuantityUnit : GraphQLObject<OrderQuantityUnit>
    {
        ///<summary>
        ///The catalog object ID referencing the
        ///CatalogMeasurementUnit.
        ///  
        ///This field is set when this is a catalog-backed measurement unit.
        ///</summary>
        [Description("The catalog object ID referencing the\nCatalogMeasurementUnit.\n  \nThis field is set when this is a catalog-backed measurement unit.")]
        public string? catalogObjectId { get; set; }

        ///<summary>
        ///A MeasurementUnit that represents the
        ///unit of measure for the quantity.
        ///</summary>
        [Description("A MeasurementUnit that represents the\nunit of measure for the quantity.")]
        public IMeasurementUnit? measurementUnit { get; set; }

        ///<summary>
        ///For non-integer quantities, represents the number of digits after the decimal point that are
        ///recorded for this quantity.
        ///  
        ///For example, a precision of 1 allows quantities such as `"1.0"` and `"1.1"`, but not `"1.01"`.
        ///  
        ///Min: 0. Max: 5.
        ///</summary>
        [Description("For non-integer quantities, represents the number of digits after the decimal point that are\nrecorded for this quantity.\n  \nFor example, a precision of 1 allows quantities such as `\"1.0\"` and `\"1.1\"`, but not `\"1.01\"`.\n  \nMin: 0. Max: 5.")]
        public int? precision { get; set; }
    }

    ///<summary>
    ///The set of line items, service charges, taxes, discounts, tips, and other items being returned in an order.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("The set of line items, service charges, taxes, discounts, tips, and other items being returned in an order.\nPermissions: ORDERS_READ")]
    public class OrderReturn : GraphQLObject<OrderReturn>
    {
        ///<summary>
        ///An aggregate monetary value being returned by this return entry.
        ///</summary>
        [Description("An aggregate monetary value being returned by this return entry.")]
        public OrderMoneyAmounts? amounts { get; set; }

        ///<summary>
        ///A collection of references to discounts being returned for an order, including the total
        ///applied discount amount to be returned. The discounts must reference a top-level discount ID
        ///from the source order.
        ///</summary>
        [Description("A collection of references to discounts being returned for an order, including the total\napplied discount amount to be returned. The discounts must reference a top-level discount ID\nfrom the source order.")]
        public IEnumerable<OrderReturnDiscount>? discounts { get; set; }

        ///<summary>
        ///A collection of line items that are being returned.
        ///</summary>
        [Description("A collection of line items that are being returned.")]
        public IEnumerable<OrderReturnLineItem>? lineItems { get; set; }

        ///<summary>
        ///A positive or negative rounding adjustment to the total value being returned. Adjustments are commonly
        ///used to apply cash rounding when the minimum unit of the account is smaller than the lowest
        ///physical denomination of the currency.
        ///</summary>
        [Description("A positive or negative rounding adjustment to the total value being returned. Adjustments are commonly\nused to apply cash rounding when the minimum unit of the account is smaller than the lowest\nphysical denomination of the currency.")]
        public OrderRoundingAdjustment? roundingAdjustment { get; set; }

        ///<summary>
        ///A collection of service charges that are being returned.
        ///</summary>
        [Description("A collection of service charges that are being returned.")]
        public IEnumerable<OrderReturnServiceCharge>? serviceCharges { get; set; }

        ///<summary>
        ///An order that contains the original sale of these return line items. This is unset
        ///for unlinked returns.
        ///</summary>
        [Description("An order that contains the original sale of these return line items. This is unset\nfor unlinked returns.")]
        public Order? source { get; set; }

        ///<summary>
        ///A collection of references to taxes being returned for an order, including the total
        ///applied tax amount to be returned. The taxes must reference a top-level tax ID from the source
        ///order.
        ///</summary>
        [Description("A collection of references to taxes being returned for an order, including the total\napplied tax amount to be returned. The taxes must reference a top-level tax ID from the source\norder.")]
        public IEnumerable<OrderReturnTax>? taxes { get; set; }

        ///<summary>
        ///A unique ID that identifies the return only within this order.
        ///</summary>
        [Description("A unique ID that identifies the return only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a discount being returned that applies to one or more return line items in an
    ///order.Fixed-amount, order-scoped discounts are distributed across all non-zero return line item totals.
    ///The amount distributed to each return line item is relative to that item’s contribution to the
    ///order subtotal.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents a discount being returned that applies to one or more return line items in an\norder.Fixed-amount, order-scoped discounts are distributed across all non-zero return line item totals.\nThe amount distributed to each return line item is relative to that item’s contribution to the\norder subtotal.\nPermissions: ORDERS_READ")]
    public class OrderReturnDiscount : GraphQLObject<OrderReturnDiscount>
    {
        ///<summary>
        ///The total declared monetary amount of the discount.
        ///  
        ///`amount_money` is not set for percentage-based discounts.
        ///</summary>
        [Description("The total declared monetary amount of the discount.\n  \n`amount_money` is not set for percentage-based discounts.")]
        public Money? amount { get; set; }

        ///<summary>
        ///The amount of discount actually applied to this line item. When an amount-based
        ///discount is at the order level, this value is different from `amount_money` because the discount
        ///is distributed across the line items.
        ///</summary>
        [Description("The amount of discount actually applied to this line item. When an amount-based\ndiscount is at the order level, this value is different from `amount_money` because the discount\nis distributed across the line items.")]
        public Money? appliedMoney { get; set; }

        ///<summary>
        ///The catalog object ID referencing CatalogDiscount.
        ///</summary>
        [Description("The catalog object ID referencing CatalogDiscount.")]
        public CatalogDiscount? discount { get; set; }

        ///<summary>
        ///The discount's name.
        ///</summary>
        [Description("The discount's name.")]
        public string? name { get; set; }

        ///<summary>
        ///The percentage of the tax, as a string representation of a decimal number.
        ///A value of `"7.25"` corresponds to a percentage of 7.25%.
        ///  
        ///`percentage` is not set for amount-based discounts.
        ///</summary>
        [Description("The percentage of the tax, as a string representation of a decimal number.\nA value of `\"7.25\"` corresponds to a percentage of 7.25%.\n  \n`percentage` is not set for amount-based discounts.")]
        public decimal? percentage { get; set; }

        ///<summary>
        ///Indicates the level at which the `OrderReturnDiscount` applies. For `ORDER` scoped
        ///discounts, the server generates references in `applied_discounts` on all
        ///`OrderReturnLineItem`s. For `LINE_ITEM` scoped discounts, the discount is only applied to
        ///`OrderReturnLineItem`s with references in their `applied_discounts` field.
        ///</summary>
        [Description("Indicates the level at which the `OrderReturnDiscount` applies. For `ORDER` scoped\ndiscounts, the server generates references in `applied_discounts` on all\n`OrderReturnLineItem`s. For `LINE_ITEM` scoped discounts, the discount is only applied to\n`OrderReturnLineItem`s with references in their `applied_discounts` field.")]
        public OrderLineItemDiscountScope? scope { get; set; }

        ///<summary>
        ///The discount `uid` from the order that contains the original application of this discount.
        ///</summary>
        [Description("The discount `uid` from the order that contains the original application of this discount.")]
        public string? sourceDiscountUid { get; set; }

        ///<summary>
        ///The type of the discount. If it is created by the API, it is `FIXED_PERCENTAGE` or `FIXED_AMOUNT`.
        ///  
        ///Discounts that do not reference a catalog object ID must have a type of
        ///`FIXED_PERCENTAGE` or `FIXED_AMOUNT`.
        ///</summary>
        [Description("The type of the discount. If it is created by the API, it is `FIXED_PERCENTAGE` or `FIXED_AMOUNT`.\n  \nDiscounts that do not reference a catalog object ID must have a type of\n`FIXED_PERCENTAGE` or `FIXED_AMOUNT`.")]
        public OrderLineItemDiscountType? type { get; set; }

        ///<summary>
        ///A unique ID that identifies the returned discount only within this order.
        ///</summary>
        [Description("A unique ID that identifies the returned discount only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///The line item being returned in an order.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("The line item being returned in an order.\nPermissions: ORDERS_READ")]
    public class OrderReturnLineItem : GraphQLObject<OrderReturnLineItem>
    {
        ///<summary>
        ///The list of references to `OrderReturnDiscount` entities applied to the return line item. Each
        ///`OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
        ///`OrderReturnDiscount` applied to the return line item. On reads, the applied amount
        ///is populated.
        ///</summary>
        [Description("The list of references to `OrderReturnDiscount` entities applied to the return line item. Each\n`OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level\n`OrderReturnDiscount` applied to the return line item. On reads, the applied amount\nis populated.")]
        public IEnumerable<OrderLineItemAppliedDiscount>? appliedDiscounts { get; set; }

        ///<summary>
        ///The list of references to `OrderReturnServiceCharge` entities applied to the return
        ///line item. Each `OrderLineItemAppliedServiceCharge` has a `service_charge_uid` that
        ///references the `uid` of a top-level `OrderReturnServiceCharge` applied to the return line
        ///item. On reads, the applied amount is populated.
        ///</summary>
        [Description("The list of references to `OrderReturnServiceCharge` entities applied to the return\nline item. Each `OrderLineItemAppliedServiceCharge` has a `service_charge_uid` that\nreferences the `uid` of a top-level `OrderReturnServiceCharge` applied to the return line\nitem. On reads, the applied amount is populated.")]
        public IEnumerable<OrderLineItemAppliedServiceCharge>? appliedServiceCharges { get; set; }

        ///<summary>
        ///The list of references to `OrderReturnTax` entities applied to the return line item. Each
        ///`OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
        ///`OrderReturnTax` applied to the return line item. On reads, the applied amount
        ///is populated.
        ///</summary>
        [Description("The list of references to `OrderReturnTax` entities applied to the return line item. Each\n`OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level\n`OrderReturnTax` applied to the return line item. On reads, the applied amount\nis populated.")]
        public IEnumerable<OrderLineItemAppliedTax>? appliedTaxes { get; set; }

        ///<summary>
        ///The base price for a single unit of the line item.
        ///</summary>
        [Description("The base price for a single unit of the line item.")]
        public Money? basePrice { get; set; }

        ///<summary>
        ///The gross return amount of money calculated as (item base price + modifiers price) * quantity.
        ///</summary>
        [Description("The gross return amount of money calculated as (item base price + modifiers price) * quantity.")]
        public Money? grossReturn { get; set; }

        ///<summary>
        ///The CatalogItemVariation ID applied to this return line item.
        ///</summary>
        [Description("The CatalogItemVariation ID applied to this return line item.")]
        public CatalogItemVariation? itemVariation { get; set; }

        ///<summary>
        ///The CatalogModifiers applied to this line item.
        ///</summary>
        [Description("The CatalogModifiers applied to this line item.")]
        public IEnumerable<OrderReturnLineItemModifier>? modifiers { get; set; }

        ///<summary>
        ///The name of the line item.
        ///</summary>
        [Description("The name of the line item.")]
        public string? name { get; set; }

        ///<summary>
        ///The note of the return line item.
        ///</summary>
        [Description("The note of the return line item.")]
        public string? note { get; set; }

        ///<summary>
        ///The quantity returned, formatted as a decimal number.
        ///For example, `"3"`.
        ///  
        ///Line items with a `quantity_unit` can have non-integer quantities.
        ///For example, `"1.70000"`.
        ///</summary>
        [Description("The quantity returned, formatted as a decimal number.\nFor example, `\"3\"`.\n  \nLine items with a `quantity_unit` can have non-integer quantities.\nFor example, `\"1.70000\"`.")]
        public decimal? quantity { get; set; }

        ///<summary>
        ///The unit and precision that this return line item's quantity is measured in.
        ///</summary>
        [Description("The unit and precision that this return line item's quantity is measured in.")]
        public OrderQuantityUnit? quantityUnit { get; set; }

        ///<summary>
        ///The `uid` of the line item in the original sale order.
        ///</summary>
        [Description("The `uid` of the line item in the original sale order.")]
        public string? sourceLineItemUid { get; set; }

        ///<summary>
        ///The total amount of discount money to return for the line item.
        ///</summary>
        [Description("The total amount of discount money to return for the line item.")]
        public Money? totalDiscount { get; set; }

        ///<summary>
        ///The total amount of money to return for this line item.
        ///</summary>
        [Description("The total amount of money to return for this line item.")]
        public Money? totalMoney { get; set; }

        ///<summary>
        ///The total amount of apportioned service charge money to return for the line item.
        ///</summary>
        [Description("The total amount of apportioned service charge money to return for the line item.")]
        public Money? totalServiceCharge { get; set; }

        ///<summary>
        ///The total amount of tax money to return for the line item.
        ///</summary>
        [Description("The total amount of tax money to return for the line item.")]
        public Money? totalTax { get; set; }

        ///<summary>
        ///A unique ID for this return line-item entry.
        ///</summary>
        [Description("A unique ID for this return line-item entry.")]
        public string? uid { get; set; }

        ///<summary>
        ///The name of the variation applied to this return line item.
        ///</summary>
        [Description("The name of the variation applied to this return line item.")]
        public string? variationName { get; set; }

        ///<summary>
        ///The total price of all item variations returned in this line item.
        ///The price is calculated as `base_price_money` multiplied by `quantity` and
        ///does not include modifiers.
        ///</summary>
        [Description("The total price of all item variations returned in this line item.\nThe price is calculated as `base_price_money` multiplied by `quantity` and\ndoes not include modifiers.")]
        public Money? variationTotalPrice { get; set; }
    }

    ///<summary>
    ///A line item modifier being returned.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("A line item modifier being returned.\nPermissions: ORDERS_READ")]
    public class OrderReturnLineItemModifier : GraphQLObject<OrderReturnLineItemModifier>
    {
        ///<summary>
        ///The base price for the modifier.
        ///  
        ///`base_price_money` is required for ad hoc modifiers.
        ///If both `catalog_object_id` and `base_price_money` are set, `base_price_money` overrides the predefined CatalogModifier price.
        ///</summary>
        [Description("The base price for the modifier.\n  \n`base_price_money` is required for ad hoc modifiers.\nIf both `catalog_object_id` and `base_price_money` are set, `base_price_money` overrides the predefined CatalogModifier price.")]
        public Money? basePrice { get; set; }

        ///<summary>
        ///The catalog object ID referencing CatalogModifier.
        ///</summary>
        [Description("The catalog object ID referencing CatalogModifier.")]
        public CatalogModifier? modifier { get; set; }

        ///<summary>
        ///The name of the item modifier.
        ///</summary>
        [Description("The name of the item modifier.")]
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
        [Description("The quantity of the line item modifier. The modifier quantity can be 0 or more.\nFor example, suppose a restaurant offers a cheeseburger on the menu. When a buyer orders\nthis item, the restaurant records the purchase by creating an `Order` object with a line item\nfor a burger. The line item includes a line item modifier: the name is cheese and the quantity\nis 1. The buyer has the option to order extra cheese (or no cheese). If the buyer chooses\nthe extra cheese option, the modifier quantity increases to 2. If the buyer does not want\nany cheese, the modifier quantity is set to 0.")]
        public decimal? quantity { get; set; }

        ///<summary>
        ///The modifier `uid` from the order's line item that contains the
        ///original sale of this line item modifier.
        ///</summary>
        [Description("The modifier `uid` from the order's line item that contains the\noriginal sale of this line item modifier.")]
        public string? sourceModifierUid { get; set; }

        ///<summary>
        ///The total price of the item modifier for its line item.
        ///This is the modifier's `base_price_money` multiplied by the line item's quantity.
        ///</summary>
        [Description("The total price of the item modifier for its line item.\nThis is the modifier's `base_price_money` multiplied by the line item's quantity.")]
        public Money? totalPrice { get; set; }

        ///<summary>
        ///A unique ID that identifies the return modifier only within this order.
        ///</summary>
        [Description("A unique ID that identifies the return modifier only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents the service charge applied to the original order.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents the service charge applied to the original order.\nPermissions: ORDERS_READ")]
    public class OrderReturnServiceCharge : GraphQLObject<OrderReturnServiceCharge>
    {
        ///<summary>
        ///The amount of a non-percentage-based service charge.
        ///  
        ///Either `percentage` or `amount_money` should be set, but not both.
        ///</summary>
        [Description("The amount of a non-percentage-based service charge.\n  \nEither `percentage` or `amount_money` should be set, but not both.")]
        public Money? amount { get; set; }

        ///<summary>
        ///The amount of money applied to the order by the service charge, including
        ///any inclusive tax amounts, as calculated by Square.
        ///  
        ///- For fixed-amount service charges, `applied_money` is equal to `amount_money`.
        ///- For percentage-based service charges, `applied_money` is the money calculated using the percentage.
        ///</summary>
        [Description("The amount of money applied to the order by the service charge, including\nany inclusive tax amounts, as calculated by Square.\n  \n- For fixed-amount service charges, `applied_money` is equal to `amount_money`.\n- For percentage-based service charges, `applied_money` is the money calculated using the percentage.")]
        public Money? appliedMoney { get; set; }

        ///<summary>
        ///The list of references to `OrderReturnTax` entities applied to the
        ///`OrderReturnServiceCharge`. Each `OrderLineItemAppliedTax` has a `tax_uid`
        ///that references the `uid` of a top-level `OrderReturnTax` that is being
        ///applied to the `OrderReturnServiceCharge`. On reads, the applied amount is
        ///populated.
        ///</summary>
        [Description("The list of references to `OrderReturnTax` entities applied to the\n`OrderReturnServiceCharge`. Each `OrderLineItemAppliedTax` has a `tax_uid`\nthat references the `uid` of a top-level `OrderReturnTax` that is being\napplied to the `OrderReturnServiceCharge`. On reads, the applied amount is\npopulated.")]
        public IEnumerable<OrderLineItemAppliedTax>? appliedTaxes { get; set; }

        ///<summary>
        ///The calculation phase after which to apply the service charge.
        ///</summary>
        [Description("The calculation phase after which to apply the service charge.")]
        public OrderServiceChargeCalculationPhase? calculationPhase { get; set; }

        ///<summary>
        ///The name of the service charge.
        ///</summary>
        [Description("The name of the service charge.")]
        public string? name { get; set; }

        ///<summary>
        ///The percentage of the service charge, as a string representation of
        ///a decimal number. For example, a value of `"7.25"` corresponds to a
        ///percentage of 7.25%.
        ///  
        ///Either `percentage` or `amount_money` should be set, but not both.
        ///</summary>
        [Description("The percentage of the service charge, as a string representation of\na decimal number. For example, a value of `\"7.25\"` corresponds to a\npercentage of 7.25%.\n  \nEither `percentage` or `amount_money` should be set, but not both.")]
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
        [Description("Indicates the level at which the apportioned service charge applies. For `ORDER`\nscoped service charges, Square generates references in `applied_service_charges` on\nall order line items that do not have them. For `LINE_ITEM` scoped service charges,\nthe service charge only applies to line items with a service charge reference in their\n`applied_service_charges` field.\n  \nThis field is immutable. To change the scope of an apportioned service charge, you must delete\nthe apportioned service charge and re-add it as a new apportioned service charge.")]
        public OrderServiceChargeScope? scope { get; set; }

        ///<summary>
        ///The catalog object ID of the associated OrderServiceCharge.
        ///</summary>
        [Description("The catalog object ID of the associated OrderServiceCharge.")]
        public CatalogServiceCharge? serviceCharge { get; set; }

        ///<summary>
        ///The service charge `uid` from the order containing the original
        ///service charge. `source_service_charge_uid` is `null` for
        ///unlinked returns.
        ///</summary>
        [Description("The service charge `uid` from the order containing the original\nservice charge. `source_service_charge_uid` is `null` for\nunlinked returns.")]
        public string? sourceServiceChargeUid { get; set; }

        ///<summary>
        ///Indicates whether the surcharge can be taxed. Service charges
        ///calculated in the `TOTAL_PHASE` cannot be marked as taxable.
        ///</summary>
        [Description("Indicates whether the surcharge can be taxed. Service charges\ncalculated in the `TOTAL_PHASE` cannot be marked as taxable.")]
        public bool? taxable { get; set; }

        ///<summary>
        ///The total amount of money to collect for the service charge.
        ///  
        ///__NOTE__: If an inclusive tax is applied to the service charge, `total_money`
        ///does not equal `applied_money` plus `total_tax_money` because the inclusive
        ///tax amount is already included in both `applied_money` and `total_tax_money`.
        ///</summary>
        [Description("The total amount of money to collect for the service charge.\n  \n__NOTE__: If an inclusive tax is applied to the service charge, `total_money`\ndoes not equal `applied_money` plus `total_tax_money` because the inclusive\ntax amount is already included in both `applied_money` and `total_tax_money`.")]
        public Money? totalMoney { get; set; }

        ///<summary>
        ///The total amount of tax money to collect for the service charge.
        ///</summary>
        [Description("The total amount of tax money to collect for the service charge.")]
        public Money? totalTax { get; set; }

        ///<summary>
        ///The treatment type of the service charge.
        ///</summary>
        [Description("The treatment type of the service charge.")]
        public OrderServiceChargeTreatmentType? treatmentType { get; set; }

        ///<summary>
        ///A unique ID that identifies the return service charge only within this order.
        ///</summary>
        [Description("A unique ID that identifies the return service charge only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a tax being returned that applies to one or more return line items in an order.Fixed-amount, order-scoped taxes are distributed across all non-zero return line item totals.
    ///The amount distributed to each return line item is relative to that item’s contribution to the
    ///order subtotal.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents a tax being returned that applies to one or more return line items in an order.Fixed-amount, order-scoped taxes are distributed across all non-zero return line item totals.\nThe amount distributed to each return line item is relative to that item’s contribution to the\norder subtotal.\nPermissions: ORDERS_READ")]
    public class OrderReturnTax : GraphQLObject<OrderReturnTax>
    {
        ///<summary>
        ///The amount of money applied by the tax in an order.
        ///</summary>
        [Description("The amount of money applied by the tax in an order.")]
        public Money? appliedMoney { get; set; }

        ///<summary>
        ///The tax's name.
        ///</summary>
        [Description("The tax's name.")]
        public string? name { get; set; }

        ///<summary>
        ///The percentage of the tax, as a string representation of a decimal number.
        ///For example, a value of `"7.25"` corresponds to a percentage of 7.25%.
        ///</summary>
        [Description("The percentage of the tax, as a string representation of a decimal number.\nFor example, a value of `\"7.25\"` corresponds to a percentage of 7.25%.")]
        public decimal? percentage { get; set; }

        ///<summary>
        ///Indicates the level at which the `OrderReturnTax` applies. For `ORDER` scoped
        ///taxes, Square generates references in `applied_taxes` on all
        ///`OrderReturnLineItem`s. For `LINE_ITEM` scoped taxes, the tax is only applied to
        ///`OrderReturnLineItem`s with references in their `applied_discounts` field.
        ///</summary>
        [Description("Indicates the level at which the `OrderReturnTax` applies. For `ORDER` scoped\ntaxes, Square generates references in `applied_taxes` on all\n`OrderReturnLineItem`s. For `LINE_ITEM` scoped taxes, the tax is only applied to\n`OrderReturnLineItem`s with references in their `applied_discounts` field.")]
        public OrderLineItemTaxScope? scope { get; set; }

        ///<summary>
        ///The tax `uid` from the order that contains the original tax charge.
        ///</summary>
        [Description("The tax `uid` from the order that contains the original tax charge.")]
        public string? sourceTaxUid { get; set; }

        ///<summary>
        ///The catalog object ID referencing CatalogTax.
        ///</summary>
        [Description("The catalog object ID referencing CatalogTax.")]
        public CatalogTax? tax { get; set; }

        ///<summary>
        ///Indicates the calculation method used to apply the tax.
        ///</summary>
        [Description("Indicates the calculation method used to apply the tax.")]
        public OrderLineItemTaxType? type { get; set; }

        ///<summary>
        ///A unique ID that identifies the returned tax only within this order.
        ///</summary>
        [Description("A unique ID that identifies the returned tax only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///A rounding adjustment of the money being returned.Commonly used to apply cash rounding
    ///when the minimum unit of the account is smaller than the lowest physical denomination of the currency.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("A rounding adjustment of the money being returned.Commonly used to apply cash rounding\nwhen the minimum unit of the account is smaller than the lowest physical denomination of the currency.\nPermissions: ORDERS_READ")]
    public class OrderRoundingAdjustment : GraphQLObject<OrderRoundingAdjustment>
    {
        ///<summary>
        ///The actual rounding adjustment amount.
        ///</summary>
        [Description("The actual rounding adjustment amount.")]
        public Money? amount { get; set; }

        ///<summary>
        ///The name of the rounding adjustment from the original sale order.
        ///</summary>
        [Description("The name of the rounding adjustment from the original sale order.")]
        public string? name { get; set; }

        ///<summary>
        ///A unique ID that identifies the rounding adjustment only within this order.
        ///</summary>
        [Description("A unique ID that identifies the rounding adjustment only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a service charge applied to an order.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents a service charge applied to an order.\nPermissions: ORDERS_READ")]
    public class OrderServiceCharge : GraphQLObject<OrderServiceCharge>
    {
        ///<summary>
        ///The amount of a non-percentage-based service charge.
        ///  
        ///Exactly one of `percentage` or `amount_money` should be set.
        ///</summary>
        [Description("The amount of a non-percentage-based service charge.\n  \nExactly one of `percentage` or `amount_money` should be set.")]
        public Money? amount { get; set; }

        ///<summary>
        ///The amount of money applied to the order by the service charge,
        ///including any inclusive tax amounts, as calculated by Square.
        ///  
        ///- For fixed-amount service charges, `applied_money` is equal to `amount_money`.
        ///- For percentage-based service charges, `applied_money` is the money
        ///calculated using the percentage.
        ///</summary>
        [Description("The amount of money applied to the order by the service charge,\nincluding any inclusive tax amounts, as calculated by Square.\n  \n- For fixed-amount service charges, `applied_money` is equal to `amount_money`.\n- For percentage-based service charges, `applied_money` is the money\ncalculated using the percentage.")]
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
        [Description("The list of references to the taxes applied to this service charge. Each\n`OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level\n`OrderLineItemTax` that is being applied to this service charge. On reads, the amount applied\nis populated.\n  \nAn `OrderLineItemAppliedTax` is automatically created on every taxable service charge\nfor all `ORDER` scoped taxes that are added to the order. `OrderLineItemAppliedTax` records\nfor `LINE_ITEM` scoped taxes must be added in requests for the tax to apply to any taxable\nservice charge. Taxable service charges have the `taxable` field set to `true` and calculated\nin the `SUBTOTAL_PHASE`.\n  \nTo change the amount of a tax, modify the referenced top-level tax.")]
        public IEnumerable<OrderLineItemAppliedTax>? appliedTaxes { get; set; }

        ///<summary>
        ///The calculation phase at which to apply the service charge.
        ///</summary>
        [Description("The calculation phase at which to apply the service charge.")]
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
        [Description("Application-defined data attached to this service charge. Metadata fields are intended\nto store descriptive references or associations with an entity in another system or store brief\ninformation about the object. Square does not process this field; it only stores and returns it\nin relevant API calls. Do not use metadata to store any sensitive information (such as personally\nidentifiable information or card details).\n  \nKeys written by applications must be 60 characters or less and must be in the character set\n`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed\nwith a namespace, separated from the key with a ':' character.\n  \nValues have a maximum length of 255 characters.\n  \nAn application can have up to 10 entries per metadata field.\n  \nEntries written by applications are private and can only be read or modified by the same\napplication.\n  \nFor more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).")]
        public Metadata? metadata { get; set; }

        ///<summary>
        ///The name of the service charge.
        ///</summary>
        [Description("The name of the service charge.")]
        public string? name { get; set; }

        ///<summary>
        ///The service charge percentage as a string representation of a
        ///decimal number. For example, `"7.25"` indicates a service charge of 7.25%.
        ///  
        ///Exactly 1 of `percentage` or `amount_money` should be set.
        ///</summary>
        [Description("The service charge percentage as a string representation of a\ndecimal number. For example, `\"7.25\"` indicates a service charge of 7.25%.\n  \nExactly 1 of `percentage` or `amount_money` should be set.")]
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
        [Description("Indicates the level at which the apportioned service charge applies. For `ORDER`\nscoped service charges, Square generates references in `applied_service_charges` on\nall order line items that do not have them. For `LINE_ITEM` scoped service charges,\nthe service charge only applies to line items with a service charge reference in their\n`applied_service_charges` field.\n  \nThis field is immutable. To change the scope of an apportioned service charge, you must delete\nthe apportioned service charge and re-add it as a new apportioned service charge.")]
        public OrderServiceChargeScope? scope { get; set; }

        ///<summary>
        ///The catalog object ID referencing the service charge CatalogObject.
        ///</summary>
        [Description("The catalog object ID referencing the service charge CatalogObject.")]
        public CatalogServiceCharge? serviceCharge { get; set; }

        ///<summary>
        ///Indicates whether the service charge can be taxed. If set to `true`,
        ///order-level taxes automatically apply to the service charge. Note that
        ///service charges calculated in the `TOTAL_PHASE` cannot be marked as taxable.
        ///</summary>
        [Description("Indicates whether the service charge can be taxed. If set to `true`,\norder-level taxes automatically apply to the service charge. Note that\nservice charges calculated in the `TOTAL_PHASE` cannot be marked as taxable.")]
        public bool? taxable { get; set; }

        ///<summary>
        ///The total amount of money to collect for the service charge.
        ///  
        ///__Note__: If an inclusive tax is applied to the service charge,
        ///`total_money` does not equal `applied_money` plus `total_tax_money`
        ///because the inclusive tax amount is already included in both
        ///`applied_money` and `total_tax_money`.
        ///</summary>
        [Description("The total amount of money to collect for the service charge.\n  \n__Note__: If an inclusive tax is applied to the service charge,\n`total_money` does not equal `applied_money` plus `total_tax_money`\nbecause the inclusive tax amount is already included in both\n`applied_money` and `total_tax_money`.")]
        public Money? totalMoney { get; set; }

        ///<summary>
        ///The total amount of tax money to collect for the service charge.
        ///</summary>
        [Description("The total amount of tax money to collect for the service charge.")]
        public Money? totalTax { get; set; }

        ///<summary>
        ///The treatment type of the service charge.
        ///</summary>
        [Description("The treatment type of the service charge.")]
        public OrderServiceChargeTreatmentType? treatmentType { get; set; }

        ///<summary>
        ///The type of the service charge.
        ///</summary>
        [Description("The type of the service charge.")]
        public OrderServiceChargeType? type { get; set; }

        ///<summary>
        ///A unique ID that identifies the service charge only within this order.
        ///</summary>
        [Description("A unique ID that identifies the service charge only within this order.")]
        public string? uid { get; set; }
    }

    ///<summary>
    ///Represents a phase in the process of calculating order totals.Service charges are applied after the indicated phase.
    ///
    ///[Read more about how order totals are calculated.](https://developer.squareup.com/docs/orders-api/how-it-works#how-totals-are-calculated)
    ///</summary>
    [Description("Represents a phase in the process of calculating order totals.Service charges are applied after the indicated phase.\n\n[Read more about how order totals are calculated.](https://developer.squareup.com/docs/orders-api/how-it-works#how-totals-are-calculated)")]
    public enum OrderServiceChargeCalculationPhase
    {
        ///<summary>
        ///The service charge is calculated as a compounding adjustment
        ///after any discounts and percentage based apportioned service charges,
        ///but before any tax considerations.
        ///</summary>
        [Description("The service charge is calculated as a compounding adjustment\nafter any discounts and percentage based apportioned service charges,\nbut before any tax considerations.")]
        APPORTIONED_AMOUNT_PHASE,
        ///<summary>
        ///The service charge is calculated as a compounding adjustment
        ///after any discounts, but before amount based apportioned service charges
        ///and any tax considerations.
        ///</summary>
        [Description("The service charge is calculated as a compounding adjustment\nafter any discounts, but before amount based apportioned service charges\nand any tax considerations.")]
        APPORTIONED_PERCENTAGE_PHASE,
        ///<summary>
        ///The service charge is applied after discounts, but before
        ///taxes.
        ///</summary>
        [Description("The service charge is applied after discounts, but before\ntaxes.")]
        SUBTOTAL_PHASE,
        ///<summary>
        ///The service charge is applied after all discounts and taxes
        ///are applied.
        ///</summary>
        [Description("The service charge is applied after all discounts and taxes\nare applied.")]
        TOTAL_PHASE,
    }

    public static class OrderServiceChargeCalculationPhaseStringValues
    {
        public const string APPORTIONED_AMOUNT_PHASE = @"APPORTIONED_AMOUNT_PHASE";
        public const string APPORTIONED_PERCENTAGE_PHASE = @"APPORTIONED_PERCENTAGE_PHASE";
        public const string SUBTOTAL_PHASE = @"SUBTOTAL_PHASE";
        public const string TOTAL_PHASE = @"TOTAL_PHASE";
    }

    ///<summary>
    ///Indicates whether this is a line-item or order-level apportioned
    ///service charge.
    ///</summary>
    [Description("Indicates whether this is a line-item or order-level apportioned\nservice charge.")]
    public enum OrderServiceChargeScope
    {
        ///<summary>
        ///The service charge should be applied to only line items specified by
        ///`OrderLineItemAppliedServiceCharge` reference records.
        ///</summary>
        [Description("The service charge should be applied to only line items specified by\n`OrderLineItemAppliedServiceCharge` reference records.")]
        LINE_ITEM,
        ///<summary>
        ///The service charge should be applied to the entire order.
        ///</summary>
        [Description("The service charge should be applied to the entire order.")]
        ORDER,
        ///<summary>
        ///Used for reporting only.
        ///The original transaction service charge scope is currently not supported by the API.
        ///</summary>
        [Description("Used for reporting only.\nThe original transaction service charge scope is currently not supported by the API.")]
        OTHER_SERVICE_CHARGE_SCOPE,
    }

    public static class OrderServiceChargeScopeStringValues
    {
        public const string LINE_ITEM = @"LINE_ITEM";
        public const string ORDER = @"ORDER";
        public const string OTHER_SERVICE_CHARGE_SCOPE = @"OTHER_SERVICE_CHARGE_SCOPE";
    }

    ///<summary>
    ///Indicates whether the service charge will be treated as a value-holding line item or
    ///apportioned toward a line item.
    ///</summary>
    [Description("Indicates whether the service charge will be treated as a value-holding line item or\napportioned toward a line item.")]
    public enum OrderServiceChargeTreatmentType
    {
        APPORTIONED_TREATMENT,
        LINE_ITEM_TREATMENT,
    }

    public static class OrderServiceChargeTreatmentTypeStringValues
    {
        public const string APPORTIONED_TREATMENT = @"APPORTIONED_TREATMENT";
        public const string LINE_ITEM_TREATMENT = @"LINE_ITEM_TREATMENT";
    }

    public enum OrderServiceChargeType
    {
        AUTO_GRATUITY,
        CUSTOM,
    }

    public static class OrderServiceChargeTypeStringValues
    {
        public const string AUTO_GRATUITY = @"AUTO_GRATUITY";
        public const string CUSTOM = @"CUSTOM";
    }

    ///<summary>
    ///Contains the details necessary to fulfill a shipment order.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Contains the details necessary to fulfill a shipment order.\nPermissions: ORDERS_READ")]
    public class OrderShipment : GraphQLObject<OrderShipment>
    {
        ///<summary>
        ///A description of why the shipment was canceled.
        ///</summary>
        [Description("A description of why the shipment was canceled.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating the shipment was canceled.\nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? canceledAt { get; set; }

        ///<summary>
        ///The shipping carrier being used to ship this fulfillment (such as UPS, FedEx, or USPS).
        ///</summary>
        [Description("The shipping carrier being used to ship this fulfillment (such as UPS, FedEx, or USPS).")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the shipment is expected to be delivered to the shipping carrier.\nThe timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the shipment failed to be completed. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? failedAt { get; set; }

        ///<summary>
        ///A description of why the shipment failed to be completed.
        ///</summary>
        [Description("A description of why the shipment failed to be completed.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when this fulfillment was moved to the `RESERVED` state, which  indicates that preparation\nof this shipment has begun. The timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when this fulfillment was moved to the `PREPARED` state, which indicates that the\nfulfillment is packaged. The timestamp must be in RFC 3339 format (for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when the shipment was requested. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? placedAt { get; set; }

        ///<summary>
        ///Information about the person to receive this shipment fulfillment.
        ///</summary>
        [Description("Information about the person to receive this shipment fulfillment.")]
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
        [Description("The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)\nindicating when this fulfillment was moved to the `COMPLETED` state, which indicates that\nthe fulfillment has been given to the shipping carrier. The timestamp must be in RFC 3339 format\n(for example, \"2016-09-04T23:59:33.123Z\").\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? shippedAt { get; set; }

        ///<summary>
        ///A note with additional information for the shipping carrier.
        ///</summary>
        [Description("A note with additional information for the shipping carrier.")]
        public string? shippingNote { get; set; }

        ///<summary>
        ///A description of the type of shipping product purchased from the carrier
        ///(such as First Class, Priority, or Express).
        ///</summary>
        [Description("A description of the type of shipping product purchased from the carrier\n(such as First Class, Priority, or Express).")]
        public string? shippingType { get; set; }

        ///<summary>
        ///The reference number provided by the carrier to track the shipment's progress.
        ///</summary>
        [Description("The reference number provided by the carrier to track the shipment's progress.")]
        public string? trackingNumber { get; set; }

        ///<summary>
        ///A link to the tracking webpage on the carrier's website.
        ///</summary>
        [Description("A link to the tracking webpage on the carrier's website.")]
        public string? trackingUrl { get; set; }
    }

    ///<summary>
    ///Criteria to sort results by. The chronological order in which results are returned. Defaults to createdAt_DESC.
    ///
    ///When using a BasicDateTimeFilter, OrderSort must match the timestamp field that the BasicDateTimeFilter uses to filter. For example, If you set your sort_field to closedAt and you use a BasicDateTimeFilter,
    ///your BasicDateTimeFilter must filter for orders by their closedAt date. If this field does not match the timestamp field in BasicDateTimeFilter, it will return an error.
    ///</summary>
    [Description("Criteria to sort results by. The chronological order in which results are returned. Defaults to createdAt_DESC.\n\nWhen using a BasicDateTimeFilter, OrderSort must match the timestamp field that the BasicDateTimeFilter uses to filter. For example, If you set your sort_field to closedAt and you use a BasicDateTimeFilter,\nyour BasicDateTimeFilter must filter for orders by their closedAt date. If this field does not match the timestamp field in BasicDateTimeFilter, it will return an error.")]
    public enum OrderSort
    {
        closedAt_ASC,
        closedAt_DESC,
        createdAt_ASC,
        createdAt_DESC,
        updatedAt_ASC,
        updatedAt_DESC,
    }

    public static class OrderSortStringValues
    {
        public const string closedAt_ASC = @"closedAt_ASC";
        public const string closedAt_DESC = @"closedAt_DESC";
        public const string createdAt_ASC = @"createdAt_ASC";
        public const string createdAt_DESC = @"createdAt_DESC";
        public const string updatedAt_ASC = @"updatedAt_ASC";
        public const string updatedAt_DESC = @"updatedAt_DESC";
    }

    ///<summary>
    ///Represents the origination details of an order.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents the origination details of an order.\nPermissions: ORDERS_READ")]
    public class OrderSource : GraphQLObject<OrderSource>
    {
        ///<summary>
        ///The name used to identify the place (physical or digital) that an order originates.
        ///If unset, the name defaults to the name of the application that created the order.
        ///</summary>
        [Description("The name used to identify the place (physical or digital) that an order originates.\nIf unset, the name defaults to the name of the application that created the order.")]
        public string? name { get; set; }
    }

    ///<summary>
    ///Represents the details of a tender with `type` `SQUARE_ACCOUNT`.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents the details of a tender with `type` `SQUARE_ACCOUNT`.\nPermissions: ORDERS_READ")]
    public class OrderSquareAccountTender : GraphQLObject<OrderSquareAccountTender>, IOrderTender
    {
        ///<summary>
        ///The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
        ///the `total_money` of the corresponding Payment will be equal to the
        ///`amount_money` of the tender.
        ///</summary>
        [Description("The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,\nthe `total_money` of the corresponding Payment will be equal to the\n`amount_money` of the tender.")]
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
        [Description("The timestamp for when the tender was created, in RFC 3339 format.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        [Description("If the tender is associated with a customer or represents a customer's card on file,\nthis is the ID of the associated customer.")]
        public Customer? customer { get; set; }

        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        [Description("The tender's unique ID. It is the associated payment ID.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        [Description("The ID of the transaction's associated location.")]
        public Location? location { get; set; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; set; }

        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        [Description("An optional note associated with the tender at the time of payment.")]
        public string? note { get; set; }

        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        [Description("The ID of the Payment that corresponds to this tender.\nThis value is only present for payments created with the v2 Payments API.")]
        public Payment? payment { get; set; }

        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        [Description("The amount of any Square processing fees applied to the tender.\n  \nThis field is not immediately populated when a new transaction is created.\nIt is usually available after about ten seconds.")]
        public Money? processingFee { get; set; }

        ///<summary>
        ///The Square Account payment's current state (such as `AUTHORIZED` or
        ///`CAPTURED`). See TenderSquareAccountDetailsStatus
        ///for possible values.
        ///</summary>
        [Description("The Square Account payment's current state (such as `AUTHORIZED` or\n`CAPTURED`). See TenderSquareAccountDetailsStatus\nfor possible values.")]
        public OrderSquareAccountTenderStatus? status { get; set; }

        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        [Description("The tip's amount of the tender.")]
        public Money? tip { get; set; }

        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        [Description("The ID of the tender's associated transaction.")]
        public string? transactionId { get; set; }

        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        [Description("The type of tender, such as `CARD` or `CASH`.")]
        public OrderTenderType? type { get; set; }
    }

    public enum OrderSquareAccountTenderStatus
    {
        ///<summary>
        ///The Square Account payment has been authorized but not yet captured.
        ///</summary>
        [Description("The Square Account payment has been authorized but not yet captured.")]
        AUTHORIZED,
        ///<summary>
        ///The Square Account payment was authorized and subsequently captured (i.e., completed).
        ///</summary>
        [Description("The Square Account payment was authorized and subsequently captured (i.e., completed).")]
        CAPTURED,
        ///<summary>
        ///The Square Account payment failed.
        ///</summary>
        [Description("The Square Account payment failed.")]
        FAILED,
        ///<summary>
        ///The Square Account payment was authorized and subsequently voided (i.e., canceled).
        ///</summary>
        [Description("The Square Account payment was authorized and subsequently voided (i.e., canceled).")]
        VOIDED,
    }

    public static class OrderSquareAccountTenderStatusStringValues
    {
        public const string AUTHORIZED = @"AUTHORIZED";
        public const string CAPTURED = @"CAPTURED";
        public const string FAILED = @"FAILED";
        public const string VOIDED = @"VOIDED";
    }

    ///<summary>
    ///The state of the order.
    ///</summary>
    [Description("The state of the order.")]
    public enum OrderState
    {
        ///<summary>
        ///Indicates that the order is canceled. Canceled orders are not paid. This is a terminal state.
        ///</summary>
        [Description("Indicates that the order is canceled. Canceled orders are not paid. This is a terminal state.")]
        CANCELED,
        ///<summary>
        ///Indicates that the order is completed. Completed orders are fully paid. This is a terminal state.
        ///</summary>
        [Description("Indicates that the order is completed. Completed orders are fully paid. This is a terminal state.")]
        COMPLETED,
        ///<summary>
        ///Indicates that the order is in a draft state. Draft orders can be updated,
        ///but cannot be paid or fulfilled.
        ///For more information, see [Create Orders](https://developer.squareup.com/docs/orders-api/create-orders).
        ///</summary>
        [Description("Indicates that the order is in a draft state. Draft orders can be updated,\nbut cannot be paid or fulfilled.\nFor more information, see [Create Orders](https://developer.squareup.com/docs/orders-api/create-orders).")]
        DRAFT,
        ///<summary>
        ///Indicates that the order is open. Open orders can be updated.
        ///</summary>
        [Description("Indicates that the order is open. Open orders can be updated.")]
        OPEN,
    }

    public static class OrderStateStringValues
    {
        public const string CANCELED = @"CANCELED";
        public const string COMPLETED = @"COMPLETED";
        public const string DRAFT = @"DRAFT";
        public const string OPEN = @"OPEN";
    }

    ///<summary>
    ///Represents a tender (i.e., a method of payment) used in a Square transaction.
    ///</summary>
    [Description("Represents a tender (i.e., a method of payment) used in a Square transaction.")]
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
        [Description("The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,\nthe `total_money` of the corresponding Payment will be equal to the\n`amount_money` of the tender.")]
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
        [Description("The timestamp for when the tender was created, in RFC 3339 format.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; }

        ///<summary>
        ///If the tender is associated with a customer or represents a customer's card on file,
        ///this is the ID of the associated customer.
        ///</summary>
        [Description("If the tender is associated with a customer or represents a customer's card on file,\nthis is the ID of the associated customer.")]
        public Customer? customer { get; }

        ///<summary>
        ///The tender's unique ID. It is the associated payment ID.
        ///</summary>
        [Description("The tender's unique ID. It is the associated payment ID.")]
        [NonNull]
        public string? id { get; }

        ///<summary>
        ///The ID of the transaction's associated location.
        ///</summary>
        [Description("The ID of the transaction's associated location.")]
        public Location? location { get; }

        ///<summary>
        ///The Square-issued ID of the merchant.
        ///</summary>
        [Description("The Square-issued ID of the merchant.")]
        [NonNull]
        public string? merchantId { get; }

        ///<summary>
        ///An optional note associated with the tender at the time of payment.
        ///</summary>
        [Description("An optional note associated with the tender at the time of payment.")]
        public string? note { get; }

        ///<summary>
        ///The ID of the Payment that corresponds to this tender.
        ///This value is only present for payments created with the v2 Payments API.
        ///</summary>
        [Description("The ID of the Payment that corresponds to this tender.\nThis value is only present for payments created with the v2 Payments API.")]
        public Payment? payment { get; }

        ///<summary>
        ///The amount of any Square processing fees applied to the tender.
        ///  
        ///This field is not immediately populated when a new transaction is created.
        ///It is usually available after about ten seconds.
        ///</summary>
        [Description("The amount of any Square processing fees applied to the tender.\n  \nThis field is not immediately populated when a new transaction is created.\nIt is usually available after about ten seconds.")]
        public Money? processingFee { get; }

        ///<summary>
        ///The tip's amount of the tender.
        ///</summary>
        [Description("The tip's amount of the tender.")]
        public Money? tip { get; }

        ///<summary>
        ///The ID of the tender's associated transaction.
        ///</summary>
        [Description("The ID of the tender's associated transaction.")]
        public string? transactionId { get; }

        ///<summary>
        ///The type of tender, such as `CARD` or `CASH`.
        ///</summary>
        [Description("The type of tender, such as `CARD` or `CASH`.")]
        public OrderTenderType? type { get; }
    }

    ///<summary>
    ///Indicates a tender's type.
    ///</summary>
    [Description("Indicates a tender's type.")]
    public enum OrderTenderType
    {
        ///<summary>
        ///A bank account payment.
        ///</summary>
        [Description("A bank account payment.")]
        BANK_ACCOUNT,
        ///<summary>
        ///A Buy Now Pay Later payment.
        ///</summary>
        [Description("A Buy Now Pay Later payment.")]
        BUY_NOW_PAY_LATER,
        ///<summary>
        ///A credit card.
        ///</summary>
        [Description("A credit card.")]
        CARD,
        ///<summary>
        ///Cash.
        ///</summary>
        [Description("Cash.")]
        CASH,
        ///<summary>
        ///This tender represents the register being opened for a "no sale" event.
        ///</summary>
        [Description("This tender represents the register being opened for a \"no sale\" event.")]
        NO_SALE,
        ///<summary>
        ///A form of tender that does not match any other value.
        ///</summary>
        [Description("A form of tender that does not match any other value.")]
        OTHER,
        ///<summary>
        ///A Square House Account payment.
        ///</summary>
        [Description("A Square House Account payment.")]
        SQUARE_ACCOUNT,
        ///<summary>
        ///A Square gift card.
        ///</summary>
        [Description("A Square gift card.")]
        SQUARE_GIFT_CARD,
        ///<summary>
        ///A credit card processed with a card processor other than Square.
        ///  
        ///This value applies only to merchants in countries where Square does not
        ///yet provide card processing.
        ///</summary>
        [Description("A credit card processed with a card processor other than Square.\n  \nThis value applies only to merchants in countries where Square does not\nyet provide card processing.")]
        THIRD_PARTY_CARD,
        ///<summary>
        ///A payment from a digital wallet, e.g. Cash App.
        ///  
        ///Note: Some "digital wallets", including Google Pay and Apple Pay, facilitate
        ///card payments.  Those payments have the `CARD` type.
        ///</summary>
        [Description("A payment from a digital wallet, e.g. Cash App.\n  \nNote: Some \"digital wallets\", including Google Pay and Apple Pay, facilitate\ncard payments.  Those payments have the `CARD` type.")]
        WALLET,
    }

    public static class OrderTenderTypeStringValues
    {
        public const string BANK_ACCOUNT = @"BANK_ACCOUNT";
        public const string BUY_NOW_PAY_LATER = @"BUY_NOW_PAY_LATER";
        public const string CARD = @"CARD";
        public const string CASH = @"CASH";
        public const string NO_SALE = @"NO_SALE";
        public const string OTHER = @"OTHER";
        public const string SQUARE_ACCOUNT = @"SQUARE_ACCOUNT";
        public const string SQUARE_GIFT_CARD = @"SQUARE_GIFT_CARD";
        public const string THIRD_PARTY_CARD = @"THIRD_PARTY_CARD";
        public const string WALLET = @"WALLET";
    }

    ///<summary>
    ///References to Payments subgraph entities
    ///
    ///Permissions:PAYMENTS_READ
    ///</summary>
    [Description("References to Payments subgraph entities\n\nPermissions:PAYMENTS_READ")]
    public class Payment : GraphQLObject<Payment>
    {
        ///<summary>
        ///Unique ID for the payment.
        ///</summary>
        [Description("Unique ID for the payment.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The amount processed for this payment, not including `tipMoney`.
        ///
        ///The amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents). For more information, see
        ///[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
        ///</summary>
        [Description("The amount processed for this payment, not including `tipMoney`.\n\nThe amount is specified in the smallest denomination of the applicable currency (for example,\nUS dollar amounts are specified in cents). For more information, see\n[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).")]
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
        [Description("The amount the developer is taking as a fee for facilitating the payment on behalf\nof the seller. This amount is specified in the smallest denomination of the applicable currency\n(for example, US dollar amounts are specified in cents). For more information,\nsee [Take Payments and Collect Fees](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees).\n\nThe amount cannot be more than 90% of the `total_money` value.\n\nTo set this field, `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required.\nFor more information, see [Permissions](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees#permissions).")]
        public Money? appFeeMoney { get; set; }

        ///<summary>
        ///Details about the application that took the payment.
        ///</summary>
        [Description("Details about the application that took the payment.")]
        public PaymentApplicationDetails? applicationDetails { get; set; }

        ///<summary>
        ///The initial amount of money approved for this payment.
        ///</summary>
        [Description("The initial amount of money approved for this payment.")]
        public Money? approvedMoney { get; set; }

        ///<summary>
        ///Details about a bank account payment. These details are only populated if the `sourceType` is `BANK_ACCOUNT`.
        ///</summary>
        [Description("Details about a bank account payment. These details are only populated if the `sourceType` is `BANK_ACCOUNT`.")]
        public BankAccountPaymentDetails? bankAccountDetails { get; set; }

        ///<summary>
        ///The buyer's billing address.
        ///</summary>
        [Description("The buyer's billing address.")]
        public Address? billingAddress { get; set; }

        ///<summary>
        ///Details about a Buy Now Pay Later payment. The details are only populated
        ///if the `source_type` is `BUY_NOW_PAY_LATER`. For more information, see
        ///[Afterpay Payments](https://developer.squareup.com/docs/payments-api/take-payments/afterpay-payments).
        ///</summary>
        [Description("Details about a Buy Now Pay Later payment. The details are only populated\nif the `source_type` is `BUY_NOW_PAY_LATER`. For more information, see\n[Afterpay Payments](https://developer.squareup.com/docs/payments-api/take-payments/afterpay-payments).")]
        public BuyNowPayLaterPaymentDetails? buyNowPayLaterDetails { get; set; }

        ///<summary>
        ///The buyer's email address.
        ///</summary>
        [Description("The buyer's email address.")]
        public string? buyerEmailAddress { get; set; }

        ///<summary>
        ///Actions that can be performed on this payment.
        ///</summary>
        [Description("Actions that can be performed on this payment.")]
        [NonNull]
        public IEnumerable<PaymentCapability>? capabilities { get; set; }

        ///<summary>
        ///Details about a card payment. These details are only populated if the `sourceType` is CARD.
        ///</summary>
        [Description("Details about a card payment. These details are only populated if the `sourceType` is CARD.")]
        public CardPaymentDetails? cardDetails { get; set; }

        ///<summary>
        ///Details about a cash payment. These details are only populated if the `sourceType` is `CASH`.
        ///</summary>
        [Description("Details about a cash payment. These details are only populated if the `sourceType` is `CASH`.")]
        public CashPaymentDetails? cashDetails { get; set; }

        ///<summary>
        ///The timestamp of when the payment was created, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp of when the payment was created, in RFC 3339 format.")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///The [Customer](https://developer.squareup.com/reference/square/payments-api/list-payments#type-customer)
        ///ID of the customer associated with the payment.
        ///</summary>
        [Description("The [Customer](https://developer.squareup.com/reference/square/payments-api/list-payments#type-customer)\nID of the customer associated with the payment.")]
        public string? customerId { get; set; }

        ///<summary>
        ///The action to be applied to the payment when the `delay_duration` has elapsed.
        ///</summary>
        [Description("The action to be applied to the payment when the `delay_duration` has elapsed.")]
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
        [Description("The duration of time after the payment's creation when Square automatically applies the\n`delayAction` to the payment. This automatic `delayAction` applies only to payments that\ndon't reach a terminal state (COMPLETED, CANCELED, or FAILED) before the `delayDuration`\ntime period.\n\nThis field is specified as a time duration, in RFC 3339 format.\n\nNotes:\nThis feature is only supported for card payments.\n\nDefault:\n\n  - Card Present payments: \"PT36H\" (36 hours) from the creation time.\n  - Card Not Present payments: \"P7D\" (7 days) from the creation time.")]
        public string? delayDuration { get; set; }

        ///<summary>
        ///The read-only timestamp of when the `delay_action` is automatically applied,
        ///in RFC 3339 format.
        ///
        ///Note that this field is calculated by summing the payment's `delay_duration` and `created_at`
        ///fields. The `created_at` field is generated by Square and might not exactly match the
        ///time on your local machine.
        ///</summary>
        [Description("The read-only timestamp of when the `delay_action` is automatically applied,\nin RFC 3339 format.\n\nNote that this field is calculated by summing the payment's `delay_duration` and `created_at`\nfields. The `created_at` field is generated by Square and might not exactly match the\ntime on your local machine.")]
        public DateTime? delayedUntil { get; set; }

        ///<summary>
        ///Details about the device that took the payment.
        ///</summary>
        [Description("Details about the device that took the payment.")]
        public PaymentDeviceDetails? deviceDetails { get; set; }

        ///<summary>
        ///Details about an external payment. The details are only populated if the `sourceType` is `EXTERNAL`.
        ///</summary>
        [Description("Details about an external payment. The details are only populated if the `sourceType` is `EXTERNAL`.")]
        public ExternalPaymentDetails? externalDetails { get; set; }

        ///<summary>
        ///The ID of the location associated with the payment.
        ///</summary>
        [Description("The ID of the location associated with the payment.")]
        public string? locationId { get; set; }

        ///<summary>
        ///The ID of the merchant associated with the payment.
        ///</summary>
        [Description("The ID of the merchant associated with the payment.")]
        public string? merchantId { get; set; }

        ///<summary>
        ///An optional note to include when creating a payment.
        ///</summary>
        [Description("An optional note to include when creating a payment.")]
        public string? note { get; set; }

        ///<summary>
        ///The ID of the order associated with the payment.
        ///</summary>
        [Description("The ID of the order associated with the payment.")]
        public string? orderId { get; set; }

        ///<summary>
        ///The processing fees and fee adjustments assessed by Square for this payment.
        ///</summary>
        [Description("The processing fees and fee adjustments assessed by Square for this payment.")]
        [NonNull]
        public IEnumerable<PaymentProcessingFee>? processingFees { get; set; }

        ///<summary>
        ///The payment's receipt number.
        ///The field will be missing if a payment is canceled.
        ///</summary>
        [Description("The payment's receipt number.\nThe field will be missing if a payment is canceled.")]
        public string? receiptNumber { get; set; }

        ///<summary>
        ///The URL for the payment's receipt.
        ///The field is only populated for COMPLETED payments.
        ///</summary>
        [Description("The URL for the payment's receipt.\nThe field is only populated for COMPLETED payments.")]
        public string? receiptUrl { get; set; }

        ///<summary>
        ///An optional ID that associates this payment with an entity in another system.
        ///</summary>
        [Description("An optional ID that associates this payment with an entity in another system.")]
        public string? referenceId { get; set; }

        ///<summary>
        ///The total amount of the payment refunded to date.
        ///
        ///This amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents).
        ///</summary>
        [Description("The total amount of the payment refunded to date.\n\nThis amount is specified in the smallest denomination of the applicable currency (for example,\nUS dollar amounts are specified in cents).")]
        public Money? refundedMoney { get; set; }

        ///<summary>
        ///The refunds for this payment.
        ///</summary>
        [Description("The refunds for this payment.")]
        public PaymentRefundConnection? refunds { get; set; }

        ///<summary>
        ///Provides information about the risk associated with this payment, as determined by Square.
        ///This field will be present for payments to sellers that have opted in to receive risk
        ///evaluations.
        ///</summary>
        [Description("Provides information about the risk associated with this payment, as determined by Square.\nThis field will be present for payments to sellers that have opted in to receive risk\nevaluations.")]
        public PaymentRiskEvaluation? riskEvaluation { get; set; }

        ///<summary>
        ///The buyer's shipping address.
        ///</summary>
        [Description("The buyer's shipping address.")]
        public Address? shippingAddress { get; set; }

        ///<summary>
        ///The source type for the payment.
        ///
        ///For information about these payment source types,
        ///see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
        ///</summary>
        [Description("The source type for the payment.\n\nFor information about these payment source types,\nsee [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).")]
        public PaymentSourceType? sourceType { get; set; }

        ///<summary>
        ///Additional payment information that gets added on the customer's card statement
        ///as part of the statement description.
        ///
        ///Note that the `statementDescriptionIdentifier` may get truncated on the statement description
        ///to fit the required information including the Square identifier (SQ *) and name of the
        ///seller taking the payment.
        ///</summary>
        [Description("Additional payment information that gets added on the customer's card statement\nas part of the statement description.\n\nNote that the `statementDescriptionIdentifier` may get truncated on the statement description\nto fit the required information including the Square identifier (SQ *) and name of the\nseller taking the payment.")]
        public string? statementDescriptionIdentifier { get; set; }

        ///<summary>
        ///Indicates whether the payment is APPROVED, PENDING, COMPLETED, CANCELED, or FAILED.
        ///</summary>
        [Description("Indicates whether the payment is APPROVED, PENDING, COMPLETED, CANCELED, or FAILED.")]
        public PaymentStatus? status { get; set; }

        ///<summary>
        ///An optional ID of the TeamMember associated with taking the payment.
        ///</summary>
        [Description("An optional ID of the TeamMember associated with taking the payment.")]
        public string? teamMemberId { get; set; }

        ///<summary>
        ///The amount designated as a tip.
        ///
        ///This amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents). For more information, see
        ///[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
        ///</summary>
        [Description("The amount designated as a tip.\n\nThis amount is specified in the smallest denomination of the applicable currency (for example,\nUS dollar amounts are specified in cents). For more information, see\n[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).")]
        public Money? tipMoney { get; set; }

        ///<summary>
        ///The total amount for the payment, including `amountMoney` and `tipMoney`.
        ///
        ///This amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents). For more information, see
        ///[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
        ///</summary>
        [Description("The total amount for the payment, including `amountMoney` and `tipMoney`.\n\nThis amount is specified in the smallest denomination of the applicable currency (for example,\nUS dollar amounts are specified in cents). For more information, see\n[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).")]
        public Money? totalMoney { get; set; }

        ///<summary>
        ///The timestamp of when the payment was last updated, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp of when the payment was last updated, in RFC 3339 format.")]
        public DateTime? updatedAt { get; set; }

        ///<summary>
        ///Details about an wallet payment. The details are only populated if the `sourceType` is `WALLET`.
        ///</summary>
        [Description("Details about an wallet payment. The details are only populated if the `sourceType` is `WALLET`.")]
        public DigitalWalletPaymentDetails? walletDetails { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Details about the application that took the payment.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nDetails about the application that took the payment.")]
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
        [Description("The Square ID assigned to the application used to take the payment.\nApplication developers can use this information to identify payments that\ntheir application processed.\nFor example, if a developer uses a custom application to process payments,\nthis field contains the application ID from the Developer Dashboard.\nIf a seller uses a [Square App Marketplace](https://developer.squareup.com/docs/app-marketplace)\napplication to process payments, the field contains the corresponding application ID.")]
        public string? applicationId { get; set; }

        ///<summary>
        ///The Square product, such as Square Point of Sale (POS), Square Invoices, or Square Virtual Terminal.
        ///</summary>
        [Description("The Square product, such as Square Point of Sale (POS), Square Invoices, or Square Virtual Terminal.")]
        public PaymentApplicationDetailsExternalSquareProduct? squareProduct { get; set; }
    }

    ///<summary>
    ///A list of products to return to external callers.
    ///</summary>
    [Description("A list of products to return to external callers.")]
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

    public static class PaymentApplicationDetailsExternalSquareProductStringValues
    {
        public const string APPOINTMENTS = @"APPOINTMENTS";
        public const string ECOMMERCE_API = @"ECOMMERCE_API";
        public const string INVOICES = @"INVOICES";
        public const string ONLINE_STORE = @"ONLINE_STORE";
        public const string OTHER = @"OTHER";
        public const string RESTAURANTS = @"RESTAURANTS";
        public const string RETAIL = @"RETAIL";
        public const string SQUARE_POS = @"SQUARE_POS";
        public const string TERMINAL_API = @"TERMINAL_API";
        public const string VIRTUAL_TERMINAL = @"VIRTUAL_TERMINAL";
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Represents an application processing fee.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nRepresents an application processing fee.")]
    public class PaymentAppProcessingFee : GraphQLObject<PaymentAppProcessingFee>
    {
        ///<summary>
        ///The exact fee amount assessed based on the payment fee rate.
        ///</summary>
        [Description("The exact fee amount assessed based on the payment fee rate.")]
        public Money? amountMoney { get; set; }

        ///<summary>
        ///The timestamp of when the fee takes effect, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp of when the fee takes effect, in RFC 3339 format.")]
        public DateTime? effectiveAt { get; set; }

        ///<summary>
        ///The platform account token for this payment fee.
        ///For a capture, this is the recipient of funds. For a refund, this is the source of funds.
        ///</summary>
        [Description("The platform account token for this payment fee.\nFor a capture, this is the recipient of funds. For a refund, this is the source of funds.")]
        public string? partyAccountId { get; set; }

        ///<summary>
        ///The price selector IDs of the payment fee being applied.
        ///</summary>
        [Description("The price selector IDs of the payment fee being applied.")]
        [NonNull]
        public IEnumerable<string>? priceSelectors { get; set; }

        ///<summary>
        ///The type of payment fee being applied (for example, `THIRD_PARTY_PAYMENT_FEE` or `THIRD_PARTY_REFUND_FEE`).
        ///</summary>
        [Description("The type of payment fee being applied (for example, `THIRD_PARTY_PAYMENT_FEE` or `THIRD_PARTY_REFUND_FEE`).")]
        public PaymentAppProcessingFeeType? type { get; set; }
    }

    ///<summary>
    ///The type of payment fee being applied.
    ///</summary>
    [Description("The type of payment fee being applied.")]
    public enum PaymentAppProcessingFeeType
    {
        THIRD_PARTY_PAYMENT_FEE,
        THIRD_PARTY_REFUND_FEE,
    }

    public static class PaymentAppProcessingFeeTypeStringValues
    {
        public const string THIRD_PARTY_PAYMENT_FEE = @"THIRD_PARTY_PAYMENT_FEE";
        public const string THIRD_PARTY_REFUND_FEE = @"THIRD_PARTY_REFUND_FEE";
    }

    ///<summary>
    ///Actions that can be performed on a payment.
    ///</summary>
    [Description("Actions that can be performed on a payment.")]
    public enum PaymentCapability
    {
        ///<summary>
        ///The payment amount can be edited down.
        ///</summary>
        [Description("The payment amount can be edited down.")]
        EDIT_AMOUNT_DOWN,
        ///<summary>
        ///The payment amount can be edited up.
        ///</summary>
        [Description("The payment amount can be edited up.")]
        EDIT_AMOUNT_UP,
        ///<summary>
        ///The delay action can be edited.
        ///</summary>
        [Description("The delay action can be edited.")]
        EDIT_DELAY_ACTION,
        ///<summary>
        ///The tip amount can be edited down.
        ///</summary>
        [Description("The tip amount can be edited down.")]
        EDIT_TIP_AMOUNT_DOWN,
        ///<summary>
        ///The tip amount can be edited up.
        ///</summary>
        [Description("The tip amount can be edited up.")]
        EDIT_TIP_AMOUNT_UP,
    }

    public static class PaymentCapabilityStringValues
    {
        public const string EDIT_AMOUNT_DOWN = @"EDIT_AMOUNT_DOWN";
        public const string EDIT_AMOUNT_UP = @"EDIT_AMOUNT_UP";
        public const string EDIT_DELAY_ACTION = @"EDIT_DELAY_ACTION";
        public const string EDIT_TIP_AMOUNT_DOWN = @"EDIT_TIP_AMOUNT_DOWN";
        public const string EDIT_TIP_AMOUNT_UP = @"EDIT_TIP_AMOUNT_UP";
    }

    ///<summary>
    ///Represents a paginated collection of `Payment` results.
    ///
    ///See the [Relay GraphQL Cursor Connections
    ///Specification](https://relay.dev/graphql/connections.htm#sec-Connection-Types) for more info.
    ///
    ///Permissions: PAYMENTS_READ.
    ///</summary>
    [Description("Represents a paginated collection of `Payment` results.\n\nSee the [Relay GraphQL Cursor Connections\nSpecification](https://relay.dev/graphql/connections.htm#sec-Connection-Types) for more info.\n\nPermissions: PAYMENTS_READ.")]
    public class PaymentConnection : GraphQLObject<PaymentConnection>, IConnectionWithEdges<PaymentEdge, Payment>
    {
        ///<summary>
        ///Wraps a specific `Payment` to pair it with its pagination cursor.
        ///</summary>
        [Description("Wraps a specific `Payment` to pair it with its pagination cursor.")]
        [NonNull]
        public IEnumerable<PaymentEdge>? edges { get; set; }

        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }

        ///<summary>
        ///The total number of edges available in this connection to paginate over.
        ///</summary>
        [Description("The total number of edges available in this connection to paginate over.")]
        [NonNull]
        public long? totalEdgeCount { get; set; }
    }

    ///<summary>
    ///The action to be applied to the payment when the `delayDuration` has elapsed.
    ///</summary>
    [Description("The action to be applied to the payment when the `delayDuration` has elapsed.")]
    public enum PaymentDelayAction
    {
        CANCEL,
        COMPLETE,
    }

    public static class PaymentDelayActionStringValues
    {
        public const string CANCEL = @"CANCEL";
        public const string COMPLETE = @"COMPLETE";
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Details about the device that took the payment.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nDetails about the device that took the payment.")]
    public class PaymentDeviceDetails : GraphQLObject<PaymentDeviceDetails>
    {
        ///<summary>
        ///Square-issued ID of the device.
        ///</summary>
        [Description("Square-issued ID of the device.")]
        public string? deviceId { get; set; }

        ///<summary>
        ///Square-issued installation ID for the device.
        ///</summary>
        [Description("Square-issued installation ID for the device.")]
        public string? deviceInstallationId { get; set; }

        ///<summary>
        ///The name of the device set by the seller.
        ///</summary>
        [Description("The name of the device set by the seller.")]
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
    [Description("Represents a specific `Payment` in the context of a `PaymentConnection`,\nproviding access to both the `Payment` and a pagination `Cursor`.\n\nSee the [Relay GraphQL Cursor Connections\nSpecification](https://relay.dev/graphql/connections.htm#sec-Edge-Types) for more info.\n\nPermissions: PAYMENTS_READ.")]
    public class PaymentEdge : GraphQLObject<PaymentEdge>, IEdge<Payment>
    {
        ///<summary>
        ///The `Cursor` of this `Payment`. This can be passed in the next query as
        ///a `before` or `after` argument to continue paginating from this `Payment`.
        ///</summary>
        [Description("The `Cursor` of this `Payment`. This can be passed in the next query as\na `before` or `after` argument to continue paginating from this `Payment`.")]
        public string? cursor { get; set; }

        ///<summary>
        ///The `Payment` of this edge.
        ///</summary>
        [Description("The `Payment` of this edge.")]
        public Payment? node { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Represents the Square processing fee.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nRepresents the Square processing fee.")]
    public class PaymentProcessingFee : GraphQLObject<PaymentProcessingFee>
    {
        ///<summary>
        ///The fee amount, which might be negative, that is assessed or adjusted by Square.
        ///
        ///Positive values represent funds being assessed, while negative values represent funds being returned.
        ///</summary>
        [Description("The fee amount, which might be negative, that is assessed or adjusted by Square.\n\nPositive values represent funds being assessed, while negative values represent funds being returned.")]
        public Money? amountMoney { get; set; }

        ///<summary>
        ///The timestamp of when the fee takes effect, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp of when the fee takes effect, in RFC 3339 format.")]
        public string? effectiveAt { get; set; }

        ///<summary>
        ///The type of fee assessed or adjusted.
        ///</summary>
        [Description("The type of fee assessed or adjusted.")]
        public PaymentProcessingFeeType? type { get; set; }
    }

    ///<summary>
    ///The type of fee assessed or adjusted.
    ///</summary>
    [Description("The type of fee assessed or adjusted.")]
    public enum PaymentProcessingFeeType
    {
        ///<summary>
        ///Type used for an adjustment to the initial processing fee.
        ///</summary>
        [Description("Type used for an adjustment to the initial processing fee.")]
        ADJUSTMENT,
        ///<summary>
        ///Type used on the initial processing fee.
        ///</summary>
        [Description("Type used on the initial processing fee.")]
        INITIAL,
    }

    public static class PaymentProcessingFeeTypeStringValues
    {
        public const string ADJUSTMENT = @"ADJUSTMENT";
        public const string INITIAL = @"INITIAL";
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
    [Description("Permissions: PAYMENTS_READ\n\nRepresents a refund of a payment made using Square. Contains information about\nthe original payment and the amount of money refunded.\n\n\nFor more performant queries on this type, please filter on `merchantId` if possible.")]
    public class PaymentRefund : GraphQLObject<PaymentRefund>
    {
        ///<summary>
        ///The amount of money refunded. This amount is specified in the smallest denomination
        ///of the applicable currency (for example, US dollar amounts are specified in cents).
        ///</summary>
        [Description("The amount of money refunded. This amount is specified in the smallest denomination\nof the applicable currency (for example, US dollar amounts are specified in cents).")]
        public Money? amountMoney { get; set; }

        ///<summary>
        ///The amount of money the application developer contributed to help cover the refunded amount.
        ///This amount is specified in the smallest denomination of the applicable currency (for example,
        ///US dollar amounts are specified in cents). For more information, see
        ///[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
        ///</summary>
        [Description("The amount of money the application developer contributed to help cover the refunded amount.\nThis amount is specified in the smallest denomination of the applicable currency (for example,\nUS dollar amounts are specified in cents). For more information, see\n[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).")]
        public Money? appFeeMoney { get; set; }

        ///<summary>
        ///The timestamp of when the refund was created, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp of when the refund was created, in RFC 3339 format.")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///The unique ID for this refund, generated by Square.
        ///</summary>
        [Description("The unique ID for this refund, generated by Square.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The location ID associated with the payment this refund is attached to.
        ///</summary>
        [Description("The location ID associated with the payment this refund is attached to.")]
        public string? locationId { get; set; }

        ///<summary>
        ///The merchant ID associated with the payment this refund is attached to.
        ///</summary>
        [Description("The merchant ID associated with the payment this refund is attached to.")]
        public string? merchantId { get; set; }

        ///<summary>
        ///The ID of the order associated with the refund.
        ///</summary>
        [Description("The ID of the order associated with the refund.")]
        public string? orderId { get; set; }

        ///<summary>
        ///The payment this refund belongs to.
        ///</summary>
        [Description("The payment this refund belongs to.")]
        public Payment? payment { get; set; }

        ///<summary>
        ///The ID of the payment associated with this refund.
        ///</summary>
        [Description("The ID of the payment associated with this refund.")]
        public string? paymentId { get; set; }

        ///<summary>
        ///Processing fees and fee adjustments assessed by Square for this refund.
        ///</summary>
        [Description("Processing fees and fee adjustments assessed by Square for this refund.")]
        [NonNull]
        public IEnumerable<PaymentProcessingFee>? processingFees { get; set; }

        ///<summary>
        ///The reason for the refund.
        ///</summary>
        [Description("The reason for the refund.")]
        public string? reason { get; set; }

        ///<summary>
        ///The refund's status.
        ///</summary>
        [Description("The refund's status.")]
        public PaymentRefundStatus? status { get; set; }

        ///<summary>
        ///An optional ID of the team member associated with taking the payment.
        ///</summary>
        [Description("An optional ID of the team member associated with taking the payment.")]
        public string? teamMemberId { get; set; }

        ///<summary>
        ///The timestamp of when the refund was last updated, in RFC 3339 format.
        ///</summary>
        [Description("The timestamp of when the refund was last updated, in RFC 3339 format.")]
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
    [Description("Represents a paginated collection of `PaymentRefund` results.\n\nSee the [Relay GraphQL Cursor Connections\nSpecification](https://relay.dev/graphql/connections.htm#sec-Connection-Types) for more info.\n\nPermissions: PAYMENTS_READ.")]
    public class PaymentRefundConnection : GraphQLObject<PaymentRefundConnection>, IConnectionWithEdges<PaymentRefundEdge, PaymentRefund>
    {
        ///<summary>
        ///Wraps a specific `PaymentRefund` to pair it with its pagination cursor.
        ///</summary>
        [Description("Wraps a specific `PaymentRefund` to pair it with its pagination cursor.")]
        [NonNull]
        public IEnumerable<PaymentRefundEdge>? edges { get; set; }

        ///<summary>
        ///Provides pagination-related information.
        ///</summary>
        [Description("Provides pagination-related information.")]
        [NonNull]
        public PageInfo? pageInfo { get; set; }

        ///<summary>
        ///The total number of edges available in this connection to paginate over.
        ///</summary>
        [Description("The total number of edges available in this connection to paginate over.")]
        [NonNull]
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
    [Description("Represents a specific `PaymentRefund` in the context of a `PaymentRefundConnection`,\nproviding access to both the `PaymentRefund` and a pagination `Cursor`.\n\nSee the [Relay GraphQL Cursor Connections\nSpecification](https://relay.dev/graphql/connections.htm#sec-Edge-Types) for more info.\n\nPermissions: PAYMENTS_READ.")]
    public class PaymentRefundEdge : GraphQLObject<PaymentRefundEdge>, IEdge<PaymentRefund>
    {
        ///<summary>
        ///The `Cursor` of this `PaymentRefund`. This can be passed in the next query as
        ///a `before` or `after` argument to continue paginating from this `PaymentRefund`.
        ///</summary>
        [Description("The `Cursor` of this `PaymentRefund`. This can be passed in the next query as\na `before` or `after` argument to continue paginating from this `PaymentRefund`.")]
        public string? cursor { get; set; }

        ///<summary>
        ///The `PaymentRefund` of this edge.
        ///</summary>
        [Description("The `PaymentRefund` of this edge.")]
        public PaymentRefund? node { get; set; }
    }

    ///<summary>
    ///Enumerates the ways `PaymentRefund`s can be sorted.
    ///</summary>
    [Description("Enumerates the ways `PaymentRefund`s can be sorted.")]
    public enum PaymentRefundSortOrder
    {
        ///<summary>
        ///Sorts ascending by the `amountMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `amountMoney.amount` field.")]
        amountMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `amountMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `amountMoney.amount` field.")]
        amountMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `amountMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `amountMoney.currency` field.")]
        amountMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `amountMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `amountMoney.currency` field.")]
        amountMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `appFeeMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `appFeeMoney.amount` field.")]
        appFeeMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `appFeeMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `appFeeMoney.amount` field.")]
        appFeeMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `appFeeMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `appFeeMoney.currency` field.")]
        appFeeMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `appFeeMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `appFeeMoney.currency` field.")]
        appFeeMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `createdAt` field.
        ///</summary>
        [Description("Sorts ascending by the `createdAt` field.")]
        createdAt_ASC,
        ///<summary>
        ///Sorts descending by the `createdAt` field.
        ///</summary>
        [Description("Sorts descending by the `createdAt` field.")]
        createdAt_DESC,
        ///<summary>
        ///Sorts ascending by the `id` field.
        ///</summary>
        [Description("Sorts ascending by the `id` field.")]
        id_ASC,
        ///<summary>
        ///Sorts descending by the `id` field.
        ///</summary>
        [Description("Sorts descending by the `id` field.")]
        id_DESC,
        ///<summary>
        ///Sorts ascending by the `locationId` field.
        ///</summary>
        [Description("Sorts ascending by the `locationId` field.")]
        locationId_ASC,
        ///<summary>
        ///Sorts descending by the `locationId` field.
        ///</summary>
        [Description("Sorts descending by the `locationId` field.")]
        locationId_DESC,
        ///<summary>
        ///Sorts ascending by the `merchantId` field.
        ///</summary>
        [Description("Sorts ascending by the `merchantId` field.")]
        merchantId_ASC,
        ///<summary>
        ///Sorts descending by the `merchantId` field.
        ///</summary>
        [Description("Sorts descending by the `merchantId` field.")]
        merchantId_DESC,
        ///<summary>
        ///Sorts ascending by the `orderId` field.
        ///</summary>
        [Description("Sorts ascending by the `orderId` field.")]
        orderId_ASC,
        ///<summary>
        ///Sorts descending by the `orderId` field.
        ///</summary>
        [Description("Sorts descending by the `orderId` field.")]
        orderId_DESC,
        ///<summary>
        ///Sorts ascending by the `paymentId` field.
        ///</summary>
        [Description("Sorts ascending by the `paymentId` field.")]
        paymentId_ASC,
        ///<summary>
        ///Sorts descending by the `paymentId` field.
        ///</summary>
        [Description("Sorts descending by the `paymentId` field.")]
        paymentId_DESC,
        ///<summary>
        ///Sorts ascending by the `reason` field.
        ///</summary>
        [Description("Sorts ascending by the `reason` field.")]
        reason_ASC,
        ///<summary>
        ///Sorts descending by the `reason` field.
        ///</summary>
        [Description("Sorts descending by the `reason` field.")]
        reason_DESC,
        ///<summary>
        ///Sorts ascending by the `status` field.
        ///</summary>
        [Description("Sorts ascending by the `status` field.")]
        status_ASC,
        ///<summary>
        ///Sorts descending by the `status` field.
        ///</summary>
        [Description("Sorts descending by the `status` field.")]
        status_DESC,
        ///<summary>
        ///Sorts ascending by the `teamMemberId` field.
        ///</summary>
        [Description("Sorts ascending by the `teamMemberId` field.")]
        teamMemberId_ASC,
        ///<summary>
        ///Sorts descending by the `teamMemberId` field.
        ///</summary>
        [Description("Sorts descending by the `teamMemberId` field.")]
        teamMemberId_DESC,
        ///<summary>
        ///Sorts ascending by the `updatedAt` field.
        ///</summary>
        [Description("Sorts ascending by the `updatedAt` field.")]
        updatedAt_ASC,
        ///<summary>
        ///Sorts descending by the `updatedAt` field.
        ///</summary>
        [Description("Sorts descending by the `updatedAt` field.")]
        updatedAt_DESC,
    }

    public static class PaymentRefundSortOrderStringValues
    {
        public const string amountMoney_amount_ASC = @"amountMoney_amount_ASC";
        public const string amountMoney_amount_DESC = @"amountMoney_amount_DESC";
        public const string amountMoney_currency_ASC = @"amountMoney_currency_ASC";
        public const string amountMoney_currency_DESC = @"amountMoney_currency_DESC";
        public const string appFeeMoney_amount_ASC = @"appFeeMoney_amount_ASC";
        public const string appFeeMoney_amount_DESC = @"appFeeMoney_amount_DESC";
        public const string appFeeMoney_currency_ASC = @"appFeeMoney_currency_ASC";
        public const string appFeeMoney_currency_DESC = @"appFeeMoney_currency_DESC";
        public const string createdAt_ASC = @"createdAt_ASC";
        public const string createdAt_DESC = @"createdAt_DESC";
        public const string id_ASC = @"id_ASC";
        public const string id_DESC = @"id_DESC";
        public const string locationId_ASC = @"locationId_ASC";
        public const string locationId_DESC = @"locationId_DESC";
        public const string merchantId_ASC = @"merchantId_ASC";
        public const string merchantId_DESC = @"merchantId_DESC";
        public const string orderId_ASC = @"orderId_ASC";
        public const string orderId_DESC = @"orderId_DESC";
        public const string paymentId_ASC = @"paymentId_ASC";
        public const string paymentId_DESC = @"paymentId_DESC";
        public const string reason_ASC = @"reason_ASC";
        public const string reason_DESC = @"reason_DESC";
        public const string status_ASC = @"status_ASC";
        public const string status_DESC = @"status_DESC";
        public const string teamMemberId_ASC = @"teamMemberId_ASC";
        public const string teamMemberId_DESC = @"teamMemberId_DESC";
        public const string updatedAt_ASC = @"updatedAt_ASC";
        public const string updatedAt_DESC = @"updatedAt_DESC";
    }

    ///<summary>
    ///Indicates the current status of a `PaymentRefund` object.
    ///</summary>
    [Description("Indicates the current status of a `PaymentRefund` object.")]
    public enum PaymentRefundStatus
    {
        ///<summary>
        ///Successfully completed.
        ///</summary>
        [Description("Successfully completed.")]
        COMPLETED,
        ///<summary>
        ///An error occurred.
        ///</summary>
        [Description("An error occurred.")]
        FAILED,
        ///<summary>
        ///Awaiting approval.
        ///</summary>
        [Description("Awaiting approval.")]
        PENDING,
        ///<summary>
        ///The refund was rejected.
        ///</summary>
        [Description("The refund was rejected.")]
        REJECTED,
    }

    public static class PaymentRefundStatusStringValues
    {
        public const string COMPLETED = @"COMPLETED";
        public const string FAILED = @"FAILED";
        public const string PENDING = @"PENDING";
        public const string REJECTED = @"REJECTED";
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
    [Description("Permissions: PAYMENTS_READ\n\nRepresents fraud risk information for the associated payment.\n\nWhen you take a payment through Square's Payments API (using the `CreatePayment`\nendpoint), Square evaluates it and assigns a risk level to the payment. Sellers\ncan use this information to determine the course of action (for example,\nprovide the goods/services or refund the payment).")]
    public class PaymentRiskEvaluation : GraphQLObject<PaymentRiskEvaluation>
    {
        ///<summary>
        ///The timestamp when payment risk was evaluated, in RFC3339 format.
        ///</summary>
        [Description("The timestamp when payment risk was evaluated, in RFC3339 format.")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///The risk level associated with the payment.
        ///</summary>
        [Description("The risk level associated with the payment.")]
        public PaymentRiskEvaluationRiskLevel? riskLevel { get; set; }
    }

    ///<summary>
    ///Represents a risk level produced by evaluating a payment.
    ///</summary>
    [Description("Represents a risk level produced by evaluating a payment.")]
    public enum PaymentRiskEvaluationRiskLevel
    {
        ///<summary>
        ///Indicates significantly elevated risk level with the payment.
        ///</summary>
        [Description("Indicates significantly elevated risk level with the payment.")]
        HIGH,
        ///<summary>
        ///Indicates elevated risk level associated with the payment.
        ///</summary>
        [Description("Indicates elevated risk level associated with the payment.")]
        MODERATE,
        ///<summary>
        ///Indicates payment risk is within the normal range.
        ///</summary>
        [Description("Indicates payment risk is within the normal range.")]
        NORMAL,
        ///<summary>
        ///Indicates Square is still evaluating the payment.
        ///</summary>
        [Description("Indicates Square is still evaluating the payment.")]
        PENDING,
    }

    public static class PaymentRiskEvaluationRiskLevelStringValues
    {
        public const string HIGH = @"HIGH";
        public const string MODERATE = @"MODERATE";
        public const string NORMAL = @"NORMAL";
        public const string PENDING = @"PENDING";
    }

    ///<summary>
    ///Enumerates the ways `Payment`s can be sorted.
    ///</summary>
    [Description("Enumerates the ways `Payment`s can be sorted.")]
    public enum PaymentSortOrder
    {
        ///<summary>
        ///Sorts ascending by the `amountMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `amountMoney.amount` field.")]
        amountMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `amountMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `amountMoney.amount` field.")]
        amountMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `amountMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `amountMoney.currency` field.")]
        amountMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `amountMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `amountMoney.currency` field.")]
        amountMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `appFeeMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `appFeeMoney.amount` field.")]
        appFeeMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `appFeeMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `appFeeMoney.amount` field.")]
        appFeeMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `appFeeMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `appFeeMoney.currency` field.")]
        appFeeMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `appFeeMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `appFeeMoney.currency` field.")]
        appFeeMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `applicationDetails.applicationId` field.
        ///</summary>
        [Description("Sorts ascending by the `applicationDetails.applicationId` field.")]
        applicationDetails_applicationId_ASC,
        ///<summary>
        ///Sorts descending by the `applicationDetails.applicationId` field.
        ///</summary>
        [Description("Sorts descending by the `applicationDetails.applicationId` field.")]
        applicationDetails_applicationId_DESC,
        ///<summary>
        ///Sorts ascending by the `applicationDetails.squareProduct` field.
        ///</summary>
        [Description("Sorts ascending by the `applicationDetails.squareProduct` field.")]
        applicationDetails_squareProduct_ASC,
        ///<summary>
        ///Sorts descending by the `applicationDetails.squareProduct` field.
        ///</summary>
        [Description("Sorts descending by the `applicationDetails.squareProduct` field.")]
        applicationDetails_squareProduct_DESC,
        ///<summary>
        ///Sorts ascending by the `approvedMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `approvedMoney.amount` field.")]
        approvedMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `approvedMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `approvedMoney.amount` field.")]
        approvedMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `approvedMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `approvedMoney.currency` field.")]
        approvedMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `approvedMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `approvedMoney.currency` field.")]
        approvedMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.accountOwnershipType` field.
        ///</summary>
        [Description("Sorts ascending by the `bankAccountDetails.accountOwnershipType` field.")]
        bankAccountDetails_accountOwnershipType_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.accountOwnershipType` field.
        ///</summary>
        [Description("Sorts descending by the `bankAccountDetails.accountOwnershipType` field.")]
        bankAccountDetails_accountOwnershipType_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.bankName` field.
        ///</summary>
        [Description("Sorts ascending by the `bankAccountDetails.bankName` field.")]
        bankAccountDetails_bankName_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.bankName` field.
        ///</summary>
        [Description("Sorts descending by the `bankAccountDetails.bankName` field.")]
        bankAccountDetails_bankName_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.country` field.
        ///</summary>
        [Description("Sorts ascending by the `bankAccountDetails.country` field.")]
        bankAccountDetails_country_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.country` field.
        ///</summary>
        [Description("Sorts descending by the `bankAccountDetails.country` field.")]
        bankAccountDetails_country_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.fingerprint` field.
        ///</summary>
        [Description("Sorts ascending by the `bankAccountDetails.fingerprint` field.")]
        bankAccountDetails_fingerprint_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.fingerprint` field.
        ///</summary>
        [Description("Sorts descending by the `bankAccountDetails.fingerprint` field.")]
        bankAccountDetails_fingerprint_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.statementDescription` field.
        ///</summary>
        [Description("Sorts ascending by the `bankAccountDetails.statementDescription` field.")]
        bankAccountDetails_statementDescription_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.statementDescription` field.
        ///</summary>
        [Description("Sorts descending by the `bankAccountDetails.statementDescription` field.")]
        bankAccountDetails_statementDescription_DESC,
        ///<summary>
        ///Sorts ascending by the `bankAccountDetails.transferType` field.
        ///</summary>
        [Description("Sorts ascending by the `bankAccountDetails.transferType` field.")]
        bankAccountDetails_transferType_ASC,
        ///<summary>
        ///Sorts descending by the `bankAccountDetails.transferType` field.
        ///</summary>
        [Description("Sorts descending by the `bankAccountDetails.transferType` field.")]
        bankAccountDetails_transferType_DESC,
        ///<summary>
        ///Sorts ascending by the `buyNowPayLaterDetails.afterpayDetails.emailAddress` field.
        ///</summary>
        [Description("Sorts ascending by the `buyNowPayLaterDetails.afterpayDetails.emailAddress` field.")]
        buyNowPayLaterDetails_afterpayDetails_emailAddress_ASC,
        ///<summary>
        ///Sorts descending by the `buyNowPayLaterDetails.afterpayDetails.emailAddress` field.
        ///</summary>
        [Description("Sorts descending by the `buyNowPayLaterDetails.afterpayDetails.emailAddress` field.")]
        buyNowPayLaterDetails_afterpayDetails_emailAddress_DESC,
        ///<summary>
        ///Sorts ascending by the `buyNowPayLaterDetails.brand` field.
        ///</summary>
        [Description("Sorts ascending by the `buyNowPayLaterDetails.brand` field.")]
        buyNowPayLaterDetails_brand_ASC,
        ///<summary>
        ///Sorts descending by the `buyNowPayLaterDetails.brand` field.
        ///</summary>
        [Description("Sorts descending by the `buyNowPayLaterDetails.brand` field.")]
        buyNowPayLaterDetails_brand_DESC,
        ///<summary>
        ///Sorts ascending by the `buyNowPayLaterDetails.clearpayDetails.emailAddress` field.
        ///</summary>
        [Description("Sorts ascending by the `buyNowPayLaterDetails.clearpayDetails.emailAddress` field.")]
        buyNowPayLaterDetails_clearpayDetails_emailAddress_ASC,
        ///<summary>
        ///Sorts descending by the `buyNowPayLaterDetails.clearpayDetails.emailAddress` field.
        ///</summary>
        [Description("Sorts descending by the `buyNowPayLaterDetails.clearpayDetails.emailAddress` field.")]
        buyNowPayLaterDetails_clearpayDetails_emailAddress_DESC,
        ///<summary>
        ///Sorts ascending by the `buyerEmailAddress` field.
        ///</summary>
        [Description("Sorts ascending by the `buyerEmailAddress` field.")]
        buyerEmailAddress_ASC,
        ///<summary>
        ///Sorts descending by the `buyerEmailAddress` field.
        ///</summary>
        [Description("Sorts descending by the `buyerEmailAddress` field.")]
        buyerEmailAddress_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.applicationCryptogram` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.applicationCryptogram` field.")]
        cardDetails_applicationCryptogram_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.applicationCryptogram` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.applicationCryptogram` field.")]
        cardDetails_applicationCryptogram_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.applicationIdentifier` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.applicationIdentifier` field.")]
        cardDetails_applicationIdentifier_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.applicationIdentifier` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.applicationIdentifier` field.")]
        cardDetails_applicationIdentifier_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.applicationName` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.applicationName` field.")]
        cardDetails_applicationName_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.applicationName` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.applicationName` field.")]
        cardDetails_applicationName_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.authResultCode` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.authResultCode` field.")]
        cardDetails_authResultCode_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.authResultCode` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.authResultCode` field.")]
        cardDetails_authResultCode_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.avsStatus` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.avsStatus` field.")]
        cardDetails_avsStatus_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.avsStatus` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.avsStatus` field.")]
        cardDetails_avsStatus_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.cardPaymentTimeline.authorizedAt` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.cardPaymentTimeline.authorizedAt` field.")]
        cardDetails_cardPaymentTimeline_authorizedAt_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.cardPaymentTimeline.authorizedAt` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.cardPaymentTimeline.authorizedAt` field.")]
        cardDetails_cardPaymentTimeline_authorizedAt_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.cardPaymentTimeline.capturedAt` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.cardPaymentTimeline.capturedAt` field.")]
        cardDetails_cardPaymentTimeline_capturedAt_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.cardPaymentTimeline.capturedAt` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.cardPaymentTimeline.capturedAt` field.")]
        cardDetails_cardPaymentTimeline_capturedAt_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.cardPaymentTimeline.voidedAt` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.cardPaymentTimeline.voidedAt` field.")]
        cardDetails_cardPaymentTimeline_voidedAt_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.cardPaymentTimeline.voidedAt` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.cardPaymentTimeline.voidedAt` field.")]
        cardDetails_cardPaymentTimeline_voidedAt_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.bin` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.bin` field.")]
        cardDetails_card_bin_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.bin` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.bin` field.")]
        cardDetails_card_bin_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.cardBrand` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.cardBrand` field.")]
        cardDetails_card_cardBrand_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.cardBrand` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.cardBrand` field.")]
        cardDetails_card_cardBrand_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.cardCoBrand` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.cardCoBrand` field.")]
        cardDetails_card_cardCoBrand_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.cardCoBrand` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.cardCoBrand` field.")]
        cardDetails_card_cardCoBrand_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.cardType` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.cardType` field.")]
        cardDetails_card_cardType_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.cardType` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.cardType` field.")]
        cardDetails_card_cardType_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.cardholderName` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.cardholderName` field.")]
        cardDetails_card_cardholderName_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.cardholderName` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.cardholderName` field.")]
        cardDetails_card_cardholderName_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.expMonth` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.expMonth` field.")]
        cardDetails_card_expMonth_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.expMonth` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.expMonth` field.")]
        cardDetails_card_expMonth_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.expYear` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.expYear` field.")]
        cardDetails_card_expYear_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.expYear` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.expYear` field.")]
        cardDetails_card_expYear_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.fingerprint` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.fingerprint` field.")]
        cardDetails_card_fingerprint_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.fingerprint` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.fingerprint` field.")]
        cardDetails_card_fingerprint_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.last4` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.last4` field.")]
        cardDetails_card_last4_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.last4` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.last4` field.")]
        cardDetails_card_last4_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.card.prepaidType` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.card.prepaidType` field.")]
        cardDetails_card_prepaidType_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.card.prepaidType` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.card.prepaidType` field.")]
        cardDetails_card_prepaidType_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.cvvStatus` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.cvvStatus` field.")]
        cardDetails_cvvStatus_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.cvvStatus` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.cvvStatus` field.")]
        cardDetails_cvvStatus_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.entryMethod` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.entryMethod` field.")]
        cardDetails_entryMethod_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.entryMethod` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.entryMethod` field.")]
        cardDetails_entryMethod_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.statementDescription` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.statementDescription` field.")]
        cardDetails_statementDescription_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.statementDescription` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.statementDescription` field.")]
        cardDetails_statementDescription_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.status` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.status` field.")]
        cardDetails_status_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.status` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.status` field.")]
        cardDetails_status_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.verificationMethod` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.verificationMethod` field.")]
        cardDetails_verificationMethod_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.verificationMethod` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.verificationMethod` field.")]
        cardDetails_verificationMethod_DESC,
        ///<summary>
        ///Sorts ascending by the `cardDetails.verificationResults` field.
        ///</summary>
        [Description("Sorts ascending by the `cardDetails.verificationResults` field.")]
        cardDetails_verificationResults_ASC,
        ///<summary>
        ///Sorts descending by the `cardDetails.verificationResults` field.
        ///</summary>
        [Description("Sorts descending by the `cardDetails.verificationResults` field.")]
        cardDetails_verificationResults_DESC,
        ///<summary>
        ///Sorts ascending by the `cashDetails.buyerSuppliedMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `cashDetails.buyerSuppliedMoney.amount` field.")]
        cashDetails_buyerSuppliedMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `cashDetails.buyerSuppliedMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `cashDetails.buyerSuppliedMoney.amount` field.")]
        cashDetails_buyerSuppliedMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `cashDetails.buyerSuppliedMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `cashDetails.buyerSuppliedMoney.currency` field.")]
        cashDetails_buyerSuppliedMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `cashDetails.buyerSuppliedMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `cashDetails.buyerSuppliedMoney.currency` field.")]
        cashDetails_buyerSuppliedMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `cashDetails.changeBackMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `cashDetails.changeBackMoney.amount` field.")]
        cashDetails_changeBackMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `cashDetails.changeBackMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `cashDetails.changeBackMoney.amount` field.")]
        cashDetails_changeBackMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `cashDetails.changeBackMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `cashDetails.changeBackMoney.currency` field.")]
        cashDetails_changeBackMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `cashDetails.changeBackMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `cashDetails.changeBackMoney.currency` field.")]
        cashDetails_changeBackMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `createdAt` field.
        ///</summary>
        [Description("Sorts ascending by the `createdAt` field.")]
        createdAt_ASC,
        ///<summary>
        ///Sorts descending by the `createdAt` field.
        ///</summary>
        [Description("Sorts descending by the `createdAt` field.")]
        createdAt_DESC,
        ///<summary>
        ///Sorts ascending by the `customerId` field.
        ///</summary>
        [Description("Sorts ascending by the `customerId` field.")]
        customerId_ASC,
        ///<summary>
        ///Sorts descending by the `customerId` field.
        ///</summary>
        [Description("Sorts descending by the `customerId` field.")]
        customerId_DESC,
        ///<summary>
        ///Sorts ascending by the `delayAction` field.
        ///</summary>
        [Description("Sorts ascending by the `delayAction` field.")]
        delayAction_ASC,
        ///<summary>
        ///Sorts descending by the `delayAction` field.
        ///</summary>
        [Description("Sorts descending by the `delayAction` field.")]
        delayAction_DESC,
        ///<summary>
        ///Sorts ascending by the `delayDuration` field.
        ///</summary>
        [Description("Sorts ascending by the `delayDuration` field.")]
        delayDuration_ASC,
        ///<summary>
        ///Sorts descending by the `delayDuration` field.
        ///</summary>
        [Description("Sorts descending by the `delayDuration` field.")]
        delayDuration_DESC,
        ///<summary>
        ///Sorts ascending by the `delayedUntil` field.
        ///</summary>
        [Description("Sorts ascending by the `delayedUntil` field.")]
        delayedUntil_ASC,
        ///<summary>
        ///Sorts descending by the `delayedUntil` field.
        ///</summary>
        [Description("Sorts descending by the `delayedUntil` field.")]
        delayedUntil_DESC,
        ///<summary>
        ///Sorts ascending by the `deviceDetails.deviceId` field.
        ///</summary>
        [Description("Sorts ascending by the `deviceDetails.deviceId` field.")]
        deviceDetails_deviceId_ASC,
        ///<summary>
        ///Sorts descending by the `deviceDetails.deviceId` field.
        ///</summary>
        [Description("Sorts descending by the `deviceDetails.deviceId` field.")]
        deviceDetails_deviceId_DESC,
        ///<summary>
        ///Sorts ascending by the `deviceDetails.deviceInstallationId` field.
        ///</summary>
        [Description("Sorts ascending by the `deviceDetails.deviceInstallationId` field.")]
        deviceDetails_deviceInstallationId_ASC,
        ///<summary>
        ///Sorts descending by the `deviceDetails.deviceInstallationId` field.
        ///</summary>
        [Description("Sorts descending by the `deviceDetails.deviceInstallationId` field.")]
        deviceDetails_deviceInstallationId_DESC,
        ///<summary>
        ///Sorts ascending by the `deviceDetails.deviceName` field.
        ///</summary>
        [Description("Sorts ascending by the `deviceDetails.deviceName` field.")]
        deviceDetails_deviceName_ASC,
        ///<summary>
        ///Sorts descending by the `deviceDetails.deviceName` field.
        ///</summary>
        [Description("Sorts descending by the `deviceDetails.deviceName` field.")]
        deviceDetails_deviceName_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.sourceFeeMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `externalDetails.sourceFeeMoney.amount` field.")]
        externalDetails_sourceFeeMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.sourceFeeMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `externalDetails.sourceFeeMoney.amount` field.")]
        externalDetails_sourceFeeMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.sourceFeeMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `externalDetails.sourceFeeMoney.currency` field.")]
        externalDetails_sourceFeeMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.sourceFeeMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `externalDetails.sourceFeeMoney.currency` field.")]
        externalDetails_sourceFeeMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.sourceId` field.
        ///</summary>
        [Description("Sorts ascending by the `externalDetails.sourceId` field.")]
        externalDetails_sourceId_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.sourceId` field.
        ///</summary>
        [Description("Sorts descending by the `externalDetails.sourceId` field.")]
        externalDetails_sourceId_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.source` field.
        ///</summary>
        [Description("Sorts ascending by the `externalDetails.source` field.")]
        externalDetails_source_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.source` field.
        ///</summary>
        [Description("Sorts descending by the `externalDetails.source` field.")]
        externalDetails_source_DESC,
        ///<summary>
        ///Sorts ascending by the `externalDetails.type` field.
        ///</summary>
        [Description("Sorts ascending by the `externalDetails.type` field.")]
        externalDetails_type_ASC,
        ///<summary>
        ///Sorts descending by the `externalDetails.type` field.
        ///</summary>
        [Description("Sorts descending by the `externalDetails.type` field.")]
        externalDetails_type_DESC,
        ///<summary>
        ///Sorts ascending by the `id` field.
        ///</summary>
        [Description("Sorts ascending by the `id` field.")]
        id_ASC,
        ///<summary>
        ///Sorts descending by the `id` field.
        ///</summary>
        [Description("Sorts descending by the `id` field.")]
        id_DESC,
        ///<summary>
        ///Sorts ascending by the `locationId` field.
        ///</summary>
        [Description("Sorts ascending by the `locationId` field.")]
        locationId_ASC,
        ///<summary>
        ///Sorts descending by the `locationId` field.
        ///</summary>
        [Description("Sorts descending by the `locationId` field.")]
        locationId_DESC,
        ///<summary>
        ///Sorts ascending by the `merchantId` field.
        ///</summary>
        [Description("Sorts ascending by the `merchantId` field.")]
        merchantId_ASC,
        ///<summary>
        ///Sorts descending by the `merchantId` field.
        ///</summary>
        [Description("Sorts descending by the `merchantId` field.")]
        merchantId_DESC,
        ///<summary>
        ///Sorts ascending by the `note` field.
        ///</summary>
        [Description("Sorts ascending by the `note` field.")]
        note_ASC,
        ///<summary>
        ///Sorts descending by the `note` field.
        ///</summary>
        [Description("Sorts descending by the `note` field.")]
        note_DESC,
        ///<summary>
        ///Sorts ascending by the `orderId` field.
        ///</summary>
        [Description("Sorts ascending by the `orderId` field.")]
        orderId_ASC,
        ///<summary>
        ///Sorts descending by the `orderId` field.
        ///</summary>
        [Description("Sorts descending by the `orderId` field.")]
        orderId_DESC,
        ///<summary>
        ///Sorts ascending by the `receiptNumber` field.
        ///</summary>
        [Description("Sorts ascending by the `receiptNumber` field.")]
        receiptNumber_ASC,
        ///<summary>
        ///Sorts descending by the `receiptNumber` field.
        ///</summary>
        [Description("Sorts descending by the `receiptNumber` field.")]
        receiptNumber_DESC,
        ///<summary>
        ///Sorts ascending by the `receiptUrl` field.
        ///</summary>
        [Description("Sorts ascending by the `receiptUrl` field.")]
        receiptUrl_ASC,
        ///<summary>
        ///Sorts descending by the `receiptUrl` field.
        ///</summary>
        [Description("Sorts descending by the `receiptUrl` field.")]
        receiptUrl_DESC,
        ///<summary>
        ///Sorts ascending by the `referenceId` field.
        ///</summary>
        [Description("Sorts ascending by the `referenceId` field.")]
        referenceId_ASC,
        ///<summary>
        ///Sorts descending by the `referenceId` field.
        ///</summary>
        [Description("Sorts descending by the `referenceId` field.")]
        referenceId_DESC,
        ///<summary>
        ///Sorts ascending by the `refundedMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `refundedMoney.amount` field.")]
        refundedMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `refundedMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `refundedMoney.amount` field.")]
        refundedMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `refundedMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `refundedMoney.currency` field.")]
        refundedMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `refundedMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `refundedMoney.currency` field.")]
        refundedMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `riskEvaluation.createdAt` field.
        ///</summary>
        [Description("Sorts ascending by the `riskEvaluation.createdAt` field.")]
        riskEvaluation_createdAt_ASC,
        ///<summary>
        ///Sorts descending by the `riskEvaluation.createdAt` field.
        ///</summary>
        [Description("Sorts descending by the `riskEvaluation.createdAt` field.")]
        riskEvaluation_createdAt_DESC,
        ///<summary>
        ///Sorts ascending by the `riskEvaluation.riskLevel` field.
        ///</summary>
        [Description("Sorts ascending by the `riskEvaluation.riskLevel` field.")]
        riskEvaluation_riskLevel_ASC,
        ///<summary>
        ///Sorts descending by the `riskEvaluation.riskLevel` field.
        ///</summary>
        [Description("Sorts descending by the `riskEvaluation.riskLevel` field.")]
        riskEvaluation_riskLevel_DESC,
        ///<summary>
        ///Sorts ascending by the `sourceType` field.
        ///</summary>
        [Description("Sorts ascending by the `sourceType` field.")]
        sourceType_ASC,
        ///<summary>
        ///Sorts descending by the `sourceType` field.
        ///</summary>
        [Description("Sorts descending by the `sourceType` field.")]
        sourceType_DESC,
        ///<summary>
        ///Sorts ascending by the `statementDescriptionIdentifier` field.
        ///</summary>
        [Description("Sorts ascending by the `statementDescriptionIdentifier` field.")]
        statementDescriptionIdentifier_ASC,
        ///<summary>
        ///Sorts descending by the `statementDescriptionIdentifier` field.
        ///</summary>
        [Description("Sorts descending by the `statementDescriptionIdentifier` field.")]
        statementDescriptionIdentifier_DESC,
        ///<summary>
        ///Sorts ascending by the `status` field.
        ///</summary>
        [Description("Sorts ascending by the `status` field.")]
        status_ASC,
        ///<summary>
        ///Sorts descending by the `status` field.
        ///</summary>
        [Description("Sorts descending by the `status` field.")]
        status_DESC,
        ///<summary>
        ///Sorts ascending by the `teamMemberId` field.
        ///</summary>
        [Description("Sorts ascending by the `teamMemberId` field.")]
        teamMemberId_ASC,
        ///<summary>
        ///Sorts descending by the `teamMemberId` field.
        ///</summary>
        [Description("Sorts descending by the `teamMemberId` field.")]
        teamMemberId_DESC,
        ///<summary>
        ///Sorts ascending by the `tipMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `tipMoney.amount` field.")]
        tipMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `tipMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `tipMoney.amount` field.")]
        tipMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `tipMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `tipMoney.currency` field.")]
        tipMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `tipMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `tipMoney.currency` field.")]
        tipMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `totalMoney.amount` field.
        ///</summary>
        [Description("Sorts ascending by the `totalMoney.amount` field.")]
        totalMoney_amount_ASC,
        ///<summary>
        ///Sorts descending by the `totalMoney.amount` field.
        ///</summary>
        [Description("Sorts descending by the `totalMoney.amount` field.")]
        totalMoney_amount_DESC,
        ///<summary>
        ///Sorts ascending by the `totalMoney.currency` field.
        ///</summary>
        [Description("Sorts ascending by the `totalMoney.currency` field.")]
        totalMoney_currency_ASC,
        ///<summary>
        ///Sorts descending by the `totalMoney.currency` field.
        ///</summary>
        [Description("Sorts descending by the `totalMoney.currency` field.")]
        totalMoney_currency_DESC,
        ///<summary>
        ///Sorts ascending by the `updatedAt` field.
        ///</summary>
        [Description("Sorts ascending by the `updatedAt` field.")]
        updatedAt_ASC,
        ///<summary>
        ///Sorts descending by the `updatedAt` field.
        ///</summary>
        [Description("Sorts descending by the `updatedAt` field.")]
        updatedAt_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.brand` field.
        ///</summary>
        [Description("Sorts ascending by the `walletDetails.brand` field.")]
        walletDetails_brand_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.brand` field.
        ///</summary>
        [Description("Sorts descending by the `walletDetails.brand` field.")]
        walletDetails_brand_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.cashAppDetails.buyerCashtag` field.
        ///</summary>
        [Description("Sorts ascending by the `walletDetails.cashAppDetails.buyerCashtag` field.")]
        walletDetails_cashAppDetails_buyerCashtag_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.cashAppDetails.buyerCashtag` field.
        ///</summary>
        [Description("Sorts descending by the `walletDetails.cashAppDetails.buyerCashtag` field.")]
        walletDetails_cashAppDetails_buyerCashtag_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.cashAppDetails.buyerCountryCode` field.
        ///</summary>
        [Description("Sorts ascending by the `walletDetails.cashAppDetails.buyerCountryCode` field.")]
        walletDetails_cashAppDetails_buyerCountryCode_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.cashAppDetails.buyerCountryCode` field.
        ///</summary>
        [Description("Sorts descending by the `walletDetails.cashAppDetails.buyerCountryCode` field.")]
        walletDetails_cashAppDetails_buyerCountryCode_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.cashAppDetails.buyerFullName` field.
        ///</summary>
        [Description("Sorts ascending by the `walletDetails.cashAppDetails.buyerFullName` field.")]
        walletDetails_cashAppDetails_buyerFullName_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.cashAppDetails.buyerFullName` field.
        ///</summary>
        [Description("Sorts descending by the `walletDetails.cashAppDetails.buyerFullName` field.")]
        walletDetails_cashAppDetails_buyerFullName_DESC,
        ///<summary>
        ///Sorts ascending by the `walletDetails.status` field.
        ///</summary>
        [Description("Sorts ascending by the `walletDetails.status` field.")]
        walletDetails_status_ASC,
        ///<summary>
        ///Sorts descending by the `walletDetails.status` field.
        ///</summary>
        [Description("Sorts descending by the `walletDetails.status` field.")]
        walletDetails_status_DESC,
    }

    public static class PaymentSortOrderStringValues
    {
        public const string amountMoney_amount_ASC = @"amountMoney_amount_ASC";
        public const string amountMoney_amount_DESC = @"amountMoney_amount_DESC";
        public const string amountMoney_currency_ASC = @"amountMoney_currency_ASC";
        public const string amountMoney_currency_DESC = @"amountMoney_currency_DESC";
        public const string appFeeMoney_amount_ASC = @"appFeeMoney_amount_ASC";
        public const string appFeeMoney_amount_DESC = @"appFeeMoney_amount_DESC";
        public const string appFeeMoney_currency_ASC = @"appFeeMoney_currency_ASC";
        public const string appFeeMoney_currency_DESC = @"appFeeMoney_currency_DESC";
        public const string applicationDetails_applicationId_ASC = @"applicationDetails_applicationId_ASC";
        public const string applicationDetails_applicationId_DESC = @"applicationDetails_applicationId_DESC";
        public const string applicationDetails_squareProduct_ASC = @"applicationDetails_squareProduct_ASC";
        public const string applicationDetails_squareProduct_DESC = @"applicationDetails_squareProduct_DESC";
        public const string approvedMoney_amount_ASC = @"approvedMoney_amount_ASC";
        public const string approvedMoney_amount_DESC = @"approvedMoney_amount_DESC";
        public const string approvedMoney_currency_ASC = @"approvedMoney_currency_ASC";
        public const string approvedMoney_currency_DESC = @"approvedMoney_currency_DESC";
        public const string bankAccountDetails_accountOwnershipType_ASC = @"bankAccountDetails_accountOwnershipType_ASC";
        public const string bankAccountDetails_accountOwnershipType_DESC = @"bankAccountDetails_accountOwnershipType_DESC";
        public const string bankAccountDetails_bankName_ASC = @"bankAccountDetails_bankName_ASC";
        public const string bankAccountDetails_bankName_DESC = @"bankAccountDetails_bankName_DESC";
        public const string bankAccountDetails_country_ASC = @"bankAccountDetails_country_ASC";
        public const string bankAccountDetails_country_DESC = @"bankAccountDetails_country_DESC";
        public const string bankAccountDetails_fingerprint_ASC = @"bankAccountDetails_fingerprint_ASC";
        public const string bankAccountDetails_fingerprint_DESC = @"bankAccountDetails_fingerprint_DESC";
        public const string bankAccountDetails_statementDescription_ASC = @"bankAccountDetails_statementDescription_ASC";
        public const string bankAccountDetails_statementDescription_DESC = @"bankAccountDetails_statementDescription_DESC";
        public const string bankAccountDetails_transferType_ASC = @"bankAccountDetails_transferType_ASC";
        public const string bankAccountDetails_transferType_DESC = @"bankAccountDetails_transferType_DESC";
        public const string buyNowPayLaterDetails_afterpayDetails_emailAddress_ASC = @"buyNowPayLaterDetails_afterpayDetails_emailAddress_ASC";
        public const string buyNowPayLaterDetails_afterpayDetails_emailAddress_DESC = @"buyNowPayLaterDetails_afterpayDetails_emailAddress_DESC";
        public const string buyNowPayLaterDetails_brand_ASC = @"buyNowPayLaterDetails_brand_ASC";
        public const string buyNowPayLaterDetails_brand_DESC = @"buyNowPayLaterDetails_brand_DESC";
        public const string buyNowPayLaterDetails_clearpayDetails_emailAddress_ASC = @"buyNowPayLaterDetails_clearpayDetails_emailAddress_ASC";
        public const string buyNowPayLaterDetails_clearpayDetails_emailAddress_DESC = @"buyNowPayLaterDetails_clearpayDetails_emailAddress_DESC";
        public const string buyerEmailAddress_ASC = @"buyerEmailAddress_ASC";
        public const string buyerEmailAddress_DESC = @"buyerEmailAddress_DESC";
        public const string cardDetails_applicationCryptogram_ASC = @"cardDetails_applicationCryptogram_ASC";
        public const string cardDetails_applicationCryptogram_DESC = @"cardDetails_applicationCryptogram_DESC";
        public const string cardDetails_applicationIdentifier_ASC = @"cardDetails_applicationIdentifier_ASC";
        public const string cardDetails_applicationIdentifier_DESC = @"cardDetails_applicationIdentifier_DESC";
        public const string cardDetails_applicationName_ASC = @"cardDetails_applicationName_ASC";
        public const string cardDetails_applicationName_DESC = @"cardDetails_applicationName_DESC";
        public const string cardDetails_authResultCode_ASC = @"cardDetails_authResultCode_ASC";
        public const string cardDetails_authResultCode_DESC = @"cardDetails_authResultCode_DESC";
        public const string cardDetails_avsStatus_ASC = @"cardDetails_avsStatus_ASC";
        public const string cardDetails_avsStatus_DESC = @"cardDetails_avsStatus_DESC";
        public const string cardDetails_cardPaymentTimeline_authorizedAt_ASC = @"cardDetails_cardPaymentTimeline_authorizedAt_ASC";
        public const string cardDetails_cardPaymentTimeline_authorizedAt_DESC = @"cardDetails_cardPaymentTimeline_authorizedAt_DESC";
        public const string cardDetails_cardPaymentTimeline_capturedAt_ASC = @"cardDetails_cardPaymentTimeline_capturedAt_ASC";
        public const string cardDetails_cardPaymentTimeline_capturedAt_DESC = @"cardDetails_cardPaymentTimeline_capturedAt_DESC";
        public const string cardDetails_cardPaymentTimeline_voidedAt_ASC = @"cardDetails_cardPaymentTimeline_voidedAt_ASC";
        public const string cardDetails_cardPaymentTimeline_voidedAt_DESC = @"cardDetails_cardPaymentTimeline_voidedAt_DESC";
        public const string cardDetails_card_bin_ASC = @"cardDetails_card_bin_ASC";
        public const string cardDetails_card_bin_DESC = @"cardDetails_card_bin_DESC";
        public const string cardDetails_card_cardBrand_ASC = @"cardDetails_card_cardBrand_ASC";
        public const string cardDetails_card_cardBrand_DESC = @"cardDetails_card_cardBrand_DESC";
        public const string cardDetails_card_cardCoBrand_ASC = @"cardDetails_card_cardCoBrand_ASC";
        public const string cardDetails_card_cardCoBrand_DESC = @"cardDetails_card_cardCoBrand_DESC";
        public const string cardDetails_card_cardType_ASC = @"cardDetails_card_cardType_ASC";
        public const string cardDetails_card_cardType_DESC = @"cardDetails_card_cardType_DESC";
        public const string cardDetails_card_cardholderName_ASC = @"cardDetails_card_cardholderName_ASC";
        public const string cardDetails_card_cardholderName_DESC = @"cardDetails_card_cardholderName_DESC";
        public const string cardDetails_card_expMonth_ASC = @"cardDetails_card_expMonth_ASC";
        public const string cardDetails_card_expMonth_DESC = @"cardDetails_card_expMonth_DESC";
        public const string cardDetails_card_expYear_ASC = @"cardDetails_card_expYear_ASC";
        public const string cardDetails_card_expYear_DESC = @"cardDetails_card_expYear_DESC";
        public const string cardDetails_card_fingerprint_ASC = @"cardDetails_card_fingerprint_ASC";
        public const string cardDetails_card_fingerprint_DESC = @"cardDetails_card_fingerprint_DESC";
        public const string cardDetails_card_last4_ASC = @"cardDetails_card_last4_ASC";
        public const string cardDetails_card_last4_DESC = @"cardDetails_card_last4_DESC";
        public const string cardDetails_card_prepaidType_ASC = @"cardDetails_card_prepaidType_ASC";
        public const string cardDetails_card_prepaidType_DESC = @"cardDetails_card_prepaidType_DESC";
        public const string cardDetails_cvvStatus_ASC = @"cardDetails_cvvStatus_ASC";
        public const string cardDetails_cvvStatus_DESC = @"cardDetails_cvvStatus_DESC";
        public const string cardDetails_entryMethod_ASC = @"cardDetails_entryMethod_ASC";
        public const string cardDetails_entryMethod_DESC = @"cardDetails_entryMethod_DESC";
        public const string cardDetails_statementDescription_ASC = @"cardDetails_statementDescription_ASC";
        public const string cardDetails_statementDescription_DESC = @"cardDetails_statementDescription_DESC";
        public const string cardDetails_status_ASC = @"cardDetails_status_ASC";
        public const string cardDetails_status_DESC = @"cardDetails_status_DESC";
        public const string cardDetails_verificationMethod_ASC = @"cardDetails_verificationMethod_ASC";
        public const string cardDetails_verificationMethod_DESC = @"cardDetails_verificationMethod_DESC";
        public const string cardDetails_verificationResults_ASC = @"cardDetails_verificationResults_ASC";
        public const string cardDetails_verificationResults_DESC = @"cardDetails_verificationResults_DESC";
        public const string cashDetails_buyerSuppliedMoney_amount_ASC = @"cashDetails_buyerSuppliedMoney_amount_ASC";
        public const string cashDetails_buyerSuppliedMoney_amount_DESC = @"cashDetails_buyerSuppliedMoney_amount_DESC";
        public const string cashDetails_buyerSuppliedMoney_currency_ASC = @"cashDetails_buyerSuppliedMoney_currency_ASC";
        public const string cashDetails_buyerSuppliedMoney_currency_DESC = @"cashDetails_buyerSuppliedMoney_currency_DESC";
        public const string cashDetails_changeBackMoney_amount_ASC = @"cashDetails_changeBackMoney_amount_ASC";
        public const string cashDetails_changeBackMoney_amount_DESC = @"cashDetails_changeBackMoney_amount_DESC";
        public const string cashDetails_changeBackMoney_currency_ASC = @"cashDetails_changeBackMoney_currency_ASC";
        public const string cashDetails_changeBackMoney_currency_DESC = @"cashDetails_changeBackMoney_currency_DESC";
        public const string createdAt_ASC = @"createdAt_ASC";
        public const string createdAt_DESC = @"createdAt_DESC";
        public const string customerId_ASC = @"customerId_ASC";
        public const string customerId_DESC = @"customerId_DESC";
        public const string delayAction_ASC = @"delayAction_ASC";
        public const string delayAction_DESC = @"delayAction_DESC";
        public const string delayDuration_ASC = @"delayDuration_ASC";
        public const string delayDuration_DESC = @"delayDuration_DESC";
        public const string delayedUntil_ASC = @"delayedUntil_ASC";
        public const string delayedUntil_DESC = @"delayedUntil_DESC";
        public const string deviceDetails_deviceId_ASC = @"deviceDetails_deviceId_ASC";
        public const string deviceDetails_deviceId_DESC = @"deviceDetails_deviceId_DESC";
        public const string deviceDetails_deviceInstallationId_ASC = @"deviceDetails_deviceInstallationId_ASC";
        public const string deviceDetails_deviceInstallationId_DESC = @"deviceDetails_deviceInstallationId_DESC";
        public const string deviceDetails_deviceName_ASC = @"deviceDetails_deviceName_ASC";
        public const string deviceDetails_deviceName_DESC = @"deviceDetails_deviceName_DESC";
        public const string externalDetails_sourceFeeMoney_amount_ASC = @"externalDetails_sourceFeeMoney_amount_ASC";
        public const string externalDetails_sourceFeeMoney_amount_DESC = @"externalDetails_sourceFeeMoney_amount_DESC";
        public const string externalDetails_sourceFeeMoney_currency_ASC = @"externalDetails_sourceFeeMoney_currency_ASC";
        public const string externalDetails_sourceFeeMoney_currency_DESC = @"externalDetails_sourceFeeMoney_currency_DESC";
        public const string externalDetails_sourceId_ASC = @"externalDetails_sourceId_ASC";
        public const string externalDetails_sourceId_DESC = @"externalDetails_sourceId_DESC";
        public const string externalDetails_source_ASC = @"externalDetails_source_ASC";
        public const string externalDetails_source_DESC = @"externalDetails_source_DESC";
        public const string externalDetails_type_ASC = @"externalDetails_type_ASC";
        public const string externalDetails_type_DESC = @"externalDetails_type_DESC";
        public const string id_ASC = @"id_ASC";
        public const string id_DESC = @"id_DESC";
        public const string locationId_ASC = @"locationId_ASC";
        public const string locationId_DESC = @"locationId_DESC";
        public const string merchantId_ASC = @"merchantId_ASC";
        public const string merchantId_DESC = @"merchantId_DESC";
        public const string note_ASC = @"note_ASC";
        public const string note_DESC = @"note_DESC";
        public const string orderId_ASC = @"orderId_ASC";
        public const string orderId_DESC = @"orderId_DESC";
        public const string receiptNumber_ASC = @"receiptNumber_ASC";
        public const string receiptNumber_DESC = @"receiptNumber_DESC";
        public const string receiptUrl_ASC = @"receiptUrl_ASC";
        public const string receiptUrl_DESC = @"receiptUrl_DESC";
        public const string referenceId_ASC = @"referenceId_ASC";
        public const string referenceId_DESC = @"referenceId_DESC";
        public const string refundedMoney_amount_ASC = @"refundedMoney_amount_ASC";
        public const string refundedMoney_amount_DESC = @"refundedMoney_amount_DESC";
        public const string refundedMoney_currency_ASC = @"refundedMoney_currency_ASC";
        public const string refundedMoney_currency_DESC = @"refundedMoney_currency_DESC";
        public const string riskEvaluation_createdAt_ASC = @"riskEvaluation_createdAt_ASC";
        public const string riskEvaluation_createdAt_DESC = @"riskEvaluation_createdAt_DESC";
        public const string riskEvaluation_riskLevel_ASC = @"riskEvaluation_riskLevel_ASC";
        public const string riskEvaluation_riskLevel_DESC = @"riskEvaluation_riskLevel_DESC";
        public const string sourceType_ASC = @"sourceType_ASC";
        public const string sourceType_DESC = @"sourceType_DESC";
        public const string statementDescriptionIdentifier_ASC = @"statementDescriptionIdentifier_ASC";
        public const string statementDescriptionIdentifier_DESC = @"statementDescriptionIdentifier_DESC";
        public const string status_ASC = @"status_ASC";
        public const string status_DESC = @"status_DESC";
        public const string teamMemberId_ASC = @"teamMemberId_ASC";
        public const string teamMemberId_DESC = @"teamMemberId_DESC";
        public const string tipMoney_amount_ASC = @"tipMoney_amount_ASC";
        public const string tipMoney_amount_DESC = @"tipMoney_amount_DESC";
        public const string tipMoney_currency_ASC = @"tipMoney_currency_ASC";
        public const string tipMoney_currency_DESC = @"tipMoney_currency_DESC";
        public const string totalMoney_amount_ASC = @"totalMoney_amount_ASC";
        public const string totalMoney_amount_DESC = @"totalMoney_amount_DESC";
        public const string totalMoney_currency_ASC = @"totalMoney_currency_ASC";
        public const string totalMoney_currency_DESC = @"totalMoney_currency_DESC";
        public const string updatedAt_ASC = @"updatedAt_ASC";
        public const string updatedAt_DESC = @"updatedAt_DESC";
        public const string walletDetails_brand_ASC = @"walletDetails_brand_ASC";
        public const string walletDetails_brand_DESC = @"walletDetails_brand_DESC";
        public const string walletDetails_cashAppDetails_buyerCashtag_ASC = @"walletDetails_cashAppDetails_buyerCashtag_ASC";
        public const string walletDetails_cashAppDetails_buyerCashtag_DESC = @"walletDetails_cashAppDetails_buyerCashtag_DESC";
        public const string walletDetails_cashAppDetails_buyerCountryCode_ASC = @"walletDetails_cashAppDetails_buyerCountryCode_ASC";
        public const string walletDetails_cashAppDetails_buyerCountryCode_DESC = @"walletDetails_cashAppDetails_buyerCountryCode_DESC";
        public const string walletDetails_cashAppDetails_buyerFullName_ASC = @"walletDetails_cashAppDetails_buyerFullName_ASC";
        public const string walletDetails_cashAppDetails_buyerFullName_DESC = @"walletDetails_cashAppDetails_buyerFullName_DESC";
        public const string walletDetails_status_ASC = @"walletDetails_status_ASC";
        public const string walletDetails_status_DESC = @"walletDetails_status_DESC";
    }

    ///<summary>
    ///The source type for a payment.
    ///
    ///For information about these payment source types,
    ///see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
    ///</summary>
    [Description("The source type for a payment.\n\nFor information about these payment source types,\nsee [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).")]
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

    public static class PaymentSourceTypeStringValues
    {
        public const string BANK_ACCOUNT = @"BANK_ACCOUNT";
        public const string BUY_NOW_PAY_LATER = @"BUY_NOW_PAY_LATER";
        public const string CARD = @"CARD";
        public const string CASH = @"CASH";
        public const string EXTERNAL = @"EXTERNAL";
        public const string SQUARE_ACCOUNT = @"SQUARE_ACCOUNT";
        public const string WALLET = @"WALLET";
    }

    ///<summary>
    ///Indicates the current status of a `Payment` object.
    ///</summary>
    [Description("Indicates the current status of a `Payment` object.")]
    public enum PaymentStatus
    {
        APPROVED,
        CANCELED,
        COMPLETED,
        FAILED,
        PENDING,
    }

    public static class PaymentStatusStringValues
    {
        public const string APPROVED = @"APPROVED";
        public const string CANCELED = @"CANCELED";
        public const string COMPLETED = @"COMPLETED";
        public const string FAILED = @"FAILED";
        public const string PENDING = @"PENDING";
    }

    ///<summary>
    ///Indicates the Square product used to generate a change.
    ///</summary>
    [Description("Indicates the Square product used to generate a change.")]
    public enum Product
    {
        ///<summary>
        ///Square Point of Sale application.
        ///</summary>
        [Description("Square Point of Sale application.")]
        SQUARE_POS,
        ///<summary>
        ///Square Connect APIs (for example, Orders API or Checkout API).
        ///</summary>
        [Description("Square Connect APIs (for example, Orders API or Checkout API).")]
        EXTERNAL_API,
        ///<summary>
        ///A Square subscription (various products).
        ///</summary>
        [Description("A Square subscription (various products).")]
        BILLING,
        ///<summary>
        ///Square Appointments.
        ///</summary>
        [Description("Square Appointments.")]
        APPOINTMENTS,
        ///<summary>
        ///Square Invoices.
        ///</summary>
        [Description("Square Invoices.")]
        INVOICES,
        ///<summary>
        ///Square Online Store.
        ///</summary>
        [Description("Square Online Store.")]
        ONLINE_STORE,
        ///<summary>
        ///Square Payroll.
        ///</summary>
        [Description("Square Payroll.")]
        PAYROLL,
        ///<summary>
        ///Square Dashboard.
        ///</summary>
        [Description("Square Dashboard.")]
        DASHBOARD,
        ///<summary>
        ///Item Library Import.
        ///</summary>
        [Description("Item Library Import.")]
        ITEM_LIBRARY_IMPORT,
        ///<summary>
        ///A Square product that does not match any other value.
        ///</summary>
        [Description("A Square product that does not match any other value.")]
        OTHER,
    }

    public static class ProductStringValues
    {
        public const string SQUARE_POS = @"SQUARE_POS";
        public const string EXTERNAL_API = @"EXTERNAL_API";
        public const string BILLING = @"BILLING";
        public const string APPOINTMENTS = @"APPOINTMENTS";
        public const string INVOICES = @"INVOICES";
        public const string ONLINE_STORE = @"ONLINE_STORE";
        public const string PAYROLL = @"PAYROLL";
        public const string DASHBOARD = @"DASHBOARD";
        public const string ITEM_LIBRARY_IMPORT = @"ITEM_LIBRARY_IMPORT";
        public const string OTHER = @"OTHER";
    }

    ///<summary>
    ///The query entry point for the entire schema.
    ///</summary>
    [Description("The query entry point for the entire schema.")]
    public class Query : GraphQLObject<Query>, IQueryRoot
    {
        ///<summary>
        ///Retrieves a list of cards owned by the merchant. A max of 25 cards will be returned.
        ///
        ///Permissions:PAYMENTS_READ
        ///</summary>
        [Description("Retrieves a list of cards owned by the merchant. A max of 25 cards will be returned.\n\nPermissions:PAYMENTS_READ")]
        public CardOnFileConnection? cardsOnFile { get; set; }

        ///<summary>
        ///A list of Customer.
        ///
        ///Permissions:CUSTOMERS_READ
        ///</summary>
        [Description("A list of Customer.\n\nPermissions:CUSTOMERS_READ")]
        public CustomerConnection? customers { get; set; }

        ///<summary>
        ///Returns the Merchant the access token is granted permission to view
        ///</summary>
        [Description("Returns the Merchant the access token is granted permission to view")]
        public Merchant? currentMerchant { get; set; }

        ///<summary>
        ///Query for catalog
        ///
        ///Permissions:ITEMS_READ
        ///</summary>
        [Description("Query for catalog\n\nPermissions:ITEMS_READ")]
        public CatalogObjectConnection? catalog { get; set; }

        ///<summary>
        ///Query for CatalogItems
        ///
        ///Permissions:ITEMS_READ
        ///</summary>
        [Description("Query for CatalogItems\n\nPermissions:ITEMS_READ")]
        public CatalogItemConnection? catalogItems { get; set; }

        ///<summary>
        ///Retrieve InventoryChanges by the specified filter
        ///
        ///Permissions:INVENTORY_READ
        ///</summary>
        [Description("Retrieve InventoryChanges by the specified filter\n\nPermissions:INVENTORY_READ")]
        public InventoryChangeConnection? inventoryChanges { get; set; }

        ///<summary>
        ///Retrieve InventoryCounts by the specified filter
        ///
        ///Permissions:INVENTORY_READ
        ///</summary>
        [Description("Retrieve InventoryCounts by the specified filter\n\nPermissions:INVENTORY_READ")]
        public InventoryCountConnection? inventoryCounts { get; set; }

        ///<summary>
        ///Returns Orders by the specified filter.
        ///
        ///Permissions:ORDERS_READ
        ///</summary>
        [Description("Returns Orders by the specified filter.\n\nPermissions:ORDERS_READ")]
        public OrderConnection? orders { get; set; }

        ///<summary>
        ///Returns Merchants by IDs. Order is not guaranteed.
        ///
        ///Permissions:MERCHANT_PROFILE_READ
        ///</summary>
        [Description("Returns Merchants by IDs. Order is not guaranteed.\n\nPermissions:MERCHANT_PROFILE_READ")]
        public MerchantConnection? merchants { get; set; }

        ///<summary>
        ///Fetches `PaymentRefund`s based on the provided arguments.
        ///</summary>
        [Description("Fetches `PaymentRefund`s based on the provided arguments.")]
        public PaymentRefundConnection? paymentRefunds { get; set; }

        ///<summary>
        ///Fetches `Payment`s based on the provided arguments.
        ///</summary>
        [Description("Fetches `Payment`s based on the provided arguments.")]
        public PaymentConnection? payments { get; set; }
    }

    ///<summary>
    ///Represents a refund processed for a Square transaction.
    ///Permissions: ORDERS_READ
    ///</summary>
    [Description("Represents a refund processed for a Square transaction.\nPermissions: ORDERS_READ")]
    public class Refund : GraphQLObject<Refund>
    {
        ///<summary>
        ///The amount of money refunded to the buyer.
        ///</summary>
        [Description("The amount of money refunded to the buyer.")]
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
        [Description("The timestamp for when the refund was created, in RFC 3339 format.\n  \nExamples for January 25th, 2020 6:25:34pm Pacific Standard Time:\n  \nUTC:  2020-01-26T02:25:34Z\n  \nPacific Standard Time with UTC offset:  2020-01-25T18:25:34-08:00")]
        public DateTime? createdAt { get; set; }

        ///<summary>
        ///The refund's unique ID.
        ///</summary>
        [Description("The refund's unique ID.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The ID of the refund's associated location.
        ///</summary>
        [Description("The ID of the refund's associated location.")]
        public Location? location { get; set; }

        ///<summary>
        ///The amount of Square processing fee money refunded to the *merchant*.
        ///</summary>
        [Description("The amount of Square processing fee money refunded to the *merchant*.")]
        public Money? processingFee { get; set; }

        ///<summary>
        ///The reason for the refund being issued.
        ///</summary>
        [Description("The reason for the refund being issued.")]
        public string? reason { get; set; }

        ///<summary>
        ///The current status of the refund (`PENDING`, `APPROVED`, `REJECTED`,
        ///or `FAILED`).
        ///</summary>
        [Description("The current status of the refund (`PENDING`, `APPROVED`, `REJECTED`,\nor `FAILED`).")]
        public RefundStatus? status { get; set; }

        ///<summary>
        ///The ID of the refunded tender.
        ///</summary>
        [Description("The ID of the refunded tender.")]
        public IOrderTender? tender { get; set; }

        ///<summary>
        ///The ID of the transaction that the refunded tender is part of.
        ///</summary>
        [Description("The ID of the transaction that the refunded tender is part of.")]
        public string? transactionId { get; set; }
    }

    ///<summary>
    ///Indicates a refund's current status.
    ///</summary>
    [Description("Indicates a refund's current status.")]
    public enum RefundStatus
    {
        ///<summary>
        ///The refund has been approved by Square.
        ///</summary>
        [Description("The refund has been approved by Square.")]
        APPROVED,
        ///<summary>
        ///The refund failed.
        ///</summary>
        [Description("The refund failed.")]
        FAILED,
        ///<summary>
        ///The refund is pending.
        ///</summary>
        [Description("The refund is pending.")]
        PENDING,
        ///<summary>
        ///The refund has been rejected by Square.
        ///</summary>
        [Description("The refund has been rejected by Square.")]
        REJECTED,
    }

    public static class RefundStatusStringValues
    {
        public const string APPROVED = @"APPROVED";
        public const string FAILED = @"FAILED";
        public const string PENDING = @"PENDING";
        public const string REJECTED = @"REJECTED";
    }

    ///<summary>
    ///A loyalty reward.
    ///
    ///Loyalty rewards are not currently fully represented in graphql, and their details must be retrieved through the
    ///REST API.
    ///
    ///Permissions:LOYALTY_READ
    ///</summary>
    [Description("A loyalty reward.\n\nLoyalty rewards are not currently fully represented in graphql, and their details must be retrieved through the\nREST API.\n\nPermissions:LOYALTY_READ")]
    public class Reward : GraphQLObject<Reward>
    {
        ///<summary>
        ///The Square-assigned ID of the loyalty reward.
        ///</summary>
        [Description("The Square-assigned ID of the loyalty reward.")]
        [NonNull]
        public string? id { get; set; }

        ///<summary>
        ///The reward tier used to create the reward.
        ///</summary>
        [Description("The reward tier used to create the reward.")]
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
    [Description("A loyalty program reward tier.\n\nLoyalty reward tiers are not currently fully represented in graphql, and their details must be retrieved through the\nREST API.\n\nPermissions:LOYALTY_READ")]
    public class RewardTier : GraphQLObject<RewardTier>
    {
        ///<summary>
        ///The Square-assigned ID of the reward tier.
        ///</summary>
        [Description("The Square-assigned ID of the reward tier.")]
        [NonNull]
        public string? id { get; set; }
    }

    ///<summary>
    ///Specifies which timestamp to use to sort `SearchOrder` results.
    ///</summary>
    [Description("Specifies which timestamp to use to sort `SearchOrder` results.")]
    public enum SearchOrdersSortField
    {
        ///<summary>
        ///The time when the order was closed, in RFC-3339 format. If you use this
        ///value, you must also set a `StateFilter` with closed states. If you are also
        ///filtering for a time range in this query, you must set the `CLOSED_AT`
        ///field in your `DateTimeFilter`.
        ///</summary>
        [Description("The time when the order was closed, in RFC-3339 format. If you use this\nvalue, you must also set a `StateFilter` with closed states. If you are also\nfiltering for a time range in this query, you must set the `CLOSED_AT`\nfield in your `DateTimeFilter`.")]
        CLOSED_AT,
        ///<summary>
        ///The time when the order was created, in RFC-3339 format. If you are also
        ///filtering for a time range in this query, you must set the `CREATED_AT`
        ///field in your `DateTimeFilter`.
        ///</summary>
        [Description("The time when the order was created, in RFC-3339 format. If you are also\nfiltering for a time range in this query, you must set the `CREATED_AT`\nfield in your `DateTimeFilter`.")]
        CREATED_AT,
        ///<summary>
        ///The time when the order last updated, in RFC-3339 format. If you are also
        ///filtering for a time range in this query, you must set the `UPDATED_AT`
        ///field in your `DateTimeFilter`.
        ///</summary>
        [Description("The time when the order last updated, in RFC-3339 format. If you are also\nfiltering for a time range in this query, you must set the `UPDATED_AT`\nfield in your `DateTimeFilter`.")]
        UPDATED_AT,
    }

    public static class SearchOrdersSortFieldStringValues
    {
        public const string CLOSED_AT = @"CLOSED_AT";
        public const string CREATED_AT = @"CREATED_AT";
        public const string UPDATED_AT = @"UPDATED_AT";
    }

    public enum SortOrder
    {
        ASC,
        DESC,
    }

    public static class SortOrderStringValues
    {
        public const string ASC = @"ASC";
        public const string DESC = @"DESC";
    }

    ///<summary>
    ///Represents information about the application used to generate a change.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Represents information about the application used to generate a change.\nPermissions: ITEMS_READ")]
    public class SourceApplication : GraphQLObject<SourceApplication>
    {
        ///<summary>
        ///__Read only__ The product type of the application.
        ///</summary>
        [Description("__Read only__ The product type of the application.")]
        public Product? product { get; set; }

        ///<summary>
        ///__Read only__ The Square-assigned ID of the application. This field is used only if the
        ///product type is `EXTERNAL_API`.
        ///</summary>
        [Description("__Read only__ The Square-assigned ID of the application. This field is used only if the\nproduct type is `EXTERNAL_API`.")]
        public string? applicationId { get; set; }

        ///<summary>
        ///__Read only__ The display name of the application
        ///(for example, `"Custom Application"` or `"Square POS 4.74 for Android"`).
        ///</summary>
        [Description("__Read only__ The display name of the application\n(for example, `\"Custom Application\"` or `\"Square POS 4.74 for Android\"`).")]
        public string? name { get; set; }
    }

    ///<summary>
    ///Permissions: PAYMENTS_READ
    ///
    ///Additional details about Square Account payments.
    ///</summary>
    [Description("Permissions: PAYMENTS_READ\n\nAdditional details about Square Account payments.")]
    public class SquareAccountPaymentDetails : GraphQLObject<SquareAccountPaymentDetails>
    {
        ///<summary>
        ///Information about errors encountered during the request.
        ///</summary>
        [Description("Information about errors encountered during the request.")]
        [NonNull]
        public IEnumerable<Error>? errors { get; set; }

        ///<summary>
        ///Unique identifier for the payment source used for this payment.
        ///</summary>
        [Description("Unique identifier for the payment source used for this payment.")]
        public string? paymentSourceToken { get; set; }
    }

    ///<summary>
    ///An enumeration of Square products.
    ///</summary>
    [Description("An enumeration of Square products.")]
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

    public static class SquareProductStringValues
    {
        public const string UNKNOWN_SQUARE_PRODUCT = @"UNKNOWN_SQUARE_PRODUCT";
        public const string CONNECT_API = @"CONNECT_API";
        public const string DASHBOARD = @"DASHBOARD";
        public const string REGISTER_CLIENT = @"REGISTER_CLIENT";
        public const string BUYER_DASHBOARD = @"BUYER_DASHBOARD";
        public const string WEB = @"WEB";
        public const string INVOICES = @"INVOICES";
        public const string GIFT_CARD = @"GIFT_CARD";
        public const string VIRTUAL_TERMINAL = @"VIRTUAL_TERMINAL";
        public const string READER_SDK = @"READER_SDK";
        public const string SQUARE_PROFILE = @"SQUARE_PROFILE";
        public const string SQUARE_LOCAL = @"SQUARE_LOCAL";
    }

    ///<summary>
    ///Determines the billing cadence of a Subscription
    ///</summary>
    [Description("Determines the billing cadence of a Subscription")]
    public enum SubscriptionCadence
    {
        ///<summary>
        ///Once per day
        ///</summary>
        [Description("Once per day")]
        DAILY,
        ///<summary>
        ///Once per week
        ///</summary>
        [Description("Once per week")]
        WEEKLY,
        ///<summary>
        ///Every two weeks
        ///</summary>
        [Description("Every two weeks")]
        EVERY_TWO_WEEKS,
        ///<summary>
        ///Once every 30 days
        ///</summary>
        [Description("Once every 30 days")]
        THIRTY_DAYS,
        ///<summary>
        ///Once every 60 days
        ///</summary>
        [Description("Once every 60 days")]
        SIXTY_DAYS,
        ///<summary>
        ///Once every 90 days
        ///</summary>
        [Description("Once every 90 days")]
        NINETY_DAYS,
        ///<summary>
        ///Once per month
        ///</summary>
        [Description("Once per month")]
        MONTHLY,
        ///<summary>
        ///Once every two months
        ///</summary>
        [Description("Once every two months")]
        EVERY_TWO_MONTHS,
        ///<summary>
        ///Once every three months
        ///</summary>
        [Description("Once every three months")]
        QUARTERLY,
        ///<summary>
        ///Once every four months
        ///</summary>
        [Description("Once every four months")]
        EVERY_FOUR_MONTHS,
        ///<summary>
        ///Once every six months
        ///</summary>
        [Description("Once every six months")]
        EVERY_SIX_MONTHS,
        ///<summary>
        ///Once per year
        ///</summary>
        [Description("Once per year")]
        ANNUAL,
        ///<summary>
        ///Once every two years
        ///</summary>
        [Description("Once every two years")]
        EVERY_TWO_YEARS,
    }

    public static class SubscriptionCadenceStringValues
    {
        public const string DAILY = @"DAILY";
        public const string WEEKLY = @"WEEKLY";
        public const string EVERY_TWO_WEEKS = @"EVERY_TWO_WEEKS";
        public const string THIRTY_DAYS = @"THIRTY_DAYS";
        public const string SIXTY_DAYS = @"SIXTY_DAYS";
        public const string NINETY_DAYS = @"NINETY_DAYS";
        public const string MONTHLY = @"MONTHLY";
        public const string EVERY_TWO_MONTHS = @"EVERY_TWO_MONTHS";
        public const string QUARTERLY = @"QUARTERLY";
        public const string EVERY_FOUR_MONTHS = @"EVERY_FOUR_MONTHS";
        public const string EVERY_SIX_MONTHS = @"EVERY_SIX_MONTHS";
        public const string ANNUAL = @"ANNUAL";
        public const string EVERY_TWO_YEARS = @"EVERY_TWO_YEARS";
    }

    ///<summary>
    ///Describes a phase in a subscription plan variation.For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Describes a phase in a subscription plan variation.For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).\nPermissions: ITEMS_READ")]
    public class SubscriptionPhase : GraphQLObject<SubscriptionPhase>
    {
        ///<summary>
        ///The Square-assigned ID of the subscription phase. This field cannot be changed after a `SubscriptionPhase` is created.
        ///</summary>
        [Description("The Square-assigned ID of the subscription phase. This field cannot be changed after a `SubscriptionPhase` is created.")]
        public string? uid { get; set; }

        ///<summary>
        ///The billing cadence of the phase. For example, weekly or monthly. This field cannot be changed after a `SubscriptionPhase` is created.
        ///</summary>
        [Description("The billing cadence of the phase. For example, weekly or monthly. This field cannot be changed after a `SubscriptionPhase` is created.")]
        public SubscriptionCadence? cadence { get; set; }

        ///<summary>
        ///The number of `cadence`s the phase lasts. If not set, the phase never ends. Only the last phase can be indefinite. This field cannot be changed after a `SubscriptionPhase` is created.
        ///</summary>
        [Description("The number of `cadence`s the phase lasts. If not set, the phase never ends. Only the last phase can be indefinite. This field cannot be changed after a `SubscriptionPhase` is created.")]
        public int? periods { get; set; }

        ///<summary>
        ///The amount to bill for each `cadence`. Failure to specify this field results in a `MISSING_REQUIRED_PARAMETER` error at runtime.
        ///</summary>
        [Description("The amount to bill for each `cadence`. Failure to specify this field results in a `MISSING_REQUIRED_PARAMETER` error at runtime.")]
        public Money? recurringPriceMoney { get; set; }

        ///<summary>
        ///The subscription pricing.
        ///</summary>
        [Description("The subscription pricing.")]
        public SubscriptionPricing? pricing { get; set; }

        ///<summary>
        ///The position this phase appears in the sequence of phases defined for the plan, indexed from 0. This field cannot be changed after a `SubscriptionPhase` is created.
        ///</summary>
        [Description("The position this phase appears in the sequence of phases defined for the plan, indexed from 0. This field cannot be changed after a `SubscriptionPhase` is created.")]
        public long? ordinal { get; set; }
    }

    ///<summary>
    ///Describes the pricing for the subscription.
    ///Permissions: ITEMS_READ
    ///</summary>
    [Description("Describes the pricing for the subscription.\nPermissions: ITEMS_READ")]
    public class SubscriptionPricing : GraphQLObject<SubscriptionPricing>
    {
        ///<summary>
        ///RELATIVE or STATIC
        ///</summary>
        [Description("RELATIVE or STATIC")]
        public SubscriptionPricingType? type { get; set; }

        ///<summary>
        ///The ids of the discount catalog objects
        ///</summary>
        [Description("The ids of the discount catalog objects")]
        public IEnumerable<string>? discountIds { get; set; }

        ///<summary>
        ///The price of the subscription, if STATIC
        ///</summary>
        [Description("The price of the subscription, if STATIC")]
        public Money? priceMoney { get; set; }
    }

    ///<summary>
    ///Determines the pricing of a Subscription
    ///</summary>
    [Description("Determines the pricing of a Subscription")]
    public enum SubscriptionPricingType
    {
        ///<summary>
        ///Static pricing
        ///</summary>
        [Description("Static pricing")]
        STATIC,
        ///<summary>
        ///Relative pricing
        ///</summary>
        [Description("Relative pricing")]
        RELATIVE,
    }

    public static class SubscriptionPricingTypeStringValues
    {
        public const string STATIC = @"STATIC";
        public const string RELATIVE = @"RELATIVE";
    }

    ///<summary>
    ///When to calculate the taxes due on a cart.
    ///</summary>
    [Description("When to calculate the taxes due on a cart.")]
    public enum TaxCalculationPhase
    {
        ///<summary>
        ///The fee is calculated based on the payment's subtotal.
        ///</summary>
        [Description("The fee is calculated based on the payment's subtotal.")]
        TAX_SUBTOTAL_PHASE,
        ///<summary>
        ///The fee is calculated based on the payment's total.
        ///</summary>
        [Description("The fee is calculated based on the payment's total.")]
        TAX_TOTAL_PHASE,
    }

    public static class TaxCalculationPhaseStringValues
    {
        public const string TAX_SUBTOTAL_PHASE = @"TAX_SUBTOTAL_PHASE";
        public const string TAX_TOTAL_PHASE = @"TAX_TOTAL_PHASE";
    }

    ///<summary>
    ///Identifiers for the location used by various governments for tax purposes.
    ///
    ///Permissions:CUSTOMERS_READ
    ///</summary>
    [Description("Identifiers for the location used by various governments for tax purposes.\n\nPermissions:CUSTOMERS_READ")]
    public class TaxIds : GraphQLObject<TaxIds>
    {
        ///<summary>
        ///The EU VAT identification number for the customer. For example, IE3426675K. The ID can contain alphanumeric characters only.
        ///</summary>
        [Description("The EU VAT identification number for the customer. For example, IE3426675K. The ID can contain alphanumeric characters only.")]
        public string? euVat { get; set; }
    }

    ///<summary>
    ///Whether to the tax amount should be additional to or included in the CatalogItem price.
    ///</summary>
    [Description("Whether to the tax amount should be additional to or included in the CatalogItem price.")]
    public enum TaxInclusionType
    {
        ///<summary>
        ///The tax is an additive tax. The tax amount is added on top of the
        ///CatalogItemVariation price. For example, a $1.00 item with a 10% additive
        ///tax would have a total cost to the buyer of $1.10.
        ///</summary>
        [Description("The tax is an additive tax. The tax amount is added on top of the\nCatalogItemVariation price. For example, a $1.00 item with a 10% additive\ntax would have a total cost to the buyer of $1.10.")]
        ADDITIVE,
        ///<summary>
        ///The tax is an inclusive tax. The tax amount is included in the
        ///CatalogItemVariation price. For example, a $1.00 item with a 10% inclusive
        ///tax would have a total cost to the buyer of $1.00, with $0.91 (91 cents) of
        ///that total being the cost of the item and $0.09 (9 cents) being tax.
        ///</summary>
        [Description("The tax is an inclusive tax. The tax amount is included in the\nCatalogItemVariation price. For example, a $1.00 item with a 10% inclusive\ntax would have a total cost to the buyer of $1.00, with $0.91 (91 cents) of\nthat total being the cost of the item and $0.09 (9 cents) being tax.")]
        INCLUSIVE,
    }

    public static class TaxInclusionTypeStringValues
    {
        public const string ADDITIVE = @"ADDITIVE";
        public const string INCLUSIVE = @"INCLUSIVE";
    }

    ///<summary>
    ///A record representing an individual team member for a business.
    ///
    ///Permissions:EMPLOYEES_READ
    ///</summary>
    [Description("A record representing an individual team member for a business.\n\nPermissions:EMPLOYEES_READ")]
    public class TeamMember : GraphQLObject<TeamMember>
    {
        ///<summary>
        ///The Square-issued ID of the team member.
        ///</summary>
        [Description("The Square-issued ID of the team member.")]
        [NonNull]
        public string? id { get; set; }
    }

    ///<summary>
    ///A GraphQL Schema defines the capabilities of a GraphQL server. It exposes all available types and directives on the server, as well as the entry points for query, mutation, and subscription operations.
    ///</summary>
    [Description("A GraphQL Schema defines the capabilities of a GraphQL server. It exposes all available types and directives on the server, as well as the entry points for query, mutation, and subscription operations.")]
    public class __Schema : GraphQLObject<__Schema>
    {
        public string? description { get; set; }

        ///<summary>
        ///A list of all types supported by this server.
        ///</summary>
        [Description("A list of all types supported by this server.")]
        [NonNull]
        public IEnumerable<__Type>? types { get; set; }

        ///<summary>
        ///The type that query operations will be rooted at.
        ///</summary>
        [Description("The type that query operations will be rooted at.")]
        [NonNull]
        public __Type? queryType { get; set; }

        ///<summary>
        ///If this server supports mutation, the type that mutation operations will be rooted at.
        ///</summary>
        [Description("If this server supports mutation, the type that mutation operations will be rooted at.")]
        public __Type? mutationType { get; set; }

        ///<summary>
        ///If this server support subscription, the type that subscription operations will be rooted at.
        ///</summary>
        [Description("If this server support subscription, the type that subscription operations will be rooted at.")]
        public __Type? subscriptionType { get; set; }

        ///<summary>
        ///A list of all directives supported by this server.
        ///</summary>
        [Description("A list of all directives supported by this server.")]
        [NonNull]
        public IEnumerable<__Directive>? directives { get; set; }
    }

    ///<summary>
    ///The fundamental unit of any GraphQL Schema is the type. There are many kinds of types in GraphQL as represented by the `__TypeKind` enum.
    ///
    ///Depending on the kind of a type, certain fields describe information about that type. Scalar types provide no information beyond a name, description and optional `specifiedByURL`, while Enum types provide their values. Object and Interface types provide the fields they describe. Abstract types, Union and Interface, provide the Object types possible at runtime. List and NonNull types compose other types.
    ///</summary>
    [Description("The fundamental unit of any GraphQL Schema is the type. There are many kinds of types in GraphQL as represented by the `__TypeKind` enum.\n\nDepending on the kind of a type, certain fields describe information about that type. Scalar types provide no information beyond a name, description and optional `specifiedByURL`, while Enum types provide their values. Object and Interface types provide the fields they describe. Abstract types, Union and Interface, provide the Object types possible at runtime. List and NonNull types compose other types.")]
    public class __Type : GraphQLObject<__Type>
    {
        [NonNull]
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
    [Description("An enum describing what kind of type a given `__Type` is.")]
    public enum __TypeKind
    {
        ///<summary>
        ///Indicates this type is a scalar.
        ///</summary>
        [Description("Indicates this type is a scalar.")]
        SCALAR,
        ///<summary>
        ///Indicates this type is an object. `fields` and `interfaces` are valid fields.
        ///</summary>
        [Description("Indicates this type is an object. `fields` and `interfaces` are valid fields.")]
        OBJECT,
        ///<summary>
        ///Indicates this type is an interface. `fields`, `interfaces`, and `possibleTypes` are valid fields.
        ///</summary>
        [Description("Indicates this type is an interface. `fields`, `interfaces`, and `possibleTypes` are valid fields.")]
        INTERFACE,
        ///<summary>
        ///Indicates this type is a union. `possibleTypes` is a valid field.
        ///</summary>
        [Description("Indicates this type is a union. `possibleTypes` is a valid field.")]
        UNION,
        ///<summary>
        ///Indicates this type is an enum. `enumValues` is a valid field.
        ///</summary>
        [Description("Indicates this type is an enum. `enumValues` is a valid field.")]
        ENUM,
        ///<summary>
        ///Indicates this type is an input object. `inputFields` is a valid field.
        ///</summary>
        [Description("Indicates this type is an input object. `inputFields` is a valid field.")]
        INPUT_OBJECT,
        ///<summary>
        ///Indicates this type is a list. `ofType` is a valid field.
        ///</summary>
        [Description("Indicates this type is a list. `ofType` is a valid field.")]
        LIST,
        ///<summary>
        ///Indicates this type is a non-null. `ofType` is a valid field.
        ///</summary>
        [Description("Indicates this type is a non-null. `ofType` is a valid field.")]
        NON_NULL,
    }

    public static class __TypeKindStringValues
    {
        public const string SCALAR = @"SCALAR";
        public const string OBJECT = @"OBJECT";
        public const string INTERFACE = @"INTERFACE";
        public const string UNION = @"UNION";
        public const string ENUM = @"ENUM";
        public const string INPUT_OBJECT = @"INPUT_OBJECT";
        public const string LIST = @"LIST";
        public const string NON_NULL = @"NON_NULL";
    }

    ///<summary>
    ///Object and Interface types are described by a list of Fields, each of which has a name, potentially a list of arguments, and a return type.
    ///</summary>
    [Description("Object and Interface types are described by a list of Fields, each of which has a name, potentially a list of arguments, and a return type.")]
    public class __Field : GraphQLObject<__Field>
    {
        [NonNull]
        public string? name { get; set; }
        public string? description { get; set; }

        [NonNull]
        public IEnumerable<__InputValue>? args { get; set; }

        [NonNull]
        public __Type? type { get; set; }

        [NonNull]
        public bool? isDeprecated { get; set; }
        public string? deprecationReason { get; set; }
    }

    ///<summary>
    ///Arguments provided to Fields or Directives and the input fields of an InputObject are represented as Input Values which describe their type and optionally a default value.
    ///</summary>
    [Description("Arguments provided to Fields or Directives and the input fields of an InputObject are represented as Input Values which describe their type and optionally a default value.")]
    public class __InputValue : GraphQLObject<__InputValue>
    {
        [NonNull]
        public string? name { get; set; }
        public string? description { get; set; }

        [NonNull]
        public __Type? type { get; set; }

        ///<summary>
        ///A GraphQL-formatted string representing the default value for this input value.
        ///</summary>
        [Description("A GraphQL-formatted string representing the default value for this input value.")]
        public string? defaultValue { get; set; }

        [NonNull]
        public bool? isDeprecated { get; set; }
        public string? deprecationReason { get; set; }
    }

    ///<summary>
    ///One possible value for a given Enum. Enum values are unique values, not a placeholder for a string or numeric value. However an Enum value is returned in a JSON response as a string.
    ///</summary>
    [Description("One possible value for a given Enum. Enum values are unique values, not a placeholder for a string or numeric value. However an Enum value is returned in a JSON response as a string.")]
    public class __EnumValue : GraphQLObject<__EnumValue>
    {
        [NonNull]
        public string? name { get; set; }
        public string? description { get; set; }

        [NonNull]
        public bool? isDeprecated { get; set; }
        public string? deprecationReason { get; set; }
    }

    ///<summary>
    ///A Directive provides a way to describe alternate runtime execution and type validation behavior in a GraphQL document.
    ///
    ///In some cases, you need to provide options to alter GraphQL's execution behavior in ways field arguments will not suffice, such as conditionally including or skipping a field. Directives provide this by describing additional information to the executor.
    ///</summary>
    [Description("A Directive provides a way to describe alternate runtime execution and type validation behavior in a GraphQL document.\n\nIn some cases, you need to provide options to alter GraphQL's execution behavior in ways field arguments will not suffice, such as conditionally including or skipping a field. Directives provide this by describing additional information to the executor.")]
    public class __Directive : GraphQLObject<__Directive>
    {
        [NonNull]
        public string? name { get; set; }
        public string? description { get; set; }

        [NonNull]
        public bool? isRepeatable { get; set; }

        [NonNull]
        public IEnumerable<__DirectiveLocation>? locations { get; set; }

        [NonNull]
        public IEnumerable<__InputValue>? args { get; set; }
    }

    ///<summary>
    ///A Directive can be adjacent to many parts of the GraphQL language, a __DirectiveLocation describes one such possible adjacencies.
    ///</summary>
    [Description("A Directive can be adjacent to many parts of the GraphQL language, a __DirectiveLocation describes one such possible adjacencies.")]
    public enum __DirectiveLocation
    {
        ///<summary>
        ///Location adjacent to a query operation.
        ///</summary>
        [Description("Location adjacent to a query operation.")]
        QUERY,
        ///<summary>
        ///Location adjacent to a mutation operation.
        ///</summary>
        [Description("Location adjacent to a mutation operation.")]
        MUTATION,
        ///<summary>
        ///Location adjacent to a subscription operation.
        ///</summary>
        [Description("Location adjacent to a subscription operation.")]
        SUBSCRIPTION,
        ///<summary>
        ///Location adjacent to a field.
        ///</summary>
        [Description("Location adjacent to a field.")]
        FIELD,
        ///<summary>
        ///Location adjacent to a fragment definition.
        ///</summary>
        [Description("Location adjacent to a fragment definition.")]
        FRAGMENT_DEFINITION,
        ///<summary>
        ///Location adjacent to a fragment spread.
        ///</summary>
        [Description("Location adjacent to a fragment spread.")]
        FRAGMENT_SPREAD,
        ///<summary>
        ///Location adjacent to an inline fragment.
        ///</summary>
        [Description("Location adjacent to an inline fragment.")]
        INLINE_FRAGMENT,
        ///<summary>
        ///Location adjacent to a variable definition.
        ///</summary>
        [Description("Location adjacent to a variable definition.")]
        VARIABLE_DEFINITION,
        ///<summary>
        ///Location adjacent to a schema definition.
        ///</summary>
        [Description("Location adjacent to a schema definition.")]
        SCHEMA,
        ///<summary>
        ///Location adjacent to a scalar definition.
        ///</summary>
        [Description("Location adjacent to a scalar definition.")]
        SCALAR,
        ///<summary>
        ///Location adjacent to an object type definition.
        ///</summary>
        [Description("Location adjacent to an object type definition.")]
        OBJECT,
        ///<summary>
        ///Location adjacent to a field definition.
        ///</summary>
        [Description("Location adjacent to a field definition.")]
        FIELD_DEFINITION,
        ///<summary>
        ///Location adjacent to an argument definition.
        ///</summary>
        [Description("Location adjacent to an argument definition.")]
        ARGUMENT_DEFINITION,
        ///<summary>
        ///Location adjacent to an interface definition.
        ///</summary>
        [Description("Location adjacent to an interface definition.")]
        INTERFACE,
        ///<summary>
        ///Location adjacent to a union definition.
        ///</summary>
        [Description("Location adjacent to a union definition.")]
        UNION,
        ///<summary>
        ///Location adjacent to an enum definition.
        ///</summary>
        [Description("Location adjacent to an enum definition.")]
        ENUM,
        ///<summary>
        ///Location adjacent to an enum value definition.
        ///</summary>
        [Description("Location adjacent to an enum value definition.")]
        ENUM_VALUE,
        ///<summary>
        ///Location adjacent to an input object type definition.
        ///</summary>
        [Description("Location adjacent to an input object type definition.")]
        INPUT_OBJECT,
        ///<summary>
        ///Location adjacent to an input object field definition.
        ///</summary>
        [Description("Location adjacent to an input object field definition.")]
        INPUT_FIELD_DEFINITION,
    }

    public static class __DirectiveLocationStringValues
    {
        public const string QUERY = @"QUERY";
        public const string MUTATION = @"MUTATION";
        public const string SUBSCRIPTION = @"SUBSCRIPTION";
        public const string FIELD = @"FIELD";
        public const string FRAGMENT_DEFINITION = @"FRAGMENT_DEFINITION";
        public const string FRAGMENT_SPREAD = @"FRAGMENT_SPREAD";
        public const string INLINE_FRAGMENT = @"INLINE_FRAGMENT";
        public const string VARIABLE_DEFINITION = @"VARIABLE_DEFINITION";
        public const string SCHEMA = @"SCHEMA";
        public const string SCALAR = @"SCALAR";
        public const string OBJECT = @"OBJECT";
        public const string FIELD_DEFINITION = @"FIELD_DEFINITION";
        public const string ARGUMENT_DEFINITION = @"ARGUMENT_DEFINITION";
        public const string INTERFACE = @"INTERFACE";
        public const string UNION = @"UNION";
        public const string ENUM = @"ENUM";
        public const string ENUM_VALUE = @"ENUM_VALUE";
        public const string INPUT_OBJECT = @"INPUT_OBJECT";
        public const string INPUT_FIELD_DEFINITION = @"INPUT_FIELD_DEFINITION";
    }
}