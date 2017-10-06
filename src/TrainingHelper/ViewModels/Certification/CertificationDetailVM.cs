using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class CertificationDetailVM
    {
        public Certification Certification { get; set; }

        public CertificationDetailVM(Certification certification)
        {
            Certification = certification;
        }
    }
}
