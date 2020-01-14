using UnityEngine;

namespace Shooter
{
    public abstract class WeaponBase : BaseObjectModel
    {
        public Ammunition Ammunition;
        public float ShootInterval;
        public bool IsReady = true;
        public int ClipsMaxCount;
        public int BulletsInClip;
        public delegate void GetWeaponHandler();
        public static event GetWeaponHandler GotNewWeapon;

        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _force = 999;
        [SerializeField] protected float _rechargeTime = 0.2f;

        [HideInInspector] public int ClipsCount;
        [HideInInspector] public int BulletsCount;

        protected Timer Timer = new Timer();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameObject.transform.parent = Camera.main.transform;
                GotNewWeapon?.Invoke();
                Transform weaponPosition = GameObject.FindGameObjectWithTag("WeaponPosition").transform;
                gameObject.transform.position = weaponPosition.position;
                gameObject.transform.rotation = weaponPosition.rotation;
            }
        }

        public abstract void Fire();
    }
}
