using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class OperatorEditVM
    {
        public virtual Oper Oper { get; set; }
        public virtual ICollection<Shift> Shift { get; set; }
        public virtual ICollection<Certification> Certification { get; set; }
        public virtual OperatorCertifications OperatorCertifications { get; set; }

        public OperatorEditVM(Oper oper, List<Shift> shift, List<Certification> certification, OperatorCertifications operatorCertifications)
        {
            Oper = oper;
            Shift = shift;
            Certification = certification;
            OperatorCertifications = operatorCertifications;
        }
    }
}
