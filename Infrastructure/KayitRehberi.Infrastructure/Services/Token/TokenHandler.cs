using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using T = KayitRehberi.Application.Abstractions.Token;

namespace KayitRehberi.Infrastructure.Services.Token
{
    public class TokenHandler : T.ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int minute)
        {
            Application.DTOs.Token token = new();

            //SecurityKeyin simetriğini alıyoruz.
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //Oluşturulacak tokan ayarlarını veriyoruz.
            token.Expiration=DateTime.UtcNow.AddMinutes(minute);

            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );
            //Token oluşturucu sınıf
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken= tokenHandler.WriteToken(securityToken);

            //refresh token oluşturma
            token.RefreshToken = CreateRefreshToken();
            return token;
         
        }
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
