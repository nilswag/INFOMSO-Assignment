using App;
using App.programs;

namespace Tests;

//tests for the 3 example programs, checks if the end state is the same as in the assignment
public class ProgramFactoryTests
{
    [Fact]
    public void BasicExampleEndState()
    {
        BasicProgram program = ProgramFactory.CreateBasic();

        program.Run();

        Player p = program.Player;
        Assert.Equal((0, 0, Facing.East), (p.X, p.Y, p.Facing));
    }

    [Fact]
    public void AdvancedExampleEndState()
    {
        AdvancedProgram program = ProgramFactory.CreateAdvanced();

        program.Run();

        Player p = program.Player;
        Assert.Equal((0, 0, Facing.East), (p.X, p.Y, p.Facing));
    }

    [Fact]
    public void ExpertExampleEndState()
    {
        ExpertProgram program = ProgramFactory.CreateExpert();

        program.Run();

        Player p = program.Player;
        Assert.Equal((3, -10, Facing.South), (p.X, p.Y, p.Facing));
    }
}
