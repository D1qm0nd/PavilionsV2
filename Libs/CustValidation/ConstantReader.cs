using CustValidation.Resources;

namespace CustValidation;

public static class ConstantReader
{
    public static string? GetConstant(string constName)
    {
        return Resources.Constants.ResourceManager.GetString(constName);
    }
}