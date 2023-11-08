using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI
{
    public class ConsoleViewStudent
    {

        private readonly StudentDAO studentDao;
        private readonly AdressDAO adressDao;

        public ConsoleViewStudent(StudentDAO studentDao,AdressDAO adressDao)
        {
            this.studentDao = studentDao;
            this.adressDao = adressDao;
        }

        private void PrintAdresses(List<Adress> adresses)
        {
            foreach (Adress v in adresses)
            {
                System.Console.WriteLine(v);
            }
        }

        private void PrintStudents(List<Student> students)
        {
            System.Console.WriteLine("Students: ");
            System.Console.WriteLine($"ID:{"",3}| Name: {"",20} | Surname: {"",25} | Date of bitrh: {"",15} |Adress ID:{"",3}| Phone: {"",13} | E-mail: {"",64} | Index: {"",10} | Student Year: {"",2} | Grade Average: {"",4}");
            foreach (Student v in students)
            {
                System.Console.WriteLine(v);
            }
        }
        private Student InputStudent()
        {
            
            System.Console.WriteLine("Enter Name: ");
            string name = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter surname: ");
            string surname = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter birth date: ");
            DateOnly birthdate = ConsoleViewUtils.SafeInputDate();
            System.Console.WriteLine("Choose Adress ID: ");
            PrintAdresses(adressDao.GetAllAdresses());
            int adressid = InputId();
            System.Console.WriteLine("Enter phone number: ");
            string phone = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter E-mail: ");
            string email = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter Index: ");
            string index = System.Console.ReadLine() ?? string.Empty;
            Index indeks = new Index(index);
            System.Console.WriteLine("Enter student year: ");
            int studentyear = ConsoleViewUtils.SafeInputInt();
            Student s = new Student(studentDao.GenerateId(), name, surname, birthdate, adressid, phone, email, indeks , studentyear, (float) 0);

            return s;
        }
        private int InputId()
        {
            System.Console.WriteLine("Enter id: ");
            return ConsoleViewUtils.SafeInputInt();
        }
        private void UpdateStudent()
        {
            int id = InputId();
            Student student = InputStudent();
            student.Id = id;
            Student? updateStudent = studentDao.UpdateStudent(student);
            if (updateStudent == null)
            {
                System.Console.WriteLine($"Student not found");
                return;
            }
            System.Console.WriteLine("Student updated");
        }
        private void AddStudent()
        {
            Student student = InputStudent();
            studentDao.AddStudent(student);
            System.Console.WriteLine("Student added");
        }


    }
}
