using System;
using System.IO;

namespace OOP_lab_5_17_1
{
    class Day : Worker
    {
        private const string _format = "{0, -40} {1, -15} {2, -10} {4, -25} {3, -25}";

        private DateTime _date;
        private string _projectName;
        private int _hours;

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        public int Hours
        {
            get => _hours;
            set => _hours = value;
        }

        public Day()
        {
            Initials = "Не вказано.";
            JobPosition = "Не вказано.";
            Date = DateTime.Parse("01.01.01");
            ProjectName = "Не вказано.";
            Hours = 0;
        }

        public Day(string initials, string jobPosition, DateTime day, int visitorsCount, string projectName)
        {
            base.Initials = UkrainianI(initials);
            base.JobPosition = UkrainianI(jobPosition);
            Date = day;
            ProjectName = UkrainianI(projectName);
            Hours = visitorsCount;
        }

        public static void Read()
        {
            ReadBase();
            ReadKey();
        }

        public static void ReadBase()
        {
            StreamReader file = new StreamReader("base.txt");

            string[] tempStr = file.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            InitialiseBase(tempStr.Length / 5);

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
                    Add();
                    goto Start;

                case ConsoleKey.E:
                    Edit();
                    goto Start;

                case ConsoleKey.A:
                    Average();
                    goto Start;

                case ConsoleKey.C:
                    HoursCount();
                    goto Start;

                case ConsoleKey.M:
                    Max();
                    goto Start;

                case ConsoleKey.OemMinus:
                    Remove();
                    goto Start;

                case ConsoleKey.Enter:
                    Write();
                    goto Start;

                case ConsoleKey.Escape:
                    return;

                default:
                    Console.WriteLine();
                    goto Start;
            }
        }

        public static void Add()
        {
            StreamWriter file = new StreamWriter("base.txt", true);

            Console.WriteLine("\nВведiть новi данi");

            Console.Write("ПIБ: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("Посада: ");

            file.WriteLine(Console.ReadLine());

        RetryDate:
            Console.Write("Дата: ");

            try
            {
                file.WriteLine(DateTime.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Неправильно вказана дата!");

                goto RetryDate;
            }

        Retry:
            Console.Write("Кiлькiсть годин: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Кiлькiсть годин має бути вказана лише числом!");

                goto Retry;
            }

            Console.Write("Назва проекту: ");

            file.WriteLine(Console.ReadLine());

            file.Close();

            ReadBase();
        }

        public static void Remove()
        {
            Console.WriteLine();

            Write();

            Console.Write("Порядковий номер запису для видалення: ");

            bool[] remove = new bool[Program.days.Length];

            for (int i = 0; i < remove.Length; ++i)
            {
                remove[i] = false;
            }

            try
            {
                remove[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.days.Length; ++i)
            {
                if (!remove[i])
                {
                    file.WriteLine(Program.days[i].Initials);
                    file.WriteLine(Program.days[i].JobPosition);
                    file.WriteLine(Program.days[i].Date);
                    file.WriteLine(Program.days[i].ProjectName);
                    file.WriteLine(Program.days[i].Hours);
                }
            }

            Console.Write("Видалено.\n");

            file.Close();

            ReadBase();
        }

        public static void Edit()
        {
            Console.WriteLine();

            Write();

            Console.Write("Порядковий номер запису для редагування: ");

            bool[] edit = new bool[Program.days.Length];

            for (int i = 0; i < edit.Length; ++i)
            {
                edit[i] = false;
            }

            try
            {
                edit[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.days.Length; ++i)
            {
                if (edit[i])
                {
                    Console.WriteLine("\nВведiть новi данi");

                    Console.Write("ПIБ: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("Посада: ");

                    file.WriteLine(Console.ReadLine());

                RetryDate:
                    Console.Write("Дата: ");

                    try
                    {
                        file.WriteLine(DateTime.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Неправильно вказана дата!");

                        goto RetryDate;
                    }

                Retry:
                    Console.Write("Кiлькiсть годин: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Кiлькiсть годин має бути вказана лише числом!");

                        goto Retry;
                    }

                    Console.Write("Назва проекту: ");

                    file.WriteLine(Console.ReadLine());
                }
                else
                {
                    file.WriteLine(Program.days[i].Initials);
                    file.WriteLine(Program.days[i].JobPosition);
                    file.WriteLine(Program.days[i].Date);
                    file.WriteLine(Program.days[i].ProjectName);
                    file.WriteLine(Program.days[i].Hours);
                }
            }

            Console.Write("Змiни внесено.\n");

            file.Close();

            ReadBase();
        }

        public static void InitialiseBase(int n)
        {
            Program.days = new Day[n];
        }

        public static void Average()
        {
            int sum = 0;

            foreach (Day day in Program.days)
            {
                sum += day.Hours;
            }

            Console.WriteLine("\nСередня кiлькiсть робочих годин: {0}", sum / Program.days.Length);
        }

        public static void Max()
        {
            int max = 0;

            foreach (Day day in Program.days)
            {
                if (max <= day.Hours)
                {
                    max = day.Hours;
                }
            }

            Console.WriteLine("\nДнi з максимальним навантаженням:");
            Console.WriteLine(_format, "ПIБ", "Посада", "Дата", "Назва проекту", "Кiлькiсть годин");

            foreach (Day day in Program.days)
            {
                if (max == day.Hours)
                {
                    Console.WriteLine(_format, day.Initials, day.JobPosition, day.Date.ToShortDateString(), day.ProjectName, day.Hours);
                }
            }
        }

        public static void HoursCount()
        {
            Console.Write("\nНазва проекту: ");

            string name = Console.ReadLine();

            int sum = 0;

            foreach (Day day in Program.days)
            {
                if (name == day.ProjectName)
                {
                    sum += day.Hours;
                }
            }

            Console.WriteLine("Кiлькiсть годин: {0}", sum);
        }

        public static void Write()
        {
            Console.WriteLine(_format, "ПIБ", "Посада", "Дата", "Назва проекту", "Кiлькiсть годин");

            for (int i = 0; i < Program.days.Length; ++i)
            {
                Console.WriteLine(_format, Program.days[i].Initials, Program.days[i].JobPosition, Program.days[i].Date.ToShortDateString(), Program.days[i].ProjectName, Program.days[i].Hours);
            }
        }
    }
}
