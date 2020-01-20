
using UnityEngine;

namespace Shooter
{
    public class FlashLightController: BaseController , IOnInitialize, IOnUpdate
    {
        private FlashLightModel _flashLight;
        private BatteryCharge _batteryUI;
        private Timer _timer;

        private Color32 orange = new Color32(225, 112, 52, 255);
        private Color32 green = new Color32(0, 147, 17, 255);

        public FlashLightController()
        {
            _flashLight = Inventory.FlashLight;
            _batteryUI = UIInterface.BatteryCharge;
            _timer = new Timer();
        }

        public void OnStart()
        {
            _flashLight.CurrentCharge = _flashLight.MaxCharge;
            _flashLight.Light.enabled = false;
            _batteryUI.Canvas.enabled = false;
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
            _batteryUI.Canvas.enabled = value;
        }

        //   +----------------------------------------+
        //   |   +--+  +--+  +--+  +--+  +--+  +--+   |
        //   |   |**|  |**|  |**|  |**|  |**|  |**|   +--+
        //   |   |**|  |**|  |**|  |**|  |**|  |**|      |
        //   |   |**|  |**|  |**|  |**|  |**|  |**|      |
        //   |   |**|  |**|  |**|  |**|  |**|  |**|   +--+
        //   |   +--+  +--+  +--+  +--+  +--+  +--+   |
        //   +----------------------------------------+
        //   
        //   Батарейка состоит из Canvas, на котором лежит Image с фоном для еще 6-ти Image - прямоугольников. 
        //   Это полоски зарядки, в коде - массив Devisions(подразделения)
        //   _flashLight.MaxCharge / 6 - значит поделить значение максимального заряда на 6 подразделений, чтобы
        //   это максимальное значение можно было свободно менять.
        //
        //     далее, в зависимости от уровня заряда, подразделения выключаются, меняют цвет 
        //     и в конце мограет все, что осталось. 

        private void DecreaseCharge()
        {
            _flashLight.CurrentCharge -= Time.deltaTime;

            if (_flashLight.CurrentCharge < _flashLight.MaxCharge - _flashLight.MaxCharge / 6)
            {
                _batteryUI.Devisions[5].enabled = false;

                if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 2)
                {
                    _batteryUI.Devisions[4].enabled = false;

                    if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 3)
                    {
                        _batteryUI.Devisions[3].enabled = false;

                        for (int i = 0; i < 3; i++)
                        {
                            _batteryUI.Devisions[i].color = orange;
                        }

                        if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 4)
                        {
                            _batteryUI.Devisions[2].enabled = false;
                            _flashLight.Light.enabled = _timer.BlinkRandom(0.1f, 0.4f);

                            if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 5)
                            {
                                _batteryUI.Devisions[1].enabled = false;
                                _batteryUI.Devisions[0].color = Color.red;
                                _batteryUI.Canvas.enabled = _batteryUI.Devisions[0].enabled = _batteryUI.IsBlinked;
                                _timer.Blink(ref _batteryUI.IsBlinked, 0.5f);
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
                _batteryUI.Devisions[1].enabled = true;
                _batteryUI.Devisions[0].color = orange;

                if (_flashLight.CurrentCharge > _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 4)
                {
                    _batteryUI.Devisions[2].enabled = true;

                    if (_flashLight.CurrentCharge > _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 3)
                    {
                        _batteryUI.Devisions[3].enabled = true;
                        for (int i = 0; i < 3; i++)
                        {
                            _batteryUI.Devisions[i].color = green;
                        }

                        if (_flashLight.CurrentCharge < _flashLight.MaxCharge - (_flashLight.MaxCharge / 6) * 2)
                        {
                            _batteryUI.Devisions[4].enabled = true;

                            if (_flashLight.CurrentCharge < _flashLight.MaxCharge - _flashLight.MaxCharge / 6)
                            {
                                _batteryUI.Devisions[5].enabled = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
