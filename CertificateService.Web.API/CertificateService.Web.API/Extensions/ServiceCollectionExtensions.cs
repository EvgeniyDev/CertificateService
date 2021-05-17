using CertificateService.Web.API.Core.Services;
using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Data.Repositories;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CertificateService.Web.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ServiceInjection(this IServiceCollection services)
        {
            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentDataRepository, StudentDataRepository>();
            services.AddTransient<IStudentTicketRepository, StudentTicketRepository>();

            services.AddTransient<IGroupsService, GroupsService>();
            services.AddTransient<IFacultiesService, FacultiesService>();
            services.AddTransient<IStudentsService, StudentsService>();
            services.AddTransient<ICertificatesService, CertificatesService>();
        }
    }
}
