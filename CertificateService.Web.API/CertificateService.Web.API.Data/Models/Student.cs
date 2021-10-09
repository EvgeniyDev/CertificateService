namespace CertificateService.Web.API.Data.Models
{
    /// <summary>
    /// A model representing a student of the group.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets student's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Models.StudentData"/>.
        /// </summary>
        public StudentData StudentData { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Models.StudentTicket"/>.
        /// </summary>
        public StudentTicket StudentTicket { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Models.Group"/>.
        /// </summary>
        public Group Group { get; set; }
    }
}
