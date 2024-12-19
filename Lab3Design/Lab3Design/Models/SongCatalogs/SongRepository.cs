using Lab3Design.Models.Songs;
using Microsoft.EntityFrameworkCore;
using DbContext = Lab3Design.Configurations.DbContext;


namespace Lab3Design.Models.SongCatalogs;

public class SongRepository : ISongRepository
{
    private readonly DbContext _dbContext;
    
    public SongRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Song>> GetSongsAsync()
    {
        return await _dbContext.songs.ToListAsync();
    }

    public async Task<List<Song>> GetSongsByCriteriaAsync(string criteria)
    {
        return await _dbContext
            .songs
            .Where(song => song.Name.Contains(criteria) || song.Author.Contains(criteria))
            .ToListAsync();
    }

    public async Task<Song> AddSongAsync(string name, string author)
    {
        var song = new Song(name, author);
        var addedSong = await _dbContext.AddAsync(song);
        await _dbContext.SaveChangesAsync();
        return addedSong.Entity;
    }

    public async Task<bool> DeleteSongAsync(string name, string author)
    {
        var song = await _dbContext.songs
            .FirstOrDefaultAsync(song => song.Name == name && song.Author == author);

        if (song == null)
        {
            return false;
        }

        _dbContext.songs.Remove(song);
        await _dbContext.SaveChangesAsync();
        return true;
    }

}