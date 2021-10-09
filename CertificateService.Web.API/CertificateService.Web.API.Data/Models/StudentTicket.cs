using System;
using System.ComponentModel.DataAnnotations;

namespace CertificateService.Web.API.Data.Models
{
    /// <summary>
    /// A model representing the student's ticket.
    /// </summary>
    public class StudentTicket
    {
        /// <summary>
        /// Gets or sets student's ticket id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets student's ticket number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets student's ticket date of issue.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets student's ticket date of expiry.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateOfExpiry { get; set; }
    }
}
