using ClinicaMedica.Data;
using ClinicaMedica.DTOs.Create;
using ClinicaMedica.Entities;
using ClinicaMedica.Models;
using ClinicaMedica.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _confi;

        public UsuariosController(ApplicationDbContext context, IConfiguration confi)
        {
            _context = context;
            _confi = confi;
        }

        [Authorize]
        [HttpGet("Datos")]
        public async Task<ActionResult<List<Usuarios>>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<string>> CreateUser([FromBody]UsuarioDTO usuario)
        {
            FuncionesToken.CreatePasswordHash(usuario.Password, out byte[] passwordHash, out byte[] passwordSalt);

            Usuarios userCreate = new Usuarios
            {
                NombreUsuario = usuario.NombreUsuario,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Rol = usuario.Rol                
            };

            _context.Usuarios.Add(userCreate);
            await _context.SaveChangesAsync();
            var respuesta = "Registrado con Exito";

            return respuesta;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody]LoginUsuario logUser)
        {
            var verify = await FuncionesToken.ValidarUsuario(logUser, _context);

            if (verify == null)
            {
                return BadRequest("Usuario o contraseña incorrectos");
            }
            
            var token = FuncionesToken.GenerarToken(verify, _confi);

            return Ok(token);
            
        }
    }
}
