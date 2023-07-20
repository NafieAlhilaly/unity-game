using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class GlitchInteractionBehavior : MonoBehaviour
    {
        private Vector3 scaleChange;
        public GameObject glitchedObject1;
        public AudioSource audioData;
        public float RotationSpeed = 20f;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                audioData.Play();
            }
        }
        void OnTriggerStay2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                TransformMovalbeObject();
            }
        }

        void TransformMovalbeObject()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal < 0f)
            {
                glitchedObject1.transform.Rotate(0, 0, 3);

            }
            if (horizontal > 0f)
            {
                glitchedObject1.transform.Rotate(0, 0, -5);
            }
        }
    }
}