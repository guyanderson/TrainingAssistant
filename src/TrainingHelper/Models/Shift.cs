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
        public string Name { get; set; }

        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<Bay> Bay { get; set; }
        public virtual ICollection<Tool> Tool { get; set; }
        public virtual ICollection<Certification> Certification { get; set; }
        public virtual ICollection<Operator> Operator { get; set; }
        public Shift() { }

        public Shift(string name)
        {
            Name = name;
        }
    }
}
