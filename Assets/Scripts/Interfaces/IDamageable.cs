using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shooter
{
    interface IDamageable
    {
        void getDamage(float damage);
        void OnDeath();
    }
}
