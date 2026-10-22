using App;
using App.commands;
using App.programs;

namespace Tests;

public class TurnTests
{
    //all 8 cases
    [Theory]
    [InlineData(Facing.North, Direction.Right, Facing.East)]
    [InlineData(Facing.East, Direction.Right, Facing.South)]
    [InlineData(Facing.South, Direction.Right, Facing.West)]
    [InlineData(Facing.West, Direction.Right, Facing.North)]
    [InlineData(Facing.North, Direction.Left, Facing.West)]
    [InlineData(Facing.East, Direction.Left, Facing.North)]
    [InlineData(Facing.South, Direction.Left, Facing.East)]
    [InlineData(Facing.West, Direction.Left, Facing.South)]
    public void TurnChangesFacing(Facing start, Direction direction, Facing expected)
    {
        Player player = new Player();
        player.Facing = start;
        Turn turn = new Turn(direction);

        turn.Execute(player, typeof(BasicProgram));

        Assert.Equal(expected, player.Facing);
    }
}
