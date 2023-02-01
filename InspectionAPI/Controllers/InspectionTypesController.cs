using InspectionAPI.Data;
using InspectionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionTypesController : ControllerBase
    {
        //Constructor
        private readonly DataContext _context;

        public InspectionTypesController(DataContext context)
        {
            _context = context;
        }
        //GET all
        [HttpGet]
        public async Task<ActionResult<List<InspectionType>>> Get()
        {
            return await _context.InspectionTypes.ToListAsync();
        }
        //GET a single one
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionType>> Get(int id)
        {
            var inspectionType = _context.InspectionTypes.FindAsync(id);
            if (inspectionType == null) { return NotFound(); }
            return Ok(inspectionType);
        }
        //POST
        [HttpPost]
        public async Task<ActionResult<InspectionType>> PostInspectionType(InspectionType inspectionType)
        {
            _context.InspectionTypes.Add(inspectionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspection", new { id = inspectionType.Id }, inspectionType);
        }
        //PUT 
        public async Task<IActionResult> PutInspectionType(InspectionType request)
        {
            var inspectionType = _context.InspectionTypes.FindAsync(request.Id);
            if(inspectionType == null) { return NotFound();  }

            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionType(int id)
        {
            var inspectionType = await _context.InspectionTypes.FindAsync(id);
            if(inspectionType == null) { return NotFound(); }
            _context.InspectionTypes.Remove(inspectionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
