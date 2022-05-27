using System;
using MASAPI.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MASAPI.Models
{
    public class HealthcareContext : DbContext
    {
        public HealthcareContext() { }

        public HealthcareContext(DbContextOptions<HealthcareContext> options) : base(options) { }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<DoctorHospital> DoctorHospitals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql("Server = localhost; Port = 5432; Database = Healthcare; User Id = postgres; Password = admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorEfConfiguration());

            modelBuilder.ApplyConfiguration(new PatientEfConfiguration());

            modelBuilder.ApplyConfiguration(new HospitalEfConfiguration());

            modelBuilder.ApplyConfiguration(new DoctorHospitalEfConfiguration());
        }
    }
}

