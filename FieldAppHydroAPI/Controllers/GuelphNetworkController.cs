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

public class StationDetailsController : ControllerBase
{
    private readonly StationDetailsContext _stationDetailsContext;
    private readonly GuelphNetworkContext _guelphMonitoringContext;

 public StationDetailsController(StationDetailsContext stationDetailsContext, GuelphNetworkContext guelphNetworkContext)
    {
        _stationDetailsContext = stationDetailsContext;
        _guelphMonitoringContext = guelphNetworkContext;
    }

[HttpGet("all")]
public async Task<IActionResult> Get()
{
    // Load data from each context separately
    var stationDetailsList = await _stationDetailsContext.StationDetails.ToListAsync();
    var guelphNetworkList = await _guelphMonitoringContext.GuelphNetwork.ToListAsync();

    // Perform the join in memory
    var joinedData = stationDetailsList.Join(
        guelphNetworkList,
        stationDetails => stationDetails.StationID,
        guelphNetwork => guelphNetwork.StationID,
        (stationDetails, guelphNetwork) => new
        {
            stationDetails.SiteID,
            stationDetails.StationID,
            stationDetails.StationType,
            stationDetails.StartDate,
            stationDetails.EndDate,
            stationDetails.Comments,
        }
    ).ToList();

    return Ok(joinedData);
}


        // GET: api/GuelphNetwork
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationDetails>>> GetStationDetails()
        {
            return await _stationDetailsContext.StationDetails.ToListAsync();
        }

        [HttpGet("elevationData")]
        public async Task<ActionResult<IEnumerable<ElevationData>>> GetElevationData()
        {
            return await _guelphMonitoringContext.GuelphNetworkElevation.ToListAsync();
        }

        // GET: api/GuelphNetwork/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationDetails>> GetGuelphNetworkItem(string id)
        {
            var GuelphNetworkItem = await _stationDetailsContext.StationDetails.FindAsync(id);

            if (GuelphNetworkItem == null)
            {
                return NotFound();
            }

            return GuelphNetworkItem;
        }

        // PUT: api/GuelphNetwork/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // POST: api/GuelphNetwork
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StationDetails>> PostStationDetailsItem(StationDetails StationDetailsItem)
        {
            _stationDetailsContext.StationDetails.Add(StationDetailsItem);
            await _stationDetailsContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuelphNetworkItem), new { id = StationDetailsItem.SiteID }, StationDetailsItem);
        }

        // DELETE: api/GuelphNetwork/5

        private bool GuelphNetworkExists(long id)
        {
            return _stationDetailsContext.StationDetails.Any(e => e.SiteID == id.ToString());
        }
    }
}