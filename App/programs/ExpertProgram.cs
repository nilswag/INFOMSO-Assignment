using App.commands;

namespace App.programs;

public class ExpertProgram : Program
{
    private Player _player;
    
    public ExpertProgram()
    {
        AvailableCommands.Add(typeof(Move));
        AvailableCommands.Add(typeof(Turn));
        AvailableCommands.Add(typeof(Repeat));

        _player = new();
    }
    
    public override void Run()
    {
        foreach (var cmd in Commands)
            cmd.Execute(_player, GetType());
    }
}