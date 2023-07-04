using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PavilionsData.PavilionsModel.Tables;

/// <summary>
/// Арендатор
/// </summary>
/// <params>
/// <param name="ID_Tentant">уникальный идентификатор арендатора</param>
/// <param name="ID_Rental">уникальный идентификатор аренды</param>
/// <param name="Name"></param>
/// <param name="PhoneNumber"></param>
/// <param name="Adress"></param>
/// </params>
[Table("Tenants")]
public class Tenant
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_Tenant { get; set; }
    [MaxLength(80)] public string Name { get; set; }
    [MaxLength(14)] public string PhoneNumber { get; set; }
    [MaxLength(80)] public string Address { get; set; }
    [MaxLength(7)] public string? RecordStatus { get; set; }

}