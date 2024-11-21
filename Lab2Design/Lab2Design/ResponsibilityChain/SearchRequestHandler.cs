using Lab2Design.SongCatalogDirectory;

namespace Lab2Design.ResponsibilityChain;

public class SearchRequestHandler : ChainLinkBase
{
    public SearchRequestHandler(SongRepository repository) : base(repository)
    {
    }

    public override Task Handle(string request)
    {
        if (request.ToLowerInvariant().Equals("search"))
        {
            Console.WriteLine("Enter song name or author");
            var criteria = Console.ReadLine();
            if (criteria is not null)
            {
                var searchResult = Repository.GetSongsByCriteriaAsync(criteria).Result;
                if (searchResult.Count == 0)
                {
                    Console.WriteLine("No one item was found by this criteria");
                }
                else
                {
                    Console.WriteLine("All found songs:");
                    foreach (var song in searchResult)
                    {
                        Console.WriteLine(song.GetStringRepresentation());
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong request! Try again!");
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