namespace Platformer.Mechanics.Fight
{
    public static class CalculationPuzzle
    {
        public static int DivisibleBy(int number, int range)
        {
            for (int i = 1; i <= range; i++)
            {
                if (i % number == 0)
                {
                    return i;
                }
            }
            return 0;
        }
        public static bool Indivisible(int number)
        {
            return number % 2 != 0;
        }
    }
}