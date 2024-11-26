using System;
using System.Globalization;

public class ParsingExample
{
    public static void Main(string[] args)
    {
        string dateString = "15/10/2024";
        string intString = "12345";
        string doubleString = "3.14159";
        string badDateString = "15-10-2024"; //Неверный формат для ParseExact
        string badIntString = "123abc";     //Неверный формат для Parse

        // ParseExact() -  строгое преобразование с указанным форматом
        try
        {
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine($"ParseExact: {date}");
            DateTime date2 = DateTime.ParseExact(badDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine($"ParseExact (bad format): {date2}"); //Вызовет FormatException
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка ParseExact: {ex.Message}");
        }

        // Parse() - преобразование с автоматическим определением формата
        try
        {
            DateTime date = DateTime.Parse(dateString); //Может определить формат автоматически
            Console.WriteLine($"Parse: {date}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка Parse: {ex.Message}");
        }

        // TryParse() - попытка преобразования без исключений
        if (int.TryParse(intString, out int parsedInt))
        {
            Console.WriteLine($"TryParse (int): {parsedInt}");
        }
        else
        {
            Console.WriteLine($"TryParse (int): Не удалось преобразовать.");
        }
        if (int.TryParse(badIntString, out int parsedBadInt))
        {
            Console.WriteLine($"TryParse (int, bad format): {parsedBadInt}");
        }
        else
        {
            Console.WriteLine($"TryParse (int, bad format): Не удалось преобразовать.");
        }
        if (double.TryParse(doubleString, out double parsedDouble))
        {
            Console.WriteLine($"TryParse (double): {parsedDouble}");
        }
        else
        {
            Console.WriteLine($"TryParse (double): Не удалось преобразовать.");
        }


        // TryParseExact() - попытка преобразования с указанным форматом без исключений
        if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            Console.WriteLine($"TryParseExact: {parsedDate}");
        }
        else
        {
            Console.WriteLine($"TryParseExact: Не удалось преобразовать.");
        }

        if (DateTime.TryParseExact(badDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedBadDate))
        {
            Console.WriteLine($"TryParseExact (bad format): {parsedBadDate}");
        }
        else
        {
            Console.WriteLine($"TryParseExact (bad format): Не удалось преобразовать.");
        }
    }
}
