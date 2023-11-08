using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class ProfessorDAO
    {
        private readonly List<Professor> professors;
        private readonly Storage<Professor> storage;

        public ProfessorDAO()
        {
            storage = new Storage<Professor>("Professors.csv");
            professors = storage.Load();
        }
        public int GenerateID()
        {
            if (professors.Count == 0) return 0;
            return professors[^1].Id + 1;
        }

        public Professor AddProfessor(Professor professor)
        {
            professor.Id = GenerateID();
            professors.Add(professor);
            storage.Save(professors);
            return professor;
        }
        public Professor? UpdateProfessor(Professor professor)
        {
            Professor? oldProfessor = GetProfessorById(professor.Id);
            if (oldProfessor is null) return null;
            oldProfessor.Name = professor.Name;
            oldProfessor.Surname = professor.Surname;
            oldProfessor.DateOfBirth = professor.DateOfBirth;
            oldProfessor.ProfessorAdressId = professor.ProfessorAdressId;
            oldProfessor.PhoneNumber= professor.PhoneNumber;
            oldProfessor.EmailAdress = professor.EmailAdress;
            oldProfessor.IDCardNumber = professor.IDCardNumber;
            oldProfessor.Title = professor.Title;
            oldProfessor.YearsOfService = professor.YearsOfService;
            oldProfessor.Subjects = professor.Subjects;
            storage.Save(professors);
            return oldProfessor;

        }
        public Professor? RemoveProfessor(int id)
        {
            Professor? professor = GetProfessorById(id);
            if (professor == null) return null;

            professors.Remove(professor);
            storage.Save(professors);
            return professor;
        }

        private Professor? GetProfessorById(int id)
        {
            return professors.Find(p => p.Id == id);
        }
        public List<Professor> GetAllProfessors()
        {
            return professors;
        }
    }
}
