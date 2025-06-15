// 4. Создать консольное приложение, в котором объявить класс, содержащий конструктор, принимающий 2 параметра (строковый и логический (bool)). Значения передаваемых в конструктор параметров записать в автоматически реализуемые свойства. Объявить класс, который является наследником данного класса. Создать два массива элементов класса наследника, размерность массива ввести с клавиатуры (размерность массивов одинаковая). Массивы заполнить произвольными значениями (в автоматическом режиме) и вывести на консоль информацию о том, в каком из массивов чаще встречается значение false.

using System;

namespace InheritanceArrayApp
{
    // Базовый класс
    public class BaseClass
    {
        public string Name { get; }
        public bool Flag { get; }

        public BaseClass(string name, bool flag)
        {
            Name = name;
            Flag = flag;
        }
    }

    // Наследник
    public class DerivedClass : BaseClass
    {
        public DerivedClass(string name, bool flag) : base(name, flag)
        {
        }

        public override string ToString()
        {
            return $"Name: {Name}, Flag: {Flag}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            string[] names = { "Alice", "Bob", "Charlie", "Diana", "Eve" };

            Console.Write("Введите размер массивов: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Неверный ввод. Пожалуйста, введите положительное число: ");
            }

            // Создаем два массива
            DerivedClass[] array1 = new DerivedClass[size];
            DerivedClass[] array2 = new DerivedClass[size];

            // Заполняем массивы случайными данными
            for (int i = 0; i < size; i++)
            {
                array1[i] = new DerivedClass(names[rand.Next(names.Length)], rand.Next(2) == 0);
                array2[i] = new DerivedClass(names[rand.Next(names.Length)], rand.Next(2) == 0);
            }

            // Подсчет количества false
            int countFalse1 = 0;
            foreach (var item in array1)
            {
                if (!item.Flag) countFalse1++;
            }

            int countFalse2 = 0;
            foreach (var item in array2)
            {
                if (!item.Flag) countFalse2++;
            }

            // Вывод результатов
            Console.WriteLine("\nМассив 1:");
            foreach (var item in array1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nМассив 2:");
            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nКоличество false в массиве 1: {countFalse1}");
            Console.WriteLine($"Количество false в массиве 2: {countFalse2}");

            if (countFalse1 > countFalse2)
            {
                Console.WriteLine("В первом массиве чаще встречается false.");
            }
            else if (countFalse2 > countFalse1)
            {
                Console.WriteLine("Во втором массиве чаще встречается false.");
            }
            else
            {
                Console.WriteLine("Значение false встречается одинаково часто в обоих массивах.");
            }
        }
    }
}