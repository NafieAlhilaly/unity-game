using UnityEngine;

namespace Platformer.Mechanics
{
    public class HiddenAreaController : MonoBehaviour
    {
        [SerializeField] readonly GameObject HiddenArea;
        void OnTriggerEnter2D(Collider2D collider)
        {
            var player = collider.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                HiddenArea.SetActive(false);
            }
        }
    }
}
