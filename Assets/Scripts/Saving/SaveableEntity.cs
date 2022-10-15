using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace RPG.Saving
{
    [ExecuteAlways]
    public class SaveableEntity: MonoBehaviour
    {
        [SerializeField] private string uniqueIdentifier = "";
        public string GetUniqueIdentifier()
        {
            return "";
        }

        public object CaptureState()
        {
            print("Capturing state for " + GetUniqueIdentifier());
            return null;
        }

        public void RestoreState(object state)
        {
            print("Restoring state for " + GetUniqueIdentifier());
        }
#if UNITY_EDITOR
        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return;
            if (string.IsNullOrEmpty(gameObject.scene.path)) return;

            SerializedObject seializedObject = new SerializedObject(this);
            SerializedProperty property = seializedObject.FindProperty("uniqueIdentifier");
            
            if (property.stringValue == "")
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                seializedObject.ApplyModifiedProperties();
            }
        }
#endif
    }
}
