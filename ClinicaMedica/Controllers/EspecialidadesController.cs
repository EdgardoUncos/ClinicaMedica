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
    public class EspecialidadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EspecialidadesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Especialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidades>>> GetEspecialidades()
        {
          if (_context.Especialidades == null)
          {
              return NotFound();
          }
            return await _context.Especialidades.ToListAsync();
        }

        // GET: api/Especialidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidades>> GetEspecialidades(int id)
        {
          if (_context.Especialidades == null)
          {
              return NotFound();
          }
            var especialidades = await _context.Especialidades.FindAsync(id);

            if (especialidades == null)
            {
                return NotFound();
            }

            return especialidades;
        }

        // PUT: api/Especialidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidades(int id, EspecialidadesDTO especialidadesDTO)
        {
            var especialidades = _mapper.Map<Especialidades>(especialidadesDTO);

            if (id != especialidades.EspecialidadId)
            {
                return BadRequest();
            }

            _context.Entry(especialidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadesExists(id))
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

        // POST: api/Especialidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Especialidades>> PostEspecialidades(EspecialidadesCreacionDTO especialidadesDTO)
        {
          if (_context.Especialidades == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Especialidades'  is null.");
          }
            var especialidades = _mapper.Map<Especialidades>(especialidadesDTO);
            _context.Especialidades.Add(especialidades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecialidades", new { id = especialidades.EspecialidadId }, especialidades);
        }

        // DELETE: api/Especialidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidades(int id)
        {
            if (_context.Especialidades == null)
            {
                return NotFound();
            }
            var especialidades = await _context.Especialidades.FindAsync(id);
            if (especialidades == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(especialidades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialidadesExists(int id)
        {
            return (_context.Especialidades?.Any(e => e.EspecialidadId == id)).GetValueOrDefault();
        }
    }
}
