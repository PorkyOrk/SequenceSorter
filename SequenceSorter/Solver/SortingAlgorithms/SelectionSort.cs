namespace SequenceSorter.Solver.SortingAlgorithms;

public class SelectionSort : ISortingAlgorithm
{
    // Enumerate through the array, starting from first element finding lowest value and its index.
    // Then swap it with the first element.
    // Then repeat the process starting from second element and then with third etc...

    public int IndexOfLast { get; private set; }
    public int ValueOfLast { get; private set; }
    
    public bool IsSolved { get; private set; }

    private int[] _currentSequence = null!;
    private int _currentIndex;
    private bool _isInitialized; 
    
    public void Initialize(int[] inputSequence)
    {
        _currentSequence = inputSequence ?? throw new ArgumentNullException(nameof(inputSequence));
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
            lowestValue = _currentSequence[0];
        }

        if (_currentIndex >= _currentSequence.Length -1)
        {
            IsSolved = true;
            return _currentSequence;
        }
        
        for (var i = _currentIndex; i < _currentSequence.Length; i++)
        {
            if (_currentSequence[i] < lowestValue)
            {
                lowestValue = _currentSequence[i];
                lowestIndex = i;
            }

            if (_currentIndex == _currentSequence.Length - 1)
            {
                return _currentSequence;
            }
        }
        
        IndexOfLast = _currentIndex;
        ValueOfLast = _currentSequence[_currentIndex];

        var currentValue = _currentSequence[_currentIndex];
        _currentSequence[_currentIndex] = lowestValue;
        _currentSequence[lowestIndex] = currentValue;
        
        _currentIndex++;

        return _currentSequence;
    }
}
