﻿using System;
using Assets.Scripts.Saving;
using UnityEngine;

namespace RPG.Stats
{
    internal class Experience: MonoBehaviour, ISaveable
    {
        [SerializeField] private float experiencePoints = 0;

        public event Action onExperienceGained;

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
            onExperienceGained();
        }

        public object CaptureState()
        {
            return experiencePoints;
        }

        public void RestoreState(object state)
        {
            experiencePoints = (float)state;
        }

        public float GetPoints()
        {
            return experiencePoints;
        }

    }
}
