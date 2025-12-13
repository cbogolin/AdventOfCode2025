using System.Diagnostics;

namespace AdventOfCode2025.Day1;

public class Day1 : DayBase
{
    const int startNumber = 50;
    public override void Run()
    {
        var instructions = File.ReadLines("Day1/day1input.txt");
        int currentNumber = startNumber;
        int counter = 0;
        foreach (var instruction in instructions)
        {
            var direction = instruction[0];
            var distance = int.Parse(instruction[1..]);
            var timesPassedZero = 0;
            var startingNumber = currentNumber;
            var startingNumberZero = startingNumber == 0 ? 1 : 0;
            
            Console.WriteLine($"\nstarting number: {startingNumber}");
            Console.WriteLine($"instruction: {instruction}");
            
            currentNumber += 
                direction switch
                {
                    'R' => distance,
                    'L' => -distance,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction))
                };
            
            Console.WriteLine($"number after turning: {currentNumber}");
            var numberAfterTurning = currentNumber;
            var landsOnZero = currentNumber == 0 ? 1 : 0;
            //timesPassedZero += Math.Abs(currentNumber / 100);
            //currentNumber %= 100;
            while (currentNumber < 0)
            {
                currentNumber += 100;
                timesPassedZero ++;
            }

            while (currentNumber > 99)
            {
                currentNumber -= 100;
                timesPassedZero ++;
            }
            var thisRoundCounts = timesPassedZero + landsOnZero - startingNumberZero;
            
            Console.WriteLine($"timesPassedZero: {timesPassedZero}");
            Console.WriteLine($"landsOnZero: {landsOnZero}");
            Console.WriteLine($"startingNumberZero: {startingNumberZero}");
            Console.WriteLine($"new starting Number after corrections: {currentNumber}");

            Console.WriteLine($"total counts for this round: {thisRoundCounts}\n");
            counter += thisRoundCounts;
        }
        
        Console.WriteLine($"Answer is: {counter}");
    }
}