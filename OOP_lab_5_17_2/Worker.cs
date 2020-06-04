using System;

namespace OOP_lab_5_17_1
{
    abstract class Worker
    {
        private string _initials;
        private string _jobPosition;

        public string Initials
        {
            get => _initials;
            set => _initials = value;
        }

        public string JobPosition
        {
            get => _jobPosition;
            set => _jobPosition = value;
        }

        public virtual string UkrainianI(string str) 
        {
            char[] ch = str.ToCharArray();

            for (int i = 0; i < ch.Length; ++i)
            {
                if (ch[i] == 'і')
                {
                    ch[i] = 'i';
                }

                if (ch[i] == 'І')
                {
                    ch[i] = 'I';
                }
            }

            return new string(ch);
        }
    }
}
