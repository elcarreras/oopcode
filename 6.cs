// 6. Создайте консольное приложение, определите интерфейс IVehicle с методом GetSpeed (возвращает double). Реализуйте два класса, реализующих интерфейс: Car и Bicycle, с автоматическим свойством MaxSpeed. Создайте коллекцию List<IVehicle>, заполните её случайными объектами Car и Bicycle. Используя LINQ, отфильтруйте транспортные средства со скоростью выше 50 и отсортируйте по убыванию скорости. Выведите результат.

using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleLINQApp
{
    // Интерфейс
    public interface IVehicle
    {
        double MaxSpeed { get; }
        double GetSpeed();
    }

    // Класс Car
    public class Car : IVehicle
    {
        public double MaxSpeed { get; } = 0;

        public Car(double maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }

        public double GetSpeed()
        {
            return MaxSpeed * 0.9; // условная текущая скорость
        }
    }

    // Класс Bicycle
    public class Bicycle : IVehicle
    {
        public double MaxSpeed { get; } = 0;

        public Bicycle(double maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }

        public double GetSpeed()
        {
            return MaxSpeed * 0.8; // условная текущая скорость
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            // Создаем список транспортных средств
            List<IVehicle> vehicles = new List<IVehicle>();

            Console.Write("Введите количество объектов для генерации: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                if (rand.Next(2) == 0)
                {
                    double speed = rand.Next(40, 121); // Максимальная скорость от 40 до 120
                    vehicles.Add(new Car(speed));
                }
                else
                {
                    double speed = rand.Next(10, 41); // Максимальная скорость от 10 до 40
                    vehicles.Add(new Bicycle(speed));
                }
            }

            // LINQ-запрос: фильтрация и сортировка
            var filteredVehicles = vehicles
                .Where(v => v.GetSpeed() > 50)
                .OrderByDescending(v => v.GetSpeed())
                .ToList();

            // Вывод результата
            Console.WriteLine("\nТранспортные средства со скоростью больше 50 (по убыванию):");
            foreach (var vehicle in filteredVehicles)
            {
                Console.WriteLine($"Тип: {vehicle.GetType().Name}, Скорость: {vehicle.GetSpeed():F2}");
            }
        }
    }
}