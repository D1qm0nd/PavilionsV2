namespace CustValidation;

public static class LoginValidation
{
    public static bool LoginValidate(string login) => login.Length >= 8;

}