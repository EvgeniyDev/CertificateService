using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IStudentTicketRepository
    {
        public IEnumerable<StudentTicket> GetStudentTickets();
        public StudentTicket GetStudentTicketById(int id);
        public StudentTicket GetStudentTicketByNumber(string number);
        public void Add(StudentTicket newStudentTicket);
        public void Update(StudentTicket studentTicket);
        public void Delete(int id);
        public void Save();
    }
}
