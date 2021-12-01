using System;
namespace AdventOfCode2021;

public abstract class BaseDay
{
    public abstract string GetPart1();
    public abstract string GetPart2();

    protected string GetInputFromFile() =>
        File.ReadAllText($"{this.GetType().Name}/{this.GetType().Name}Input.txt");
}

