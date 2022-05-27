using System;
using System.ComponentModel.DataAnnotations;

namespace MASAPI.Models
{
	public class Patient : Person
	{
		public DateTime Accepted { get; set; }
		public string Sickness { get; set; }
		public int IdHospital { get; set; }

		public virtual Hospital IdHospitalNavigation { get; set; }
	}
}
