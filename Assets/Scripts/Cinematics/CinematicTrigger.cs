using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics

{
    public class CinematicTrigger : MonoBehaviour
    {
        private bool alreadyTriggered = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!alreadyTriggered && other.tag == "Player")
            {
                alreadyTriggered = true;
                GetComponent<PlayableDirector>().Play();
            }
        }
    }
}

