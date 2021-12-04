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

    internal class Timetable
    {
        internal int StudentID;
        internal string Surname;
        internal string FirstName;
        internal char Gender;
        internal int Level;
        internal string FormClass;
        internal string Grid1;
        internal string Grid2;
        internal List<Class> Classes = new List<Class>();

        internal Timetable(List<string> Data)
        {
            if (Data == null)
                return;

            this.StudentID = Convert.ToInt32(Data[0]);
            this.Surname = Data[1];
            this.FirstName = Data[2];
            this.Gender = Convert.ToChar(Data[3]);
            this.Level = Convert.ToInt32(Data[4]);
            this.FormClass = Data[5];
            this.Grid1 = Data[6];
            this.Grid2 = Data[7];

            Classes.Add(new Class(Data[8]));
            Classes.Add(new Class(Data[9]));
            Classes.Add(new Class(Data[11]));
            Classes.Add(new Class(Data[12]));
            Classes.Add(new Class(Data[13]));
            Classes.Add(new Class(Data[15]));

            Classes.Add(new Class(Data[18]));
            Classes.Add(new Class(Data[19]));
            Classes.Add(new Class(Data[21]));
            Classes.Add(new Class(Data[22]));
            Classes.Add(new Class(Data[23]));
            Classes.Add(new Class(Data[25]));

            Classes.Add(new Class(Data[28]));
            Classes.Add(new Class(Data[29]));
            Classes.Add(new Class(Data[31]));
            Classes.Add(new Class(Data[32]));
            Classes.Add(new Class(Data[33]));
            Classes.Add(new Class(Data[35]));

            Classes.Add(new Class(Data[38]));
            Classes.Add(new Class(Data[39]));
            Classes.Add(new Class(Data[41]));
            Classes.Add(new Class(Data[42]));
            Classes.Add(new Class(Data[43]));
            Classes.Add(new Class(Data[45]));
            
            Classes.Add(new Class(Data[48]));
            Classes.Add(new Class(Data[49]));
            Classes.Add(new Class(Data[51]));
            Classes.Add(new Class(Data[52]));
            Classes.Add(new Class(Data[53]));
            Classes.Add(new Class(Data[55]));
        }
    }
}
