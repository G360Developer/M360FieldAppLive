/*using System;
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
    public class StationDetailsController : ControllerBase
    {
        private readonly StationDetailsContext _context;

        public StationDetailsController(StationDetailsContext context)
        {
            _context = context;
        }


        // GET: api/StationDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationDetails>>> GetStationDetails()
        {
            return await _context.StationDetails.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationDetails>>> JoinStationDetails()
        {
            return await _context.StationDetails.ToListAsync();
        }

        // GET: api/StationDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationDetails>> GetStationDetailsItem(string id)
        {
            var StationDetailsItem = await _context.StationDetails.FindAsync(id);

            if (StationDetailsItem == null)
            {
                return NotFound();
            }

            return StationDetailsItem;
        }

        // PUT: api/StationDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // POST: api/StationDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StationDetails>> PostStationDetailsItem(StationDetails StationDetailsItem)
        {
            _context.StationDetails.Add(StationDetailsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStationDetailsItem), new { id = StationDetailsItem.SiteID }, StationDetailsItem);
        }

        // DELETE: api/StationDetails/5

        private bool StationDetailsExists(long id)
        {
            return _context.StationDetails.Any(e => e.SiteID == id.ToString());
        }
    }
}*/