using System;
using System.Linq;
using UnityEngine;

namespace RPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        [SerializeField] private ProgressionCharacterClass[] characterClasses = null;

        public float GetHealth(CharacterClass characterClass, int level)
        {
            var usedClass = characterClasses.First(x => x.CharacterClass == characterClass);
            if (usedClass == null) return 0;
            return usedClass.health[level - 1];
        }

        [Serializable]
        class ProgressionCharacterClass
        {
            [SerializeField] public CharacterClass CharacterClass;
            [SerializeField] public float[] health;
        }
    }
}
