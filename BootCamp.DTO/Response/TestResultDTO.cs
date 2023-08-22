﻿using BootCamp.Data.Entities;
using BootCamp.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BootCamp.DTO.Response
{
    public class TestResultDTO
    {
        public string StudentId { get; set; }
        public int Score { get; set; }
        public string TestType { get; set;}


        [JsonIgnore]
        public string TraineeId { get; set; }

    }
}
