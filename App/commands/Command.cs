namespace App.commands;

public abstract class Command
{
    public abstract void Execute(Player player, Type programType);
}