using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Areas")]
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Shift> Shift { get; set; }
        public virtual ICollection<Bay> Bay { get; set; }
        public virtual ICollection<Tool> Tool { get; set; }
        public virtual ICollection<Certification> Certification { get; set; }
        public virtual ICollection<Operator> Operator { get; set; }

        public Area() { }

        public Area(string name)
        {
            Name = name;
        }
    }
}
