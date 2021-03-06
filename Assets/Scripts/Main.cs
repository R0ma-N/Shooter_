﻿
using UnityEngine;

namespace Shooter
{
    public class Main : MonoBehaviour
    {
        private PlayerController _playerController;
        private InputController _inputController;
        private FlashLightController _flashLightController;
        private WeaponController _weaponController;
        private IOnUpdate[] _controllersUpdate;
        private IOnInitialize[] _controllersInit;

        private void Awake()
        {
            _playerController = new PlayerController();
            _inputController = new InputController();
            _flashLightController = new FlashLightController();
            _weaponController = new WeaponController();
            
            _controllersInit = new IOnInitialize[1];
            _controllersInit[0] = _flashLightController;
            
            _controllersUpdate = new IOnUpdate[4];
            _controllersUpdate[0] = _inputController;
            _controllersUpdate[1] = _playerController;
            _controllersUpdate[2] = _flashLightController;
            _controllersUpdate[3] = _weaponController;
        }
        void Start()
        {
            for (int i = 0; i < _controllersInit.Length; i++)
            {
                var controller = _controllersInit[i];
                controller.OnStart();
            }
            _weaponController.On();
        }

        void Update()
        {
            for (int i = 0; i < _controllersUpdate.Length; i++)
            {
                var controller = _controllersUpdate[i];
                controller.OnUpdate();
            }
        }
    }
}
