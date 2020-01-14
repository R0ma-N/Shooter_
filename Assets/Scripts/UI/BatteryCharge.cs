using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class BatteryCharge : MonoBehaviour
    {
        public Image[] Devisions;
        public Canvas Canvas;
        public bool IsBlinked;
        
        void Awake()
        {
            Devisions = GetComponentsInChildren<Image>();
            Canvas = GetComponentInParent<Canvas>();
            IsBlinked = true;
        }

        private void Update()
        {
            Devisions[0].enabled = Canvas.enabled = IsBlinked;
        }
    }
}
