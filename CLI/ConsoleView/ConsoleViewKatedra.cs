using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI
{
    public class ConsoleViewKatedra
    {
        private readonly KatedraDAO katedraDao;
        private readonly ProfessorDAO professorDao;

        public ConsoleViewKatedra(KatedraDAO katedraDao, ProfessorDAO professorDao)
        {
            this.katedraDao = katedraDao;
            this.professorDao = professorDao;
        }

        private void PrintProfessors(List<Professor> professors)
        {
            foreach (Professor p in professors)
            {
                System.Console.WriteLine(p);
            }
        }
        private void PrintKatedras(List<Katedra> katedras)
        {
            System.Console.WriteLine("Departments: ");
            //System.Console.WriteLine($"ID:{"",3}| Name: {"",20} | Head professor ID: {"",3}");
            foreach (Katedra k in katedras)
            {
                System.Console.WriteLine(k);
            }
        }
        private Katedra InputKatedra()
        {

            System.Console.WriteLine("Enter department name: ");
            string name = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter head id: ");
            PrintProfessors(professorDao.GetAllProfessors());
            int headid = ConsoleViewUtils.SafeInputInt();
            Professor professor = professorDao.GetProfessorById(headid);
            Katedra k = new Katedra(katedraDao.GenerateID(), name, professor);

            return k;
        }
        private int InputId()
        {
            System.Console.WriteLine("Enter id: ");
            return ConsoleViewUtils.SafeInputInt();
        }
        private void UpdateKatedra()
        {
            int id = InputId();
            Katedra katedra = InputKatedra();
            katedra.Id = id;
            Katedra? updateKatedra = katedraDao.UpdateKatedra(katedra);
            if (updateKatedra == null)
            {
                System.Console.WriteLine($"Department not found");
                return;
            }
            System.Console.WriteLine("Department updated");
        }
        private void AddKatedra()
        {
            Katedra katedra = InputKatedra();
            katedraDao.AddKatedra(katedra);
            System.Console.WriteLine("Department added");
        }
        private void RemoveKatedra()
        {
            int id = InputId();
            Katedra? removedKatedra = katedraDao.RemoveKatedra(id);
            if (removedKatedra is null)
            {
                System.Console.WriteLine("Department not found");
                return;
            }

            System.Console.WriteLine("Department removed");
        }
        private void ShowAllKatedras()
        {
            PrintKatedras(katedraDao.GetAllKatedras());
        }
        private void ShowMenuKatedra()
        {
            System.Console.WriteLine("\nChoose an option: ");
            System.Console.WriteLine("1: Show All departments");
            System.Console.WriteLine("2: Add department");
            System.Console.WriteLine("3: Update department");
            System.Console.WriteLine("4: Remove department");
            System.Console.WriteLine("0: Close");
        }
        public void RunMenuKatedra()
        {
            while (true)
            {
                ShowMenuKatedra();
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
                    ShowAllKatedras();
                    break;
                case "2":
                    AddKatedra();
                    break;
                case "3":
                    UpdateKatedra();
                    break;
                case "4":
                    RemoveKatedra();
                    break;
            }
        }
    }
}
