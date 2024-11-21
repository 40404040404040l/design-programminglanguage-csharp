using Lab2Design.SongCatalogDirectory;

namespace Lab2Design.ResponsibilityChain;

public class QuitRequestHandler : ChainLinkBase
{
    public QuitRequestHandler(SongRepository repository) : base(repository)
    {
    }

    public override async Task Handle(string request)
    {
        if (request.ToLowerInvariant().Equals("quit"))
        {
            Environment.Exit(0);
        }
        else
        {
            if (Next is not null)
            {
                await Next.Handle(request);
            }
            else
            {
                Console.WriteLine("Wrong request");
            }
        }
    }
}