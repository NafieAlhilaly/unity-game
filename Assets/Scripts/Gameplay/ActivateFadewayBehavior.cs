using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class ActivateFadewayBehavior : MonoBehaviour
    {
        public AudioSource InteractionSound;
        public GameObject BoxColliderGameObject;
        public List<GameObject> GameObjectsToFadaway;
        private List<SpriteRenderer> srs =  new List<SpriteRenderer>();
        private BoxCollider2D boxCollider2D;
        void Start()
        {
            boxCollider2D = BoxColliderGameObject.GetComponent<BoxCollider2D>();
            foreach (var gameObject in GameObjectsToFadaway)
            {
                SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
                srs.Add(sp);
            }
        }

        void StartFadeAway()
        {
            StartCoroutine(FadeAway());
        }
        IEnumerator FadeAway()
        {
            for (float f = 1f; f >= 0f; f -= 0.16f)
            {
                foreach (SpriteRenderer sr in  srs)
                {
                    Color _color = sr.color;
                    _color.a = f;
                    sr.material.color = _color;
                }
                yield return new WaitForSeconds(0.4f);
            }
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(0.4f);
            boxCollider2D.enabled = true;
            for (float f = 0f; f <= 1f; f += 0.16f)
            {
                foreach (SpriteRenderer sr in  srs)
                {
                    Color _color = sr.color;
                    _color.a = f;
                    sr.material.color = _color;
                }
                yield return new WaitForSeconds(0.4f);
            }
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                InteractionSound.Play();
                StartFadeAway();
            }
        }
    }
}