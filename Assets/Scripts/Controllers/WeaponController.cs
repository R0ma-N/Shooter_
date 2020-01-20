﻿using UnityEngine;

namespace Shooter
{
    public class WeaponController : BaseController, IOnUpdate
    {
        private WeaponBase _activeWeapon;
        private Timer _timer;
        private KeyCode _fire = KeyCode.Mouse0;
        private KeyCode _reload = KeyCode.R;
        private int _index = 0;
        
        public WeaponController()
        {
            _activeWeapon = Inventory.Weapons[0];
            _timer = new Timer();
            WeaponBase.GotNewWeapon += NewWeapon;

            // 1.не понял как можно отписаться от этого события, если оружие можно будет
            //подобрать в любой момент, т.е. если отписаться, то оружие подобрать будет уже нельзя
            //
            // 2.т.к. WeaponBase абстрактный, кроме как через статическое поле к соботию не обратиться
        }

        public void OnUpdate()
        {
            if (Input.GetKey(_fire))
            {
                if(_activeWeapon.BulletsCount > 0)
                {
                    _activeWeapon.Fire();
                    _activeWeapon.IsReady = _timer.TimeIsUp(_activeWeapon.ShootInterval);
                }
                else return;
            }
            else if (Input.GetKeyUp(_fire))
            {
                _activeWeapon.IsReady = true;
                _timer.DistTime = 0;

                if(_activeWeapon is Flamethrower)
                {
                    _activeWeapon.StopFire();
                }
            }

            //не понял почему стрельба и перезарядка может быть в WeaponController,
            //а смена оружия по колесику мыши должна быть обязательно в InputController
            float mv = Input.GetAxis("Mouse ScrollWheel");
            if (mv > 0)
            {
                Debug.Log(_index);
                if (_index < Inventory.Weapons.Length - 1)
                {
                    ChangeWeapon(_index + 1);
                    return;
                }
                
                if (_index == Inventory.Weapons.Length - 1)
                {
                    ChangeWeapon(0);
                }
            }
            
            if (mv < 0)
            {
                if (_index > 0)
                {
                    ChangeWeapon(_index - 1);
                    return;
                }

                if (_index == 0)
                {
                    ChangeWeapon(Inventory.Weapons.Length - 1);
                }
            }

            if (Input.GetKeyDown(_reload))
            {
                if (_activeWeapon.ClipsCount == 0)
                    return;
                _activeWeapon.ClipsCount--;
                _activeWeapon.BulletsCount = _activeWeapon.BulletsInClip;
            }

            UIInterface.BulletsCount.TxtBullets.text = $"{_activeWeapon.ClipsCount}/{_activeWeapon.BulletsCount}  {Inventory.Weapons.Length}";
        }

        private void ChangeWeapon(int index)
        {

            if (_activeWeapon) _activeWeapon.IsVisible(false);
            _index = index;
            _activeWeapon = Inventory.Weapons[_index];
            _activeWeapon.IsVisible(true);
        }

        private void NewWeapon()
        {
            Inventory = new Inventory(true);
            ChangeWeapon(Inventory.Weapons.Length - 1);
            _activeWeapon.ClipsCount = _activeWeapon.ClipsMaxCount;
            _activeWeapon.BulletsCount = _activeWeapon.BulletsInClip;
        }
    }
}
