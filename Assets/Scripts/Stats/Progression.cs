using System;
using System.Linq;
using UnityEngine;

namespace RPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        [SerializeField] private ProgressionCharacterClass[] characterClasses = null;

        public float GetStat(Stat stat, CharacterClass characterClass, int level)
        {
            foreach (var progressionClass in characterClasses)
            {
                if (progressionClass.CharacterClass != characterClass) continue;

                foreach (var progressionStat in progressionClass.stats)
                {
                    if(progressionStat.stat != stat) continue;
                    if (progressionStat.levels.Length < level) continue;
                    return progressionStat.levels[level - 1];
                }
            }
            return 0;
        }

        [Serializable]
        class ProgressionCharacterClass
        {
            public CharacterClass CharacterClass;

            public ProgressionStat[] stats;
        }

        [Serializable]
        class ProgressionStat
        {
            public Stat stat;
            public float[] levels;
        }
    }
}
