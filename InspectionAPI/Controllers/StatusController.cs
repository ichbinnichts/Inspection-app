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


    }
}
