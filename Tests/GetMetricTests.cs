using App;
using App.programs;

namespace Tests
{
    public class GetMetricTests
    {
        //tests whether all the metrics are correct for the ExpertProgram and therefore tests all the outputs of the getMetrics() method
        [Fact]
        public void ExpertExampleMetrics()
        {
            ExpertProgram program = ProgramFactory.CreateExpert();

            ProgramMetrics metrics = program.GetMetrics();

            Assert.Equal(11, metrics.NrCommands);
            Assert.Equal(2, metrics.MaxNesting);
            Assert.Equal(2, metrics.NrRepeats);
        }
    }
}
