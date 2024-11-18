using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace StationDataApi.Models;

public class PersonnelLookupData
{
    [Key]

    public int PersonnelID { get; set; }
    public int AffilID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Title { get; set; }
    public string? Position { get; set; }
    public string? WorkGroup { get; set; }
    public string? Department { get; set; }
    public string? Birthdate { get; set; }
    public bool ResearchGroupMember { get; set; }
    public Byte[]? SSMA_TimeStamp { get; set; }
}