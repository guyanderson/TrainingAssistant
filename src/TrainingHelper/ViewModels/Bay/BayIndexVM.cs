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

        public BayIndexVM(List<Bay> bay)
        {
            Bay = bay;
        }
    }

}
/*

    public bool isEnough()
    {
        int operCert = Bay.Select(a => a.Tool).Select(a => a.Certification).OperatorCertifications.AsQueryable().Select(y => y.Oper).Count();
        foreach (var y in Bay.Select(z => z.Tool))
            if (operCert <= y.Select(r => r.Certification.TargetTrained))
            {
                enough = true;
            }
            else
            {
                enough = false;
                break;
            }
        }
        return enough
    }
*/