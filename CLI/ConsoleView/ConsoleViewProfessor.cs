using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI
{
    public class ConsoleViewProfessor
    {
        private readonly ProfessorDAO professorDao;

        public ConsoleViewProfessor(ProfessorDAO professorDao)
        {
            this.professorDao = professorDao;
        }

        private void PrintAdresses(List<Adress> adresses)
        {
            foreach (Adress v in adresses)
            {
                System.Console.WriteLine(v);
            }
        }
        private void PrintProfessors(List<Professor> professors)
        {
            System.Console.WriteLine("Professors: ");
            //System.Console.WriteLine($"ID:{"",3}| Name: {"",20} | Surname: {"",25} | Date of bitrh: {"",15} | Adress ID:{"",3}| Phone: {"",13} | E-mail: {"",64} | ID card number: {"",10} | Title: {"",10} | Years of service: {"",2}");
            foreach (Professor p in professors)
            {
                System.Console.WriteLine(p);
            }
        }
        private Professor InputProfessor()
        {
            System.Console.WriteLine("Enter name: ");
            string name = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter surname: ");
            string surname = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter birth date: ");
            DateOnly birthdate = DateOnly.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter adress: 'Street , City , State'");
            Adress adress = new Adress(System.Console.ReadLine() ?? string.Empty);
            System.Console.WriteLine("Enter phone number: ");
            string phone = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter E-mail: ");
            string email = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter ID card number: ");
            string idcard = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter title: ");
            string title = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter years of service: ");
            int yearsofservice = ConsoleViewUtils.SafeInputInt();

            Professor p = new Professor(professorDao.GenerateID(),name,surname,birthdate, adress, phone,email,idcard,title,yearsofservice);
            return p;
        }
        private int InputId()
        {
            System.Console.WriteLine("Enter id: ");
            return ConsoleViewUtils.SafeInputInt();
        }
        private void UpdateProfessor()
        {
            int id = InputId();
            Professor professor = InputProfessor();
            professor.Id = id;
            Professor? updateProfessor = professorDao.UpdateProfessor(professor);
            if (updateProfessor == null)
            {
                System.Console.WriteLine($"Professor not found");
                return;
            }
            System.Console.WriteLine("Professor updated");
        }
        private void AddProfessor()
        {
            Professor professor = InputProfessor();
            professorDao.AddProfessor(professor);
            System.Console.WriteLine("Professor added");
        }
        private void RemoveProfessor()
        {
            int id = InputId();
            Professor? removedProfessor = professorDao.RemoveProfessor(id);
            if (removedProfessor is null)
            {
                System.Console.WriteLine("Professor not found");
                return;
            }

            System.Console.WriteLine("Professor removed");
        }
        private void ShowAllProfessors()
        {
            PrintProfessors(professorDao.GetAllProfessors());
        }
        private void ShowMenuProfessor()
        {
            System.Console.WriteLine("\nChoose an option: ");
            System.Console.WriteLine("1: Show All professors");
            System.Console.WriteLine("2: Add professor");
            System.Console.WriteLine("3: Update professor");
            System.Console.WriteLine("4: Remove professor");
            System.Console.WriteLine("0: Close");
        }
        public void RunMenuProfessor()
        {
            while (true)
            {
                ShowMenuProfessor();
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
                    ShowAllProfessors();
                    break;
                case "2":
                    AddProfessor();
                    break;
                case "3":
                    UpdateProfessor();
                    break;
                case "4":
                    RemoveProfessor();
                    break;
            }
        }
    }
}
