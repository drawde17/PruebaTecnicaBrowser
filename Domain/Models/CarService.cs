using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("CarService")]
    public class CarService
    {
        [Key]
        [Required]
        public int IdCarService { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
