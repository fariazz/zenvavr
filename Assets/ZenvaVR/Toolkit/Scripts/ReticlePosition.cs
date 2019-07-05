using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    public class ReticlePosition : MonoBehaviour
    {
        [Tooltip("VrPointer controller")]
        public VrPointer vrPointer;

        [Tooltip("Reticle")]
        public Reticle reticle;


        private void Awake()
        {
            if (!vrPointer) throw new System.Exception("VrPointer missing");
            if (!reticle) throw new System.Exception("Reticle missing");
        }

        // Update is called once per frame
        void Update()
        {
            if (vrPointer.Target.distance > 0)
                reticle.SetPosition(vrPointer.Target);
            else
                reticle.SetPosition();
        }
    }
}