using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExitZoneController : MonoBehaviour
{
    [SerializeField] int sceneIndex = 1;
    void OnTriggerEnter2D(Collider2D collider2DInfo)
    {
        if (collider2DInfo.gameObject.name == "Player")
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }    
}
