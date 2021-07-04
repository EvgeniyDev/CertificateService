using System;
using System.ComponentModel.DataAnnotations;

namespace CertificateService.Web.API.Data.Models
{
    public class StudentData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
