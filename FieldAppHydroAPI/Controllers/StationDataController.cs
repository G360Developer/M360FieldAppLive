using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StationDataApi.Models;

namespace FieldAppHydroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationDataController : ControllerBase
    {
        private readonly StationDataContext _context;

        public StationDataController(StationDataContext context)
        {
            _context = context;
        }


        // GET: api/StationData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationData>>> GetStationData()
        {
            return await _context.StationData.ToListAsync();
        }

        // GET: api/StationData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationData>> GetStationDataItem(long id)
        {
            var stationDataItem = await _context.StationData.FindAsync(id);

            if (stationDataItem == null)
            {
                return NotFound();
            }

            return stationDataItem;
        }

        [HttpGet("personnel-lookup")]
public async Task<ActionResult<IEnumerable<PersonnelLookupData>>> GetPersonnelLookupData()
{
    try
    {
        var personnelData = await _context.PersonnelLookupData.ToListAsync();
        return Ok(personnelData);
    }
    catch (Exception ex)
    {
        return StatusCode(500, "Error retrieving personnel lookup data: " + ex.Message);
    }
}
/* 
        // PUT: api/StationData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationDataItem(long id, StationData stationDataItem)
        {
            if (id != stationDataItem.SiteID)
            {
                return BadRequest();
            }

            _context.Entry(stationDataItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
*/

        // POST: api/StationData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StationData>> PostStationDataItem(StationData stationDataItem)
        {
            _context.StationData.Add(stationDataItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStationDataItem), new { id = stationDataItem.SiteID }, stationDataItem);
        }
/* 
        // DELETE: api/StationData/5
       [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStationDataItem(long id)
        {
            var stationDataItem = await _context.StationData.FindAsync(id);
            if (stationDataItem == null)
            {
                return NotFound();
            }

            _context.StationData.Remove(stationDataItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StationDataExists(long id)
        {
            return _context.StationData.Any(e => e.SiteID == id);
        }
    }

*/
}}