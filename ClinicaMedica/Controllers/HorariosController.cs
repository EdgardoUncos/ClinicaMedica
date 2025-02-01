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
using Microsoft.AspNetCore.Authorization;

namespace ClinicaMedica.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HorariosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Horarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorariosDTO>>> GetHorarios()
        {
          if (_context.Horarios == null)
          {
              return NotFound();
          }
          var horariosDTO = _mapper.Map<IEnumerable<HorariosDTO>>(await _context.Horarios.ToListAsync());
            
            return  horariosDTO.ToList();
        }

        // GET: api/Horarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Horarios>> GetHorarios(int id)
        {
          if (_context.Horarios == null)
          {
              return NotFound();
          }
            var horarios = await _context.Horarios.FindAsync(id);

            if (horarios == null)
            {
                return NotFound();
            }

            return horarios;
        }

        // PUT: api/Horarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorarios(int id, Horarios horarios)
        {
            if (id != horarios.HorarioId)
            {
                return BadRequest();
            }

            _context.Entry(horarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorariosExists(id))
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

        // POST: api/Horarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Horarios>> PostHorarios(HorariosCreacionDTO horariosCreacionDTO)
        {
          if (_context.Horarios == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Horarios'  is null.");
          }
          var horarios = _mapper.Map<Horarios>(horariosCreacionDTO);
            _context.Horarios.Add(horarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorarios", new { id = horarios.HorarioId }, horarios);
        }

//        {
//          "horarioInicio": "08:00:00",
//          "horarioFin": "12:00:00"
//         }

    // DELETE: api/Horarios/5
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorarios(int id)
        {
            if (_context.Horarios == null)
            {
                return NotFound();
            }
            var horarios = await _context.Horarios.FindAsync(id);
            if (horarios == null)
            {
                return NotFound();
            }

            _context.Horarios.Remove(horarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorariosExists(int id)
        {
            return (_context.Horarios?.Any(e => e.HorarioId == id)).GetValueOrDefault();
        }
    }
}
