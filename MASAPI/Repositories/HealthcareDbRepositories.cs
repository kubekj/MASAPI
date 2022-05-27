using System;
using MASAPI.DTOs;
using MASAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MASAPI.Repositories
{
    public class HealthcareDbRepositories : IHealthcareDbRepositories
    {
        private readonly HealthcareContext _context;

        public HealthcareDbRepositories(HealthcareContext context)
        {
            _context = context;
        }

        public async Task<DoctorHospital> AssignDoctorToHospital(int IdHospital, DoctorDTO doctor)
        {
            var doesHospitalExists = await _context.Hospitals.AnyAsync(x => x.ID == IdHospital);

            if (!doesHospitalExists)
                return null;

            var isDocAlreadyAssignedInThisHospital =  await _context.DoctorHospitals.Where(x => x.IdHospital == IdHospital).ToListAsync();

            foreach (var item in isDocAlreadyAssignedInThisHospital)
            {
                if (item.IdDoctor == doctor.ID)
                    return null;
            }

            var doesDocExists = await _context.Doctors.AnyAsync(x => x.ID == doctor.ID);

            if (!doesDocExists)
            {
                var newDoc = await _context.Doctors.AddAsync(new Doctor
                {
                    ID = _context.Doctors.Max(x => x.ID) + 1,
                    Name = doctor.Name,
                    Surname = doctor.Surname,
                    Gender = doctor.Gender,
                    PhoneNumber = doctor.PhoneNumber,
                    HireDate = doctor.HireDate,
                    Title = doctor.Title
                });
            }

            await _context.SaveChangesAsync();

            var getDoctor = await _context.Doctors.SingleOrDefaultAsync(x => x.Surname == doctor.Surname);

            if (getDoctor == null)
                return null;

            var addDoctorToHospital = await _context.DoctorHospitals.AddAsync(new DoctorHospital
            {
                IdDoctor = getDoctor.ID,
                IdHospital = IdHospital
            });

            await _context.SaveChangesAsync();

            return addDoctorToHospital.Entity;
        }

        public async Task<bool> DeleteDoctor(int IdDoctor)
        {
            var isDoctorHired = await _context.Doctors.SingleOrDefaultAsync(x => x.ID == IdDoctor);

            if (isDoctorHired == null)
                return false;

            _context.Doctors.Remove(isDoctorHired);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<Hospital>> GetHospitalsFromDbAsync()
        {
            var result = await _context.Hospitals
                .Include(x => x.Patients)
                .Include(x => x.Doctors)
                .ToListAsync();

            return result;
        }

        public async Task<Person> GetPatientFromDbAsync(int ID)
        {
            var result = await _context.Patients
               .Where(x => x.ID == ID)
               .SingleOrDefaultAsync();

            return result;
        }
    }
}

