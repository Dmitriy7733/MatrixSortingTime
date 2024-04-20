using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите размер матрицы (количество строк и столбцов):");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        // Заполнение матрицы случайными числами
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = random.Next(100); // случайное число от 0 до 99
            }
        }

        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Сортировка матрицы по столбцам
        for (int j = 0; j < n; j++)
        {
            int[] column = new int[n];
            for (int i = 0; i < n; i++)
            {
                column[i] = matrix[i, j];
            }
            Array.Sort(column);
            for (int i = 0; i < n; i++)
            {
                matrix[i, j] = column[i];
            }
        }

        stopwatch.Stop();

        Console.WriteLine("Отсортированная матрица:");
        PrintMatrix(matrix);

        Console.WriteLine($"Время, потраченное на сортировку: {stopwatch.Elapsed}");
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
