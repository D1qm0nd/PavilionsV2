namespace CustValidation;

public static class PhoneValidation
{
    public static bool PhoneValidate(string phonenumber) =>
        phonenumber.Length == 11
        && phonenumber.ContainsOnlyDigits()
        && phonenumber.StartsWith("7");

    private static bool ContainsOnlyDigits(this string phonenumber) => !phonenumber.Any((c) => !Char.IsDigit(c));
}