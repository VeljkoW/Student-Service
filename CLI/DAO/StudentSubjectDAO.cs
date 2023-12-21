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
        public StudentSubjectDAO()
        {
            storage = new Storage<StudentSubject>("StudentSubject.csv");
            studentStubjects = storage.Load();
        }
        public StudentSubject AddSubject(StudentSubject studentSubject)
        {
            studentStubjects.Add(studentSubject);
            storage.Save(studentStubjects);
            return studentSubject;
        }
        public StudentSubject? UpdateSubject(StudentSubject studentSubject)
        {
            StudentSubject? oldObj = GetSubjectById(studentSubject.studentId);
            if (oldObj is null) return null;

            oldObj.studentId = studentSubject.studentId;
            oldObj.subjectId = studentSubject.subjectId;

            storage.Save(studentStubjects);
            return oldObj;
        }
        public StudentSubject? RemoveSubject(int id)
        {
            StudentSubject? subject = GetSubjectById(id);
            if (subject == null) return null;

            studentStubjects.Remove(subject);
            storage.Save(studentStubjects);
            return subject;
        }
        public StudentSubject? GetSubjectById(int id)
        {
            return studentStubjects.Find(v => v.studentId == id);
        }
    }
}
