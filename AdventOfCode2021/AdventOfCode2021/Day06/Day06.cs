using System;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021;

public class Day06 : BaseDay
{
    public override string GetPart1()
    {
        var fish = GetInputFromFile().Split(',').Select(int.Parse).Select(_ => new LanternFish(_)).ToList();
        var total = fish.Count;
        for(int i = 0; i < 80; i++)
        {
            var toAdd = new List<LanternFish>();
            foreach (var f in fish)
            {
                if(f.Tick())
                {
                    toAdd.Add(new LanternFish());
                }
            }

            fish.AddRange(toAdd);
            //Console.WriteLine($"{i}: {fish.Count}.");
        }

        return $"{fish.Count}";
    }

    public override string GetPart2()
    {
        var input = GetInputFromFile().Split(',').Select(int.Parse).ToList();
        var fish = new long[9];
        for(int i = 0; i < 9; i++)
        {
            fish[i] = input.Count(_ => _ == i);
        }
        for(int i = 0; i < 256; i++)
        {
            var count = fish[0];
            fish = fish.Rotate();
            fish[6] += count;
            fish[8] = count;
        }

        return $"{fish.Sum()}";
    }
}

