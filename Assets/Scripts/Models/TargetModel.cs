using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class TargetModel : BaseObjectModel, IDamageable
    {
        public float Health;

        protected override void Awake()
        {
            base.Awake();
            Rigidbody.isKinematic = true;
            Shader.SetGlobalColor(5, Color.black);
        }

        public void getDamage(float damage)
        {
            Health -= damage;
            if(Health <= 0)
            {
                OnDeath();
            }
        }

        public void OnDeath()
        {
            Rigidbody.isKinematic = false;
            Destroy(gameObject);
        }
    }
}
