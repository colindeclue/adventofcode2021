using System;
namespace AdventOfCode2021;

public class Day04 : BaseDay
{
    public override string GetPart1()
    {
        var input = GetInputFromFile().Split(Environment.NewLine).ToArray();
        var numbersCalled = input[0].Split(',').Select(int.Parse).ToArray();
        var allBoards = input.Skip(1).Where(_ => _.Length > 0).ToArray();
        var chunked = allBoards.Chunk(5).ToArray();
        var boards = new List<BingoBoard>();
        foreach(var chunk in chunked)
        {
            var split = chunk.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries).Where(s => s.Length > 0));
            var numbers = split.Select(s => s.Select(int.Parse).ToArray()).ToArray();
            boards.Add(new BingoBoard(numbers));
        }

        foreach (var number in numbersCalled)
        {
            foreach(var board in boards)
            {
                if (board.CallNumber(number))
                {
                    return (board.GetUnmarkedSum() * number).ToString();
                }
            }
        }

        return "fart";
    }

    public override string GetPart2()
    {
        var input = GetInputFromFile().Split(Environment.NewLine).ToArray();
        var numbersCalled = input[0].Split(',').Select(int.Parse).ToArray();
        var allBoards = input.Skip(1).Where(_ => _.Length > 0).ToArray();
        var chunked = allBoards.Chunk(5).ToArray();
        var boards = new List<BingoBoard>();
        foreach (var chunk in chunked)
        {
            var split = chunk.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries).Where(s => s.Length > 0));
            var numbers = split.Select(s => s.Select(int.Parse).ToArray()).ToArray();
            boards.Add(new BingoBoard(numbers));
        }

        var itCounts = false;
        foreach (var number in numbersCalled)
        {
            var toCheck = boards.Where(b => !b.HasWon);
            if (toCheck.Count() == 1) itCounts = true;
            foreach (var board in toCheck)
            {
                if (board.CallNumber(number) && itCounts)
                {
                    return (board.GetUnmarkedSum() * number).ToString();
                }
            }
        }

        return "fart";
    }
}

