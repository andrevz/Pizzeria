using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Configuration.Entities;

public class BranchScheduleConfiguration : IEntityTypeConfiguration<BranchSchedule>
{
    public void Configure(EntityTypeBuilder<BranchSchedule> builder)
    {
        builder.ToTable("branch_schedules");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("branch_schedule_id");
        
        builder.Property(p => p.Day)
            .HasColumnName("day_of_week");

        builder.Property(p => p.OpensAt)
            .HasColumnName("opens_at")
            .IsRequired();
        
        builder.Property(p => p.ClosedAt)
            .HasColumnName("closed_at")
            .IsRequired();
        
        builder.Property(p => p.BranchId)
            .HasColumnName("branch_id")
            .IsRequired();
        
        builder.HasOne(p => p.Branch)
            .WithMany(b => b.Schedules)
            .HasForeignKey(p => p.BranchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}