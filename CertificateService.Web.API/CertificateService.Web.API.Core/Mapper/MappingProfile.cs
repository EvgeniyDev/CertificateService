using AutoMapper;
using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Core.ViewModels.Authorization;
using CertificateService.Web.API.Data.Models;

namespace CertificateService.Web.API.Core.Mapper
{
    public class MappingProfile : Profile
    {
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
