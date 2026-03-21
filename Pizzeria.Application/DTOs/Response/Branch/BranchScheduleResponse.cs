namespace Pizzeria.Application.DTOs.Response.Branch;

public class BranchScheduleResponse
{
    public Guid Id { get; set; }
    public DayOfWeek Day { get; set; }
    public TimeOnly OpensAt { get; set; }
    public TimeOnly ClosesAt { get; set; }
}