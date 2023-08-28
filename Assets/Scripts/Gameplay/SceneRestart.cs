using Platformer.Core;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    public class SceneRestart : Simulation.Event<SceneRestart>
    {
        public override void Execute()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}