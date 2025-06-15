// 3.	Создать консольное приложение, в котором объявить метод расчета медианного значения в целочисленном массиве, который передается в виде параметра в метод. Размерность массива задается пользователем с клавиатуры, массив заполняется случайными числами от 0 до значения размерности массива. 

using System;

namespace MedianApp
{
    class Program
    {
        // Метод для вычисления медианы
        static double CalculateMedian(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Массив не должен быть пустым.");

            Array.Sort(numbers);

            int n = numbers.Length;
            int mid = n / 2;

            if (n % 2 == 0)
            {
                // Если количество элементов четное — среднее двух центральных
                return (numbers[mid - 1] + numbers[mid]) / 2.0;
            }
            else
            {
                // Если нечетное — просто центральный элемент
                return numbers[mid];
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();

            // Ввод размера массива
            Console.Write("Введите размер массива: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Неверный ввод. Пожалуйста, введите положительное число: ");
            }

            // Создание и заполнение массива случайными числами
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(0, n + 1); // [0; n]
            }

            // Вывод массива
            Console.WriteLine("\nСгенерированный массив:");
            Console.WriteLine(string.Join(", ", array));

            // Вычисление медианы
            double median = CalculateMedian(array);
            Console.WriteLine($"\nМедиана: {median}");
        }
    }
}