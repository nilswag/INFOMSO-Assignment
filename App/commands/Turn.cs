namespace App.commands;

public class Turn : Command
{
    public Direction Direction { get; private set; }

    public Turn(Direction direction)
    {
        Direction = direction;
    }
    
    public override void Execute(Player player, Type programType)
    {
        throw new NotImplementedException();
    }
}