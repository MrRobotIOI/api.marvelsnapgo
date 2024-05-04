using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarHammer40KAPI.Entities;

public class MSCard
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    public required String name { get; set; }
    public string description { get; set; } = string.Empty;
    public string cardinfolink { get; set; }= string.Empty;
    public double latitude { get; set; }
    public double longitude { get; set; }
    public string[] image { get; set; } = new string[0];
}