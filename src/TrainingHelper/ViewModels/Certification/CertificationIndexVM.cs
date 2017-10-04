using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class CertificationIndexVM
    {


        public List<Certification> Certifications { get; set; }

        public CertificationIndexVM(List<Certification> certifications)
        {
            Certifications = certifications;
        }
    }
}
