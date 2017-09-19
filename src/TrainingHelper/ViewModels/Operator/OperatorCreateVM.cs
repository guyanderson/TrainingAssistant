using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class OperatorCreateVM
    {
        public virtual Oper Oper { get; set; }
        public virtual ICollection<Shift> Shift { get; set; }

        public OperatorCreateVM(Oper oper, List<Shift> shift)
        {
            Oper = oper;
            Shift = shift;
        }
    }
}

