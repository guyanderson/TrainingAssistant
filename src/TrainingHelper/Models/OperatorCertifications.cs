using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    public class OperatorCertifications
    {
        public int OperatorCertificationsId { get; set; }

        public virtual Certification Certification { get; set; }
        public virtual OperatorCertifications Operator { get; set; }
    }
}
