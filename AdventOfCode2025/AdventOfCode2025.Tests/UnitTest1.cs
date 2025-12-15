namespace AdventOfCode2025.Tests;
using AdventOfCode2025;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    [TestCase(50, -60, 90, 1, TestName = "spin negative")]
    [TestCase(50, 60, 10, 1, TestName = "spin positive")]
    [TestCase(50, -150, 0, 2, TestName = "spin negative end zero")]
    [TestCase(50, 150, 0, 2, TestName = "spin positive end zero")]
    [TestCase(50, -1000, 50, 10, TestName = "big spin negative")]
    [TestCase(50, 1000, 50, 10, TestName = "big spin positive")]
    [TestCase(0, -350, 50, 3, TestName = "zero start negative turn")]
    [TestCase(0, 350, 50, 3, TestName = "zero start positive turn")]
    [TestCase(0, 500, 0, 5, TestName = "zero start zero end positive turn")]
    [TestCase(0, -500, 0, 5, TestName = "zero start zero end negative turn")]
    public void RotationTest(int startNumber, int parsedInstruction, int expectedEndNumber, int expectedCounter)
    {
        int counter = 0;
        int endNumber = Day1.Day1.RotateDial(startNumber, parsedInstruction, ref counter);
        Assert.That(counter, Is.EqualTo(expectedCounter));
        Assert.That(endNumber, Is.EqualTo(expectedEndNumber));
    }
}