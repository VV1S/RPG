using UnityEngine;

namespace RPG.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        private const string deafaultSaveFile = "save";

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                GetComponent<SavingSystem>().Save(deafaultSaveFile);
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                GetComponent<SavingSystem>().Load(deafaultSaveFile);
            }
        }
    }
}

