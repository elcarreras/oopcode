// 17. Создать консольное приложение, в котором объявить метод (и запустить его в отдельном потоке (из пула потоков)) внутри которого запустить бесконечный цикл, который выводит на консоль сообщение каждый раз, когда пользователь нажимает Enter. Между нажатиями на Enter поток с бесконечным циклом замирает в ожидании действия пользователя. 

using System;
using System.Threading;

namespace ConsoleWaitOnEnter
{
    class Program
    {
        private static bool _exit = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Запуск фонового потока...");

            Thread thread = new Thread(BackgroundThreadMethod);
            thread.IsBackground = true;
            thread.Start();

            Console.WriteLine("Введите 'exit' для выхода.");

            while (true)
            {
                string input = Console.ReadLine();
                if (input?.Trim().ToLower() == "exit")
                {
                    _exit = true;
                    Console.WriteLine("Завершение программы...");
                    Thread.Sleep(500); // даём время потоку завершиться
                    break;
                }
            }
        }

        static void BackgroundThreadMethod()
        {
            while (!_exit)
            {
                Console.WriteLine("Ожидание нажатия Enter...");

                // Ждём Enter
                while (!_exit)
                {
                    var key = Console.ReadKey(true); // true - не отображать вводимый символ
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("Сообщение от потока");
                        break; // выходим из внутреннего цикла, продолжаем внешний
                    }
                }
            }

            Console.WriteLine("Фоновый поток завершил работу.");
        }
    }
}