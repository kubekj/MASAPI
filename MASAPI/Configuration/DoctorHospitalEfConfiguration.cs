using System;
using MASAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASAPI.Configuration
{
	public class DoctorHospitalEfConfiguration : IEntityTypeConfiguration<DoctorHospital>
	{
        public void Configure(EntityTypeBuilder<DoctorHospital> builder)
        {
            builder.HasKey(e => new { e.IdDoctor, e.IdHospital })
                .HasName("DoctorHospital_PK");

            builder.ToTable("Doctor_Hospital");

            builder.HasOne(d => d.IdDoctorNavigation)
                .WithMany(d => d.Hospitals)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.IdHospitalNavigation)
                .WithMany(d => d.Doctors)
                .HasForeignKey(d => d.IdHospital)
                .OnDelete(DeleteBehavior.Cascade);

            var doctorHospitals = new List<DoctorHospital>();

            doctorHospitals.Add(new DoctorHospital { IdDoctor = 1, IdHospital = 2 });
            doctorHospitals.Add(new DoctorHospital { IdDoctor = 2, IdHospital = 1 });

            builder.HasData(doctorHospitals);
        }
    }
}

