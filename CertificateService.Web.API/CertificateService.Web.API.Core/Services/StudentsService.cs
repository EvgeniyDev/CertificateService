using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CertificateService.Web.API.Core.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository studentRepository;

        public StudentsService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void Add(AddStudentViewModel newStudent)
        {
            studentRepository.Add(new Student()
            {
                StudentData = new StudentData()
                {
                    Name = newStudent.Name,
                    Surname = newStudent.Surname,
                    Patronymic = newStudent.Patronymic
                },
                StudentTicket = new StudentTicket()
                {
                    Number = newStudent.StudentTicketNumber,
                    DateOfIssue = newStudent.StudentTicketDateOfIssue,
                    DateOfExpiry = newStudent.StudentTicketDateOfExpiry
                }
            });
        }

        public void Delete(int id)
        {
            studentRepository.Delete(id);
        }

        public StudentViewModel GetStudent(int id)
        {
            var student = studentRepository.GetStudentById(id);

            var studentViewModel = new StudentViewModel()
            {
                Id = student.Id,
                Name = student.StudentData.Name,
                Surname = student.StudentData.Surname,
                Patronymic = student.StudentData.Patronymic,
                DateOfBirth = student.StudentData.DateOfBirth,
                StudentTicketNumber = student.StudentTicket.Number,
                StudentTicketDateOfIssue = student.StudentTicket.DateOfIssue,
                StudentTicketDateOfExpiry = student.StudentTicket.DateOfExpiry
            };

            return studentViewModel;
        }

        public IEnumerable<StudentViewModel> GetStudents()
        {
            var studentViewModels = new List<StudentViewModel>();
            var students = studentRepository.GetStudents().ToList();

            for (int i = 0; i < students.Count; i++)
            {
                studentViewModels.Add(new StudentViewModel()
                {
                    Id = students[i].Id,
                    Name = students[i].StudentData.Name,
                    Surname = students[i].StudentData.Surname,
                    Patronymic = students[i].StudentData.Patronymic,
                    StudentTicketNumber = students[i].StudentTicket.Number,
                    StudentTicketDateOfIssue = students[i].StudentTicket.DateOfIssue,
                    StudentTicketDateOfExpiry = students[i].StudentTicket.DateOfExpiry
                });
            }

            return studentViewModels;
        }

        public void Update(StudentViewModel student)
        {
            var studentInDb = studentRepository.GetStudentById(student.Id);

            if (studentInDb == null)
            {
                return;
            }

            studentInDb.StudentData.Name = student.Name;
            studentInDb.StudentData.Surname = student.Surname;
            studentInDb.StudentData.Patronymic = student.Patronymic;
            studentInDb.StudentData.DateOfBirth = student.DateOfBirth;
            studentInDb.StudentTicket.Number = student.StudentTicketNumber;
            studentInDb.StudentTicket.DateOfIssue = student.StudentTicketDateOfIssue;
            studentInDb.StudentTicket.DateOfExpiry = student.StudentTicketDateOfExpiry;

            studentRepository.Update(studentInDb);
        }
    }
}
