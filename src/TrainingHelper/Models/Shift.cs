using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Shifts")]
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual ICollection<Operator> Operator { get; set; }

        public Shift() { }

        public Shift(string name)
        {
            Name = name;
        }
    }
}
