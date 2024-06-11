using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOL.Models;

[Table("characters")]
public class Character
{
    [Key] public int Id { get; set; }

    [MaxLength(50)] public String FirstName { get; set; } = String.Empty;
    [MaxLength(120)] public String LastName { get; set; } = String.Empty;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }

    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
    public ICollection<CharacterTitles> CharacterTitles { get; set; } = new HashSet<CharacterTitles>();
}