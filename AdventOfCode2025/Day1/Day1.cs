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
            Console.WriteLine($"starting iteration...");
            var direction = instruction[0];
            Console.WriteLine($"Direction is: {direction}");
            
            var distance = int.Parse(instruction[1..]);
            Console.WriteLine($"distance is: {distance}");
            
            currentNumber += direction switch { 'R' => distance, 'L' => -distance };
            Console.WriteLine($"currentNumber is: {currentNumber}");

            currentNumber %= 100 ;
            currentNumber = currentNumber < 0 ? currentNumber + 100 : currentNumber;
            Console.WriteLine($"currentNumber is: {currentNumber}");
            
            counter = currentNumber == 0 ? counter + 1 : counter;
            Console.WriteLine($"counter is: {counter}");
            
            Console.WriteLine($"Ending iteration...");
        }
        
        Console.WriteLine($"Answer is: {counter}");
    }
}