using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualVisaCenter.API.Data;
using VirtualVisaCenter.Shared.Entities;

namespace VirualVisaCenter.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/embassies")]
    public class EmbassiesController : ControllerBase
    {

        private readonly DataContext _context;

        public EmbassiesController(DataContext context)
        {
            _context = context;
        }

        // Método Get- LISTA
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Embassies.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var embassy = await _context.Embassies.FirstOrDefaultAsync(x => x.Id == id);

            if (embassy == null)
            {
                return NotFound();
            }
            return Ok(embassy);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Embassy embassy)
        {
            _context.Add(embassy);
            await _context.SaveChangesAsync();
            return Ok(embassy);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Embassy embassy)
        {
            _context.Update(embassy);
            await _context.SaveChangesAsync();
            return Ok(embassy);
        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.Embassies

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