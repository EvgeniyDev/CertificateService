namespace CertificateService.Web.API.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        public StudentData StudentData { get; set; }
        public StudentTicket StudentTicket { get; set; }
        public Group Group { get; set; }
    }
}
