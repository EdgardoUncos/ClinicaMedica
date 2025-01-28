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
    public class CitasMedicasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CitasMedicasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CitasMedicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitasMedicasDTO>>> GetCitasMedicas()
        {
          if (_context.CitasMedicas == null)
          {
              return NotFound();
          }
            var citasMedicas = await _context.CitasMedicas.Include(c => c.Medicos)
                  .Include(c => c.Paciente).Include(c => c.DetalleCitas).ToListAsync();
            
            var citasMedicasDTO = _mapper.Map<List<CitasMedicasDTO>>(citasMedicas);
            
            return citasMedicasDTO;
        }

        // GET: api/CitasMedicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitasMedicas>> GetCitasMedicas(int id)
        {
          if (_context.CitasMedicas == null)
          {
              return NotFound();
          }
            var citasMedicas = await _context.CitasMedicas.FindAsync(id);

            if (citasMedicas == null)
            {
                return NotFound();
            }

            return citasMedicas;
        }

        // PUT: api/CitasMedicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitasMedicas(int id, CitasMedicas citasMedicas)
        {
            if (id != citasMedicas.CitaMedicaId)
            {
                return BadRequest();
            }

            _context.Entry(citasMedicas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasMedicasExists(id))
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

        // POST: api/CitasMedicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CitasMedicas>> PostCitasMedicas(CitasMedicasCreacionDTO citasMedicasCreacionDTO)
        {
          if (_context.CitasMedicas == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CitasMedicas'  is null.");
          }

            var citasMedicas = _mapper.Map<CitasMedicas>(citasMedicasCreacionDTO);
            _context.CitasMedicas.Add(citasMedicas);
            _context.DetalleCitas.AddRange(citasMedicas.DetalleCitas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitasMedicas", new { id = citasMedicas.CitaMedicaId }, citasMedicas);
        }

        // DELETE: api/CitasMedicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitasMedicas(int id)
        {
            if (_context.CitasMedicas == null)
            {
                return NotFound();
            }
            var citasMedicas = await _context.CitasMedicas.FindAsync(id);
            if (citasMedicas == null)
            {
                return NotFound();
            }

            _context.CitasMedicas.Remove(citasMedicas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitasMedicasExists(int id)
        {
            return (_context.CitasMedicas?.Any(e => e.CitaMedicaId == id)).GetValueOrDefault();
        }
    }
}
