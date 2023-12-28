using AutoMapper;
using FakeSchool.Domain.Escola;
using FakeSchool.Domain.Usuario;
using FakeSchool.Web.Areas.Aluno.Models;
using FakeSchool.Web.Areas.Curso.Models;
using FakeSchool.Web.Areas.Professor.Models;
using FakeSchool.Web.Models;

namespace FakeSchool.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<AlunoViewModel, Aluno>().ReverseMap()
                .ForMember(dest => dest.Curso, opt => opt.MapFrom(src => src.Curso.Nome));

            CreateMap<GerirAlunoViewModel, Aluno>().ReverseMap()
                .ForMember(dest => dest.Curso, opt => opt.MapFrom(src => src.Curso.Nome))
                .ForMember(dest => dest.DuracaoAnos, opt => opt.MapFrom(src => src.Curso.DuracaoAnos));

            CreateMap<Aluno, FormAlunoViewModel>().ReverseMap().ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Status) ? "Cursando" : src.Status));

            CreateMap<Aluno, FormAlunoViewModel>()
                .ForMember(dest => dest.DuracaoAnos, opt => opt.MapFrom(src => src.Curso.DuracaoAnos));

            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<Curso, FormCursoViewModel>().ReverseMap();
            CreateMap<Professor, ProfessorViewModel>().ReverseMap();
        }
    }
}
