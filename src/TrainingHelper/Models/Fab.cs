using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    public class Fab
    {
        [Key]
        public int FabId { get; set; }
        
        public class Shift
        {
            public int ShiftId { get; set; }
            public string Name { get; set; }
        }
        public class Area
        {
            public int AreaId { get; set; }
            public string Name { get; set; }
        }

        public class Bay
        {
            public int BayId { get; set; }
            public string Name { get; set; }
            public int TargetTrained { get; set; }
            public int AreaId { get; set; }
        }

        public class Tool
        {
            public int ToolId { get; set; }
            public string Name { get; set; }
            public int BayId { get; set; }


        }

        public class Operator
        {
            public int OperatorId { get; set; }
            public string Name { get; set; }
            public int ShiftId { get; set; } 

        }

        public class Certification
        {
            public int CertificationId { get; set; }
            public string Name { get; set; }
            public int TargetTrained { get; set; }
        }

        public class OperatorCertification
        {
            public int OperatorId { get; set; }
            public int CertificationId { get; set; }
            public Operator Operator { get; set; }
            public Certification certification { get; set; }
        }

    }
}
 