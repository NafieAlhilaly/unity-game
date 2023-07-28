using System.Collections;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    Vector3 beginPos;
    public bool attacking = false;
    public float RotationSpeed = 0.3f;
    public GameObject Boss;
    private Quaternion _lookRotation;
    private Vector3 _swordDirection;

    public void PrepareMovingTo(Vector3 endPos, float time = 0.5f)
    {
        StartCoroutine(Move(beginPos, endPos, time));
    }
    public void PrepareToAttack(Transform target, float speed)
    {
        StartCoroutine(Attack(target, speed));
    }
    public void PrepareMovingToBoss(float speed)
    {
        StartCoroutine(Move(transform.position, Boss.transform.position + new Vector3(-1.3f, 0f, 0f), speed));
    }

    IEnumerator Move(Vector3 beginPos, Vector3 endPos, float time)
    {
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            transform.position = Vector3.Lerp(beginPos, endPos, t);
            yield return null;
        }
    }

    public void RotateToTarget(Transform Target)
    {
        _swordDirection = (Target.position - transform.position).normalized;
        float angle = (Mathf.Atan2(_swordDirection.y, _swordDirection.x) * Mathf.Rad2Deg) - 40;
        _lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
    }

    public IEnumerator Attack(Transform target, float speed)
    {
        PrepareMovingTo(target.position, speed);
        yield return new WaitForSeconds(1f);
        PrepareMovingToBoss(speed);
    }
}
