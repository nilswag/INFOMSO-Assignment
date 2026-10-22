using App;
using App.commands;
using App.programs;

namespace Tests
{
    public class ProgramTests
    {
        [Fact]
        public void BasicProgramDoesNotAcceptRepeat()
        {
            BasicProgram program = new BasicProgram();

            program.AddCommand(new Repeat(2));

            Assert.Equal(0, program.GetMetrics().NrCommands);
        }

        [Fact]
        public void EmptyProgramHasZeroMetrics()
        {
            BasicProgram program = new BasicProgram();

            ProgramMetrics metrics = program.GetMetrics();

            Assert.Equal((0, 0, 0), (metrics.NrCommands, metrics.MaxNesting, metrics.NrRepeats));
        }

        [Theory]
        [InlineData(typeof(BasicProgram))]
        [InlineData(typeof(AdvancedProgram))]
        public void NestedRepeatNotAllowedInBasicAndAdvanced(Type programType)
        {
            Repeat outer = new Repeat(2);
            Repeat inner = new Repeat(3);

            outer.AddChild(inner, programType);

            Assert.Empty(outer.Body);
        }
    }
}
