using System;

namespace AdapterExample
{
    // Система яку будемо адаптовувати
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "old system";
        }
    }

    // Дуже стара система 
    class VeryOldElectricitySystem
    {
        public string MatchRoundSocket()
        {
            return "very old system";
        }
    }

    // Широковикористовуваний інтерфейс нової системи (специфікація до квартири)
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    // Ну і власне сама розетка у новій квартирі
    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "new interface";
        }
    }

    // Адаптер назовні виглядає як нові євророзетки, шляхом наслідування прийнятного у 
    // системі інтерфейсу
    class Adapter : INewElectricitySystem
    {
        // Але всередині він старий
        private readonly OldElectricitySystem _adaptee;

        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        // Тут адаптер «перекладає» функціональність із нового стандарту на старий
        public string MatchWideSocket()
        {
            return _adaptee.MatchThinSocket();
        }
    }

    // Новий адаптер для дуже старої системи
    class VeryOldAdapter : INewElectricitySystem
    {
        private readonly VeryOldElectricitySystem _adaptee;

        public VeryOldAdapter(VeryOldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        public string MatchWideSocket()
        {
            // Тут так само міг би бути «трансформатор»
            return _adaptee.MatchRoundSocket();
        }
    }

    class ElectricityConsumer
    {
        // Зарядний пристрій, який розуміє тільки нову систему
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1) Ми можемо користуватися новою системою без проблем
            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);

            // 2) Ми повинні адаптуватися до старої системи, використовуючи адаптер
            var oldElectricitySystem = new OldElectricitySystem();
            var adapter = new Adapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter);

            // 3) Адаптація до «дуже старої» системи через новий адаптер
            var veryOldElectricitySystem = new VeryOldElectricitySystem();
            var veryOldAdapter = new VeryOldAdapter(veryOldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(veryOldAdapter);

            Console.ReadKey();
        }
    }
}
