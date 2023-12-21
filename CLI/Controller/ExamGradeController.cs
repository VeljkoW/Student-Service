using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Controller
{
    public class ExamGradeController
    {
        private readonly ExamGradeDAO examgradeDao;

        public ExamGradeController()
        {
            examgradeDao = new ExamGradeDAO();
        }

        public List<ExamGrade> GetAllExamGrades()
        {
            return examgradeDao.GetAllExamGrades();
        }

        public void Add(ExamGrade examgrade)
        {
            examgradeDao.AddExamGrade(examgrade);
        }

        public void Delete(int examgradeId)
        {
            examgradeDao.RemoveExamGrade(examgradeId);
        }

        public void Subscribe(IObserver observer)
        {
            examgradeDao.examGradeSubject.Subscribe(observer);
        }
    }
}
