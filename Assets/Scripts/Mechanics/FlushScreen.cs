using System.Collections;
using UnityEngine;
namespace Platformer.Mechanics
{

    public class FlushScreen : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            Color newColor = spriteRenderer.color;
            newColor.a = 0;
            spriteRenderer.color = newColor;
        }

        public void StartFlushing()
        {
            StartCoroutine(Flushing());
        }

        IEnumerator Flushing()
        {
            for (float i = 0; i < 1; i += 0.1f)
            {
                Color newColor = spriteRenderer.color;
                newColor.a = i;
                spriteRenderer.color = newColor;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

}