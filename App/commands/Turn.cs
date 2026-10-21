namespace App.commands;

public class Turn : Command
{
    public Direction Direction { get; private set; }

    public Turn(Direction direction)
    {
        Direction = direction;
    }
    
    public override string ToString()
    {
        return $"Turn {Direction.ToString().ToLower()}";
    }

    public override void Execute(Player player, Type programType)
    {
        var arr = Enum.GetValues<Facing>();
        
        var index = (int)player.Facing + (int)Direction;
        index %= 4;
        if (index < 0)
            index = 3;

        player.Facing = arr[index];
    }
}