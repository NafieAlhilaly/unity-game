using UnityEngine;

namespace Platformer.Mechanics
{

    public class PortalController : MonoBehaviour
    {
        [SerializeField] bool isActive = false;
        [SerializeField] PortalController TeleportTo;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var player = collider.gameObject.GetComponent<PlayerController>();
            if (player != null && isActive == true)
            {
                player.Teleport(TeleportTo.transform.position);
            }
        }
    }
}