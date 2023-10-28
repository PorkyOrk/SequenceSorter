namespace SequenceSorter.Generator;

public class SequenceGenerator
{
    private readonly int _minValue;
    private readonly int _maxValue;
    private readonly Random _rng;

    public SequenceGenerator(int minValue, int maxValue) : this(minValue, maxValue, 1) { }
    
    public SequenceGenerator(int minValue, int maxValue, int seed)
    {
        if (_minValue > _maxValue)
        {
            throw new ArgumentException("min value cannot be higher than max value");
        }
        
        _minValue = minValue;
        _maxValue = maxValue;
        _rng = new Random(seed);
    }

    public int GenerateRandomValue()
    {
        return _rng.Next(_minValue, _maxValue);
    }

    public int[] RandomSequence(int count)
    {
        var result = new int[count];
        for (var i = 0; i < count; i++)
        {
            result[i] = _rng.Next(_minValue, _maxValue);
        }
        return result;
    }

    public int[] LinearSequence(int count)
    {
        var result = new int[count];

        for (var i = 0; i < count; i++)
        {
            result[i] = i + _minValue;
        }
        return result;
    }
    
    public int[] ShuffledSequence(int count)
    {
        var result  = LinearSequence(count);
        return ShuffleSequence(result);    
    }

    private int[] ShuffleSequence(int[] sequence)
    {
        for (var i = 0; i < sequence.Length;i++)
        {
            var a = sequence[i];
            var randomIdx = _rng.Next(0, sequence.Length);
            var b = sequence[randomIdx];
            
            sequence[i] = b;
            sequence[randomIdx] = a;
        }
        return sequence;
    }
    
}