/* 10. Создать консольное приложение, в котором объявить два делегата для хранения ссылок на методы, обладающие следующими сигнатурами:
a.	void (int, string, bool)
b.	int (int[], double)
Реализовать методы, подходящие, описанным выше сигнатурам. Сохранить ссылки на данные в описанных делегатах. Вызвать методы используя созданные делегаты.
*/

using System;

namespace DelegateExampleApp
{
    class Program
    {
        // a. Делегат для метода void (int, string, bool)
        public delegate void DelegateA(int id, string name, bool isActive);

        // b. Делегат для метода int (int[], double)
        public delegate int DelegateB(int[] numbers, double threshold);

        static void Main(string[] args)
        {
            // Создаем делегаты и привязываем к методам
            DelegateA delA = new DelegateA(MethodAImplementation);
            DelegateB delB = new DelegateB(MethodBImplementation);

            // Вызываем методы через делегаты
            delA(10, "Test", true);

            int[] data = { 5, 12, 3, 8, 15 };
            int result = delB(data, 7.5);
            Console.WriteLine($"Результат MethodB: {result}");
        }

        // Метод, соответствующий сигнатуре DelegateA
        static void MethodAImplementation(int id, string name, bool isActive)
        {
            Console.WriteLine($"MethodA: ID={id}, Имя={name}, Активен={isActive}");
        }

        // Метод, соответствующий сигнатуре DelegateB
        static int MethodBImplementation(int[] numbers, double threshold)
        {
            int count = 0;
            foreach (int num in numbers)
            {
                if (num > threshold)
                    count++;
            }
            return count;
        }
    }
}