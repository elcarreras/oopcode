// Создайте консольное приложение, в котором определите класс Person с автоматическими свойствами Name(строковое) и Address (объект другого класса Address с полями City и Street). Реализуйте конструктор для Person, принимающий параметры для инициализации всех свойств. Создайте массив объектов Person размером, введённым с клавиатуры, заполните его случайными значениями и выведите данные всех объектов на консоль. 

using System;

namespace PersonApp
{
    // Класс Address
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }

        public override string ToString()
        {
            return $"{City}, ул. {Street}";
        }
    }

    // Класс Person
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        // Конструктор
        public Person(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Адрес: {Address}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Массивы случайных данных для заполнения
            string[] names = { "Алексей", "Мария", "Сергей", "Ольга", "Дмитрий", "Екатерина" };
            string[] cities = { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Казань" };
            string[] streets = { "Ленина", "Гагарина", "Пушкина", "Советская", "Первомайская" };

            Random rand = new Random();

            // Ввод размера массива
            Console.Write("Введите количество персон: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Неверный ввод. Пожалуйста, введите положительное число: ");
            }

            // Создание и заполнение массива
            Person[] people = new Person[n];
            for (int i = 0; i < n; i++)
            {
                Address address = new Address
                {
                    City = cities[rand.Next(cities.Length)],
                    Street = streets[rand.Next(streets.Length)]
                };

                people[i] = new Person(names[rand.Next(names.Length)], address);
            }

            // Вывод результатов
            Console.WriteLine("\nСписок персон:");
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}