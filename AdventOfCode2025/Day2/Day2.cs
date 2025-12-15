namespace AdventOfCode2025.Day2;

public class Day2 : DayBase
{
    public override void Run()
    {
        var instructions = File.ReadLines("Day2/day2input.txt");
        var ranges = instructions.First().Split(',');
        var rangesSplit = ranges.Select(s => s.Split("-").Select(long.Parse).ToArray());
        foreach (var range in rangesSplit)
        {
            Console.WriteLine($"Answer is: \n{range[0]} - {range[1]}");
        }
        
    }
}