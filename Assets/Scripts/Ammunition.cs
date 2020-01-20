using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Ammunition : BaseObjectModel
    {
        [SerializeField] protected float _timeToDestruct = 10;
        [SerializeField] protected float _Damage = 10;
 
        public void AddForce(Vector3 dir)
        {
            if (!Rigidbody) return;
            Rigidbody.AddForce(dir);
        }

        public void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.getDamage(_Damage);
            }
            
            Destroy(gameObject);
        }

        public void Destroy()
        {
            DestroyImmediate(gameObject, true);
        }
    }
}