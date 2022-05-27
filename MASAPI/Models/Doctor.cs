using System;
using System.ComponentModel.DataAnnotations;

namespace MASAPI.Models
{
	public class Doctor : Person
	{
        public Doctor()
        {
			Hospitals = new HashSet<DoctorHospital>();
        }

		public DateTime HireDate { get; set; }
		public string Title { get; set; }

		public virtual ICollection<DoctorHospital> Hospitals { get; set; }
	}
}

