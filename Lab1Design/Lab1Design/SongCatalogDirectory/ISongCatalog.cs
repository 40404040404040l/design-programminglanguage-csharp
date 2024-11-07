using Lab1Design.SongDirectory;

namespace Lab1Design.SongCatalogDirectory;

public interface ISongCatalog
{
    IList<ISong> FindSong(string criteria);
    IEnumerable<ISong> ShowAllSongs();
    void AddSong(string songName, string author);
    void DeleteSong(string songName, string author);
    public void SaveToFile();
}