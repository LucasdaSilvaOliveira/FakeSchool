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
        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
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

        public async Task<bool> Logar(string userName, string senha)
        {

            var login = await _signInManager.PasswordSignInAsync(userName, senha, false, false);

            if (login.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}
