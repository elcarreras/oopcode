// 9. Создать консольное приложение, в котором объявить класс, использующий обобщенный тип данных. Дополнительно создать класс, внутри которого объявить конструктор, принимающий 2 параметра (целочисленный и строковый) и записывающий значения в автоматически реализуемые свойства. Наложить ограничения на обобщенный тип данных, что он может принимать только описанный класс и классы наследники. 

using System;

namespace GenericWithConstraintsApp
{
    // Базовый класс с автоматическими свойствами
    public class Person
    {
        public int Id { get; }
        public string Name { get; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Имя: {Name}";
        }
    }

    // Наследник
    public class Employee : Person
    {
        public Employee(int id, string name) : base(id, name)
        {
        }
    }

    // Обобщённый класс с ограничением типа
    public class Repository<T> where T : Person
    {
        private T item;

        public Repository(T item)
        {
            this.item = item;
        }

        public void ShowItemInfo()
        {
            Console.WriteLine($"Тип: {item.GetType().Name}, Данные: {item}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Используем Person
            var person = new Person(1, "Алексей");
            var personRepo = new Repository<Person>(person);
            personRepo.ShowItemInfo();

            // Используем Employee (наследник Person)
            var employee = new Employee(2, "Мария");
            var employeeRepo = new Repository<Employee>(employee);
            employeeRepo.ShowItemInfo();

            // Строка ниже не скомпилируется — ограничение запрещает int
            // var badRepo = new Repository<int>(new int()); // ОШИБКА!
        }
    }
}