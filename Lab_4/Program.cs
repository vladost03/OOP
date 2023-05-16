using System;
using System.Collections.Generic;
using System.IO;

class TemperatureAnalyzer
{
    private Dictionary<string, double[]> temperatures = new Dictionary<string, double[]>();

    public TemperatureAnalyzer(string filePath)
    {
        LoadTemperatureData(filePath);
    }

    private void LoadTemperatureData(string filePath)
    {
        string[] input = File.ReadAllLines(filePath);
        {
            for (int i = 1; i < 12; i++)
            {
                string[] monthData = input[i].Split(' ');
                double[] monthTemperatures = new double[30];
                for (int j = 0; j < 30; j++)
                {
                    monthTemperatures[j] = double.Parse(monthData[j]);
                }
                temperatures.Add(GetMonthName(i + 1), monthTemperatures);
            }
        }
    }

    public void PrintAverageTemperatures()
    {
        Console.WriteLine("Список середніх температур:");
        foreach (KeyValuePair<string, double[]> monthTemperatures in temperatures)
        {
            double averageTemperature = GetAverageTemperature(monthTemperatures.Value);
            Console.WriteLine("{0}: {1}", monthTemperatures.Key, averageTemperature);
        }
    }

    public void GetSortedAverageTemperatures()
    {
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
    }

    private string GetMonthName(int monthNumber)
    {
        return new DateTime(2000, monthNumber, 1).ToString("MMMM");
    }

    private double GetAverageTemperature(double[] temperatures)
    {
        double sum = 0.0;
        foreach (double temperature in temperatures)
        {
            sum += temperature;
        }
        return Math.Round(sum / temperatures.Length, 2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        TemperatureAnalyzer analyzer = new TemperatureAnalyzer("C:/Users/T14/Documents/input.txt");

        analyzer.PrintAverageTemperatures();
        Console.WriteLine(" ");
        analyzer.GetSortedAverageTemperatures();
    }
}