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

            if (File.Exists("Burgundy.log"))
                File.Delete("Burgundy.log");
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
                        }
                        StudentEfforts.Add(Student);
                    }
                }
            }

            StudentEfforts = StudentEfforts.OrderBy(Student => Student.StudentID).ToList();
        }

        private void Process_Click(object sender, EventArgs e)
        {
            Dictionary<Class, int> ClassesWithNoEfforts = new Dictionary<Class, int>();
            if (StudentTimetables.Count != StudentEfforts.Count || StudentTimetables[0].StudentID != StudentEfforts[0].StudentID)
            {
                var Result = MessageBox.Show("The Student TimeTables & Student Efforts Don't Match, I Can Continue, But Things May Get Weird, Is That Okay?\n\nPlease Tell Johnathon!", "Offset Mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Result == DialogResult.No)
                    return;
            }

            foreach (var StudentTimetable in StudentTimetables)
            {
                foreach (var Day in StudentTimetable.Week.Days)
                {
                    foreach (var TimetableClass in Day.Classes)
                    {
                        foreach (var StudentEffort in StudentEfforts)
                        {
                            foreach (var StudentSubject in StudentEffort.StudentSubjects)
                            {
                                if (TimetableClass.Name == StudentEffort.StudentFormClass)
                                    continue;

                                if (StudentSubject.SubjectName == TimetableClass.Name)
                                {
                                    if (StudentSubject.SubjectEffort1 == 0)
                                    {
                                        if (ClassesWithNoEfforts.ContainsKey(TimetableClass))
                                        {
                                            ClassesWithNoEfforts[TimetableClass] = ClassesWithNoEfforts[TimetableClass] + 1;
                                            continue;
                                        }

                                        ClassesWithNoEfforts.Add(TimetableClass, 1);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach(var ClassWithNoEfforts in ClassesWithNoEfforts)
            {
                File.AppendAllText("Efforts.txt", $"Teacher: {ClassWithNoEfforts.Key.Teacher} Class: {ClassWithNoEfforts.Key.Name} Missed: {ClassWithNoEfforts.Value} Efforts\n");
            }
        }
    }
}
