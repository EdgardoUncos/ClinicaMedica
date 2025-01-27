using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaMedica.Data;
using ClinicaMedica.Entities;
using ClinicaMedica.DTOs.Create;
using AutoMapper;
using ClinicaMedica.DTOs.Basic;

namespace ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServiciosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Servicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiciosDTO>>> GetServicios()
        {
          if (_context.Servicios == null)
          {
              return NotFound();
          }
            return _mapper.Map<List<ServiciosDTO>>(await _context.Servicios.ToListAsync());
        }

        // GET: api/Servicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiciosDTO>> GetServicios(int id)
        {
          if (_context.Servicios == null)
          {
              return NotFound();
          }
            var servicios = await _context.Servicios.FindAsync(id);

            if (servicios == null)
            {
                return NotFound();
            }

            return _mapper.Map<ServiciosDTO>(servicios);
        }

        // PUT: api/Servicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicios(int id, Servicios servicios)
        {
            if (id != servicios.ServicioId)
            {
                return BadRequest();
            }

            _context.Entry(servicios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Servicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servicios>> PostServicios(ServiciosCreacionDTO serviciosCreacionDTO)
        {
          if (_context.Servicios == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Servicios'  is null.");
          }
            var servicios = _mapper.Map<Servicios>(serviciosCreacionDTO);
            _context.Servicios.Add(servicios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicios", new { id = servicios.ServicioId }, servicios);
        }

        // DELETE: api/Servicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicios(int id)
        {
            if (_context.Servicios == null)
            {
                return NotFound();
            }
            var servicios = await _context.Servicios.FindAsync(id);
            if (servicios == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiciosExists(int id)
        {
            return (_context.Servicios?.Any(e => e.ServicioId == id)).GetValueOrDefault();
        }
    }
}
