using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Certifications")]
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Shift> Shift { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<Bay> Bay { get; set; }
        public virtual ICollection<Tool> Tool { get; set; }
        public virtual ICollection<Operator> Operator { get; set; }

        public Certification() { }

        public Certification(string name)
        {
            Name = name;
        }

    }
}
