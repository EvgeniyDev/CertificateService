using AutoMapper;
using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Core.ViewModels.Authorization;
using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Core.Mapper
{
    /// <inheritdoc/>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Faculty, AddFacultyViewModel>().ReverseMap();
            CreateMap<Faculty, UpdateFacultyViewModel>().ReverseMap();

            CreateMap<Group, AddGroupViewModel>().ReverseMap();
            CreateMap<Group, UpdateGroupViewModel>().ReverseMap();

            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
