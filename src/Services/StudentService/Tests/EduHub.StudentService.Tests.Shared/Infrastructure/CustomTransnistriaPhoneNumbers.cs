namespace EduHub.StudentService.Shared.Tests.Infrastructure
{
    public static class CustomTransnistriaPhoneNumbers
    {
        private static readonly Random Random = new Random();
        
        public static string GenerateTransnistriaPhoneNumber()
        {
            var prefix = "+373";
            var region = GetRandomRegion(); // Получаем случайный регион
            var number = region + GenerateDigits(4); // Генерируем оставшиеся четыре цифры
            
            return prefix + number;
        }
        
        private static string GetRandomRegion()
        {
            string[] regions = ["533", "555", "777", "778", "779", "791", "792", "793", "794", "795", "797", "798", "799"];
            return regions[Random.Next(regions.Length)];
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
}