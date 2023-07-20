using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Mace collides with a Ghost.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class GhostMaceCollision : Simulation.Event<GhostMaceCollision>
    {
        public MaceAttackController Mace;
        public GhostController Ghost;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            Ghost.Death();
        }
    }
}