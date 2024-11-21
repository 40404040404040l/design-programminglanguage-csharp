namespace Lab2Design.ConsoleInterfaceDirectory;

public class ConsolePrinter
{
    public static void Greet()
    {
        Console.WriteLine("Hi! Welcome to SongCatalog!");
        Console.WriteLine("Here is instruction for program:");
        Console.WriteLine("'list' to display all items of catalog");
        Console.WriteLine("'search' to go find items in catalog");
        Console.WriteLine("'add' to add new song");
        Console.WriteLine("'del' to delete song from list");
        Console.WriteLine("'quit' to exit");
    }
}