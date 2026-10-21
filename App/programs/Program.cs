using App.commands;

namespace App.programs;

public abstract class Program
{
    protected LinkedList<Command> Commands = new();
    protected List<Type> AvailableCommands = [];
    protected Player Player = new();

    public abstract void Run();

    public void AddCommand(Command cmd)
    {
        if (!AvailableCommands.Contains(cmd.GetType()))
        {
            Console.Error.WriteLine("Program does not support: " + cmd.GetType());
            return;
        } // perhaps throw exception
        
        Commands.AddLast(cmd);
    }

    public void ImportCommands(LinkedList<Command> cmds)
    {
        Commands = cmds;
    }

    public ProgramMetrics GetMetrics()
    {
        return new ProgramMetrics(Commands);
    }
    
}