using App;

namespace Tests;

public class PlayerTests
{
    [Theory]
    [InlineData(Facing.North, 3, 0, 3)]
    [InlineData(Facing.East, 3, 3, 0)]
    [InlineData(Facing.South, 3, 0, -3)]
    [InlineData(Facing.West, 3, -3, 0)]
    [InlineData(Facing.East, 0, 0, 0)] 
    public void MoveChangesPosition(Facing facing, int steps, int expectedX, int expectedY)
    {
        Player player = new Player();
        player.Facing = facing;

        player.Move(steps);

        Assert.Equal((expectedX, expectedY), (player.X, player.Y));
    }
}
