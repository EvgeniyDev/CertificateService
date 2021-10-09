using System;
using System.ComponentModel.DataAnnotations;

namespace CertificateService.Web.API.Data.Models
{
    /// <summary>
    /// A model representing a student data of the student.
    /// </summary>
    public class StudentData
    {
        /// <summary>
        /// Gets or sets student's data id.
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
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
