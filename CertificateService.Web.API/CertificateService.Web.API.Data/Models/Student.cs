namespace CertificateService.Web.API.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentDataId { get; set; }
        public int StudentTicketId { get; set; }
        public int GroupId { get; set; }

        public StudentData StudentData { get; set; }
        public StudentTicket StudentTicket { get; set; }
        public Group Group { get; set; }
    }
}
