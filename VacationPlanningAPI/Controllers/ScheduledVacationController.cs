using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationManagementAPI.Models;




[ApiController]
[Route("[controller]")]
public class ScheduledVacationsController : ControllerBase
{
    private readonly VacationPlanningContext _context;

    public ScheduledVacationsController(VacationPlanningContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScheduledVacation>>> GetScheduledVacations()
    {
        return await _context.ScheduledVacations.Include(sv => sv.Employee).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ScheduledVacation>> GetScheduledVacation(int id)
    {
        var scheduledVacation = await _context.ScheduledVacations.Include(sv => sv.Employee).FirstOrDefaultAsync(sv => sv.Id == id);
        if (scheduledVacation == null)
        {
            return NotFound();
        }
        return scheduledVacation;
    }

    [HttpPost]
    public async Task<ActionResult<ScheduledVacation>> PostScheduledVacation(ScheduledVacation scheduledVacation)
    {
        _context.ScheduledVacations.Add(scheduledVacation);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetScheduledVacation), new { id = scheduledVacation.Id }, scheduledVacation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutScheduledVacation(int id, ScheduledVacation scheduledVacation)
    {
        if (id != scheduledVacation.Id)
        {
            return BadRequest();
        }

        _context.Entry(scheduledVacation).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScheduledVacation(int id)
    {
        var scheduledVacation = await _context.ScheduledVacations.FindAsync(id);
        if (scheduledVacation == null)
        {
            return NotFound();
        }

        _context.ScheduledVacations.Remove(scheduledVacation);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
