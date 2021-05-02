using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<Student> Students { get; set; }
    }
}
