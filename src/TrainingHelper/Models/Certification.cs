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

        public Certification() { }

        public Certification(string name)
        {
            Name = name;
        }

    }
}
