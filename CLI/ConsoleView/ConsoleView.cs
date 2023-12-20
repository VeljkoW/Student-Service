using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class ConsoleView
    {
        private readonly ConsoleViewExamGrade consoleviewexamgrade;
        private readonly ConsoleViewKatedra consoleviewkatedra;
        private readonly ConsoleViewProfessor consoleviewprofessor;
        private readonly ConsoleViewStudent consoleviewstudent;
        private readonly ConsoleViewSubject consoleviewsubject;

        public ConsoleView( ConsoleViewExamGrade consoleviewexamgrade, ConsoleViewKatedra consoleviewkatedra, ConsoleViewProfessor consoleviewprofessor, ConsoleViewStudent consoleviewstudent, ConsoleViewSubject consoleviewsubject)
        {
            this.consoleviewexamgrade = consoleviewexamgrade;
            this.consoleviewkatedra = consoleviewkatedra;
            this.consoleviewprofessor = consoleviewprofessor;
            this.consoleviewstudent = consoleviewstudent;
            this.consoleviewsubject = consoleviewsubject;
        }
        

        public void RunMenu()
        {
            while (true)
            {
                ShowMenu();
                string userInput = System.Console.ReadLine() ?? "0";
                if (userInput == "0") break;
                HandleMenuInput(userInput);
            }
        }
        private void ShowMenu()
        {
            System.Console.WriteLine("\nChoose an option: ");
            System.Console.WriteLine("1: Student options");
            System.Console.WriteLine("2: Professor options");
            System.Console.WriteLine("3: Subject options");
            System.Console.WriteLine("4: Exam grade options");
            System.Console.WriteLine("5: Department options");
            System.Console.WriteLine("0: Close");
        }
        private void HandleMenuInput(string input)
        {
            switch (input)
            {
                case "1":
                    consoleviewstudent.RunMenuStudent();
                    break;
                case "2":
                    consoleviewprofessor.RunMenuProfessor();
                    break;
                case "3":
                    consoleviewsubject.RunMenuSubject();
                    break;
                case "4":
                    consoleviewexamgrade.RunMenuExamGrade();
                    break;
                case "5":
                    consoleviewkatedra.RunMenuKatedra();
                    break;
            }
        }
    }
}
