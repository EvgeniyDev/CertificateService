using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Resources;
using Microsoft.Extensions.Options;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services
{
    public class CertificatesService : ICertificatesService
    {
        private readonly string certificateFilePath;

        private readonly IStudentsService studentsService;
        private readonly IGroupsService groupsService;

        public CertificatesService(
            IStudentsService studentsService,
            IGroupsService groupsService,
            IOptions<CertificateViewModel> options)
        {
            this.studentsService = studentsService;
            this.groupsService = groupsService;

            certificateFilePath = options.Value.FilePath;
        }

        public async Task<Stream> GetCertificateAsync(int studentId, bool isPdf)
        {
            var student = await studentsService.GetStudentAsync(studentId);
            var group = await groupsService.GetStudentGroupName(student.Id);

            var fileStream = new FileStream(certificateFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var document = new WordDocument(fileStream, FormatType.Docx);
            var stream = new MemoryStream();

            document = EditWordDocument(document, student, group.Name);

            if (isPdf)
            {
                var render = new DocIORenderer();
                var pdfDocument = render.ConvertToPDF(document);
                render.Dispose();
                document.Dispose();

                pdfDocument.Save(stream);
                pdfDocument.Close();
            }
            else
            {
                document.Save(stream, FormatType.Docx);
                document.Close();
            }
            stream.Position = 0;

            return stream;
        }

        private WordDocument EditWordDocument(WordDocument document, StudentViewModel student, string groupName)
        {
            document.Replace(Constants.TemplateFile.Name, student.Name, false, true);
            document.Replace(Constants.TemplateFile.Surname, student.Surname, false, true);
            document.Replace(Constants.TemplateFile.Patronymic, student.Patronymic, false, true);

            var facultyNumber = groupName[0].ToString();
            var courseNumber = groupName[1].ToString();

            document.Replace(Constants.TemplateFile.Faculty, facultyNumber, false, true);
            document.Replace(Constants.TemplateFile.Course, courseNumber, false, true);

            var info = CultureInfo.GetCultureInfo("uk-UA").DateTimeFormat;
            var day = DateTime.UtcNow.ToLocalTime().Day.ToString();
            var month = info.MonthGenitiveNames[DateTime.UtcNow.ToLocalTime().Month - 1];
            var year = DateTime.UtcNow.ToLocalTime().Year.ToString();

            document.Replace(Constants.TemplateFile.DayOfCertificateIssue, day, false, true);
            document.Replace(Constants.TemplateFile.MonthOfCertificateIssue, month, false, true);
            document.Replace(Constants.TemplateFile.YearOfCertificateIssue, year, false, true);

            var graduationMonth = Constants.LocativeUAMonthNames[student.StudentTicketDateOfExpiry.Month - 1];
            var graduationYear = student.StudentTicketDateOfExpiry.Year.ToString();

            document.Replace(Constants.TemplateFile.MonthOfGraduation, graduationMonth, false, true);
            document.Replace(Constants.TemplateFile.YearOfGraduation, graduationYear, false, true);

            return document;
        }
    }
}
