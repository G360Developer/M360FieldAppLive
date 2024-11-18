using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace StationDataApi.Models;


public class StationData
{
    [Key]
    public string SiteID { get; set; } 
    public string StationID { get; set; }
    public string WellType { get; set; } = string.Empty;
    public string Personnel { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Unit {get; set;} = string.Empty;
    public string DepthReference { get; set; } = string.Empty;
    public string MeasurementType { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
}

 