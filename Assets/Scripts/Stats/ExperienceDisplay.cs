using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stats
{
    public class ExperienceDisplay : MonoBehaviour
    {
        [SerializeField] private Text xpValue;
        private Experience experience;

        void Awake()
        {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Text>().text = String.Format("{0:0}", experience.GetPoints());
        }
    }
}

