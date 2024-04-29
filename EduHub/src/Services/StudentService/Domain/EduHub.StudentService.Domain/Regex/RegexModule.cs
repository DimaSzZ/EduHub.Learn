using System.Text.RegularExpressions;

public static class RegexModule
{
    public static void ValidateSegmentFullName(string segmentFullName, string segmentFullNameParamet)
    {
        var regex = new Regex(@"^[a-zA-Z]+$");
        if (!regex.IsMatch(segmentFullName))
        {
            throw new ArgumentException($"Fullname part '{segmentFullName}' contains invalid characters.", segmentFullNameParamet);
        }
    }

    public static void ValidateEmail(string emailValue, string emailValueParametr)
    {
        var regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        if (!regex.IsMatch(emailValue))
        {
            throw new ArgumentException($"emailValue '{emailValue}' contains invalid characters.", emailValueParametr);
        }
    }

    public static void ValidatePhoneNumber(string phoneNumberValue, string phoneNumberValueParametr)
    {
        var regex = new Regex(@"^\+373(?:6|7)[0-9]{7}$");
        if (!regex.IsMatch(phoneNumberValue))
        {
            throw new ArgumentException($"emailValue '{phoneNumberValue}' contains invalid characters.", phoneNumberValueParametr);
        }
    }
}