using FarenayteApi.Application.DTO.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarenayteApi.Presentation.Service
{
    public class Token
    {
        public static async Task<string> GenerateToken(UsuarioResponseDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("erthpguetibuyh5ut9reeytr9");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = System.DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    //new Claim(ClaimTypes.Role, "admin"),
                }),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}