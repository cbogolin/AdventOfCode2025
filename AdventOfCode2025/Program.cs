// See https://aka.ms/new-console-template for more information

using AdventOfCode2025;
using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;

const AdventDay currentDay = AdventDay.Day2;

Console.WriteLine("Hello, World!");
Console.WriteLine($"Day {currentDay}:");
DayBase day = null;

switch (currentDay)
{
    case AdventDay.Day1:
    {
        day = new Day1();
        day.Run();
        break;
    }
    case AdventDay.Day2:
        day = new Day2();
        day.Run();
        break;
    default:
        break;
}


internal enum AdventDay
{
    Day1,
    Day2,
    Day3,
    Day4,
    Day5,
    Day6,
    Day7,
    Day8,
    Day9,
    Day10,
    Day11,
    Day12,
    Day13,
    Day14,
    Day15,
    Day16,
    Day17,
    Day18,
    Day19,
    Day20,
    Day21,
    Day22,
    Day23,
    Day24,
    Day25,
    Day26,
    Day27,
    Day28,
    Day29,
    Day30,
    Day31
}