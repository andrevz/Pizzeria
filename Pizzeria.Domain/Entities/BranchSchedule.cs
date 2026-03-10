namespace Pizzeria.Domain.Entities;

public class BranchSchedule : BaseEntity
{
    public DayOfWeek Day { get; private set; }
    public TimeOnly OpensAt { get; private set; }
    public TimeOnly ClosedAt { get; private set; }
    
    public Guid BranchId { get; init; }
    public Branch Branch { get; init; } = null!;

    private BranchSchedule() { }

    private BranchSchedule(Guid branchId, DayOfWeek day, TimeOnly opensAt, TimeOnly closedAt)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(opensAt, closedAt);
        
        Day = day;
        OpensAt = opensAt;
        ClosedAt = closedAt;
        BranchId = branchId;
    }

    public static BranchSchedule Create(Guid branchId, DayOfWeek day, TimeOnly opensAt, TimeOnly closedAt)
    {
        return new BranchSchedule(branchId, day, opensAt, closedAt);
    }
}