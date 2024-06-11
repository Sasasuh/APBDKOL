using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOL.Models;

[Table("titles")]
public class Title
{
    [Key] public int Id { get; set; }

    [MaxLength(100)] public string Name { get; set; } = String.Empty;
    public ICollection<CharacterTitles> CharacterTitles { get; set; } = new HashSet<CharacterTitles>();

}