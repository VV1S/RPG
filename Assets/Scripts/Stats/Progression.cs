using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        [SerializeField] private ProgressionCharacterClass[] characterClasses = null;

        private Dictionary<CharacterClass, Dictionary<Stat, float[]>> lookupTable = null;

        public float GetStat(Stat stat, CharacterClass characterClass, int level)
        {
            BuildLookup();

            float[] levels = lookupTable[characterClass][stat];

            if (levels.Length < level)
            {
                return 0;
            }

            return levels[level - 1];
        }

        public int GetLevels(Stat stat, CharacterClass characterClass)
        {
            BuildLookup();
            float[] levels = lookupTable[characterClass][stat];
            return levels.Length;
        }

        private void BuildLookup()
        {
            if (lookupTable != null) return;
            lookupTable = new Dictionary<CharacterClass, Dictionary<Stat, float[]>>();
            foreach (var progressionClass in characterClasses)
            {
                var statLookupTable = new Dictionary<Stat, float[]>();

                foreach (var progressionStat in progressionClass.stats)
                {
                    statLookupTable[progressionStat.stat] = progressionStat.levels;
                }

                lookupTable[progressionClass.CharacterClass] = statLookupTable;
            }
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
