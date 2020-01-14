using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public sealed class FlashLightModel : BaseObjectModel
    {
        public Light Light { get; private set; }
        public bool IsOn;
        public float MaxCharge = 10;
        public float CurrentCharge;

        public Transform GoFollow;
        public Vector3 VecOffset;

        Timer Timer;
        
        protected override void Awake()
        {           
            Light = GetComponent<Light>();
            IsOn = false;
            GoFollow = Camera.main.transform;
            transform.position = Camera.main.transform.position;
            VecOffset = transform.position - GoFollow.position;
            Timer = new Timer();
        }

        private void Update()
        {

        }
    }
}
