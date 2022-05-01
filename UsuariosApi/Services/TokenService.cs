using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models.Token;

namespace UsuariosApi.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> usuario)
        {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString()),

            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("djfgu48vkbfh34db37cghf93bbd5tcxbd")
                );
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}
