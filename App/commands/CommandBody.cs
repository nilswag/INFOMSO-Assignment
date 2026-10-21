using App.programs;

namespace App.commands;

public abstract class CommandBody : Command
{
    private readonly LinkedList<Command> _body = new();

    public void AddChild(Command cmd, Type programType)
    {
        if (cmd is CommandBody && programType != typeof(ExpertProgram))
        {
            Console.Error.WriteLine("Nested commands that have bodies are only allowed in expert programs.");
            return;
        } // potentially throw exception
        
        _body.AddLast(cmd);
    }

    protected void ExecuteBody(Player player, Type programType)
    {
        foreach (var cmd in _body)
            cmd.Execute(player, programType);
    }
}