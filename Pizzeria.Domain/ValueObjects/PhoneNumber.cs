using Pizzeria.Domain.Enums;

namespace Pizzeria.Domain.ValueObjects;

public record PhoneNumber
{
    public string CountryCode { get; init; }
    public string NationalNumber { get; init; }
    public string? Extension { get; init; }
    public PhoneNumberType Type { get; init; }

    private PhoneNumber(string countryCode, string nationalNumber, string? extension, PhoneNumberType type)
    {
        if (!IsValidCountryCode(countryCode))
        {
            throw new ArgumentException($"Invalid country code: {countryCode}");
        }

        if (!IsValidNationalNumber(nationalNumber))
        {
            throw new ArgumentException($"Invalid national number: {nationalNumber}");
        }

        if (type == PhoneNumberType.LandLine && string.IsNullOrWhiteSpace(extension))
        {
            throw new ArgumentException($"Extension is required for local numbers");
        }
        
        CountryCode = countryCode;
        NationalNumber = nationalNumber;
        Extension = extension;
        Type = type;
    }
    
    private static bool IsValidCountryCode(string countryCode) =>
        !string.IsNullOrWhiteSpace(countryCode) && countryCode.Length <= 3 && countryCode.All(char.IsDigit);
    
    private static bool IsValidNationalNumber(string? nationalNumber) =>
        !string.IsNullOrWhiteSpace(nationalNumber) && nationalNumber.Length is >= 7 and <= 12 && nationalNumber.All(char.IsDigit);

    public static PhoneNumber Create(string countryCode, string nationalNumber,  string? extension, PhoneNumberType type)
    {
        return new PhoneNumber(countryCode, nationalNumber, extension, type);
    }
}