using System;
using MASAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASAPI.Configuration
{
	public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
	{
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.ID)
               .HasName("Patient_PK");

            builder.Property(e => e.ID).UseIdentityColumn();

            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

            builder.Property(e => e.MiddleName).HasMaxLength(50);

            builder.Property(e => e.Surname).HasMaxLength(50).IsRequired();

            builder.Property(e => e.Gender).HasMaxLength(1).IsRequired();

            builder.Property(e => e.PhoneNumber).HasMaxLength(9).IsRequired();

            builder.Property(e => e.Accepted).IsRequired();

            builder.Property(e => e.Sickness).HasMaxLength(100).IsRequired();

            builder.HasOne(d => d.IdHospitalNavigation)
              .WithMany(d => d.Patients)
              .HasForeignKey(d => d.IdHospital)
              .OnDelete(DeleteBehavior.Cascade);

            var patients = new List<Patient>();

            patients.Add(new Patient
            {
                ID = 1,
                Name = "Piotrek",
                Surname = "Zambrowski",
                Gender = 'M',
                PhoneNumber = "123789456",
                Accepted = DateTime.UtcNow,
                Sickness = "Too much alcohol",
                IdHospital = 1
            });

            patients.Add(new Patient
            {
                ID = 2,
                Name = "Angelika",
                Surname = "Patusiar",
                Gender = 'F',
                PhoneNumber = "456789123",
                Accepted = DateTime.UtcNow,
                Sickness = "Too much weed",
                IdHospital = 2
            });

            builder.HasData(patients);
        }
    }
}

