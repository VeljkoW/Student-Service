using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Controller
{
    public class ProfessorController
    {
        private readonly ProfessorDAO professorDao;

        public ProfessorController()
        {
            professorDao = new ProfessorDAO();
        }

        public List<Professor> GetAllProfessors()
        {
            return professorDao.GetAllProfessors();
        }

        public Professor? GetProfessorById(int id)
        {
            return professorDao.GetProfessorById(id);
        }

        public void Add(Professor professor)
        {
            professorDao.AddProfessor(professor);
        }

        public void Delete(int professorId)
        {
            professorDao.RemoveProfessor(professorId);
        }
        public void Update(Professor professor)
        {
            professorDao.UpdateProfessor(professor);
        }

        public void Subscribe(IObserver observer)
        {
            professorDao.professorSubject.Subscribe(observer);
        }
    }
}
