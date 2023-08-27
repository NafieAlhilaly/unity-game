using UnityEngine;
using TMPro;

namespace Platformer.Mechanics
{
    public class HealthOnUIController : MonoBehaviour
    {
        [SerializeField] TextMeshPro HealthOnUI;
        [SerializeField] PlayerController Player;
        void Update()
        {
            HealthOnUI.text = Player.health.maxHP.ToString();
        }
    }

}