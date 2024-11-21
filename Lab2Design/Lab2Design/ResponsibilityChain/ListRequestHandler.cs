using Lab2Design.SongCatalogDirectory;

namespace Lab2Design.ResponsibilityChain;

public class ListRequestHandler : ChainLinkBase
{
    public ListRequestHandler(SongRepository repository) : base(repository)
    {
    }

    public override Task Handle(string request)
    {
        if (request.ToLowerInvariant().Equals("list"))
        {
            Console.WriteLine("All compositions in catalog:");
            foreach (var song in Repository.GetSongsAsync().Result)
            {
                Console.WriteLine(song.GetStringRepresentation());
            }
        }
        else
        {
            if (Next is not null)
            {
                Next.Handle(request);
            }
            else
            {
                Console.WriteLine("Wrong request");
            }
        }
        return Task.CompletedTask;
    }
}