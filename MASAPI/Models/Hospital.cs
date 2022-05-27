using System;
using System.ComponentModel.DataAnnotations;

namespace MASAPI.Models
{
	public class Hospital
	{
		public Hospital()
		{
			Patients = new HashSet<Patient>();
			Doctors = new HashSet<DoctorHospital>();
		}

		public int ID { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Address { get; set; }

		[Required]
		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; }

		public virtual ICollection<Patient> Patients { get; set; }
		public virtual ICollection<DoctorHospital> Doctors { get; set; }
	}
}

