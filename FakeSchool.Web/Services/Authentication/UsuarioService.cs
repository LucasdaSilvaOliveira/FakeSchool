using AutoMapper;
using FakeSchool.Domain.Usuario;
using FakeSchool.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSchool.Infra.Services.Authentication
{
    public class UsuarioService
    {
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private IMapper _mapper;
        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task<bool> CriarConta(UsuarioViewModel user)
        {

            var userMap = _mapper.Map<Usuario>(user);
            
            var createAccount = await _userManager.CreateAsync(userMap, user.Senha);

            if (createAccount.Succeeded)
            {
                return true;
            }

            return false;

        }
    }
}
