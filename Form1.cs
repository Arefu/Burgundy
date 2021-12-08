using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Burgundy
{
    public partial class Form1 : Form
    {
        internal static List<Timetable> StudentTimetables;
        internal static List<Student> StudentEfforts;

        public Form1()
        {
            InitializeComponent();
            StudentTimetables = new List<Timetable>();
            StudentEfforts = new List<Student>();

            ignoreClasses.Text = "SLC,FLT,HOME,Catchup";
            if (File.Exists("Missed Efforts.txt"))
                File.Delete("Missed Efforts.txt");
        }

        private void Load_TT_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
            {
                OpenFileDialog.Filter = "Student_TTs|*.txt";
                OpenFileDialog.Title = "Select Student TT File";

                if (OpenFileDialog.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Please Select Student_TTs.txt File!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (StreamReader StreamReader = new StreamReader(File.Open(OpenFileDialog.FileName, FileMode.Open, FileAccess.Read)))
                {
                    //Discard Header.
                    StreamReader.ReadLine();
                    while (StreamReader.EndOfStream == false)
                    {
                        List<string> Data = StreamReader.ReadLine().Split('\t').ToList();
                        StudentTimetables.Add(new Timetable(Data));
                    }
                }
            }

            StudentTimetables = StudentTimetables.OrderBy(Student => Student.StudentID).ToList();
        }

        private void Load_Effort_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
            {
                OpenFileDialog.Filter = "Student Efforts Detailed|*.csv";
                OpenFileDialog.Title = "Select Student Efforts File";

                if (OpenFileDialog.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Please Select Student Efforts File!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (StreamReader StreamReader = new StreamReader(File.Open(OpenFileDialog.FileName, FileMode.Open, FileAccess.Read)))
                {
                    //Discard Header.
                    StreamReader.ReadLine();

                    while (StreamReader.EndOfStream == false)
                    {
                        var Efforts = StreamReader.ReadLine().Split(',').ToList();

                        var Student = new Student(Efforts.Take(8).ToList());
                        Efforts.RemoveRange(0, 8);

                        while (Efforts.Count > 0)
                        {
                            if (String.IsNullOrEmpty(Efforts[0]))
                            {
                                Efforts.RemoveRange(0, 5);
                                continue;
                            }

                            var Subject = new Subject(Efforts.Take(5).ToList());
                            Efforts.RemoveRange(0, 5);
                            Student.AddClass(Subject);

                            if (!Student.AllSubjects.Contains(Subject))
                                Student.AllSubjects.Add(Subject);
                        }
                        StudentEfforts.Add(Student);
                    }
                }
            }

            StudentEfforts = StudentEfforts.OrderBy(Student => Student.StudentID).ToList();
        }

        private void Process_Click(object sender, EventArgs e)
        {
            Dictionary<Subject, int> ClassesWithNoEfforts = new Dictionary<Subject, int>();
            if (StudentTimetables.Count != StudentEfforts.Count || StudentTimetables[0].StudentID != StudentEfforts[0].StudentID)
            {
                var Result = MessageBox.Show("The Student TimeTables & Student Efforts Don't Match, I Can Continue, But Things May Get Weird, Is That Okay?\n\nPlease Tell Johnathon!", "Offset Mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Result == DialogResult.No)
                    return;
            }

            for (int i = 0; i < Student.AllSubjects.Count; i++)
            {
                Subject Subject = Student.AllSubjects[i];
                if (Subject.SubjectEffort1 != 0)
                    Student.AllSubjects.Remove(Subject);
                if (ignoreClasses.Text.Split(',').Any(ignore => Subject.SubjectName.ToUpper().Contains(ignore.ToUpper())))
                    Student.AllSubjects.Remove(Subject);
            }

            Student.AllSubjects = Student.AllSubjects.OrderBy(Subject => Subject.SubjectTeacher).ToList();
            Dictionary<Class, int> DoneClasses = new Dictionary<Class, int>();
            List<MissedEffort> Missed = new List<MissedEffort>();

            this.Text = "Working...";
            
            foreach (var Effort in Student.AllSubjects)
            {
                foreach (var StudentTimetable in StudentTimetables)
                {
                    foreach (var Class in StudentTimetable.Classes)
                    {
                        if (Class.Name == null)
                            continue;
                        if (Class.Name == StudentTimetable.FormClass)
                            continue;
                        if (ignoreClasses.Text.Split(',').Any(ignore => Class.Name.ToUpper().Contains(ignore.ToUpper())))
                            continue;


                        if (Class.Name == Effort.SubjectName && Class.Teacher.Split('/').Any(Teacher => Effort.SubjectTeacher == Teacher))
                        {
                            if (DoneClasses.ContainsKey(Class) == false)
                            {
                                DoneClasses.Add(Class, 1);
                                Missed.Add(new MissedEffort(Class, $"{StudentTimetable.FirstName} {StudentTimetable.Surname}", 1));
                            }
                            else
                            {
                                DoneClasses[Class] = DoneClasses[Class] + 1;
                            }
                        }
                    }
                }
            }

            DoneClasses = DoneClasses.OrderBy(Class => Class.Key.Teacher).ToDictionary(Key => Key.Key, Value => Value.Value);
            foreach(var Class in DoneClasses)
            {
                File.AppendAllText("Missed Efforts.txt", $"{Class.Key.Name}-{Class.Key.Teacher} Missed  {Class.Value} Efforts\n");
            }
            this.Text = "";
        }

        class MissedEffort
        {
            Class Class;
            String Name;
            int NumberOfMissed;

            public MissedEffort(Class Class, string Name, int Number)
            {
                this.Class = Class;
                this.Name = Name;
                this.NumberOfMissed = Number;
            }

            public void AddToMissed(Class Class, string Name)
            {
                if(this.Class == Class && this.Name == Name)
                {
                    NumberOfMissed = NumberOfMissed + 1;
                }
            }
        }
    }
}
