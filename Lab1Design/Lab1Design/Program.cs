using Lab1Design.ConsoleInterfaceDirectory;
using Lab1Design.SongCatalogDirectory;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("HUI");
        ISongCatalog songCatalog = new SongCatalog("/Users/40404040404040l/RiderProjects/design-programminglanguage-csharp/Lab1Design/Lab1Design/songs.json");
        var consolePrinter = new ConsolePrinter();
        consolePrinter.Greet();
        while (true)
        {
            Console.WriteLine("Input the command:");
            var command = Console.ReadLine();
            if (command is null)
            {
                Console.WriteLine("Wrong command! Try again");
                continue;
            }

            command = command.ToLowerInvariant();
            if (command.Equals("list"))
            {
                Console.WriteLine("All compositions in catalog:");
                consolePrinter.PrintAllSongs(songCatalog.ShowAllSongs());
            }

            else if (command.Equals("search"))
            {
                Console.WriteLine("Enter song name or author");
                var criteria = Console.ReadLine();
                if (criteria is not null)
                {
                    var searchResult = songCatalog.FindSong(criteria);
                    if (searchResult.Count == 0)
                    {
                        Console.WriteLine("No one item was found by this criteria");
                    }
                    else
                    {
                        Console.WriteLine("All found songs:");
                        consolePrinter.PrintAllSongs(searchResult);
                    }
                }
                else
                {
                    Console.WriteLine("Wrong request! Try again!");
                }
            }

            else if (command.Equals("add"))
            {
                Console.WriteLine("Enter song author:");
                var authorToAdd = Console.ReadLine();
                var flag = true;
                if (authorToAdd is null)
                {
                    Console.WriteLine("Author can't be null");
                    continue;
                }
                foreach (var letter in authorToAdd.Where(letter => letter != ' '))
                {
                    flag = false;
                }
                if (flag)
                {
                    Console.WriteLine("Author can't be a space");
                    continue;
                }
                Console.WriteLine("Enter song name:");
                var nameToAdd = Console.ReadLine();
                if (nameToAdd is null)
                {
                    Console.WriteLine("Name can't be null");
                    continue;
                }

                flag = true;
                foreach (var letter in nameToAdd.Where(letter => letter != ' '))
                {
                    flag = false;
                }
                if (flag)
                {
                    Console.WriteLine("Name can't be a space");
                    continue;
                }
                songCatalog.AddSong(nameToAdd, authorToAdd);
                Console.WriteLine("Song was added");
            }

            else if (command.Equals("del"))
            {
                Console.WriteLine("Enter song author:");
                var authorToDelete = Console.ReadLine();
                var flag = true;
                if (authorToDelete is null)
                {
                    Console.WriteLine("Author can't be null");
                    continue;
                }
                foreach (var letter in authorToDelete.Where(letter => letter != ' '))
                {
                    flag = false;
                }
                if (flag)
                {
                    Console.WriteLine("Author can't be a space");
                    continue;
                }
                Console.WriteLine("Enter song name:");
                var nameToDelete = Console.ReadLine();
                flag = true;
                if (nameToDelete is null)
                {
                    Console.WriteLine("Name can't be null");
                    continue;
                }
                foreach (var letter in nameToDelete.Where(letter => letter != ' '))
                {
                    flag = false;
                }
                if (flag)
                {
                    Console.WriteLine("Name can't be a space");
                    continue;
                }
                songCatalog.DeleteSong(nameToDelete, authorToDelete);
                Console.WriteLine("Song was deleted");
            }

            else if (command.Equals("quit"))
            {
                songCatalog.SaveToFile();
                break;
            }
            
            else
            {
                Console.WriteLine("Wrong command!");
            }
        }
    }
}
