using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExitZoneController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2DInfo)
    {
        if (collider2DInfo.gameObject.name == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }    
}
