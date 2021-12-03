using System;
namespace AdventOfCode2021.Extensions;

public static class ArrayExtensions
{
    public static T[][] TransposeRowsAndColumns<T>(this T[][] arr)
    {
        int rowCount = arr.Length;
        int columnCount = arr[0].Length;
        T[][] transposed = new T[columnCount][];
        if (rowCount == columnCount)
        {
            transposed = (T[][])arr.Clone();
            for (int i = 1; i < rowCount; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    T temp = transposed[i][j];
                    transposed[i][j] = transposed[j][i];
                    transposed[j][i] = temp;
                }
            }
        }
        else
        {
            for (int column = 0; column < columnCount; column++)
            {
                transposed[column] = new T[rowCount];
                for (int row = 0; row < rowCount; row++)
                {
                    transposed[column][row] = arr[row][column];
                }
            }
        }
        return transposed;
    }
}

