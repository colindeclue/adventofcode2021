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

    /// <summary>
    /// Break a list of items into chunks of a specific size
    /// </summary>
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
    {
        while (source.Any())
        {
            yield return source.Take(chunksize);
            source = source.Skip(chunksize);
        }
    }

    public static T[] Rotate<T>(this T[] source)
    {
        for(int i = 1; i < source.Length; i++)
        {
            source[i - 1] = source[i];
        }

        return source;
    }
}

