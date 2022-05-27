using System;
using MASAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASAPI.Configuration
{
	public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
	{
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.ID)
                .HasName("Doctor_PK");

            builder.Property(e => e.ID).UseIdentityColumn();

            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

            builder.Property(e => e.MiddleName).HasMaxLength(50);

            builder.Property(e => e.Surname).HasMaxLength(50).IsRequired();

            builder.Property(e => e.Gender).HasMaxLength(1).IsRequired();

            builder.Property(e => e.PhoneNumber).HasMaxLength(9).IsRequired();

            builder.Property(e => e.HireDate).IsRequired();

            builder.Property(e => e.Title).HasMaxLength(30).IsRequired();

            var doctors = new List<Doctor>();

            doctors.Add(new Doctor
            {
                ID = 1,
                Name = "Artur",
                Surname = "Arturowski",
                Gender = 'M',
                PhoneNumber = "135792468",
                HireDate = DateTime.UtcNow,
                Title = "Habilitated Doctor"
            });

            doctors.Add(new Doctor
            {
                ID = 2,
                Name = "Agata",
                Surname = "Agatowska",
                Gender = 'F',
                PhoneNumber = "124578359",
                HireDate = DateTime.UtcNow,
                Title = "Licenced Doctor"
            });

            builder.HasData(doctors);
            
        }
    }
}

