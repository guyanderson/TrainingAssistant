using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Tools")]
    public class Tool
    {
        [Key]
        public int ToolId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int BayId { get; set; }
        [Required]
        public int CertificationId { get; set; }

        public virtual Bay Bay { get; set; }
        public virtual Certification Certification { get; set; }

        public Tool() { }

        public Tool(string name, int bayId, int certificationId)
        {
            Name = name;
            BayId = bayId;
            CertificationId = certificationId;
        }       
    }
}
