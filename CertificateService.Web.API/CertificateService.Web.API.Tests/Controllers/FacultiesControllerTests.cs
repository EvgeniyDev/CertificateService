using CertificateService.Web.API.Controllers;
using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Tests.Controllers
{
    public class FacultiesControllerTests
    {
        private const int ValidFacultyNumber = 1;

        private Mock<IFacultiesService> facultiesServiceMock;
        private FacultiesController facultiesController;

        [SetUp]
        public void Setup()
        {
            facultiesServiceMock = new Mock<IFacultiesService>();
            facultiesController = new FacultiesController(facultiesServiceMock.Object);
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GetFacultyById_WhenCalledAndVaildIdIsPassed_ReturnsOkObjectResult(int facultyId)
        {
            var result = await facultiesController.GetFacultyById(facultyId);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);

            facultiesServiceMock.Verify(m => m.GetFacultyAsync(facultyId), Times.Once);
        }

        [TestCase(ValidFacultyNumber)]
        public async Task GetFacultyByNumber_WhenCalledAndVaildIdIsPassed_ReturnsOkObjectResult(int facultyNumber)
        {
            var result = await facultiesController.GetFacultyByNumber(facultyNumber);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);

            facultiesServiceMock.Verify(m => m.GetFacultyByNumberAsync(facultyNumber), Times.Once);
        }

        [TestCase]
        public async Task GetFaculties_WhenCalled_ReturnsOkObjectResult()
        {
            var result = await facultiesController.GetFaculties();

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);

            facultiesServiceMock.Verify(m => m.GetFacultiesAsync(), Times.Once);
        }

        [TestCase]
        public async Task Add_WhenCalledAndValidModelIsPassed_Returns201StatusCode()
        {
            var facultyToAdd = new AddFacultyViewModel()
            {
                Name = nameof(AddFacultyViewModel.Name),
                Number = ValidFacultyNumber
            };

            var result = await facultiesController.Add(facultyToAdd);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is StatusCodeResult);
            Assert.IsTrue((result as StatusCodeResult).StatusCode == StatusCodes.Status201Created);

            facultiesServiceMock.Verify(m => m.AddAsync(facultyToAdd), Times.Once);
        }

        [TestCase(1)]
        public async Task AddGroupsToFaculty_WhenCalledAndValidDataIsPassed_Returns201StatusCode(int facultyId)
        {
            int[] groupIds = { 1, 2 };

            var result = await facultiesController.AddGroupsToFaculty(facultyId, groupIds);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is StatusCodeResult);
            Assert.IsTrue((result as StatusCodeResult).StatusCode == StatusCodes.Status201Created);

            facultiesServiceMock.Verify(m => m.AddGroupsToFacultyAsync(facultyId, groupIds), Times.Once);
        }

        [TestCase(1)]
        public async Task RemoveGroupsToFaculty_WhenCalledAndValidDataIsPassed_ReturnsNoContent(int facultyId)
        {
            int[] groupIds = { 1, 2 };

            var result = await facultiesController.RemoveGroupsFromFaculty(facultyId, groupIds);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NoContentResult);

            facultiesServiceMock.Verify(m => m.RemoveGroupsFromFacultyAsync(facultyId, groupIds), Times.Once);
        }

        [TestCase]
        public async Task Update_WhenCalledAndValidDataIsPassed_ReturnsOkObjectResult()
        {
            var facultyToUpdate = new UpdateFacultyViewModel()
            {
                Id = 1,
                Name = nameof(AddFacultyViewModel.Name),
                Number = ValidFacultyNumber
            };

            var result = await facultiesController.Update(facultyToUpdate);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);

            facultiesServiceMock.Verify(m => m.UpdateAsync(facultyToUpdate), Times.Once);
        }

        [TestCase(1)]
        public async Task Delete_WhenCalledAndValidIdIsPassed_ReturnsNoContent(int facultyId)
        {
            var result = await facultiesController.Delete(facultyId);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NoContentResult);

            facultiesServiceMock.Verify(m => m.DeleteAsync(facultyId), Times.Once);
        }
    }
}
