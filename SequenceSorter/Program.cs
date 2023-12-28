using SequenceSorter.Algorithms;
using SequenceSorter.Generator;
using SequenceSorter.Solver;

namespace SequenceSorter;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        const int valueCount = 100;
        var seed = (int) DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;
        
        var generator = new SequenceGenerator(0,valueCount, seed);
        var sequence = generator.ShuffledSequence(valueCount);
        var algorithm = new SelectionSort();
        var solver = new SequenceSolver(algorithm, sequence);
        
        solver.Solve();

        var visualizer = new ValuesSequenceVisualizerForm(solver);
        
        Application.Run(visualizer);
    }
}