using System;
using System.ComponentModel.DataAnnotations;

namespace MASAPI.Models
{
	public abstract class Person
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }

		[Display(Name = "Middle Name")]
		public string? MiddleName { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public char Gender { get; set; }

		[Required]
		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; }

	}
}

