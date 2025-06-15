// 14. Создать консольное приложение с асинхронным методом, который принимает целое число n и асинхронно вычисляет сумму квадратов чисел от 1 до n, разбивая задачу на 3 параллельные подзадачи (каждая обрабатывает треть диапазона) с использованием Task.Run и Task.Delay(100) для имитации продолжительности вычисления. Результаты выполнения подазадач объединить с помощью Task.WhenAll. Если переданное значение n<=0, то метод должен завершиться с пользовательским исключением InvalidInputException

using System;
using System.Threading.Tasks;

namespace AsyncSumOfSquaresApp
{
    // Пользовательское исключение
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Ошибка: Введено недопустимое значение n. Должно быть больше 0.")
        {
        }
    }

    class Program
    {
        // Асинхронный метод вычисления суммы квадратов
        public static async Task<int> CalculateSumOfSquaresAsync(int n)
        {
            if (n <= 0)
                throw new InvalidInputException();

            // Разбиваем диапазон на 3 части
            int partSize = n / 3;

            // Первая часть: от 1 до partSize
            var task1 = Task.Run(async () =>
            {
                await Task.Delay(100); // имитация длительной операции
                int sum = 0;
                for (int i = 1; i <= partSize; i++)
                    sum += i * i;
                return sum;
            });

            // Вторая часть: от partSize+1 до partSize*2
            var task2 = Task.Run(async () =>
            {
                await Task.Delay(100);
                int start = partSize + 1;
                int end = partSize * 2;
                int sum = 0;
                for (int i = start; i <= end; i++)
                    sum += i * i;
                return sum;
            });

            // Третья часть: от partSize*2+1 до n
            var task3 = Task.Run(async () =>
            {
                await Task.Delay(100);
                int start = partSize * 2 + 1;
                int sum = 0;
                for (int i = start; i <= n; i++)
                    sum += i * i;
                return sum;
            });

            // Ожидаем завершения всех задач
            var results = await Task.WhenAll(task1, task2, task3);

            // Суммируем результаты
            return results[0] + results[1] + results[2];
        }

        static async Task Main(string[] args)
        {
            Console.Write("Введите число n > 0: ");
            string input = Console.ReadLine();
            int n;

            if (!int.TryParse(input, out n))
            {
                Console.WriteLine("Ошибка: Введите корректное целое число.");
                return;
            }

            try
            {
                int result = await CalculateSumOfSquaresAsync(n);
                Console.WriteLine($"Сумма квадратов от 1 до {n} равна: {result}");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}