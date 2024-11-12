using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationManagementAPI.Models;

[ApiController]
[Route("[controller]")]
public class DepartmentRestrictionsController : ControllerBase
{
    private readonly VacationPlanningContext _context;

    public DepartmentRestrictionsController(VacationPlanningContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentRestriction>>> GetDepartmentRestrictions()
    {
        return await _context.DepartmentRestrictions.Include(dr => dr.Department).Include(dr => dr.Restriction).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentRestriction>> GetDepartmentRestriction(int id)
    {
        var departmentRestriction = await _context.DepartmentRestrictions.Include(dr => dr.Department).Include(dr => dr.Restriction).FirstOrDefaultAsync(dr => dr.Id == id);
        if (departmentRestriction == null)
        {
            return NotFound();
        }
        return departmentRestriction;
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentRestriction>> PostDepartmentRestriction(DepartmentRestriction departmentRestriction)
    {
        _context.DepartmentRestrictions.Add(departmentRestriction);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDepartmentRestriction), new { id = departmentRestriction.Id }, departmentRestriction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDepartmentRestriction(int id, DepartmentRestriction departmentRestriction)
    {
        if (id != departmentRestriction.Id)
        {
            return BadRequest();
        }

        _context.Entry(departmentRestriction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartmentRestriction(int id)
    {
        var departmentRestriction = await _context.DepartmentRestrictions.FindAsync(id);
        if (departmentRestriction == null)
        {
            return NotFound();
        }

        _context.DepartmentRestrictions.Remove(departmentRestriction);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
