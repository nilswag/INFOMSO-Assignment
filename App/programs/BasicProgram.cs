using App.commands;

namespace App.programs;

public class BasicProgram : Program
{
    private Player _player;
    
    public BasicProgram()
    {
        AvailableCommands.Add(typeof(Move));
        AvailableCommands.Add(typeof(Turn));

        _player = new();
    }
    
    public override void Run()
    {
        foreach (var cmd in Commands)
            cmd.Execute(_player, GetType());
    }
}