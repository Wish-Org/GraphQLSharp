namespace GraphQLSharp;

public class EnumTypeAttribute : Attribute
{
    protected Type EnumType { get; set; }

    public EnumTypeAttribute(Type enumType)
    {
        EnumType = enumType;
    }
}