using System;
using System.Linq;

namespace AdventOfCode2021;

public class Day05 : BaseDay
{
    public override string GetPart1()
    {
        var lines = GetInputFromFile().Split(Environment.NewLine)
            .Select(ParseLine)
            .Where(_ => _.start.X == _.end.X || _.start.Y == _.end.Y)
            .Select(_ => new Line(_.start, _.end))
            .ToList();

        var map = new Dictionary<Point, int>();
        foreach(var line in lines)
        {
            foreach(var point in line.Contents())
            {
                if (!map.ContainsKey(point)) map[point] = 0;
                map[point]++;
            }
        }

        //Print(map);

        return $"{map.Count(_ => _.Value >= 2)}";
    }

    public override string GetPart2()
    {
        var lines = GetInputFromFile().Split(Environment.NewLine)
            .Select(ParseLine)
            .Select(_ => new Line(_.start, _.end))
            .ToList();

        var map = new Dictionary<Point, int>();
        foreach (var line in lines)
        {
            foreach (var point in line.Contents())
            {
                if (!map.ContainsKey(point)) map[point] = 0;
                map[point]++;
            }
        }

        //Print(map);

        return $"{map.Count(_ => _.Value >= 2)}";
    }

    private void Print(Dictionary<Point, int> map)
    {
        for(int y = 0; y <= 9; y++)
        {
            for(int x = 0; x <= 9; x++)
            {
                var point = new Point(x, y);
                if(map.ContainsKey(point))
                {
                    Console.Write(map[point]);
                }
                else
                {
                    Console.Write('.');
                }
            }

            Console.Write(Environment.NewLine);
        }
    }

    private (Point start, Point end) ParseLine(string inputLine)
    {
        var parts = inputLine.Split(" -> ");
        var parsed = parts.Select(_ => _.Split(',').Select(int.Parse).ToArray()).ToArray();
        var start = new Point(parsed[0][0], parsed[0][1]);
        var end = new Point(parsed[1][0], parsed[1][1]);

        return (start, end);
    }
}

