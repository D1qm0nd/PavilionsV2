using PavilionsData.PavilionsModel.Tables;
using WPFUserControls;

namespace PavilionsApplication.Extentions;

public static class LoginDataExtentions
{
    public static Employee MakeEmployee(this LoginData data) => new Employee()
    {
        Login = data.Email,
        Password = data.Password,
        Surname = data.Surname,
        Name = data.Name,
        Middlename = data.Middlename,
        PhoneNumber = data.PhoneNumber,
        Id_Role = 1,
        Photo = data.ImageBytes,
        Gender = ""
    };
}