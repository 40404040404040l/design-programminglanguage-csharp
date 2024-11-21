using Lab1Design.ResponsibilityChain;
using Lab2Design.SongCatalogDirectory;

namespace Lab2Design.ResponsibilityChain;

public abstract class ChainLinkBase : IChainLink
{
    protected IChainLink? Next { get; set; }
    protected SongRepository Repository;

    protected ChainLinkBase(SongRepository repository)
    {
        Repository = repository;
    }

    public void AddNext(IChainLink chainLink)
    {
        if (Next is null)
        {
            Next = chainLink;
        }
        else
        {
            Next.AddNext(chainLink);
        }
    }

    public abstract Task Handle(string request);
}