using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    [RequireComponent(typeof(VrPointer))]
    public class DistanceGrabController : MonoBehaviour
    {
        [Tooltip("Position where the grabbed object is held")]
        public GameObject grabPosition;

        Grabbable item;
        VrPointer vrPointer;
        bool isGripping;

        void Awake ()
        {
            vrPointer = GetComponent<VrPointer>();
        }

        public void Grip ()
        {
            isGripping = true;

            if(vrPointer.Target.transform.GetComponent<Grabbable>())
            {
                item = vrPointer.Target.transform.GetComponent<Grabbable>();
                item.Grab(grabPosition);
                item.transform.position = grabPosition.transform.position;
            }
        }

        public void Release ()
        {
            isGripping = false;
            item?.Release();
            item = null;
        }
    }
}