using Platformer.Mechanics;
using UnityEngine;


namespace Hunter.Behaviour
{
    public class FinalAttackBehaviour : MonoBehaviour
    {
        [SerializeField] StateManager StateManager;
        [SerializeField] Transform Target;
        [SerializeField] ParticleSystem CleaveEffectR;
        [SerializeField] ParticleSystem CleaveEffectL;
        [SerializeField] AudioSource ChagringSound;
        [SerializeField] FlushScreen FlushScreen;
        [SerializeField] AutoAttack AutoAttack;

        bool started = true;
        void Start()
        {
            CleaveEffectR.Stop();
            CleaveEffectL.Stop();
            ChagringSound.Stop();
        }
        void Update()
        {
            if (StateManager.CurrentState.GetType() == typeof(FinalAttack))
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * 2f);
            }
            if (transform.position.x == Target.transform.position.x && transform.position.y == Target.transform.position.y && started)
            {
                Invoke(nameof(InitiatePurgeAttack), 9);
                started = false;
            }
        }

        void InitiatePurgeAttack()
        {
            AutoAttack.CurrentAttackState = AutoAttack.AttackState.Stop;
            ChagringSound.time = 0;
            ChagringSound.Play();
            CleaveEffectR.Play();
            CleaveEffectL.Play();
            Invoke(nameof(Flush), 6);
            // TODO: Add finish scene
            // labels: todo
        }

        void Flush()
        {
            FlushScreen.StartFlushing();
        }
    }
}