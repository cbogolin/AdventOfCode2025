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
        var timesPassedOrEndOnZero = 0;

        while (parsedInstruction != 0)
        {
            switch (parsedInstruction)
            {
                case > 0:
                    currentNumber++;
                    if (currentNumber >= 100) currentNumber -= 100;
                    if (currentNumber == 0) timesPassedOrEndOnZero++;
                    parsedInstruction--;
                    break;
                case < 0:
                    currentNumber--;
                    if (currentNumber == 0) timesPassedOrEndOnZero++;
                    if (currentNumber < 0) currentNumber += 100;
                    parsedInstruction++;
                    break;
            }
        }

        currentNumber %= 100;
        if (currentNumber < 0) currentNumber += 100;
            
        counter += timesPassedOrEndOnZero;
        
        return currentNumber;
    }

    public static int OldTwoRotateDial(int currentNumber, int parsedInstruction, ref int counter)
    {
        var timesPassedZero = 0;

        while (parsedInstruction != 0)
        {
            if (parsedInstruction % 100 != 0)
            {
                currentNumber += parsedInstruction % 100;
                parsedInstruction -= parsedInstruction % 100;
            }
            
            if (parsedInstruction / 100 > 0)
            {
                timesPassedZero += parsedInstruction / 100;
                parsedInstruction -= parsedInstruction;
            }
            else if (parsedInstruction / 100 < 0)
            {
                timesPassedZero += Math.Abs(parsedInstruction / 100);
                parsedInstruction -= parsedInstruction;
            }
        }

        if (currentNumber < 0)
        {
            currentNumber += 100;
            timesPassedZero++;
        }
        else if (currentNumber >= 100)
        {
            currentNumber -= 100;
            timesPassedZero++;
        }
        else if (currentNumber == 0)
        {
            timesPassedZero++;
        }
            
        counter += timesPassedZero;
        return currentNumber;
    }
    public static int OldRotateDial(int currentNumber, int parsedInstruction, ref int counter)
    {
        var timesPassedZero = 0;
        var startingNumber = currentNumber;
            
        Console.WriteLine($"\nstarting number: {startingNumber}");
        Console.WriteLine($"instruction: {parsedInstruction}");

        currentNumber += parsedInstruction;
        Console.WriteLine($"number after turning: {currentNumber}");
        
        timesPassedZero += Math.Abs(currentNumber / 100);
        Console.WriteLine($"timesPassedZero = {currentNumber} / 100 = {timesPassedZero}");
        timesPassedZero += currentNumber < 0 ? 1 : 0;
        Console.WriteLine($"timesPassedZero += {currentNumber} < 0 ? {timesPassedZero}");
        currentNumber %= 100;
        Console.WriteLine($"currentNumber = {currentNumber} %= 100");
        //var isStartingNumberZeroAndGoesNegative = startingNumber == 0 && currentNumber < 0;
        //Console.WriteLine($"isStartingNumberZeroAndGoesNegative: {isStartingNumberZeroAndGoesNegative}");
        while (currentNumber < 0)
        {
            Console.WriteLine($"current number {currentNumber} < 0");
            currentNumber += 100;
            Console.WriteLine($"+ 100 = {currentNumber}");
            //timesPassedZero ++;
            //Console.WriteLine($"timesPassedZero = {timesPassedZero}");
        }

        while (currentNumber > 99)
        {
            Console.WriteLine($"current number {currentNumber} > 99");
            currentNumber -= 100;
            Console.WriteLine($"- 100 = {currentNumber}");
            timesPassedZero ++;
            Console.WriteLine($"timesPassedZero = {timesPassedZero}");
        }
        
        //var landsOnZero = currentNumber == 0 ? 1 : 0;
        var thisRoundCounts = timesPassedZero;// - (isStartingNumberZeroAndGoesNegative? 1 : 0);// + landsOnZero;//;
            
        Console.WriteLine($"timesPassedZero: {timesPassedZero}");
        //Console.WriteLine($"landsOnZero: {landsOnZero}");
        Console.WriteLine($"new starting Number after corrections: {currentNumber}");

        Console.WriteLine($"total counts for this round: {thisRoundCounts}\n");
        counter += thisRoundCounts;
        return currentNumber;
    }
}