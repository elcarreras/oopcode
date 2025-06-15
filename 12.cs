// 12. Создать консольное приложение, в котором объявить класс, внутри которого содержится событие, событие может хранить ссылку на метод, обладающий заданной сигнатурой: void (int). Реализовать метод, подходящий данной сигнатуре и подписать его на событие. В событии реализовать вывод на консоль информации каждый раз, когда какой-либо метод подписывается на данное событие или отписывается от него. Вызвать событие. 

using System;

namespace EventExampleApp
{
    class Program
    {
        // Объявляем класс с событием
        public class MyEventPublisher
        {
            // Событие с кастомной логикой подписки/отписки
            private EventHandler<int> myEvent;

            public event EventHandler<int> MyEvent
            {
                add
                {
                    Console.WriteLine($"Подписан метод: {value.Method.Name}");
                    myEvent += value;
                }
                remove
                {
                    Console.WriteLine($"Отписан метод: {value.Method.Name}");
                    myEvent -= value;
                }
            }

            // Метод для вызова события
            public void DoSomething()
            {
                Console.WriteLine("Выполняется действие. Вызываем событие...");
                myEvent?.Invoke(this, 42); // Передаем значение 42
            }
        }

        // Метод, подходящий сигнатуре void (int)
        static void MyEventHandlerMethod(object sender, int e)
        {
            Console.WriteLine($"Событие вызвано! Получено значение: {e}");
        }

        static void Main(string[] args)
        {
            // Создаем экземпляр класса с событием
            MyEventPublisher publisher = new MyEventPublisher();

            // Подписываем метод на событие
            publisher.MyEvent += MyEventHandlerMethod;

            // Вызываем событие
            publisher.DoSomething();

            // Отписываем метод от события
            publisher.MyEvent -= MyEventHandlerMethod;
        }
    }
}