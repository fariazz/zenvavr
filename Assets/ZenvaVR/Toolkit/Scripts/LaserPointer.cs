using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserPointer : MonoBehaviour
    {
        [Tooltip("VrPointer controller")]
        public VrPointer vrPointer;

        LineRenderer lineRend;
        Vector3[] linePoints;

        void Awake()
        {
            lineRend = GetComponent<LineRenderer>();

            linePoints = new Vector3[2];

            // if not passed, try to find in parents
            if (!vrPointer)
                vrPointer = GetComponentInParent<VrPointer>();

            if (!vrPointer)
                throw new System.Exception("VrPointer missing");   
        }

        // Update is called once per frame
        void Update()
        {
            // set the starting and ending position of the Line Renderer
            linePoints[0] = transform.position;
            linePoints[1] = vrPointer.EndPosition;

            lineRend.SetPositions(linePoints);
        }
    }
}