using System.Linq;

namespace CustValidation;

public static class PasswordValidation
{
    public static bool PasswordValidate(string password) =>
        password.Length >= 6
        && password.LettersContains()
        && password.DigitContains()
        && password.ContainsCapitals()
        && password.ContainsNotCapitals()
        && password.ContainsSpecialSymbol();

    private static bool DigitContains(this string password)
    {
        foreach (var ch in password)
        {
            if (char.IsDigit(ch))
                return true;
        }

        return false;
    }

    private static bool LettersContains(this string password)
    {
        foreach (var ch in password)
        {
            if (char.IsLetter(ch))
                return true;
        }

        return false;
    }

    private static bool ContainsCapitals(this string password) => password.Any(Char.IsUpper);
    private static bool ContainsNotCapitals(this string password) => password.Any(Char.IsUpper);


    private static bool ContainsSpecialSymbol(this string password)
    {
        var specSymb = ("@{}()&^:!\"';*?<>,.#$%`~[]|\\/" as string).ToCharArray();
        foreach (var symb in specSymb)
        {
            if (password.Contains(symb))
                return true;
        }

        return false;
    }
}