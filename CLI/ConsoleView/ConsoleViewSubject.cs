using CLI.models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class ConsoleViewSubject
    {
        private readonly SubjectDAO subjectDao;
        private readonly ProfessorDAO professorDao;

        public ConsoleViewSubject(SubjectDAO subjectDao, ProfessorDAO professorDao)
        {
            this.subjectDao = subjectDao;
            this.professorDao = professorDao;
        }

        private void PrintProfessors(List<Professor> professors)
        {
            foreach (Professor p in professors)
            {
                System.Console.WriteLine(p);
            }
        }

        private void PrintSubjects(List<Subject> subjects)
        {
            System.Console.WriteLine("Subjects: ");
            System.Console.WriteLine($"ID:{"",3}| Name: {"",20} | Semester: {"",6} | Year: {"",4} | Professor ID:{"",3}| ESPB Points: {"",1}");
            foreach (Subject s in subjects)
            {
                System.Console.WriteLine(s);
            }
        }

        private Subject InputSubject()
        {
            System.Console.WriteLine("Enter subject Name: ");
            string name = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter semester (0 - LETNJI, 1 - ZIMSKI): ");
            Semester semester = new Semester();
            do {
                int x = ConsoleViewUtils.SafeInputInt();
                if (x == 0)
                {
                    semester = Semester.LETNJI;
                }
                else if (x == 1)
                {
                    semester = Semester.ZIMSKI;
                }
            } while(ConsoleViewUtils.SafeInputInt() != 0 || ConsoleViewUtils.SafeInputInt() != 1);
            System.Console.WriteLine("Enter Year: ");
            int year = ConsoleViewUtils.SafeInputInt();
            System.Console.WriteLine("Enter Professor ID: ");
            PrintProfessors(professorDao.GetAllProfessors());
            int professorid = ConsoleViewUtils.SafeInputInt();
            System.Console.WriteLine("Enter ESPB Points: ");
            int espb = ConsoleViewUtils.SafeInputInt();
            Subject s = new Subject(subjectDao.GenerateID(),name,semester,year,professorid,espb);
            return s;
        }
        private int InputId()
        {
            System.Console.WriteLine("Enter id: ");
            return ConsoleViewUtils.SafeInputInt();
        }
        private void UpdateSubject()
        {
            int id = InputId();
            Subject subject = InputSubject();
            subject.SubjectID = id;
            Subject? updateSubject = subjectDao.UpdateSubject(subject);
            if (updateSubject == null)
            {
                System.Console.WriteLine($"Subject not found");
                return;
            }
            System.Console.WriteLine("Subject updated");
        }
        private void AddSubject()
        {
            Subject subject = InputSubject();
            subjectDao.AddSubject(subject);
            System.Console.WriteLine("Subject added");
        }
        private void RemoveSubject()
        {
            int id = InputId();
            Subject? removedSubject = subjectDao.RemoveSubject(id);
            if (removedSubject is null)
            {
                System.Console.WriteLine("Subject not found");
                return;
            }

            System.Console.WriteLine("Subject removed");
        }
        private void ShowAllSubjects()
        {
            PrintSubjects(subjectDao.GetAllSubjects());
        }
        private void ShowMenuSubject()
        {
            System.Console.WriteLine("\nChoose an option: ");
            System.Console.WriteLine("1: Show All subjects");
            System.Console.WriteLine("2: Add subjects");
            System.Console.WriteLine("3: Update subjects");
            System.Console.WriteLine("4: Remove subjects");
            System.Console.WriteLine("0: Close");
        }
        public void RunMenuSubject()
        {
            while (true)
            {
                ShowMenuSubject();
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
                    ShowAllSubjects();
                    break;
                case "2":
                    AddSubject();
                    break;
                case "3":
                    UpdateSubject();
                    break;
                case "4":
                    RemoveSubject();
                    break;
            }
        }
    }
}
