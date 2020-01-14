using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Timer
    {
        public float DistTime = 0;
        private float CurTime = 0;
        private float _random;
        private bool active;


        public bool TimeIsUp (float value)
        {
            if (DistTime == 0) 
            {
                DistTime = CurTime = value;
            }

            if (CurTime > 0)
            {
                CurTime -= Time.deltaTime;
                return false;
            }
            else
            {
                CurTime = DistTime;
                return true;
            }
        }

        public void blink(ref bool val1, float val2)
        {
            if (val1)
            {
                if (TimeIsUp(val2))
                    val1 = false;
            }
            else
            {
                if (TimeIsUp(val2))
                    val1 = true;
            }
        }

        public bool BlinkRandom(float minValue, float maxValue)
        {
            if (active)
            {
                _random = Random.Range(minValue, maxValue);
                if (TimeIsUp(_random))
                {
                    active = false;
                }
                    return false;
            }
            else
            {
                _random = Random.Range(minValue, maxValue);
                if (TimeIsUp(_random))
                {
                    active = true;
                }
                    return true;
            }
        }
    }
}
