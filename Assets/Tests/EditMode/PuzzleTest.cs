using NUnit.Framework;
using Platformer.Mechanics.Fight;

public class PuzzleTest
{
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
        int result1 = CalculationPuzzle.DivisibleBy(DivisibleBy1, options.Length);
        int result2 = CalculationPuzzle.DivisibleBy(DivisibleBy2, options.Length);
        int result3 = CalculationPuzzle.DivisibleBy(DivisibleBy3, options.Length);
        int result4 = CalculationPuzzle.DivisibleBy(DivisibleBy4, options.Length);
        int result5 = CalculationPuzzle.DivisibleBy(DivisibleBy5, options.Length);

        // Assert
        Assert.IsTrue(result1 % DivisibleBy1 == 0);
        Assert.IsTrue(result2 % DivisibleBy2 == 0);
        Assert.IsTrue(result3 % DivisibleBy3 == 0);
        Assert.IsTrue(result4 % DivisibleBy4 == 0);
        Assert.IsTrue(result5 % DivisibleBy5 == 0);
    }
    [Test]
    public void TestIndivisible()
    {
        // Arrange
        int n1 = 1;
        int n2 = 2;
        int n3 = 3;
        int n4 = 4;
        int n5 = 5;

        // Act
        bool result1 = CalculationPuzzle.Indivisible(n1);
        bool result2 = CalculationPuzzle.Indivisible(n2);
        bool result3 = CalculationPuzzle.Indivisible(n3);
        bool result4 = CalculationPuzzle.Indivisible(n4);
        bool result5 = CalculationPuzzle.Indivisible(n5);

        // Assert
        Assert.IsTrue(result1);
        Assert.IsFalse(result2);
        Assert.IsTrue(result3);
        Assert.IsFalse(result4);
        Assert.IsTrue(result5);
    }
}
