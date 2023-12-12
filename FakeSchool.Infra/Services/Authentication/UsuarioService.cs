using FakeSchool.Domain.Usuario;
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
        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> Logar(string userName, string senha)
        {


            var createAccount = await _signInManager.PasswordSignInAsync(userName, senha, false, false);

            if (createAccount.Succeeded)
            {
                return true;
            }

            return false;

        }
    }
}
