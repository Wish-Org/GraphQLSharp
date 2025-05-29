namespace GraphQLSharp;

#nullable enable

///<summary>
///Returns information about pagination in a connection, in accordance with the
///[Relay specification](https://relay.dev/graphql/connections.htm#sec-undefined.PageInfo).
///</summary>
public class PageInfo : GraphQLObject<PageInfo>
{
    ///<summary>
    ///The cursor corresponding to the last node in edges.
    ///</summary>
    public string? endCursor { get; set; }
    ///<summary>
    ///Whether there are more pages to fetch following the current page.
    ///</summary>
    public bool? hasNextPage { get; set; }
    ///<summary>
    ///Whether there are any pages prior to the current page.
    ///</summary>
    public bool? hasPreviousPage { get; set; }
    ///<summary>
    ///The cursor corresponding to the first node in edges.
    ///</summary>
    public string? startCursor { get; set; }
}