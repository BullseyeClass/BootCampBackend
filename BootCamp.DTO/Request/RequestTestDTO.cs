using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BootCamp.DTO.Request
{
    public class RequestTestDTO
    {
		public int Score { get; set; }
		public string TestType { get; set; }
		[JsonIgnore]
		public string? TraineeId { get; set; }
	}
}
