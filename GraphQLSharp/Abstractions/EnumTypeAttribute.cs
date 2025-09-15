namespace GraphQLSharp;

public class EnumTypeAttribute : Attribute
{
    public Type EnumType { get; }

    public EnumTypeAttribute(Type enumType)
    {
        EnumType = enumType;
    }
}