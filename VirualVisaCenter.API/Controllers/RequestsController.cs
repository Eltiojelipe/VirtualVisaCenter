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
    [Route("/api/requests")]
    public class RequestsController : ControllerBase
    {

        private readonly DataContext _context;

        public RequestsController(DataContext context)
        {
            _context = context;
        }

        // Método Get- LISTA
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Requests.ToListAsync());
        }

        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == id);

            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Request request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }

        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Request request)
        {
            _context.Update(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.Requests

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


