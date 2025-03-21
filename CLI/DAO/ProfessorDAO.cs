﻿using CLI.Observer;
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
        public ObserverSubject professorSubject;

        public ProfessorDAO()
        {
            storage = new Storage<Professor>("Professors.csv");
            professors = storage.Load();
            professorSubject = new ObserverSubject();
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
            professorSubject.NotifyObservers();
            return professor;
        }
        public Professor? UpdateProfessor(Professor professor)
        {
            Professor? oldProfessor = GetProfessorById(professor.Id);
            if (oldProfessor is null) return null;
            oldProfessor.Name = professor.Name;
            oldProfessor.Surname = professor.Surname;
            oldProfessor.DateOfBirth = professor.DateOfBirth;
            oldProfessor.ProfessorAdress = professor.ProfessorAdress;
            oldProfessor.PhoneNumber= professor.PhoneNumber;
            oldProfessor.EmailAdress = professor.EmailAdress;
            oldProfessor.IDCardNumber = professor.IDCardNumber;
            oldProfessor.Title = professor.Title;
            oldProfessor.YearsOfService = professor.YearsOfService;
            oldProfessor.Subjects = professor.Subjects;
            oldProfessor.DepartmentId = professor.DepartmentId;
            storage.Save(professors);
            professorSubject.NotifyObservers();
            return oldProfessor;

        }
        public Professor? RemoveProfessor(int id)
        {
            Professor? professor = GetProfessorById(id);
            if (professor == null) return null;

            professors.Remove(professor);
            storage.Save(professors);
            professorSubject.NotifyObservers();
            return professor;
        }

        public Professor? GetProfessorById(int id)
        {
            return professors.Find(p => p.Id == id);
        }
        public List<Professor> GetAllProfessors()
        {
            return professors;
        }
    }
}
