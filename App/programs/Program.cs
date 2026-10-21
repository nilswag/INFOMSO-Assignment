using App.commands;

namespace App.programs;

public abstract class Program
{
    protected LinkedList<Command> Commands = new();
    protected List<Type> AvailableCommands = [];
    protected Player Player = new();

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

    public ProgramMetrics GetMetrics()
    {
        return new ProgramMetrics(Commands);
    }
    
}