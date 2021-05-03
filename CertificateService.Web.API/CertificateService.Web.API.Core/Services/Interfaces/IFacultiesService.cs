using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IFacultiesService
    {
        void Add(Faculty newFaculty);
        void Delete(int id);
        void Update(Faculty faculty);
        IEnumerable<Faculty> GetFaculties();
        Faculty GetFaculty(int id);
    }
}
