using AutoMapper;
using FakeSchool.Domain.Usuario;
using FakeSchool.Web.Models;

namespace FakeSchool.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
