using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Controller
{
    public class StudentSubjectController
    {
        private readonly StudentSubjectDAO studentSubjectDAO;

        public StudentSubjectController()
        {
            studentSubjectDAO = new StudentSubjectDAO();
        }

        public List<StudentSubject> GetAllSubjects()
        {
            return studentSubjectDAO.GetAllSubjects();
        }

        public void Add(StudentSubject studentSubject)
        {
            studentSubjectDAO.AddSubject(studentSubject);
        }

        public void Delete(int studentId,int professorId)
        {
            studentSubjectDAO.RemoveSubject(studentId,professorId);
        }
        public void Update(StudentSubject studentSubject)
        {
            studentSubjectDAO.UpdateSubject(studentSubject);
        }

        public void Subscribe(IObserver observer)
        {
            studentSubjectDAO.studentSubjectSubject.Subscribe(observer);
        }
    }
}
