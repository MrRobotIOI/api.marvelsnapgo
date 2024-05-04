using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarHammer40KAPI.Entities;

public class users
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
  

    public List<int> cardcollection { get; set; } = new List<int>();
}