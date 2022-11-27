using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] private Weapon weapon = null;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                var fighter = other.transform.GetComponent<Fighter>();
                fighter.EquipWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }
}
