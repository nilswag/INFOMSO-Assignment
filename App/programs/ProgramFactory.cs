namespace App.programs;

public class ProgramFactory
{

    public static BasicProgram CreateBasic()
    {
        return new BasicProgram();
    }

    public static AdvancedProgram CreateAdvanced()
    {
        return new AdvancedProgram();
    }
    
    public static ExpertProgram CreateExpert()
    {
        return new ExpertProgram();
    }
    
}