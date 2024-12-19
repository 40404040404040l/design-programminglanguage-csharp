using Lab3Design.Models.Songs;

namespace Lab3Design.Models.SongCatalogs;

public interface ISongRepository
{
    public Task<List<Song>> GetSongsAsync();
    public Task<List<Song>> GetSongsByCriteriaAsync(string criteria);
    public Task<Song> AddSongAsync(string name, string author);
    public Task<bool> DeleteSongAsync(string name, string author);
}