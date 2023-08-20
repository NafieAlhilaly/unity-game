using NUnit.Framework;
using Platformer.Mechanics.Fight;

public class PuzzleTest
{
    CalculationPuzzle p = new();
    int[] options = { 1, 2, 3, 4, 5 };

    [Test]
    public void TestDivisibleBy()
    {
        // Arrange
        int DivisibleBy1 = 1;
        int DivisibleBy2 = 2;
        int DivisibleBy3 = 3;
        int DivisibleBy4 = 4;
        int DivisibleBy5 = 5;

        // Act
        int result1 = p.DivisibleBy(DivisibleBy1, options.Length);
        int result2 = p.DivisibleBy(DivisibleBy2, options.Length);
        int result3 = p.DivisibleBy(DivisibleBy3, options.Length);
        int result4 = p.DivisibleBy(DivisibleBy4, options.Length);
        int result5 = p.DivisibleBy(DivisibleBy5, options.Length);

        // Assert
        Assert.IsTrue(result1 % DivisibleBy1 == 0);
        Assert.IsTrue(result2 % DivisibleBy2 == 0);
        Assert.IsTrue(result3 % DivisibleBy3 == 0);
        Assert.IsTrue(result4 % DivisibleBy4 == 0);
        Assert.IsTrue(result5 % DivisibleBy5 == 0);
    }
}
