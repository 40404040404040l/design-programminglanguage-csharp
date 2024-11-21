using Lab2Design.SongCatalogDirectory;

namespace Lab2Design.ResponsibilityChain;

public class AddRequestHandler : ChainLinkBase
{
    public AddRequestHandler(SongRepository repository) : base(repository)
    {
        Repository = repository;
    }

    public override async Task Handle(string request)
    {
        if (request.ToLowerInvariant().Equals("add"))
        {
            Console.WriteLine("Enter song author:");
            var authorToAdd = Console.ReadLine();
            var flag = true;
            if (authorToAdd is null)
            {
                Console.WriteLine("Author can't be null");
                return;
            }
            foreach (var _ in authorToAdd.Where(letter => letter != ' '))
            {
                flag = false;
            }
            if (flag)
            {
                Console.WriteLine("Author can't be a space");
                return;
            }
            Console.WriteLine("Enter song name:");
            var nameToAdd = Console.ReadLine();
            if (nameToAdd is null)
            {
                Console.WriteLine("Name can't be null");
                return;
            }

            flag = true;
            foreach (var _ in nameToAdd.Where(letter => letter != ' '))
            {
                flag = false;
            }
            if (flag)
            {
                Console.WriteLine("Name can't be a space");
                return;
            }
            await Repository.AddSongAsync(nameToAdd, authorToAdd);
            Console.WriteLine("Song was added");
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