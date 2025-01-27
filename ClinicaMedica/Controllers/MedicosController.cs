using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaMedica.Data;
using ClinicaMedica.Entities;
using AutoMapper;
using ClinicaMedica.DTOs.Create;
using ClinicaMedica.DTOs.Basic;

namespace ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MedicosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Medicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicosDTO>>> GetMedicos()
        {
          if (_context.Medicos == null)
          {
              return NotFound();
          }
            var medico = await _context.Medicos.Include(m => m.Especialidades).Include(m => m.Persona).ToListAsync();

            var lista = _mapper.Map<List<MedicosDTO>>(medico);
            return lista;
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicosDTO>> GetMedicos(int id)
        {
          if (_context.Medicos == null)
          {
              return NotFound();
          }
            var medicos = await _context.Medicos.Include(m => m.Persona)
                .Include(m => m.Especialidades).FirstOrDefaultAsync(m => m.EspecialidadId == id);

            if (medicos == null)
            {
                return NotFound();
            }

            return _mapper.Map<MedicosDTO>(medicos);
        }

        // PUT: api/Medicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicos(int id, MedicosDTO medicosDTO)
        {
            if (id != medicosDTO.MedicoId)
            {
                return BadRequest();
            }
            var medicos = _mapper.Map<Medicos>(medicosDTO);

            _context.Entry(medicos).State = EntityState.Modified;
            _context.Entry(medicos.Persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicosExists(id))
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

        // POST: api/Medicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicosDTO>> PostMedicos(MedicosCreacionDTO medicosCreacionDTO)
        {
          if (_context.Medicos == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Medicos'  is null.");
          }
          var medicos = _mapper.Map<Medicos>(medicosCreacionDTO);
          _context.Personas.Add(medicos.Persona);
          _context.Medicos.Add(medicos);
          await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicos", new { id = medicos.MedicoId }, medicos);
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicos(int id)
        {
            if (_context.Medicos == null)
            {
                return NotFound();
            }
            var medicos = await _context.Medicos.FindAsync(id);
            if (medicos == null)
            {
                return NotFound();
            }

            _context.Medicos.Remove(medicos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicosExists(int id)
        {
            return (_context.Medicos?.Any(e => e.MedicoId == id)).GetValueOrDefault();
        }
    }
}
