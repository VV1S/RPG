using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        Transform target;
        float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }

            else
            {
                GetComponent<Mover>().Cancel();
                if (timeSinceLastAttack >= timeBetweenAttacks)
                {
                    AttackBehaviour();
                    timeSinceLastAttack = 0;
                }
            }
        }

        private void AttackBehaviour()
        {
            GetComponent<Animator>().SetTrigger("attack");
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attck(CombatTarget combatTarget)
        {
            GetComponent<ActionScheluder>().StartAction(this);
            target = combatTarget.transform;
        }   
        
        public void Cancel()
        {
            target = null;  
        }

        //Animation Event
        void Hit()
        {

        }
    }
}


