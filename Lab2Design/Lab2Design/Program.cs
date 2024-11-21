using Lab2Design.ConsoleInterfaceDirectory;
using Lab2Design.ResponsibilityChain;

namespace Lab2Design;

internal class Program
{
    public static async Task Main(string[] args)
    {
        ConsolePrinter.Greet();
        var responsibilityChain = new ResponsibilityChainFactory().CreateChain();
        while (true)
        {
            Console.WriteLine("Input the command:");
            var command = Console.ReadLine();
            if (command is null)
            {
                Console.WriteLine("Wrong command! Try again");
                continue;
            }
    
            await responsibilityChain.Handle(command);
        }
    }
}