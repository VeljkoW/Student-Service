using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class SubjectController
    {
        private readonly SubjectDAO subjectDao;

        public SubjectController()
        {
            subjectDao = new SubjectDAO();
        }

        public List<Subject> GetAllSubjects()
        {
            return subjectDao.GetAllSubjects();
        }

        public void Add(Subject subject)
        {
            subjectDao.AddSubject(subject);
        }
        public void Update(Subject subject)
        {
            subjectDao.UpdateSubject(subject);
        }

        public void Delete(string subjectId)
        {
            subjectDao.RemoveSubject(subjectId);
        }

        public void Subscribe(IObserver observer)
        {
            subjectDao.subjectSubject.Subscribe(observer);
        }
    }
}
