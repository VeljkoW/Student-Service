using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class StudentSubjectDAO
    {
        private readonly List<StudentSubject> studentStubjects;
        private readonly Storage<StudentSubject> storage;
        public ObserverSubject studentSubjectSubject;
        public StudentSubjectDAO()
        {
            storage = new Storage<StudentSubject>("StudentSubject.csv");
            studentStubjects = storage.Load();
            studentSubjectSubject = new ObserverSubject();
        }
        public StudentSubject AddSubject(StudentSubject studentSubject)
        {
            studentStubjects.Add(studentSubject);
            storage.Save(studentStubjects);
            return studentSubject;
        }
        public StudentSubject? UpdateSubject(StudentSubject studentSubject)
        {
            StudentSubject? oldObj = GetSubjectById(studentSubject.studentId,studentSubject.subjectId);
            if (oldObj is null) return null;

            oldObj.studentId = studentSubject.studentId;
            oldObj.subjectId = studentSubject.subjectId;

            storage.Save(studentStubjects);
            return oldObj;
        }
        public List<StudentSubject> GetAllSubjects()
        {
            return studentStubjects;
        }
        public StudentSubject? RemoveSubject(int studentId,int subjectId)
        {
            StudentSubject? subject = GetSubjectById(studentId, subjectId);
            if (subject == null) return null;

            studentStubjects.Remove(subject);
            storage.Save(studentStubjects);
            return subject;
        }
        public StudentSubject? GetSubjectById(int studentIdd,int subjectIdd)
        {
            return studentStubjects.Find(v => v.studentId == studentIdd && v.subjectId==subjectIdd);
        }
    }
}