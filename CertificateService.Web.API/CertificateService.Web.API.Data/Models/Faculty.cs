using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
