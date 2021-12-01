using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burgundy
{
    internal class Class
    {
        internal string Code;
        internal string Name;
        internal string Room;
        internal string Teacher;

        internal Class(string Data)
        {
            if (string.IsNullOrEmpty(Data))
                return;

            var Class = Data.Split('-');
            this.Code = Class[0];
            this.Name = Class[1];
            this.Room = Class[3];
            this.Teacher = Class[2];
        }
    }

    internal class Week
    {
        internal List<Day> Days = new List<Day>();

        internal void AddDay(Day Day)
        {
            Days.Add(Day);
        }
    }

    internal class Day
    {
        //Maybe Add Char To What Class Is If Needed?
        internal List<Class> Classes = new List<Class>();

        internal void AddClass(Class Class)
        {
            this.Classes.Add(Class);
        }
    }

    internal class Timetable
    {
        internal int StudentID;
        internal string Surname;
        internal string FirstName;
        internal char Gender;
        internal int Level;
        internal string Class;
        internal string Grid1;
        internal string Grid2;

        internal Week Week = new Week();

        private Day Monday = new Day();
        private Day Tuesday = new Day();
        private Day Wednesday = new Day();
        private Day Thursday = new Day();
        private Day Friday = new Day();

        internal Timetable(List<string> Data)
        {
            if (Data == null)
                return;

            this.StudentID = Convert.ToInt32(Data[0]);
            this.Surname = Data[1];
            this.FirstName = Data[2];
            this.Gender = Convert.ToChar(Data[3]);
            this.Level = Convert.ToInt32(Data[4]);
            this.Class = Data[5];
            this.Grid1 = Data[6];
            this.Grid2 = Data[7];

            this.Monday.AddClass(new Class(Data[8]));
            this.Monday.AddClass(new Class(Data[9]));
            this.Monday.AddClass(new Class(Data[11]));
            this.Monday.AddClass(new Class(Data[12]));
            this.Monday.AddClass(new Class(Data[13]));
            this.Monday.AddClass(new Class(Data[15]));

            this.Tuesday.AddClass(new Class(Data[18]));
            this.Tuesday.AddClass(new Class(Data[19]));
            this.Tuesday.AddClass(new Class(Data[21]));
            this.Tuesday.AddClass(new Class(Data[22]));
            this.Tuesday.AddClass(new Class(Data[23]));
            this.Tuesday.AddClass(new Class(Data[25]));

            this.Wednesday.AddClass(new Class(Data[28]));
            this.Wednesday.AddClass(new Class(Data[29]));
            this.Wednesday.AddClass(new Class(Data[31]));
            this.Wednesday.AddClass(new Class(Data[32]));
            this.Wednesday.AddClass(new Class(Data[33]));
            this.Wednesday.AddClass(new Class(Data[35]));

            this.Thursday.AddClass(new Class(Data[38]));
            this.Thursday.AddClass(new Class(Data[39]));
            this.Thursday.AddClass(new Class(Data[41]));
            this.Thursday.AddClass(new Class(Data[42]));
            this.Thursday.AddClass(new Class(Data[43]));
            this.Thursday.AddClass(new Class(Data[45]));
            
            this.Friday.AddClass(new Class(Data[48]));
            this.Friday.AddClass(new Class(Data[49]));
            this.Friday.AddClass(new Class(Data[51]));
            this.Friday.AddClass(new Class(Data[52]));
            this.Friday.AddClass(new Class(Data[53]));
            this.Friday.AddClass(new Class(Data[55]));

            this.Week.AddDay(Monday);
            this.Week.AddDay(Tuesday);
            this.Week.AddDay(Wednesday);
            this.Week.AddDay(Thursday);
            this.Week.AddDay(Friday);
        }
    }
}
