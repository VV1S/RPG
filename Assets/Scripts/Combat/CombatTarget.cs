using RPG.Attributes;
using RPG.Control;
using UnityEngine;

namespace RPG.Combat 
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour, IRaycastable
    {
        public CursorType GetCursorType()
        {
            return CursorType.Combat;
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            var target = callingController.GetComponent<Fighter>();
            if (!GetComponent<Fighter>().CanAttack(target.gameObject))
            {
                return false;
            }

            if (Input.GetMouseButton(0))
            {
                GetComponent<Fighter>().Attck(target.gameObject);
            }
            return true;
        }
    }
}


