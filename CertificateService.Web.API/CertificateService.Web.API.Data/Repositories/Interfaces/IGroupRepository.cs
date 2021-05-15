using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        public IEnumerable<Group> GetGroups();
        public Group GetGroupByPredicate(Expression<Func<Group, bool>> predicate);
        public void Add(Group newGroup);
        public void Update(Group group);
        public void Delete(int id);
        public void Save();
    }
}
