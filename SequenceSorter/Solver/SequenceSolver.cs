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
            SequenceValues = _algorithm.Step();
            
            await Task.Delay(WaitBetweenStepsMs);
            
            SortingStepCompleted?.Invoke(this, new SortingStepCompleteEventArgs(_algorithm.IndexOfLast, _algorithm.ValueOfLast));
        }
    }
}