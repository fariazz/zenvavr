using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    [RequireComponent(typeof(Rigidbody))]
    public class ImpulseZeroGravity : MonoBehaviour
    {
        [Tooltip("Movement speed")]
        public float speed;

        [Tooltip("Follow the direction of this object")]
        public GameObject directionObj;

        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.velocity = directionObj.transform.forward * speed;
        }
    }
}