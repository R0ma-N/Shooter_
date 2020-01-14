using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class BaseObjectModel : MonoBehaviour
    {
        [HideInInspector] public Rigidbody Rigidbody;
        [HideInInspector] public MeshRenderer MeshRenderer;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            MeshRenderer = GetComponent<MeshRenderer>();
        }

        public bool IsVisible(bool value)
        {
            MeshRenderer.enabled = value;
            return value;
        }
    }
}
