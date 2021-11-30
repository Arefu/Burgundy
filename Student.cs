using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burgundy
{
    internal class Student
    {
        internal int StudentID;
        internal string Surname;
        internal string FirstName;
        internal char Gender;
        internal DateTime StudentBirthday;
        internal int Year;
        //Ignore This When Checking Efforts!
        internal string StudentFormClass;
        internal DateTime ReportWeekStart;

        internal List<Subject> StudentSubjects;

        internal Student(List<string> Student)
        {
            this.StudentID = Convert.ToInt32(Student[0]);
            this.Surname = Student[1];
            this.FirstName = Student[2];
            this.Gender = Convert.ToChar(Student[3]);
            this.StudentBirthday = Convert.ToDateTime(Student[4]);
            this.Year = Convert.ToInt32(Student[5]);
            this.StudentFormClass = Student[6];
            this.ReportWeekStart = Convert.ToDateTime(Student[7]);

            this.StudentSubjects = new List<Subject>();
        }

        internal void AddClass(Subject Subject)
        {
            this.StudentSubjects.Add(Subject);
        }
    }

    internal class Subject
    {
        internal string SubjectName;
        internal string SubjectTeacher;
        internal int SubjectAttendance;
        internal int SubjectEffort1;
        internal int SubjectEffort2;

        internal Subject(List<string> Subject)
        {
            this.SubjectName = Subject[0];
            this.SubjectTeacher = Subject[1];
            Int32.TryParse(Subject[2], out SubjectAttendance);
            Int32.TryParse(Subject[3], out SubjectEffort1);
            Int32.TryParse(Subject[4], out SubjectEffort2);
        }
    }
}
