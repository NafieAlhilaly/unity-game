using System.Collections;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PatrollerController : MonoBehaviour
    {
        [SerializeField] PatrolPath Path;
        [SerializeField] float speed = 1f;
        Vector3 startPos;
        Vector3 targetPos;
        Vector3 endPos;
        [SerializeField] SpriteRenderer Light;
        [SerializeField] float LightAlpha = 0.5f;
        [SerializeField] public bool IsPlayerDetected = false;
        [SerializeField] public bool IsEffected = false;
        private BoxCollider2D boxCollider2D;
        [SerializeField] bool IsLightFading = false;
        [SerializeField] float LightBlinkModifier = 0.01f;
        [SerializeField] float LightOutModifier = 1f;
        void Start()
        {
            Color NewLightColor = Light.color;
            NewLightColor.a = LightAlpha;
            Light.color = NewLightColor;
            boxCollider2D = GetComponent<BoxCollider2D>();
            startPos = new Vector3(Path.startPosition.x, transform.position.y, transform.position.z);
            endPos = new Vector3(Path.endPosition.x, transform.position.y, transform.position.z);
            targetPos = endPos;
        }

        void Update()
        {
            if (IsEffected && !IsLightFading)
            {
                StartLightFade();
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (transform.position == targetPos)
                targetPos = startPos;
            if (transform.position == startPos)
                targetPos = endPos;
            if (Light.color.a <= 0)
            {
                boxCollider2D.enabled = false;
            }
            if (Light.color.a > 0)
            {
                boxCollider2D.enabled = true;
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                IsPlayerDetected = true;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                IsPlayerDetected = false;
            }
        }
        void StartLightFade()
        {
            IsLightFading = true;
            StartCoroutine(LightFadeSlowly());
        }
        IEnumerator LightFadeSlowly()
        {
            Color NewLightColor = Light.color;
            NewLightColor.a = 0.02f;
            Light.color = NewLightColor;
            yield return new WaitForSeconds(LightBlinkModifier);

            NewLightColor.a = 0.04f;
            Light.color = NewLightColor;
            yield return new WaitForSeconds(LightBlinkModifier);

            NewLightColor.a = LightAlpha;
            Light.color = NewLightColor;

            while (Light.color.a > 0)
            {
                NewLightColor = Light.color;
                NewLightColor.a -= 0.01f;
                Light.color = NewLightColor;
                yield return new WaitForSeconds(0.03f);
            }
            yield return new WaitForSeconds(LightOutModifier);
            while (Light.color.a < LightAlpha)
            {
                NewLightColor = Light.color;
                NewLightColor.a += 0.03f;
                Light.color = NewLightColor;
                yield return new WaitForSeconds(0.03f);
            }
            IsLightFading = false;
        }

        // TODO: Add a funtion to make the character attack Player when Player is detected.
    }
}