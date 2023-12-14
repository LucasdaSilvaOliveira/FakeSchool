﻿using AutoMapper;
using FakeSchool.Domain.Escola;
using FakeSchool.Domain.Usuario;
using FakeSchool.Web.Areas.Aluno.Models;
using FakeSchool.Web.Areas.Curso.Models;
using FakeSchool.Web.Models;

namespace FakeSchool.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<Aluno, FormAlunoViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<Curso, FormCursoViewModel>().ReverseMap();
        }
    }
}
