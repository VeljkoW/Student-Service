using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class SubjectDAO
    {
        private readonly List<Subject> subjects;
        private readonly Storage<Subject> storage;
        public ObserverSubject subjectSubject;

        public SubjectDAO()
        {
            storage = new Storage<Subject>("Subject.csv");
            subjects = storage.Load();
            subjectSubject = new ObserverSubject();
        }
        public int GenerateID()
        {
            if (subjects.Count == 0) return 0;
            return subjects[^1].Id + 1;
        }

        public Subject AddSubject(Subject subject)
        {
            subject.Id = GenerateID();
            subjects.Add(subject);
            storage.Save(subjects);
            return subject;
        }

        public Subject? UpdateSubject(Subject subject)
        {
            Subject? oldSubject = GetSubjectById(subject.Id);
            if (oldSubject is null) return null;

            oldSubject.SubjectID = subject.SubjectID;
            oldSubject.SubjectName = subject.SubjectName;
            oldSubject.Semester = subject.Semester;
            oldSubject.Year = subject.Year;
            oldSubject.ProfessorId= subject.ProfessorId;
            oldSubject.ESPBPoints = subject.ESPBPoints;
            oldSubject.StudentsWhoPassed= subject.StudentsWhoPassed;
            oldSubject.StudentsWhoDidntPass= subject.StudentsWhoDidntPass;

            storage.Save(subjects);
            return oldSubject;
        }
        public Subject? RemoveSubject(int id)
        {
            Subject? subject = GetSubjectById(id);
            if (subject == null) return null;

            subjects.Remove(subject);
            storage.Save(subjects);
            return subject;
        }
        public Subject? GetSubjectById(int id)
        {
            return subjects.Find(v => v.Id == id);
        }

        public List<Subject> GetAllSubjects()
        {
            return subjects;
        }

    }
}
