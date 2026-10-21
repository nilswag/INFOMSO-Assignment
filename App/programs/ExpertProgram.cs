using App.commands;

namespace App.programs;

public class ExpertProgram : Program
{
    
    public ExpertProgram()
    {
        AvailableCommands.Add(typeof(Move));
        AvailableCommands.Add(typeof(Turn));
        AvailableCommands.Add(typeof(Repeat));
    }
    
    public override void Run()
    {
        foreach (var cmd in Commands)
            cmd.Execute(Player, GetType());
    }
}