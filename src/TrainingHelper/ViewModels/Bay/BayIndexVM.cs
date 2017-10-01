using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class BayIndexVM
    {
        public List<Bay> Bay { get; set; }
        public List<Bay> FailedCertList { get; set; }

        public BayIndexVM(List<Bay> bay, List<Bay> failedCertList)
        {
            Bay = bay;
            FailedCertList = failedCertList;
        }

    }
}
