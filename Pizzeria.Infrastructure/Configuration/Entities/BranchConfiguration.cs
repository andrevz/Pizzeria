using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Configuration.Entities;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("branches");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("branch_id");
        
        builder.HasMany(p => p.Schedules)
            .WithOne(p => p.Branch)
            .HasForeignKey(p => p.BranchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Address)
            .HasColumnName("address")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(p => p.IsOpen)
            .HasColumnName("is_open");

        builder.OwnsOne(p => p.Phone, phone =>
        {
            phone.Property(p => p.CountryCode)
                .HasColumnName("country_code")
                .HasMaxLength(3)
                .IsRequired();

            phone.Property(p => p.NationalNumber)
                .HasColumnName("national_number")
                .HasMaxLength(12)
                .IsRequired();

            phone.Property(p => p.Extension)
                .HasColumnName("extension")
                .HasMaxLength(5);

            phone.Property(p => p.PhoneType)
                .HasColumnName("phone_type");
        });
        
        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .IsRequired();
        
        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at");
    }
}