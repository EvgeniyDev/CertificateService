﻿using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CertificateService.Web.API.Data.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly AppDBContext appDBContext;

        public FacultyRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void Add(Faculty newFaculty)
        {
            newFaculty.Id = default;

            appDBContext.Faculties.Add(newFaculty);
            Save();
        }

        public void Delete(int id)
        {
            var facultyToDelete = GetFacultyById(id);

            if (facultyToDelete != null)
            {
                appDBContext.Faculties.Remove(facultyToDelete);
                Save();
            }
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            return appDBContext.Faculties.AsEnumerable();
        }

        public Faculty GetFacultyById(int id)
        {
            return appDBContext.Faculties.FirstOrDefault(x => x.Id == id);
        }

        public Faculty GetFacultyByName(string name)
        {
            return appDBContext.Faculties.FirstOrDefault(x => x.Name == name);
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }

        public void Update(Faculty faculty)
        {
            var facultyToUpdate = GetFacultyById(faculty.Id);

            if (facultyToUpdate is null)
            {
                Add(faculty);
            }
            else
            {
                facultyToUpdate.Name = faculty.Name;
                facultyToUpdate.Number = faculty.Number;

                appDBContext.Update(facultyToUpdate);
            }

            Save();
        }
    }
}