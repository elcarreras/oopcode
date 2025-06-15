// 8. Создать консольное приложение, в котором объявить класс, использующий обобщенный тип данных. Внутри класса объявить метод, который выводит на консоль название типа данных, который был использован в качестве обобщенного при создании элемента класса. 

using System;

namespace GenericTypeApp
{
    // Обобщённый класс
    public class MyGenericClass<T>
    {
        // Метод, выводящий тип данных T
        public void ShowType()
        {
            Console.WriteLine("Тип данных: " + typeof(T).Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объекты с разными типами
            MyGenericClass<int> intObj = new MyGenericClass<int>();
            MyGenericClass<string> stringObj = new MyGenericClass<string>();
            MyGenericClass<DateTime> dateTimeObj = new MyGenericClass<DateTime>();

            // Вызываем метод для каждого объекта
            intObj.ShowType();      // Тип данных: Int32
            stringObj.ShowType();   // Тип данных: String
            dateTimeObj.ShowType(); // Тип данных: DateTime
        }
    }
}