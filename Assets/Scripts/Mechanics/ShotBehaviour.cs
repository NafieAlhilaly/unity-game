using UnityEngine;

namespace Platformer.Mechanics
{
    public class Shot : MonoBehaviour
    {
        [SerializeField] float Speed = 10f;
        [SerializeField] AudioSource ShotSound;
        private Transform StartPosition;

        void Start()
        {
            ShotSound.Play();
            StartPosition = transform;
        }
        void Update()
        {
            transform.position += Vector3.down * Time.deltaTime * Speed;
            if(transform.position.y <= -20f)
            {
                Destroy(gameObject);
            }
        }
    }
}
