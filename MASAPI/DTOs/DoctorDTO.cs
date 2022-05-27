using System;
namespace MASAPI.DTOs
{
	public class DoctorDTO
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public string? MiddleName { get; set; }

		public string Surname { get; set; }

		public char Gender { get; set; }

		public string PhoneNumber { get; set; }

		public DateTime HireDate { get; set; }

		public string Title { get; set; }
	}
}

