﻿using BootCamp.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Entities
{
    public class PhoneNumber : Common
    {
        public string Extension { get; set; }
        public string Number { get; set; }
        public string TraineeId { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
