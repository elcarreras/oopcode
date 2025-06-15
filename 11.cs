// 11. Создать консольное приложение, в котором объявить интерфейс, содержащий 3 произвольных метода. Создать класс, являющийся наследником объявленного интерфейса и реализующий данный интерфейс. Вызвать объявленные методы используя интерфейсную ссылку. 

using System;

namespace InterfaceExampleApp
{
    // Объявляем интерфейс с 3 методами
    public interface IWorker
    {
        void StartWork();
        void StopWork();
        void ReportStatus();
    }

    // Класс, реализующий интерфейс
    public class Employee : IWorker
    {
        private string name;

        public Employee(string name)
        {
            this.name = name;
        }

        public void StartWork()
        {
            Console.WriteLine($"{name} начал работу.");
        }

        public void StopWork()
        {
            Console.WriteLine($"{name} закончил работу.");
        }

        public void ReportStatus()
        {
            Console.WriteLine($"{name} готов к работе.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса Employee
            Employee employee = new Employee("Александр");

            // Создаем ссылку на интерфейс и приводим к ней объект
            IWorker worker = employee;

            // Вызываем методы через интерфейсную ссылку
            worker.ReportStatus();
            worker.StartWork();
            worker.StopWork();
        }
    }
}