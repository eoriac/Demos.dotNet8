namespace CSharpBasic;

public static class StringExtensions
{

    public static string AddDollarSign(this string stringToModify)
    {
        return stringToModify += " $";
    }
}
