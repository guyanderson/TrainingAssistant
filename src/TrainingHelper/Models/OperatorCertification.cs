using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingHelper.Models
{
    public class OperatorCertification
    {
        [Key]
        public int OperatorCertificationId { get; set; }
        public Operator Operator { get; set; }
        public Certification Certification { get; set; }
    }
}
