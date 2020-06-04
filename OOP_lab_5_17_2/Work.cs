using System;
using System.IO;

namespace OOP_lab_5_17_1
{
    class Work
    {
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

            Input.ReadBase();
        }

        public static void Remove()
        {
            Console.WriteLine();

            Output.Write();

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

            Input.ReadBase();
        }

        public static void Edit()
        {
            Console.WriteLine();

            Output.Write();

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

            Input.ReadBase();
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
            Console.WriteLine(Output.Format, "ПIБ", "Посада", "Дата", "Назва проекту", "Кiлькiсть годин");

            foreach (Day day in Program.days)
            {
                if (max == day.Hours)
                {
                    Console.WriteLine(Output.Format, day.Initials, day.JobPosition, day.Date.ToShortDateString(), day.ProjectName, day.Hours);
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
    }
}
