using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.models;

namespace CLI
{
    public class StudentDAO
    {
        private readonly List<Student> students;
        private readonly Storage<Student> storage;
        public StudentDAO()
        {
            storage = new Storage<Student>("Students.csv");
            students = storage.Load();
        }
        public int GenerateId()
        {
            if (students.Count == 0) return 0;
            return students[^1].Id + 1;
        }
        public Student AddStudent(Student stud)
        {
            stud.Id = GenerateId();
            students.Add(stud);
            storage.Save(students);
            return stud;
        }
        public Student? UpdateStudent(Student stud)
        {
                Student? old = GetStudentById(stud.Id);
                if (old is null) return null;
                old.Phone = stud.Phone;
                old.Surname = stud.Surname;
                old.Name = stud.Name;
                old.Email = stud.Email;
                old.DateOfBirth = stud.DateOfBirth;
                old.AdressId = stud.AdressId;
                old.ToDoExams = stud.ToDoExams;
                old.FinishedExams = stud.FinishedExams;
                storage.Save(students);
                return old;
        }
        public Student? RemoveStudent(int id)
        {
            Student? student = GetStudentById(id);
            if (student == null) return null;

            students.Remove(student);
            storage.Save(students);
            return student;
        }
        public List<Student> GetAllStudent()
        {
            return students;
        }
        private Student? GetStudentById(int id)
        {
            return students.Find(v => v.Id == id);
        }
    }
}
