// 15. Создать консольное приложение, в котором объявить метод генерирующих массив из случайных чисел (0 - 1000). Размерность массива задается случайно (10 млн – 15 млн записей). Массив необходимо отсортировать по возрастанию и найти в массиве количество элементов, равных Х (значение Х передается в виде параметра в метод). Запустить данный метод в 10 одновременно выполняющихся потоках (из пула потоков) и посчитать минимальное, максимальное и среднее время выполнения метода. 

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MultiThreadedArrayProcessing
{
    class Program
    {
        // Метод для обработки массива
        public static (int count, long elapsedMs) ProcessArray(int x, Random rand)
        {
            Stopwatch sw = Stopwatch.StartNew();

            // Генерация случайной длины от 10 до 15 миллионов
            int length = rand.Next(10_000_000, 15_000_001);
            int[] array = new int[length];

            // Заполнение массива случайными числами
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(0, 1001);
            }

            // Сортировка
            Array.Sort(array);

            // Поиск количества элементов, равных X
            int count = 0;
            foreach (var value in array)
            {
                if (value == x) count++;
            }

            sw.Stop();
            return (count, sw.ElapsedMilliseconds);
        }

        static async Task Main(string[] args)
        {
            const int taskCount = 10;
            var tasks = new Task<(int count, long timeMs)>[taskCount];
            var rand = new Random();

            Console.WriteLine("Запуск задач...");

            // Создаем и запускаем задачи
            for (int i = 0; i < taskCount; i++)
            {
                int x = rand.Next(0, 1001); // X — случайное число от 0 до 1000
                int localSeed = rand.Next(); // Чтобы избежать проблем с одинаковым Random в разных потоках

                tasks[i] = Task.Run(() =>
                {
                    return ProcessArray(x, new Random(localSeed));
                });
            }

            long[] times = new long[taskCount];

            // Ждём завершения всех задач и собираем результаты
            for (int i = 0; i < taskCount; i++)
            {
                var result = await tasks[i];
                times[i] = result.timeMs;
                Console.WriteLine($"Задача {i + 1}: Найдено {result.count} элементов. Время: {times[i]} мс");
            }

            // Вычисляем статистику
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;
            long totalTime = 0;

            foreach (var t in times)
            {
                minTime = Math.Min(minTime, t);
                maxTime = Math.Max(maxTime, t);
                totalTime += t;
            }

            double avgTime = (double)totalTime / taskCount;

            Console.WriteLine("\nСтатистика времени выполнения:");
            Console.WriteLine($"Минимальное время: {minTime} мс");
            Console.WriteLine($"Максимальное время: {maxTime} мс");
            Console.WriteLine($"Среднее время: {avgTime:F2} мс");
        }
    }
}