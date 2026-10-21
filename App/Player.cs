namespace App;

public class Player
{
    public int X { get; private set; } = 0;
    public int Y { get; private set; } = 0;
    public Facing Facing { get; set; } = Facing.East;

    public void Move(int steps)
    {
        int xa = 0, ya = 0;
        switch (Facing)
        {
            case Facing.North:
                ya = 1;
                break;
            case Facing.East:
                xa = 1;
                break;
            case Facing.South:
                ya = -1;
                break;
            case Facing.West:
                xa = -1;
                break;
        }

        X += xa * steps;
        Y += ya * steps;
    }
    
}