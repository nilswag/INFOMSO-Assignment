using App.commands;

namespace App.programs;

public abstract class Program
{
    protected LinkedList<Command> Commands = new();
    protected List<Type> AvailableCommands = new();

    public abstract void Run();

    public void AddCommand(Command cmd)
    {
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