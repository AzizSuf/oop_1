/*
 * Задание 1: Приведение и преобразование типов.
 *
 * Created: 20.02.23
 * Author : Aziz Sufyanov
 * e-mail : aziz-sufyanov@mail.ru
 */


using System.Text;

namespace Ex1
{
    class Animal
    {
        public Animal()
        {

        }
    }

    class Cat : Animal
    {
        public Cat()
        {

        }
    }

    class Dog : Animal
    {
        public Dog()
        {

        }
    }

    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public void Print()
        {
            Console.WriteLine($"Person {Name}");
        }
    }

    class Employee : Person
    {
        public string Company { get; set; }
        public Employee(string name, string company) : base(name)
        {
            Company = company;
        }
    }

    class Client : Person
    {
        public string Bank { get; set; }
        public Client(string name, string bank) : base(name)
        {
            Bank = bank;
        }
    }

    class Counter
    {
        public int Seconds { get; set; }

        public static implicit operator Counter(int x)
        {
            return new Counter { Seconds = x };
        }
        public static explicit operator int(Counter counter)
        {
            return counter.Seconds;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, CFU");
            Console.WriteLine();

            ImplicitConversionExample();   // Пункт 1.

            ExplicitConversionExample();   // Пункт 2.

            ConversionExceptionsExample(); // Пункт 3.

            SafeCastExample();             // Пункт 4.

            UserImplicitExplicitConvertion();      // Пункт 5.

            ConvertParsTryParse();         // Пункт 6.
        }

        /// <summary>
        /// 1) Неявное преобразование простых и ссылочных типов, в виде комментариев внести в программу таблицу неявных преобразований
        /// </summary>
        private static void ImplicitConversionExample()
        {
            // Все безопасные автоматические преобразования можно описать следующей таблицей: //
            //--------------------------------------------------------------------------------//
            // Тип     | В какие типы безопасно преобразуется                                 //
            //--------------------------------------------------------------------------------//
            // byte    | short, ushort, int, uint, long, ulong, float, double, decimal        //
            // sbyte   | short, int, long, float, double, decimal                             //
            // short   | int, long, float, double, decimal                                    //
            // ushort  | int, uint, long, ulong, float, double, decimal                       //
            // int     | long, float, double, decimal                                         //
            // uint    | long, ulong, float, double, decimal                                  //
            // long    | float, double, decimal                                               //
            // ulong   | float, double, decimal                                               //
            // float   | double                                                               //
            // char    | ushort, int, uint, long, ulong, float, double, decimal               //
            //--------------------------------------------------------------------------------//

            // Демонтрация некоторых неявных преобразований
            byte byteVar = 55;

            short shortVar = byteVar;      // implicit convertion from 'byte' to 'short'
            ushort ushortVar = byteVar;    // from 'byte' to 'ushort'
            int intVar = byteVar;          // from 'byte' to 'int'
            uint uintVar = byteVar;        // from 'byte' to 'uint'
            ulong ulongVar = byteVar;      // from 'byte' to 'ulong'
            long longVar = byteVar;        // from 'byte' to 'long'
            float floatVar = byteVar;      // from 'byte' to 'float'
            double doubleVar = byteVar;    // from 'byte' to 'double'
            decimal decimalVar = byteVar;  // from 'byte' to 'decimal'

            Console.WriteLine($"byte: {byteVar}, short: {shortVar}, ushort: {ushortVar} .....");

            float floatVar2 = 45.5f;
            double doubleVar2 = floatVar2; // implicit convertion from 'float' to 'double'

            // Тут будет ошибка!! Из 'double' во 'float ' НЕТ неявного преобразования!!
            // floatVar2 = doubleVar2;

            // Демонстрация потерь при  преобразование большого int в число с плавающей точкой
            Int32 i32Data = Int32.MaxValue;
            float fData = i32Data;
            double dData = i32Data;
            Console.WriteLine("Преобразование большого int в число с плавающей точкой");
            Console.WriteLine($"int32: {i32Data}  -->  float: {fData},  double: {dData}");

            Int64 i64Data = Int64.MaxValue;
            fData = i64Data;
            dData = i64Data;
            Console.WriteLine($"int64: {i64Data}  -->  float: {fData},  double: {dData}");
            Console.WriteLine();

            // Ссылочные типы
            Animal someAnimal = new Cat();
         }

        /// <summary>
        /// 2) Явное преобразование простых и ссылочных типов,
        /// в виде комментариев внести в программу таблицу явных преобразований
        /// </summary>
        private static void ExplicitConversionExample()
        {
            // Таблица явных преобразований
            //----------------------------------------------------------------------------------------//
            // Откуда  | Куда                                                                         //
            //----------------------------------------------------------------------------------------//
            // sbyte   | byte, ushort, uint, ulong или char                                          //
            // byte    | Sbyte или char                                                               //
            // short   | sbyte, byte, ushort, uint, ulong или char                                   //
            // ushort  | sbyte, byte, short или char                                                 //
            // int     | sbyte, byte, short, ushort, uint, ulong или char                            //
            // uint    | sbyte, byte, short, ushort, int или char                                    //
            // long    | sbyte, byte, short, ushort, int, uint, ulong или char                       //
            // ulong   | sbyte, byte, short, ushort, int, uint, long или char                        //
            // char    | sbyte, byte или short                                                       //
            // float   | sbyte, byte, short, ushort, int, uint, long, ulong, char или decimal        //
            // double  | sbyte, byte, short, ushort, int, uint, long, ulong, char, float или decimal //
            // decimal | sbyte, byte, short, ushort, int, uint, long, ulong, char, float или double  //
            //----------------------------------------------------------------------------------------//

            double dNum = 30.334;
            float fNum = (float) dNum;  // Явное преобразование. Возможна потеря точности!!

            int iNum = 1000;
            byte bNum = (byte) iNum;    // Явное преобразование. В данном случае переполнение bNum!

            // Ссылочные типы
            Cat cat = new Cat();
            Animal animal = cat;

            Cat castCat =  (Cat) animal; // Явное преобразование.
        }

        /// <summary>
        /// 3) Вызвать и обработать исключение преобразования типов
        /// </summary>
        private static void ConversionExceptionsExample()
        {
            int srcNumber = 1000;
            byte dstNumber;

            checked
            {
                try
                {
                    dstNumber = (byte)srcNumber;
                }
                catch (Exception)
                {
                    Console.WriteLine("Переполнение byte");
                }
            }
        }

        /// <summary>
        /// 4) Безопасное приведение ссылочных типов с помощью операторов as и is
        /// </summary>
        private static void SafeCastExample()
        {
            // Ключевое слово as. С помощью него программа пытается преобразовать выражение к определенному типу,
            // при этом не выбрасывает исключение. В случае неудачного преобразования выражение будет содержать значение null:
            Person person = new Person("Tom");
            Employee? employee = person as Employee;
            if (employee == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine(employee.Company);
            }

            // Оператор is позволяет автоматически преобразовать значение к типу, если это значение представляет данный тип.Например:
            Person person1 = new Person("Tom");
            if (person is Employee employee1)
            {
                Console.WriteLine(employee1.Company);
            }
            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }

            // Оператор is также можно применять и без преобразования, просто проверяя на соответствие типу:
            Person person2 = new Person("Tom");
            if (person2 is Employee)
            {
                Console.WriteLine("Представляет тип Employee");
            }
            else
            {
                Console.WriteLine("НЕ является объектом типа Employee");
            }

        }

        /// <summary>
        /// 5) Пользовательское преобразование типов Implicit, Explicit
        /// </summary>
        private static void UserImplicitExplicitConvertion()
        {
            Counter counter1 = new Counter { Seconds = 23 };

            int x = (int)counter1;
            Console.WriteLine(x);   // 23

            Counter counter2 = x;
            Console.WriteLine(counter2.Seconds);  // 23
        }

        /// <summary>
        /// 6) Преобразование с помощью класса Convert и преобразование строки в число с помощью методов Parse, TryParse класса System.Int32.
        /// </summary>
        private static void ConvertParsTryParse()
        {
            int iNum = 100;
            float fNum = Convert.ToSingle(iNum);

            string text = "3456";
            int number = int.Parse(text);  // Тут может вылетить исключение!

            text = "5656";
            bool status = int.TryParse(text, out number);
            Console.WriteLine(status);
        }
    }

}