﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Areas")]
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Bay> Bay { get; set; }

        public Area() { }

        public Area(string name)
        {
            Name = name;
        }
    }
}
 