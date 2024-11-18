using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace FieldAppHydro.Data;


public class ElevationData
{
    [Key]
    public string SiteID { get; set; } 
    public string? StationID { get; set; } = string.Empty;
    public string? ElevRefID { get; set; } = string.Empty;
    public DateTime DateSurveyed { get; set; }
    public double Elevation {get; set;}
    public DateTime ElevStartAppDate { get; set; }
    public DateTime ElevendAppDate { get; set; }
    public string? Comments { get; set; } = string.Empty;
    public Byte[] SSMA_TimeStamp { get; set; }
}

 