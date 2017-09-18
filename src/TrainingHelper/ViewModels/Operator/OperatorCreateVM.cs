using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class OperatorCreateVM
    {
        public virtual Operator Operator { get; set; }
        public virtual ICollection<Shift> Shift { get; set; }

        public OperatorCreateVM(Operator oper, List<Shift> shift)
        {
            Operator = oper;
            Shift = shift;
        }
    }
}

