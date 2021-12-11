using System;
namespace AdventOfCode2021;

public class LanternFish
{
    public int Timer { get; internal set; }

    public LanternFish()
    {
        Timer = 8;
    }

    public LanternFish(int timer)
    {
        Timer = timer;
    }

    public bool Tick()
    {
        Timer--;
        if(Timer == -1)
        {
            Timer = 6;
            return true;
        }

        return false;
    }
}

