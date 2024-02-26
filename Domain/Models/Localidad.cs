using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Localidad")]
    public class Localidad
    {
        [Key]
        [Required]
        public int IdLocalidad { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
