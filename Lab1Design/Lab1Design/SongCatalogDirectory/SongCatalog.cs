using System.Text.Json;
using Lab1Design.SongDirectory;

namespace Lab1Design.SongCatalogDirectory;

public class SongCatalog : ISongCatalog
{
    private readonly List<Song> _songs;
    private readonly string _filePath;

    public SongCatalog(string filePath)
    {
        _filePath = filePath;
        _songs = LoadFromFile();
    }

    public IList<ISong> FindSong(string criteria)
    {
        var hs = new HashSet<ISong>();
        foreach (var song in _songs.FindAll(song => song.Name.Equals(criteria)))
        {
            hs.Add(song);
        }

        foreach (var song in _songs.FindAll(song => song.Author.Equals(criteria)))
        {
            hs.Add(song);
        }

        return hs.ToList();
    }

    public IEnumerable<ISong> ShowAllSongs()
    {
        return _songs.AsReadOnly();
    }

    public void AddSong(string songName, string author)
    {
        _songs.Add(new Song(songName, author));
    }

    public void DeleteSong(string songName, string author)
    {
        var songsToDelete = _songs.Where(song => song.Name == songName && song.Author == author).ToList();

        foreach (var song in songsToDelete)
        {
            _songs.Remove(song);
        }
    }

    private List<Song> LoadFromFile()
    {
        if (!File.Exists(_filePath)) return new List<Song>();
        try
        {
            var json = File.ReadAllText(_filePath);

            if (!string.IsNullOrWhiteSpace(json))
                return JsonSerializer.Deserialize<List<Song>>(json) ?? new List<Song>();
            return new List<Song>();

        }
        catch (JsonException)
        {
            return new List<Song>();
        }

    }
    
    public void SaveToFile()
    {
        var json = JsonSerializer.Serialize(_songs, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}