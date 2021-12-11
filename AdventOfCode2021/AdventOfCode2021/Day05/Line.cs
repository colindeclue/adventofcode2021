using System;
namespace AdventOfCode2021;

public record Line
{
    public Point Start { get; }
    public Point End { get; }

    private readonly Direction _direction;

    public Line(Point first, Point second)
    {
        if(first.X == second.X)
        {
            _direction = Direction.Vertical;
        }
        else if(first.Y == second.Y)
        {
            _direction = Direction.Horizontal;
        }
        else
        {
            _direction = Direction.Diagonal;
        }

        Start = first;
        End = second;
    }

    public IEnumerable<Point> Contents()
    {
        if(_direction == Direction.Vertical)
        {
            for(int y = Math.Min(Start.Y, End.Y); y <= Math.Max(Start.Y, End.Y); y++)
            {
                yield return new Point(Start.X, y);
            }
        }
        else if(_direction == Direction.Horizontal)
        {
            for(int x = Math.Min(Start.X, End.X); x <= Math.Max(Start.X, End.X); x++)
            {
                yield return new Point(x, Start.Y);
            }
        }
        else
        {
            var xValues = GetXValues();
            var yValues = GetYValues();
            for(int i = 0; i < xValues.Length; i++)
            {
                yield return new Point(xValues[i], yValues[i]);
            }
        }
    }

    private int[] GetXValues()
    {
        var output = new List<int>();
        if(Start.X > End.X)
        {
            for(int i = Start.X; i >= End.X; i--)
            {
                output.Add(i);
            }
        }
        else
        {
            for(int i = Start.X; i <= End.X; i++)
            {
                output.Add(i);
            }
        }

        return output.ToArray();
    }

    private int[] GetYValues()
    {
        var output = new List<int>();
        if (Start.Y > End.Y)
        {
            for (int i = Start.Y; i >= End.Y; i--)
            {
                output.Add(i);
            }
        }
        else
        {
            for (int i = Start.Y; i <= End.Y; i++)
            {
                output.Add(i);
            }
        }

        return output.ToArray();
    }

    private enum Direction
    {
        Horizontal,
        Vertical,
        Diagonal
    }
}

