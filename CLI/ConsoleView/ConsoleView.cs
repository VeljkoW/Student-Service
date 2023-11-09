using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class ConsoleView
    {
        private readonly ConsoleViewAdress consoleviewadress;
        private readonly ConsoleViewExamGrade consoleviewexamgrade;
        private readonly ConsoleViewKatedra consoleviewkatedra;
        private readonly ConsoleViewProfessor consoleviewprofessor;
        private readonly ConsoleViewStudent consoleviewstudent;
        private readonly ConsoleViewSubject consoleviewsubject;

        public ConsoleView(ConsoleViewAdress consoleviewadress, ConsoleViewExamGrade consoleviewexamgrade, ConsoleViewKatedra consoleviewkatedra, ConsoleViewProfessor consoleviewprofessor, ConsoleViewStudent consoleviewstudent, ConsoleViewSubject consoleviewsubject)
        {
            this.consoleviewadress = consoleviewadress;
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
            System.Console.WriteLine("1: Adress options");
            System.Console.WriteLine("2: Student options");
            System.Console.WriteLine("3: Professor options");
            System.Console.WriteLine("4: Subject options");
            System.Console.WriteLine("5: Exam grade options");
            System.Console.WriteLine("6: Department options");
            System.Console.WriteLine("0: Close");
        }
        private void HandleMenuInput(string input)
        {
            switch (input)
            {
                case "1":
                    consoleviewadress.RunMenuAdress();
                    break;
                case "2":
                    consoleviewstudent.RunMenuStudent();
                    break;
                case "3":
                    consoleviewprofessor.RunMenuProfessor();
                    break;
                case "4":
                    consoleviewsubject.RunMenuSubject();
                    break;
                case "5":
                    consoleviewexamgrade.RunMenuExamGrade();
                    break;
                case "6":
                    consoleviewkatedra.RunMenuKatedra();
                    break;
            }
        }
    }
}
