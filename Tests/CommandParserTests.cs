using App.commands;
using App.parsing;
using App.programs;

namespace Tests;

//we use strings here instead of reading a file, so the tests dont depend on a file existing
public class CommandParserTests
{
    [Fact]
    public void ParseSimpleCommands()
    {
        CommandParser parser = new CommandParser();
        string text = "Move 5\nTurn left\nTurn right";

        var commands = parser.Parse(text, typeof(BasicProgram));

        string[] expected = { "Move 5", "Turn left", "Turn right" };
        Assert.Equal(expected, commands.Select(c => c.ToString()));
    }

    [Fact]
    public void ParseRepeatWithIndentedBody()
    {
        CommandParser parser = new CommandParser();
        string text = "Repeat 4 times\n" +
                      "    Move 10\n" +
                      "    Turn right";

        var commands = parser.Parse(text, typeof(AdvancedProgram));

        Repeat repeat = Assert.IsType<Repeat>(Assert.Single(commands));
        Assert.Equal(2, repeat.Body.Count());
    }
}
