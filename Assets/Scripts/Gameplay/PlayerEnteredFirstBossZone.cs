using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlayerEnteredFirstBossZone : MonoBehaviour
    {
        public AudioSource lightningStrikeSound;
        public SwordBehavior sword;
        public RobocatBehavior robocat;
        public AudioSource bossOST;

        void OnTriggerEnter2D(Collider2D col)
        {
            lightningStrikeSound.Play();
            Debug.Log(sword.transform.position);
            Debug.Log(robocat.transform.position);

            robocat.prepareMovingTo(new Vector3(143.19f, -5.14f, 0));
            StartCoroutine(CountDownToFight());
        }

        IEnumerator CountDownToFight()
        {
            yield return new WaitForSeconds(5.0f);
            robocat.IsFightStarted = true;
            gameObject.SetActive(false);
        }
    }
}
