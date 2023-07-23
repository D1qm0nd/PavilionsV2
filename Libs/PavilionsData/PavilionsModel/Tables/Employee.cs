using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Interfaces;

namespace PavilionsData.PavilionsModel.Tables;

#nullable disable
/// <summary>
/// Сотрудник
/// </summary>
/// <params>
/// <param name="Id_Employee">уникальный идентификатор сотрудника</param>
/// <param name="Surname">фамилия</param>
/// <param name="Name">имя</param>
/// <param name="Middlename">отчество</param>
/// <param name="Login">логин</param>
/// <param name="Password">пароль</param>
/// <param name="PhoneNumber">номер телефона</param>
/// <param name="Gender">пол</param>
/// <param name="Photo">фото</param>
/// </params>
[Table("Employees")]
public class Employee : IUserData
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_Employee { get; set; }

    [MaxLength(80)] public string Surname { get; set; }
    [MaxLength(80)] public string Name { get; set; }
    [MaxLength(80)] public string Middlename { get; set; }
    [Required, MaxLength(80)] public string Login { get; set; }
    [MaxLength(80)] public string Password { get; set; }
    
    [ForeignKey("Role")]
    public int Id_Role { get; set; }
    [Required, MaxLength(11)] public string PhoneNumber { get; set; }
    public byte[]? Photo { get; set; }
    [MaxLength(3)] public string Gender { get; set; }

    [JsonIgnore] public Role Role { get; set; }


    public bool isNotFull()
    {
        return Login == null && Password == null && Surname == null &&
               Name == null && Middlename == null && PhoneNumber == null;
    }

    public bool Equals(Employee other)
    {
        return Login == other.Login && Password == other.Password;
    }
}