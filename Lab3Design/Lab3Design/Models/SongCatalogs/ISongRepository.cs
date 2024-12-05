using Lab3Design.Models.Songs;

namespace Lab3Design.Models.SongCatalogs;

public interface ISongRepository
{
    Task<IList<ISong>> FindSong(string criteria);
    Task<IEnumerable<ISong>> ShowAllSongs();
    Task AddSong(string songName, string author);
    Task DeleteSong(string songName, string author);
    Task SaveToFile();
}