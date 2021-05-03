using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CertificateService.Web.API.Data.Repositories
{
    public class StudentDataRepository : IStudentDataRepository
    {
        private readonly AppDBContext appDBContext;

        public StudentDataRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void Add(StudentData newStudentData)
        {
            appDBContext.StudentDatas.Add(newStudentData);
            Save();
        }

        public void Delete(int id)
        {
            var studentDataToDelete = GetStudentDataById(id);

            if (studentDataToDelete != null)
            {
                appDBContext.StudentDatas.Remove(studentDataToDelete);
                Save();
            }
        }

        public StudentData GetStudentDataByFullName(string name, string surname, string patronymic)
        {
            return appDBContext.StudentDatas.FirstOrDefault(x => x.Name == name && x.Surname == surname && x.Patronymic == patronymic);
        }

        public StudentData GetStudentDataById(int id)
        {
            return appDBContext.StudentDatas.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<StudentData> GetStudentDatas()
        {
            return appDBContext.StudentDatas.AsEnumerable();
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }

        public void Update(StudentData studentData)
        {
            appDBContext.Update(studentData);
            Save();
        }
    }
}
