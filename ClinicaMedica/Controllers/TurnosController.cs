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

namespace ClinicaMedica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TurnosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Turnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turnos>>> GetTurnos()
        {
          if (_context.Turnos == null)
          {
              return NotFound();
          }
            return await _context.Turnos.ToListAsync();
        }

        // GET: api/Turnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turnos>> GetTurnos(int id)
        {
          if (_context.Turnos == null)
          {
              return NotFound();
          }
            var turnos = await _context.Turnos.FindAsync(id);

            if (turnos == null)
            {
                return NotFound();
            }

            return turnos;
        }

        // PUT: api/Turnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurnos(int id, Turnos turnos)
        {
            if (id != turnos.TurnoId)
            {
                return BadRequest();
            }

            _context.Entry(turnos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnosExists(id))
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

        // POST: api/Turnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Turnos>> PostTurnos(TurnosCreacionDTO turnosCreacionDTO)
        {
          if (_context.Turnos == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Turnos'  is null.");
          }
          var turnos = _mapper.Map<Turnos>(turnosCreacionDTO);
            _context.Turnos.Add(turnos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurnos", new { id = turnos.TurnoId }, turnos);
        }

        [HttpPost("TurnosMasivos")]
        public async Task<ActionResult<Turnos>> PostTurnosMasivos([FromBody]List<TurnosCreacionDTO> turnosCreacionDTO)
        {
          if (_context.Turnos == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Turnos'  is null.");
          }
           
            // Mapear cada TurnoCreacionDTO a Turnos
            var turnos = turnosCreacionDTO.Select(dto => _mapper.Map<Turnos>(dto)).ToList();

            // Agregar todos los turnos al contexto
            foreach (var turno in turnos)
            {
                _context.Turnos.Add(turno);
            }

            try
            {
                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();

                // Devolver una respuesta con los IDs de los turnos creados
                var turnosIds = turnos.Select(t => t.TurnoId).ToList();
                return CreatedAtAction("GetTurnos", new { ids = turnosIds }, turnos);
            }
            catch (Exception ex)
            {

                return Problem(ex.ToString());
            }

            


        }


        // DELETE: api/Turnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurnos(int id)
        {
            if (_context.Turnos == null)
            {
                return NotFound();
            }
            var turnos = await _context.Turnos.FindAsync(id);
            if (turnos == null)
            {
                return NotFound();
            }

            _context.Turnos.Remove(turnos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TurnosExists(int id)
        {
            return (_context.Turnos?.Any(e => e.TurnoId == id)).GetValueOrDefault();
        }
    }
}
