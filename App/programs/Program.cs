using App.commands;

namespace App.programs;

public abstract class Program
{
    protected LinkedList<Command> Commands = new();
    protected List<Type> AvailableCommands = [];
    public Player Player { get; } = new();

    public abstract void Run();

    public void AddCommand(Command command)
    {
        if (!AvailableCommands.Contains(command.GetType()))
        {
            Console.Error.WriteLine("Program does not support: " + command.GetType());
            return;
        } // perhaps throw exception
        
        Commands.AddLast(command);
    }

    public void ImportCommands(LinkedList<Command> command)
    {
        Commands = command;
    }

    public string GetTrace()
    {
        var steps = new List<string>();
        CollectSteps(Commands, steps);

        return string.Join(", ", steps) + ".";
    }

    private static void CollectSteps(IEnumerable<Command> commands, List<string> steps)
    {
        foreach (var command in commands)
        {
            if (command is Repeat repeat)
            {
                for (var i = 0; i < repeat.NrRepeats; i++)
                    CollectSteps(repeat.Body, steps);
            }
            else
                steps.Add(command.ToString());
        }
    }

    public ProgramMetrics GetMetrics()
    {
        return new ProgramMetrics(Commands);
    }
    
}