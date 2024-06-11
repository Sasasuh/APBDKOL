using KOL.Models;
using Microsoft.EntityFrameworkCore;

namespace KOL.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    //Dbsets

    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitles> CharacterTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Item1",
                Weight = 1
            },
            new Item
            {
                Id = 2,
                Name = "Itemw",
                Weight = 3
            }
        });

        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title
            {
                Id = 1,
                Name = "Title1"
            },
            new Title
            {
                Id = 2,
                Name = "Title2"
            }
        });
        
        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character
            {
                Id = 1, 
                FirstName = "Anna",
                LastName = "Nowak",
                CurrentWeight = 5,
                MaxWeight = 7
            },
            new Character
            {
                Id = 2, 
                FirstName = "Jan",
                LastName = "Kowalski",
                CurrentWeight = 6,
                MaxWeight = 8
            }
        });

        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 4
            },
            new Backpack
            {
                CharacterId = 2,
                ItemId = 2,
                Amount = 3
            }
        });
        

        modelBuilder.Entity<CharacterTitles>().HasData(new List<CharacterTitles>
        {
            new CharacterTitles
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = DateTime.Parse("2024-05-23")
            },
            new CharacterTitles
            {
                CharacterId = 2,
                TitleId = 2,
                AcquiredAt = DateTime.Parse("2024-03-18")
            }
        });
    }
}