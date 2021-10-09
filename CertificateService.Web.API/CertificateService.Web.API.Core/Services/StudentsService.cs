using CertificateService.Web.API.Core.Exceptions;
using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Resources;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository studentRepository;

        public StudentsService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task AddAsync(AddStudentViewModel newStudent)
        {
            await studentRepository.AddAsync(new Student()
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

        public async Task DeleteAsync(int id)
        {
            await GetStudentAsync(id);

            await studentRepository.DeleteAsync(id);
        }

        public async Task<StudentViewModel> GetStudentAsync(int id)
        {
            var student = await studentRepository.GetStudentAsync(s => s.Id == id);

            if (student == null)
            {
                var errorMessage = string.Format(ErrorMessages.NotFound, $"{nameof(Student)} by requested id '{id}' was");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return MapStudent(student);
        }

        public async Task<StudentViewModel> GetStudentAsync(string name, string surname, string patornymic)
        {
            var student = await studentRepository
                .GetStudentAsync(s => s.StudentData.Name == name && s.StudentData.Surname == surname && s.StudentData.Patronymic == patornymic);

            if (student == null)
            {
                var errorMessage = string.Format(ErrorMessages.NotFound, $"{nameof(Student)} by requested full name '{name}, {surname}, {patornymic}' was");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return MapStudent(student);
        }

        public async Task<StudentViewModel> GetStudentAsync(string studentTicketNumber)
        {
            var student = await studentRepository.GetStudentAsync(s => s.StudentTicket.Number == studentTicketNumber);

            if (student == null)
            {
                var errorMessage = string.Format(ErrorMessages.NotFound, $"{nameof(Student)} by requested student ticket number '{studentTicketNumber}' was");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            return MapStudent(student);
        }

        public async Task<IEnumerable<StudentViewModel>> GetStudentsAsync()
        {
            var studentViewModels = new List<StudentViewModel>();
            var students = (await studentRepository.GetStudentsAsync()).ToList();

            if (!students.Any())
            {
                var errorMessage = string.Format(ErrorMessages.NotFound, "Students were");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            for (int i = 0; i < students.Count; i++)
            {
                studentViewModels.Add(MapStudent(students[i]));
            }

            return studentViewModels;
        }

        private StudentViewModel MapStudent(Student student)
        {
            return new StudentViewModel()
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
        }

        public async Task UpdateAsync(StudentViewModel student)
        {
            var studentInDb = await studentRepository.GetStudentAsync(s => s.Id == student.Id);

            if (studentInDb == null)
            {
                var errorMessage = string.Format(ErrorMessages.NotFound, $"{nameof(Student)} by requested id was");
                throw new HttpStatusException(HttpStatusCode.NotFound, errorMessage);
            }

            studentInDb.StudentData.Name = student.Name;
            studentInDb.StudentData.Surname = student.Surname;
            studentInDb.StudentData.Patronymic = student.Patronymic;
            studentInDb.StudentData.DateOfBirth = student.DateOfBirth;
            studentInDb.StudentTicket.Number = student.StudentTicketNumber;
            studentInDb.StudentTicket.DateOfIssue = student.StudentTicketDateOfIssue;
            studentInDb.StudentTicket.DateOfExpiry = student.StudentTicketDateOfExpiry;

            await studentRepository.UpdateAsync(studentInDb);
        }
    }
}
