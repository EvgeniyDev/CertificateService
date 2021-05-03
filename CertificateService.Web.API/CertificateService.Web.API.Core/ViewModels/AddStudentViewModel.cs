using System;

namespace CertificateService.Web.API.Core.ViewModels
{
    public class AddStudentViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentTicketNumber { get; set; }
        public DateTime StudentTicketDateOfIssue { get; set; }
        public DateTime StudentTicketDateOfExpiry { get; set; }
    }
}
