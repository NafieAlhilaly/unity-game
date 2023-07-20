using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class RobocatBehavior : MonoBehaviour
    {
        Vector3 beginPos;
        float time = 2f;
        public GameObject player;
        public bool IsFightStarted = false;
        public SwordBehavior sword;
        bool readyToAttack = false;
        public float MaxX = 0f;

        public float MinX = -3.35f;

        public float MaxY = 0f;

        public float MinY = -3.35f;
        public GameObject FlyingPlatform;
        public GameObject GroundPlatform;

        public void prepareMovingTo(Vector3 endPos)
        {
            StartCoroutine(Move(endPos, time));
        }
        public void prepareMovingToRandomPosition()
        {
            float x = Core.Fuzzy.ValueBetween(MinX, MaxX);
            float y = Core.Fuzzy.ValueBetween(MinY, MaxY);
            StartCoroutine(Move(new Vector3(x, y, 0f), time));
        }
        public void prepareMovingObjectTo(GameObject objectToMove, Vector3 endPos, float time){
            StartCoroutine(MoveObjectTo(objectToMove, endPos, time));
        }
        void Update()
        {
            if (IsFightStarted == true)
            {
                StartCoroutine(AttackWithSword());
            }
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

        IEnumerator AttackWithSword()
        {
            if (readyToAttack == false)
            {
                sword.prepareMovingTo(transform.position + new Vector3(-2.7f, 0, 0), 1.2f);
                readyToAttack = true;
                sword.RotateToTarget(player.transform);
                yield return new WaitForSeconds(5.0f);
            }
        }

        IEnumerator MoveObjectTo(GameObject objectToMove, Vector3 endPos, float time){
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