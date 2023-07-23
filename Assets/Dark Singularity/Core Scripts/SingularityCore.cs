using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class SingularityCore : MonoBehaviour
{
    //This script is responsible for what happens when the pullable objects reach the core
    //by default, the game objects are simply turned off
    //as this is much more performant than destroying the objects
    void OnTriggerStay2D (Collider2D other) {
        if(other.GetComponent<SingularityPullable>()){
            Debug.Log("Singularity reached core");
        }
    }

    void Awake(){
        if(GetComponent<CircleCollider2D>()){
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
}
