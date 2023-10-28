using SequenceSorter.Solver.SortingAlgorithms;

namespace SequenceSorter.Solver;

public class SequenceSolver
{
    public int[] SequenceValues { get; private set; } = null!;

    private readonly ISortingAlgorithm _algorithm;
    private const int WaitBetweenStepsMs = 1;

    public event EventHandler<SortingStepCompleteEventArgs>? SortingStepCompleted; 
    
    public SequenceSolver(ISortingAlgorithm algorithm, int[] sequence)
    {
        _algorithm = algorithm;
        _algorithm.Initialize(sequence);
    }
    
    public async void Solve()
    {
        while (_algorithm.IsSolved == false)
        {
            // var t = new Task<int[]>(() =>_algorithm.Step());
            // t.Start();
            // SequenceValues = t.Result;

            SequenceValues = await Task.Run(() => _algorithm.Step());
            await Task.Delay(WaitBetweenStepsMs);
            
            SortingStepCompleted?.Invoke(this, new SortingStepCompleteEventArgs(_algorithm.IndexOfLast, _algorithm.ValueOfLast));
        }
    }
}