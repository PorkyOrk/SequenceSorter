namespace SequenceSorter.Solver.SortingAlgorithms;

public interface ISortingAlgorithm
{
    /// <summary>
    /// Index of the most recently sorted item.
    /// </summary>
    public int IndexOfLast { get; }
    
    /// <summary>
    /// Value of the most recently sorted item.
    /// </summary>
    public int ValueOfLast { get; }
    
    /// <summary>
    /// Indicates the algorithm has completed sorting of the sequence.
    /// </summary>
    public bool IsSolved { get; }

    /// <summary>
    /// Required to setup the algorithm with input data.
    /// </summary>
    /// <param name="inputSequence">Initial sequence to be parsed by the algorithm.</param>
    public void Initialize(int[] inputSequence);
    
    /// <summary>
    /// Run single step in the sorting process.
    /// </summary>
    /// <returns>Sequence after running through the step.</returns>
    public int[] Step();
}