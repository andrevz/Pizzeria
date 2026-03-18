using System.ComponentModel.DataAnnotations;
using Pizzeria.Domain.Enums;

namespace Pizzeria.Application.DTOs.Request.Branch;

public record UpdateBranchRequest(
    [Required] string Name,
    [Required] string Address,
    [Required] string CountryCode,
    [Required] string NationalNumber,
    string Extension,
    PhoneNumberType PhoneType,
    bool IsOpen);
