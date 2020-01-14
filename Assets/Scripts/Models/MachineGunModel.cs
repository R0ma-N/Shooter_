using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class MachineGunModel : WeaponBase
    {
        //public Transform FirePoint;
        
        //override protected void Awake()
        //{
        //    base.Awake();
        //    ShootInterval = 1;
        //}

        public override void Fire()
        {
            if (IsReady)
            {
                var tempAmmunation = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
                tempAmmunation.AddForce(_barrel.forward * _force);
                BulletsCount--;
                print("FIRE");
            }    
        }
    }
}
