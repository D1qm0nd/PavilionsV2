using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PavilionsData.PavilionsModel.Tables
{
    [Table("Logs")]
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id_Log { get; set; }

        [Required]
        public string? CurrentUser { get; set; }

        [Required, ForeignKey(nameof(Rental))]
        public int? Id_Rental { get; set; }
        [Required]
        public int? Id_Tenant { get; set; }
        [Required]
        public int? Id_Employee { get; set; }

        [Required]
        public string? ShoppingCenterName { get; set; }
        [Required]
        public int? Id_Pavilion { get; set; }
        [Required]
        public int? Id_RentalStatus { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }


        [JsonIgnore] public Rental Rental { get; set; }

    }
}
