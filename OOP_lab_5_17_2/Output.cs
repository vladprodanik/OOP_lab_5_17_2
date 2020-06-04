using System;

namespace OOP_lab_5_17_1
{
    class Output
    {
        public const string Format = "{0, -40} {1, -15} {2, -10} {4, -25} {3, -25}";

        public static void Write()
        {
            Console.WriteLine(Format, "ПIБ", "Посада", "Дата", "Назва проекту", "Кiлькiсть годин");

            for (int i = 0; i < Program.days.Length; ++i)
            {
                Console.WriteLine(Format, Program.days[i].Initials, Program.days[i].JobPosition, Program.days[i].Date.ToShortDateString(), Program.days[i].ProjectName, Program.days[i].Hours);
            }
        }
    }
}
