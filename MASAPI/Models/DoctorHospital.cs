using System;
namespace MASAPI.Models
{
	public class DoctorHospital
	{
		public int IdDoctor { get; set; }
		public int IdHospital { get; set; }

		public virtual Doctor IdDoctorNavigation { get; set; }
		public virtual Hospital IdHospitalNavigation { get; set; }
	}
}

