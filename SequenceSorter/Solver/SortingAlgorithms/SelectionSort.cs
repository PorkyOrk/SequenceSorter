namespace SequenceSorter.Solver.SortingAlgorithms;

public class SelectionSort : ISortingAlgorithm
{
    // Enumerate through the array, starting from first element finding lowest value and its index.
    // Then swap it with the first element.
    // Then repeat the process starting from second element and then with third etc...

    public int IndexOfLast { get; private set; }
    public int ValueOfLast { get; private set; }
    public int[] CurrentSequence { get; set; } = null!;
    public bool IsSolved { get; private set; }

    private int _currentIndex;
    private bool _isInitialized; 

    
    public void Initialize(int[] inputSequence)
    {
        CurrentSequence = inputSequence ?? throw new ArgumentNullException(nameof(inputSequence));
        _isInitialized = true;
    }

    public int[] Step()
    {
        if (!_isInitialized)
        {
            throw new ArgumentException("Algorithm has not been initialized with inputValues. Run the Initialize method");
        }
        
        var lowestValue = int.MaxValue;
        int lowestIndex = 0;

        if (_currentIndex == 0)
        {
            lowestValue = CurrentSequence[0];
        }

        if (_currentIndex >= CurrentSequence.Length -1)
        {
            IsSolved = true;
            return CurrentSequence;
        }
        
        for (var i = _currentIndex; i < CurrentSequence.Length; i++)
        {
            if (CurrentSequence[i] < lowestValue)
            {
                lowestValue = CurrentSequence[i];
                lowestIndex = i;
            }

            if (_currentIndex == CurrentSequence.Length - 1)
            {
                return CurrentSequence;
            }
        }
        
        IndexOfLast = _currentIndex;
        ValueOfLast = CurrentSequence[_currentIndex];

        var currentValue = CurrentSequence[_currentIndex];
        CurrentSequence[_currentIndex] = lowestValue;
        CurrentSequence[lowestIndex] = currentValue;
        
        _currentIndex++;

        return CurrentSequence;
    }
}
