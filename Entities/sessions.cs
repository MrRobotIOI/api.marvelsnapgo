using System.ComponentModel.DataAnnotations;

namespace WarHammer40KAPI.Entities;

public class sessions
{
    [Key]
    public int id { get; set; }
    public  int userId { get; set; }
  
}