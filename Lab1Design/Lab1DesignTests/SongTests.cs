using Lab1Design.SongCatalogDirectory;
using Lab1Design.SongDirectory;
using Xunit;

public class SongTests
{
    [Fact]
    public void CreateSong_ShouldInitializeCorrectly()
    {
        var song = new Song("song1", "author1");
        Assert.Equal("song1", song.Name);
        Assert.Equal("author1", song.Author);
    }

    [Fact]
    public void GetStringRepresentation_ShouldReturnFormattedString()
    {
        var song = new Song("song1", "author1");
        Assert.Equal("song1 - author1", song.GetStringRepresentation());
    }

    [Fact]
    public void AddSong_ToCatalog_ShouldStoreSong()
    {
        var catalog = new SongCatalog("testPath");
        catalog.AddSong("song1", "author1");
        Assert.True(Enumerable.ElementAt(catalog.ShowAllSongs(), 0).GetStringRepresentation() == "song1 - author1");
    }

    [Fact]
    public void DeleteSong_FromCatalog_ShouldRemoveSong()
    {
        var catalog = new SongCatalog("testPath");
        catalog.AddSong("song1", "author1");
        catalog.DeleteSong("song1", "author1");
        Assert.Empty(catalog.ShowAllSongs());
    }

    [Fact]
    public void FindSong_InCatalog_ShouldReturnCorrectSongs()
    {
        var catalog = new SongCatalog("testPath");
        catalog.AddSong("song1", "author1");
        catalog.AddSong("song2", "author2");

        Assert.Equal("song1 - author1", catalog.FindSong("song1")[0].GetStringRepresentation());
        Assert.Equal("song1 - author1", catalog.FindSong("author1")[0].GetStringRepresentation());
        Assert.Equal("song2 - author2", catalog.FindSong("song2")[0].GetStringRepresentation());
        Assert.Equal("song2 - author2", catalog.FindSong("author2")[0].GetStringRepresentation());
    }

    [Fact]
    public void ShowAllSongs_ShouldReturnAllSongs()
    {
        var catalog = new SongCatalog("testPath");
        catalog.AddSong("song1", "author1");
        catalog.AddSong("song2", "author2");

        Assert.Equal("song1 - author1", Enumerable.ElementAt(catalog.ShowAllSongs(), 0).GetStringRepresentation());
        Assert.Equal("song2 - author2", Enumerable.ElementAt(catalog.ShowAllSongs(), 1).GetStringRepresentation());
    }
}
