using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        [SerializeField] private Text healthValue;
        private Fighter fighter;

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        {
            var targetHealth = fighter.GetTarget();
            if (targetHealth == null)
            {
                healthValue.text = "No enemy targeted";
                return;
            }
            healthValue.text = String.Format("{0:0}%", targetHealth.GetPercentage());
        }
    }
}

