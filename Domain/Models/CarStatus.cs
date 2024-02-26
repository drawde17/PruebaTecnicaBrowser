using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("CarStatus")]
    public class CarStatus
    {
        [Key]
        [Required]
        public int IdCarStatus { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int IdCar { get; set; }
        [Required]
        public int IdCarService { get; set; }
        public Nullable<int> IdLocalidadRecogida { get; set; }
        public Nullable<int> IdLocalidadDevolucion { get; set; }

    }
}
