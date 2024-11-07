using System.Text;

namespace Lab1Design.SongDirectory;

public class Song : ISong
{
    public string Name { get; }
    public string Author { get; }

    public Song(string name, string author)
    {
        Name = name;
        Author = author;
    }
    
    public string GetStringRepresentation()
    {
        return $"{Name} - {Author}";
    }
}