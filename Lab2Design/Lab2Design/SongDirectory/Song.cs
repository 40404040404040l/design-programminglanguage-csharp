using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2Design.SongDirectory;

public class Song : ISong
{
    [Key]
    [Column("id")]
    public Guid Id { get; init; }
    [Column("name")]
    public string Name { get; }
    [Column("author")]
    public string Author { get; }

    public Song(string name, string author)
    {
        Id = Guid.NewGuid();
        Name = name;
        Author = author;
    }
    
    public string GetStringRepresentation()
    {
        return $"{Name} - {Author}";
    }
}