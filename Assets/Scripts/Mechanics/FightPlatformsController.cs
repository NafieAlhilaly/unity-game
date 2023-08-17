using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [SerializeField] GameObject UpperPlatform;
        [SerializeField] GameObject LowerPlatform;
        [SerializeField] PatrolPath UpperPlatformPath;
        [SerializeField] PatrolPath LowerPlatformPath;
        [SerializeField] bool MovingPlatform = false;
        [SerializeField] float time = 30f;
        void Start()
        {
            Invoke(nameof(CountDonwToMovePlatforms), time);
        }

        void Update()
        {
            if(MovingPlatform && UpperPlatform.transform.position.y >= UpperPlatformPath.endPosition.y){
                UpperPlatform.transform.position = Vector3.MoveTowards(UpperPlatform.transform.position, UpperPlatformPath.endPosition, Time.deltaTime * 0.6f);
            }
            if(MovingPlatform && UpperPlatform.transform.position.y <= UpperPlatformPath.endPosition.y){
                LowerPlatform.transform.position = Vector3.MoveTowards(LowerPlatform.transform.position, LowerPlatformPath.endPosition, Time.deltaTime * 0.4f);
            }
        }

        void CountDonwToMovePlatforms(){
            MovingPlatform = true;
        }
    }
}
