using System;
using System.ComponentModel.DataAnnotations;

namespace CertificateService.Web.API.Data.Models
{
    public class StudentTicket
    {
        public int Id { get; set; }
        public string Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfExpiry { get; set; }
    }
}
