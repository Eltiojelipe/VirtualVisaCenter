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
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {

        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        // Método Get- LISTA
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.Countries

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

