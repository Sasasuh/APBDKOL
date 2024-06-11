using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOL.Models;

[Table("items")]
public class Item
{
    [Key] public int Id { get; set; }
    [MaxLength(100)] public string Name { get; set; } = String.Empty;

    public int Weight { get; set; }
    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
}