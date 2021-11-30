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

    internal class Day
    {
        internal Class P1;
        internal Class P2;
        internal Class P3;
        internal Class P4;
        internal Class P5;

        internal Class WhaWhanau;
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

        internal Day Monday = new Day();
        internal Day Tuesday = new Day();
        internal Day Wednesday = new Day();
        internal Day Thursday = new Day();
        internal Day Friday = new Day();

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

            this.Monday.P1 = new Class(Data[8]);
            this.Monday.P2 = new Class(Data[9]);
            this.Monday.P3 = new Class(Data[11]);
            this.Monday.WhaWhanau = new Class(Data[12]);
            this.Monday.P4 = new Class(Data[13]);
            this.Monday.P5 = new Class(Data[15]);

            this.Tuesday.P1 = new Class(Data[18]);
            this.Tuesday.P2 = new Class(Data[19]);
            this.Tuesday.P3 = new Class(Data[21]);
            this.Tuesday.WhaWhanau = new Class(Data[22]);
            this.Tuesday.P4 = new Class(Data[23]);
            this.Tuesday.P5 = new Class(Data[25]);

            this.Wednesday.P1 = new Class(Data[28]);
            this.Wednesday.P2 = new Class(Data[29]);
            this.Wednesday.P3 = new Class(Data[31]);
            this.Wednesday.WhaWhanau = new Class(Data[32]);
            this.Wednesday.P4 = new Class(Data[33]);
            this.Wednesday.P5 = new Class(Data[35]);

            this.Thursday.P1 = new Class(Data[38]);
            this.Thursday.P2 = new Class(Data[39]);
            this.Thursday.P3 = new Class(Data[41]);
            this.Thursday.WhaWhanau = new Class(Data[42]);
            this.Thursday.P4 = new Class(Data[43]);
            this.Thursday.P5 = new Class(Data[45]);
            
            this.Friday.P1 = new Class(Data[48]);
            this.Friday.P2 = new Class(Data[49]);
            this.Friday.P3 = new Class(Data[51]);
            this.Friday.WhaWhanau = new Class(Data[52]);
            this.Friday.P4 = new Class(Data[53]);
            this.Friday.P5 = new Class(Data[55]);
        }
    }
}
