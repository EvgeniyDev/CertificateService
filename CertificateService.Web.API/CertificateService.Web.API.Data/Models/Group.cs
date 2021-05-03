using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
