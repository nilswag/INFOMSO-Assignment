using App.commands;

namespace App.programs;

public class ProgramMetrics
{
    public int NrCommands { get; private set; }
    public int MaxNesting { get; private set; }
    public int NrRepeats { get; private set; }

    public ProgramMetrics(LinkedList<Command> commands)
    {
        
    }
}