using System.Collections;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class RobocatBehavior : MonoBehaviour
    {
        Vector3 beginPos;
        float time = 2f;
        public GameObject player;
        public bool IsFightStarted = false;
        public float MaxX = 0f;

        public float MinX = -3.35f;

        public float MaxY = 0f;

        public float MinY = -3.35f;
        public GameObject FlyingPlatform;
        public GameObject GroundPlatform;

        public void PrepareMovingTo(Vector3 endPos)
        {
            StartCoroutine(Move(endPos, time));
        }
        public void PrepareMovingToRandomPosition()
        {
            float x = Core.Fuzzy.ValueBetween(MinX, MaxX);
            float y = Core.Fuzzy.ValueBetween(MinY, MaxY);
            StartCoroutine(Move(new Vector3(x, y, 0f), time));
        }
        public void PrepareMovingObjectTo(GameObject objectToMove, Vector3 endPos, float time)
        {
            StartCoroutine(MoveObjectTo(objectToMove, endPos, time));
        }

        IEnumerator Move(Vector3 endPos, float time)
        {
            beginPos = transform.position;
            for (float t = 0; t < 1; t += Time.deltaTime / time)
            {
                transform.position = Vector3.Lerp(beginPos, endPos, t);
                yield return null;
            }
        }

        IEnumerator MoveObjectTo(GameObject objectToMove, Vector3 endPos, float time)
        {
            beginPos = transform.position;
            for (float t = 0; t < 1; t += Time.deltaTime / time)
            {
                objectToMove.transform.position = Vector3.Lerp(beginPos, endPos, t);
                yield return null;
            }
            yield return new WaitForSeconds(1f);
        }
    }

}