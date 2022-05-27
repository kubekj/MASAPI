using System;
using MASAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MASAPI.Configuration
{
	public class HospitalEfConfiguration : IEntityTypeConfiguration<Hospital>
	{
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.HasKey(e => e.ID)
                .HasName("Hospital_PK");

            builder.Property(e => e.ID).UseIdentityColumn();

            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

            builder.Property(e => e.Address).HasMaxLength(50).IsRequired();

            builder.Property(e => e.PhoneNumber).HasMaxLength(50).IsRequired();

            var hospitals = new List<Hospital>();

            hospitals.Add(new Hospital
            {
                ID = 1,
                Name = "Onkologiczny",
                Address = "Cybernetyki",
                PhoneNumber = "123456789"
            });

            hospitals.Add(new Hospital
            {
                ID = 2,
                Name = "Psychologiczny",
                Address = "Ameryki",
                PhoneNumber = "987654321"
            });

            builder.HasData(hospitals);
        }
    }
}

