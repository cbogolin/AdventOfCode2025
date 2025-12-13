// See https://aka.ms/new-console-template for more information

using AdventOfCode2025.Day1;

const AdventDay currentDay = AdventDay.Day1;

Console.WriteLine("Hello, World!");
Console.WriteLine($"Day {currentDay}:");

switch (currentDay)
{
    case AdventDay.Day1:
    {
        var day = new Day1();
        day.Run();
        break;
    }
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