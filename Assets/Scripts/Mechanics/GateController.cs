using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class GateController : MonoBehaviour
    {
        enum GateState
        {
            Opened,
            Closed,
            Moving
        }
        [SerializeField] AudioSource GateSound;
        [SerializeField] float GateSpeed;
        [SerializeField] float GateMaxY;
        [SerializeField] float GateMinY;
        [SerializeField] GateState CurrentGateState = GateState.Closed;
        private bool IsPlayerIn = false;
        void OnTriggerEnter2D(Collider2D collider2DInfo)
        {
            if (collider2DInfo.gameObject.name == "Player")
            {
                GateSound.Play();
                IsPlayerIn = true;
            }
        }
        void OnTriggerStay2D(Collider2D collider2DInfo)
        {
            if (collider2DInfo.gameObject.name == "Player" && transform.position.y <= GateMaxY)
            {
                transform.position = transform.position + Vector3.up * Time.deltaTime * GateSpeed;
                if (transform.position.y >= GateMaxY)
                {
                    CurrentGateState = GateState.Opened;
                    if (GateSound.isPlaying == true)
                    {
                        GateSound.Stop();
                    }
                }
            }
        }
        void OnTriggerExit2D(Collider2D collider2DInfo)
        {
            if (collider2DInfo.gameObject.name == "Player")
            {
                IsPlayerIn = false;
                GateSound.Play();
            }
        }
        void Update()
        {
            if (transform.position.y < GateMaxY && CurrentGateState == GateState.Opened || transform.position.y > GateMinY && CurrentGateState == GateState.Closed)
            {
                CurrentGateState = GateState.Moving;
            }
            if (IsPlayerIn == false && transform.position.y > GateMinY)
            {
                transform.position = transform.position + Vector3.down * Time.deltaTime * GateSpeed;
                if (transform.position.y <= GateMinY)
                {
                    CurrentGateState = GateState.Closed;
                    if (GateSound.isPlaying == true)
                    {
                        GateSound.Stop();
                    }
                }
            }
        }
    }
}
