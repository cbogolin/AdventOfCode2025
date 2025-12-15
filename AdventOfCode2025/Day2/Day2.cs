namespace AdventOfCode2025.Day2;

public class Day2 : DayBase
{
    public override void Run()
    {
        var instructions = File.ReadLines("Day2/day2input.txt");
        var ranges = instructions.First().Split(',');
        var rangesSplit = ranges.Select(s => s.Split("-").Select(long.Parse).ToArray());

        long totals = 0;
        foreach (var range in rangesSplit)
        {
            var startOfRange = range.First();
            var endOfRange = range.Last();
            int startDigitCount = Math.Abs(startOfRange).ToString().Length;
            int endDigitCount = Math.Abs(endOfRange).ToString().Length;
            Console.WriteLine($"startDigitCount: {startDigitCount}");
            Console.WriteLine($"endDigitCount: {endDigitCount}");
            Console.WriteLine($"RANGE is: {startOfRange} - {endOfRange}\n");

            if (startDigitCount % 2 == 1 && endDigitCount % 2 == 1 && startDigitCount == endDigitCount)
            {
                continue;
            }
            for (var i = startOfRange; i <= endOfRange; i++)
            {
                var iDigitCount = Math.Abs(i).ToString().Length;
                if (iDigitCount % 2 == 1)
                {
                    continue;
                }

                // ReSharper disable once PossibleLossOfFraction
                var splitNum = (long)Math.Pow(10, iDigitCount / 2);
                
                var firstHalf = i / splitNum;
                var secondHalf = i % splitNum;
                if (firstHalf == secondHalf)
                {
                    totals += i;
                }
            }
            
        }
        
        Console.WriteLine($"sum of digits: {totals}");
    }
}