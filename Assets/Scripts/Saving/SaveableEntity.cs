using System.Collections.Generic;
using Assets.Scripts.Saving;
using UnityEditor;
using UnityEngine;


namespace RPG.Saving
{
    [ExecuteAlways]
    public class SaveableEntity: MonoBehaviour
    {
        [SerializeField] private string uniqueIdentifier = "";
        public string GetUniqueIdentifier()
        {
            return uniqueIdentifier;
        }

        public object CaptureState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
            foreach (var saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.CaptureState();
            }
            return state;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> stateDict = (Dictionary<string, object>)state;
            foreach (var saveable in GetComponents<ISaveable>())
            {
                var typeString = saveable.GetType().ToString();
                if (stateDict.ContainsKey(typeString))
                {
                    saveable.RestoreState(stateDict[typeString]);
                }
            }
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
