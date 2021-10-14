using CertificateService.Web.API.Data.Models;
using System;

namespace CertificateService.Web.API.Core.ViewModels
{
    /// <summary>
    /// A view model for <see cref="Student"/>.
    /// </summary>
    public class StudentViewModel
    {
        /// <summary>
        /// Gets or sets student's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets student's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets student's surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets student's patronymic.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Gets or sets student's gender.
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Gets or sets student's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets student's ticket number.
        /// </summary>
        public string StudentTicketNumber { get; set; }

        /// <summary>
        /// Gets or sets student's ticket date of issue.
        /// </summary>
        public DateTime StudentTicketDateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets student's ticket date of expiration.
        /// </summary>
        public DateTime StudentTicketDateOfExpiry { get; set; }
    }
}
