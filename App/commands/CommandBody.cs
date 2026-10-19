using App.programs;

namespace App.commands;

public abstract class CommandBody : Command
{
    private LinkedList<Command> _body = new();

    public void AddChild(Command cmd)
    {
        _body.AddLast(cmd);
    }

    public void ExecuteBody(Player player, Type programType)
    {
        foreach (var cmd in _body)
            cmd.Execute(player, programType);
    }
}