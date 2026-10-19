namespace App;

public class Player
{
    public int X { get; private set; } = 0;
    public int Y { get; private set; } = 0;
    public Facing Facing { get; private set; } = Facing.East;

    public void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }
    
}