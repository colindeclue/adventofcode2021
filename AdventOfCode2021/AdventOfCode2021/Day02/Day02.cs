using System;
namespace AdventOfCode2021.Day02;

public class Day02 : BaseDay
{
    public override string GetPart1()
    {
        var startX = 0;
        var startY = 0;
        var commands = GetInputFromFile().Split(Environment.NewLine).Select(line => line.Split(" ")).ToArray();
        foreach (var command in commands)
        {
            var distance = int.Parse(command[1]);
            var _ = command[0] switch
            {
                "forward" => startX += distance,
                "down" => startY += distance,
                "up" => startY -= distance,
                _ => throw new NotImplementedException()
            };
        }

        return (startX * startY).ToString();
    }

    public override string GetPart2()
    {
        var startX = 0;
        var startY = 0;
        var startAim = 0;
        var commands = GetInputFromFile().Split(Environment.NewLine).Select(line => line.Split(" ")).ToArray();
        foreach (var command in commands)
        {
            var distance = int.Parse(command[1]);
            switch (command[0])
            {
                case "forward":
                    startX += distance;
                    startY += startAim * distance;
                    break;
                case "down":
                    startAim += distance;
                    break;
                case "up":
                    startAim -= distance;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        return (startX * startY).ToString();
    }
}

