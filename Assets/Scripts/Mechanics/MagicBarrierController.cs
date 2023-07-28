using UnityEngine;

namespace Platformer.Mechanics
{
    public class MagicBarrierController : MonoBehaviour
    {
        [SerializeField] int DeathCountcondition = 3;
        void Update()
        {
            if(GhostController.DeathCount >= DeathCountcondition){
                gameObject.SetActive(false);
            }
        }
    }
}