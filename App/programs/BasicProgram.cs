using App.commands;

namespace App.programs;

public class BasicProgram : Program
{
    
    public BasicProgram()
    {
        AvailableCommands.Add(typeof(Move));
        AvailableCommands.Add(typeof(Turn));
    }
    
    public override void Run()
    {
        foreach (var cmd in Commands)
            cmd.Execute(Player, GetType());
    }
}