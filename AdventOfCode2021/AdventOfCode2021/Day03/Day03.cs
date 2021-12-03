using System;
using AdventOfCode2021.Extensions;
namespace AdventOfCode2021;

public class Day03 : BaseDay
{
    public override string GetPart1()
    {
        var input = GetInputFromFile().Split(Environment.NewLine).Select(s => s.Select(c => c - '0').ToArray()).ToArray();
        var transposed = input.TransposeRowsAndColumns();
        var gammaArray = new int[transposed.Length];
        var epsilonArray = new int[transposed.Length];
        for (int i = 0; i < transposed.Length; i++)
        {
            gammaArray[i] = transposed[i].GroupBy(t => t).OrderByDescending(t => t.Count()).First().Key;
            epsilonArray[i] = gammaArray[i] == 1 ? 0 : 1;
        }

        var gammaNumber = Convert.ToInt32(string.Join(string.Empty, gammaArray), 2);
        var epsilonNumber = Convert.ToInt32(string.Join(string.Empty, epsilonArray), 2);

        return (gammaNumber * epsilonNumber).ToString();
    }

    public override string GetPart2()
    {
        var input = GetInputFromFile().Split(Environment.NewLine).Select(s => s.Select(c => c - '0').ToArray()).ToArray();
        var index = 0;
        var oxygenList = input.Select(c => c.ToArray()).ToArray();
        var co2List = input.Select(c => c.ToArray()).ToArray();
        while (true)
        {
            if(oxygenList.Length > 1)
            {
                oxygenList = KeepMostCommon(oxygenList, index);
            }
            if(co2List.Length > 1)
            {
                co2List = KeepLeastCommon(co2List, index);
            }

            if (oxygenList.Length == 1 && co2List.Length == 1) break;
            index++;
        }

        var oxygenRating = Convert.ToInt32(string.Join(string.Empty, oxygenList[0]), 2);
        var co2Rating = Convert.ToInt32(string.Join(string.Empty, co2List[0]), 2);

        return (oxygenRating * co2Rating).ToString();
    }

    private static int[][] KeepMostCommon(int[][] current, int index)
    {
        var toConsider = current.Select(c => c[index]).ToArray();
        var toKeep = toConsider.GroupBy(t => t).OrderByDescending(t => t.Count()).ThenByDescending(t => t.Key).First().Key;

        return current.Where(c => c[index] == toKeep).ToArray();
    }

    private static int[][] KeepLeastCommon(int[][] current, int index)
    {
        var toConsider = current.Select(c => c[index]).ToArray();
        var toKeep = toConsider.GroupBy(t => t).OrderBy(t => t.Count()).ThenBy(t => t.Key).First().Key;

        return current.Where(c => c[index] == toKeep).ToArray();
    }
}