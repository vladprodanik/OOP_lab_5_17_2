using System;

namespace OOP_lab_5_17_1
{
    class Day : Worker
    {
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
    }
}
