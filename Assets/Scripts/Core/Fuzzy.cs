using UnityEngine;

namespace Platformer.Core
{
    /// <summary>
    /// Fuzzy provides methods for using values +- an amount of random deviation, or fuzz.
    /// </summary>
    static class Fuzzy
    {
        public static float ValueBetween(float min, float max)
        {
            return Random.Range(min, max);
        }
    }
}