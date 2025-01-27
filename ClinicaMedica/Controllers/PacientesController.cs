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
    public class PacientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PacientesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacientesDTO>>> GetPacientes()
        {
          if (_context.Pacientes == null)
          {
              return NotFound();
          }
            var pacientes = await _context.Pacientes.Include(p => p.Persona).ToListAsync();
            return _mapper.Map<List<PacientesDTO>>(pacientes);
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacientesDTO>> GetPacientes(int id)
        {
          if (_context.Pacientes == null)
          {
              return NotFound();
          }
            var paciente = await _context.Pacientes.Include(p => p.Persona)
                .FirstOrDefaultAsync(p => p.PacienteId == id);

            if (paciente == null)
            {
                return NotFound();
            }
            var pacienteDTO = _mapper.Map<PacientesDTO>(paciente);

            return pacienteDTO;
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacientes(int id, PacientesDTO pacientesDTO)
        {
            if (id != pacientesDTO.PacienteId)
            {
                return BadRequest();
            }

            var paciente = _mapper.Map<Pacientes>(pacientesDTO);

            _context.Entry(paciente).State = EntityState.Modified;
            _context.Entry(paciente.Persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientesExists(id))
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

        // POST: api/Pacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pacientes>> PostPacientes(PacientesCreacionDTO pacientesCreacionDTO)
        {
          if (_context.Pacientes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Pacientes'  is null.");
          }
            var pacientes = _mapper.Map<Pacientes>(pacientesCreacionDTO);
            _context.Personas.Add(pacientes.Persona);
            _context.Pacientes.Add(pacientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacientes", new { id = pacientes.PacienteId }, pacientes);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacientes(int id)
        {
            if (_context.Pacientes == null)
            {
                return NotFound();
            }
            var pacientes = await _context.Pacientes.FindAsync(id);
            if (pacientes == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(pacientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacientesExists(int id)
        {
            return (_context.Pacientes?.Any(e => e.PacienteId == id)).GetValueOrDefault();
        }
    }
}
