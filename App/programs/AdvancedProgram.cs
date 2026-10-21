using App.commands;

namespace App.programs;

public class AdvancedProgram : Program
{
    private Player _player;
    
    public AdvancedProgram()
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