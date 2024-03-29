﻿public class TArray
{
    private double[] arr;
    public TArray()
    {

    }
    public void setprintArray()
    {
        Console.WriteLine("Введiть кiлькiсть елементiв масиву: ");
        int n = Convert.ToInt32(Console.ReadLine());
        this.arr = new double[n];
        Console.WriteLine("Введiть елементи масиву (Enter - наступний елемент): ");
        for (int i = 0; i < n; i++)
            arr[i] = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Масив: ");
        for (int i = 0; i < n; i++)
            Console.WriteLine(arr[i]);
    }
    public int Task11()
    {
        int firstpositive = 0;
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 0)
            {
                firstpositive = i;
                break;
            }
        }
        for(int i = firstpositive + 1; i < arr.Length; i++)
        {
            if (arr[i] < 0)
                count +=1;
        }
       return count;
    }
    public void Task12(TArray a, TArray b, TArray c)
    {
        double[] newarr = new double[a.arr.Length];
        for (int i = 0; i < a.arr.Length; i++)
            newarr[i] = a.arr[i] - 3 * b.arr[i] + 2 * c.arr[i];
        Console.WriteLine("a - 3*b + 2*c = ");
        for (int i = 0; i < newarr.Length; i++)
            Console.WriteLine(newarr[i]);
    }
    public void Task13()
    {
        int count = 0;
        for (int i = 0; i<arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                arr[count]= arr[i];
                count += 1;
            }
        }
        while (count < arr.Length)
        {
            arr[count] = 0;
            count += 1;
        }
        Console.WriteLine("Новий масив");
        for (int i = 0; i < arr.Length; i++)
            Console.WriteLine(arr[i]);
    }
}
public class TMatrix
{
    private int x;
    private int y;
    private double[,] matrix;
    private double[,] smoothedMatrix;
    public TMatrix()
    {

    }
    public void setMatrix(int x, int y)
    {
        this.x = x;
        this.y = y;
        matrix = new double[x, y];
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++)
                matrix[i, j] = Convert.ToDouble(Console.ReadLine());
    }
    public void printMatrix()
    {
        Console.WriteLine("Матриця: ");
        var m = 0;
        while (m < matrix.GetLength(0))
        {
            var n = 0;
            while (n < matrix.GetLength(1))
            {
                Console.Write("{0}\t", matrix[m, n]);
                n++;
            }
            m++;
            Console.WriteLine();
        }
        Console.WriteLine(" ");
    }
    public void Task21()
    {
        double[] diagonal = new double[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            diagonal[i] = matrix[i, i];
        }

        Array.Sort(diagonal);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[i, i] = diagonal[i];
        }
        printMatrix();
    }
    public void Task22()
    {
        smoothedMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                double sum = 0;
                int count = 0;

                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        int neighborRow = i + x;
                        int neighborColumn = j + y;

                        if (neighborRow >= 0 && neighborRow < matrix.GetLength(0) &&
                            neighborColumn >= 0 && neighborColumn < matrix.GetLength(1) &&
                            !(x == 0 && y == 0))
                        {
                            sum += matrix[neighborRow, neighborColumn];
                            count++;
                        }
                    }
                }
                smoothedMatrix[i, j] = (int)Math.Round((double)sum / count);
            }
        }
        Console.WriteLine("Згладжена матриця: ");
        var m = 0;
        while (m < smoothedMatrix.GetLength(0))
        {
            var n = 0;
            while (n < smoothedMatrix.GetLength(1))
            {
                Console.Write("{0}\t", smoothedMatrix[m, n]);
                n++;
            }
            m++;
            Console.WriteLine();
        }
        Console.WriteLine(" ");
    }
    public void Task23()
    {
        Task22();
        double underd = 0;

        for (int i = 1; i < smoothedMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < i; j++)
            {
                underd += Math.Abs(smoothedMatrix[i, j]);
            }
        }

        Console.WriteLine("Сума модулiв нижче дiагоналi:" + underd);
    }
}
class MainCode
{
    static void Main(string[] args)
    {
        Console.WriteLine("Завдання 1.1: ");
        TArray array = new TArray();
        array.setprintArray();
        Console.WriteLine("кiлькiсть -елементiв пiсля першого додатнього: ");
        Console.WriteLine(array.Task11());
        Console.WriteLine("Завдання 1.2: ");
        Console.WriteLine("Масив a: ");
        TArray a = new TArray();
        a.setprintArray();
        Console.WriteLine("Масив b: ");
        TArray b = new TArray();
        b.setprintArray();
        Console.WriteLine("Масив c: ");
        TArray c = new TArray();
        c.setprintArray();
        a.Task12(a, b, c);
        Console.WriteLine("Завдання 1.3: ");
        TArray zeroend = new TArray();
        zeroend.setprintArray();
        zeroend.Task13();
        Console.WriteLine("Завдання 2.1: ");
        TMatrix matrix = new TMatrix();
        Console.WriteLine("Введiть довжину матрицi: ");
        int l = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введiть елементи матрицi: ");
        matrix.setMatrix(l, l);
        matrix.printMatrix();
        matrix.Task21();
        Console.WriteLine("Завдання 2.2: ");
        Console.WriteLine("Введiть ширину матрицi: ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введiть довжину матрицi: ");
        int y = Convert.ToInt32(Console.ReadLine());
        TMatrix m = new TMatrix();
        Console.WriteLine("Введiть елементи матрицi: ");
        m.setMatrix(x, y);
        m.printMatrix();
        m.Task22();
        Console.WriteLine("Завдання 2.3: ");
        Console.WriteLine("Введiть ширину матрицi: ");
        int width = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введiть довжину матрицi: ");
        int length = Convert.ToInt32(Console.ReadLine());
        TMatrix d = new TMatrix();
        Console.WriteLine("Введiть елементи матрицi: ");
        d.setMatrix(width, length);
        d.printMatrix();
        d.Task23();
    }
}
