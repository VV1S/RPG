using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        private Text healthValue;
        private Fighter fighter;

        private void Awake()
        {
            healthValue = GetComponent<Text>();
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        {
            var health = fighter.GetTarget();
            if (health == null)
            {
                healthValue.text = "No enemy targeted";
                return;
            }
            healthValue.text = String.Format("{0:0}/{1:0}", health.GetHealthPoints(), health.GetMaxHealthPoints());
        }
    }
}

