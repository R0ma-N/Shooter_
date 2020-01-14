using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shooter
{
    public class Inventory
    {
        public List<Object> inventory;
        public List<WeaponBase> _weapons;
        public FlashLightModel FlashLight;
        public GameObject Player;

        public Inventory()
        {
            FlashLight = Object.FindObjectOfType<FlashLightModel>();
            Player = GameObject.FindGameObjectWithTag("Player");
            _weapons = Player.GetComponentsInChildren<WeaponBase>().ToList();
            foreach (WeaponBase weapon in _weapons)
            {
                weapon.ClipsCount = weapon.ClipsMaxCount;
                weapon.BulletsCount = weapon.BulletsInClip;
            }
        }

        public Inventory(bool NewWeapon)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            _weapons = Player.GetComponentsInChildren<WeaponBase>().ToList();
        }
    }
}
