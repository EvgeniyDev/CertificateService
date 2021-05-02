using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IStudentDataRepository
    {
        public IEnumerable<StudentData> GetStudentDatas();
        public StudentData GetStudentDataById(int id);
        public StudentData GetStudentDataByFullName(string name, string surname, string patronymic);
        public void Add(StudentData newStudentData);
        public void Update(StudentData studentData);
        public void Delete(int id);
        public void Save();
    }
}
