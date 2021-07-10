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
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentDataRepository, StudentDataRepository>();
            services.AddScoped<IStudentTicketRepository, StudentTicketRepository>();

            services.AddScoped<IGroupsService, GroupsService>();
            services.AddScoped<IFacultiesService, FacultiesService>();
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<ICertificatesService, CertificatesService>();
        }
    }
}
