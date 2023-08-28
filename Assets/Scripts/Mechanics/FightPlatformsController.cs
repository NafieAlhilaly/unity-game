using System.Collections;
using Platformer.Mechanics.Fight.FloatingPlatformState;
using UnityEngine;
using TMPro;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    public class FightPlatformsController : MonoBehaviour
    {
        [SerializeField] GameObject UpperPlatform;
        [SerializeField] GameObject LowerPlatform;
        [SerializeField] PatrolPath UpperPlatformPath;
        [SerializeField] PatrolPath LowerPlatformPath;
        [SerializeField] bool MovingPlatform = false;
        [SerializeField] float time = 30f;
        [SerializeField] ParticleSystem[] UpperPlatformPSs;
        [SerializeField] TextMeshPro[] UpperPlatformNumbers;
        [SerializeField] public int SelectedNumber = 0;
        [SerializeField] public TextMeshPro Console;
        [SerializeField] public StateManager FPStateManager;
        [SerializeField] PlayerController Player;
        [SerializeField] FlushScreen FS;
        bool alive = true;
        void Start()
        {
            Invoke(nameof(CountDonwToMovePlatforms), time);
            foreach (ParticleSystem PS in UpperPlatformPSs)
            {
                PS.Stop();
            }
        }

        void Update()
        {
            if (MovingPlatform && UpperPlatform.transform.position.y >= UpperPlatformPath.endPosition.y)
            {
                UpperPlatform.transform.position = Vector3.MoveTowards(UpperPlatform.transform.position, UpperPlatformPath.endPosition, Time.deltaTime * 0.6f);
            }
            if (MovingPlatform && UpperPlatform.transform.position.y == UpperPlatformPath.endPosition.y)
            {
                FPStateManager.ReadyForCalculationPuzzle = true;
            }
            if (MovingPlatform && UpperPlatform.transform.position.y <= UpperPlatformPath.endPosition.y)
            {
                LowerPlatform.transform.position = Vector3.MoveTowards(LowerPlatform.transform.position, LowerPlatformPath.endPosition, Time.deltaTime * 0.4f);
            }
            if (Player.health.maxHP <= 0 && alive)
            {
                Schedule<SceneRestart>(1.5f);
                FS.StartFlushing();
                alive = false;
            }
        }

        void CountDonwToMovePlatforms()
        {
            MovingPlatform = true;
        }

        public IEnumerator PlayPlatformEffect()
        {
            for (int i = 0; i < UpperPlatformPSs.Length; i++)
            {
                TextMeshPro text = UpperPlatformNumbers[i];
                UpperPlatformPSs[i].Play();
                text.text = (i + 1).ToString();
                yield return new WaitForSeconds(0.3f);
            }
        }

        public IEnumerator StopPlatformEffect()
        {
            for (int i = 0; i <= UpperPlatformPSs.Length; i++)
            {
                TextMeshPro text = UpperPlatformNumbers[i];
                UpperPlatformPSs[i].Stop();
                text.text = " ";
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}
