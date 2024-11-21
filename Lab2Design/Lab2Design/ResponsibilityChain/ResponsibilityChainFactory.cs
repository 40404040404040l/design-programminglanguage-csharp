using Lab1Design.ResponsibilityChain;
using Lab2Design.SongCatalogDirectory;

namespace Lab2Design.ResponsibilityChain;

public class ResponsibilityChainFactory : IResponsibilityChainFactory
{
    public ChainLinkBase CreateChain()
    {
        var songRepository = new SongRepository();
        var addRequestHandler = new AddRequestHandler(songRepository);
        var delRequestHandler = new DelRequestHandler(songRepository);
        var listRequestHandler = new ListRequestHandler(songRepository);
        var quitRequestHandler = new QuitRequestHandler(songRepository);
        var searchRequestHandler = new SearchRequestHandler(songRepository);
        addRequestHandler.AddNext(delRequestHandler);
        addRequestHandler.AddNext(listRequestHandler);
        addRequestHandler.AddNext(quitRequestHandler);
        addRequestHandler.AddNext(searchRequestHandler);
        return addRequestHandler;
    }
}