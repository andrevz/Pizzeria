using Pizzeria.Domain.Entities;
using Pizzeria.Domain.Enums;

namespace Pizzeria.Application.DTOs.Response.Branch;

public class BranchResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string CountryCode { get; set; }
    public required string NationalNumber { get; set; }
    public string? Extension { get; set; }
    public PhoneNumberType PhoneType { get; set; }
    public bool IsOpen { get; set; }
    public IEnumerable<BranchSchedule> Schedules { get; set; } = [];
}
