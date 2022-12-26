using Assets.Scripts.Saving;
using UnityEngine;

namespace RPG.Stats
{
    internal class Experience: MonoBehaviour, ISaveable
    {
        [SerializeField] private float experiencePoints = 0;

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
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
