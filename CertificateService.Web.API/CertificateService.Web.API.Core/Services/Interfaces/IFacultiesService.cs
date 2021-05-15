using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    public interface IFacultiesService
    {
        void Add(AddFacultyViewModel newFaculty);
        void Delete(int id);
        void Update(UpdateFacultyViewModel faculty);
        IEnumerable<Faculty> GetFaculties();
        Faculty GetFaculty(int id);
        Faculty GetFacultyByNumber(int number);
        void AddGroupsToFaculty(int facultyId, int[] groupIds);
        void RemoveGroupsFromFaculty(int facultyId, int[] groupIds);
    }
}
