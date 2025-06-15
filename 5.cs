// 5. Создать консольное приложение, в котором объявить класс, содержащий в себе виртуальный и абстрактный методы. Создать класс наследник от базового класса и переопределить в нем виртуальный и абстрактный методы. Используя представителя класса наследника вызвать переопределенные методы.

using System;

namespace VirtualAbstractApp
{
    // Абстрактный базовый класс
    abstract class BaseClass
    {
        // Виртуальный метод
        public virtual void ShowVirtual()
        {
            Console.WriteLine("Виртуальный метод из BaseClass");
        }

        // Абстрактный метод
        public abstract void ShowAbstract();
    }

    // Наследник, реализующий абстрактный метод и переопределяющий виртуальный
    class DerivedClass : BaseClass
    {
        public override void ShowVirtual()
        {
            Console.WriteLine("Переопределённый виртуальный метод в DerivedClass");
        }

        public override void ShowAbstract()
        {
            Console.WriteLine("Реализация абстрактного метода в DerivedClass");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр наследника
            BaseClass obj = new DerivedClass();

            // Вызываем методы
            obj.ShowVirtual();   // вызовет переопределённый виртуальный
            obj.ShowAbstract();  // вызовет реализацию абстрактного метода
        }
    }
}