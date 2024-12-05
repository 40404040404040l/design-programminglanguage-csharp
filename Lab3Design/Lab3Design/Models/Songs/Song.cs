using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3Design.Models.Songs;

public class Song(string name, string author) : ISong
{
    [Key]
    [Column("id")]
    public Guid Id { get; init; } = Guid.NewGuid();

    [Column("name")]
    public string Name { get; } = name;

    [Column("author")]
    public string Author { get; } = author;

    public string GetStringRepresentation()
    {
        return $"{Name} - {Author}";
    }
}