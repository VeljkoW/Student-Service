using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class ExamGradeDAO
    {
        private readonly List<ExamGrade> examgrades;
        private readonly Storage<ExamGrade> storage;
        public ObserverSubject examGradeSubject;
        public ExamGradeDAO()
        {
            storage = new Storage<ExamGrade>("ExamGrades.csv");
            examgrades = storage.Load();
            examGradeSubject = new ObserverSubject();
        }
        public int GenerateID()
        {
            if (examgrades.Count == 0) return 0;
            return examgrades[^1].Id + 1;
        }
        public ExamGrade AddExamGrade(ExamGrade examgrade)
        {
            examgrade.Id = GenerateID();
            examgrades.Add(examgrade);
            storage.Save(examgrades);
            examGradeSubject.NotifyObservers();
            return examgrade;
        }
        public ExamGrade? UpdateExamGrade(ExamGrade examgrade)
        {
            ExamGrade? oldExamGrade = GetExamGradeById(examgrade.Id);
            if (oldExamGrade is null) return null;
            oldExamGrade.StudentId = examgrade.StudentId;
            oldExamGrade.SubjectId = examgrade.SubjectId;
            oldExamGrade.Grade = examgrade.Grade;
            oldExamGrade.Date = examgrade.Date;
            storage.Save(examgrades);
            examGradeSubject.NotifyObservers();
            return oldExamGrade;

        }
        private ExamGrade? GetExamGradeById(int id)
        {
            return examgrades.Find(e => e.Id == id);
        }
        public ExamGrade? RemoveExamGrade(int id)
        {
            ExamGrade? examgrade = GetExamGradeById(id);
            if (examgrade == null) return null;

            examgrades.Remove(examgrade);
            storage.Save(examgrades);
            examGradeSubject.NotifyObservers();
            return examgrade;
        }
        public List<ExamGrade> GetAllExamGrades()
        {
            return examgrades;
        }
        public double getAverageGrade(int subjectid)
        {
            int sum = 0;
            int cnt = 0;
            foreach (ExamGrade e in examgrades)
            {
                if (e.Id == subjectid)
                {
                    sum += e.Grade;
                    cnt++;
                }
            }
            if (cnt == 0)
            {
                return 5;
            }
            return sum / cnt;
        }

    }
}
