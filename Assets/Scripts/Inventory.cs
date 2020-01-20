
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Inventory
    {
        public List<Object> inventory;
        public WeaponBase[] Weapons;
        public FlashLightModel FlashLight;
        public GameObject Player;

        public Inventory()
        {
            FlashLight = Object.FindObjectOfType<FlashLightModel>();
            Player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            Weapons = Player.GetComponentsInChildren<WeaponBase>();
            foreach (WeaponBase weapon in Weapons)
            {
                weapon.ClipsCount = weapon.ClipsMaxCount;
                weapon.BulletsCount = weapon.BulletsInClip;
            }
        }

        //смысл второго конструктора в том, что первый находит и заряжает всё имеющиеся оружие при старте,
        //второй же срабатывает при подборе нового и не заряжает уже имеющееся
        public Inventory(bool NewWeapon)
        {
            Player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            Weapons = Player.GetComponentsInChildren<WeaponBase>();
        }
    }
}
