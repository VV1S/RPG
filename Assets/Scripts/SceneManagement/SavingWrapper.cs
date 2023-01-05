using System.Collections;
using RPG.Saving;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        private const string deafaultSaveFile = "save";

        [SerializeField] private float fadeInTime;

        void Awake()
        {
            StartCoroutine(LoadLastScene());
        }

        private IEnumerator LoadLastScene()
        {
            Fader fader = FindObjectOfType<Fader>();
            fader.FadeOutImmediate();
            yield return GetComponent<SavingSystem>().LoadLastScene(deafaultSaveFile);
            yield return fader.FadeIn(fadeInTime);
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
            if (Input.GetKeyUp(KeyCode.Delete))
            {
                Delete();
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

        public void Delete()
        {
            GetComponent<SavingSystem>().Delete(deafaultSaveFile);
        }

    }
}

