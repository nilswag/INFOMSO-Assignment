using App.commands;

namespace App.programs;

public class AdvancedProgram : Program
{
    public AdvancedProgram()
    {
        AvailableCommands.Add(typeof(Move));
        AvailableCommands.Add(typeof(Turn));
        AvailableCommands.Add(typeof(Repeat));
    }
    
    public override void Run()
    {
        throw new NotImplementedException();
    }
}