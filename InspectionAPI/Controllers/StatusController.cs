using InspectionAPI.Data;
using InspectionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        //Constructor
        private readonly DataContext _context;
        public StatusController(DataContext context)
        {
            _context = context;
        }

        //GET All
        [HttpGet]
        public async Task<ActionResult<List<Status>>> Get()
        {
            return await _context.Statuses.ToListAsync();
        }
        //GET a single one
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> Get(int id)
        {
            var status = _context.Statuses.FindAsync(id);
            if (status == null) { return NotFound(); }

            return Ok(status);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            return Ok(status);
        }
        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(Status request)
        {
            var status = _context.Statuses.FindAsync(request.Id);
            if(status == null) { return NotFound(); }
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if(status == null) { return NotFound(); }
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
