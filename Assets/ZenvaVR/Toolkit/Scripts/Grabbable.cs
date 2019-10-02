using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Zenva.VR
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Grabbable : MonoBehaviour
    {
        // options when releasing the item
        public enum ReleaseAction { nothing, backToOrigin, throws }

        [Tooltip("Does it face the foward direction of the hand that grabs it")]
        public bool facesForward;

        [Tooltip("What happens when releasing")]
        public ReleaseAction releaseAction;

        [Tooltip("Event triggered when grabbing")]
        public UnityEvent OnGrab;

        [Tooltip("Event triggered when releasing")]
        public UnityEvent OnRelease;
        
        // who is grabbing this
        GameObject grabCtrl;

        // original position and rotation
        Vector3 originalPosition;
        Quaternion originalRotation;

        // original parent
        Transform originalParent;

        // rigid body
        Rigidbody rb;

        // original kinematic status
        bool isKinematic;

        // keep track of the controller velocity for throwing
        Vector3 ctrlVelocity;
        Vector3 prevPosition;

        void Awake()
        {            
            rb = GetComponent<Rigidbody>();
            isKinematic = rb.isKinematic;
            
            originalParent = transform.parent;
        }

        void FixedUpdate()
        {
            // calculate the velocity based on the previous and current position
            if(grabCtrl && releaseAction == ReleaseAction.throws)
            {
                ctrlVelocity = (transform.position - prevPosition) / Time.fixedDeltaTime;
                prevPosition = transform.position;
            }
        }


        public void Grab(GameObject grabCtrl)
        {
            // can be called if already grabbing
            if (this.grabCtrl) return;

            this.grabCtrl = grabCtrl;

            // keep for when releasing
            originalPosition = transform.position;
            originalRotation = transform.rotation;
            prevPosition = originalPosition;

            // face to the same direction as the controller
            if (facesForward)
                transform.forward = grabCtrl.transform.forward;

            // set as child of the controller
            transform.parent = grabCtrl.transform;

            // set rigidbody to kinematic
            rb.isKinematic = true;

            // trigger event
            OnGrab.Invoke();
        }

        public void Release()
        {
            // can't be called if not grabbing
            if (!grabCtrl) return;

            // return to it's original parent if any
            transform.parent = originalParent;

            // restore rigid body
            rb.isKinematic = isKinematic;

            // handle release actions
            switch (releaseAction)
            {
                case ReleaseAction.backToOrigin:
                    BackToOrigin();
                    break;
                case ReleaseAction.throws:
                    ThrowItem();
                    break;
            }        

            // trigger event
            OnRelease.Invoke();

            // disconnect from controller
            grabCtrl = null;
        }

        void BackToOrigin()
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }

        void ThrowItem()
        {
            // needs a non-kinematic RB
            rb.isKinematic = false;

            // set controller velocity
            rb.velocity = ctrlVelocity;
        }
    }
}

