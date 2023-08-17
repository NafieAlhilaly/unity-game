using UnityEngine;

namespace Platformer.Mechanics
{

    public class PlatformBehaviuor : MonoBehaviour
    {
        [SerializeField] FightPlatformsController fc;
        [SerializeField] int number;

        void OnTriggerEnter2D(Collider2D col){
            if(col.CompareTag("Player"))
            {
                fc.SelectedNumber = number;
            }
        }
        
    }
}
