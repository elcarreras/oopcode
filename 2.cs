// 2.	Создать консольное приложение, в котором объявить класс с приватным методом, выводящим на консоль сообщение, переданное в данном методе. Вызвать приватный метод из вне класса, в котором он объявлен (использование рефлексии). 

using System;
using System.Reflection;

namespace ReflectionPrivateMethodApp
{
    // Класс с приватным методом
    public class MessagePrinter
    {
        private void PrintMessage(string message)
        {
            Console.WriteLine($"Сообщение: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр класса
            var printer = new MessagePrinter();

            // Получаем тип объекта
            Type type = typeof(MessagePrinter);

            // Получаем информацию о приватном методе
            MethodInfo methodInfo = type.GetMethod("PrintMessage", BindingFlags.NonPublic | BindingFlags.Instance);

            if (methodInfo != null)
            {

                // Вызываем приватный метод через рефлексию
                Console.Write("Введите сообщение для вывода: ");
                string input = Console.ReadLine();

                methodInfo.Invoke(printer, new object[] { input });
            }
            else
            {
                Console.WriteLine("Метод не найден.");
            }
        }
    }
}