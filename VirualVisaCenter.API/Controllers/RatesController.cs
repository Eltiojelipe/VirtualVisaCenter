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
    [Route("/api/rates")]
    public class RatesController : ControllerBase
    {

        private readonly DataContext _context;

        public RatesController(DataContext context)
        {
            _context = context;
        }

        // Método Get- LISTA
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Rates.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var rate = await _context.Rates.FirstOrDefaultAsync(x => x.Id == id);

            if (rate == null)
            {
                return NotFound();
            }
            return Ok(rate);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Rate rate)
        {
            _context.Add(rate);
            await _context.SaveChangesAsync();
            return Ok(rate);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Rate rate)
        {
            _context.Update(rate);
            await _context.SaveChangesAsync();
            return Ok(rate);
        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.Rates

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

