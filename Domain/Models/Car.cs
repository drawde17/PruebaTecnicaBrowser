using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [Required]
        public int IdCar { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
