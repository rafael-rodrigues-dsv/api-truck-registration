using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Entities.Enums;

namespace TruckRegistration.Infra.Data.Mappings
{
    public class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Truck");

            builder.Property(c => c.Id)
               .HasColumnName("Id")
               .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.Description)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Model)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .HasConversion(
                    v => v.ToString(),
                    v => (EModel)Enum.Parse(typeof(EModel), v))
                .IsRequired();

            builder.Property(c => c.ManufactureYear)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.ModelYear)
                .HasColumnType("int")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Renavam)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Color)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
