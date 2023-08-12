using System.Collections;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlayerEnteredFirstBossZone : MonoBehaviour
    {
        public AudioSource lightningStrikeSound;
        public RobocatBehavior robocat;
        public AudioSource bossOST;

        void OnTriggerEnter2D(Collider2D col)
        {
            lightningStrikeSound.Play();
            robocat.PrepareMovingTo(new Vector3(143.19f, -5.14f, 0));
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
