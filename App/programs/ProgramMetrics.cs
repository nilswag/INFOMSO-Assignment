using App.commands;

namespace App.programs;

public class ProgramMetrics
{
    public int NrCommands { get; private set; }
    public int MaxNesting { get; private set; }
    public int NrRepeats { get; private set; }

    public ProgramMetrics(IEnumerable<Command> commands)
    {
        NrCommands = CalculateCommands(commands);
        MaxNesting = CalculateNesting(commands);
        NrRepeats = CalculateRepeats(commands);
    }

    private static int CalculateCommands(IEnumerable<Command> commands)
    {
        var count = 0;

        foreach (var command in commands)
        {
            count++;

            if (command is CommandBody body)
                count += CalculateCommands(body.Body);
        }

        return count;
    }

    private static int CalculateNesting(IEnumerable<Command> commands)
    {
        var count = 0;

        foreach (var command in commands)
        {
            if (command is CommandBody body)
                count = Math.Max(count, 1 + CalculateNesting(body.Body));
        }

        return count;
    }

    private static int CalculateRepeats(IEnumerable<Command> commands)
    {
        int count = 0;

        foreach (var command in commands)
        {
            if (command is Repeat) count++;

            if (command is CommandBody body)
                count += CalculateRepeats(body.Body);
        }
        
        return count;
    }
    
}