using Lab2Design.SongDirectory;

namespace Lab2Design.SongCatalogDirectory;

public interface ISongCatalog
{
    Task<IList<ISong>> FindSong(string criteria);
    Task<IEnumerable<ISong>> ShowAllSongs();
    Task AddSong(string songName, string author);
    Task DeleteSong(string songName, string author);
    Task SaveToFile();
}