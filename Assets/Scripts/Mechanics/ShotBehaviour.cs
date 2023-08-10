using UnityEngine;

namespace Platformer.Mechanics
{
    public class Shot : MonoBehaviour
    {
        [SerializeField] float Speed = 10f;
        [SerializeField] AudioSource ShotSound;
        public GameObject Player;
        [SerializeField] bool TargetPlayer = false;
        Vector3 CurrentPlayerPosition;

        void Awake()
        {
            if (Player == null)
            {
                Player = GameObject.FindGameObjectWithTag("Player");
            }
            CurrentPlayerPosition = (Player.transform.position - transform.position).normalized;
            ShotSound.Play();
        }
        void Update()
        {
            if (TargetPlayer)
            {
                transform.position += Speed * Time.deltaTime * CurrentPlayerPosition;
            }
            else
            {
                transform.position += Speed * Time.deltaTime * Vector3.down;
            }
            if (transform.position.y <= -20f)
            {
                Destroy(gameObject);
            }
        }
    }
}
