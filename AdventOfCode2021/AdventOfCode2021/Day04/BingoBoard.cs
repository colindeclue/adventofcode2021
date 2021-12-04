using System;
namespace AdventOfCode2021;

public class BingoBoard
{
    private readonly BingoItem[][] _bingoItems = new BingoItem[][]
    {
         new BingoItem[5],
         new BingoItem[5],
         new BingoItem[5],
         new BingoItem[5],
         new BingoItem[5]
    };

    public BingoBoard(int[][] numbers)
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                _bingoItems[i][j] = new BingoItem
                {
                    Marked = false,
                    Number = numbers[i][j]
                };
            }
        }
    }

    public bool HasWon { get; private set; } = false;

    public bool CallNumber(int number)
    {
        // set the number
        for(int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if(_bingoItems[i][j].Number == number)
                {
                    _bingoItems[i][j].Marked = true;
                }
            }
        }

        // Check if winner
        for(int i = 0; i < 5; i++)
        {
            if (CheckColumn(i))
            {
                HasWon = true;
                return true;
            }
            if (CheckRow(i))
            {
                HasWon = true;
                return true;
            }
        }

        return false;
    }

    public int GetUnmarkedSum()
    {
        var unmarked = _bingoItems.SelectMany(b => b.Where(_ => !_.Marked));

        return unmarked.Sum(_ => _.Number);
    }

    private bool CheckColumn(int index)
    {
        for(int j = 0; j < 5; j++)
        {
            if (!_bingoItems[index][j].Marked) return false;
        }

        return true;
    }

    private bool CheckRow(int index)
    {
        for(int i = 0; i < 5; i++)
        {
            if (!_bingoItems[i][index].Marked) return false;
        }

        return true;
    }
}

public record BingoItem
{
    public int Number { get; init; }
    public bool Marked { get; set; }
}

