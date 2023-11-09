using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI
{
    public class ConsoleViewExamGrade
    {
        private readonly ExamGradeDAO examgradeDao;
        private readonly StudentDAO studentDao;
        private readonly SubjectDAO subjectDao;

        public ConsoleViewExamGrade(ExamGradeDAO examgradeDao, StudentDAO studentDao, SubjectDAO subjectDao)
        {
            this.examgradeDao = examgradeDao;
            this.studentDao = studentDao;
            this.subjectDao = subjectDao;
        }

        private void PrintStudents(List<Student> students)
        {
            foreach (Student s in students)
            {
                System.Console.WriteLine(s);
            }
        }
        private void PrintSubjects(List<Subject> subjects)
        {
            foreach (Subject s in subjects)
            {
                System.Console.WriteLine(s);
            }
        }
        private void PrintExamGrades(List<ExamGrade> examgrades)
        {
            System.Console.WriteLine("Exam grades: ");
            System.Console.WriteLine($"ID:{"",3}| Student ID: {"",3} | Subject ID: {"",3} | Grade: {"",2} | Date:{"",11}");
            foreach (ExamGrade eg in examgrades)
            {
                System.Console.WriteLine(eg);
            }
        }
        private ExamGrade InputExamGrade()
        {

            System.Console.WriteLine("Enter Student: ");
            PrintStudents(studentDao.GetAllStudents());
            int studentid = ConsoleViewUtils.SafeInputInt();
            System.Console.WriteLine("Enter Subject: ");
            PrintSubjects(subjectDao.GetAllSubjects());
            int subjectid = ConsoleViewUtils.SafeInputInt();
            System.Console.WriteLine("Enter Grade: ");
            int grade = ConsoleViewUtils.SafeInputInt();
            System.Console.WriteLine("Enter Date: ");
            DateOnly date = ConsoleViewUtils.SafeInputDate();

            ExamGrade eg = new ExamGrade(examgradeDao.GenerateID(),studentid,subjectid,grade,date);

            return eg;
        }
        private int InputId()
        {
            System.Console.WriteLine("Enter id: ");
            return ConsoleViewUtils.SafeInputInt();
        }
        private void UpdateExamGrade()
        {
            int id = InputId();
            ExamGrade examgrade = InputExamGrade();
            examgrade.Id = id;
            ExamGrade? updateExamGrade = examgradeDao.UpdateExamGrade(examgrade);
            if (updateExamGrade == null)
            {
                System.Console.WriteLine($"Exam grade not found");
                return;
            }
            System.Console.WriteLine("Exam grade updated");
        }
        private void AddExamGrade()
        {
            ExamGrade examgrade = InputExamGrade();
            examgradeDao.AddExamGrade(examgrade);
            System.Console.WriteLine("Exam grade added");
        }
        private void RemoveExamGrade()
        {
            int id = InputId();
            ExamGrade? removedExamGrade = examgradeDao.RemoveExamGrade(id);
            if (removedExamGrade is null)
            {
                System.Console.WriteLine("Exam grade not found");
                return;
            }

            System.Console.WriteLine("Exam grade removed");
        }
        private void ShowAllExamGrades()
        {
            PrintExamGrades(examgradeDao.GetAllExamGrades());
        }
        private void ShowMenuExamGrade()
        {
            System.Console.WriteLine("\nChoose an option: ");
            System.Console.WriteLine("1: Show All exam grades");
            System.Console.WriteLine("2: Add exam grade");
            System.Console.WriteLine("3: Update exam grade");
            System.Console.WriteLine("4: Remove exam grade");
            System.Console.WriteLine("0: Close");
        }
        public void RunMenuExamGrade()
        {
            while (true)
            {
                ShowMenuExamGrade();
                string userInput = System.Console.ReadLine() ?? "0";
                if (userInput == "0") break;
                HandleMenuInput(userInput);
            }
        }
        private void HandleMenuInput(string input)
        {
            switch (input)
            {
                case "1":
                    ShowAllExamGrades();
                    break;
                case "2":
                    AddExamGrade();
                    break;
                case "3":
                    UpdateExamGrade();
                    break;
                case "4":
                    RemoveExamGrade();
                    break;
            }
        }
    }
}
