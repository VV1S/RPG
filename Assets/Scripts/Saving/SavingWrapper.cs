using UnityEngine;

namespace RPG.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        private const string deafaultSaveFile = "save";

        private void Start()
        {
            Load();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                Save();
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                Load();
            }
        }
        public void Save()
        {
            GetComponent<SavingSystem>().Save(deafaultSaveFile);
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(deafaultSaveFile);
        }

    }
}

