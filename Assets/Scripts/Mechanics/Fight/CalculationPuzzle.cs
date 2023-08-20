namespace Platformer.Mechanics.Fight
{
    public class CalculationPuzzle
    {
        public int DivisibleBy(int number, int range)
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
    }
}