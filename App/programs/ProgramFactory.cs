using App.commands;

namespace App.programs;

public class ProgramFactory
{

    public static BasicProgram CreateBasic()
    {
        var program = new BasicProgram();

        for (var i = 0; i < 4; i++)
        {
            program.AddCommand(new Move(10));
            program.AddCommand(new Turn(Direction.Right));
        }

        return program;
    }

    public static AdvancedProgram CreateAdvanced()
    {
        var program = new AdvancedProgram();

        var repeat = new Repeat(4);
        repeat.AddChild(new Move(10), typeof(AdvancedProgram));
        repeat.AddChild(new Turn(Direction.Right), typeof(AdvancedProgram));
        program.AddCommand(repeat);

        return program;
    }
    
    public static ExpertProgram CreateExpert()
    {
        var program = new ExpertProgram();

        program.AddCommand(new Move(5));
        program.AddCommand(new Turn(Direction.Left));
        program.AddCommand(new Turn(Direction.Left));
        program.AddCommand(new Move(3));
        program.AddCommand(new Turn(Direction.Right));

        var outer = new Repeat(3);
        outer.AddChild(new Move(1), typeof(ExpertProgram));
        outer.AddChild(new Turn(Direction.Right), typeof(ExpertProgram));

        var inner = new Repeat(5);
        inner.AddChild(new Move(2), typeof(ExpertProgram));
        outer.AddChild(inner, typeof(ExpertProgram));

        program.AddCommand(outer);
        program.AddCommand(new Turn(Direction.Left));

        return program;
    }
    
}