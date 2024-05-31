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
    [Route("/api/typeVisas")]
    public class TypeVisasController : ControllerBase
    {

        private readonly DataContext _context;

        public TypeVisasController(DataContext context)
        {
            _context = context;
        }

        // Método Get- LISTA
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.TypeVIsas.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var typeVisa = await _context.TypeVIsas.FirstOrDefaultAsync(x => x.Id == id);

            if (typeVisa == null)
            {
                return NotFound();
            }
            return Ok(typeVisa);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TypeVIsa typeVisa)
        {
            _context.Add(typeVisa);
            await _context.SaveChangesAsync();
            return Ok(typeVisa);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(TypeVIsa typeVisa)
        {
            _context.Update(typeVisa);
            await _context.SaveChangesAsync();
            return Ok(typeVisa);
        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.TypeVIsas

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
