namespace Lab1Design.ResponsibilityChain;

public interface IChainLink
{
    void AddNext(IChainLink chainLink);
    Task Handle(string request);
}