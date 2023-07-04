namespace WPFUserControls;

public class LoginData
{

    public LoginData(string email, string login, string password, string surname, string name, string middlename, string phoneNumber, byte[]? imageBytes)
    {
        Email = email;
        Login = login;
        Password = password;
        Surname = surname;
        Name = name;
        Middlename = middlename;
        PhoneNumber = phoneNumber;
        ImageBytes = imageBytes;
    }

    public string? Email { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Surname { get; set; }
    public string? Name { get; set; }
    public string? Middlename { get; set; }
    public string? PhoneNumber { get; set; }
    
    public byte[]? ImageBytes { get; set; }
    
}