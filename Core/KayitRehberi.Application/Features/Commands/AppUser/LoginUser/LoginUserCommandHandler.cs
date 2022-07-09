using KayitRehberi.Application.Abstractions.Token;
using KayitRehberi.Application.DTOs;
using KayitRehberi.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U = KayitRehberi.Domain.Entities.Identity;

namespace KayitRehberi.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly ITokenHandler _tokenHandler;
        readonly UserManager<U.AppUser> _userManager;
        readonly SignInManager<U.AppUser> _signInManager;

        public LoginUserCommandHandler(ITokenHandler tokenHandler, UserManager<U.AppUser> userManager, SignInManager<U.AppUser> signInManager)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            //kullanıcıdan e-mail ya da kullanıcı adı alarak kontrol yapıyoruz.
            U.AppUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user == null)
                throw new NotFoundException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded) //Authentication başarılı
            {
                Token token = _tokenHandler.CreateAccessToken(5);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token,
                };

            }
            //return new LoginUserErrorCommandResponse()
            //{
            //    Message = "Kullanıcı adı ve ya şifre hatalı"
            //};
            throw new AuthenticationErrorException();
        }
    }
}
