using Lab1Design.SongCatalogDirectory;
using Lab1Design.SongDirectory;
using Xunit;

public class Tests
{
    [Fact]
    public void SongCreateTest()
    {
        var song = new Song("song1", "author1");
        Assert.Equal("song1", song.Name);
        Assert.Equal("author1", song.Author);
    }

    [Fact]
    public void SongGetStringRepresentationTest()
    {
        var song = new Song("song1", "author1");
        Assert.Equal("song1 - author1", song.GetStringRepresentation());
    }

    [Fact]
    public void SongCatalogAddSongTest()
    {
        var songCatalog = new SongCatalog("testPath");
        songCatalog.AddSong("song1", "author1");
        Assert.True(Enumerable.ElementAt(songCatalog.ShowAllSongs(), 0).GetStringRepresentation() == "song1 - author1");
    }

    [Fact]
    public void SongCatalogDeleteSongTest()
    {
        var songCatalog = new SongCatalog("testPath");
        songCatalog.AddSong("song1", "author1");
        songCatalog.DeleteSong("song1", "author1");
        Assert.Empty(songCatalog.ShowAllSongs());
    }

    [Fact]
    public void SongCatalogFindSongTest()
    {
        var songCatalog = new SongCatalog("testPath");
        songCatalog.AddSong("song1", "author1");
        songCatalog.AddSong("song2", "author2");
        Assert.Equal("song1 - author1", songCatalog.FindSong("song1")[0].GetStringRepresentation());
        Assert.Equal("song1 - author1", songCatalog.FindSong("author1")[0].GetStringRepresentation());
        Assert.Equal("song2 - author2", songCatalog.FindSong("song2")[0].GetStringRepresentation());
        Assert.Equal("song2 - author2", songCatalog.FindSong("author2")[0].GetStringRepresentation());
    }

    [Fact]
    public void SongCatalogShowAllSongsTest()
    {
        var songCatalog = new SongCatalog("testPath");
        songCatalog.AddSong("song1", "author1");
        songCatalog.AddSong("song2", "author2");
        Assert.Equal("song1 - author1", Enumerable.ElementAt(songCatalog.ShowAllSongs(), 0).GetStringRepresentation());
        Assert.Equal("song2 - author2", Enumerable.ElementAt(songCatalog.ShowAllSongs(), 1).GetStringRepresentation());
    }
}