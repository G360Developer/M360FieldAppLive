using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace StationDataApi.Models;


public class StationDetails
{
    [Key]
    public string SiteID { get; set; } = string.Empty;
    public string StationID { get; set; } = string.Empty;
    public string StationType { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Comments { get; set; } = string.Empty;

}

