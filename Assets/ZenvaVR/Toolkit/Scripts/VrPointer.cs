using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    public class VrPointer : MonoBehaviour
    {
        [Tooltip("Maximum interaction distance")]
        public float maxDistance;

        [Tooltip("Show ray for debugging")]
        public bool isDebug;

        [Tooltip("Start position of the pointer")]
        public Transform origin;

        [Tooltip("Layers we want the pointer to detect")]
        public LayerMask detectedLayers = ~0; 

        // end position of the pointer
        public Vector3 EndPosition { get; private set; }

        // raycast hit
        public RaycastHit Target { get; private set; }

        // keep track of interactables
        Interactable currInteractable;
        Interactable prevInteractable;

        // Update is called once per frame
        void Update()
        {
            Raycast();
        }

        void Raycast()
        {
            RaycastHit target;

            // we found an object
            if (Physics.Raycast(origin.position, transform.forward, out target, maxDistance, detectedLayers.value))
            {
                Target = target;

                EndPosition = target.point;

                currInteractable = target.collider.transform.GetComponent<Interactable>();

                // call selection method
                if (currInteractable)
                    currInteractable.Over();
            }

            // we didn't find any object
            else
            {
                Target = new RaycastHit();

                EndPosition = transform.position + transform.forward * maxDistance;

                // call the unselection method
                if (currInteractable)
                    currInteractable.Out();
            }

            // check that selection changed
            if(currInteractable != prevInteractable)
            {
                prevInteractable?.Out();
            }

            prevInteractable = currInteractable;

            if (true)
                Debug.DrawRay(transform.position, EndPosition - transform.position, Color.blue);
        }

        public void PressButton()
        {
            currInteractable?.ButtonDown();
        }
    }
}