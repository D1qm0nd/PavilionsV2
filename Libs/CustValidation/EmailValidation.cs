namespace CustValidation;

public static class EmailValidation
{
    public static bool EmailValidate(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith(".")) {
            return false;
        }
        
        if (trimmedEmail.Contains("--") || trimmedEmail.Contains(";--") || trimmedEmail.Contains("..") || trimmedEmail.Contains("@@"))
            return false;
        
        foreach(var chr in ConstantReader.GetConstant("EmailNotAllowed"))
            if (trimmedEmail.Contains(chr))
                return false;
        
        try {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch {
            return false;
        }
        return true;
    }
}