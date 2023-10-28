using SequenceSorter.Generator;
using SequenceSorter.Solver;
using SequenceSorter.Solver.SortingAlgorithms;

namespace SequenceSorter;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        const int valueCount = 100;
        
        var generator = new SequenceGenerator(0,valueCount, (int)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds);
        
        var seq = generator.ShuffledSequence(valueCount);
        var algorithm = new SelectionSort();

        var solver = new SequenceSolver(algorithm, seq);
        solver.Solve();

        var visualizer = new ValuesSequenceVisualizerForm(solver);

        Application.Run(visualizer);
    }
}