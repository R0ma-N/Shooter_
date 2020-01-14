using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class BulletModel : Ammunition
    {
        protected override void Awake()
        {
            base.Awake();
            Destroy(gameObject, _timeToDestruct);
        }
    }
}
