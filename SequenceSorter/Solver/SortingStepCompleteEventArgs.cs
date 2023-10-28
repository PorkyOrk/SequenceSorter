namespace SequenceSorter.Solver;

public class SortingStepCompleteEventArgs : EventArgs
{
    public int IndexOfLast { get; }
    public int ValueOfLast { get; }

    public SortingStepCompleteEventArgs(int indexOfLast, int valueOfLast)
    {
        IndexOfLast = indexOfLast;
        ValueOfLast = valueOfLast;
    }
}