// 13. Создайте консольное приложение, определите класс с автоматическим свойством Counter (целочисленное) и статическим полем, помеченным атрибутом [ThreadStatic], для подсчёта вызовов метода в каждом потоке. Реализуйте метод, увеличивающий это поле и выводящий его значение. Запустите метод в 3 потоках из пула потоков, каждый из которых вызывает метод 5 раз. Выведите значения счётчика для каждого потока, демонстрируя независимость [ThreadStatic].

using System;
using System.Threading;

namespace ThreadStaticCounterApp
{
    public class CounterClass
    {
        // Автоматическое свойство
        public int Counter { get; set; }

        // Статическое поле с [ThreadStatic], уникальное для каждого потока
        [ThreadStatic]
        private static int threadSpecificCounter;

        // Метод, который будет выполняться в каждом потоке
        public void IncrementCounter()
        {
            threadSpecificCounter++;
            Console.WriteLine($"Поток ID: {Thread.CurrentThread.ManagedThreadId}, " +
                              $"Значение счетчика потока: {threadSpecificCounter}, " +
                              $"Значение свойства Counter: {Counter}");
        }
    }

    class Program
    {
        // Метод, который будет вызываться из потоков
        public static void ThreadMethod(object obj)
        {
            var counter = (CounterClass)obj;

            for (int i = 0; i < 5; i++)
            {
                counter.IncrementCounter();
                Thread.Sleep(50); // небольшая пауза для наглядности вывода
            }
        }

        static void Main(string[] args)
        {
            // Создаём три экземпляра класса
            var counter1 = new CounterClass();
            var counter2 = new CounterClass();
            var counter3 = new CounterClass();

            // Запускаем по 5 вызовов метода IncrementCounter() в каждом потоке
            ThreadPool.QueueUserWorkItem(ThreadMethod, counter1);
            ThreadPool.QueueUserWorkItem(ThreadMethod, counter2);
            ThreadPool.QueueUserWorkItem(ThreadMethod, counter3);

            // Ждём немного, чтобы дать время выполниться потокам
            Thread.Sleep(1000);
        }
    }
}