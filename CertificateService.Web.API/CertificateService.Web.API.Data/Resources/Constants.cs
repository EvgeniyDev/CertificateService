using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Data.Resources
{
    public class Constants
    {
        public class Role
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }

        public class OutputData
        {
            public const string ContentType = "application/octet-stream";
            public const string FileNameDocx = "Certificate.docx";
            public const string FileNamePdf = "Certificate.pdf";
        }

        public class TemplateFile
        {
            public const string Name = nameof(StudentData.Name);
            public const string Surname = nameof(StudentData.Surname);
            public const string Patronymic = nameof(StudentData.Patronymic);
            public const string Course = "k";
            public const string Faculty = "f";
            public const string MonthOfGraduation = "meoe";
            public const string YearOfGraduation = "yeoe";
            public const string DayOfCertificateIssue = "doi";
            public const string MonthOfCertificateIssue = "moi";
            public const string YearOfCertificateIssue = "yoi";

            public static readonly string[] ForMaleToUnderline = { "він", "студентом" };
            public static readonly string[] ForFemaleToUnderline = { "(вона)", "(кою)" };
        }

        public static readonly string[] LocativeUAMonthNames =
            { "січні", "лютому", "березні", "квітні", "травні", "червні", "липні", "серпні", "вересні", "жовтні", "листопаді", "грудні" };
    }
}
