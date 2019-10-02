using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class GrabController : MonoBehaviour
    {
        Grabbable item;
        bool isGripping;

        private void Awake()
        {
            // make sure the hand rigid body is kinematic
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }

        public void Grip()
        {
            isGripping = true;
        }

        // release if carrying anything
        public void Release()
        {
            isGripping = false;
            item?.Release();
            item = null;
        }

        private void OnTriggerStay(Collider other)
        {
            // check we are not already carrying an item, we are gripping, and we found a grabbable object
            if (!item && isGripping && other.GetComponent<Grabbable>())
            {
                item = other.GetComponent<Grabbable>();

                // start grabbing
                item.Grab(gameObject);
            }            
        }
    }
}