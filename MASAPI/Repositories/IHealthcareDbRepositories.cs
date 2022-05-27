using System;
using MASAPI.DTOs;
using MASAPI.Models;

namespace MASAPI.Repositories
{
	public interface IHealthcareDbRepositories
	{
		Task<Person> GetPatientFromDbAsync(int ID);
		Task<ICollection<Hospital>> GetHospitalsFromDbAsync();
		Task<bool> DeleteDoctor(int IdDoctor);
		Task<DoctorHospital> AssignDoctorToHospital(int IdHospital, DoctorDTO doctor);
	}
}
