using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Controller
{
    public class StudentController
    {
        private readonly StudentDAO studentDao;

        public StudentController()
        {
            studentDao = new StudentDAO();
        }

        public List<Student> GetAllStudents()
        {
            return studentDao.GetAllStudents();
        }

        public void Add(Student student)
        {
            studentDao.AddStudent(student);
        }

        public void Delete(int studentId)
        {
            studentDao.RemoveStudent(studentId);
        }

        public void Subscribe(IObserver observer)
        {
            studentDao.studentSubject.Subscribe(observer);
        }
    }
}
