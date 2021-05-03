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
        private readonly IStudentDataRepository studentDataRepository;
        private readonly IStudentTicketRepository studentTicketRepository;

        public StudentsService(
            IStudentRepository studentRepository,
            IStudentDataRepository studentDataRepository,
            IStudentTicketRepository studentTicketRepository)
        {
            this.studentRepository = studentRepository;
            this.studentDataRepository = studentDataRepository;
            this.studentTicketRepository = studentTicketRepository;
        }

        public void Add(StudentViewModel newStudent)
        {
            studentTicketRepository.Add(new StudentTicket()
            {
                Number = newStudent.StudentTicketNumber,
                DateOfIssue = newStudent.StudentTicketDateOfIssue,
                DateOfExpiry = newStudent.StudentTicketDateOfExpiry
            });
            studentDataRepository.Add(new StudentData()
            {
                Name = newStudent.Name,
                Surname = newStudent.Surname,
                Patronymic = newStudent.Patronymic
            });
            studentRepository.Add(new Student()
            {
                GroupId = newStudent.GroupId,
                // Rewrite to get by predicate
                StudentDataId = studentDataRepository.GetStudentDatas().Last().Id,
                StudentTicketId = studentTicketRepository.GetStudentTickets().Last().Id
            });
        }

        public void Delete(int id)
        {
            var student = studentRepository.GetStudentById(id);

            studentRepository.Delete(id);
            studentDataRepository.Delete(student.StudentDataId);
            studentTicketRepository.Delete(student.StudentTicketId);
        }

        public StudentViewModel GetStudent(int id)
        {
            var student = studentRepository.GetStudentById(id);
            var studentData = studentDataRepository.GetStudentDataById(student.StudentDataId);
            var studentTicket = studentTicketRepository.GetStudentTicketById(student.StudentTicketId);

            var studentViewModel = new StudentViewModel()
            {
                Id = student.Id,
                Name = studentData.Name,
                Surname = studentData.Surname,
                Patronymic = studentData.Patronymic,
                DateOfBirth = studentData.DateOfBirth,
                StudentTicketNumber = studentTicket.Number,
                StudentTicketDateOfIssue = studentTicket.DateOfIssue,
                StudentTicketDateOfExpiry = studentTicket.DateOfExpiry
            };

            return studentViewModel;
        }

        public IEnumerable<StudentViewModel> GetStudents()
        {
            var studentViewModels = new List<StudentViewModel>();

            var students = studentRepository.GetStudents().ToList();
            var studentDatas = studentDataRepository.GetStudentDatas().ToList();
            var studentTickets = studentTicketRepository.GetStudentTickets().ToList();

            for (int i = 0; i < students.Count; i++)
            {
                studentViewModels.Add(new StudentViewModel()
                {
                    Id = students[i].Id,
                    Name = studentDatas[i].Name,
                    Surname = studentDatas[i].Surname,
                    Patronymic = studentDatas[i].Patronymic,
                    StudentTicketNumber = studentTickets[i].Number,
                    StudentTicketDateOfIssue = studentTickets[i].DateOfIssue,
                    StudentTicketDateOfExpiry = studentTickets[i].DateOfExpiry
                });
            }

            return studentViewModels;
        }

        public void Update(StudentViewModel student)
        {
            var studentInDb = studentRepository.GetStudentById(student.Id);

            if (studentInDb == null)
            {
                Add(student);

                return;
            }

            var studentToUpdate = new Student()
            {
                Id = student.Id,
                GroupId = student.GroupId
            };
            var studentDataToUpdate = new StudentData()
            {
                Id = studentInDb.StudentDataId,
                Name = student.Name,
                Surname = student.Surname,
                Patronymic = student.Patronymic,
                DateOfBirth = student.DateOfBirth
            };
            var studentTicketToUpdate = new StudentTicket()
            {
                Id = studentInDb.StudentTicketId,
                Number = student.StudentTicketNumber,
                DateOfIssue = student.StudentTicketDateOfIssue,
                DateOfExpiry = student.StudentTicketDateOfExpiry
            };

            studentRepository.Update(studentToUpdate);
            studentDataRepository.Update(studentDataToUpdate);
            studentTicketRepository.Update(studentTicketToUpdate);
        }
    }
}
