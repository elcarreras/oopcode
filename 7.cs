// 7. Создать консольное приложение, в котором объявить класс, содержащий в себе два целочисленных автоматически реализуемых свойства. Внутри класса переопределить оператор «+», который позволит складывать элементы данного класса между собой. 

using System;

namespace OperatorOverloadApp
{
    // Класс с двумя целочисленными свойствами
    public class MyNumber
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }

        // Конструктор
        public MyNumber(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        // Переопределение оператора +
        public static MyNumber operator +(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.Value1 + b.Value1, a.Value2 + b.Value2);
        }

        // Для удобства вывода
        public override string ToString()
        {
            return $"Value1: {Value1}, Value2: {Value2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем два объекта
            MyNumber num1 = new MyNumber(5, 10);
            MyNumber num2 = new MyNumber(15, 20);

            Console.WriteLine("num1: " + num1);
            Console.WriteLine("num2: " + num2);

            // Складываем объекты
            MyNumber result = num1 + num2;

            Console.WriteLine("\nРезультат сложения:");
            Console.WriteLine(result);
        }
    }
}