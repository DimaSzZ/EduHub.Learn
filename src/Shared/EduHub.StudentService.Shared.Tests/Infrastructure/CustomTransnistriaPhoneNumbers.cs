namespace EduHub.StudentService.Shared.Tests.Infrastructure;

public static class CustomTransnistriaPhoneNumbers
{
    private static readonly Random Random = new Random();
    
    public static string GenerateTransnistriaPhoneNumber()
    {
        var prefix = "+373";
        var region = Random.Next(0, 2) == 0 ? "2" : (Random.Next(0, 2) == 0 ? "6" : "7"); // Randomly choose between "2", "6", or "7"
        var number = region + GenerateDigits(7);
        
        return prefix + number;
    }
    
    private static string GenerateDigits(int count)
    {
        var digits = "";
        for (int i = 0; i < count; i++)
        {
            digits += Random.Next(0, 10).ToString();
        }
        
        return digits;
    }
}