using Lab2Design.SongCatalogDirectory;

namespace Lab2Design.ResponsibilityChain;

public class DelRequestHandler : ChainLinkBase
{
    public DelRequestHandler(SongRepository repository) : base(repository)
    {
    }

    public override async Task Handle(string request)
    {
        if (request.ToLowerInvariant().Equals("del"))
        {
            Console.WriteLine("Enter song author:");
            var authorToDelete = Console.ReadLine();
            var flag = true;
            if (authorToDelete is null)
            {
                Console.WriteLine("Author can't be null");
                return;
            }

            foreach (var _ in authorToDelete.Where(letter => letter != ' '))
            {
                flag = false;
            }

            if (flag)
            {
                Console.WriteLine("Author can't be a space");
                return;
            }

            Console.WriteLine("Enter song name:");
            var nameToDelete = Console.ReadLine();
            flag = true;
            if (nameToDelete is null)
            {
                Console.WriteLine("Name can't be null");
                return;
            }

            foreach (var _ in nameToDelete.Where(letter => letter != ' '))
            {
                flag = false;
            }

            if (flag)
            {
                Console.WriteLine("Name can't be a space");
                return;
            }

            await Repository.DeleteSongAsync(nameToDelete, authorToDelete);
            Console.WriteLine("Song was deleted");
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