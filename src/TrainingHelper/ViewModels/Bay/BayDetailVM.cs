using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class BayDetailVM
    {
        public Bay Bay;
        //public Tool Tool;

        public BayDetailVM(Bay bay)
        {
            Bay = bay;
            //Tool = tools;
        }

    }
}
