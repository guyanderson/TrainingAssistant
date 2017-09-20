using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class OperatorDetailsVM
    {
        public virtual Oper Oper { get; set; }
        public virtual ICollection<OperatorCertifications> OperatorCertifications { get; set; }
        public virtual ICollection<Certification> Certification { get; set; }

        public OperatorDetailsVM(Oper oper, List<OperatorCertifications> operatorCertifications, List<Certification> certifications)
        {
            Oper = oper;
            OperatorCertifications = operatorCertifications;
            Certification = certifications;
        }
    }
}
