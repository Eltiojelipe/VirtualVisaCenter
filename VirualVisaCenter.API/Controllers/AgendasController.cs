using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualVisaCenter.API.Data;
using VirtualVisaCenter.Shared.Entities;

namespace VirualVisaCenter.API.Controllers
{
    [ApiController]
    [Route("/api/agendas")]
    public class AgendasController : ControllerBase
    {

        private readonly DataContext _context;

        public AgendasController(DataContext context)
        {
            _context = context;
        }

        // Método Get- LISTA
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Agendas.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var agenda = await _context.Agendas.FirstOrDefaultAsync(x => x.Id == id);

            if (agenda == null)
            {
                return NotFound();
            }
            return Ok(agenda);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Agenda agenda)
        {
            _context.Add(agenda);
            await _context.SaveChangesAsync();
            return Ok(agenda);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Agenda agenda)
        {
            _context.Update(agenda);
            await _context.SaveChangesAsync();
            return Ok(agenda);
        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.Agendas

                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (Filasafectadas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
