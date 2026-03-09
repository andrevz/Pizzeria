namespace Pizzeria.Domain.Entities;

public class BranchSchedule
{
    public DayOfWeek Day { get; set; }
    public TimeOnly OpensAt { get; set; }
    public TimeOnly ClosedAt { get; set; }

    private BranchSchedule(DayOfWeek day, TimeOnly opensAt, TimeOnly closedAt)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(opensAt, closedAt);
        
        Day = day;
        OpensAt = opensAt;
        ClosedAt = closedAt;
    }

    public static BranchSchedule Create(DayOfWeek day, TimeOnly opensAt, TimeOnly closedAt)
    {
        return new BranchSchedule(day, opensAt, closedAt);
    }
}