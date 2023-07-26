using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class AraOfEffect : MonoBehaviour
    {
        [SerializeField] PlayerController Player;
        [SerializeField] PatrollerController Effected;

        void Start(){
            Player = GetComponent<PlayerController>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Effected.IsEffected = true;
            }
        }
        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Effected.IsEffected = false;
            }
        }
    }
}
