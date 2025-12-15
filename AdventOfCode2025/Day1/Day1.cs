using System.Diagnostics;

namespace AdventOfCode2025.Day1;

public class Day1 : DayBase
{
    private const int StartNumber = 50;
    public override void Run()
    {
        var instructions = File.ReadLines("Day1/day1input.txt");
        var currentNumber = StartNumber;
        var counter = 0;
        foreach (var instruction in instructions)
        {
            var parsedInstruction = ParseInstruction(instruction);
            currentNumber = RotateDial(currentNumber, parsedInstruction, ref counter);
        }
        
        Console.WriteLine($"Answer is: {counter}");
    }
    
    private static int ParseInstruction(string instruction)
    {
        var direction = instruction[0];
        var distance = int.Parse(instruction[1..]);
        
        var parsedInstruction = 
            direction switch
            {
                'R' => distance,
                'L' => -distance,
                _ => throw new ArgumentOutOfRangeException(nameof(direction))
            };
        return parsedInstruction;
    }
    
    public static int RotateDial(int currentNumber, int parsedInstruction, ref int counter)
    {
        var timesPointerAtZero = 0;

        while (parsedInstruction != 0)
        {
            switch (parsedInstruction)
            {
                case > 0:
                    currentNumber++;
                    if (currentNumber >= 100) currentNumber -= 100;
                    if (currentNumber == 0) timesPointerAtZero++;
                    parsedInstruction--;
                    break;
                case < 0:
                    currentNumber--;
                    if (currentNumber == 0) timesPointerAtZero++;
                    if (currentNumber < 0) currentNumber += 100;
                    parsedInstruction++;
                    break;
            }
        }

        currentNumber %= 100;
        if (currentNumber < 0) currentNumber += 100;
            
        counter += timesPointerAtZero;
        
        return currentNumber;
    }
}