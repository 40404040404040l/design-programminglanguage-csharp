namespace Lab3Design.Models.Songs;

public class SongDto(string name, string author)
{
    public string Name { get; private set; } = name;
    public string Author { get; private set; } = author;
}