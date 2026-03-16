using Pizzeria.Domain.Enums;

namespace Pizzeria.Application.DTOs.Request.Branch;

public class CreateBranchRequest
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string CountryCode { get; set; }
    public required string NationalNumber { get; set; }
    public string? Extension { get; set; }
    public PhoneNumberType PhoneType { get; set; }
    public bool IsOpen { get; set; }
}
