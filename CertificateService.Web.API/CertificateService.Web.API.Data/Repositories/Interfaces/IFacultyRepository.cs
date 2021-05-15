using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IFacultyRepository
    {
        public IEnumerable<Faculty> GetFaculties();
        public Faculty GetFacultyByPredicate(Expression<Func<Faculty, bool>> predicate);
        public void Add(Faculty newFaculty);
        public void Update(Faculty faculty);
        public void Delete(int id);
        public void Save();
    }
}
