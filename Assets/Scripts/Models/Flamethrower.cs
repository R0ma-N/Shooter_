using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Flamethrower : WeaponBase
    {
        private ParticleSystem _fire;
        
        override protected void Awake()
        {
            base.Awake();
            _fire = GetComponentInChildren<ParticleSystem>();
            _fire.Stop();
        }

        public override void Fire()
        {
            if (IsReady)
            {
                _fire.Play();
            }

            BulletsCount--;
        }

        public override void StopFire()
        {
            _fire.Stop();
            IsReady = true;
        }
    }
}
