using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    public class SceneExitZoneController : MonoBehaviour
    {
        [SerializeField] readonly int sceneIndex = 1;
        void OnTriggerEnter2D(Collider2D collider2DInfo)
        {
            if (collider2DInfo.gameObject.name == "Player")
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}
