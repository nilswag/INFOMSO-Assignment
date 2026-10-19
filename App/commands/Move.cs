namespace App.commands;

public class Move : Command
{
    public int Steps { get; private set; }

    public Move(int steps)
    {
        Steps = steps;
    }
    
    public override void Execute(Player player, Type programType)
    {
        
    }
}