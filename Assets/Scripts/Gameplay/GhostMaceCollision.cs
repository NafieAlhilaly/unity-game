using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a Mace collides with a Ghost.
    /// </summary>
    public class GhostMaceCollision : Simulation.Event<GhostMaceCollision>
    {
        public MaceAttackController Mace;
        public GhostController Ghost;

        public override void Execute()
        {
            Ghost.Death();
        }
    }
}