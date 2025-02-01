using ClinicaMedica.Data;
using ClinicaMedica.Entities;
using ClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ClinicaMedica.Utilities
{
    public static class FuncionesToken
    {
        // Verifica si hay un usuario en la bd que coincida con las password y si la encuentra
        // retorna el usuario sino retorna null
        public static async Task<Usuarios> ValidarUsuario(LoginUsuario logUser, ApplicationDbContext _context)
        {
            var cuenta = await _context.Usuarios.Where(x => x.NombreUsuario == logUser.NombreUsuario).FirstOrDefaultAsync();

            if (cuenta == null)
                return cuenta;
            

            if (!VerifyPasswordHash(logUser.Password, cuenta.PasswordHash, cuenta.PasswordSalt))
            {
                cuenta = null;
                return cuenta;
            }

            return cuenta;
        }

        // Generar el token con datos de la cuenta y datos del appsetting.json, el key, etc
        public static string GenerarToken(Usuarios usuario, IConfiguration confi)
        {
            // Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(confi["JWT:Key"]));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);

            // Claims
            var _claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId,usuario.UsuarioId.ToString()),
                new Claim("usuario",usuario.NombreUsuario),
                
            };

            // Payload
            var _payload = new JwtPayload(
                issuer: confi["Jwt:Issuer"],
                audience: confi["Jwt:Audience"],
                claims: _claims, notBefore: DateTime.Today,
                expires: DateTime.Now.AddMinutes(60)
                );

            // Generar el token
            var _token = new JwtSecurityToken(_header, _payload);

            return new JwtSecurityTokenHandler().WriteToken(_token);
        }

        // Verifica la password
        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        // crea los hash y estan disponibles como out
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
