using System;
using System.IO;

namespace OOP_lab_5_17_1
{
    class Input
    {
        public static void Read()
        {
            ReadBase();
            ReadKey();
        }

        public static void ReadBase()
        {
            StreamReader file = new StreamReader("base.txt");

            string[] tempStr = file.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            Work.InitialiseBase(tempStr.Length / 5);

            for (int i = 0; i < tempStr.Length; i += 5)
            {
                Program.days[i / 5] = new Day(tempStr[i], tempStr[i + 1], DateTime.Parse(tempStr[i + 2]), int.Parse(tempStr[i + 3]), tempStr[i + 4]);
            }

            file.Close();
        }

        private static void ReadKey()
        {
            
        Start:

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Середня кiлькiсть робочих годин: A");
            Console.WriteLine("Кiлькiсть годин на проектi: C");
            Console.WriteLine("Днi з максимальним навантаженням: M");
            Console.WriteLine("Вихiд: Esc");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.OemPlus:
                    Work.Add();
                    goto Start;

                case ConsoleKey.E:
                    Work.Edit();
                    goto Start;

                case ConsoleKey.A:
                    Work.Average();
                    goto Start;

                case ConsoleKey.C:
                    Work.HoursCount();
                    goto Start;

                case ConsoleKey.M:
                    Work.Max();
                    goto Start;

                case ConsoleKey.OemMinus:
                    Work.Remove();
                    goto Start;

                case ConsoleKey.Enter:
                    Output.Write();
                    goto Start;

                case ConsoleKey.Escape:
                    return;

                default:
                    Console.WriteLine();
                    goto Start;
            }
        }
    }
}
