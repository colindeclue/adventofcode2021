using System;
namespace AdventOfCode2021;

public class Day08 : BaseDay
{
    public override string GetPart1()
    {
        var uniqueLengths = new[] { 2, 4, 3, 7 };
        var outputs = GetInputFromFile().Split(Environment.NewLine).Select(l => l.Split('|')).Select(l => l[1]).SelectMany(l => l.Split(' ')).Where(s => uniqueLengths.Contains(s.Length));

        return $"{outputs.Count()}";
    }

    public override string GetPart2()
    {
        throw new NotImplementedException();
    }
}

