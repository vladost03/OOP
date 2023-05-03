class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Зчитуємо дані з файлу
        string[] input = File.ReadAllLines("C:/Users/T14/Documents/input.txt");

        // Створюємо словник, де ключами є назви місяців, а значеннями - масиви температур
        Dictionary<string, double[]> temperatures = new Dictionary<string, double[]>();

        for (int i = 0; i < 12; i++)
        {
            string[] monthData = input[i].Split(' ');

            // Заповнюємо масив температур для поточного місяця
            double[] monthTemperatures = new double[30];
            for (int j = 0; j < 30; j++)
            {
                monthTemperatures[j] = double.Parse(monthData[j]);
            }

            // Додаємо масив температур до словника за назвою місяця
            temperatures.Add(GetMonthName(i + 1), monthTemperatures);
        }

        // Обчислюємо середню температуру для кожного місяця та виводимо її на екран
        Console.WriteLine("Список середніх температур:");
        foreach (KeyValuePair<string, double[]> monthTemperatures in temperatures)
        {
            double averageTemperature = GetAverageTemperature(monthTemperatures.Value);
            Console.WriteLine("{0}: {1}", monthTemperatures.Key, averageTemperature);
        }

        // Сортуємо словник за значеннями (середніми температурами) та виводимо його на екран
        var sortedTemperatures = from pair in temperatures
                                 orderby GetAverageTemperature(pair.Value)
                                 select pair;

        Console.WriteLine(" ");
        Console.WriteLine("Сортований список середніх температур:");
        foreach (KeyValuePair<string, double[]> monthTemperatures in sortedTemperatures)
        {
            double averageTemperature = GetAverageTemperature(monthTemperatures.Value);
            Console.WriteLine("{0}: {1}", monthTemperatures.Key, averageTemperature);
        }

        Console.ReadKey();
    }

    // Повертає назву місяця за номером (1-січень, 2-лютий, тощо)
    static string GetMonthName(int monthNumber)
    {
        DateTime date = new DateTime(2000, monthNumber, 1);
        return date.ToString("MMMM");
    }

    // Обчислює середню температуру за масивом температур
    static double GetAverageTemperature(double[] temperatures)
    {
        double sum = 0.0;
        foreach (double temperature in temperatures)
        {
            sum += temperature;
        }
        return Math.Round(sum / temperatures.Length, 2);
    }
}

