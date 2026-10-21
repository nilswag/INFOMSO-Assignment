using App.parsing;
using App.programs;

namespace App;

public class Cli
{
    public void Start()
    {
        while (true)
        {
            var program = SelectProgram();
            if (program == null)
                return;

            Console.WriteLine("1. Execute");
            Console.WriteLine("2. Calculate metrics");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Execute(program);
                    break;
                case "2":
                    PrintMetrics(program);
                    break;
                default:
                    Console.WriteLine("Unknown option");
                    break;
            }

            Console.WriteLine();
        }
    }

    private Program? SelectProgram()
    {
        Console.WriteLine("1. Basic example");
        Console.WriteLine("2. Advanced example");
        Console.WriteLine("3. Expert example");
        Console.WriteLine("4. Import from file");
        Console.WriteLine("0. Quit");
        Console.Write("Choose a program: ");

        switch (Console.ReadLine())
        {
            case "1":
                return ProgramFactory.CreateBasic();
            case "2":
                return ProgramFactory.CreateAdvanced();
            case "3":
                return ProgramFactory.CreateExpert();
            case "4":
                return ImportProgram();
            case "0":
                return null;
            default:
                Console.WriteLine("Unknown option");
                return SelectProgram();
        }
    }

    private Program? ImportProgram()
    {
        Console.Write("File path: ");
        var path = Console.ReadLine() ?? "";

        try
        {
            var text = File.ReadAllText(path);
            var commands = new CommandParser().Parse(text, typeof(ExpertProgram));
            var metrics = new ProgramMetrics(commands);

            Program program;
            if (metrics.NrRepeats == 0)
                program = ProgramFactory.CreateBasic();
            else if (metrics.MaxNesting == 1)
                program = ProgramFactory.CreateAdvanced();
            else
                program = ProgramFactory.CreateExpert();

            program.ImportCommands(commands);
            return program;
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Could not import program: " + e.Message);
            return SelectProgram();
        }
    }

    private static void Execute(Program program)
    {
        program.Run();

        var player = program.Player;
        Console.WriteLine(program.GetTrace());
        Console.WriteLine($"End state ({player.X},{player.Y}) facing {player.Facing.ToString().ToLower()}.");
    }

    private static void PrintMetrics(Program program)
    {
        var metrics = program.GetMetrics();

        Console.WriteLine("No. of commands: " + metrics.NrCommands);
        Console.WriteLine("Max nesting: " + metrics.MaxNesting);
        Console.WriteLine("No. of repeats: " + metrics.NrRepeats);
    }
}