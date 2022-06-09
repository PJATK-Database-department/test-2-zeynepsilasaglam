using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    [Table("Mechanic")]
    public class Mechanic
    {
        [Key]
        public int IdMechanic { get; set; }
        [Required, MaxLength(20, ErrorMessage = "MAx Length is 20")]
        public string FirstName { get; set; }
        [Required, MaxLength(30, ErrorMessage = "MAx Length is 30")]
        public string LastName { get; set; }

        public ICollection<Inspection> Inspections { get; set; } = new HashSet<Inspection>();
    }
}
