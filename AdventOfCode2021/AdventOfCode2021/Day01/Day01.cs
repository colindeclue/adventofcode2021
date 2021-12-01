using System;
namespace AdventOfCode2021.Day01;

public class Day01 : BaseDay
{
    public override string GetPart1()
    {
        var intArray = GetInputFromFile().Split(Environment.NewLine).Select(int.Parse).ToArray();
        var count = 0;
        for(int i = 1; i < intArray.Length; i++)
        {
            if(intArray[i] > intArray[i - 1])
            {
                count++;
            }
        }

        return count.ToString();
    }

    public override string GetPart2()
    {
        var intArray = GetInputFromFile().Split(Environment.NewLine).Select(int.Parse).ToArray();
        var previous = intArray[0] + intArray[1] + intArray[2];
        var count = 0;
        for(int i = 3; i < intArray.Length; i++)
        {
            var current = intArray[i] + intArray[i - 1] + intArray[i - 2];
            if (current > previous)
            {
                count++;
            }

            previous = current;
        }

        return count.ToString();
    }
}

