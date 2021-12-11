using System;

namespace AdventOfCode2021;

public class Day07 : BaseDay
{
    public override string GetPart1()
    {
        var positions = GetInputFromFile().Split(',').Select(int.Parse);
        var min = positions.Min();
        var max = positions.Max();
        var minFuel = int.MaxValue;
        for(int i = min; i < max; i++)
        {
            var fuelCost = positions.Sum(p => Math.Abs(p - i));
            if(fuelCost < minFuel)
            {
                minFuel = fuelCost;
            }
        }

        return $"{minFuel}";
    }

    public override string GetPart2()
    {
        var positions = GetInputFromFile().Split(',').Select(int.Parse);
        var min = positions.Min();
        var max = positions.Max();
        var minFuel = int.MaxValue;
        for (int i = min; i < max; i++)
        {
            var fuelCost = positions.Sum(p => Sum(Math.Abs(p - i)));
            if (fuelCost < minFuel)
            {
                minFuel = fuelCost;
            }
        }

        return $"{minFuel}";
    }

    private int Sum(int n)
    {
        return n * (n + 1) / 2;
    }
}

