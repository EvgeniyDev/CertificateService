using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CertificateService.Web.API.Data.Repositories
{
    public class StudentTicketRepository : IStudentTicketRepository
    {
        private readonly AppDBContext appDBContext;

        public StudentTicketRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void Add(StudentTicket newStudentTicket)
        {
            appDBContext.StudentTickets.Add(newStudentTicket);
            Save();
        }

        public void Delete(int id)
        {
            var studentTicketToDelete = GetStudentTicketById(id);

            if (studentTicketToDelete != null)
            {
                appDBContext.StudentTickets.Remove(studentTicketToDelete);
                Save();
            }
        }

        public StudentTicket GetStudentTicketById(int id)
        {
            return appDBContext.StudentTickets.FirstOrDefault(x => x.Id == id);
        }

        public StudentTicket GetStudentTicketByNumber(string number)
        {
            return appDBContext.StudentTickets.FirstOrDefault(x => x.Number == number);
        }

        public IEnumerable<StudentTicket> GetStudentTickets()
        {
            return appDBContext.StudentTickets.AsEnumerable();
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }

        public void Update(StudentTicket studentTicket)
        {
            appDBContext.Update(studentTicket);

            Save();
        }
    }
}
