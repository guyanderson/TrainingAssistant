using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class OperatorDetailsVM
    {
        public Oper Oper;

        public OperatorDetailsVM(Oper oper)
        {
            Oper = oper;
        }
    }
}
