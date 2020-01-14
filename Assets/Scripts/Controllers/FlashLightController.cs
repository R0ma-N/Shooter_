using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class FlashLightController: BaseController , IOnInitialize, IOnUpdate
    {
        private FlashLightModel _flashLight;
        private Timer _timer;
        
        public FlashLightController()
        {
            _flashLight = Inventory.FlashLight;
            _timer = new Timer();
        }

        public void OnStart()
        {
            _flashLight.CurrentCharge = _flashLight.MaxCharge;
            _flashLight.Light.enabled = false;
            UIInterface.BatteryCharge.Canvas.enabled = false;
        }
        
        public void OnUpdate()
        {
            if (_flashLight.IsOn && _flashLight.CurrentCharge > 0)
            {
                DecreaseCharge();
            }
            else Off();

            if (!_flashLight.IsOn && _flashLight.CurrentCharge < _flashLight.MaxCharge)
            {
                IncreaseCharge();
            }
        }
        
        public override void On()
        {
            Switch(true);
        }
        public override void Off()
        {
            Switch(false);
        }

        public override void Switch()
        {
            if (_flashLight.IsOn)
            {
                Off();
            }
            else
            {
                On();
            }
        }

        private void Switch(bool value)
        {
            _flashLight.Light.enabled = value;
            _flashLight.IsOn = value;
            UIInterface.BatteryCharge.Canvas.enabled = value;
        }
        private void Rotation()
        {
            //_flashLight.transform.position = _flashLight
        }


        private void DecreaseCharge()
        {
            _flashLight.CurrentCharge -= Time.deltaTime;

            if (_flashLight.CurrentCharge < _flashLight.MaxCharge - _flashLight.MaxCharge / 6)
            {
                UIInterface.BatteryCharge.Devisions[5].enabled = false;

                if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 2)
                {
                    UIInterface.BatteryCharge.Devisions[4].enabled = false;

                    if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 3)
                    {
                        UIInterface.BatteryCharge.Devisions[3].enabled = false;

                        for (int i = 0; i < 3; i++)
                        {
                            UIInterface.BatteryCharge.Devisions[i].color = new Color32(225, 112, 52, 255);
                        }

                        if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 4)
                        {
                            UIInterface.BatteryCharge.Devisions[2].enabled = false;
                            _flashLight.Light.enabled = _timer.BlinkRandom(0.1f, 0.4f);

                            if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 5)
                            {                               
                                UIInterface.BatteryCharge.Devisions[1].enabled = false;
                                UIInterface.BatteryCharge.Devisions[0].color = Color.red;
                                _timer.blink(ref UIInterface.BatteryCharge.IsBlinked, 0.5f);
                                _flashLight.Light.enabled = _timer.BlinkRandom(0.01f, 0.1f);
                            }
                        }
                    }
                }
            }
        }

        private void IncreaseCharge()
        {
            _flashLight.CurrentCharge += Time.deltaTime;
            if(_flashLight.CurrentCharge > _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 5)
            {
                UIInterface.BatteryCharge.Devisions[1].enabled = true;
                UIInterface.BatteryCharge.Devisions[0].color = new Color32(225, 112, 52, 255);

                if (_flashLight.CurrentCharge > _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 4)
                {
                    UIInterface.BatteryCharge.Devisions[2].enabled = true;

                    if (_flashLight.CurrentCharge > _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 3)
                    {
                        UIInterface.BatteryCharge.Devisions[3].enabled = true;
                        for (int i = 0; i < 3; i++)
                        {
                            UIInterface.BatteryCharge.Devisions[i].color = new Color32(0,147,17,255);
                        }

                        if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 2)
                        {
                            UIInterface.BatteryCharge.Devisions[4].enabled = true;

                            if (_flashLight.CurrentCharge < _flashLight.MaxCharge - _flashLight.MaxCharge / 6)
                            {
                                UIInterface.BatteryCharge.Devisions[5].enabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void Blink()
        {

        }
    }
}
