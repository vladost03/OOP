interface INumber
{
    int ToInt();
}

class ArabicNumber : INumber
{
    private int value;

    public ArabicNumber(int value)
    {
        this.value = value;
    }

    public int ToInt()
    {
        return value;
    }
}

class RomanNumber : INumber
{
    private string value;
    private static readonly Dictionary<char, int> romanNumerals = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    public RomanNumber(string value)
    {
        this.value = value.ToUpper();
    }

    public int ToInt()
    {
        int result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            if (i > 0 && romanNumerals[value[i]] > romanNumerals[value[i - 1]])
            {
                result += romanNumerals[value[i]] - 2 * romanNumerals[value[i - 1]];
            }
            else
            {
                result += romanNumerals[value[i]];
            }
        }
        return result;
    }
}

class TextNumber : INumber
{
    private string value;
    private static readonly Dictionary<string, int> textNumbers = new Dictionary<string, int>()
    {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9},
        {"zero", 0}
    };

    public TextNumber(string value)
    {
        this.value = value.ToLower();
    }

    public int ToInt()
    {
        if (textNumbers.ContainsKey(value))
        {
            return textNumbers[value];
        }
        else
        {
            throw new ArgumentException("Invalid text number: " + value);
        }
    }
}

class NumberCalculator
{
    public static int Sum(INumber num1, INumber num2)
    {
        return num1.ToInt() + num2.ToInt();
    }

    public static int Difference(INumber num1, INumber num2)
    {
        return num1.ToInt() - num2.ToInt();
    }
}

class MainCode
{
    static void Main(string[] args)
    {
        Console.WriteLine("Arabic numbers: ");
        Console.WriteLine("Enter first number:");
        int a1 = Convert.ToInt32(Console.ReadLine());
        ArabicNumber arabic1 = new ArabicNumber(a1);
        Console.WriteLine("Enter second number:");
        int a2 = Convert.ToInt32(Console.ReadLine());
        ArabicNumber arabic2 = new ArabicNumber(a2);
        Console.WriteLine("Sum of Arabic numbers: " + NumberCalculator.Sum(arabic1, arabic2));
        Console.WriteLine("Difference of Arabic numbers: " + NumberCalculator.Difference(arabic1, arabic2));
        
        Console.WriteLine("Roman numbers: ");
        Console.WriteLine("Enter first number:");
        string r1 = Convert.ToString(Console.ReadLine());
        RomanNumber roman1 = new RomanNumber(r1);
        Console.WriteLine("Enter second number:");
        string r2 = Convert.ToString(Console.ReadLine());
        RomanNumber roman2 = new RomanNumber(r2);
        Console.WriteLine("Sum of Roman numbers: " + NumberCalculator.Sum(roman1, roman2));
        Console.WriteLine("Difference of Roman numbers: " + NumberCalculator.Difference(roman1, roman2));


        Console.WriteLine("Text numbers: ");
        Console.WriteLine("Enter first number:");
        string t1 = Convert.ToString(Console.ReadLine());
        TextNumber text1 = new TextNumber(t1);
        Console.WriteLine("Enter second number:");
        string t2 = Convert.ToString(Console.ReadLine());
        TextNumber text2 = new TextNumber(t2);
        Console.WriteLine("Sum of text numbers: " + NumberCalculator.Sum(text1, text2));
        Console.WriteLine("Difference of text numbers: " + NumberCalculator.Difference(text1, text2));

        // Invalid text number
        try
        {
            TextNumber text3 = new TextNumber("dozen");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


}

