using SequenceSorter.Solver;

namespace SequenceSorter;

public class ValuesSequenceVisualizerForm : Form
{
    private readonly SequenceSolver _solver;
    private int _indexOfLast;
    private int _valueOfLast;
    
    public ValuesSequenceVisualizerForm(SequenceSolver solver)
    {
        _solver = solver;
        ResizeRedraw = true;
        Text = "Values Visualized";
        _solver.SortingStepCompleted += RepaintValues;
    }

    private void RepaintValues(object? sender, SortingStepCompleteEventArgs args)
    {
        _indexOfLast = args.IndexOfLast;
        _valueOfLast = args.ValueOfLast;
        Refresh();
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        var valuesToVisualize = _solver.SequenceValues;
        
        ClientSize = new Size(valuesToVisualize.Length, valuesToVisualize.Length);
        var blackPen = new Pen(ForeColor);
        var redPen = new Pen(Color.Red);
        const int spacing = 5;

        for (var i = 0; i < valuesToVisualize.Length; i++)
        {
            var x = i + spacing;
            e.Graphics.DrawLine(
                i == _indexOfLast 
                    ? redPen
                    : blackPen, 
                x, valuesToVisualize[i], x, ClientSize.Height-1
            );
        }
    }
}