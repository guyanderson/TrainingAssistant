﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{

    [Table("Operators")]
    public class Operator
    {
        [Key]
        public int OperatorId { get; set; }
        public string Name { get; set; }
        public int ShiftId { get; set; }

        public Operator() { }

        public Operator(string name, int shiftId)
        {
            Name = name;
            ShiftId = shiftId;
        }
    }

}
