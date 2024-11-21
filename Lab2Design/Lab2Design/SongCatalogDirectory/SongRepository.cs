using Lab2Design.SongDirectory;
using Microsoft.EntityFrameworkCore;

namespace Lab2Design.SongCatalogDirectory;

public class SongRepository
{
    private readonly DbContext _dbContext = new DbContext();

    public async Task<List<Song>> GetSongsAsync()
    {
        return await _dbContext.songs.AsNoTracking().ToListAsync();
    }

    public async Task<List<Song>> GetSongsByCriteriaAsync(string criteria)
    {
        return await _dbContext
            .songs
            .AsNoTracking()
            .Where(song => song.Name.Contains(criteria) || song.Author.Contains(criteria))
            .ToListAsync();
    }

    public async Task AddSongAsync(string name, string author)
    {
        var song = new Song(name, author);
        await _dbContext.AddAsync(song);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteSongAsync(string name, string author)
    {
        await _dbContext.songs.Where(song => song.Name == name && song.Author == author).ExecuteDeleteAsync();
    }
}