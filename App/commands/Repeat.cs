namespace App.commands;

public class Repeat : CommandBody
{
    public int NrRepeats { get; private set; }
    
    public Repeat(int nrRepeats)
    {
        NrRepeats = nrRepeats;
    }
    
    public override void Execute(Player player, Type programType)
    {
        for (var i = 0; i < NrRepeats; i++)
            ExecuteBody(player, programType);
    }
}