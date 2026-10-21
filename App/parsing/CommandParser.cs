using App.commands;
using App.programs;

namespace App.parsing;

public class CommandParser
{
    private string[] _lines = new string[0];
    private int _index;
    private Type _programType = typeof(Program);

    public LinkedList<Command> Parse(string text, Type programType)
    {
        _programType = programType;
        _lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        _index = 0;

        return ParseBlock(0);
    }

    private LinkedList<Command> ParseBlock(int depth)
    {
        var commands = new LinkedList<Command>();

        while (_index < _lines.Length && GetDepth(_lines[_index]) == depth)
        {
            var cmd = ParseCommand(_lines[_index]);
            _index++;

            if (cmd is CommandBody body)
            {
                foreach (var child in ParseBlock(depth + 1))
                    body.AddChild(child, _programType);
            }

            commands.AddLast(cmd);
        }

        return commands;
    }

    private int GetDepth(string line)
    {
        return (line.Length - line.TrimStart().Length) / 4;
    }

    private Command ParseCommand(string line)
    {
        var parts = line.Trim().Split(' ');

        if (parts[0] == "Move")
            return new Move(int.Parse(parts[1]));

        if (parts[0] == "Turn")
        {
            if (parts[1] == "left")
                return new Turn(Direction.Left);

            return new Turn(Direction.Right);
        }

        if (parts[0] == "Repeat")
            return new Repeat(int.Parse(parts[1]));

        throw new FormatException($"Unknown command: {line}");
    }
}